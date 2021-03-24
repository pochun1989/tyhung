namespace TEST
{
    partial class ChangeScqty
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
            this.tbScqty = new System.Windows.Forms.TextBox();
            this.lbScqty = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.tbPass = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // tbScqty
            // 
            this.tbScqty.Font = new System.Drawing.Font("微軟正黑體", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.tbScqty.Location = new System.Drawing.Point(381, 110);
            this.tbScqty.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tbScqty.Name = "tbScqty";
            this.tbScqty.Size = new System.Drawing.Size(165, 50);
            this.tbScqty.TabIndex = 19;
            // 
            // lbScqty
            // 
            this.lbScqty.AutoSize = true;
            this.lbScqty.Font = new System.Drawing.Font("微軟正黑體", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lbScqty.Location = new System.Drawing.Point(234, 113);
            this.lbScqty.Name = "lbScqty";
            this.lbScqty.Size = new System.Drawing.Size(100, 40);
            this.lbScqty.TabIndex = 18;
            this.lbScqty.Text = "Scqty";
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.button1.Location = new System.Drawing.Point(331, 315);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(122, 65);
            this.button1.TabIndex = 20;
            this.button1.Text = "Save";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // tbPass
            // 
            this.tbPass.Font = new System.Drawing.Font("微軟正黑體", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.tbPass.Location = new System.Drawing.Point(381, 210);
            this.tbPass.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tbPass.Name = "tbPass";
            this.tbPass.PasswordChar = '*';
            this.tbPass.Size = new System.Drawing.Size(165, 50);
            this.tbPass.TabIndex = 22;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微軟正黑體", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label1.Location = new System.Drawing.Point(173, 213);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(161, 40);
            this.label1.TabIndex = 21;
            this.label1.Text = "Password";
            // 
            // ChangeScqty
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tbPass);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.tbScqty);
            this.Controls.Add(this.lbScqty);
            this.Name = "ChangeScqty";
            this.Text = "ChangeScqty";
            this.Load += new System.EventHandler(this.ChangeScqty_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbScqty;
        private System.Windows.Forms.Label lbScqty;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox tbPass;
        private System.Windows.Forms.Label label1;
    }
}