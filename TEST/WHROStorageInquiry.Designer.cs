namespace TEST
{
    partial class WHROStorageInquiry
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WHROStorageInquiry));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
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
            this.btnMAP = new System.Windows.Forms.Button();
            this.lbOrder = new System.Windows.Forms.Label();
            this.tbOrder = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dgvDDZL = new System.Windows.Forms.DataGridView();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dgvCARTON = new System.Windows.Forms.DataGridView();
            this.tsButton.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDDZL)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCARTON)).BeginInit();
            this.SuspendLayout();
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
            this.tsButton.Size = new System.Drawing.Size(983, 58);
            this.tsButton.TabIndex = 18;
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
            this.tsbDelete.Enabled = false;
            this.tsbDelete.Image = ((System.Drawing.Image)(resources.GetObject("tsbDelete.Image")));
            this.tsbDelete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbDelete.Name = "tsbDelete";
            this.tsbDelete.Size = new System.Drawing.Size(57, 55);
            this.tsbDelete.Text = "Delete";
            this.tsbDelete.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsbDelete.ToolTipText = "列表檢視";
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
            this.tsbExcel.Enabled = false;
            this.tsbExcel.Image = ((System.Drawing.Image)(resources.GetObject("tsbExcel.Image")));
            this.tsbExcel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbExcel.Name = "tsbExcel";
            this.tsbExcel.Size = new System.Drawing.Size(47, 55);
            this.tsbExcel.Text = "Excel";
            this.tsbExcel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
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
            // 
            // btnMAP
            // 
            this.btnMAP.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMAP.BackColor = System.Drawing.Color.Gray;
            this.btnMAP.Font = new System.Drawing.Font("微軟正黑體", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnMAP.Location = new System.Drawing.Point(833, 62);
            this.btnMAP.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnMAP.Name = "btnMAP";
            this.btnMAP.Size = new System.Drawing.Size(139, 53);
            this.btnMAP.TabIndex = 19;
            this.btnMAP.Text = "Locate";
            this.btnMAP.UseVisualStyleBackColor = false;
            this.btnMAP.Click += new System.EventHandler(this.Button1_Click);
            // 
            // lbOrder
            // 
            this.lbOrder.AutoSize = true;
            this.lbOrder.Font = new System.Drawing.Font("微軟正黑體", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lbOrder.Location = new System.Drawing.Point(11, 68);
            this.lbOrder.Name = "lbOrder";
            this.lbOrder.Size = new System.Drawing.Size(154, 38);
            this.lbOrder.TabIndex = 22;
            this.lbOrder.Text = "OrderNO:";
            // 
            // tbOrder
            // 
            this.tbOrder.Font = new System.Drawing.Font("微軟正黑體", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.tbOrder.Location = new System.Drawing.Point(180, 66);
            this.tbOrder.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tbOrder.Name = "tbOrder";
            this.tbOrder.Size = new System.Drawing.Size(448, 47);
            this.tbOrder.TabIndex = 23;
            this.tbOrder.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TbOrder_KeyDown);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.dgvDDZL);
            this.panel1.Location = new System.Drawing.Point(11, 124);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(493, 374);
            this.panel1.TabIndex = 24;
            // 
            // dgvDDZL
            // 
            this.dgvDDZL.AllowUserToAddRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.LightGray;
            this.dgvDDZL.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvDDZL.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvDDZL.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvDDZL.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Sunken;
            this.dgvDDZL.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("微軟正黑體", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDDZL.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvDDZL.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvDDZL.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvDDZL.Location = new System.Drawing.Point(3, 2);
            this.dgvDDZL.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dgvDDZL.Name = "dgvDDZL";
            this.dgvDDZL.ReadOnly = true;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("微軟正黑體", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDDZL.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvDDZL.RowHeadersVisible = false;
            this.dgvDDZL.RowHeadersWidth = 62;
            this.dgvDDZL.RowTemplate.Height = 31;
            this.dgvDDZL.Size = new System.Drawing.Size(488, 369);
            this.dgvDDZL.TabIndex = 0;
            this.dgvDDZL.SelectionChanged += new System.EventHandler(this.DgvDDZL_SelectionChanged);
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.Controls.Add(this.dgvCARTON);
            this.panel2.Location = new System.Drawing.Point(509, 124);
            this.panel2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(463, 374);
            this.panel2.TabIndex = 25;
            // 
            // dgvCARTON
            // 
            this.dgvCARTON.AllowUserToAddRows = false;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.LightGray;
            this.dgvCARTON.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle5;
            this.dgvCARTON.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvCARTON.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvCARTON.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Sunken;
            this.dgvCARTON.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("微軟正黑體", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvCARTON.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.dgvCARTON.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvCARTON.DefaultCellStyle = dataGridViewCellStyle7;
            this.dgvCARTON.Location = new System.Drawing.Point(3, 2);
            this.dgvCARTON.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dgvCARTON.Name = "dgvCARTON";
            this.dgvCARTON.ReadOnly = true;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("微軟正黑體", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvCARTON.RowHeadersDefaultCellStyle = dataGridViewCellStyle8;
            this.dgvCARTON.RowHeadersVisible = false;
            this.dgvCARTON.RowHeadersWidth = 62;
            this.dgvCARTON.RowTemplate.Height = 31;
            this.dgvCARTON.Size = new System.Drawing.Size(458, 369);
            this.dgvCARTON.TabIndex = 0;
            this.dgvCARTON.DoubleClick += new System.EventHandler(this.DgvCARTON_DoubleClick);
            // 
            // WHROStorageInquiry
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gainsboro;
            this.ClientSize = new System.Drawing.Size(983, 508);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.tbOrder);
            this.Controls.Add(this.lbOrder);
            this.Controls.Add(this.btnMAP);
            this.Controls.Add(this.tsButton);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "WHROStorageInquiry";
            this.Text = "WHReportOrderStorageInquiry";
            this.Load += new System.EventHandler(this.WHROStorageInquiry_Load);
            this.Shown += new System.EventHandler(this.WHROStorageInquiry_Shown);
            this.tsButton.ResumeLayout(false);
            this.tsButton.PerformLayout();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDDZL)).EndInit();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCARTON)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

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
        private System.Windows.Forms.Button btnMAP;
        private System.Windows.Forms.Label lbOrder;
        private System.Windows.Forms.TextBox tbOrder;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridView dgvDDZL;
        private System.Windows.Forms.DataGridView dgvCARTON;
    }
}