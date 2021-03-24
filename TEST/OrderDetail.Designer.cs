namespace TEST
{
    partial class OrderDetail
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OrderDetail));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dgvOrderDetail = new System.Windows.Forms.DataGridView();
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
            this.label1 = new System.Windows.Forms.Label();
            this.lbOrder = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dgvInner = new System.Windows.Forms.DataGridView();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrderDetail)).BeginInit();
            this.tsButton.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInner)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.dgvOrderDetail);
            this.panel1.Location = new System.Drawing.Point(9, 122);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(471, 414);
            this.panel1.TabIndex = 0;
            // 
            // dgvOrderDetail
            // 
            this.dgvOrderDetail.AllowUserToAddRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.LightGray;
            this.dgvOrderDetail.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvOrderDetail.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvOrderDetail.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("微軟正黑體", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvOrderDetail.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvOrderDetail.Location = new System.Drawing.Point(3, 2);
            this.dgvOrderDetail.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dgvOrderDetail.Name = "dgvOrderDetail";
            this.dgvOrderDetail.ReadOnly = true;
            this.dgvOrderDetail.RowHeadersVisible = false;
            this.dgvOrderDetail.RowHeadersWidth = 62;
            this.dgvOrderDetail.RowTemplate.Height = 31;
            this.dgvOrderDetail.Size = new System.Drawing.Size(466, 408);
            this.dgvOrderDetail.TabIndex = 0;
            this.dgvOrderDetail.SelectionChanged += new System.EventHandler(this.DgvOrderDetail_SelectionChanged);
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
            this.tsButton.Size = new System.Drawing.Size(780, 58);
            this.tsButton.TabIndex = 19;
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
            this.tspClear.Enabled = false;
            this.tspClear.Image = ((System.Drawing.Image)(resources.GetObject("tspClear.Image")));
            this.tspClear.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tspClear.Name = "tspClear";
            this.tspClear.Size = new System.Drawing.Size(49, 55);
            this.tspClear.Text = "Clear";
            this.tspClear.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
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
            this.tsbQuery.Enabled = false;
            this.tsbQuery.Image = ((System.Drawing.Image)(resources.GetObject("tsbQuery.Image")));
            this.tsbQuery.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbQuery.Name = "tsbQuery";
            this.tsbQuery.Size = new System.Drawing.Size(56, 55);
            this.tsbQuery.Text = "Query";
            this.tsbQuery.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsbQuery.ToolTipText = "列表檢視";
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
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微軟正黑體", 22F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label1.Location = new System.Drawing.Point(11, 66);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(191, 47);
            this.label1.TabIndex = 20;
            this.label1.Text = "OrderNO:";
            // 
            // lbOrder
            // 
            this.lbOrder.AutoSize = true;
            this.lbOrder.Font = new System.Drawing.Font("微軟正黑體", 22F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lbOrder.Location = new System.Drawing.Point(217, 66);
            this.lbOrder.Name = "lbOrder";
            this.lbOrder.Size = new System.Drawing.Size(258, 47);
            this.lbOrder.TabIndex = 21;
            this.lbOrder.Text = "BA1801-001A";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.dgvInner);
            this.panel2.Location = new System.Drawing.Point(485, 124);
            this.panel2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(284, 408);
            this.panel2.TabIndex = 22;
            // 
            // dgvInner
            // 
            this.dgvInner.AllowUserToAddRows = false;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.LightGray;
            this.dgvInner.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvInner.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvInner.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("微軟正黑體", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvInner.DefaultCellStyle = dataGridViewCellStyle4;
            this.dgvInner.Location = new System.Drawing.Point(3, 2);
            this.dgvInner.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dgvInner.Name = "dgvInner";
            this.dgvInner.ReadOnly = true;
            this.dgvInner.RowHeadersVisible = false;
            this.dgvInner.RowHeadersWidth = 62;
            this.dgvInner.RowTemplate.Height = 31;
            this.dgvInner.Size = new System.Drawing.Size(279, 403);
            this.dgvInner.TabIndex = 0;
            // 
            // OrderDetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(780, 537);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.lbOrder);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tsButton);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "OrderDetail";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "OrderDetail";
            this.Load += new System.EventHandler(this.OrderDetail_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrderDetail)).EndInit();
            this.tsButton.ResumeLayout(false);
            this.tsButton.PerformLayout();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvInner)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dgvOrderDetail;
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
        private System.Windows.Forms.Label label1;
        internal System.Windows.Forms.Label lbOrder;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridView dgvInner;
    }
}