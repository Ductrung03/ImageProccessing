namespace ImageProcessing
{
    partial class MainForm
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
            this.components = new System.ComponentModel.Container();
            this.oneLabel = new System.Windows.Forms.Label();
            this.twoLabel = new System.Windows.Forms.Label();
            this.threeLabel = new System.Windows.Forms.Label();
            this.fourLabel = new System.Windows.Forms.Label();
            this.fiveLabel = new System.Windows.Forms.Label();
            this.sixLabel = new System.Windows.Forms.Label();
            this.stopButton = new System.Windows.Forms.Button();
            this.sequenceTimer = new System.Windows.Forms.Timer(this.components);
            this.refreshTimer = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // oneLabel
            // 
            this.oneLabel.AutoSize = true;
            this.oneLabel.Enabled = false;
            this.oneLabel.Location = new System.Drawing.Point(16, 11);
            this.oneLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.oneLabel.Name = "oneLabel";
            this.oneLabel.Size = new System.Drawing.Size(95, 17);
            this.oneLabel.TabIndex = 0;
            this.oneLabel.Text = "1. Connecting";
            // 
            // twoLabel
            // 
            this.twoLabel.AutoSize = true;
            this.twoLabel.Enabled = false;
            this.twoLabel.Location = new System.Drawing.Point(16, 36);
            this.twoLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.twoLabel.Name = "twoLabel";
            this.twoLabel.Size = new System.Drawing.Size(141, 17);
            this.twoLabel.TabIndex = 1;
            this.twoLabel.Text = "2. Configuring device";
            // 
            // threeLabel
            // 
            this.threeLabel.AutoSize = true;
            this.threeLabel.Enabled = false;
            this.threeLabel.Location = new System.Drawing.Point(16, 60);
            this.threeLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.threeLabel.Name = "threeLabel";
            this.threeLabel.Size = new System.Drawing.Size(120, 17);
            this.threeLabel.TabIndex = 2;
            this.threeLabel.Text = "3. Starting stream";
            this.threeLabel.Click += new System.EventHandler(this.threeLabel_Click);
            // 
            // fourLabel
            // 
            this.fourLabel.AutoSize = true;
            this.fourLabel.Enabled = false;
            this.fourLabel.Location = new System.Drawing.Point(16, 85);
            this.fourLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.fourLabel.Name = "fourLabel";
            this.fourLabel.Size = new System.Drawing.Size(88, 17);
            this.fourLabel.TabIndex = 3;
            this.fourLabel.Text = "4. Streaming";
            // 
            // fiveLabel
            // 
            this.fiveLabel.AutoSize = true;
            this.fiveLabel.Enabled = false;
            this.fiveLabel.Location = new System.Drawing.Point(16, 139);
            this.fiveLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.fiveLabel.Name = "fiveLabel";
            this.fiveLabel.Size = new System.Drawing.Size(127, 17);
            this.fiveLabel.TabIndex = 4;
            this.fiveLabel.Text = "5. Stopping stream";
            // 
            // sixLabel
            // 
            this.sixLabel.AutoSize = true;
            this.sixLabel.Enabled = false;
            this.sixLabel.Location = new System.Drawing.Point(16, 164);
            this.sixLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.sixLabel.Name = "sixLabel";
            this.sixLabel.Size = new System.Drawing.Size(113, 17);
            this.sixLabel.TabIndex = 5;
            this.sixLabel.Text = "6. Disconnecting";
            // 
            // stopButton
            // 
            this.stopButton.Enabled = false;
            this.stopButton.Location = new System.Drawing.Point(35, 105);
            this.stopButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.stopButton.Name = "stopButton";
            this.stopButton.Size = new System.Drawing.Size(100, 28);
            this.stopButton.TabIndex = 8;
            this.stopButton.Text = "Stop";
            this.stopButton.UseVisualStyleBackColor = true;
            this.stopButton.Click += new System.EventHandler(this.stopButton_Click);
            // 
            // sequenceTimer
            // 
            this.sequenceTimer.Interval = 1000;
            this.sequenceTimer.Tick += new System.EventHandler(this.sequence_timer_Tick);
            // 
            // refreshTimer
            // 
            this.refreshTimer.Interval = 1000;
            this.refreshTimer.Tick += new System.EventHandler(this.refresh_timer_Tick);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1220, 604);
            this.Controls.Add(this.stopButton);
            this.Controls.Add(this.sixLabel);
            this.Controls.Add(this.fiveLabel);
            this.Controls.Add(this.fourLabel);
            this.Controls.Add(this.threeLabel);
            this.Controls.Add(this.twoLabel);
            this.Controls.Add(this.oneLabel);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "MainForm";
            this.Text = "Thiết lập kết nối Grapber";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label oneLabel;
        private System.Windows.Forms.Label twoLabel;
        private System.Windows.Forms.Label threeLabel;
        private System.Windows.Forms.Label fourLabel;
        private System.Windows.Forms.Label fiveLabel;
        private System.Windows.Forms.Label sixLabel;
        private PvGUIDotNet.PvDisplayControl displayControl;
        private System.Windows.Forms.Button stopButton;
        private System.Windows.Forms.Timer sequenceTimer;
        private System.Windows.Forms.Timer refreshTimer;
        internal PvGUIDotNet.PvGenBrowserControl browser;
    }
}

