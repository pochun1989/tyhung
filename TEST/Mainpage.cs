using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TEST
{
    public partial class Mainpage : Form
    {
        #region 變數

        Mainpage2 a = new Mainpage2();
        public static string nodes = "";
        DateTime myDate = DateTime.Now;
        public string modifySL = "0";

        #endregion


        public Mainpage()
        {
            InitializeComponent();

            int W = System.Windows.Forms.Screen.PrimaryScreen.Bounds.Width;
            int H = System.Windows.Forms.Screen.PrimaryScreen.Bounds.Height;

            this.Width = W;
            this.Height = H;

            //this.WindowState = FormWindowState.Maximized;
        }


        private void Mainpage_Load(object sender, EventArgs e)
        {
            try
            {
                panel1.Controls.Clear(); // 清空工作表介面                                         
                
                a.TopLevel = false; // 在最上層
                a.FormBorderStyle = FormBorderStyle.None; // 清除邊框
                panel1.Controls.Add(a); // 工作表加視窗
                a.myDate = myDate.ToString("yyyy-MM-dd HH:mm:ss");
                a.Width = panel1.Width;
                a.Height = panel1.Height;

                //al.WindowState = FormWindowState.Maximized;
                a.Show(); // 視窗顯示
            }
            catch (Exception)
            {
            }
        }

        private void BtnMunuSwitch_Click(object sender, EventArgs e)
        {


            
        }


        

        private void BtnClose_Click(object sender, EventArgs e)
        {
            
        }

        private void BtnMunuSwitch_Click_1(object sender, EventArgs e)
        {
            modifySL = Program.Modifytype.modify;
            Console.WriteLine(modifySL);
            if (modifySL == "0")
            {
                if (a.tvWarehouse.Visible == true)
                {
                    //int a, b = 0;
                    a.splitContainer1.Panel1Collapsed = true;

                    a.tvWarehouse.Visible = false;


                    if (nodes == "Node1_1")
                    {
                        a.splitContainer1.Panel2.Controls.Clear(); // 清空工作表介面                                         
                        WHBIWarehouse al = new WHBIWarehouse();
                        al.TopLevel = false; // 在最上層
                        al.FormBorderStyle = FormBorderStyle.None; // 清除邊框
                        a.splitContainer1.Panel2.Controls.Add(al); // 工作表加視窗
                        al.Width = panel1.Width;
                        al.Height = panel1.Height;
                        al.Show(); // 視窗顯示

                    }
                    else if (nodes == "Node1_2")
                    {
                        a.splitContainer1.Panel2.Controls.Clear(); // 清空工作表介面                                         
                        WHBIStorageLocation al = new WHBIStorageLocation();
                        al.TopLevel = false; // 在最上層
                        al.FormBorderStyle = FormBorderStyle.None; // 清除邊框
                        a.splitContainer1.Panel2.Controls.Add(al); // 工作表加視窗
                        al.Width = panel1.Width;
                        al.Height = panel1.Height;
                        al.Show(); // 視窗顯示
                    }
                    else if (nodes == "Node1_3")
                    {
                        a.splitContainer1.Panel2.Controls.Clear(); // 清空工作表介面                                         
                        WHBIPallet al = new WHBIPallet();
                        al.TopLevel = false; // 在最上層
                        al.FormBorderStyle = FormBorderStyle.None; // 清除邊框
                        a.splitContainer1.Panel2.Controls.Add(al); // 工作表加視窗
                        al.Width = panel1.Width;
                        al.Height = panel1.Height;
                        al.Show(); // 視窗顯示
                    }
                    else if (nodes == "Node2_1")
                    {
                        a.splitContainer1.Panel2.Controls.Clear(); // 清空工作表介面                                         
                        WHSFGScanin2 al = new WHSFGScanin2();
                        al.myDate2 = myDate.ToString("yyyy-MM-dd HH:mm:ss");
                        al.TopLevel = false; // 在最上層
                        al.FormBorderStyle = FormBorderStyle.None; // 清除邊框
                        a.splitContainer1.Panel2.Controls.Add(al); // 工作表加視窗
                        al.Width = panel1.Width;
                        al.Height = panel1.Height;
                        al.Show(); // 視窗顯示
                    }
                    else if (nodes == "Node2_2_1")
                    {
                        a.splitContainer1.Panel2.Controls.Clear(); // 清空工作表介面                                         
                        WHSFGStorageAssignPallet2 al = new WHSFGStorageAssignPallet2();
                        al.TopLevel = false; // 在最上層
                        al.FormBorderStyle = FormBorderStyle.None; // 清除邊框
                        a.splitContainer1.Panel2.Controls.Add(al); // 工作表加視窗
                        al.Width = panel1.Width;
                        al.Height = panel1.Height;
                        al.Show(); // 視窗顯示
                    }
                    else if (nodes == "Node2_2_2")
                    {
                        a.splitContainer1.Panel2.Controls.Clear(); // 清空工作表介面                                         
                        WHSFGAssignStoreLocation al = new WHSFGAssignStoreLocation();
                        al.TopLevel = false; // 在最上層
                        al.FormBorderStyle = FormBorderStyle.None; // 清除邊框
                        a.splitContainer1.Panel2.Controls.Add(al); // 工作表加視窗
                        al.Width = panel1.Width;
                        al.Height = panel1.Height;
                        al.Show(); // 視窗顯示
                    }
                    else if (nodes == "Node2_3")
                    {
                        a.splitContainer1.Panel2.Controls.Clear(); // 清空工作表介面                                  

                        InWarehouse al = new InWarehouse();
                        al.TopLevel = false; // 在最上層
                        al.FormBorderStyle = FormBorderStyle.None; // 清除邊框
                        a.splitContainer1.Panel2.Controls.Add(al); // 工作表加視窗
                        al.Width = panel1.Width;
                        al.Height = panel1.Height;
                        al.myDate2 = myDate.ToString("yyyy-MM-dd HH:mm:ss");
                        al.Show(); // 視窗顯示
                    }
                    else if (nodes == "Node3_1")
                    {
                        a.splitContainer1.Panel2.Controls.Clear(); // 清空工作表介面                                         
                        WHSO al = new WHSO();
                        al.TopLevel = false; // 在最上層
                        al.FormBorderStyle = FormBorderStyle.None; // 清除邊框
                        a.splitContainer1.Panel2.Controls.Add(al); // 工作表加視窗
                        al.Width = panel1.Width;
                        al.Height = panel1.Height;
                        al.Show(); // 視窗顯示
                    }
                    else if (nodes == "Node4_1")
                    {
                        a.splitContainer1.Panel2.Controls.Clear(); // 清空工作表介面                                         
                        WHInsProcess al = new WHInsProcess();
                        al.TopLevel = false; // 在最上層
                        al.FormBorderStyle = FormBorderStyle.None; // 清除邊框
                        a.splitContainer1.Panel2.Controls.Add(al); // 工作表加視窗
                        al.Width = panel1.Width;
                        al.Height = panel1.Height;
                        al.Show(); // 視窗顯示
                    }
                    else if (nodes == "Node4_2")
                    {
                        a.splitContainer1.Panel2.Controls.Clear(); // 清空工作表介面                                         
                        InspectionFix al = new InspectionFix();
                        al.TopLevel = false; // 在最上層
                        al.FormBorderStyle = FormBorderStyle.None; // 清除邊框
                        a.splitContainer1.Panel2.Controls.Add(al); // 工作表加視窗
                        al.Width = panel1.Width;
                        al.Height = panel1.Height;
                        al.Show(); // 視窗顯示
                    }
                    else if (nodes == "Node5_1")
                    {
                        a.splitContainer1.Panel2.Controls.Clear(); // 清空工作表介面                                         
                        WHROStatusInWarehouse al = new WHROStatusInWarehouse();
                        al.TopLevel = false; // 在最上層
                        al.FormBorderStyle = FormBorderStyle.None; // 清除邊框
                        a.splitContainer1.Panel2.Controls.Add(al); // 工作表加視窗
                        al.Width = panel1.Width;
                        al.Height = panel1.Height;
                        al.Show(); // 視窗顯示
                    }
                    else if (nodes == "Node5_2")
                    {
                        a.splitContainer1.Panel2.Controls.Clear(); // 清空工作表介面                                         
                        WHROStorageInquiry al = new WHROStorageInquiry();
                        al.TopLevel = false; // 在最上層
                        al.FormBorderStyle = FormBorderStyle.None; // 清除邊框
                        a.splitContainer1.Panel2.Controls.Add(al); // 工作表加視窗
                        al.Width = panel1.Width;
                        al.Height = panel1.Height;
                        al.Show(); // 視窗顯示
                    }
                    else if (nodes == "Node5_3")
                    {
                        a.splitContainer1.Panel2.Controls.Clear(); // 清空工作表介面                                         
                        ComOrder al = new ComOrder();
                        al.TopLevel = false; // 在最上層
                        al.FormBorderStyle = FormBorderStyle.None; // 清除邊框
                        a.splitContainer1.Panel2.Controls.Add(al); // 工作表加視窗
                        al.Width = panel1.Width;
                        al.Height = panel1.Height;
                        al.Show(); // 視窗顯示
                    }
                    else if (nodes == "Node5_4")
                    {
                        a.splitContainer1.Panel2.Controls.Clear(); // 清空工作表介面                                         
                        WHStorageNow al = new WHStorageNow();
                        al.TopLevel = false; // 在最上層
                        al.FormBorderStyle = FormBorderStyle.None; // 清除邊框
                        a.splitContainer1.Panel2.Controls.Add(al); // 工作表加視窗
                        al.Width = panel1.Width;
                        al.Height = panel1.Height;
                        al.Show(); // 視窗顯示
                    }
                    else if (nodes == "Node5_5")
                    {
                        a.splitContainer1.Panel2.Controls.Clear(); // 清空工作表介面                                         
                        WHDayReport al = new WHDayReport();
                        al.TopLevel = false; // 在最上層
                        al.FormBorderStyle = FormBorderStyle.None; // 清除邊框
                        a.splitContainer1.Panel2.Controls.Add(al); // 工作表加視窗
                        al.Width = panel1.Width;
                        al.Height = panel1.Height;
                        al.Show(); // 視窗顯示
                    }
                    else if (nodes == "Node5_6")
                    {
                        a.splitContainer1.Panel2.Controls.Clear(); // 清空工作表介面                                         
                        CartonDetail al = new CartonDetail();
                        al.TopLevel = false; // 在最上層
                        al.FormBorderStyle = FormBorderStyle.None; // 清除邊框
                        a.splitContainer1.Panel2.Controls.Add(al); // 工作表加視窗
                        al.Width = panel1.Width;
                        al.Height = panel1.Height;
                        al.Show(); // 視窗顯示
                    }
                    else if (nodes == "Node6_1")
                    {
                        a.splitContainer1.Panel2.Controls.Clear(); // 清空工作表介面                                         
                        WHBillboardOrderStatus al = new WHBillboardOrderStatus();
                        al.TopLevel = false; // 在最上層
                        al.FormBorderStyle = FormBorderStyle.None; // 清除邊框
                        a.splitContainer1.Panel2.Controls.Add(al); // 工作表加視窗
                        al.Width = panel1.Width;
                        al.Height = panel1.Height;
                        al.Show(); // 視窗顯示
                    }

                }
                else
                {
                    a.splitContainer1.Panel1Collapsed = false;

                    a.tvWarehouse.Visible = true;

                    if (nodes == "Node1_1")
                    {
                        a.splitContainer1.Panel2.Controls.Clear(); // 清空工作表介面                                         
                        WHBIWarehouse al = new WHBIWarehouse();
                        al.TopLevel = false; // 在最上層
                        al.FormBorderStyle = FormBorderStyle.None; // 清除邊框
                        a.splitContainer1.Panel2.Controls.Add(al); // 工作表加視窗
                        al.Width = a.splitContainer1.Panel2.Width;
                        al.Height = a.splitContainer1.Panel2.Height;
                        al.Show(); // 視窗顯示

                    }
                    else if (nodes == "Node1_2")
                    {
                        a.splitContainer1.Panel2.Controls.Clear(); // 清空工作表介面                                         
                        WHBIStorageLocation al = new WHBIStorageLocation();
                        al.TopLevel = false; // 在最上層
                        al.FormBorderStyle = FormBorderStyle.None; // 清除邊框
                        a.splitContainer1.Panel2.Controls.Add(al); // 工作表加視窗
                        al.Width = a.splitContainer1.Panel2.Width;
                        al.Height = a.splitContainer1.Panel2.Height;
                        al.Show(); // 視窗顯示
                    }
                    else if (nodes == "Node1_3")
                    {
                        a.splitContainer1.Panel2.Controls.Clear(); // 清空工作表介面                                         
                        WHBIPallet al = new WHBIPallet();
                        al.TopLevel = false; // 在最上層
                        al.FormBorderStyle = FormBorderStyle.None; // 清除邊框
                        a.splitContainer1.Panel2.Controls.Add(al); // 工作表加視窗
                        al.Width = a.splitContainer1.Panel2.Width;
                        al.Height = a.splitContainer1.Panel2.Height;
                        al.Show(); // 視窗顯示
                    }
                    else if (nodes == "Node2_1")
                    {
                        a.splitContainer1.Panel2.Controls.Clear(); // 清空工作表介面                                         
                        WHSFGScanin2 al = new WHSFGScanin2();
                        al.myDate2 = myDate.ToString("yyyy-MM-dd HH:mm:ss");
                        al.TopLevel = false; // 在最上層
                        al.FormBorderStyle = FormBorderStyle.None; // 清除邊框
                        a.splitContainer1.Panel2.Controls.Add(al); // 工作表加視窗
                        al.Width = a.splitContainer1.Panel2.Width;
                        al.Height = a.splitContainer1.Panel2.Height;
                        al.Show(); // 視窗顯示
                    }
                    else if (nodes == "Node2_2_1")
                    {
                        a.splitContainer1.Panel2.Controls.Clear(); // 清空工作表介面                                         
                        WHSFGStorageAssignPallet2 al = new WHSFGStorageAssignPallet2();
                        al.TopLevel = false; // 在最上層
                        al.FormBorderStyle = FormBorderStyle.None; // 清除邊框
                        a.splitContainer1.Panel2.Controls.Add(al); // 工作表加視窗
                        al.Width = a.splitContainer1.Panel2.Width;
                        al.Height = a.splitContainer1.Panel2.Height;
                        al.Show(); // 視窗顯示
                    }
                    else if (nodes == "Node2_2_2")
                    {
                        a.splitContainer1.Panel2.Controls.Clear(); // 清空工作表介面                                         
                        WHSFGAssignStoreLocation al = new WHSFGAssignStoreLocation();
                        al.TopLevel = false; // 在最上層
                        al.FormBorderStyle = FormBorderStyle.None; // 清除邊框
                        a.splitContainer1.Panel2.Controls.Add(al); // 工作表加視窗
                        al.Width = a.splitContainer1.Panel2.Width;
                        al.Height = a.splitContainer1.Panel2.Height;
                        al.Show(); // 視窗顯示
                    }
                    else if (nodes == "Node3_1")
                    {
                        a.splitContainer1.Panel2.Controls.Clear(); // 清空工作表介面                                         
                        WHSO al = new WHSO();
                        al.TopLevel = false; // 在最上層
                        al.FormBorderStyle = FormBorderStyle.None; // 清除邊框
                        a.splitContainer1.Panel2.Controls.Add(al); // 工作表加視窗
                        al.Width = a.splitContainer1.Panel2.Width;
                        al.Height = a.splitContainer1.Panel2.Height;
                        al.Show(); // 視窗顯示
                    }
                    else if (nodes == "Node4_1")
                    {
                        a.splitContainer1.Panel2.Controls.Clear(); // 清空工作表介面                                         
                        WHInsProcess al = new WHInsProcess();
                        al.TopLevel = false; // 在最上層
                        al.FormBorderStyle = FormBorderStyle.None; // 清除邊框
                        a.splitContainer1.Panel2.Controls.Add(al); // 工作表加視窗
                        al.Width = panel1.Width;
                        al.Height = panel1.Height;
                        al.Show(); // 視窗顯示
                    }
                    else if (nodes == "Node4_2")
                    {
                        a.splitContainer1.Panel2.Controls.Clear(); // 清空工作表介面                                         
                        InspectionFix al = new InspectionFix();
                        al.TopLevel = false; // 在最上層
                        al.FormBorderStyle = FormBorderStyle.None; // 清除邊框
                        a.splitContainer1.Panel2.Controls.Add(al); // 工作表加視窗
                        al.Width = panel1.Width;
                        al.Height = panel1.Height;
                        al.Show(); // 視窗顯示
                    }
                    else if (nodes == "Node5_1")
                    {
                        a.splitContainer1.Panel2.Controls.Clear(); // 清空工作表介面                                         
                        WHROStatusInWarehouse al = new WHROStatusInWarehouse();
                        al.TopLevel = false; // 在最上層
                        al.FormBorderStyle = FormBorderStyle.None; // 清除邊框
                        a.splitContainer1.Panel2.Controls.Add(al); // 工作表加視窗
                        al.Width = panel1.Width;
                        al.Height = panel1.Height;
                        al.Show(); // 視窗顯示
                    }
                    else if (nodes == "Node5_2")
                    {
                        a.splitContainer1.Panel2.Controls.Clear(); // 清空工作表介面                                         
                        WHROStorageInquiry al = new WHROStorageInquiry();
                        al.TopLevel = false; // 在最上層
                        al.FormBorderStyle = FormBorderStyle.None; // 清除邊框
                        a.splitContainer1.Panel2.Controls.Add(al); // 工作表加視窗
                        al.Width = panel1.Width;
                        al.Height = panel1.Height;
                        al.Show(); // 視窗顯示
                    }
                    else if (nodes == "Node5_3")
                    {
                        a.splitContainer1.Panel2.Controls.Clear(); // 清空工作表介面                                         
                        ComOrder al = new ComOrder();
                        al.TopLevel = false; // 在最上層
                        al.FormBorderStyle = FormBorderStyle.None; // 清除邊框
                        a.splitContainer1.Panel2.Controls.Add(al); // 工作表加視窗
                        al.Width = panel1.Width;
                        al.Height = panel1.Height;
                        al.Show(); // 視窗顯示
                    }
                    else if (nodes == "Node5_4")
                    {
                        a.splitContainer1.Panel2.Controls.Clear(); // 清空工作表介面                                         
                        WHStorageNow al = new WHStorageNow();
                        al.TopLevel = false; // 在最上層
                        al.FormBorderStyle = FormBorderStyle.None; // 清除邊框
                        a.splitContainer1.Panel2.Controls.Add(al); // 工作表加視窗
                        al.Width = panel1.Width;
                        al.Height = panel1.Height;
                        al.Show(); // 視窗顯示
                    }
                    else if (nodes == "Node5_5")
                    {
                        a.splitContainer1.Panel2.Controls.Clear(); // 清空工作表介面                                         
                        WHDayReport al = new WHDayReport();
                        al.TopLevel = false; // 在最上層
                        al.FormBorderStyle = FormBorderStyle.None; // 清除邊框
                        a.splitContainer1.Panel2.Controls.Add(al); // 工作表加視窗
                        al.Width = panel1.Width;
                        al.Height = panel1.Height;
                        al.Show(); // 視窗顯示
                    }
                    else if (nodes == "Node5_6")
                    {
                        a.splitContainer1.Panel2.Controls.Clear(); // 清空工作表介面                                         
                        CartonDetail al = new CartonDetail();
                        al.TopLevel = false; // 在最上層
                        al.FormBorderStyle = FormBorderStyle.None; // 清除邊框
                        a.splitContainer1.Panel2.Controls.Add(al); // 工作表加視窗
                        al.Width = panel1.Width;
                        al.Height = panel1.Height;
                        al.Show(); // 視窗顯示
                    }
                    else if (nodes == "Node6_1")
                    {
                        a.splitContainer1.Panel2.Controls.Clear(); // 清空工作表介面                                         
                        WHBillboardOrderStatus al = new WHBillboardOrderStatus();
                        al.TopLevel = false; // 在最上層
                        al.FormBorderStyle = FormBorderStyle.None; // 清除邊框
                        a.splitContainer1.Panel2.Controls.Add(al); // 工作表加視窗
                        al.Width = panel1.Width;
                        al.Height = panel1.Height;
                        al.Show(); // 視窗顯示
                    }

                }
            }
            else 
            {
                MessageBox.Show("SAVE OR CANCEL FIRST");
            }

        }

        private void BtnClose_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Label2_Click(object sender, EventArgs e)
        {
            update al = new update();            
           
            al.Show(); // 視窗顯示
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
