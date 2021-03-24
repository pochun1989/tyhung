namespace TEST
{
    partial class WHScanCode
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
            this.VspContainer = new AForge.Controls.VideoSourcePlayer();
            this.PbxScanner = new AForge.Controls.PictureBox();
            this.BtnScanner = new System.Windows.Forms.Button();
            this.BtnStart = new System.Windows.Forms.Button();
            this.BtnStop = new System.Windows.Forms.Button();
            this.TmScanner = new System.Windows.Forms.Timer(this.components);
            this.TxtScannerCode = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.PbxScanner)).BeginInit();
            this.SuspendLayout();
            // 
            // VspContainer
            // 
            this.VspContainer.Location = new System.Drawing.Point(12, 12);
            this.VspContainer.Name = "VspContainer";
            this.VspContainer.Size = new System.Drawing.Size(606, 345);
            this.VspContainer.TabIndex = 0;
            this.VspContainer.Text = "videoSourcePlayer1";
            this.VspContainer.VideoSource = null;
            // 
            // PbxScanner
            // 
            this.PbxScanner.Image = null;
            this.PbxScanner.Location = new System.Drawing.Point(624, 12);
            this.PbxScanner.Name = "PbxScanner";
            this.PbxScanner.Size = new System.Drawing.Size(742, 520);
            this.PbxScanner.TabIndex = 1;
            this.PbxScanner.TabStop = false;
            // 
            // BtnScanner
            // 
            this.BtnScanner.Location = new System.Drawing.Point(127, 465);
            this.BtnScanner.Name = "BtnScanner";
            this.BtnScanner.Size = new System.Drawing.Size(97, 42);
            this.BtnScanner.TabIndex = 2;
            this.BtnScanner.Text = "SCANNER";
            this.BtnScanner.UseVisualStyleBackColor = true;
            this.BtnScanner.Click += new System.EventHandler(this.BtnScanner_Click);
            // 
            // BtnStart
            // 
            this.BtnStart.Location = new System.Drawing.Point(85, 378);
            this.BtnStart.Name = "BtnStart";
            this.BtnStart.Size = new System.Drawing.Size(113, 62);
            this.BtnStart.TabIndex = 3;
            this.BtnStart.Text = "start";
            this.BtnStart.UseVisualStyleBackColor = true;
            this.BtnStart.Click += new System.EventHandler(this.BtnStart_Click);
            // 
            // BtnStop
            // 
            this.BtnStop.Location = new System.Drawing.Point(383, 378);
            this.BtnStop.Name = "BtnStop";
            this.BtnStop.Size = new System.Drawing.Size(112, 62);
            this.BtnStop.TabIndex = 4;
            this.BtnStop.Text = "stop";
            this.BtnStop.UseVisualStyleBackColor = true;
            this.BtnStop.Click += new System.EventHandler(this.BtnStop_Click);
            // 
            // TmScanner
            // 
            this.TmScanner.Tick += new System.EventHandler(this.TmScanner_Tick);
            // 
            // TxtScannerCode
            // 
            this.TxtScannerCode.Location = new System.Drawing.Point(257, 474);
            this.TxtScannerCode.Name = "TxtScannerCode";
            this.TxtScannerCode.Size = new System.Drawing.Size(175, 29);
            this.TxtScannerCode.TabIndex = 5;
            // 
            // WHScanCode
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1378, 544);
            this.Controls.Add(this.TxtScannerCode);
            this.Controls.Add(this.BtnStop);
            this.Controls.Add(this.BtnStart);
            this.Controls.Add(this.BtnScanner);
            this.Controls.Add(this.PbxScanner);
            this.Controls.Add(this.VspContainer);
            this.Name = "WHScanCode";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "WHScanCode";
            ((System.ComponentModel.ISupportInitialize)(this.PbxScanner)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private AForge.Controls.VideoSourcePlayer VspContainer;
        private AForge.Controls.PictureBox PbxScanner;
        private System.Windows.Forms.Button BtnScanner;
        private System.Windows.Forms.Button BtnStart;
        private System.Windows.Forms.Button BtnStop;
        private System.Windows.Forms.Timer TmScanner;
        private System.Windows.Forms.TextBox TxtScannerCode;
    }
}