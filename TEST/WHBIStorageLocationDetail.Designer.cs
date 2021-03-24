namespace TEST
{
    partial class WHBIStorageLocationDetail
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
            this.btnExit = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.lbWarehouseName = new System.Windows.Forms.Label();
            this.lbWHName = new System.Windows.Forms.Label();
            this.tbShelfLevel = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tbShelfGrid = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tbMemo = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tbShelfNo = new System.Windows.Forms.TextBox();
            this.cbWhname = new System.Windows.Forms.ComboBox();
            this.cbWarehouseID = new System.Windows.Forms.ComboBox();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.SuspendLayout();
            // 
            // btnExit
            // 
            this.btnExit.BackColor = System.Drawing.Color.DarkGray;
            this.btnExit.FlatAppearance.BorderSize = 0;
            this.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExit.Font = new System.Drawing.Font("微軟正黑體", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnExit.Location = new System.Drawing.Point(512, 349);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(175, 77);
            this.btnExit.TabIndex = 29;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = false;
            this.btnExit.Click += new System.EventHandler(this.BtnExit_Click);
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.DarkGray;
            this.btnSave.FlatAppearance.BorderSize = 0;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("微軟正黑體", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnSave.Location = new System.Drawing.Point(161, 349);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(175, 77);
            this.btnSave.TabIndex = 28;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.BtnSave_Click);
            // 
            // lbWarehouseName
            // 
            this.lbWarehouseName.AutoSize = true;
            this.lbWarehouseName.Font = new System.Drawing.Font("微軟正黑體", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lbWarehouseName.Location = new System.Drawing.Point(196, 103);
            this.lbWarehouseName.Name = "lbWarehouseName";
            this.lbWarehouseName.Size = new System.Drawing.Size(127, 35);
            this.lbWarehouseName.TabIndex = 26;
            this.lbWarehouseName.Text = "ShelfNo:";
            // 
            // lbWHName
            // 
            this.lbWHName.AutoSize = true;
            this.lbWHName.Font = new System.Drawing.Font("微軟正黑體", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lbWHName.Location = new System.Drawing.Point(134, 41);
            this.lbWHName.Name = "lbWHName";
            this.lbWHName.Size = new System.Drawing.Size(200, 35);
            this.lbWHName.TabIndex = 25;
            this.lbWHName.Text = "WarehouseID:";
            // 
            // tbShelfLevel
            // 
            this.tbShelfLevel.Font = new System.Drawing.Font("微軟正黑體", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.tbShelfLevel.Location = new System.Drawing.Point(407, 158);
            this.tbShelfLevel.Name = "tbShelfLevel";
            this.tbShelfLevel.Size = new System.Drawing.Size(120, 45);
            this.tbShelfLevel.TabIndex = 32;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微軟正黑體", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label1.Location = new System.Drawing.Point(183, 161);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(153, 35);
            this.label1.TabIndex = 31;
            this.label1.Text = "ShelfLevel:";
            // 
            // tbShelfGrid
            // 
            this.tbShelfGrid.Font = new System.Drawing.Font("微軟正黑體", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.tbShelfGrid.Location = new System.Drawing.Point(407, 216);
            this.tbShelfGrid.Name = "tbShelfGrid";
            this.tbShelfGrid.Size = new System.Drawing.Size(120, 45);
            this.tbShelfGrid.TabIndex = 34;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("微軟正黑體", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label2.Location = new System.Drawing.Point(188, 219);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(142, 35);
            this.label2.TabIndex = 33;
            this.label2.Text = "ShelfGrid:";
            // 
            // tbMemo
            // 
            this.tbMemo.Font = new System.Drawing.Font("微軟正黑體", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.tbMemo.Location = new System.Drawing.Point(407, 275);
            this.tbMemo.Name = "tbMemo";
            this.tbMemo.Size = new System.Drawing.Size(271, 45);
            this.tbMemo.TabIndex = 36;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("微軟正黑體", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label3.Location = new System.Drawing.Point(196, 278);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(113, 35);
            this.label3.TabIndex = 35;
            this.label3.Text = "MEMO:";
            // 
            // tbShelfNo
            // 
            this.tbShelfNo.Font = new System.Drawing.Font("微軟正黑體", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.tbShelfNo.Location = new System.Drawing.Point(407, 100);
            this.tbShelfNo.Name = "tbShelfNo";
            this.tbShelfNo.Size = new System.Drawing.Size(120, 45);
            this.tbShelfNo.TabIndex = 39;
            // 
            // cbWhname
            // 
            this.cbWhname.Font = new System.Drawing.Font("微軟正黑體", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.cbWhname.FormattingEnabled = true;
            this.cbWhname.Location = new System.Drawing.Point(407, 38);
            this.cbWhname.Name = "cbWhname";
            this.cbWhname.Size = new System.Drawing.Size(173, 43);
            this.cbWhname.TabIndex = 40;
            // 
            // cbWarehouseID
            // 
            this.cbWarehouseID.Font = new System.Drawing.Font("微軟正黑體", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.cbWarehouseID.FormattingEnabled = true;
            this.cbWarehouseID.Location = new System.Drawing.Point(756, 410);
            this.cbWarehouseID.Name = "cbWarehouseID";
            this.cbWarehouseID.Size = new System.Drawing.Size(32, 28);
            this.cbWarehouseID.TabIndex = 38;
            this.cbWarehouseID.Visible = false;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // WHBIStorageLocationDetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gainsboro;
            this.ClientSize = new System.Drawing.Size(876, 452);
            this.Controls.Add(this.cbWhname);
            this.Controls.Add(this.tbShelfNo);
            this.Controls.Add(this.cbWarehouseID);
            this.Controls.Add(this.tbMemo);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tbShelfGrid);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tbShelfLevel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.lbWarehouseName);
            this.Controls.Add(this.lbWHName);
            this.Name = "WHBIStorageLocationDetail";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "WHBasicInformationStorageLocationDetail";
            this.Load += new System.EventHandler(this.WHBIStorageLocationDetail_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label lbWarehouseName;
        private System.Windows.Forms.Label lbWHName;
        internal System.Windows.Forms.TextBox tbShelfLevel;
        private System.Windows.Forms.Label label1;
        internal System.Windows.Forms.TextBox tbShelfGrid;
        private System.Windows.Forms.Label label2;
        internal System.Windows.Forms.TextBox tbMemo;
        private System.Windows.Forms.Label label3;
        internal System.Windows.Forms.TextBox tbShelfNo;
        internal System.Windows.Forms.ComboBox cbWhname;
        internal System.Windows.Forms.ComboBox cbWarehouseID;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
    }
}