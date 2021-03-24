namespace TEST
{
    partial class Mainpage2
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
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("Warehouse 倉庫");
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("Storage Location 儲存位置");
            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("Pallet 棧板");
            System.Windows.Forms.TreeNode treeNode4 = new System.Windows.Forms.TreeNode("Basic Information 基本資料", new System.Windows.Forms.TreeNode[] {
            treeNode1,
            treeNode2,
            treeNode3});
            System.Windows.Forms.TreeNode treeNode5 = new System.Windows.Forms.TreeNode("Scan In 成品掃描");
            System.Windows.Forms.TreeNode treeNode6 = new System.Windows.Forms.TreeNode("Assign Pallet 指定棧板");
            System.Windows.Forms.TreeNode treeNode7 = new System.Windows.Forms.TreeNode("Assign Store Location 指定儲存區");
            System.Windows.Forms.TreeNode treeNode8 = new System.Windows.Forms.TreeNode("Storage 存放", new System.Windows.Forms.TreeNode[] {
            treeNode6,
            treeNode7});
            System.Windows.Forms.TreeNode treeNode9 = new System.Windows.Forms.TreeNode("InWarehouse  入庫秤重");
            System.Windows.Forms.TreeNode treeNode10 = new System.Windows.Forms.TreeNode("Scan In Finished Goods 成品入庫", new System.Windows.Forms.TreeNode[] {
            treeNode5,
            treeNode8,
            treeNode9});
            System.Windows.Forms.TreeNode treeNode11 = new System.Windows.Forms.TreeNode("Scan Out 出庫掃描");
            System.Windows.Forms.TreeNode treeNode12 = new System.Windows.Forms.TreeNode("CTN Position外箱位置");
            System.Windows.Forms.TreeNode treeNode13 = new System.Windows.Forms.TreeNode("Scan Out Finished Goods 成品出庫", new System.Windows.Forms.TreeNode[] {
            treeNode11,
            treeNode12});
            System.Windows.Forms.TreeNode treeNode14 = new System.Windows.Forms.TreeNode("Inspection 驗貨選箱");
            System.Windows.Forms.TreeNode treeNode15 = new System.Windows.Forms.TreeNode("InspectionFix 驗貨修正");
            System.Windows.Forms.TreeNode treeNode16 = new System.Windows.Forms.TreeNode("Inspection Process 驗貨流程", new System.Windows.Forms.TreeNode[] {
            treeNode14,
            treeNode15});
            System.Windows.Forms.TreeNode treeNode17 = new System.Windows.Forms.TreeNode("Order Status In Warehouse 訂單繳庫狀況");
            System.Windows.Forms.TreeNode treeNode18 = new System.Windows.Forms.TreeNode("Order storage inquiry 訂單儲位查詢");
            System.Windows.Forms.TreeNode treeNode19 = new System.Windows.Forms.TreeNode("Finished Order 已出貨訂單查詢");
            System.Windows.Forms.TreeNode treeNode20 = new System.Windows.Forms.TreeNode("In Warehouse 在庫訂單");
            System.Windows.Forms.TreeNode treeNode21 = new System.Windows.Forms.TreeNode("All Day Report 全日入庫統計");
            System.Windows.Forms.TreeNode treeNode22 = new System.Windows.Forms.TreeNode("CartonDetail  訂單外箱明細");
            System.Windows.Forms.TreeNode treeNode23 = new System.Windows.Forms.TreeNode("LeanDetail 令線統計");
            System.Windows.Forms.TreeNode treeNode24 = new System.Windows.Forms.TreeNode("Report 報表", new System.Windows.Forms.TreeNode[] {
            treeNode17,
            treeNode18,
            treeNode19,
            treeNode20,
            treeNode21,
            treeNode22,
            treeNode23});
            System.Windows.Forms.TreeNode treeNode25 = new System.Windows.Forms.TreeNode("Order Status Billboard");
            System.Windows.Forms.TreeNode treeNode26 = new System.Windows.Forms.TreeNode("LeanDaily");
            System.Windows.Forms.TreeNode treeNode27 = new System.Windows.Forms.TreeNode("Stock 庫存變化");
            System.Windows.Forms.TreeNode treeNode28 = new System.Windows.Forms.TreeNode("Billboard 看板", new System.Windows.Forms.TreeNode[] {
            treeNode25,
            treeNode26,
            treeNode27});
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.tvWarehouse = new System.Windows.Forms.TreeView();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.tvWarehouse);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.AutoScroll = true;
            this.splitContainer1.Panel2.BackColor = System.Drawing.Color.SkyBlue;
            this.splitContainer1.Size = new System.Drawing.Size(875, 370);
            this.splitContainer1.SplitterDistance = 162;
            this.splitContainer1.TabIndex = 0;
            // 
            // tvWarehouse
            // 
            this.tvWarehouse.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tvWarehouse.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.tvWarehouse.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.tvWarehouse.Location = new System.Drawing.Point(0, 2);
            this.tvWarehouse.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tvWarehouse.Name = "tvWarehouse";
            treeNode1.Name = "Node1_1";
            treeNode1.Text = "Warehouse 倉庫";
            treeNode2.Name = "Node1_2";
            treeNode2.Text = "Storage Location 儲存位置";
            treeNode3.Name = "Node1_3";
            treeNode3.Text = "Pallet 棧板";
            treeNode4.Name = "Node1";
            treeNode4.Text = "Basic Information 基本資料";
            treeNode5.Name = "Node2_1";
            treeNode5.Text = "Scan In 成品掃描";
            treeNode6.Name = "Node2_2_1";
            treeNode6.Text = "Assign Pallet 指定棧板";
            treeNode7.Name = "Node2_2_2";
            treeNode7.Text = "Assign Store Location 指定儲存區";
            treeNode8.Name = "Node2_2";
            treeNode8.Text = "Storage 存放";
            treeNode9.Name = "Node2_3";
            treeNode9.Text = "InWarehouse  入庫秤重";
            treeNode10.Name = "Node2";
            treeNode10.Text = "Scan In Finished Goods 成品入庫";
            treeNode11.Name = "Node3_1";
            treeNode11.Text = "Scan Out 出庫掃描";
            treeNode12.Name = "Node3_2";
            treeNode12.Text = "CTN Position外箱位置";
            treeNode13.Name = "Node3";
            treeNode13.Text = "Scan Out Finished Goods 成品出庫";
            treeNode14.Name = "Node4_1";
            treeNode14.Text = "Inspection 驗貨選箱";
            treeNode15.Name = "Node4_2";
            treeNode15.Text = "InspectionFix 驗貨修正";
            treeNode16.Name = "Node4";
            treeNode16.Text = "Inspection Process 驗貨流程";
            treeNode17.Name = "Node5_1";
            treeNode17.Text = "Order Status In Warehouse 訂單繳庫狀況";
            treeNode18.Name = "Node5_2";
            treeNode18.Text = "Order storage inquiry 訂單儲位查詢";
            treeNode19.Name = "Node5_3";
            treeNode19.Text = "Finished Order 已出貨訂單查詢";
            treeNode20.Name = "Node5_4";
            treeNode20.Text = "In Warehouse 在庫訂單";
            treeNode21.Name = "Node5_5";
            treeNode21.Text = "All Day Report 全日入庫統計";
            treeNode22.Name = "Node5_6";
            treeNode22.Text = "CartonDetail  訂單外箱明細";
            treeNode23.Name = "Node5_7";
            treeNode23.Text = "LeanDetail 令線統計";
            treeNode24.Name = "Node5";
            treeNode24.Text = "Report 報表";
            treeNode25.Name = "Node6_1";
            treeNode25.Text = "Order Status Billboard";
            treeNode26.Name = "Node6_2";
            treeNode26.Text = "LeanDaily";
            treeNode27.Name = "Node6_3";
            treeNode27.Text = "Stock 庫存變化";
            treeNode28.Name = "Node6";
            treeNode28.Text = "Billboard 看板";
            this.tvWarehouse.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode4,
            treeNode10,
            treeNode13,
            treeNode16,
            treeNode24,
            treeNode28});
            this.tvWarehouse.Size = new System.Drawing.Size(159, 358);
            this.tvWarehouse.TabIndex = 4;
            this.tvWarehouse.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.TvWarehouse_AfterSelect_1);
            // 
            // Mainpage2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(875, 370);
            this.Controls.Add(this.splitContainer1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Mainpage2";
            this.Text = "MainPage2";
            this.Load += new System.EventHandler(this.Mainpage2_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.SplitContainer splitContainer1;
        public System.Windows.Forms.TreeView tvWarehouse;
    }
}