

using System.Windows.Forms;

namespace ImageProcessing
{
    partial class IR_Camera
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.Binning = new System.Windows.Forms.GroupBox();
            this.Zoom = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.Post = new System.Windows.Forms.GroupBox();
            this.txtPost_BuocNhay = new System.Windows.Forms.TextBox();
            this.lblNextFrame = new System.Windows.Forms.Label();
            this.lbl_NumberOfFrame = new System.Windows.Forms.Label();
            this.txtPost_Frames = new System.Windows.Forms.TextBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.NUC = new System.Windows.Forms.GroupBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.rdbNUC2 = new System.Windows.Forms.RadioButton();
            this.label17 = new System.Windows.Forms.Label();
            this.rdbNUC1 = new System.Windows.Forms.RadioButton();
            this.comboBoxTempNuc = new System.Windows.Forms.ComboBox();
            this.txtNUC1_Nhiet = new System.Windows.Forms.TextBox();
            this.txtNUC2_Nhiet = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.btnNUC2_Upload = new System.Windows.Forms.Button();
            this.btnNUC1Upload = new System.Windows.Forms.Button();
            this.label15 = new System.Windows.Forms.Label();
            this.txtNUC2_Path = new System.Windows.Forms.TextBox();
            this.txtNuc1_Path = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.BPR = new System.Windows.Forms.GroupBox();
            this.btnNOISE_UPLOAD = new System.Windows.Forms.Button();
            this.btn_OFFSET_UPLOAD = new System.Windows.Forms.Button();
            this.txtNOISE_Duongdan = new System.Windows.Forms.TextBox();
            this.txtNOISE_Nhiet = new System.Windows.Forms.TextBox();
            this.txtOFFSET_Duongdan = new System.Windows.Forms.TextBox();
            this.txtOFFSET_Nhiet = new System.Windows.Forms.TextBox();
            this.label21 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.rdbNoise = new System.Windows.Forms.RadioButton();
            this.rdbOffset = new System.Windows.Forms.RadioButton();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.EDGE = new System.Windows.Forms.GroupBox();
            this.textBox8 = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.hScrollBar2 = new System.Windows.Forms.HScrollBar();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.tabPage6 = new System.Windows.Forms.TabPage();
            this.AGC = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox6 = new System.Windows.Forms.TextBox();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.radioButton5 = new System.Windows.Forms.RadioButton();
            this.radioButton4 = new System.Windows.Forms.RadioButton();
            this.radioButton3 = new System.Windows.Forms.RadioButton();
            this.tabPage7 = new System.Windows.Forms.TabPage();
            this.Flip = new System.Windows.Forms.GroupBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.rdb_y = new System.Windows.Forms.RadioButton();
            this.rdb_x = new System.Windows.Forms.RadioButton();
            this.tabPage8 = new System.Windows.Forms.TabPage();
            this.Gamma = new System.Windows.Forms.GroupBox();
            this.textBox9 = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.hScrollBar1 = new System.Windows.Forms.HScrollBar();
            this.tabPage9 = new System.Windows.Forms.TabPage();
            this.btnStart = new System.Windows.Forms.Button();
            this.btnStop = new System.Windows.Forms.Button();
            this.vScrollBar1 = new System.Windows.Forms.VScrollBar();
            this.Grp_Zoom = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.btnFocus = new System.Windows.Forms.Button();
            this.btnGamma = new System.Windows.Forms.Button();
            this.btnEdge = new System.Windows.Forms.Button();
            this.btnPost = new System.Windows.Forms.Button();
            this.btnNUC = new System.Windows.Forms.Button();
            this.btnBpr = new System.Windows.Forms.Button();
            this.btnBinning = new System.Windows.Forms.Button();
            this.btnAgc = new System.Windows.Forms.Button();
            this.btnFlip = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.BtnBprDynamic = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.rdPicture = new System.Windows.Forms.RadioButton();
            this.lblPath = new System.Windows.Forms.Label();
            this.textBox7 = new System.Windows.Forms.TextBox();
            this.btnOpenCAM_VIDEO_PIC = new System.Windows.Forms.Button();
            this.rdVideo = new System.Windows.Forms.RadioButton();
            this.rdCAMLink = new System.Windows.Forms.RadioButton();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnExit = new System.Windows.Forms.Button();
            this.grpSetting = new System.Windows.Forms.GroupBox();
            this.btnSendToFPGA = new System.Windows.Forms.Button();
            this.btnsave = new System.Windows.Forms.Button();
            this.btnUpload = new System.Windows.Forms.Button();
            this.btnSetting = new System.Windows.Forms.Button();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.pvDisplayControl = new System.Windows.Forms.PictureBox();
            this.groupBox8 = new System.Windows.Forms.GroupBox();
            this.pvDisplayControl2 = new System.Windows.Forms.PictureBox();
            this.groupBox9 = new System.Windows.Forms.GroupBox();
            this.pvDisplayControlFocus = new System.Windows.Forms.PictureBox();
            this.pvDisplayControl3 = new System.Windows.Forms.PictureBox();
            this.textBoxFocus = new System.Windows.Forms.TextBox();
            this.textBoxAutoFocus = new System.Windows.Forms.TextBox();
            this.Zoom.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.Post.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.NUC.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.BPR.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.EDGE.SuspendLayout();
            this.tabPage5.SuspendLayout();
            this.tabPage6.SuspendLayout();
            this.AGC.SuspendLayout();
            this.tabPage7.SuspendLayout();
            this.Flip.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.tabPage8.SuspendLayout();
            this.Gamma.SuspendLayout();
            this.Grp_Zoom.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.grpSetting.SuspendLayout();
            this.groupBox7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pvDisplayControl)).BeginInit();
            this.groupBox8.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pvDisplayControl2)).BeginInit();
            this.groupBox9.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pvDisplayControlFocus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pvDisplayControl3)).BeginInit();
            this.SuspendLayout();
            // 
            // Binning
            // 
            this.Binning.Location = new System.Drawing.Point(18, 20);
            this.Binning.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.Binning.Name = "Binning";
            this.Binning.Padding = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.Binning.Size = new System.Drawing.Size(530, 304);
            this.Binning.TabIndex = 5;
            this.Binning.TabStop = false;
            this.Binning.Text = "Binning";
            // 
            // Zoom
            // 
            this.Zoom.Controls.Add(this.tabPage1);
            this.Zoom.Controls.Add(this.tabPage2);
            this.Zoom.Controls.Add(this.tabPage3);
            this.Zoom.Controls.Add(this.tabPage4);
            this.Zoom.Controls.Add(this.tabPage5);
            this.Zoom.Controls.Add(this.tabPage6);
            this.Zoom.Controls.Add(this.tabPage7);
            this.Zoom.Controls.Add(this.tabPage8);
            this.Zoom.Controls.Add(this.tabPage9);
            this.Zoom.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Zoom.Location = new System.Drawing.Point(5, 18);
            this.Zoom.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.Zoom.Name = "Zoom";
            this.Zoom.SelectedIndex = 0;
            this.Zoom.Size = new System.Drawing.Size(686, 369);
            this.Zoom.TabIndex = 10;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.groupBox6);
            this.tabPage1.Controls.Add(this.Post);
            this.tabPage1.Location = new System.Drawing.Point(4, 38);
            this.tabPage1.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.tabPage1.Size = new System.Drawing.Size(678, 327);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Post";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // groupBox6
            // 
            this.groupBox6.Location = new System.Drawing.Point(353, 28);
            this.groupBox6.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Padding = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.groupBox6.Size = new System.Drawing.Size(306, 301);
            this.groupBox6.TabIndex = 3;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "FPGA Parameters";
            // 
            // Post
            // 
            this.Post.Controls.Add(this.txtPost_BuocNhay);
            this.Post.Controls.Add(this.lblNextFrame);
            this.Post.Controls.Add(this.lbl_NumberOfFrame);
            this.Post.Controls.Add(this.txtPost_Frames);
            this.Post.Location = new System.Drawing.Point(15, 20);
            this.Post.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.Post.Name = "Post";
            this.Post.Padding = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.Post.Size = new System.Drawing.Size(313, 308);
            this.Post.TabIndex = 2;
            this.Post.TabStop = false;
            this.Post.Text = "Software Parameters";
            // 
            // txtPost_BuocNhay
            // 
            this.txtPost_BuocNhay.Location = new System.Drawing.Point(161, 95);
            this.txtPost_BuocNhay.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.txtPost_BuocNhay.Name = "txtPost_BuocNhay";
            this.txtPost_BuocNhay.Size = new System.Drawing.Size(112, 34);
            this.txtPost_BuocNhay.TabIndex = 3;
            this.txtPost_BuocNhay.Text = "1";
            this.txtPost_BuocNhay.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblNextFrame
            // 
            this.lblNextFrame.AutoSize = true;
            this.lblNextFrame.Location = new System.Drawing.Point(28, 97);
            this.lblNextFrame.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.lblNextFrame.Name = "lblNextFrame";
            this.lblNextFrame.Size = new System.Drawing.Size(124, 29);
            this.lblNextFrame.TabIndex = 2;
            this.lblNextFrame.Text = "Bước nhảy";
            // 
            // lbl_NumberOfFrame
            // 
            this.lbl_NumberOfFrame.AutoSize = true;
            this.lbl_NumberOfFrame.Location = new System.Drawing.Point(28, 63);
            this.lbl_NumberOfFrame.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.lbl_NumberOfFrame.Name = "lbl_NumberOfFrame";
            this.lbl_NumberOfFrame.Size = new System.Drawing.Size(122, 29);
            this.lbl_NumberOfFrame.TabIndex = 1;
            this.lbl_NumberOfFrame.Text = "Số frames";
            // 
            // txtPost_Frames
            // 
            this.txtPost_Frames.Location = new System.Drawing.Point(161, 69);
            this.txtPost_Frames.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.txtPost_Frames.Name = "txtPost_Frames";
            this.txtPost_Frames.Size = new System.Drawing.Size(112, 34);
            this.txtPost_Frames.TabIndex = 0;
            this.txtPost_Frames.Text = "5";
            this.txtPost_Frames.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.NUC);
            this.tabPage2.Location = new System.Drawing.Point(4, 38);
            this.tabPage2.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.tabPage2.Size = new System.Drawing.Size(678, 327);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "NUC";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // NUC
            // 
            this.NUC.Controls.Add(this.groupBox4);
            this.NUC.Controls.Add(this.txtNUC1_Nhiet);
            this.NUC.Controls.Add(this.txtNUC2_Nhiet);
            this.NUC.Controls.Add(this.label16);
            this.NUC.Controls.Add(this.btnNUC2_Upload);
            this.NUC.Controls.Add(this.btnNUC1Upload);
            this.NUC.Controls.Add(this.label15);
            this.NUC.Controls.Add(this.txtNUC2_Path);
            this.NUC.Controls.Add(this.txtNuc1_Path);
            this.NUC.Controls.Add(this.label14);
            this.NUC.Controls.Add(this.label13);
            this.NUC.Controls.Add(this.label12);
            this.NUC.Controls.Add(this.label11);
            this.NUC.Location = new System.Drawing.Point(18, 20);
            this.NUC.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.NUC.Name = "NUC";
            this.NUC.Padding = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.NUC.Size = new System.Drawing.Size(650, 305);
            this.NUC.TabIndex = 3;
            this.NUC.TabStop = false;
            this.NUC.Text = "NUC";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.rdbNUC2);
            this.groupBox4.Controls.Add(this.label17);
            this.groupBox4.Controls.Add(this.rdbNUC1);
            this.groupBox4.Controls.Add(this.comboBoxTempNuc);
            this.groupBox4.Location = new System.Drawing.Point(50, 201);
            this.groupBox4.Margin = new System.Windows.Forms.Padding(1);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Padding = new System.Windows.Forms.Padding(1);
            this.groupBox4.Size = new System.Drawing.Size(370, 100);
            this.groupBox4.TabIndex = 16;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Chọn chế độ";
            // 
            // rdbNUC2
            // 
            this.rdbNUC2.AutoSize = true;
            this.rdbNUC2.Location = new System.Drawing.Point(238, 28);
            this.rdbNUC2.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.rdbNUC2.Name = "rdbNUC2";
            this.rdbNUC2.Size = new System.Drawing.Size(99, 33);
            this.rdbNUC2.TabIndex = 1;
            this.rdbNUC2.Text = "NUC2";
            this.rdbNUC2.UseVisualStyleBackColor = true;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(18, 64);
            this.label17.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(104, 29);
            this.label17.TabIndex = 15;
            this.label17.Text = "Nhiệt độ";
            // 
            // rdbNUC1
            // 
            this.rdbNUC1.AutoSize = true;
            this.rdbNUC1.Checked = true;
            this.rdbNUC1.Location = new System.Drawing.Point(110, 28);
            this.rdbNUC1.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.rdbNUC1.Name = "rdbNUC1";
            this.rdbNUC1.Size = new System.Drawing.Size(99, 33);
            this.rdbNUC1.TabIndex = 0;
            this.rdbNUC1.TabStop = true;
            this.rdbNUC1.Text = "NUC1";
            this.rdbNUC1.UseVisualStyleBackColor = true;
            // 
            // comboBoxTempNuc
            // 
            this.comboBoxTempNuc.FormattingEnabled = true;
            this.comboBoxTempNuc.Location = new System.Drawing.Point(110, 66);
            this.comboBoxTempNuc.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.comboBoxTempNuc.Name = "comboBoxTempNuc";
            this.comboBoxTempNuc.Size = new System.Drawing.Size(198, 37);
            this.comboBoxTempNuc.TabIndex = 2;
            // 
            // txtNUC1_Nhiet
            // 
            this.txtNUC1_Nhiet.Location = new System.Drawing.Point(156, 43);
            this.txtNUC1_Nhiet.Margin = new System.Windows.Forms.Padding(1);
            this.txtNUC1_Nhiet.Name = "txtNUC1_Nhiet";
            this.txtNUC1_Nhiet.Size = new System.Drawing.Size(195, 34);
            this.txtNUC1_Nhiet.TabIndex = 14;
            // 
            // txtNUC2_Nhiet
            // 
            this.txtNUC2_Nhiet.Location = new System.Drawing.Point(156, 129);
            this.txtNUC2_Nhiet.Margin = new System.Windows.Forms.Padding(1);
            this.txtNUC2_Nhiet.Name = "txtNUC2_Nhiet";
            this.txtNUC2_Nhiet.Size = new System.Drawing.Size(195, 34);
            this.txtNUC2_Nhiet.TabIndex = 13;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(48, 158);
            this.label16.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(130, 29);
            this.label16.TabIndex = 12;
            this.label16.Text = "Đường dẫn";
            // 
            // btnNUC2_Upload
            // 
            this.btnNUC2_Upload.Location = new System.Drawing.Point(539, 148);
            this.btnNUC2_Upload.Margin = new System.Windows.Forms.Padding(1);
            this.btnNUC2_Upload.Name = "btnNUC2_Upload";
            this.btnNUC2_Upload.Size = new System.Drawing.Size(100, 28);
            this.btnNUC2_Upload.TabIndex = 11;
            this.btnNUC2_Upload.Text = "Upload";
            this.btnNUC2_Upload.UseVisualStyleBackColor = true;
            // 
            // btnNUC1Upload
            // 
            this.btnNUC1Upload.Location = new System.Drawing.Point(539, 70);
            this.btnNUC1Upload.Margin = new System.Windows.Forms.Padding(1);
            this.btnNUC1Upload.Name = "btnNUC1Upload";
            this.btnNUC1Upload.Size = new System.Drawing.Size(100, 24);
            this.btnNUC1Upload.TabIndex = 10;
            this.btnNUC1Upload.Text = "Upload";
            this.btnNUC1Upload.UseVisualStyleBackColor = true;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(50, 69);
            this.label15.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(130, 29);
            this.label15.TabIndex = 9;
            this.label15.Text = "Đường dẫn";
            // 
            // txtNUC2_Path
            // 
            this.txtNUC2_Path.Location = new System.Drawing.Point(156, 158);
            this.txtNUC2_Path.Margin = new System.Windows.Forms.Padding(1);
            this.txtNUC2_Path.Name = "txtNUC2_Path";
            this.txtNUC2_Path.Size = new System.Drawing.Size(332, 34);
            this.txtNUC2_Path.TabIndex = 8;
            // 
            // txtNuc1_Path
            // 
            this.txtNuc1_Path.Location = new System.Drawing.Point(156, 70);
            this.txtNuc1_Path.Margin = new System.Windows.Forms.Padding(1);
            this.txtNuc1_Path.Name = "txtNuc1_Path";
            this.txtNuc1_Path.Size = new System.Drawing.Size(332, 34);
            this.txtNuc1_Path.TabIndex = 7;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(48, 129);
            this.label14.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(104, 29);
            this.label14.TabIndex = 6;
            this.label14.Text = "Nhiệt độ";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(48, 47);
            this.label13.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(104, 29);
            this.label13.TabIndex = 5;
            this.label13.Text = "Nhiệt độ";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(18, 106);
            this.label12.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(78, 29);
            this.label12.TabIndex = 4;
            this.label12.Text = "NUC2";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(18, 20);
            this.label11.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(78, 29);
            this.label11.TabIndex = 3;
            this.label11.Text = "NUC1";
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.BPR);
            this.tabPage3.Location = new System.Drawing.Point(4, 38);
            this.tabPage3.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.tabPage3.Size = new System.Drawing.Size(678, 327);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Bpr";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // BPR
            // 
            this.BPR.Controls.Add(this.btnNOISE_UPLOAD);
            this.BPR.Controls.Add(this.btn_OFFSET_UPLOAD);
            this.BPR.Controls.Add(this.txtNOISE_Duongdan);
            this.BPR.Controls.Add(this.txtNOISE_Nhiet);
            this.BPR.Controls.Add(this.txtOFFSET_Duongdan);
            this.BPR.Controls.Add(this.txtOFFSET_Nhiet);
            this.BPR.Controls.Add(this.label21);
            this.BPR.Controls.Add(this.label20);
            this.BPR.Controls.Add(this.label19);
            this.BPR.Controls.Add(this.label18);
            this.BPR.Controls.Add(this.rdbNoise);
            this.BPR.Controls.Add(this.rdbOffset);
            this.BPR.Controls.Add(this.comboBox2);
            this.BPR.Location = new System.Drawing.Point(18, 20);
            this.BPR.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.BPR.Name = "BPR";
            this.BPR.Padding = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.BPR.Size = new System.Drawing.Size(642, 306);
            this.BPR.TabIndex = 4;
            this.BPR.TabStop = false;
            this.BPR.Text = "BPR";
            // 
            // btnNOISE_UPLOAD
            // 
            this.btnNOISE_UPLOAD.Location = new System.Drawing.Point(525, 184);
            this.btnNOISE_UPLOAD.Margin = new System.Windows.Forms.Padding(1);
            this.btnNOISE_UPLOAD.Name = "btnNOISE_UPLOAD";
            this.btnNOISE_UPLOAD.Size = new System.Drawing.Size(113, 28);
            this.btnNOISE_UPLOAD.TabIndex = 12;
            this.btnNOISE_UPLOAD.Text = "Upload";
            this.btnNOISE_UPLOAD.UseVisualStyleBackColor = true;
            // 
            // btn_OFFSET_UPLOAD
            // 
            this.btn_OFFSET_UPLOAD.Location = new System.Drawing.Point(519, 82);
            this.btn_OFFSET_UPLOAD.Margin = new System.Windows.Forms.Padding(1);
            this.btn_OFFSET_UPLOAD.Name = "btn_OFFSET_UPLOAD";
            this.btn_OFFSET_UPLOAD.Size = new System.Drawing.Size(113, 28);
            this.btn_OFFSET_UPLOAD.TabIndex = 11;
            this.btn_OFFSET_UPLOAD.Text = "Upload";
            this.btn_OFFSET_UPLOAD.UseVisualStyleBackColor = true;
            // 
            // txtNOISE_Duongdan
            // 
            this.txtNOISE_Duongdan.Location = new System.Drawing.Point(152, 188);
            this.txtNOISE_Duongdan.Margin = new System.Windows.Forms.Padding(1);
            this.txtNOISE_Duongdan.Name = "txtNOISE_Duongdan";
            this.txtNOISE_Duongdan.Size = new System.Drawing.Size(349, 34);
            this.txtNOISE_Duongdan.TabIndex = 10;
            // 
            // txtNOISE_Nhiet
            // 
            this.txtNOISE_Nhiet.Location = new System.Drawing.Point(152, 157);
            this.txtNOISE_Nhiet.Margin = new System.Windows.Forms.Padding(1);
            this.txtNOISE_Nhiet.Name = "txtNOISE_Nhiet";
            this.txtNOISE_Nhiet.Size = new System.Drawing.Size(165, 34);
            this.txtNOISE_Nhiet.TabIndex = 9;
            // 
            // txtOFFSET_Duongdan
            // 
            this.txtOFFSET_Duongdan.Location = new System.Drawing.Point(152, 87);
            this.txtOFFSET_Duongdan.Margin = new System.Windows.Forms.Padding(1);
            this.txtOFFSET_Duongdan.Name = "txtOFFSET_Duongdan";
            this.txtOFFSET_Duongdan.Size = new System.Drawing.Size(349, 34);
            this.txtOFFSET_Duongdan.TabIndex = 8;
            // 
            // txtOFFSET_Nhiet
            // 
            this.txtOFFSET_Nhiet.Location = new System.Drawing.Point(152, 58);
            this.txtOFFSET_Nhiet.Margin = new System.Windows.Forms.Padding(1);
            this.txtOFFSET_Nhiet.Name = "txtOFFSET_Nhiet";
            this.txtOFFSET_Nhiet.Size = new System.Drawing.Size(165, 34);
            this.txtOFFSET_Nhiet.TabIndex = 7;
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(54, 188);
            this.label21.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(130, 29);
            this.label21.TabIndex = 6;
            this.label21.Text = "Đường dẫn";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(50, 157);
            this.label20.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(104, 29);
            this.label20.TabIndex = 5;
            this.label20.Text = "Nhiệt độ";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(50, 89);
            this.label19.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(130, 29);
            this.label19.TabIndex = 4;
            this.label19.Text = "Đường dẫn";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(48, 60);
            this.label18.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(104, 29);
            this.label18.TabIndex = 3;
            this.label18.Text = "Nhiệt độ";
            // 
            // rdbNoise
            // 
            this.rdbNoise.AutoSize = true;
            this.rdbNoise.Location = new System.Drawing.Point(22, 126);
            this.rdbNoise.Margin = new System.Windows.Forms.Padding(1);
            this.rdbNoise.Name = "rdbNoise";
            this.rdbNoise.Size = new System.Drawing.Size(109, 33);
            this.rdbNoise.TabIndex = 2;
            this.rdbNoise.Text = "NOISE";
            this.rdbNoise.UseVisualStyleBackColor = true;
            // 
            // rdbOffset
            // 
            this.rdbOffset.AutoSize = true;
            this.rdbOffset.Checked = true;
            this.rdbOffset.Location = new System.Drawing.Point(22, 34);
            this.rdbOffset.Margin = new System.Windows.Forms.Padding(1);
            this.rdbOffset.Name = "rdbOffset";
            this.rdbOffset.Size = new System.Drawing.Size(131, 33);
            this.rdbOffset.TabIndex = 1;
            this.rdbOffset.TabStop = true;
            this.rdbOffset.Text = "OFFSET";
            this.rdbOffset.UseVisualStyleBackColor = true;
            // 
            // comboBox2
            // 
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Location = new System.Drawing.Point(152, 226);
            this.comboBox2.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(210, 37);
            this.comboBox2.TabIndex = 0;
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.EDGE);
            this.tabPage4.Location = new System.Drawing.Point(4, 38);
            this.tabPage4.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.tabPage4.Size = new System.Drawing.Size(678, 327);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "Edge";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // EDGE
            // 
            this.EDGE.Controls.Add(this.textBox8);
            this.EDGE.Controls.Add(this.label10);
            this.EDGE.Controls.Add(this.label9);
            this.EDGE.Controls.Add(this.hScrollBar2);
            this.EDGE.Location = new System.Drawing.Point(18, 20);
            this.EDGE.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.EDGE.Name = "EDGE";
            this.EDGE.Padding = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.EDGE.Size = new System.Drawing.Size(640, 305);
            this.EDGE.TabIndex = 5;
            this.EDGE.TabStop = false;
            this.EDGE.Text = "EDGE";
            // 
            // textBox8
            // 
            this.textBox8.Location = new System.Drawing.Point(200, 82);
            this.textBox8.Margin = new System.Windows.Forms.Padding(1);
            this.textBox8.Name = "textBox8";
            this.textBox8.Size = new System.Drawing.Size(125, 34);
            this.textBox8.TabIndex = 3;
            this.textBox8.Text = "0";
            this.textBox8.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(584, 128);
            this.label10.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(52, 29);
            this.label10.TabIndex = 2;
            this.label10.Text = "100";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(5, 128);
            this.label9.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(26, 29);
            this.label9.TabIndex = 1;
            this.label9.Text = "0";
            // 
            // hScrollBar2
            // 
            this.hScrollBar2.Location = new System.Drawing.Point(40, 128);
            this.hScrollBar2.Name = "hScrollBar2";
            this.hScrollBar2.Size = new System.Drawing.Size(532, 34);
            this.hScrollBar2.TabIndex = 0;
            // 
            // tabPage5
            // 
            this.tabPage5.Controls.Add(this.Binning);
            this.tabPage5.Location = new System.Drawing.Point(4, 38);
            this.tabPage5.Margin = new System.Windows.Forms.Padding(1);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Padding = new System.Windows.Forms.Padding(1);
            this.tabPage5.Size = new System.Drawing.Size(678, 327);
            this.tabPage5.TabIndex = 4;
            this.tabPage5.Text = "Binning";
            this.tabPage5.UseVisualStyleBackColor = true;
            // 
            // tabPage6
            // 
            this.tabPage6.Controls.Add(this.AGC);
            this.tabPage6.Location = new System.Drawing.Point(4, 38);
            this.tabPage6.Margin = new System.Windows.Forms.Padding(1);
            this.tabPage6.Name = "tabPage6";
            this.tabPage6.Padding = new System.Windows.Forms.Padding(1);
            this.tabPage6.Size = new System.Drawing.Size(678, 327);
            this.tabPage6.TabIndex = 5;
            this.tabPage6.Text = "Agc";
            this.tabPage6.UseVisualStyleBackColor = true;
            // 
            // AGC
            // 
            this.AGC.Controls.Add(this.label4);
            this.AGC.Controls.Add(this.label3);
            this.AGC.Controls.Add(this.label2);
            this.AGC.Controls.Add(this.label1);
            this.AGC.Controls.Add(this.textBox6);
            this.AGC.Controls.Add(this.textBox5);
            this.AGC.Controls.Add(this.textBox4);
            this.AGC.Controls.Add(this.textBox3);
            this.AGC.Controls.Add(this.radioButton5);
            this.AGC.Controls.Add(this.radioButton4);
            this.AGC.Controls.Add(this.radioButton3);
            this.AGC.Location = new System.Drawing.Point(16, 12);
            this.AGC.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.AGC.Name = "AGC";
            this.AGC.Padding = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.AGC.Size = new System.Drawing.Size(647, 314);
            this.AGC.TabIndex = 8;
            this.AGC.TabStop = false;
            this.AGC.Text = "AGC";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(60, 212);
            this.label4.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(107, 29);
            this.label4.TabIndex = 10;
            this.label4.Text = "LimitSup";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(56, 184);
            this.label3.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(89, 29);
            this.label3.TabIndex = 9;
            this.label3.Text = "LimitInf";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(56, 116);
            this.label2.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(85, 29);
            this.label2.TabIndex = 8;
            this.label2.Text = "ThSup";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(54, 90);
            this.label1.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 29);
            this.label1.TabIndex = 7;
            this.label1.Text = "ThInf";
            // 
            // textBox6
            // 
            this.textBox6.Location = new System.Drawing.Point(176, 212);
            this.textBox6.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.textBox6.Name = "textBox6";
            this.textBox6.Size = new System.Drawing.Size(114, 34);
            this.textBox6.TabIndex = 6;
            // 
            // textBox5
            // 
            this.textBox5.Location = new System.Drawing.Point(176, 184);
            this.textBox5.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(114, 34);
            this.textBox5.TabIndex = 5;
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(176, 116);
            this.textBox4.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(114, 34);
            this.textBox4.TabIndex = 4;
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(176, 90);
            this.textBox3.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(114, 34);
            this.textBox3.TabIndex = 3;
            // 
            // radioButton5
            // 
            this.radioButton5.AutoSize = true;
            this.radioButton5.Location = new System.Drawing.Point(32, 155);
            this.radioButton5.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.radioButton5.Name = "radioButton5";
            this.radioButton5.Size = new System.Drawing.Size(112, 33);
            this.radioButton5.TabIndex = 2;
            this.radioButton5.Text = "Manual";
            this.radioButton5.UseVisualStyleBackColor = true;
            // 
            // radioButton4
            // 
            this.radioButton4.AutoSize = true;
            this.radioButton4.Location = new System.Drawing.Point(32, 62);
            this.radioButton4.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.radioButton4.Name = "radioButton4";
            this.radioButton4.Size = new System.Drawing.Size(90, 33);
            this.radioButton4.TabIndex = 1;
            this.radioButton4.Text = "Semi";
            this.radioButton4.UseVisualStyleBackColor = true;
            // 
            // radioButton3
            // 
            this.radioButton3.AutoSize = true;
            this.radioButton3.Checked = true;
            this.radioButton3.Location = new System.Drawing.Point(32, 35);
            this.radioButton3.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.radioButton3.Name = "radioButton3";
            this.radioButton3.Size = new System.Drawing.Size(82, 33);
            this.radioButton3.TabIndex = 0;
            this.radioButton3.TabStop = true;
            this.radioButton3.Text = "Auto";
            this.radioButton3.UseVisualStyleBackColor = true;
            // 
            // tabPage7
            // 
            this.tabPage7.Controls.Add(this.Flip);
            this.tabPage7.Location = new System.Drawing.Point(4, 38);
            this.tabPage7.Margin = new System.Windows.Forms.Padding(1);
            this.tabPage7.Name = "tabPage7";
            this.tabPage7.Padding = new System.Windows.Forms.Padding(1);
            this.tabPage7.Size = new System.Drawing.Size(678, 327);
            this.tabPage7.TabIndex = 6;
            this.tabPage7.Text = "Flip";
            this.tabPage7.UseVisualStyleBackColor = true;
            // 
            // Flip
            // 
            this.Flip.Controls.Add(this.groupBox5);
            this.Flip.Location = new System.Drawing.Point(15, 20);
            this.Flip.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.Flip.Name = "Flip";
            this.Flip.Padding = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.Flip.Size = new System.Drawing.Size(634, 309);
            this.Flip.TabIndex = 10;
            this.Flip.TabStop = false;
            this.Flip.Text = "Flip";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.radioButton1);
            this.groupBox5.Controls.Add(this.rdb_y);
            this.groupBox5.Controls.Add(this.rdb_x);
            this.groupBox5.Location = new System.Drawing.Point(58, 60);
            this.groupBox5.Margin = new System.Windows.Forms.Padding(1);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Padding = new System.Windows.Forms.Padding(1);
            this.groupBox5.Size = new System.Drawing.Size(434, 134);
            this.groupBox5.TabIndex = 0;
            this.groupBox5.TabStop = false;
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Location = new System.Drawing.Point(151, 93);
            this.radioButton1.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(130, 33);
            this.radioButton1.TabIndex = 2;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "axis - x & y";
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // rdb_y
            // 
            this.rdb_y.AutoSize = true;
            this.rdb_y.Location = new System.Drawing.Point(254, 40);
            this.rdb_y.Margin = new System.Windows.Forms.Padding(1);
            this.rdb_y.Name = "rdb_y";
            this.rdb_y.Size = new System.Drawing.Size(95, 33);
            this.rdb_y.TabIndex = 1;
            this.rdb_y.Text = "axis-y";
            this.rdb_y.UseVisualStyleBackColor = true;
            // 
            // rdb_x
            // 
            this.rdb_x.AutoSize = true;
            this.rdb_x.Checked = true;
            this.rdb_x.Location = new System.Drawing.Point(74, 40);
            this.rdb_x.Margin = new System.Windows.Forms.Padding(1);
            this.rdb_x.Name = "rdb_x";
            this.rdb_x.Size = new System.Drawing.Size(95, 33);
            this.rdb_x.TabIndex = 0;
            this.rdb_x.TabStop = true;
            this.rdb_x.Text = "axis-x";
            this.rdb_x.UseVisualStyleBackColor = true;
            // 
            // tabPage8
            // 
            this.tabPage8.Controls.Add(this.Gamma);
            this.tabPage8.Location = new System.Drawing.Point(4, 38);
            this.tabPage8.Margin = new System.Windows.Forms.Padding(1);
            this.tabPage8.Name = "tabPage8";
            this.tabPage8.Padding = new System.Windows.Forms.Padding(1);
            this.tabPage8.Size = new System.Drawing.Size(678, 327);
            this.tabPage8.TabIndex = 7;
            this.tabPage8.Text = "Gramma";
            this.tabPage8.UseVisualStyleBackColor = true;
            // 
            // Gamma
            // 
            this.Gamma.Controls.Add(this.textBox9);
            this.Gamma.Controls.Add(this.label8);
            this.Gamma.Controls.Add(this.label7);
            this.Gamma.Controls.Add(this.hScrollBar1);
            this.Gamma.Location = new System.Drawing.Point(15, 20);
            this.Gamma.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.Gamma.Name = "Gamma";
            this.Gamma.Padding = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.Gamma.Size = new System.Drawing.Size(640, 301);
            this.Gamma.TabIndex = 10;
            this.Gamma.TabStop = false;
            this.Gamma.Text = "Gamma";
            // 
            // textBox9
            // 
            this.textBox9.Location = new System.Drawing.Point(266, 80);
            this.textBox9.Margin = new System.Windows.Forms.Padding(1);
            this.textBox9.Name = "textBox9";
            this.textBox9.Size = new System.Drawing.Size(99, 34);
            this.textBox9.TabIndex = 4;
            this.textBox9.Text = "0";
            this.textBox9.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(587, 119);
            this.label8.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(52, 29);
            this.label8.TabIndex = 3;
            this.label8.Text = "100";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(5, 118);
            this.label7.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(60, 29);
            this.label7.TabIndex = 2;
            this.label7.Text = "-100";
            // 
            // hScrollBar1
            // 
            this.hScrollBar1.Location = new System.Drawing.Point(80, 119);
            this.hScrollBar1.Name = "hScrollBar1";
            this.hScrollBar1.Size = new System.Drawing.Size(503, 35);
            this.hScrollBar1.TabIndex = 0;
            this.hScrollBar1.Value = 50;
            // 
            // tabPage9
            // 
            this.tabPage9.Location = new System.Drawing.Point(4, 38);
            this.tabPage9.Name = "tabPage9";
            this.tabPage9.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage9.Size = new System.Drawing.Size(678, 327);
            this.tabPage9.TabIndex = 8;
            this.tabPage9.Text = "tabPage9";
            this.tabPage9.UseVisualStyleBackColor = true;
            // 
            // btnStart
            // 
            this.btnStart.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStart.Location = new System.Drawing.Point(38, 86);
            this.btnStart.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(151, 48);
            this.btnStart.TabIndex = 11;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // btnStop
            // 
            this.btnStop.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStop.Location = new System.Drawing.Point(38, 170);
            this.btnStop.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(151, 48);
            this.btnStop.TabIndex = 12;
            this.btnStop.Text = "Stop";
            this.btnStop.UseVisualStyleBackColor = true;
            // 
            // vScrollBar1
            // 
            this.vScrollBar1.Location = new System.Drawing.Point(30, 40);
            this.vScrollBar1.Name = "vScrollBar1";
            this.vScrollBar1.Size = new System.Drawing.Size(32, 353);
            this.vScrollBar1.TabIndex = 17;
            // 
            // Grp_Zoom
            // 
            this.Grp_Zoom.Controls.Add(this.label6);
            this.Grp_Zoom.Controls.Add(this.vScrollBar1);
            this.Grp_Zoom.Controls.Add(this.label5);
            this.Grp_Zoom.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Grp_Zoom.Location = new System.Drawing.Point(1631, 20);
            this.Grp_Zoom.Margin = new System.Windows.Forms.Padding(1);
            this.Grp_Zoom.Name = "Grp_Zoom";
            this.Grp_Zoom.Padding = new System.Windows.Forms.Padding(1);
            this.Grp_Zoom.Size = new System.Drawing.Size(95, 421);
            this.Grp_Zoom.TabIndex = 18;
            this.Grp_Zoom.TabStop = false;
            this.Grp_Zoom.Text = "Zoom";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(28, 406);
            this.label6.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(68, 17);
            this.label6.TabIndex = 1;
            this.label6.Text = "Zoom out";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(28, 22);
            this.label5.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(59, 17);
            this.label5.TabIndex = 0;
            this.label5.Text = "Zoom in";
            // 
            // btnFocus
            // 
            this.btnFocus.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFocus.Location = new System.Drawing.Point(1754, 116);
            this.btnFocus.Margin = new System.Windows.Forms.Padding(1);
            this.btnFocus.Name = "btnFocus";
            this.btnFocus.Size = new System.Drawing.Size(95, 82);
            this.btnFocus.TabIndex = 19;
            this.btnFocus.Text = "Focus";
            this.btnFocus.UseVisualStyleBackColor = true;
            this.btnFocus.Click += new System.EventHandler(this.btnFocus_Click_1);
            // 
            // btnGamma
            // 
            this.btnGamma.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGamma.Location = new System.Drawing.Point(598, 118);
            this.btnGamma.Margin = new System.Windows.Forms.Padding(1);
            this.btnGamma.Name = "btnGamma";
            this.btnGamma.Size = new System.Drawing.Size(125, 58);
            this.btnGamma.TabIndex = 1;
            this.btnGamma.Text = "Gamma";
            this.btnGamma.UseVisualStyleBackColor = true;
            this.btnGamma.Click += new System.EventHandler(this.btnGamma_Click_1);
            // 
            // btnEdge
            // 
            this.btnEdge.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEdge.Location = new System.Drawing.Point(598, 38);
            this.btnEdge.Margin = new System.Windows.Forms.Padding(1);
            this.btnEdge.Name = "btnEdge";
            this.btnEdge.Size = new System.Drawing.Size(125, 56);
            this.btnEdge.TabIndex = 3;
            this.btnEdge.Text = "Edge";
            this.btnEdge.UseVisualStyleBackColor = true;
            this.btnEdge.Click += new System.EventHandler(this.btnEdge_Click);
            // 
            // btnPost
            // 
            this.btnPost.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPost.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPost.Location = new System.Drawing.Point(61, 38);
            this.btnPost.Margin = new System.Windows.Forms.Padding(1);
            this.btnPost.Name = "btnPost";
            this.btnPost.Size = new System.Drawing.Size(125, 56);
            this.btnPost.TabIndex = 20;
            this.btnPost.Text = "Post";
            this.btnPost.UseVisualStyleBackColor = true;
            this.btnPost.Click += new System.EventHandler(this.btnPost_Click_1);
            // 
            // btnNUC
            // 
            this.btnNUC.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNUC.Location = new System.Drawing.Point(246, 38);
            this.btnNUC.Margin = new System.Windows.Forms.Padding(1);
            this.btnNUC.Name = "btnNUC";
            this.btnNUC.Size = new System.Drawing.Size(125, 56);
            this.btnNUC.TabIndex = 21;
            this.btnNUC.Text = "NUC";
            this.btnNUC.UseVisualStyleBackColor = true;
            this.btnNUC.Click += new System.EventHandler(this.btnNUC_Click_1);
            // 
            // btnBpr
            // 
            this.btnBpr.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBpr.Location = new System.Drawing.Point(373, 38);
            this.btnBpr.Margin = new System.Windows.Forms.Padding(1);
            this.btnBpr.Name = "btnBpr";
            this.btnBpr.Size = new System.Drawing.Size(75, 56);
            this.btnBpr.TabIndex = 22;
            this.btnBpr.Text = "BPR";
            this.btnBpr.UseVisualStyleBackColor = true;
            this.btnBpr.Click += new System.EventHandler(this.btnBpr_Click_1);
            // 
            // btnBinning
            // 
            this.btnBinning.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBinning.Location = new System.Drawing.Point(63, 118);
            this.btnBinning.Margin = new System.Windows.Forms.Padding(1);
            this.btnBinning.Name = "btnBinning";
            this.btnBinning.Size = new System.Drawing.Size(125, 56);
            this.btnBinning.TabIndex = 23;
            this.btnBinning.Text = "Binning";
            this.btnBinning.UseVisualStyleBackColor = true;
            this.btnBinning.Click += new System.EventHandler(this.btnBinning_Click_1);
            // 
            // btnAgc
            // 
            this.btnAgc.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAgc.Location = new System.Drawing.Point(246, 118);
            this.btnAgc.Margin = new System.Windows.Forms.Padding(1);
            this.btnAgc.Name = "btnAgc";
            this.btnAgc.Size = new System.Drawing.Size(125, 58);
            this.btnAgc.TabIndex = 24;
            this.btnAgc.Text = "Agc";
            this.btnAgc.UseVisualStyleBackColor = true;
            this.btnAgc.Click += new System.EventHandler(this.btnAgc_Click_1);
            // 
            // btnFlip
            // 
            this.btnFlip.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFlip.Location = new System.Drawing.Point(422, 118);
            this.btnFlip.Margin = new System.Windows.Forms.Padding(1);
            this.btnFlip.Name = "btnFlip";
            this.btnFlip.Size = new System.Drawing.Size(125, 58);
            this.btnFlip.TabIndex = 25;
            this.btnFlip.Text = "Flip";
            this.btnFlip.UseVisualStyleBackColor = true;
            this.btnFlip.Click += new System.EventHandler(this.btnFlip_Click_1);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.BtnBprDynamic);
            this.groupBox1.Controls.Add(this.btnPost);
            this.groupBox1.Controls.Add(this.btnFlip);
            this.groupBox1.Controls.Add(this.btnAgc);
            this.groupBox1.Controls.Add(this.btnNUC);
            this.groupBox1.Controls.Add(this.btnGamma);
            this.groupBox1.Controls.Add(this.btnEdge);
            this.groupBox1.Controls.Add(this.btnBinning);
            this.groupBox1.Controls.Add(this.btnBpr);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(910, 624);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(1);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(1);
            this.groupBox1.Size = new System.Drawing.Size(778, 205);
            this.groupBox1.TabIndex = 26;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Process";
            // 
            // BtnBprDynamic
            // 
            this.BtnBprDynamic.Location = new System.Drawing.Point(459, 39);
            this.BtnBprDynamic.Name = "BtnBprDynamic";
            this.BtnBprDynamic.Size = new System.Drawing.Size(126, 75);
            this.BtnBprDynamic.TabIndex = 26;
            this.BtnBprDynamic.Text = "BRP Dynamic";
            this.BtnBprDynamic.UseVisualStyleBackColor = true;
            this.BtnBprDynamic.Click += new System.EventHandler(this.BtnBprDynamic_Click_1);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.rdPicture);
            this.groupBox2.Controls.Add(this.lblPath);
            this.groupBox2.Controls.Add(this.textBox7);
            this.groupBox2.Controls.Add(this.btnOpenCAM_VIDEO_PIC);
            this.groupBox2.Controls.Add(this.rdVideo);
            this.groupBox2.Controls.Add(this.rdCAMLink);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(910, 484);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(1);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(1);
            this.groupBox2.Size = new System.Drawing.Size(778, 124);
            this.groupBox2.TabIndex = 27;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Input";
            // 
            // rdPicture
            // 
            this.rdPicture.AutoSize = true;
            this.rdPicture.Location = new System.Drawing.Point(15, 88);
            this.rdPicture.Margin = new System.Windows.Forms.Padding(1);
            this.rdPicture.Name = "rdPicture";
            this.rdPicture.Size = new System.Drawing.Size(109, 33);
            this.rdPicture.TabIndex = 6;
            this.rdPicture.TabStop = true;
            this.rdPicture.Text = "Picture";
            this.rdPicture.UseVisualStyleBackColor = true;
            this.rdPicture.CheckedChanged += new System.EventHandler(this.rdPicture_CheckedChanged);
            // 
            // lblPath
            // 
            this.lblPath.AutoSize = true;
            this.lblPath.Location = new System.Drawing.Point(121, 90);
            this.lblPath.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.lblPath.Name = "lblPath";
            this.lblPath.Size = new System.Drawing.Size(67, 29);
            this.lblPath.TabIndex = 5;
            this.lblPath.Text = "Path:";
            // 
            // textBox7
            // 
            this.textBox7.Location = new System.Drawing.Point(178, 88);
            this.textBox7.Margin = new System.Windows.Forms.Padding(1);
            this.textBox7.Name = "textBox7";
            this.textBox7.Size = new System.Drawing.Size(529, 34);
            this.textBox7.TabIndex = 4;
            // 
            // btnOpenCAM_VIDEO_PIC
            // 
            this.btnOpenCAM_VIDEO_PIC.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOpenCAM_VIDEO_PIC.Location = new System.Drawing.Point(189, 25);
            this.btnOpenCAM_VIDEO_PIC.Margin = new System.Windows.Forms.Padding(1);
            this.btnOpenCAM_VIDEO_PIC.Name = "btnOpenCAM_VIDEO_PIC";
            this.btnOpenCAM_VIDEO_PIC.Size = new System.Drawing.Size(189, 34);
            this.btnOpenCAM_VIDEO_PIC.TabIndex = 3;
            this.btnOpenCAM_VIDEO_PIC.Text = "Open";
            this.btnOpenCAM_VIDEO_PIC.UseVisualStyleBackColor = true;
            this.btnOpenCAM_VIDEO_PIC.Click += new System.EventHandler(this.btnOpenCAM_VIDEO_PIC_Click);
            // 
            // rdVideo
            // 
            this.rdVideo.AutoSize = true;
            this.rdVideo.Location = new System.Drawing.Point(15, 56);
            this.rdVideo.Margin = new System.Windows.Forms.Padding(1);
            this.rdVideo.Name = "rdVideo";
            this.rdVideo.Size = new System.Drawing.Size(97, 33);
            this.rdVideo.TabIndex = 2;
            this.rdVideo.Text = "Video";
            this.rdVideo.UseVisualStyleBackColor = true;
            this.rdVideo.CheckedChanged += new System.EventHandler(this.rdVideo_CheckedChanged);
            // 
            // rdCAMLink
            // 
            this.rdCAMLink.AutoSize = true;
            this.rdCAMLink.Checked = true;
            this.rdCAMLink.Location = new System.Drawing.Point(15, 25);
            this.rdCAMLink.Margin = new System.Windows.Forms.Padding(1);
            this.rdCAMLink.Name = "rdCAMLink";
            this.rdCAMLink.Size = new System.Drawing.Size(162, 33);
            this.rdCAMLink.TabIndex = 1;
            this.rdCAMLink.TabStop = true;
            this.rdCAMLink.Text = "Camera link";
            this.rdCAMLink.UseVisualStyleBackColor = true;
            this.rdCAMLink.CheckedChanged += new System.EventHandler(this.rdCAMLink_CheckedChanged);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btnExit);
            this.groupBox3.Controls.Add(this.btnStart);
            this.groupBox3.Controls.Add(this.btnStop);
            this.groupBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.Location = new System.Drawing.Point(1718, 484);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(1);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(1);
            this.groupBox3.Size = new System.Drawing.Size(220, 343);
            this.groupBox3.TabIndex = 28;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Control";
            // 
            // btnExit
            // 
            this.btnExit.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExit.Location = new System.Drawing.Point(38, 253);
            this.btnExit.Margin = new System.Windows.Forms.Padding(1);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(151, 50);
            this.btnExit.TabIndex = 13;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            // 
            // grpSetting
            // 
            this.grpSetting.Controls.Add(this.btnSendToFPGA);
            this.grpSetting.Controls.Add(this.btnsave);
            this.grpSetting.Controls.Add(this.btnUpload);
            this.grpSetting.Controls.Add(this.btnSetting);
            this.grpSetting.Controls.Add(this.Zoom);
            this.grpSetting.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpSetting.Location = new System.Drawing.Point(24, 451);
            this.grpSetting.Margin = new System.Windows.Forms.Padding(1);
            this.grpSetting.Name = "grpSetting";
            this.grpSetting.Padding = new System.Windows.Forms.Padding(1);
            this.grpSetting.Size = new System.Drawing.Size(858, 362);
            this.grpSetting.TabIndex = 29;
            this.grpSetting.TabStop = false;
            this.grpSetting.Text = "Setting";
            this.grpSetting.Enter += new System.EventHandler(this.grpSetting_Enter);
            // 
            // btnSendToFPGA
            // 
            this.btnSendToFPGA.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSendToFPGA.Location = new System.Drawing.Point(705, 203);
            this.btnSendToFPGA.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.btnSendToFPGA.Name = "btnSendToFPGA";
            this.btnSendToFPGA.Size = new System.Drawing.Size(132, 38);
            this.btnSendToFPGA.TabIndex = 14;
            this.btnSendToFPGA.Text = "Send to FPGA";
            this.btnSendToFPGA.UseVisualStyleBackColor = true;
            // 
            // btnsave
            // 
            this.btnsave.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnsave.Location = new System.Drawing.Point(705, 158);
            this.btnsave.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.btnsave.Name = "btnsave";
            this.btnsave.Size = new System.Drawing.Size(132, 31);
            this.btnsave.TabIndex = 13;
            this.btnsave.Text = "Save";
            this.btnsave.UseVisualStyleBackColor = true;
            // 
            // btnUpload
            // 
            this.btnUpload.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpload.Location = new System.Drawing.Point(705, 109);
            this.btnUpload.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.btnUpload.Name = "btnUpload";
            this.btnUpload.Size = new System.Drawing.Size(132, 34);
            this.btnUpload.TabIndex = 12;
            this.btnUpload.Text = "Upload";
            this.btnUpload.UseVisualStyleBackColor = true;
            this.btnUpload.Click += new System.EventHandler(this.btnUpload_Click);
            // 
            // btnSetting
            // 
            this.btnSetting.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSetting.Location = new System.Drawing.Point(705, 56);
            this.btnSetting.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.btnSetting.Name = "btnSetting";
            this.btnSetting.Size = new System.Drawing.Size(132, 34);
            this.btnSetting.TabIndex = 11;
            this.btnSetting.Text = "Setting";
            this.btnSetting.UseVisualStyleBackColor = true;
            this.btnSetting.Click += new System.EventHandler(this.btnSetting_Click);
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.pvDisplayControl);
            this.groupBox7.Location = new System.Drawing.Point(19, 18);
            this.groupBox7.Margin = new System.Windows.Forms.Padding(1);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Padding = new System.Windows.Forms.Padding(1);
            this.groupBox7.Size = new System.Drawing.Size(518, 422);
            this.groupBox7.TabIndex = 30;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "groupBox7";
            // 
            // pvDisplayControl
            // 
            this.pvDisplayControl.Location = new System.Drawing.Point(4, 28);
            this.pvDisplayControl.Name = "pvDisplayControl";
            this.pvDisplayControl.Size = new System.Drawing.Size(499, 378);
            this.pvDisplayControl.TabIndex = 15;
            this.pvDisplayControl.TabStop = false;
            this.pvDisplayControl.Visible = false;
            this.pvDisplayControl.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pvDisplayControl_Click);
            // 
            // groupBox8
            // 
            this.groupBox8.Controls.Add(this.pvDisplayControl2);
            this.groupBox8.Location = new System.Drawing.Point(555, 18);
            this.groupBox8.Margin = new System.Windows.Forms.Padding(1);
            this.groupBox8.Name = "groupBox8";
            this.groupBox8.Padding = new System.Windows.Forms.Padding(1);
            this.groupBox8.Size = new System.Drawing.Size(518, 422);
            this.groupBox8.TabIndex = 31;
            this.groupBox8.TabStop = false;
            this.groupBox8.Text = "groupBox8";
            // 
            // pvDisplayControl2
            // 
            this.pvDisplayControl2.Location = new System.Drawing.Point(10, 28);
            this.pvDisplayControl2.Name = "pvDisplayControl2";
            this.pvDisplayControl2.Size = new System.Drawing.Size(499, 378);
            this.pvDisplayControl2.TabIndex = 16;
            this.pvDisplayControl2.TabStop = false;
            this.pvDisplayControl2.Visible = false;
            // 
            // groupBox9
            // 
            this.groupBox9.Controls.Add(this.textBoxAutoFocus);
            this.groupBox9.Controls.Add(this.textBoxFocus);
            this.groupBox9.Controls.Add(this.pvDisplayControlFocus);
            this.groupBox9.Controls.Add(this.pvDisplayControl3);
            this.groupBox9.Location = new System.Drawing.Point(1101, 18);
            this.groupBox9.Margin = new System.Windows.Forms.Padding(1);
            this.groupBox9.Name = "groupBox9";
            this.groupBox9.Padding = new System.Windows.Forms.Padding(1);
            this.groupBox9.Size = new System.Drawing.Size(516, 422);
            this.groupBox9.TabIndex = 32;
            this.groupBox9.TabStop = false;
            this.groupBox9.Text = "groupBox9";
            // 
            // pvDisplayControlFocus
            // 
            this.pvDisplayControlFocus.Location = new System.Drawing.Point(20, 28);
            this.pvDisplayControlFocus.Name = "pvDisplayControlFocus";
            this.pvDisplayControlFocus.Size = new System.Drawing.Size(94, 86);
            this.pvDisplayControlFocus.TabIndex = 33;
            this.pvDisplayControlFocus.TabStop = false;
            // 
            // pvDisplayControl3
            // 
            this.pvDisplayControl3.Location = new System.Drawing.Point(20, 120);
            this.pvDisplayControl3.Name = "pvDisplayControl3";
            this.pvDisplayControl3.Size = new System.Drawing.Size(481, 247);
            this.pvDisplayControl3.TabIndex = 17;
            this.pvDisplayControl3.TabStop = false;
            this.pvDisplayControl3.Visible = false;
            // 
            // textBoxFocus
            // 
            this.textBoxFocus.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.textBoxFocus.Location = new System.Drawing.Point(118, 42);
            this.textBoxFocus.Margin = new System.Windows.Forms.Padding(1);
            this.textBoxFocus.Name = "textBoxFocus";
            this.textBoxFocus.Size = new System.Drawing.Size(383, 36);
            this.textBoxFocus.TabIndex = 34;
            // 
            // textBoxAutoFocus
            // 
            this.textBoxAutoFocus.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.textBoxAutoFocus.Location = new System.Drawing.Point(20, 371);
            this.textBoxAutoFocus.Margin = new System.Windows.Forms.Padding(1);
            this.textBoxAutoFocus.Name = "textBoxAutoFocus";
            this.textBoxAutoFocus.Size = new System.Drawing.Size(481, 36);
            this.textBoxAutoFocus.TabIndex = 35;
            // 
            // IR_Camera
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(1924, 893);
            this.Controls.Add(this.groupBox9);
            this.Controls.Add(this.groupBox8);
            this.Controls.Add(this.groupBox7);
            this.Controls.Add(this.grpSetting);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnFocus);
            this.Controls.Add(this.Grp_Zoom);
            this.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(968, 563);
            this.Name = "IR_Camera";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "IR_Camera";
            this.Load += new System.EventHandler(this.IR_Camera_Load);
            this.Zoom.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.Post.ResumeLayout(false);
            this.Post.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.NUC.ResumeLayout(false);
            this.NUC.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.BPR.ResumeLayout(false);
            this.BPR.PerformLayout();
            this.tabPage4.ResumeLayout(false);
            this.EDGE.ResumeLayout(false);
            this.EDGE.PerformLayout();
            this.tabPage5.ResumeLayout(false);
            this.tabPage6.ResumeLayout(false);
            this.AGC.ResumeLayout(false);
            this.AGC.PerformLayout();
            this.tabPage7.ResumeLayout(false);
            this.Flip.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.tabPage8.ResumeLayout(false);
            this.Gamma.ResumeLayout(false);
            this.Gamma.PerformLayout();
            this.Grp_Zoom.ResumeLayout(false);
            this.Grp_Zoom.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.grpSetting.ResumeLayout(false);
            this.groupBox7.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pvDisplayControl)).EndInit();
            this.groupBox8.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pvDisplayControl2)).EndInit();
            this.groupBox9.ResumeLayout(false);
            this.groupBox9.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pvDisplayControlFocus)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pvDisplayControl3)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.GroupBox Binning;
        private System.Windows.Forms.TabControl Zoom;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Button btnStop;
        private PvGUIDotNet.PvDisplayControl pvDisplayControl1;
        private System.Windows.Forms.VScrollBar vScrollBar1;
        private System.Windows.Forms.GroupBox Grp_Zoom;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnEdge;
        private System.Windows.Forms.Button btnGamma;
        private System.Windows.Forms.Button btnFocus;
        private System.Windows.Forms.TabPage tabPage5;
        private System.Windows.Forms.TabPage tabPage6;
        private System.Windows.Forms.TabPage tabPage7;
        private System.Windows.Forms.TabPage tabPage8;
        private System.Windows.Forms.Button btnPost;
        private System.Windows.Forms.Button btnNUC;
        private System.Windows.Forms.Button btnBpr;
        private System.Windows.Forms.Button btnBinning;
        private System.Windows.Forms.Button btnAgc;
        private System.Windows.Forms.Button btnFlip;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label lblPath;
        private System.Windows.Forms.TextBox textBox7;
        private System.Windows.Forms.Button btnOpenCAM_VIDEO_PIC;
        private System.Windows.Forms.RadioButton rdVideo;
        private System.Windows.Forms.RadioButton rdCAMLink;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.GroupBox Post;
        private System.Windows.Forms.TextBox txtPost_BuocNhay;
        private System.Windows.Forms.Label lblNextFrame;
        private System.Windows.Forms.Label lbl_NumberOfFrame;
        private System.Windows.Forms.TextBox txtPost_Frames;
        private System.Windows.Forms.GroupBox grpSetting;
        private System.Windows.Forms.GroupBox BPR;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.GroupBox EDGE;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.HScrollBar hScrollBar2;
        private System.Windows.Forms.GroupBox NUC;
        private System.Windows.Forms.ComboBox comboBoxTempNuc;
        private System.Windows.Forms.RadioButton rdbNUC2;
        private System.Windows.Forms.RadioButton rdbNUC1;
        private System.Windows.Forms.GroupBox AGC;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox6;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.RadioButton radioButton5;
        private System.Windows.Forms.RadioButton radioButton4;
        private System.Windows.Forms.RadioButton radioButton3;
        private System.Windows.Forms.TextBox textBox8;
        private System.Windows.Forms.GroupBox Flip;
        private System.Windows.Forms.GroupBox Gamma;
        private System.Windows.Forms.TextBox textBox9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.HScrollBar hScrollBar1;
        private System.Windows.Forms.TextBox txtNUC1_Nhiet;
        private System.Windows.Forms.TextBox txtNUC2_Nhiet;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Button btnNUC2_Upload;
        private System.Windows.Forms.Button btnNUC1Upload;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox txtNUC2_Path;
        private System.Windows.Forms.TextBox txtNuc1_Path;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Button btnNOISE_UPLOAD;
        private System.Windows.Forms.Button btn_OFFSET_UPLOAD;
        private System.Windows.Forms.TextBox txtNOISE_Duongdan;
        private System.Windows.Forms.TextBox txtNOISE_Nhiet;
        private System.Windows.Forms.TextBox txtOFFSET_Duongdan;
        private System.Windows.Forms.TextBox txtOFFSET_Nhiet;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.RadioButton rdbNoise;
        private System.Windows.Forms.RadioButton rdbOffset;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.RadioButton rdb_y;
        private System.Windows.Forms.RadioButton rdb_x;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.Button btnSendToFPGA;
        private System.Windows.Forms.Button btnsave;
        private System.Windows.Forms.Button btnUpload;
        private System.Windows.Forms.Button btnSetting;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.RadioButton rdPicture;
        private PvGUIDotNet.PvDisplayControl displayControl0;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.GroupBox groupBox8;
        private System.Windows.Forms.GroupBox groupBox9;
        private TabPage tabPage9;
        private PictureBox pvDisplayControl;
        private PictureBox pvDisplayControl2;
        private PictureBox pvDisplayControl3;
        private Button BtnBprDynamic;
        private PictureBox pvDisplayControlFocus;
        private TextBox textBoxAutoFocus;
        private TextBox textBoxFocus;
    }
}