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
    public partial class WHDayReport : Form
    {
        #region 建構函式

        public WHDayReport()
        {
            InitializeComponent();
        }

        #endregion

        #region 變數

        DataSet ds = new DataSet(); // 儲存資料表容器    
        DataSet ds2 = new DataSet();
        DataSet dsDep = new DataSet();
        public string USERID;

        #endregion

        #region 畫面載入

        private void WHDayReport_Load(object sender, EventArgs e)
        {
            LoadKcbh();
            cbKCBH.SelectedIndex = 0;
            cbStyle.SelectedIndex = 0;

        }

        #endregion

        #region 方法



        #region KCBH

        private void LoadKcbh()
        {
              DataBinding dbconn = new DataBinding();
                string sql1 = "select * from KCZL where KCCLASS = '2'";
                SqlDataAdapter adapter1 = new SqlDataAdapter(sql1, dbconn.connection);
                adapter1.Fill(ds, "倉庫");
                this.cbKCBH.DataSource = ds.Tables[0];
                this.cbKCBH.ValueMember = "KCBH";
                this.cbKCBH.DisplayMember = "KCBH";

                cbKCBH.MaxDropDownItems = 8;
                cbKCBH.IntegralHeight = false;
            
        }

        #endregion

        #region 總表

        private void wtoday()
        {
            try
            {
                if (cbStyle.SelectedIndex == 0) //出貨
                {
                    if (tbOrder.Text != "")
                    {
                        ds = new DataSet();
                        DataBinding dbConn = new DataBinding();

                        string sql = string.Format("select Idate,sum(CTQTY) as CTQTY,sum(QTY) as QTY from (select CONVERT(varchar(12) ,INDATE, 112 ) as Idate,count(CARTONBAR) as CTQTY, SUM(QTY) as QTY  from YWCP where INDATE between '{0}' and DATEADD(DAY,1,'{1}') and KCBH = '{2}' and DDBH like '{3}%' group by INDATE ) as c group by Idate order by Idate desc", dtpFrom.Text, dtpTo.Text, cbKCBH.Text.Trim(), tbOrder.Text.Trim());

                        Console.WriteLine(sql);
                        SqlDataAdapter adapter = new SqlDataAdapter(sql, dbConn.connection);
                        adapter.SelectCommand.CommandTimeout = 900;
                        adapter.Fill(ds, "訂單表");
                        this.dgvDay.DataSource = this.ds.Tables[0];
                    }
                    else
                    {
                        ds = new DataSet();
                        DataBinding dbConn = new DataBinding();

                        string sql = string.Format("select Idate,sum(CTQTY) as CTQTY,sum(QTY) as QTY from (select CONVERT(varchar(12) ,INDATE, 112 ) as Idate,count(CARTONBAR) as CTQTY, SUM(QTY) as QTY  from YWCP where INDATE between '{0}' and DATEADD(DAY,1,'{1}') and KCBH = '{2}' group by INDATE ) as c group by Idate order by Idate desc", dtpFrom.Text, dtpTo.Text, cbKCBH.Text.Trim());

                        Console.WriteLine(sql);
                        SqlDataAdapter adapter = new SqlDataAdapter(sql, dbConn.connection);
                        adapter.SelectCommand.CommandTimeout = 900;
                        adapter.Fill(ds, "訂單表");
                        this.dgvDay.DataSource = this.ds.Tables[0];
                    }
                }
                else if (cbStyle.SelectedIndex == 1) //翻箱2
                {
                    if (tbOrder.Text != "")
                    {
                        ds = new DataSet();
                        DataBinding dbConn = new DataBinding();

                        string sql = string.Format("select Idate,sum(CTQTY) as CTQTY,sum(QTY) as QTY from (select CONVERT(varchar(12) ,OUTDATE, 112 ) as Idate,count(CARTONBAR) as CTQTY, SUM(QTY) as QTY  from YWCP where OUTDATE between '{0}' and DATEADD(DAY,1,'{1}') and DDBH like '{2}%' and KCBH = '{3}' group by OUTDATE ) as c group by Idate order by Idate desc", dtpFrom.Text, dtpTo.Text, tbOrder.Text.Trim(), cbKCBH.Text);

                        Console.WriteLine(sql);
                        SqlDataAdapter adapter = new SqlDataAdapter(sql, dbConn.connection);
                        adapter.SelectCommand.CommandTimeout = 900;
                        adapter.Fill(ds, "訂單表");
                        this.dgvDay.DataSource = this.ds.Tables[0];
                    }
                    else
                    {
                        ds = new DataSet();
                        DataBinding dbConn = new DataBinding();

                        string sql = string.Format("select Idate,sum(CTQTY) as CTQTY,sum(QTY) as QTY from (select CONVERT(varchar(12) ,OUTDATE, 112 ) as Idate,count(CARTONBAR) as CTQTY, SUM(QTY) as QTY  from YWCP where OUTDATE between '{0}' and DATEADD(DAY,1,'{1}') and KCBH = '{2}' group by OUTDATE ) as c group by Idate order by Idate desc", dtpFrom.Text, dtpTo.Text, cbKCBH.Text);

                        Console.WriteLine(sql);
                        SqlDataAdapter adapter = new SqlDataAdapter(sql, dbConn.connection);
                        adapter.SelectCommand.CommandTimeout = 900;
                        adapter.Fill(ds, "訂單表");
                        this.dgvDay.DataSource = this.ds.Tables[0];
                    }
                }
                else if (cbStyle.SelectedIndex == 2) //驗貨3
                {
                    if (tbOrder.Text != "")
                    {
                        ds = new DataSet();
                        DataBinding dbConn = new DataBinding();

                        string sql = string.Format("select Idate,sum(CTQTY) as CTQTY,sum(QTY) as QTY from (select CONVERT(varchar(12) ,INSPECTDATE, 112 ) as Idate,count(CARTONBAR) as CTQTY, SUM(QTY) as QTY  from YWCP where INSPECTDATE between '{0}' and DATEADD(DAY,1,'{1}') and KCBH = '{2}' and DDBH like '{3}%' group by INSPECTDATE ) as c group by Idate order by Idate desc", dtpFrom.Text, dtpTo.Text, cbKCBH.Text, tbOrder.Text.Trim());

                        Console.WriteLine(sql);
                        SqlDataAdapter adapter = new SqlDataAdapter(sql, dbConn.connection);
                        adapter.SelectCommand.CommandTimeout = 900;
                        adapter.Fill(ds, "訂單表");
                        this.dgvDay.DataSource = this.ds.Tables[0];
                    }
                    else
                    {
                        ds = new DataSet();
                        DataBinding dbConn = new DataBinding();

                        string sql = string.Format("select Idate,sum(CTQTY) as CTQTY,sum(QTY) as QTY from (select CONVERT(varchar(12) ,INSPECTDATE, 112 ) as Idate,count(CARTONBAR) as CTQTY, SUM(QTY) as QTY  from YWCP where INSPECTDATE between '{0}' and DATEADD(DAY,1,'{1}') and KCBH = '{2}' group by INSPECTDATE ) as c group by Idate order by Idate desc", dtpFrom.Text, dtpTo.Text, cbKCBH.Text);

                        Console.WriteLine(sql);
                        SqlDataAdapter adapter = new SqlDataAdapter(sql, dbConn.connection);
                        adapter.SelectCommand.CommandTimeout = 900;
                        adapter.Fill(ds, "訂單表");
                        this.dgvDay.DataSource = this.ds.Tables[0];
                    }
                }
            }
            catch (Exception)
            {

            }
        }

        #endregion

        #region 訂單

        private void order()
        {
            try
            {
                //if (checkBox1.Checked == true)
                //{
                    if (cbStyle.SelectedIndex == 0)
                    {
                        if (tbOrder.Text != "")
                        {
                            ds2 = new DataSet();
                            DataBinding dbConn = new DataBinding();

                            string sql = string.Format("select a.DDBH,a.Pairs,b.CTQTY,b.QTY from DDZL as a left join(select DDBH, count(CARTONBAR) as CTQTY, sum(Qty) as QTY, KCBH from YWCP where INDATE between DATEADD(DAY,0,'{0}') and DATEADD(DAY, 1,'{1}') and DDBH = '{2}' and SB = 1  group by DDBH,KCBH) as b on a.DDBH = b.DDBH where QTY > 0 and KCBH = '{3}'", dgvDay.CurrentRow.Cells[0].Value.ToString(), dgvDay.CurrentRow.Cells[0].Value.ToString(), tbOrder.Text.Trim(), cbKCBH.Text.Trim());

                            Console.WriteLine(sql);
                            SqlDataAdapter adapter = new SqlDataAdapter(sql, dbConn.connection);
                            adapter.SelectCommand.CommandTimeout = 900;
                            adapter.Fill(ds2, "訂單表");
                            this.dgvDetail.DataSource = this.ds2.Tables[0];
                        }
                        else
                        {
                            ds2 = new DataSet();
                            DataBinding dbConn = new DataBinding();

                            string sql = string.Format("select a.DDBH,a.Pairs,b.CTQTY,b.QTY from DDZL as a left join(select DDBH, count(CARTONBAR) as CTQTY, sum(Qty) as QTY, KCBH from YWCP where INDATE between DATEADD(DAY,0,'{0}') and DATEADD(DAY, 1,'{1}')  and SB = 1  group by DDBH,KCBH) as b on a.DDBH = b.DDBH where QTY > 0 and KCBH = '{2}' ", dgvDay.CurrentRow.Cells[0].Value.ToString(), dgvDay.CurrentRow.Cells[0].Value.ToString(), cbKCBH.Text);

                            Console.WriteLine(sql);
                            SqlDataAdapter adapter = new SqlDataAdapter(sql, dbConn.connection);
                            adapter.SelectCommand.CommandTimeout = 900;
                            adapter.Fill(ds2, "訂單表");
                            this.dgvDetail.DataSource = this.ds2.Tables[0];
                        }
                    }
                    else if (cbStyle.SelectedIndex == 1)
                    {
                        if (tbOrder.Text != "")
                        {
                            ds2 = new DataSet();
                            DataBinding dbConn = new DataBinding();

                            string sql = string.Format("select a.DDBH,a.Pairs,b.CTQTY,b.QTY from DDZL as a left join(select DDBH, count(CARTONBAR) as CTQTY, sum(Qty) as QTY, KCBH from YWCP where OUTDATE between DATEADD(DAY,0,'{0}') and DATEADD(DAY, 1,'{1}') and DDBH = '{2}' group by DDBH,KCBH) as b on a.DDBH = b.DDBH where QTY > 0 and KCBH = '{3}'", dgvDay.CurrentRow.Cells[0].Value.ToString(), dgvDay.CurrentRow.Cells[0].Value.ToString(), tbOrder.Text.Trim(), cbKCBH.Text.Trim());

                            Console.WriteLine(sql);
                            SqlDataAdapter adapter = new SqlDataAdapter(sql, dbConn.connection);
                            adapter.SelectCommand.CommandTimeout = 900;
                            adapter.Fill(ds2, "訂單表");
                            this.dgvDetail.DataSource = this.ds2.Tables[0];
                        }
                        else
                        {
                            ds2 = new DataSet();
                            DataBinding dbConn = new DataBinding();

                            string sql = string.Format("select a.DDBH,a.Pairs,b.CTQTY,b.QTY from DDZL as a left join(select DDBH, count(CARTONBAR) as CTQTY, sum(Qty) as QTY, KCBH from YWCP where OUTDATE between DATEADD(DAY,0,'{0}') and DATEADD(DAY, 1,'{1}') group by DDBH,KCBH) as b on a.DDBH = b.DDBH where QTY > 0 and KCBH = '{2}'  ", dgvDay.CurrentRow.Cells[0].Value.ToString(), dgvDay.CurrentRow.Cells[0].Value.ToString(), cbKCBH.Text);

                            Console.WriteLine(sql);
                            SqlDataAdapter adapter = new SqlDataAdapter(sql, dbConn.connection);
                            adapter.SelectCommand.CommandTimeout = 900;
                            adapter.Fill(ds2, "訂單表");
                            this.dgvDetail.DataSource = this.ds2.Tables[0];
                        }
                    }
                    else if (cbStyle.SelectedIndex == 2)
                    {
                        if (tbOrder.Text != "")
                        {
                            ds2 = new DataSet();
                            DataBinding dbConn = new DataBinding();

                            string sql = string.Format("select a.DDBH,a.Pairs,b.CTQTY,b.QTY from DDZL as a left join(select DDBH, count(CARTONBAR) as CTQTY, sum(Qty) as QTY, KCBH from YWCP where INSPECTDATE between DATEADD(DAY,0,'{0}') and DATEADD(DAY, 1,'{1}') and DDBH = '{2}' group by DDBH,KCBH) as b on a.DDBH = b.DDBH where QTY > 0 and KCBH = '{3}'", dgvDay.CurrentRow.Cells[0].Value.ToString(), dgvDay.CurrentRow.Cells[0].Value.ToString(), tbOrder.Text.Trim(), cbKCBH.Text.Trim());

                            Console.WriteLine(sql);
                            SqlDataAdapter adapter = new SqlDataAdapter(sql, dbConn.connection);
                            adapter.SelectCommand.CommandTimeout = 900;
                            adapter.Fill(ds2, "訂單表");
                            this.dgvDetail.DataSource = this.ds2.Tables[0];
                        }
                        else
                        {
                            ds2 = new DataSet();
                            DataBinding dbConn = new DataBinding();

                            string sql = string.Format("select a.DDBH,a.Pairs,b.CTQTY,b.QTY from DDZL as a left join(select DDBH, count(CARTONBAR) as CTQTY, sum(Qty) as QTY, KCBH from YWCP where INSPECTDATE between DATEADD(DAY,0,'{0}') and DATEADD(DAY, 1,'{1}') group by DDBH,KCBH) as b on a.DDBH = b.DDBH where QTY > 0 and KCBH = '{2}'  ", dgvDay.CurrentRow.Cells[0].Value.ToString(), dgvDay.CurrentRow.Cells[0].Value.ToString(), cbKCBH.Text);

                            Console.WriteLine(sql);
                            SqlDataAdapter adapter = new SqlDataAdapter(sql, dbConn.connection);
                            adapter.SelectCommand.CommandTimeout = 900;
                            adapter.Fill(ds2, "訂單表");
                            this.dgvDetail.DataSource = this.ds2.Tables[0];
                        }
                    }
                //}
                //else                 
                //{
                //    if (cbStyle.SelectedIndex == 0)
                //    {
                //        if (tbOrder.Text != "")
                //        {
                //            ds2 = new DataSet();
                //            DataBinding dbConn = new DataBinding();

                //            string sql = string.Format("select a.DDBH,a.Pairs,b.CTQTY,b.QTY from DDZL as a left join(select DDBH, count(CARTONBAR) as CTQTY, sum(Qty) as QTY, KCBH from YWCP where (LastInDate between DATEADD(DAY,0,'{0}') and DATEADD(DAY, 1,'{1}')) and DDBH = '{2}' and DepNO = '{3}' group by DDBH,KCBH) as b on a.DDBH = b.DDBH where QTY > 0 and KCBH = '{4}'", dgvDay.CurrentRow.Cells[0].Value.ToString(), dgvDay.CurrentRow.Cells[0].Value.ToString(), tbOrder.Text.Trim(),comboBox1.SelectedValue, cbKCBH.Text.Trim());

                //            Console.WriteLine(sql);
                //            SqlDataAdapter adapter = new SqlDataAdapter(sql, dbConn.connection);
                //            adapter.SelectCommand.CommandTimeout = 900;
                //            adapter.Fill(ds2, "訂單表");
                //            this.dgvDetail.DataSource = this.ds2.Tables[0];
                //        }
                //        else
                //        {
                //            ds2 = new DataSet();
                //            DataBinding dbConn = new DataBinding();

                //            string sql = string.Format("select a.DDBH,a.Pairs,b.CTQTY,b.QTY from DDZL as a left join(select DDBH, count(CARTONBAR) as CTQTY, sum(Qty) as QTY, KCBH from YWCP where (LastInDate between DATEADD(DAY,0,'{0}') and DATEADD(DAY, 1,'{1}')) and DepNO = '{2}' group by DDBH,KCBH) as b on a.DDBH = b.DDBH where QTY > 0 and KCBH = '{3}' ", dgvDay.CurrentRow.Cells[0].Value.ToString(), dgvDay.CurrentRow.Cells[0].Value.ToString(), comboBox1.SelectedValue, cbKCBH.Text);

                //            Console.WriteLine(sql);
                //            SqlDataAdapter adapter = new SqlDataAdapter(sql, dbConn.connection);
                //            adapter.SelectCommand.CommandTimeout = 900;
                //            adapter.Fill(ds2, "訂單表");
                //            this.dgvDetail.DataSource = this.ds2.Tables[0];
                //        }
                //    }
                //    else if (cbStyle.SelectedIndex == 1)
                //    {
                //        if (tbOrder.Text != "")
                //        {
                //            ds2 = new DataSet();
                //            DataBinding dbConn = new DataBinding();

                //            string sql = string.Format("select a.DDBH,a.Pairs,b.CTQTY,b.QTY from DDZL as a left join(select DDBH, count(CARTONBAR) as CTQTY, sum(Qty) as QTY, KCBH from YWCP where OUTDATE between DATEADD(DAY,0,'{0}') and DATEADD(DAY, 1,'{1}') and DDBH = '{2}' and DepNO = '{3}' group by DDBH,KCBH) as b on a.DDBH = b.DDBH where QTY > 0 and KCBH = '{4}'", dgvDay.CurrentRow.Cells[0].Value.ToString(), dgvDay.CurrentRow.Cells[0].Value.ToString(), tbOrder.Text.Trim(), comboBox1.SelectedValue , cbKCBH.Text.Trim());

                //            Console.WriteLine(sql);
                //            SqlDataAdapter adapter = new SqlDataAdapter(sql, dbConn.connection);
                //            adapter.SelectCommand.CommandTimeout = 900;
                //            adapter.Fill(ds2, "訂單表");
                //            this.dgvDetail.DataSource = this.ds2.Tables[0];
                //        }
                //        else
                //        {
                //            ds2 = new DataSet();
                //            DataBinding dbConn = new DataBinding();

                //            string sql = string.Format("select a.DDBH,a.Pairs,b.CTQTY,b.QTY from DDZL as a left join(select DDBH, count(CARTONBAR) as CTQTY, sum(Qty) as QTY, KCBH from YWCP where (OUTDATE between DATEADD(DAY,0,'{0}') and DATEADD(DAY, 1,'{1}'))  and DepNO = '{2}' group by DDBH,KCBH) as b on a.DDBH = b.DDBH where QTY > 0 and KCBH = '{3}'  ", dgvDay.CurrentRow.Cells[0].Value.ToString(), dgvDay.CurrentRow.Cells[0].Value.ToString(), comboBox1.SelectedValue, cbKCBH.Text);

                //            Console.WriteLine(sql);
                //            SqlDataAdapter adapter = new SqlDataAdapter(sql, dbConn.connection);
                //            adapter.SelectCommand.CommandTimeout = 900;
                //            adapter.Fill(ds2, "訂單表");
                //            this.dgvDetail.DataSource = this.ds2.Tables[0];
                //        }
                //    }
                //    else if (cbStyle.SelectedIndex == 2)
                //    {
                //        if (tbOrder.Text != "")
                //        {
                //            ds2 = new DataSet();
                //            DataBinding dbConn = new DataBinding();

                //            string sql = string.Format("select a.DDBH,a.Pairs,b.CTQTY,b.QTY from DDZL as a left join(select DDBH, count(CARTONBAR) as CTQTY, sum(Qty) as QTY, KCBH from YWCP where INSPECTDATE between DATEADD(DAY,0,'{0}') and DATEADD(DAY, 1,'{1}') and DDBH = '{2}' and DepNO = '{3}' group by DDBH,KCBH) as b on a.DDBH = b.DDBH where QTY > 0 and KCBH = '{4}'", dgvDay.CurrentRow.Cells[0].Value.ToString(), dgvDay.CurrentRow.Cells[0].Value.ToString(), tbOrder.Text.Trim(),comboBox1.SelectedValue, cbKCBH.Text.Trim());

                //            Console.WriteLine(sql);
                //            SqlDataAdapter adapter = new SqlDataAdapter(sql, dbConn.connection);
                //            adapter.SelectCommand.CommandTimeout = 900;
                //            adapter.Fill(ds2, "訂單表");
                //            this.dgvDetail.DataSource = this.ds2.Tables[0];
                //        }
                //        else
                //        {
                //            ds2 = new DataSet();
                //            DataBinding dbConn = new DataBinding();

                //            string sql = string.Format("select a.DDBH,a.Pairs,b.CTQTY,b.QTY from DDZL as a left join(select DDBH, count(CARTONBAR) as CTQTY, sum(Qty) as QTY, KCBH from YWCP where (INSPECTDATE between DATEADD(DAY,0,'{0}') and DATEADD(DAY, 1,'{1}')) and DepNO = '{2}' group by DDBH,KCBH) as b on a.DDBH = b.DDBH where QTY > 0 and KCBH = '{3}'  ", dgvDay.CurrentRow.Cells[0].Value.ToString(), dgvDay.CurrentRow.Cells[0].Value.ToString(), comboBox1.SelectedValue, cbKCBH.Text);

                //            Console.WriteLine(sql);
                //            SqlDataAdapter adapter = new SqlDataAdapter(sql, dbConn.connection);
                //            adapter.SelectCommand.CommandTimeout = 900;
                //            adapter.Fill(ds2, "訂單表");
                //            this.dgvDetail.DataSource = this.ds2.Tables[0];
                //        }
                //    }
                //}
            }
            catch (Exception)
            {

            }
        }


        #endregion

        #region 內盒

        private void inner()
        {
            try
            {
                if (cbStyle.SelectedIndex == 0)
                {
                    
                        ds2 = new DataSet();
                        DataBinding dbConn = new DataBinding();

                        string sql = string.Format("select b.DDCC, sum (b.Qty) as num from (select * from YWCP where DDBH = '{0}' and INDATE between DATEADD(DAY,0,'{1}') and DATEADD(DAY, 1,'{2}') and KCBH = '{3}') as a left join (select * from YWBZPOS where DDBH = '{4}') as b on a.XH = b.XH group by DDCC", dgvDetail.CurrentRow.Cells[0].Value.ToString(), dgvDay.CurrentRow.Cells[0].Value.ToString(), dgvDay.CurrentRow.Cells[0].Value.ToString(), cbKCBH.Text.Trim(), dgvDetail.CurrentRow.Cells[0].Value.ToString());

                        Console.WriteLine(sql);
                        SqlDataAdapter adapter = new SqlDataAdapter(sql, dbConn.connection);
                        adapter.SelectCommand.CommandTimeout = 900;
                        adapter.Fill(ds2, "訂單表");
                        this.dgvinner.DataSource = this.ds2.Tables[0];
                    
                    
                }
                else if (cbStyle.SelectedIndex == 1)
                {
                    
                        ds2 = new DataSet();
                        DataBinding dbConn = new DataBinding();

                        string sql = string.Format("select b.DDCC, sum (b.Qty) as num from (select * from YWCP where DDBH = '{0}' and OUTDATE between DATEADD(DAY,0,'{1}') and DATEADD(DAY, 1,'{2}') and KCBH = '{3}') as a left join (select * from YWBZPOS where DDBH = '{4}') as b on a.XH = b.XH group by DDCC", dgvDetail.CurrentRow.Cells[0].Value.ToString(), dgvDay.CurrentRow.Cells[0].Value.ToString(), dgvDay.CurrentRow.Cells[0].Value.ToString(), cbKCBH.Text.Trim(), dgvDetail.CurrentRow.Cells[0].Value.ToString());

                        Console.WriteLine(sql);
                        SqlDataAdapter adapter = new SqlDataAdapter(sql, dbConn.connection);
                        adapter.SelectCommand.CommandTimeout = 900;
                        adapter.Fill(ds2, "訂單表");
                        this.dgvinner.DataSource = this.ds2.Tables[0];
                    
                   
                }
                else if (cbStyle.SelectedIndex == 2)
                {
                    
                        ds2 = new DataSet();
                        DataBinding dbConn = new DataBinding();

                        string sql = string.Format("select b.DDCC, sum (b.Qty) as num from (select * from YWCP where DDBH = '{0}' and INSPECTDATE between DATEADD(DAY,0,'{1}') and DATEADD(DAY, 1,'{2}') and KCBH = '{3}') as a left join (select * from YWBZPOS where DDBH = '{4}') as b on a.XH = b.XH group by DDCC", dgvDetail.CurrentRow.Cells[0].Value.ToString(), dgvDay.CurrentRow.Cells[0].Value.ToString(), dgvDay.CurrentRow.Cells[0].Value.ToString(), cbKCBH.Text.Trim(), dgvDetail.CurrentRow.Cells[0].Value.ToString());

                        Console.WriteLine(sql);
                        SqlDataAdapter adapter = new SqlDataAdapter(sql, dbConn.connection);
                        adapter.SelectCommand.CommandTimeout = 900;
                        adapter.Fill(ds2, "訂單表");
                        this.dgvinner.DataSource = this.ds2.Tables[0];
                    
                    
                }
            }
            catch (Exception)
            {

            }
        }


        #endregion

        #region EXCEL

        public static void ExportExcel(string fileName, DataGridView myDGV)
        {
            if (myDGV.Rows.Count > 0)
            {

                string saveFileName = "";
                //bool fileSaved = false;  
                SaveFileDialog saveDialog = new SaveFileDialog();
                saveDialog.DefaultExt = "xls";
                saveDialog.Filter = "Excel文件|*.xls";
                saveDialog.FileName = fileName;
                saveDialog.ShowDialog();
                saveFileName = saveDialog.FileName;
                if (saveFileName.IndexOf(":") < 0) return; //被点了取消   
                Microsoft.Office.Interop.Excel.Application xlApp = new Microsoft.Office.Interop.Excel.Application();
                if (xlApp == null)
                {
                    MessageBox.Show("未安装Excel。Chưa cài đặt EXCEL");
                    return;
                }

                Microsoft.Office.Interop.Excel.Workbooks workbooks = xlApp.Workbooks;
                Microsoft.Office.Interop.Excel.Workbook workbook = workbooks.Add(Microsoft.Office.Interop.Excel.XlWBATemplate.xlWBATWorksheet);
                Microsoft.Office.Interop.Excel.Worksheet worksheet = (Microsoft.Office.Interop.Excel.Worksheet)workbook.Worksheets[1];//取得sheet1  

                //写入标题  
                for (int i = 0; i < myDGV.ColumnCount; i++)
                {
                    worksheet.Cells[1, i + 1] = myDGV.Columns[i].HeaderText;
                }
                //写入数值  
                for (int r = 0; r < myDGV.Rows.Count; r++)
                {
                    for (int i = 0; i < myDGV.ColumnCount; i++)
                    {
                        worksheet.Cells[r + 2, i + 1] = myDGV.Rows[r].Cells[i].Value;
                    }
                    System.Windows.Forms.Application.DoEvents();
                }
                worksheet.Columns.EntireColumn.AutoFit();//列宽自适应  
                                                         //   if (Microsoft.Office.Interop.cmbxType.Text != "Notification")  
                                                         //   {  
                                                         //       Excel.Range rg = worksheet.get_Range(worksheet.Cells[2, 2], worksheet.Cells[ds.Tables[0].Rows.Count + 1, 2]);  
                                                         //      rg.NumberFormat = "00000000";  
                                                         //   }  

                if (saveFileName != "")
                {
                    try
                    {
                        workbook.Saved = true;
                        workbook.SaveCopyAs(saveFileName);
                        //fileSaved = true;  
                    }
                    catch (Exception ex)
                    {
                        //fileSaved = false;  
                        MessageBox.Show("文件出錯！\n" + ex.Message);
                    }

                }
                //else  
                //{  
                //    fileSaved = false;  
                //}  
                xlApp.Quit();
                GC.Collect();//强行销毁   
                             // if (fileSaved && System.IO.File.Exists(saveFileName)) System.Diagnostics.Process.Start(saveFileName); //打开EXCEL  
                MessageBox.Show("導出文件成功。Xuất tập tin thành công", "提示", MessageBoxButtons.OK);
            }
            else
            {
                MessageBox.Show("報表為空白。Báo cáo trống", "提示", MessageBoxButtons.OK);
            }

        }

        #endregion

        #endregion

        #region 事件

        #endregion

        private void DgvDay_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void DgvDay_SelectionChanged(object sender, EventArgs e)
        {
            order();
        }

        private void TsbQuery_Click(object sender, EventArgs e)
        {
            wtoday();
        }

        private void TsbExcel_Click(object sender, EventArgs e)
        {
            ExportExcel("report", dgvDetail);
        }

        private void dgvDetail_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (cbStyle.SelectedIndex == 0)
                {
                    DayReportDetail Form = new DayReportDetail();
                    Form.style = "0";
                    Form.ddbh = dgvDetail.CurrentRow.Cells[0].Value.ToString();
                    Form.date = dgvDay.CurrentRow.Cells[0].Value.ToString();
                    Form.ShowDialog();
                }
                else if (cbStyle.SelectedIndex == 1)
                {
                    DayReportDetail Form = new DayReportDetail();
                    Form.style = "1";
                    Form.ddbh = dgvDetail.CurrentRow.Cells[0].Value.ToString();
                    Form.date = dgvDay.CurrentRow.Cells[0].Value.ToString();
                    Form.ShowDialog();
                }
                else if (cbStyle.SelectedIndex == 2)
                {
                    DayReportDetail Form = new DayReportDetail();
                    Form.style = "2";
                    Form.ddbh = dgvDetail.CurrentRow.Cells[0].Value.ToString();
                    Form.date = dgvDay.CurrentRow.Cells[0].Value.ToString();
                    Form.ShowDialog();
                }
            }
            catch (Exception) { }
        }

        private void dgvDetail_SelectionChanged(object sender, EventArgs e)
        {
            inner();
        }
        
    }
}
