namespace TEST
{
    partial class WHInsProcess
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WHInsProcess));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.lblInWare = new System.Windows.Forms.Label();
            this.lblAmount = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tbOrder = new System.Windows.Forms.TextBox();
            this.lbOrderNo = new System.Windows.Forms.Label();
            this.tsButton = new System.Windows.Forms.ToolStrip();
            this.tspInsert = new System.Windows.Forms.ToolStripButton();
            this.tsbClear = new System.Windows.Forms.ToolStripButton();
            this.tspClear = new System.Windows.Forms.ToolStripButton();
            this.tsbDelete = new System.Windows.Forms.ToolStripButton();
            this.tsbQuery = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbFirst = new System.Windows.Forms.ToolStripButton();
            this.tsbPrior = new System.Windows.Forms.ToolStripButton();
            this.tsbNext = new System.Windows.Forms.ToolStripButton();
            this.tsbLast = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbRClick = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbPrint = new System.Windows.Forms.ToolStripButton();
            this.tsbExcel = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbExit = new System.Windows.Forms.ToolStripButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dgvCarton = new System.Windows.Forms.DataGridView();
            this.button1 = new System.Windows.Forms.Button();
            this.lblPercent = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lblSB = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.tsButton.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCarton)).BeginInit();
            this.SuspendLayout();
            // 
            // lblInWare
            // 
            this.lblInWare.AutoSize = true;
            this.lblInWare.Cursor = System.Windows.Forms.Cursors.Cross;
            this.lblInWare.Font = new System.Drawing.Font("微軟正黑體", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lblInWare.Location = new System.Drawing.Point(281, 200);
            this.lblInWare.Name = "lblInWare";
            this.lblInWare.Size = new System.Drawing.Size(31, 34);
            this.lblInWare.TabIndex = 38;
            this.lblInWare.Text = "0";
            // 
            // lblAmount
            // 
            this.lblAmount.AutoSize = true;
            this.lblAmount.Font = new System.Drawing.Font("微軟正黑體", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lblAmount.Location = new System.Drawing.Point(281, 139);
            this.lblAmount.Name = "lblAmount";
            this.lblAmount.Size = new System.Drawing.Size(31, 34);
            this.lblAmount.TabIndex = 37;
            this.lblAmount.Text = "0";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("微軟正黑體", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label2.Location = new System.Drawing.Point(44, 200);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(188, 34);
            this.label2.TabIndex = 36;
            this.label2.Text = "InWarehouse:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微軟正黑體", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label1.Location = new System.Drawing.Point(44, 139);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(198, 34);
            this.label1.TabIndex = 35;
            this.label1.Text = "OrderAmount:";
            // 
            // tbOrder
            // 
            this.tbOrder.Font = new System.Drawing.Font("微軟正黑體", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.tbOrder.Location = new System.Drawing.Point(189, 72);
            this.tbOrder.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tbOrder.Name = "tbOrder";
            this.tbOrder.Size = new System.Drawing.Size(275, 43);
            this.tbOrder.TabIndex = 34;
            this.tbOrder.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TbOrder_KeyDown);
            // 
            // lbOrderNo
            // 
            this.lbOrderNo.AutoSize = true;
            this.lbOrderNo.Font = new System.Drawing.Font("微軟正黑體", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lbOrderNo.Location = new System.Drawing.Point(44, 75);
            this.lbOrderNo.Name = "lbOrderNo";
            this.lbOrderNo.Size = new System.Drawing.Size(134, 34);
            this.lbOrderNo.TabIndex = 33;
            this.lbOrderNo.Text = "OrderNo:";
            // 
            // tsButton
            // 
            this.tsButton.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.tsButton.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tspInsert,
            this.tsbClear,
            this.tspClear,
            this.tsbDelete,
            this.tsbQuery,
            this.toolStripSeparator4,
            this.tsbFirst,
            this.tsbPrior,
            this.tsbNext,
            this.tsbLast,
            this.toolStripSeparator2,
            this.tsbRClick,
            this.toolStripSeparator1,
            this.tsbPrint,
            this.tsbExcel,
            this.toolStripSeparator3,
            this.tsbExit});
            this.tsButton.Location = new System.Drawing.Point(0, 0);
            this.tsButton.Name = "tsButton";
            this.tsButton.Padding = new System.Windows.Forms.Padding(0, 0, 3, 0);
            this.tsButton.Size = new System.Drawing.Size(1000, 58);
            this.tsButton.TabIndex = 32;
            this.tsButton.Text = "toolStrip1";
            // 
            // tspInsert
            // 
            this.tspInsert.Enabled = false;
            this.tspInsert.Image = ((System.Drawing.Image)(resources.GetObject("tspInsert.Image")));
            this.tspInsert.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tspInsert.Name = "tspInsert";
            this.tspInsert.Size = new System.Drawing.Size(52, 55);
            this.tspInsert.Text = "Insert";
            this.tspInsert.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tspInsert.ToolTipText = "列表檢視";
            // 
            // tsbClear
            // 
            this.tsbClear.Enabled = false;
            this.tsbClear.Image = ((System.Drawing.Image)(resources.GetObject("tsbClear.Image")));
            this.tsbClear.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbClear.Name = "tsbClear";
            this.tsbClear.Size = new System.Drawing.Size(63, 55);
            this.tsbClear.Text = "Modify";
            this.tsbClear.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // tspClear
            // 
            this.tspClear.Image = ((System.Drawing.Image)(resources.GetObject("tspClear.Image")));
            this.tspClear.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tspClear.Name = "tspClear";
            this.tspClear.Size = new System.Drawing.Size(49, 55);
            this.tspClear.Text = "Clear";
            this.tspClear.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tspClear.Click += new System.EventHandler(this.TspClear_Click);
            // 
            // tsbDelete
            // 
            this.tsbDelete.Image = ((System.Drawing.Image)(resources.GetObject("tsbDelete.Image")));
            this.tsbDelete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbDelete.Name = "tsbDelete";
            this.tsbDelete.Size = new System.Drawing.Size(57, 55);
            this.tsbDelete.Text = "Delete";
            this.tsbDelete.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsbDelete.ToolTipText = "列表檢視";
            this.tsbDelete.Click += new System.EventHandler(this.TsbDelete_Click);
            // 
            // tsbQuery
            // 
            this.tsbQuery.Image = ((System.Drawing.Image)(resources.GetObject("tsbQuery.Image")));
            this.tsbQuery.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbQuery.Name = "tsbQuery";
            this.tsbQuery.Size = new System.Drawing.Size(56, 55);
            this.tsbQuery.Text = "Query";
            this.tsbQuery.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsbQuery.ToolTipText = "列表檢視";
            this.tsbQuery.Click += new System.EventHandler(this.TsbQuery_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 58);
            // 
            // tsbFirst
            // 
            this.tsbFirst.Enabled = false;
            this.tsbFirst.Image = ((System.Drawing.Image)(resources.GetObject("tsbFirst.Image")));
            this.tsbFirst.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbFirst.Name = "tsbFirst";
            this.tsbFirst.Size = new System.Drawing.Size(43, 55);
            this.tsbFirst.Text = "First";
            this.tsbFirst.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsbFirst.ToolTipText = "列表檢視";
            // 
            // tsbPrior
            // 
            this.tsbPrior.Enabled = false;
            this.tsbPrior.Image = ((System.Drawing.Image)(resources.GetObject("tsbPrior.Image")));
            this.tsbPrior.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbPrior.Name = "tsbPrior";
            this.tsbPrior.Size = new System.Drawing.Size(47, 55);
            this.tsbPrior.Text = "Prior";
            this.tsbPrior.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsbPrior.ToolTipText = "列表檢視";
            // 
            // tsbNext
            // 
            this.tsbNext.Enabled = false;
            this.tsbNext.Image = ((System.Drawing.Image)(resources.GetObject("tsbNext.Image")));
            this.tsbNext.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbNext.Name = "tsbNext";
            this.tsbNext.Size = new System.Drawing.Size(45, 55);
            this.tsbNext.Text = "Next";
            this.tsbNext.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsbNext.ToolTipText = "列表檢視";
            // 
            // tsbLast
            // 
            this.tsbLast.Enabled = false;
            this.tsbLast.Image = ((System.Drawing.Image)(resources.GetObject("tsbLast.Image")));
            this.tsbLast.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbLast.Name = "tsbLast";
            this.tsbLast.Size = new System.Drawing.Size(41, 55);
            this.tsbLast.Text = "Last";
            this.tsbLast.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsbLast.ToolTipText = "列表檢視";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 58);
            // 
            // tsbRClick
            // 
            this.tsbRClick.Enabled = false;
            this.tsbRClick.Image = ((System.Drawing.Image)(resources.GetObject("tsbRClick.Image")));
            this.tsbRClick.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbRClick.Name = "tsbRClick";
            this.tsbRClick.Size = new System.Drawing.Size(62, 55);
            this.tsbRClick.Text = "R-Click";
            this.tsbRClick.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsbRClick.ToolTipText = "列表檢視";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 58);
            // 
            // tsbPrint
            // 
            this.tsbPrint.Enabled = false;
            this.tsbPrint.Image = ((System.Drawing.Image)(resources.GetObject("tsbPrint.Image")));
            this.tsbPrint.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbPrint.Name = "tsbPrint";
            this.tsbPrint.Size = new System.Drawing.Size(46, 55);
            this.tsbPrint.Text = "Print";
            this.tsbPrint.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsbPrint.ToolTipText = "列表檢視";
            // 
            // tsbExcel
            // 
            this.tsbExcel.Image = ((System.Drawing.Image)(resources.GetObject("tsbExcel.Image")));
            this.tsbExcel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbExcel.Name = "tsbExcel";
            this.tsbExcel.Size = new System.Drawing.Size(47, 55);
            this.tsbExcel.Text = "Excel";
            this.tsbExcel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsbExcel.Click += new System.EventHandler(this.TsbExcel_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 58);
            // 
            // tsbExit
            // 
            this.tsbExit.Image = ((System.Drawing.Image)(resources.GetObject("tsbExit.Image")));
            this.tsbExit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbExit.Name = "tsbExit";
            this.tsbExit.Size = new System.Drawing.Size(37, 55);
            this.tsbExit.Text = "Exit";
            this.tsbExit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsbExit.Click += new System.EventHandler(this.TsbExit_Click);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.dgvCarton);
            this.panel1.Location = new System.Drawing.Point(508, 62);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(482, 358);
            this.panel1.TabIndex = 42;
            // 
            // dgvCarton
            // 
            this.dgvCarton.AllowUserToAddRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.LightGray;
            this.dgvCarton.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvCarton.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvCarton.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvCarton.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Sunken;
            this.dgvCarton.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvCarton.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvCarton.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvCarton.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvCarton.Location = new System.Drawing.Point(3, 2);
            this.dgvCarton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dgvCarton.Name = "dgvCarton";
            this.dgvCarton.ReadOnly = true;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("微軟正黑體", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvCarton.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvCarton.RowHeadersVisible = false;
            this.dgvCarton.RowHeadersWidth = 62;
            this.dgvCarton.RowTemplate.Height = 31;
            this.dgvCarton.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCarton.Size = new System.Drawing.Size(476, 351);
            this.dgvCarton.TabIndex = 14;
            this.dgvCarton.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvCarton_CellContentClick);
            this.dgvCarton.DoubleClick += new System.EventHandler(this.DgvCarton_DoubleClick);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.DodgerBlue;
            this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.button1.Location = new System.Drawing.Point(189, 371);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(129, 43);
            this.button1.TabIndex = 41;
            this.button1.Text = "Inspection";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // lblPercent
            // 
            this.lblPercent.AutoSize = true;
            this.lblPercent.Font = new System.Drawing.Font("微軟正黑體", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lblPercent.Location = new System.Drawing.Point(281, 259);
            this.lblPercent.Name = "lblPercent";
            this.lblPercent.Size = new System.Drawing.Size(31, 34);
            this.lblPercent.TabIndex = 40;
            this.lblPercent.Text = "0";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("微軟正黑體", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label5.Location = new System.Drawing.Point(44, 259);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(163, 34);
            this.label5.TabIndex = 39;
            this.label5.Text = "Percentage:";
            // 
            // lblSB
            // 
            this.lblSB.AutoSize = true;
            this.lblSB.Font = new System.Drawing.Font("微軟正黑體", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lblSB.Location = new System.Drawing.Point(281, 313);
            this.lblSB.Name = "lblSB";
            this.lblSB.Size = new System.Drawing.Size(31, 34);
            this.lblSB.TabIndex = 44;
            this.lblSB.Text = "0";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("微軟正黑體", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label4.Location = new System.Drawing.Point(44, 313);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(203, 34);
            this.label4.TabIndex = 43;
            this.label4.Text = "Selected Boxes";
            // 
            // WHInsProcess
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1000, 425);
            this.Controls.Add(this.lblSB);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lblInWare);
            this.Controls.Add(this.lblAmount);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbOrder);
            this.Controls.Add(this.lbOrderNo);
            this.Controls.Add(this.tsButton);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.lblPercent);
            this.Controls.Add(this.label5);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "WHInsProcess";
            this.Text = "WHInsProcess";
            this.Load += new System.EventHandler(this.WHInsProcess_Load);
            this.tsButton.ResumeLayout(false);
            this.tsButton.PerformLayout();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCarton)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblInWare;
        private System.Windows.Forms.Label lblAmount;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbOrder;
        private System.Windows.Forms.Label lbOrderNo;
        private System.Windows.Forms.ToolStrip tsButton;
        private System.Windows.Forms.ToolStripButton tspInsert;
        private System.Windows.Forms.ToolStripButton tsbClear;
        private System.Windows.Forms.ToolStripButton tspClear;
        private System.Windows.Forms.ToolStripButton tsbDelete;
        private System.Windows.Forms.ToolStripButton tsbQuery;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripButton tsbFirst;
        private System.Windows.Forms.ToolStripButton tsbPrior;
        private System.Windows.Forms.ToolStripButton tsbNext;
        private System.Windows.Forms.ToolStripButton tsbLast;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton tsbRClick;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton tsbPrint;
        private System.Windows.Forms.ToolStripButton tsbExcel;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton tsbExit;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label lblPercent;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridView dgvCarton;
        private System.Windows.Forms.Label lblSB;
        private System.Windows.Forms.Label label4;
    }
}