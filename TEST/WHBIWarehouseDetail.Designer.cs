namespace TEST
{
    partial class WHBIWarehouseDetail
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
            this.cbWarehouseClass = new System.Windows.Forms.ComboBox();
            this.lbWarehouseClass = new System.Windows.Forms.Label();
            this.tbWarehouseName = new System.Windows.Forms.TextBox();
            this.lbWarehouseName = new System.Windows.Forms.Label();
            this.lbWarehouseID = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.tbWHID = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // cbWarehouseClass
            // 
            this.cbWarehouseClass.AutoCompleteCustomSource.AddRange(new string[] {
            "原物料倉",
            "成品倉",
            "BC品倉",
            "總務倉"});
            this.cbWarehouseClass.Font = new System.Drawing.Font("微軟正黑體", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.cbWarehouseClass.FormattingEnabled = true;
            this.cbWarehouseClass.Items.AddRange(new object[] {
            "原物料倉",
            "成品倉",
            "BC品倉",
            "總務倉"});
            this.cbWarehouseClass.Location = new System.Drawing.Point(433, 225);
            this.cbWarehouseClass.Name = "cbWarehouseClass";
            this.cbWarehouseClass.Size = new System.Drawing.Size(255, 48);
            this.cbWarehouseClass.TabIndex = 9;
            // 
            // lbWarehouseClass
            // 
            this.lbWarehouseClass.AutoSize = true;
            this.lbWarehouseClass.Font = new System.Drawing.Font("微軟正黑體", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lbWarehouseClass.Location = new System.Drawing.Point(94, 229);
            this.lbWarehouseClass.Name = "lbWarehouseClass";
            this.lbWarehouseClass.Size = new System.Drawing.Size(272, 40);
            this.lbWarehouseClass.TabIndex = 8;
            this.lbWarehouseClass.Text = "WarehouseClass:";
            // 
            // tbWarehouseName
            // 
            this.tbWarehouseName.Font = new System.Drawing.Font("微軟正黑體", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.tbWarehouseName.Location = new System.Drawing.Point(433, 154);
            this.tbWarehouseName.Name = "tbWarehouseName";
            this.tbWarehouseName.Size = new System.Drawing.Size(255, 50);
            this.tbWarehouseName.TabIndex = 14;
            // 
            // lbWarehouseName
            // 
            this.lbWarehouseName.AutoSize = true;
            this.lbWarehouseName.Font = new System.Drawing.Font("微軟正黑體", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lbWarehouseName.Location = new System.Drawing.Point(94, 159);
            this.lbWarehouseName.Name = "lbWarehouseName";
            this.lbWarehouseName.Size = new System.Drawing.Size(287, 40);
            this.lbWarehouseName.TabIndex = 13;
            this.lbWarehouseName.Text = "WarehouseName:";
            // 
            // lbWarehouseID
            // 
            this.lbWarehouseID.AutoSize = true;
            this.lbWarehouseID.Font = new System.Drawing.Font("微軟正黑體", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lbWarehouseID.Location = new System.Drawing.Point(94, 86);
            this.lbWarehouseID.Name = "lbWarehouseID";
            this.lbWarehouseID.Size = new System.Drawing.Size(228, 40);
            this.lbWarehouseID.TabIndex = 12;
            this.lbWarehouseID.Text = "WarehouseID:";
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.Gray;
            this.btnSave.FlatAppearance.BorderSize = 0;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("微軟正黑體", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnSave.Location = new System.Drawing.Point(134, 325);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(175, 77);
            this.btnSave.TabIndex = 16;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.BtnSave_Click_1);
            // 
            // btnExit
            // 
            this.btnExit.BackColor = System.Drawing.Color.Gray;
            this.btnExit.FlatAppearance.BorderSize = 0;
            this.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExit.Font = new System.Drawing.Font("微軟正黑體", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnExit.Location = new System.Drawing.Point(459, 325);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(175, 77);
            this.btnExit.TabIndex = 17;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = false;
            this.btnExit.Click += new System.EventHandler(this.BtnExit_Click);
            // 
            // tbWHID
            // 
            this.tbWHID.Font = new System.Drawing.Font("微軟正黑體", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.tbWHID.Location = new System.Drawing.Point(433, 83);
            this.tbWHID.Name = "tbWHID";
            this.tbWHID.Size = new System.Drawing.Size(255, 50);
            this.tbWHID.TabIndex = 23;
            // 
            // WHBIWarehouseDetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gainsboro;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tbWHID);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.tbWarehouseName);
            this.Controls.Add(this.lbWarehouseName);
            this.Controls.Add(this.lbWarehouseID);
            this.Controls.Add(this.cbWarehouseClass);
            this.Controls.Add(this.lbWarehouseClass);
            this.Name = "WHBIWarehouseDetail";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "WHBasicInformationWarehouseDetail";
            this.Load += new System.EventHandler(this.WHBasicInformationWarehouseDetail_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lbWarehouseClass;
        private System.Windows.Forms.Label lbWarehouseName;
        private System.Windows.Forms.Label lbWarehouseID;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnExit;
        internal System.Windows.Forms.ComboBox cbWarehouseClass;
        internal System.Windows.Forms.TextBox tbWarehouseName;
        internal System.Windows.Forms.TextBox tbWHID;
    }
}