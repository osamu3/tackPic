namespace takepic {
	partial class Form1 {
		/// <summary>
		/// 必要なデザイナー変数です。
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// 使用中のリソースをすべてクリーンアップします。
		/// </summary>
		/// <param name="disposing">マネージ リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
		protected override void Dispose(bool disposing) {
			if (disposing && (components != null)) {
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows フォーム デザイナーで生成されたコード

		/// <summary>
		/// デザイナー サポートに必要なメソッドです。このメソッドの内容を
		/// コード エディターで変更しないでください。
		/// </summary>
		private void InitializeComponent() {
			this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
			this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
			this.pictureBox2 = new System.Windows.Forms.PictureBox();
			this.label_name = new System.Windows.Forms.Label();
			this.button_toggleliveview = new System.Windows.Forms.Button();
			this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
			this.panel1 = new System.Windows.Forms.Panel();
			this.chkBxFileSave = new System.Windows.Forms.CheckBox();
			this.chkBxFtpUpLoad = new System.Windows.Forms.CheckBox();
			this.button_capture = new System.Windows.Forms.Button();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.rdBtnIIS = new System.Windows.Forms.RadioButton();
			this.rdBtnAzure = new System.Windows.Forms.RadioButton();
			this.txtBxURL = new System.Windows.Forms.TextBox();
			this.btnCallSeverHub = new System.Windows.Forms.Button();
			this.picBoxPhotImage = new System.Windows.Forms.PictureBox();
			this.tableLayoutPanel1.SuspendLayout();
			this.tableLayoutPanel2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
			this.tableLayoutPanel3.SuspendLayout();
			this.panel1.SuspendLayout();
			this.groupBox1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.picBoxPhotImage)).BeginInit();
			this.SuspendLayout();
			// 
			// tableLayoutPanel1
			// 
			this.tableLayoutPanel1.ColumnCount = 2;
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 23.07692F));
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 76.92308F));
			this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 0);
			this.tableLayoutPanel1.Controls.Add(this.picBoxPhotImage, 1, 0);
			this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
			this.tableLayoutPanel1.Name = "tableLayoutPanel1";
			this.tableLayoutPanel1.RowCount = 1;
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
			this.tableLayoutPanel1.Size = new System.Drawing.Size(1017, 747);
			this.tableLayoutPanel1.TabIndex = 0;
			// 
			// tableLayoutPanel2
			// 
			this.tableLayoutPanel2.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
			this.tableLayoutPanel2.ColumnCount = 1;
			this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel2.Controls.Add(this.pictureBox2, 0, 3);
			this.tableLayoutPanel2.Controls.Add(this.label_name, 0, 0);
			this.tableLayoutPanel2.Controls.Add(this.button_toggleliveview, 0, 2);
			this.tableLayoutPanel2.Controls.Add(this.tableLayoutPanel3, 0, 1);
			this.tableLayoutPanel2.Controls.Add(this.btnCallSeverHub, 0, 4);
			this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 3);
			this.tableLayoutPanel2.Name = "tableLayoutPanel2";
			this.tableLayoutPanel2.RowCount = 6;
			this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
			this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 116F));
			this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 53F));
			this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 104F));
			this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 45F));
			this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 18F));
			this.tableLayoutPanel2.Size = new System.Drawing.Size(228, 691);
			this.tableLayoutPanel2.TabIndex = 0;
			// 
			// pictureBox2
			// 
			this.pictureBox2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.pictureBox2.Location = new System.Drawing.Point(4, 206);
			this.pictureBox2.Name = "pictureBox2";
			this.pictureBox2.Size = new System.Drawing.Size(220, 98);
			this.pictureBox2.TabIndex = 0;
			this.pictureBox2.TabStop = false;
			// 
			// label_name
			// 
			this.label_name.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.label_name.AutoSize = true;
			this.label_name.Location = new System.Drawing.Point(83, 10);
			this.label_name.Name = "label_name";
			this.label_name.Size = new System.Drawing.Size(62, 12);
			this.label_name.TabIndex = 1;
			this.label_name.Text = "No Camera";
			// 
			// button_toggleliveview
			// 
			this.button_toggleliveview.Dock = System.Windows.Forms.DockStyle.Fill;
			this.button_toggleliveview.Location = new System.Drawing.Point(4, 152);
			this.button_toggleliveview.Name = "button_toggleliveview";
			this.button_toggleliveview.Size = new System.Drawing.Size(220, 47);
			this.button_toggleliveview.TabIndex = 3;
			this.button_toggleliveview.Text = "Toggle Live View";
			this.button_toggleliveview.UseVisualStyleBackColor = true;
			this.button_toggleliveview.Click += new System.EventHandler(this.button_toggleliveview_Click);
			// 
			// tableLayoutPanel3
			// 
			this.tableLayoutPanel3.ColumnCount = 2;
			this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 114F));
			this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel3.Controls.Add(this.panel1, 0, 1);
			this.tableLayoutPanel3.Controls.Add(this.button_capture, 1, 1);
			this.tableLayoutPanel3.Controls.Add(this.groupBox1, 0, 0);
			this.tableLayoutPanel3.Controls.Add(this.txtBxURL, 1, 0);
			this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanel3.Location = new System.Drawing.Point(4, 35);
			this.tableLayoutPanel3.Name = "tableLayoutPanel3";
			this.tableLayoutPanel3.RowCount = 2;
			this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 47F));
			this.tableLayoutPanel3.Size = new System.Drawing.Size(220, 110);
			this.tableLayoutPanel3.TabIndex = 4;
			// 
			// panel1
			// 
			this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.panel1.Controls.Add(this.chkBxFileSave);
			this.panel1.Controls.Add(this.chkBxFtpUpLoad);
			this.panel1.Location = new System.Drawing.Point(3, 66);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(108, 41);
			this.panel1.TabIndex = 3;
			// 
			// chkBxFileSave
			// 
			this.chkBxFileSave.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.chkBxFileSave.AutoSize = true;
			this.chkBxFileSave.Checked = true;
			this.chkBxFileSave.CheckState = System.Windows.Forms.CheckState.Checked;
			this.chkBxFileSave.Location = new System.Drawing.Point(4, 22);
			this.chkBxFileSave.Name = "chkBxFileSave";
			this.chkBxFileSave.Size = new System.Drawing.Size(82, 16);
			this.chkBxFileSave.TabIndex = 4;
			this.chkBxFileSave.Text = "ファイル保存";
			this.chkBxFileSave.UseVisualStyleBackColor = true;
			// 
			// chkBxFtpUpLoad
			// 
			this.chkBxFtpUpLoad.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.chkBxFtpUpLoad.AutoSize = true;
			this.chkBxFtpUpLoad.Location = new System.Drawing.Point(4, 3);
			this.chkBxFtpUpLoad.Name = "chkBxFtpUpLoad";
			this.chkBxFtpUpLoad.Size = new System.Drawing.Size(77, 16);
			this.chkBxFtpUpLoad.TabIndex = 3;
			this.chkBxFtpUpLoad.Text = "アップロード";
			this.chkBxFtpUpLoad.UseVisualStyleBackColor = true;
			// 
			// button_capture
			// 
			this.button_capture.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.button_capture.Location = new System.Drawing.Point(115, 64);
			this.button_capture.Margin = new System.Windows.Forms.Padding(1);
			this.button_capture.Name = "button_capture";
			this.button_capture.Size = new System.Drawing.Size(104, 45);
			this.button_capture.TabIndex = 2;
			this.button_capture.Text = "写真を撮る";
			this.button_capture.UseVisualStyleBackColor = true;
			this.button_capture.Click += new System.EventHandler(this.button_capture_Click);
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.rdBtnIIS);
			this.groupBox1.Controls.Add(this.rdBtnAzure);
			this.groupBox1.Location = new System.Drawing.Point(3, 3);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(108, 57);
			this.groupBox1.TabIndex = 4;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "groupBox1";
			// 
			// rdBtnIIS
			// 
			this.rdBtnIIS.AutoSize = true;
			this.rdBtnIIS.Checked = true;
			this.rdBtnIIS.Location = new System.Drawing.Point(6, 35);
			this.rdBtnIIS.Name = "rdBtnIIS";
			this.rdBtnIIS.Size = new System.Drawing.Size(100, 16);
			this.rdBtnIIS.TabIndex = 1;
			this.rdBtnIIS.TabStop = true;
			this.rdBtnIIS.Text = "Local IIS Sever";
			this.rdBtnIIS.UseVisualStyleBackColor = true;
			// 
			// rdBtnAzure
			// 
			this.rdBtnAzure.AutoSize = true;
			this.rdBtnAzure.Location = new System.Drawing.Point(6, 14);
			this.rdBtnAzure.Name = "rdBtnAzure";
			this.rdBtnAzure.Size = new System.Drawing.Size(101, 16);
			this.rdBtnAzure.TabIndex = 0;
			this.rdBtnAzure.Text = "Azure Web Site";
			this.rdBtnAzure.UseVisualStyleBackColor = true;
			this.rdBtnAzure.CheckedChanged += new System.EventHandler(this.rdBtnAzure_CheckedChanged);
			// 
			// txtBxURL
			// 
			this.txtBxURL.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.txtBxURL.Location = new System.Drawing.Point(117, 12);
			this.txtBxURL.Multiline = true;
			this.txtBxURL.Name = "txtBxURL";
			this.txtBxURL.Size = new System.Drawing.Size(100, 38);
			this.txtBxURL.TabIndex = 5;
			// 
			// btnCallSeverHub
			// 
			this.btnCallSeverHub.Location = new System.Drawing.Point(4, 311);
			this.btnCallSeverHub.Name = "btnCallSeverHub";
			this.btnCallSeverHub.Size = new System.Drawing.Size(196, 23);
			this.btnCallSeverHub.TabIndex = 5;
			this.btnCallSeverHub.Text = "デバッグ用：[Nothig]";
			this.btnCallSeverHub.UseVisualStyleBackColor = true;
			this.btnCallSeverHub.Click += new System.EventHandler(this.btnCallSeverHub_Click);
			// 
			// picBoxPhotImage
			// 
			this.picBoxPhotImage.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.picBoxPhotImage.Location = new System.Drawing.Point(237, 3);
			this.picBoxPhotImage.Name = "picBoxPhotImage";
			this.picBoxPhotImage.Size = new System.Drawing.Size(777, 741);
			this.picBoxPhotImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.picBoxPhotImage.TabIndex = 1;
			this.picBoxPhotImage.TabStop = false;
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1017, 747);
			this.Controls.Add(this.tableLayoutPanel1);
			this.Name = "Form1";
			this.Text = "Form1";
			this.tableLayoutPanel1.ResumeLayout(false);
			this.tableLayoutPanel2.ResumeLayout(false);
			this.tableLayoutPanel2.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
			this.tableLayoutPanel3.ResumeLayout(false);
			this.tableLayoutPanel3.PerformLayout();
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.picBoxPhotImage)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
		private System.Windows.Forms.PictureBox pictureBox2;
		private System.Windows.Forms.Label label_name;
		private System.Windows.Forms.Button button_capture;
		private System.Windows.Forms.Button button_toggleliveview;
		private System.Windows.Forms.PictureBox picBoxPhotImage;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
		private System.Windows.Forms.CheckBox chkBxFtpUpLoad;
		private System.Windows.Forms.Button btnCallSeverHub;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.CheckBox chkBxFileSave;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.RadioButton rdBtnIIS;
		private System.Windows.Forms.RadioButton rdBtnAzure;
		private System.Windows.Forms.TextBox txtBxURL;
	}
}

