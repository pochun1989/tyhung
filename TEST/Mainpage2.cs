using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TEST
{
    public partial class Mainpage2 : Form
    {


        string node = "";
        //Mainpage M = new Mainpage();
        //DateTime myDate = DateTime.Now;
        public string myDate ;
        public string modifySL = "0";
        public int checkScan = 0;

        public Mainpage2()
        {
            InitializeComponent();
            //this.WindowState = FormWindowState.Maximized;            
        }

        private void BtnMunuSwitch_Click(object sender, EventArgs e)
        {
            
        }

        #region 樹狀節點方法

        #region 倉庫基本訊息

        private void WHBasicInformationWarehouse()
        {         
            splitContainer1.Panel2.Controls.Clear(); // 清空工作表介面                                         
            WHBIWarehouse al = new WHBIWarehouse();
            al.TopLevel = false; // 在最上層
            al.FormBorderStyle = FormBorderStyle.None; // 清除邊框
            splitContainer1.Panel2.Controls.Add(al); // 工作表加視窗
            al.Width = splitContainer1.Panel2.Width;
            al.Height = splitContainer1.Panel2.Height;
            
            //al.WindowState = FormWindowState.Maximized;
            al.Show(); // 視窗顯示
            checkScan = 1;
        }

        #endregion

        #region 倉庫儲存位置

        private void WHBasicInformationStorageLocation()
        {
            splitContainer1.Panel2.Controls.Clear(); // 清空工作表介面                                         
            WHBIStorageLocation al = new WHBIStorageLocation();
            al.TopLevel = false; // 在最上層
            al.FormBorderStyle = FormBorderStyle.None; // 清除邊框
            splitContainer1.Panel2.Controls.Add(al); // 工作表加視窗

            al.Width = splitContainer1.Panel2.Width;
            al.Height = splitContainer1.Panel2.Height;
            //al.WindowState = FormWindowState.Maximized;
            al.Show(); // 視窗顯示
        }

        #endregion

        #region 倉庫棧板

        private void WHBasicInformationPallet()
        {
            splitContainer1.Panel2.Controls.Clear(); // 清空工作表介面                                         
            WHBIPallet al = new WHBIPallet();
            al.TopLevel = false; // 在最上層
            al.FormBorderStyle = FormBorderStyle.None; // 清除邊框
            splitContainer1.Panel2.Controls.Add(al); // 工作表加視窗

            al.Width = splitContainer1.Panel2.Width;
            al.Height = splitContainer1.Panel2.Height;
            al.Show(); // 視窗顯示
        }


        #endregion

        #region 掃描入庫

        private void WHScanInFinishedGoodsScanIn()
        {
            splitContainer1.Panel2.Controls.Clear(); // 清空工作表介面                                         
            WHSFGScanin2 al = new WHSFGScanin2();
            
            //al.myDate2 = myDate.ToString("yyyy-MM-dd HH:mm:ss");
            al.myDate2 = myDate;
            al.TopLevel = false; // 在最上層
            al.FormBorderStyle = FormBorderStyle.None; // 清除邊框
            splitContainer1.Panel2.Controls.Add(al); // 工作表加視窗

            al.Width = splitContainer1.Panel2.Width;
            al.Height = splitContainer1.Panel2.Height;
            al.Show(); // 視窗顯示
        }

        #endregion

        #region 掃描指定棧板

        private void WHScanInFinishedGoodsStorageAssignPallet()
        {
            splitContainer1.Panel2.Controls.Clear(); // 清空工作表介面                                         
            WHSFGStorageAssignPallet2 al = new WHSFGStorageAssignPallet2();
            al.TopLevel = false; // 在最上層
            al.FormBorderStyle = FormBorderStyle.None; // 清除邊框
            splitContainer1.Panel2.Controls.Add(al); // 工作表加視窗

            al.Width = splitContainer1.Panel2.Width;
            al.Height = splitContainer1.Panel2.Height;
            al.Show(); // 視窗顯示

        }

        #endregion

        #region 掃描指定儲存位置

        private void WHScanInFinishedGoodsAssignStoreLocation()
        {
            splitContainer1.Panel2.Controls.Clear(); // 清空工作表介面                                         
            WHSFGAssignStoreLocation al = new WHSFGAssignStoreLocation();
            al.TopLevel = false; // 在最上層
            al.FormBorderStyle = FormBorderStyle.None; // 清除邊框
            splitContainer1.Panel2.Controls.Add(al); // 工作表加視窗

            al.Width = splitContainer1.Panel2.Width;
            al.Height = splitContainer1.Panel2.Height;
            al.Show(); // 視窗顯示
        }

        #endregion

        #region 出庫掃描

        private void WHScanOutFinishedGoods()
        {
            splitContainer1.Panel2.Controls.Clear(); // 清空工作表介面                                         
            WHSO al = new WHSO();
            al.TopLevel = false; // 在最上層
            al.FormBorderStyle = FormBorderStyle.None; // 清除邊框
            splitContainer1.Panel2.Controls.Add(al); // 工作表加視窗

            al.Width = splitContainer1.Panel2.Width;
            al.Height = splitContainer1.Panel2.Height;
            al.Show(); // 視窗顯示
        }

        #endregion

        #region 驗貨流程

        private void WHIInspectionProcess()
        {
            splitContainer1.Panel2.Controls.Clear(); // 清空工作表介面                                         
            WHInsProcess al = new WHInsProcess();
            al.TopLevel = false; // 在最上層
            al.FormBorderStyle = FormBorderStyle.None; // 清除邊框
            splitContainer1.Panel2.Controls.Add(al); // 工作表加視窗

            al.Width = splitContainer1.Panel2.Width;
            al.Height = splitContainer1.Panel2.Height;
            al.Show(); // 視窗顯示
        }

        #endregion

        #region 驗貨修正

        private void WHIInspectionFix()
        {
            splitContainer1.Panel2.Controls.Clear(); // 清空工作表介面                                         
            InspectionFix al = new InspectionFix();
            al.TopLevel = false; // 在最上層
            al.FormBorderStyle = FormBorderStyle.None; // 清除邊框
            splitContainer1.Panel2.Controls.Add(al); // 工作表加視窗

            al.Width = splitContainer1.Panel2.Width;
            al.Height = splitContainer1.Panel2.Height;
            al.Show(); // 視窗顯示
        }

        #endregion

        #region 訂單繳庫情況

        private void WHReportOrderStatusInWarehouse()
        {
            splitContainer1.Panel2.Controls.Clear(); // 清空工作表介面                                         
            WHROStatusInWarehouse al = new WHROStatusInWarehouse();
            al.TopLevel = false; // 在最上層
            al.FormBorderStyle = FormBorderStyle.None; // 清除邊框
            splitContainer1.Panel2.Controls.Add(al); // 工作表加視窗

            al.Width = splitContainer1.Panel2.Width;
            al.Height = splitContainer1.Panel2.Height;
            al.Show(); // 視窗顯示
        }

        #endregion

        #region 訂單儲位查詢

        private void WHReportOrderStorageInquiry()
        {
            splitContainer1.Panel2.Controls.Clear(); // 清空工作表介面                                         
            WHROStorageInquiry al = new WHROStorageInquiry();
            al.TopLevel = false; // 在最上層
            al.FormBorderStyle = FormBorderStyle.None; // 清除邊框
            splitContainer1.Panel2.Controls.Add(al); // 工作表加視窗

            al.Width = splitContainer1.Panel2.Width;
            al.Height = splitContainer1.Panel2.Height;
            al.Show(); // 視窗顯示
        }

        #endregion

        #region 訂單儲位查詢

        private void FinishedOrder()
        {
            splitContainer1.Panel2.Controls.Clear(); // 清空工作表介面                                         
            ComOrder al = new ComOrder();
            al.TopLevel = false; // 在最上層
            al.FormBorderStyle = FormBorderStyle.None; // 清除邊框
            splitContainer1.Panel2.Controls.Add(al); // 工作表加視窗

            al.Width = splitContainer1.Panel2.Width;
            al.Height = splitContainer1.Panel2.Height;
            al.Show(); // 視窗顯示
        }

        #endregion    

        #region 訂單繳庫看板

        private void WHBillboardOrderStatus()
        {
            //splitContainer1.Panel2.Controls.Clear(); // 清空工作表介面                                         
            //WHBillboardOrderStatus al = new WHBillboardOrderStatus();
            //al.TopLevel = false; // 在最上層
            //al.FormBorderStyle = FormBorderStyle.None; // 清除邊框
            //splitContainer1.Panel2.Controls.Add(al); // 工作表加視窗

            //al.Width = splitContainer1.Panel2.Width;
            //al.Height = splitContainer1.Panel2.Height;
            //al.Show(); // 視窗顯示

            //splitContainer1.Panel2.Controls.Clear(); // 清空工作表介面                                         

            //al.TopLevel = false; // 在最上層
            //al.FormBorderStyle = FormBorderStyle.None; // 清除邊框
            //splitContainer1.Panel2.Controls.Add(al); // 工作表加視窗

            //al.Width = splitContainer1.Panel2.Width;
            //al.Height = splitContainer1.Panel2.Height;
            //al.groupBox1.Width = al.Width / 3;
            //al.groupBox1.Height = al.Height ;
            //al.groupBox2.Width = al.Width / 3;
            //al.groupBox2.Height = al.Height;
            //al.groupBox3.Width = al.Width / 3;
            //al.groupBox3.Height = al.Height;
            //int W = System.Windows.Forms.Screen.PrimaryScreen.Bounds.Width;
            //int H = System.Windows.Forms.Screen.PrimaryScreen.Bounds.Height;
            BoardStatus al = new BoardStatus();

            al.ShowDialog(); // 視窗顯示
            //this.TopLevel = false; // 在最上層
            
            //al.TopMost = true;

        }

        #endregion

        #region 在庫訂單

        private void InWarehouse()
        {
            splitContainer1.Panel2.Controls.Clear(); // 清空工作表介面                                         
            WHStorageNow al = new WHStorageNow();
            al.TopLevel = false; // 在最上層
            al.FormBorderStyle = FormBorderStyle.None; // 清除邊框
            splitContainer1.Panel2.Controls.Add(al); // 工作表加視窗

            al.Width = splitContainer1.Panel2.Width;
            al.Height = splitContainer1.Panel2.Height;
            al.Show(); // 視窗顯示
        }

        #endregion

        #region 在庫訂單

        private void CarDetail()
        {
            splitContainer1.Panel2.Controls.Clear(); // 清空工作表介面                                         
            CartonDetail al = new CartonDetail();
            al.TopLevel = false; // 在最上層
            al.FormBorderStyle = FormBorderStyle.None; // 清除邊框
            splitContainer1.Panel2.Controls.Add(al); // 工作表加視窗

            al.Width = splitContainer1.Panel2.Width;
            al.Height = splitContainer1.Panel2.Height;
            al.Show(); // 視窗顯示
        }

        #endregion

        #region 總計

        private void WAll()
        {
            splitContainer1.Panel2.Controls.Clear(); // 清空工作表介面                                         
            WHDayReport al = new WHDayReport();
            al.TopLevel = false; // 在最上層
            al.FormBorderStyle = FormBorderStyle.None; // 清除邊框
            splitContainer1.Panel2.Controls.Add(al); // 工作表加視窗

            al.Width = splitContainer1.Panel2.Width;
            al.Height = splitContainer1.Panel2.Height;
            al.Show(); // 視窗顯示
        }

        #endregion

        #region LEAN統計

        private void LeanLoad()
        {
            splitContainer1.Panel2.Controls.Clear(); // 清空工作表介面                                         
            LeanDetail al = new LeanDetail();
            al.TopLevel = false; // 在最上層
            al.FormBorderStyle = FormBorderStyle.None; // 清除邊框
            splitContainer1.Panel2.Controls.Add(al); // 工作表加視窗

            al.Width = splitContainer1.Panel2.Width;
            al.Height = splitContainer1.Panel2.Height;
            al.Show(); // 視窗顯示
        }

        #endregion

        #region LEAN統計

        private void InWare()
        {
            splitContainer1.Panel2.Controls.Clear(); // 清空工作表介面                                         
            InWarehouse al = new InWarehouse();
            al.TopLevel = false; // 在最上層
            al.FormBorderStyle = FormBorderStyle.None; // 清除邊框
            splitContainer1.Panel2.Controls.Add(al); // 工作表加視窗
            al.myDate2 = myDate;
            al.Width = splitContainer1.Panel2.Width;
            al.Height = splitContainer1.Panel2.Height;
            al.Show(); // 視窗顯示
        }

        #endregion

        #region 外箱位置

        private void CTNPOS()
        {
            splitContainer1.Panel2.Controls.Clear(); // 清空工作表介面                                         
            SepScan al = new SepScan();
            al.TopLevel = false; // 在最上層
            al.FormBorderStyle = FormBorderStyle.None; // 清除邊框
            splitContainer1.Panel2.Controls.Add(al); // 工作表加視窗
            //al.myDate2 = myDate;
            al.Width = splitContainer1.Panel2.Width;
            al.Height = splitContainer1.Panel2.Height;
            al.Show(); // 視窗顯示
        }

        #endregion

        #region 總計

        private void LineLoad()
        {
            try
            {
                GC.Collect();

                LineDaily Form = new LineDaily();
                Form.Width = 1300;
                Form.Height = 650;
                //al.TopLevel = true;
                Form.ShowDialog();
                //DialogResult dialogResult = al.ShowDialog(); // 視窗顯示

            }
            catch (NullReferenceException)
            {
                
            }
        }

        #endregion

        #region 庫存

        private void StockLoad()
        {
            try
            {
                //GC.Collect();
                LineChart Form = new LineChart();
                Form.Width = 1300;
                Form.Height = 650;
                //al.TopLevel = true;
                Form.ShowDialog();
                //DialogResult dialogResult = al.ShowDialog(); // 視窗顯示

            }
            catch (NullReferenceException)
            {

            }
        }

        #endregion


        #endregion



        private void TvWarehouse_AfterSelect(object sender, TreeViewEventArgs e)
        {
            
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Mainpage2_Load(object sender, EventArgs e)
        {

        }

        private void TvWarehouse_AfterSelect_1(object sender, TreeViewEventArgs e)
        {
            modifySL = Program.Modifytype.modify;
            Console.WriteLine(modifySL);
            if (modifySL == "0")
            {
                //樹狀節點選擇項目
                string tvMenuSelect = e.Node.Name;
                switch (tvMenuSelect)  
                {
                    //case "Node1_1":
                    //    WHBasicInformationWarehouse();
                    //    Mainpage.nodes = "Node1_1";
                    //    node = "Node1_1";
                    //    break;
                    //case "Node1_2":
                    //    WHBasicInformationStorageLocation();
                    //    node = "Node1_2";
                    //    Mainpage.nodes = "Node1_2";
                    //    break;
                    //case "Node1_3":
                    //    WHBasicInformationPallet();
                    //    node = "Node1_3";
                    //    Mainpage.nodes = "Node1_3";
                    //    break;
                    case "Node2_1":
                        WHScanInFinishedGoodsScanIn();
                        node = "Node2_1";
                        Mainpage.nodes = "Node2_1";
                        break;
                    //case "Node2_2_1":
                    //    WHScanInFinishedGoodsStorageAssignPallet();
                    //    node = "Node2_2_1";
                    //    Mainpage.nodes = "Node2_2_1";
                    //    break;
                    //case "Node2_2_2":
                    //    WHScanInFinishedGoodsAssignStoreLocation();
                    //    node = "Node2_2_2";
                    //    Mainpage.nodes = "Node2_2_2";
                    //    break;
                    //case "Node2_3":
                    //    InWare();
                    //    node = "Node2_3";
                    //    Mainpage.nodes = "Node2_3";
                    //    break;
                    //case "Node3_1":
                    //    WHScanOutFinishedGoods();
                    //    node = "Node3_1";
                    //    Mainpage.nodes = "Node3_1";
                    //    break;
                    //case "Node3_2":
                    //    CTNPOS();
                    //    node = "Node3_2";
                    //    Mainpage.nodes = "Node3_2";
                    //    break;
                    //case "Node4_1":
                    //    WHIInspectionProcess();
                    //    node = "Node4_1";
                    //    Mainpage.nodes = "Node4_1";
                    //    break;
                    //case "Node4_2":
                    //    WHIInspectionFix();
                    //    node = "Node4_2";
                    //    Mainpage.nodes = "Node4_2";
                    //    break;
                    case "Node5_1":
                        WHReportOrderStatusInWarehouse();
                        node = "Node5_1";
                        Mainpage.nodes = "Node5_1";
                        break;
                    case "Node5_2":
                        WHReportOrderStorageInquiry();
                        node = "Node5_2";
                        Mainpage.nodes = "Node5_2";
                        break;
                    case "Node5_3":
                        FinishedOrder();
                        node = "Node5_3";
                        Mainpage.nodes = "Node5_3";
                        break;
                    case "Node5_4":
                        InWarehouse();
                        node = "Node5_4";
                        Mainpage.nodes = "Node5_4";
                        break;
                    case "Node5_5":
                        WAll();
                        node = "Node5_5";
                        Mainpage.nodes = "Node5_5";
                        break;
                    case "Node5_6":
                        CarDetail();
                        node = "Node5_6";
                        Mainpage.nodes = "Node5_6";
                        break;
                    case "Node5_7":
                        LeanLoad();
                        node = "Node5_7";
                        Mainpage.nodes = "Node5_7";
                        break;
                    case "Node6_1":
                        WHBillboardOrderStatus();
                        node = "Node6_1";
                        Mainpage.nodes = "Node6_1";
                        break;
                    case "Node6_2":
                        LineLoad();
                        node = "Node6_2";
                        Mainpage.nodes = "Node6_2";
                        break;
                    case "Node6_3":
                        StockLoad();
                        node = "Node6_3";
                        Mainpage.nodes = "Node6_3";
                        break;
                }
            }
            else
            {
                MessageBox.Show("SAVE OR CANCEL FIRST");
            }
        }
    }
}
