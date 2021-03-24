using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TEST
{
    public partial class WHSO : Form
    {

        #region 建構函式

        public WHSO()
        {
            InitializeComponent();
        }

        #endregion

        #region 離開事件

        private void TsbExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        #endregion

        #region 變數

        DataSet ds = new DataSet();
        DataSet ds2 = new DataSet();
        DataSet ds3 = new DataSet();
        public string USERID;
        public string cc = "3";
        public string TakeID = "";

        #endregion

        #region 畫面載入

        private void WHSO_Load(object sender, EventArgs e)
        {
            USERID = Program.User.userID;
            rb03.Checked = true;
            //SearchData();
        }

        #endregion

        #region 讀取Datagridview

        private void SearchData()
        {
           
                ds = new DataSet();
                DataBinding dbConn = new DataBinding();
                try
                {
                    string sql = string.Format("select top 500 a.DDBH as '訂單編號', b.Qty as '數量', a.KHPO as 'CTS', a.Article as 'Article', a.XieXing as '鞋型' from DDZL  as a left outer join (select DDBH,SUM(QTY) as QTY from SCLH group by DDBH) as b on a.DDBH = b.DDBH order by USERDATE DESC ");
                    SqlDataAdapter adapter = new SqlDataAdapter(sql, dbConn.connection);
                    adapter.Fill(ds, "訂單表");
                    this.dgvDDBH.DataSource = this.ds.Tables[0];

                }
                catch (Exception)
                {
                    MessageBox.Show("訂單載入失敗!", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                
                }
            Outer();



        }

        #endregion

        #region 讀取外箱

        private void Outer()
        {
            if (tbOrder.TextLength > 0)
            {
                ds2 = new DataSet();
                DataBinding dbConn2 = new DataBinding();
                try
                {
                    string sql = string.Format("select distinct a.CARTONBAR as '外箱號', a.Qty as '數量', c.FSA_NO as '貨架', c.FSA_Locate as '儲位' from YWCP as a left outer join (select distinct * from PalletDetail) as b on a.CARTONBAR = b.CARTONBAR left outer join (select distinct * from FStorageAreaDetail) as c on b.Pallet_NO = c.Pallet_NO where (a.DDBH = '{0}' and a.SB = 1) ", tbOrder.Text, tbOrder.Text);                 


                  
                    SqlDataAdapter adapter = new SqlDataAdapter(sql, dbConn2.connection);
                    adapter.Fill(ds2, "儲位表");
                    this.dgvFSA.DataSource = this.ds2.Tables[0];
                }
                catch (Exception)
                {
                    MessageBox.Show("外箱載入失敗! Dang tai du lieu khong thanh cong", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                   
                }
            }
            else
            {

            }
        }

        #endregion

        #region 選擇gridview

        private void DgvDDBH_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                tbOrder.Text = dgvDDBH.CurrentRow.Cells[0].Value.ToString();
                //Outer();

                int c = 0;
                c = dgvFSA.Rows.Count;
                Console.WriteLine(c);


                for (int d = 0; d < c; d++)
                {
                    dgvFSA.Rows.RemoveAt(0);
                }
                

                if (rb04.Checked == true)
                {
                    DataBinding dbConn2 = new DataBinding();
                    string sql1 = string.Format("select distinct a.CARTONBAR as '外箱號', a.Qty as '數量', c.FSA_NO as '貨架', c.FSA_Locate as '儲位' from YWCP as a left outer join (select distinct * from PalletDetail) as b on a.CARTONBAR = b.CARTONBAR left outer join (select * from FStorageAreaDetail) as c on b.Pallet_NO = c.Pallet_NO where (a.DDBH = '{0}' and a.SB = 4) ", tbOrder.Text, tbOrder.Text);
                    SqlDataAdapter adapter1 = new SqlDataAdapter(sql1, dbConn2.connection);
                    adapter1.Fill(ds2, "儲位表");
                    this.dgvFSA.DataSource = this.ds2.Tables[0];
                }
                else
                {
                     DataBinding dbConn2 = new DataBinding();
                      string sql1 = string.Format("select distinct a.CARTONBAR as '外箱號', a.Qty as '數量', c.FSA_NO as '貨架', c.FSA_Locate as '儲位' from YWCP as a left outer join (select distinct * from PalletDetail) as b on a.CARTONBAR = b.CARTONBAR left outer join (select * from FStorageAreaDetail) as c on b.Pallet_NO = c.Pallet_NO where (a.DDBH = '{0}' and a.SB = 1) ", tbOrder.Text, tbOrder.Text);
                     SqlDataAdapter adapter1 = new SqlDataAdapter(sql1, dbConn2.connection);
                     adapter1.Fill(ds2, "儲位表");
                     this.dgvFSA.DataSource = this.ds2.Tables[0];
                }
               

                int W = 0;
                W = dgvFSA.Width;
                dgvFSA.Columns[0].Width = W / 2;
                dgvFSA.Columns[1].Width = W / 6;
                dgvFSA.Columns[2].Width = W / 6;
                dgvFSA.Columns[2].Width = W / 6;


            }
            catch (Exception) { }
        }

        #endregion

        

        #region 清空按鈕

        private void TspClear_Click(object sender, EventArgs e)
        {
            tbOrder.Text = "";

            int c = 0;
            c = dgvFSA.Rows.Count;
            Console.WriteLine(c);


            for (int d = 0; d < c; d++)
            {
                dgvFSA.Rows.RemoveAt(0);
            }
            c -= 1;

            int f = 0;
            f = dgvDDBH.Rows.Count;
           


            for (int d = 0; d < f; d++)
            {
                dgvDDBH.Rows.RemoveAt(0);
            }
            f -= 1;

        }

        #endregion

        #region 查詢按鈕

        private void TsbQuery_Click(object sender, EventArgs e)
        {
            search();
        }


        #endregion

        #region 查詢方法

        private void search()
        {
            //ds = new DataSet();
            DataBinding dbConn = new DataBinding();
            DataBinding dbConn2 = new DataBinding();
            try
            {                
                string sql = string.Format("select  c.YSBH as '訂單編號', b.Qty as '數量', a.KHPO as 'CTS', a.Article as 'Article', a.XieXing as '鞋型' from ywdd  as c left join ddzl a on a.ddbh = c.DDBH left outer join (select DDBH, SUM(QTY) as QTY from SCLH group by DDBH) as b on  c.YSBH = b.DDBH where c.YSBH = '{0}'", tbOrder.Text);
                SqlDataAdapter adapter = new SqlDataAdapter(sql, dbConn.connection);
                adapter.Fill(ds, "訂單表");
                this.dgvDDBH.DataSource = this.ds.Tables[0];

                int X = 0;
                X = dgvDDBH.Width;
                dgvDDBH.Columns[0].Width = X / 4;



                if (rb04.Checked == true)
                {
                    Console.WriteLine("------------");
                    Console.WriteLine("3");

                    //DataBinding dbConn2 = new DataBinding();
                    string sql1 = string.Format("select distinct a.CARTONBAR as '外箱號', a.Qty as '數量', c.FSA_NO as '貨架', c.FSA_Locate as '儲位' from YWCP as a left outer join (select distinct * from PalletDetail) as b on a.CARTONBAR = b.CARTONBAR left outer join (select * from FStorageAreaDetail) as c on b.Pallet_NO = c.Pallet_NO where (a.DDBH like '{0}%' and a.SB = 4) ", tbOrder.Text);
                    
                    Console.WriteLine(sql1);

                    SqlDataAdapter adapter1 = new SqlDataAdapter(sql1, dbConn2.connection);
                    adapter1.Fill(ds3, "儲位表");
                    this.dgvFSA.DataSource = this.ds3.Tables[0];
                }
                else
                {
                    Console.WriteLine("------------");
                    Console.WriteLine("1");
                    //DataBinding dbConn2 = new DataBinding();
                    string sql1 = string.Format("select distinct a.CARTONBAR as '外箱號', a.Qty as '數量', c.FSA_NO as '貨架', c.FSA_Locate as '儲位' from YWCP as a left outer join (select distinct * from PalletDetail) as b on a.CARTONBAR = b.CARTONBAR left outer join (select * from FStorageAreaDetail) as c on b.Pallet_NO = c.Pallet_NO where (a.DDBH = '{0}' and a.SB = 1) ", tbOrder.Text);
                    SqlDataAdapter adapter1 = new SqlDataAdapter(sql1, dbConn2.connection);

                    Console.WriteLine(sql1);

                    adapter1.Fill(ds3, "儲位表");
                    this.dgvFSA.DataSource = this.ds3.Tables[0];
                }


                int W = 0;
                W = dgvFSA.Width;
                dgvFSA.Columns[0].Width = W / 2;
                dgvFSA.Columns[1].Width = W / 6;
                dgvFSA.Columns[2].Width = W / 6;
                dgvFSA.Columns[2].Width = W / 6;



            }
            catch (Exception)
            {
                MessageBox.Show("訂單載入失敗! Dang tai du lieu khong thanh cong", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                
            }
        }

        #endregion


        private void TbOrder_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)//如果输入的是回车键
            {
                search();
            }
        }

        #region 進入掃描

        private void scanout()
        {
            try
            {

                if (tbOrder.TextLength > 0)
                {

                    if (rb01.Checked == true) //出貨
                    {
                        WHSOFinishedGoods2 appw = new WHSOFinishedGoods2();
                        appw.DDBH = tbOrder.Text;
                        appw.ScanClass = cc;
                        appw.Height = 600;
                        appw.Width = 1250;
                        appw.lbDDBH.Text = tbOrder.Text;
                        appw.ShowDialog();
                        
                    }
                    else
                    {
                    tbOrder.Text = dgvDDBH.CurrentRow.Cells[0].Value.ToString();
                    IDCHECK ID = new IDCHECK();
                    ID.DDBH = tbOrder.Text;
                    ID.SCCLASS = cc;
                    ID.ShowDialog();
                    }
                    
                    


                }
                else
                {
                    MessageBox.Show("請輸入訂單號! Nhap so thu tu", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
            }
            catch (Exception)
            {
                MessageBox.Show("訂單載入錯誤 Dang tai loi du lieu", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

        private void DgvDDBH_DoubleClick(object sender, EventArgs e)
        {
            if (rb01.Checked == true)
            {
                cc = "3";
            }
            else if (rb02.Checked == true)
            {
                cc = "4";
            }
            else if (rb03.Checked == true)
            {
                cc = "2";
            }
            else if (rb04.Checked == true)
            {
                cc = "5";
            }

            scanout();
            //清空A表
            int a = 0;
            a = dgvDDBH.Rows.Count;
            for (int d = 0; d < a; d++)
            {
                dgvDDBH.Rows.RemoveAt(0);
            }

            //清空B表
            int c = 0;
            c = dgvFSA.Rows.Count;
            Console.WriteLine(c);
            for (int d = 0; d < c; d++)
            {
                dgvFSA.Rows.RemoveAt(0);
            }



            tbOrder.Text = "";


        }



        private void Button1_Click(object sender, EventArgs e)
        {
            //清空A表
            int a = 0;
            a = dgvDDBH.Rows.Count;  
            for (int d = 0; d < a; d++)
            {
                dgvDDBH.Rows.RemoveAt(0);
            }
            
            //清空B表
            int c = 0;
            c = dgvFSA.Rows.Count;
            Console.WriteLine(c);
            for (int d = 0; d < c; d++)
            {
                dgvFSA.Rows.RemoveAt(0);
            }  

            search();

            if (rb01.Checked == true)
            {
                cc = "3";
            }
            else if (rb02.Checked == true)
            {
                cc = "4";
            }
            else if (rb03.Checked == true)
            {
                cc = "2";
            }
            else if (rb04.Checked == true)
            {
                cc = "5";
            }


        }

        private void CbClass_SelectedIndexChanged(object sender, EventArgs e)
        {
            //切換選擇
            if (tbOrder.Text != "")
            {
                //清空A表
                int a = 0;
                a = dgvDDBH.Rows.Count;
                for (int d = 0; d < a; d++)
                {
                    dgvDDBH.Rows.RemoveAt(0);
                }

                //清空B表
                int c = 0;
                c = dgvFSA.Rows.Count;   

                for (int d = 0; d < c; d++)
                {
                    dgvFSA.Rows.RemoveAt(0);
                }


                if (rb01.Checked == true)
                {
                    cc = "3";
                }
                else if (rb02.Checked == true)
                {
                    cc = "4";
                }
                else if (rb03.Checked == true)
                {
                    cc = "2";
                }
                else if (rb04.Checked == true)
                {
                    cc = "5";
                }
                Console.WriteLine(cc);

                search();

                
            }
            else
            {

            }
        }

        private void Rb01_MouseUp(object sender, MouseEventArgs e)
        {
            tbOrder.Focus();
        }

        private void Rb02_MouseUp(object sender, MouseEventArgs e)
        {
            tbOrder.Focus();
        }

        private void Rb03_MouseUp(object sender, MouseEventArgs e)
        {
            tbOrder.Focus();
        }

        private void Rb04_MouseUp(object sender, MouseEventArgs e)
        {
            tbOrder.Focus();
        }

        private void WHSO_Shown(object sender, EventArgs e)
        {
            tbOrder.Focus();
        }
    }
}
