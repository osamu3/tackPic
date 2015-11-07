using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;
using System.IO;
using System.Net;//FTP Up Load用
using System.Text.RegularExpressions;//ファイル名抽出用
using Nikon;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Client;

using System.Diagnostics;



namespace takepic {
	public partial class Form1 : Form {
		private NikonManager _Manager;
		private NikonDevice _Device;
		private System.Windows.Forms.Timer _LiveViewTimer;
		private Image _PhotImg;
		private Image _LiveViewImg;
		private string _LiveViewImgFlNm = "liveViewImg.jpg";

		private HubConnection _HubConnection;
		private IHubProxy _HubProxy;


		public Form1() {
			InitializeComponent();

			// Disable buttons
			ToggleButtons(false);

			// ライブビューのフレームレートをタイマーでセット
			_LiveViewTimer = new System.Windows.Forms.Timer();
			_LiveViewTimer.Tick += new System.EventHandler(liveViewTimer_Tick);
			_LiveViewTimer.Interval = 1000;//１秒間に１回　1000/30で 30フレーム／秒

			// Nikon managerオブジェクト作成しイベントハンドラを登録する。
			_Manager = new NikonManager("Type0011.md3");
			_Manager.DeviceAdded += new DeviceAddedDelegate(manager_DeviceAdded);
			_Manager.DeviceRemoved += new DeviceRemovedDelegate(manager_DeviceRemoved);


			// SignalR オブジェクト作成しHubのイベントハンドラを登録する。
			setHubConnection();

		}

		//（注）グローバル変数【_HubConnection】を編集しています。イベントハンドラ中で実行するので、大域変数を利用しなければならなかったため。
		void setHubConnection() {
			//現在稼働中のハブコネクションがあれば、いったん廃棄
			if (_HubConnection != null) {
				_HubConnection.Stop();
				_HubConnection.Dispose();
			}
			if (rdBtnAzure.Checked)
				_HubConnection = new HubConnection("http://picupsignalr.azurewebsites.net/");
			else
				_HubConnection = new HubConnection("http://LocalHost/");

			txtBxURL.Text = _HubConnection.Url.ToString();

			// HubConnectionをStartする前にHelloHubクラスに対するproxyを作っておく
			_HubProxy = _HubConnection.CreateHubProxy("WatchFolder");

			// サーバーから【PushShutter】という通知が送られてきたら【takeAPicture】を実行するデリゲートをのメソッドを登録
			_HubProxy.On<string>("PushShutter", takeAPicture);

			_HubConnection.Start();
		}


		//シャッターボタン押下指令　拝命 
		void takeAPicture(string s) {
			// 説明文
			#region
			//↓は、コントロールが作成されたスレッドとは別スレッドから呼び出されるため、エラーとなる；
			//ToggleButtons(false);
			//よって、Invokeとデリゲートを使用(Invokeは、元のスレッドと同じスレッドハンドルでデリゲートを実行する)
			//------------------------------------------------------------------------------------------------------
			// stringを引数に取りintを返すsetFocusメソッドを参照する'DlgtFnc'デリゲートを生成
			//		Func<string, int> DlgtFnc = setFocus;
			//	↑を、こんな風に↓インラインで処理を記述したい。
			//		Func<string, int> DlgtFnc = public int setFocus(String str) { ToggleButtons(false);return 0;}
			// そこで匿名メソッドを使用して、【setFocus】メソッド名を省略
			//		Func<string, int> DlgtFnc = delegate (string str) { ToggleButtons(false);return 0;}
			// 更にラムダ式
			//		Func<string, int> DlgtFnc = (string str) => { ToggleButtons(false);return 0;};
			// 更に更に省略
			//		Func<string, int> DlgtFnc = str => { ToggleButtons(false);return 0;};
			// これをInvokeで利用するため、Func型宣言と実行を同時に行うため匿名メソッドを使用
			//		Invoke((MethodInvoker)delegate () { ToggleButtons(false);});
			// 更に、ラムダ式を利用
			//		Invoke((MethodInvoker)(() => { ToggleButtons(false); }));
			//-------------------------------------------------------------------------------------------------------
			#endregion

			Task.Factory.StartNew(() => {//すぐにスタート
				Invoke((MethodInvoker)(() => {
					if (_Device == null) {
						return;
					}

					ToggleButtons(false);

					try {
						_Device.Capture();
					} catch (NikonException ex) {
						Console.WriteLine("シャッター押下に失敗しました。" + ex.Message);
						ToggleButtons(true);
					}
					picBoxPhotImage.Image = null;
				}));
			});
		}


		//ローカルIIS接続時のファイル書き込み終了イベント：写真画像及びライブ保存完了時に呼び出される。
		//private void writeImgFileCallback( IAsyncResult ar) {
		private void writeImgFileCallback(IAsyncResult ar) {
			//保存したファイル名を取得するには、↓ではだめ
			//private void writePhotFileCallback(string fileName) {
			//ファイル名を取り出すため、FileStreamから取り出すのはダサい
			//System.IO.FileStream fs = (System.IO.FileStream)ar.AsyncState;
			//よって、flStream.BeginWriteのイベントハンドラのstate パラメータを使用する（因みにFrameWork4.5からはWriteAsync()を使用
			//使い方は、【Socket.BeginConnect() のヘルプの「解説」】より
			//【state パラメータを使用して、 Socket を BeginConnect に渡さなければなりません。他の情報がコールバックに必要な場合は、小さなクラスを作成して Socket などの必要な情報を保持します。
			//このクラスのインスタンスは、 state パラメータを使用して BeginConnect メソッドに渡します。】cf:http://dobon.net/vb/bbs/log3-20/11887.html
			//よって、BeginWrite(byte[] buffer,int offset,int size,	AsyncCallback callback,	Object state)
			//の、stateオブジェクトに渡す自前クラス設定する。

			EvHndParamClass param = (EvHndParamClass)ar.AsyncState;
			//保存した写真画像名を抽出
			//Regex reg = new Regex(@"phot[0-9].*[.]jpg$");
			//Match mtchStr = reg.Match(fs.Name);

			//サーバの「PhotChangeハブ」へ保存ファイル名を通知
			try {
				//_HubProxy.Invoke("PhotChange", mtchStr.ToString()).Wait();
				_HubProxy.Invoke("PhotChange", param.str).Wait();
			} catch (Exception ex) {
				Console.WriteLine("err:" + ex.Message + "Webサーバ呼び出しエラーです。");
			}
		}

		//ライブ画像の書き込み終了時に呼び出されるメソッド：ここから【PhotChange】Hubを呼び出す。
		private void writeLiveImgFileCallback(IAsyncResult ar) {
			//			Console.WriteLine("LovView映像配信中");
			//サーバの【PhotChange】Hubへ保存したファイル名を通知
			try {
				_HubProxy.Invoke("PhotChange", _LiveViewImgFlNm).Wait();
			} catch (Exception ex) {
				Console.WriteLine("err:" + ex.Message + "Webサーバ呼び出しエラーです。");
			}
		}


		// 撮影画像の準備完了時のイベントメソッド：撮影画像を保存し、保存完了時に【writeImgFileCallback】Hubを呼び出す。
		void device_ImageReady(NikonDevice sender, NikonImage image) {
			using (MemoryStream memStream = new MemoryStream(image.Buffer)) {
				// 画像データの検証オン
				_PhotImg = System.Drawing.Image.FromStream(memStream);

				//保存する写真画像のユーニークなファイル名
				//確認用に、フォームに撮った写真をフォームに表示
				picBoxPhotImage.Image = _PhotImg;

				//写真画像保存時のファイル名にユニークな名前を付ける。
				string fileUnqNm = "phot" + DateTime.Now.Month.ToString() + "_" + DateTime.Now.Day.ToString() + "_" + DateTime.Now.Hour.ToString() + "_" + DateTime.Now.Minute.ToString() + "_" + DateTime.Now.Second.ToString() + "_" + DateTime.Now.Millisecond.ToString() + ".jpg";

				#region 条件分岐：ローカルサーバへのファイル保存がONなら
				if (chkBxFileSave.Checked == true) {
					try {//ファイル保存
						Console.WriteLine("写真画像保存開始");

						//flStream.BeginWriteイベントハンド呼び出し時に使用するステイタスパラメータクラスのインスタンスを作成
						using (EvHndParamClass param = new EvHndParamClass()) {

							// ファイル書き込み終了時のイベントハンドラで実行されるコールバックメソッド内でファイル名を利用すため
							//そのイベントハンドラに渡すパラメータの、stプロパティにファイル名をセット						
							param.str = fileUnqNm;

							//非同期書き込み用のファイルストリームを作成
							using (FileStream flStream = new FileStream(@"C:\inetpub\wwwroot\images/" + fileUnqNm, FileMode.Create,
																		FileAccess.Write, FileShare.ReadWrite, image.Buffer.Length, true)) {
								//非同期書き込み、書き込み終了時に呼び出されるメソッド【writeFileCallback】
								//flStream.BeginWrite(image.Buffer, 0, image.Buffer.Length, new AsyncCallback(writeImgFileCallback), flStream);
								flStream.BeginWrite(image.Buffer, 0, image.Buffer.Length, new AsyncCallback(writeImgFileCallback), param);
								//							await writer.WriteAsync(input);
							}
						}
					} catch (Exception ex) {
						Console.WriteLine("err:" + ex.Message + " 写真画像ファイル書き込み失敗!");
					}
				}
				#endregion

				#region 条件分岐: FTPアップロードチェックボックスがONなら
				if (chkBxFtpUpLoad.Checked == true) {
					try {//↓は、FTPにて写真アップロードの【場合】です。
						WebClient wc = new WebClient();
						//アップロード完了時イベントを登録
						wc.UploadDataCompleted += (s, e) => {
							Console.WriteLine("アップロード完了");
							_HubProxy.Invoke("PhotChange", fileUnqNm).Wait();
						};

						//Uri u = new Uri("" + fileUnqNm);

						//認証設定
//						wc.Credentials = new NetworkCredential(@"", "");

						Console.WriteLine("写真画像FTPアップロード開始");
						wc.UploadDataAsync(u, image.Buffer);
					} catch (Exception ex) {
						//MessageBox.Show(ex.ToString());
						Console.WriteLine("err:" + ex.Message + " 写真画像FTPアップロード失敗!");
					}
				}
				#endregion
			}
		}

		// タイマー割り込みでライブビューを表示するイベントメソッド(画像ファイルのローカル保存 Or ＦＴＰ)
		void liveViewTimer_Tick(object sender, EventArgs e) {
			// Get live view image
			NikonLiveViewImage image = null;

			try {
				image = _Device.GetLiveViewImage();
			} catch (NikonException) {
				_LiveViewTimer.Stop();
			}

			if (image != null) {
				MemoryStream memStream = new MemoryStream(image.JpegBuffer);
				//確認用に、フォームに撮った写真をフォームに表示
				_LiveViewImg = System.Drawing.Image.FromStream(memStream);
				picBoxPhotImage.Image = _LiveViewImg;

				#region 条件分岐：ローカルサーバへのファイル保存がONなら
				if (chkBxFileSave.Checked == true) {
					try {//ファイルを上書きで保存（ファイル名固定）

						Console.WriteLine("ライブ画像保存開始");

						//非同期書き込み用のファイルストリームを作成
						using (FileStream flStream = new FileStream(@"C:\inetpub\wwwroot\images/" + _LiveViewImgFlNm, FileMode.Create,
																	FileAccess.Write, FileShare.ReadWrite, image.JpegBuffer.Length, true)) {

							//flStream.BeginWriteイベントハンド呼び出し時に使用するステイタスパラメータクラスのインスタンスを作成
							using (EvHndParamClass param = new EvHndParamClass()) {
								//ファイル書き込み終了時のイベントハンドラで実行されるコールバックメソッド内でファイル名を利用すため
								//そのイベントハンドラに渡すパラメータの、stプロパティにファイル名をセット
								param.str = _LiveViewImgFlNm;

								//非同期に書き込み処理を実行する。当該イベント完了時に呼び出されるメソッド【writeImgFileCallback】を設定
								flStream.BeginWrite(image.JpegBuffer, 0, image.JpegBuffer.Length, new AsyncCallback(writeImgFileCallback), param);
								//	await writer.WriteAsync(input);//←Frame Work 4.5以上でないと使えない？
							}
						}
					} catch (Exception ex) {
						Console.WriteLine("err:" + ex.Message + " ライブ画像ファイル書き込み失敗!");
					}
				}
				#endregion

				#region 条件分岐: FTPアップロードチェックボックスがONなら
				if (chkBxFtpUpLoad.Checked == true) {
					try {//↓は、FTPにて写真アップロードの【場合】です。
						WebClient wc = new WebClient();
						//アップロード完了時イベントを登録
						wc.UploadDataCompleted += (s, ev) => {
							Console.WriteLine("アップロード完了");
							_HubProxy.Invoke("PhotChange", _LiveViewImgFlNm).Wait();
						};

						Uri u = new Uri("" + _LiveViewImgFlNm);
						//認証設定
						wc.Credentials = new NetworkCredential();

						Console.WriteLine("写真画像FTPアップロード開始");
						wc.UploadDataAsync(u, image.JpegBuffer);
					} catch (Exception ex) {
						//MessageBox.Show(ex.ToString());
						Console.WriteLine("err:" + ex.Message + " 写真画像FTPアップロード失敗!");
					}
				}
				#endregion

			}
		}

		// 写真撮影ボタンクリック時のイベントメソッド(コールバック)
		private void button_capture_Click(object sender, EventArgs e) {
			if (_Device == null) {
				return;
			}

			ToggleButtons(false);

			try {
				// シャッターを押し、画像をバッファへ転送する。
				//画像が準備できれば【device_ImageR】イベント発火
				_Device.Capture();
			} catch (NikonException ex) {
				Console.WriteLine("err:" + ex.Message + " 写真画像FTPアップロード失敗!");
				ToggleButtons(true);
			}

			picBoxPhotImage.Image = null;
		}

		//デバッグ用：何もしない。
		private void btnCallSeverHub_Click(object sender, EventArgs e) {

			MessageBox.Show("何もしないことにしました。");
			//Hub呼び出しテスト　_HubProxy.Invoke("PhotChange", "default.jpg").Wait();

		}

		// 撮影完了時にトグルボタンをONにするイベントメソッド(コールバック)
		void device_CaptureComplete(NikonDevice sender, int data) {
			// Re-enable buttons when the capture completes
			ToggleButtons(true);
		}

		// ライブビュー表示／非表示トグルボタン押下時のイベントメソッド（コールバック）
		void ToggleButtons(bool enabled) {
			this.button_capture.Enabled = enabled;
			this.button_toggleliveview.Enabled = enabled;
		}

		// ライブビュー開始／中止トグルボタン押下時のイベントメソッド(コールバック)
		private void button_toggleliveview_Click(object sender, EventArgs e) {
			if (_Device == null) {
				return;
			}
			if (_Device.LiveViewEnabled) {
				_Device.LiveViewEnabled = false;
				_LiveViewTimer.Stop();
				picBoxPhotImage.Image = null;
			} else {
				_Device.LiveViewEnabled = true;
				_LiveViewTimer.Start();
			}
		}

		// アプリ終了時のフォームクローズイベントメソッド(コールバック)
		protected override void OnClosing(CancelEventArgs e) {
			// Disable live view (in case it's enabled)
			if (_Device != null) {
				if (_Device.LiveViewEnabled) 
					_Device.LiveViewEnabled = false;
			}

			// Shut down the Nikon manager
			_Manager.Shutdown();
			base.OnClosing(e);
		}

		// カメラ接続開始時のイベントメソッド(コールバック)
		void manager_DeviceAdded(NikonManager sender, NikonDevice device) {
			this._Device = device;

			// Set the device name
			label_name.Text = device.Name;

			// Enable buttons
			ToggleButtons(true);

			// 撮影画像のバッファへの転送完了イベント
			device.ImageReady += new ImageReadyDelegate(device_ImageReady);
			// 撮影完了時のイベント(トグルボタンOFF→ON）
			device.CaptureComplete += new CaptureCompleteDelegate(device_CaptureComplete);
		}

		// カメラ接続終了時のイベントメソッド(コールバック)
		void manager_DeviceRemoved(NikonManager sender, NikonDevice device) {
			this._Device = null;

			// Stop live view timer
			_LiveViewTimer.Stop();

			// Clear device name
			label_name.Text = "No Camera";

			// Disable buttons
			ToggleButtons(false);

			// Clear live view picture
			picBoxPhotImage.Image = null;
		}

		//Webサーバー切り替え時に、Hubコネクション再構築を行う
		private void rdBtnAzure_CheckedChanged(object sender, EventArgs e) {
			setHubConnection();
		}
	}

	//flStream.BeginWriteイベントハンド呼び出し時に使用するステイタスパラメータクラスの宣言
	public class EvHndParamClass : IDisposable {
		public string str;

		//コンストラクタ
		public EvHndParamClass() {
			str = "default";
		}
		//デストラクタ
		~EvHndParamClass() {
			Console.WriteLine("EvHndParamClassのインスタンスのデストラクタが呼び出されました。");
		}
		//Using区で確実にディスポーズするため
		void IDisposable.Dispose() {
			Console.WriteLine("EvHndParamClassのインスタンスが、Using区の終了でディスポーズされました。");
		}
	}
}
