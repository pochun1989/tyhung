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
    public partial class WHSOFinishedGoods2 : Form
    {
        #region 變數
        public string TakeUser;
        public string DDBH;
        DataSet ds = new DataSet();
        DataSet ds2 = new DataSet();
        DataSet ds3 = new DataSet();
        DataSet ds4 = new DataSet();
        //string count = "";
        string Palletnum = "";
        public string USERID;
        int CARTONNO = 0;
        int Qty = 0;
        string DDCC = "";
        string pallet = "";
        public  string ScanClass = "";
        DateTime myDate = DateTime.Now;
        #endregion

        #region 建構函式

        public WHSOFinishedGoods2()
        {
            InitializeComponent();
        }

        #endregion

        #region 畫面載入

        private void WHSOFinishedGoods2_Load(object sender, EventArgs e)
        {
            USERID = Program.User.userID;
            string myDateString = myDate.ToString("yyyy-MM-dd HH:mm:ss");
            SearchData();
        }

        #endregion

        #region 方法

        #region 載入方法

        private void SearchData()
        {
            string myDateString = myDate.ToString("yyyy-MM-dd HH:mm:ss");
            if (ScanClass == "3") //出貨
            {
                ds = new DataSet();
                DataBinding dbConn = new DataBinding();
                try
                {
                    string sql = string.Format("select distinct a.Article as 'Article', a.XieXing as '鞋名', c.Pallet_NO as '棧板號', e.FSA_NO as '貨架',f.count as '在庫數量' , e.FSA_Locate as '儲位' from ddzl as a left outer join (select * from YWCP) as b on a.DDBH = b.DDBH left outer join (select * from PalletDetail) as c on b.CARTONBAR = c.CARTONBAR left outer join (select * from Pallet) as d on c.Pallet_NO = d.Pallet_NO left outer join (select * from FStorageAreaDetail) as e on d.Pallet_NO = e.Pallet_NO  left outer join (select Pallet_NO, count(CARTONBAR) as count from PalletDetail group by Pallet_NO) as f on d.Pallet_NO = f.Pallet_NO  where b.SB=1 and a.DDBH = '{0}' ", DDBH);
                    SqlDataAdapter adapter = new SqlDataAdapter(sql, dbConn.connection);
                    adapter.Fill(ds, "A表");
                    this.dgvA.DataSource = this.ds.Tables[0];

                }
                catch (Exception)
                {
                    //MessageBox.Show("A載入失敗!", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }


                ds2 = new DataSet();
                DataBinding dbConn2 = new DataBinding();
                try
                {
                    string sql = string.Format("select CARTONBAR  as '外箱號', Qty as '數量', DDBH as '訂單號' from YWCP where SB = 3 and DDBH like '{0}%' and EXEDATE >= '{1}' ORDER BY EXEDATE DESC", DDBH, myDateString);

                    Console.WriteLine("~~~~~");
                    Console.WriteLine(sql);
                    Console.WriteLine("~~~~~");

                    SqlDataAdapter adapter = new SqlDataAdapter(sql, dbConn2.connection);
                    adapter.Fill(ds2, "B表");

                    
                    this.dgvB.DataSource = this.ds2.Tables[0];

                    int W = 0;
                    W = dgvB.Width;
                    dgvB.Columns[0].Width = W / 2;
                    dgvB.Columns[1].Width = W / 8;
                    dgvB.Columns[2].Width = W / 8*3;
                }
                catch (Exception)
                {
                    //MessageBox.Show("B載入失敗!", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                //dgvInner.Rows[i].Cells[3].Value.ToString()

                ds3 = new DataSet();
                DataBinding dbConn3 = new DataBinding();
                try
                {

                    DataBinding connX = new DataBinding();
                    string sqlX = string.Format("select count(a.CARTONBAR) as count from (select * from YWCP where sb = 1) as a left outer join PalletDetail as b on a.CARTONBAR = b.CARTONBAR where Pallet_NO is NULL and DDBH = '{0}' ", DDBH);

                    Console.WriteLine(sqlX);

                    SqlCommand cmdX = new SqlCommand(sqlX, connX.connection);
                    SqlDataAdapter sdaX = new SqlDataAdapter(cmdX);
                    DataTable dtX = new DataTable();
                    sdaX.Fill(dtX);
                    connX.OpenConnection();
                    string countNULL = "";
                    countNULL = dtX.Rows[0][0].ToString();
                    label1.Text = countNULL;
                }
                catch (Exception)
                {
                    //MessageBox.Show("A載入失敗!", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }

                //ds4 = new DataSet();
                //DataBinding dbConn4 = new DataBinding();
                //try
                //{

                //    DataBinding connX = new DataBinding();
                //    string sqlX = string.Format("select count(distinct DDBH) as count from PalletDetail as a left outer join YWCP as b on a.CARTONBAR  = b.CARTONBAR where b.SB = 1 and Pallet_NO = '{0}' group by Pallet_NO ", dgvA.Rows[0].Cells[2].Value);

                //    Console.WriteLine(sqlX);

                //    SqlCommand cmd1 = new SqlCommand(sqlX, connX.connection);
                //    connX.OpenConnection();
                //    SqlDataReader reader1 = cmd1.ExecuteReader();


                //    if (reader1.Read() == true) //有棧板
                //    {
                //        if (reader1.GetInt32(0) > 1)
                //        {
                //            rbPallet.Enabled = false;
                //            rbBox.Checked = true;
                //        }
                //        else
                //        {
                //            rbPallet.Enabled = true;
                //            rbPallet.Checked = true;
                //        }

                //    }
                //    else //沒有棧板
                //    {
                //        rbPallet.Enabled = false;
                //        rbBox.Checked = true;
                //    }
                //    connX.CloseConnection();
                //}
                //catch (Exception)
                //{
                //    //MessageBox.Show("A載入失敗!", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Error);

                //}
            }
            else if (ScanClass == "4") //驗貨
            {
                ds = new DataSet();
                DataBinding dbConn = new DataBinding();
                try
                {
                    string sql = string.Format("select distinct a.Article as 'Article', a.XieXing as '鞋名', c.Pallet_NO as '棧板號', e.FSA_NO as '貨架',f.count as '在庫數量' , e.FSA_Locate as '儲位' from ddzl as a left outer join (select * from YWCP) as b on a.DDBH = b.DDBH left outer join (select * from PalletDetail) as c on b.CARTONBAR = c.CARTONBAR left outer join (select * from Pallet) as d on c.Pallet_NO = d.Pallet_NO left outer join (select * from FStorageAreaDetail) as e on d.Pallet_NO = e.Pallet_NO  left outer join (select Pallet_NO, count(CARTONBAR) as count from PalletDetail group by Pallet_NO) as f on d.Pallet_NO = f.Pallet_NO  where b.SB=1 and a.DDBH = '{0}' ", DDBH);
                    SqlDataAdapter adapter = new SqlDataAdapter(sql, dbConn.connection);
                    adapter.Fill(ds, "A表");
                    this.dgvA.DataSource = this.ds.Tables[0];



                }
                catch (Exception)
                {
                    //MessageBox.Show("A載入失敗!", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }


                ds2 = new DataSet();
                DataBinding dbConn2 = new DataBinding();
                try
                {
                    string sql = string.Format("select CARTONBAR  as '外箱號', Qty as '數量', DDBH as '訂單號',OUTDATE from YWCP where SB = 4 and DDBH = '{0}' and INSPECTDATE > '{1}' ORDER BY INSPECTDATE DESC", DDBH, myDateString);
                    SqlDataAdapter adapter = new SqlDataAdapter(sql, dbConn2.connection);
                    adapter.Fill(ds2, "B表");
                    this.dgvB.DataSource = this.ds2.Tables[0];

                    int W = 0;
                    W = dgvB.Width;
                    dgvB.Columns[0].Width = W / 2;
                    dgvB.Columns[1].Width = W / 8;
                    dgvB.Columns[2].Width = W / 8 * 3;

                }
                catch (Exception)
                {
                    //MessageBox.Show("B載入失敗!", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                //dgvInner.Rows[i].Cells[3].Value.ToString()

                ds3 = new DataSet();
                DataBinding dbConn3 = new DataBinding();
                try
                {

                    DataBinding connX = new DataBinding();
                    string sqlX = string.Format("select count(a.CARTONBAR) as count from (select * from YWCP where sb = 1) as a left outer join PalletDetail as b on a.CARTONBAR = b.CARTONBAR where Pallet_NO is NULL and DDBH = '{0}' ", DDBH);

                    Console.WriteLine(sqlX);

                    SqlCommand cmdX = new SqlCommand(sqlX, connX.connection);
                    SqlDataAdapter sdaX = new SqlDataAdapter(cmdX);
                    DataTable dtX = new DataTable();
                    sdaX.Fill(dtX);
                    connX.OpenConnection();
                    string countNULL = "";
                    countNULL = dtX.Rows[0][0].ToString();
                    dgvA.Rows[0].Cells[4].Value = countNULL;
                }
                catch (Exception)
                {
                    //MessageBox.Show("A載入失敗!", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }

                //ds4 = new DataSet();
                //DataBinding dbConn4 = new DataBinding();
                //try
                //{

                //    DataBinding connX = new DataBinding();
                //    string sqlX = string.Format("select count(distinct DDBH) as count from PalletDetail as a left outer join YWCP as b on a.CARTONBAR  = b.CARTONBAR where b.SB = 1 and Pallet_NO = '{0}' group by Pallet_NO ", dgvA.Rows[0].Cells[2].Value);

                //    Console.WriteLine(sqlX);

                //    SqlCommand cmd1 = new SqlCommand(sqlX, connX.connection);
                //    connX.OpenConnection();
                //    SqlDataReader reader1 = cmd1.ExecuteReader();


                //    if (reader1.Read() == true) //有棧板
                //    {
                //        if (reader1.GetInt32(0) > 1)
                //        {
                //            rbPallet.Enabled = false;
                //            rbBox.Checked = true;
                //        }
                //        else
                //        {
                //            rbPallet.Enabled = true;
                //            rbPallet.Checked = true;
                //        }

                //    }
                //    else //沒有棧板
                //    {
                //        rbPallet.Enabled = false;
                //        rbBox.Checked = true;
                //    }
                //    connX.CloseConnection();
                //}
                //catch (Exception)
                //{
                //    //MessageBox.Show("A載入失敗!", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Error);

                //}
            }
            else if (ScanClass == "2") //翻箱
            {
                ds = new DataSet();
                DataBinding dbConn = new DataBinding();
                try
                {
                    string sql = string.Format("select distinct a.Article as 'Article', a.XieXing as '鞋名', c.Pallet_NO as '棧板號', e.FSA_NO as '貨架',f.count as '在庫數量' , e.FSA_Locate as '儲位' from ddzl as a left outer join (select * from YWCP) as b on a.DDBH = b.DDBH left outer join (select * from PalletDetail) as c on b.CARTONBAR = c.CARTONBAR left outer join (select * from Pallet) as d on c.Pallet_NO = d.Pallet_NO left outer join (select * from FStorageAreaDetail) as e on d.Pallet_NO = e.Pallet_NO  left outer join (select Pallet_NO, count(CARTONBAR) as count from PalletDetail group by Pallet_NO) as f on d.Pallet_NO = f.Pallet_NO  where b.SB=1 and a.DDBH = '{0}' ", DDBH);
                    SqlDataAdapter adapter = new SqlDataAdapter(sql, dbConn.connection);
                    adapter.Fill(ds, "A表");
                    this.dgvA.DataSource = this.ds.Tables[0];



                }
                catch (Exception)
                {
                    //MessageBox.Show("A載入失敗!", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }


                ds2 = new DataSet();
                DataBinding dbConn2 = new DataBinding();
                try
                {
                    string sql = string.Format("select CARTONBAR  as '外箱號', Qty as '數量', DDBH as '訂單號',OUTDATE from YWCP where SB = 2 and DDBH = '{0}' and OUTDATE > '{1}' ORDER BY OUTDATE DESC", DDBH, myDateString);
                    SqlDataAdapter adapter = new SqlDataAdapter(sql, dbConn2.connection);
                    adapter.Fill(ds2, "B表");
                    this.dgvB.DataSource = this.ds2.Tables[0];

                    int W = 0;
                    W = dgvB.Width;
                    dgvB.Columns[0].Width = W / 2;
                    dgvB.Columns[1].Width = W / 8;
                    dgvB.Columns[2].Width = W / 8 * 3;

                }
                catch (Exception)
                {
                    //MessageBox.Show("B載入失敗!", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                //dgvInner.Rows[i].Cells[3].Value.ToString()

                ds3 = new DataSet();
                DataBinding dbConn3 = new DataBinding();
                try
                {

                    DataBinding connX = new DataBinding();
                    string sqlX = string.Format("select count(a.CARTONBAR) as count from (select * from YWCP where sb = 1) as a left outer join PalletDetail as b on a.CARTONBAR = b.CARTONBAR where Pallet_NO is NULL and DDBH = '{0}' ", DDBH);

                    Console.WriteLine(sqlX);

                    SqlCommand cmdX = new SqlCommand(sqlX, connX.connection);
                    SqlDataAdapter sdaX = new SqlDataAdapter(cmdX);
                    DataTable dtX = new DataTable();
                    sdaX.Fill(dtX);
                    connX.OpenConnection();
                    string countNULL = "";
                    countNULL = dtX.Rows[0][0].ToString();
                    dgvA.Rows[0].Cells[4].Value = countNULL;
                }
                catch (Exception)
                {
                    //MessageBox.Show("A載入失敗!", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }

                //ds4 = new DataSet();
                //DataBinding dbConn4 = new DataBinding();
                //try
                //{

                //    DataBinding connX = new DataBinding();
                //    string sqlX = string.Format("select count(distinct DDBH) as count from PalletDetail as a left outer join YWCP as b on a.CARTONBAR  = b.CARTONBAR where b.SB = 1 and Pallet_NO = '{0}' group by Pallet_NO ", dgvA.Rows[0].Cells[2].Value);

                //    Console.WriteLine(sqlX);

                //    SqlCommand cmd1 = new SqlCommand(sqlX, connX.connection);
                //    connX.OpenConnection();
                //    SqlDataReader reader1 = cmd1.ExecuteReader();


                //    if (reader1.Read() == true) //有棧板
                //    {
                //        if (reader1.GetInt32(0) > 1)
                //        {
                //            rbPallet.Enabled = false;
                //            rbBox.Checked = true;
                //        }
                //        else
                //        {
                //            rbPallet.Enabled = true;
                //            rbPallet.Checked = true;
                //        }

                //    }
                //    else //沒有棧板
                //    {
                //        rbPallet.Enabled = false;
                //        rbBox.Checked = true;
                //    }
                //    connX.CloseConnection();
                //}
                //catch (Exception)
                //{
                //    //MessageBox.Show("A載入失敗!", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Error);

                //}
            }
            else if (ScanClass == "5") //翻箱驗貨
            {
                Console.WriteLine("5");

                ds = new DataSet();
                DataBinding dbConn = new DataBinding();
                try
                {
                    string sql = string.Format("select distinct a.Article as 'Article', a.XieXing as '鞋名', c.Pallet_NO as '棧板號', e.FSA_NO as '貨架',f.count as '在庫數量' , e.FSA_Locate as '儲位' from ddzl as a left outer join (select * from YWCP) as b on a.DDBH = b.DDBH left outer join (select * from PalletDetail) as c on b.CARTONBAR = c.CARTONBAR left outer join (select * from Pallet) as d on c.Pallet_NO = d.Pallet_NO left outer join (select * from FStorageAreaDetail) as e on d.Pallet_NO = e.Pallet_NO  left outer join (select Pallet_NO, count(CARTONBAR) as count from PalletDetail group by Pallet_NO) as f on d.Pallet_NO = f.Pallet_NO  where b.SB=4 and a.DDBH = '{0}' ", DDBH);
                    SqlDataAdapter adapter = new SqlDataAdapter(sql, dbConn.connection);
                    adapter.Fill(ds, "A表");
                    this.dgvA.DataSource = this.ds.Tables[0];

                }
                catch (Exception)
                {
                    //MessageBox.Show("A載入失敗!", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }


                ds2 = new DataSet();
                DataBinding dbConn2 = new DataBinding();
                try
                {
                    string sql = string.Format("select CARTONBAR  as '外箱號', Qty as '數量', DDBH as '訂單號',OUTDATE from YWCP where SB = 2 and DDBH = '{0}' and OUTDATE > '{1}' ORDER BY OUTDATE DESC", DDBH, myDateString);
                    SqlDataAdapter adapter = new SqlDataAdapter(sql, dbConn2.connection);
                    adapter.Fill(ds2, "B表");
                    this.dgvB.DataSource = this.ds2.Tables[0];

                    int W = 0;
                    W = dgvB.Width;
                    dgvB.Columns[0].Width = W / 2;
                    dgvB.Columns[1].Width = W / 8;
                    dgvB.Columns[2].Width = W / 8 * 3;

                }
                catch (Exception)
                {
                    //MessageBox.Show("B載入失敗!", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                //dgvInner.Rows[i].Cells[3].Value.ToString()

                ds3 = new DataSet();
                DataBinding dbConn3 = new DataBinding();
                try
                {

                    DataBinding connX = new DataBinding();
                    string sqlX = string.Format("select count(a.CARTONBAR) as count from (select * from YWCP where sb = 4) as a left outer join PalletDetail as b on a.CARTONBAR = b.CARTONBAR where Pallet_NO is NULL and DDBH = '{0}' ", DDBH);

                    Console.WriteLine(sqlX);

                    SqlCommand cmdX = new SqlCommand(sqlX, connX.connection);
                    SqlDataAdapter sdaX = new SqlDataAdapter(cmdX);
                    DataTable dtX = new DataTable();
                    sdaX.Fill(dtX);
                    connX.OpenConnection();
                    string countNULL = "";
                    countNULL = dtX.Rows[0][0].ToString();
                    dgvA.Rows[0].Cells[4].Value = countNULL;
                }
                catch (Exception)
                {
                    //MessageBox.Show("A載入失敗!", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }

                //ds4 = new DataSet();
                //DataBinding dbConn4 = new DataBinding();
                //try
                //{

                //    DataBinding connX = new DataBinding();
                //    string sqlX = string.Format("select count(distinct DDBH) as count from PalletDetail as a left outer join YWCP as b on a.CARTONBAR  = b.CARTONBAR where b.SB = 1 and Pallet_NO = '{0}' group by Pallet_NO ", dgvA.Rows[0].Cells[2].Value);

                //    Console.WriteLine(sqlX);

                //    SqlCommand cmd1 = new SqlCommand(sqlX, connX.connection);
                //    connX.OpenConnection();
                //    SqlDataReader reader1 = cmd1.ExecuteReader();


                //    if (reader1.Read() == true) //有棧板
                //    {
                //        if (reader1.GetInt32(0) > 1)
                //        {
                //            rbPallet.Enabled = false;
                //            rbBox.Checked = true;
                //        }
                //        else
                //        {
                //            rbPallet.Enabled = true;
                //            rbPallet.Checked = true;
                //        }

                //    }
                //    else //沒有棧板
                //    {
                //        rbPallet.Enabled = false;
                //        rbBox.Checked = true;
                //    }
                //    connX.CloseConnection();
                //}
                //catch (Exception)
                //{
                //    //MessageBox.Show("A載入失敗!", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Error);

                //}
            }


        }

        #endregion

        #region 刪除DDBHTemp

        private void DeleteDDBH() 
        {
            int result;
            DataBinding dbconn = new DataBinding();
            string sql1 = string.Format("delete DDBHTemp where DDBH = '{0}'", DDBH);
            SqlCommand cmd1 = new SqlCommand(sql1, dbconn.connection);
            dbconn.OpenConnection();
            result = cmd1.ExecuteNonQuery();
            if (result == 1)
            {
                //MessageBox.Show("刪除資料成功! Bổ sung thông tin thành công", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        #endregion

        #region 掃描外箱方法

        private void outerscan()
        {
            try
            {
                string ddzl = "";
                DataBinding dbConn2 = new DataBinding();
                string sql2 = string.Format("select DDBH from YWCP where CARTONBAR = '{0}'", tbScan.Text);
                SqlCommand cmd2 = new SqlCommand(sql2, dbConn2.connection);
                dbConn2.OpenConnection();
                SqlDataReader reader2 = cmd2.ExecuteReader();
                if (reader2.Read())
                {
                    ddzl = reader2["DDBH"].ToString();
                }
                dbConn2.CloseConnection();

                Console.WriteLine(ddzl);

                if (DDBH == ddzl)
                {
                    if (ScanClass == "3") //出貨
                    {
                        //選出棧板號
                        DataBinding connF = new DataBinding();
                        string sqlF = string.Format("select b.Pallet_NO as 棧板號 from YWCP as a left outer join (select * from PalletDetail) as b on a.CARTONBAR = b.CARTONBAR where a.CARTONBAR = '{0}'", tbScan.Text);
                        SqlCommand cmdF = new SqlCommand(sqlF, connF.connection);
                        SqlDataAdapter sdaF = new SqlDataAdapter(cmdF);
                        DataTable dtF = new DataTable();
                        sdaF.Fill(dtF);
                        connF.OpenConnection();

                        Palletnum = dtF.Rows[0]["棧板號"].ToString().Trim();
                        Console.WriteLine(Palletnum);



                        DataBinding con = new DataBinding();
                        string strSQL1 = string.Format("select * from YWCP where CARTONBAR = '{0}' and SB = 1", tbScan.Text.Trim());
                        SqlCommand cmda = new SqlCommand(strSQL1, con.connection);
                        con.OpenConnection();
                        SqlDataReader reader = cmda.ExecuteReader();

                        Console.WriteLine(strSQL1);

                        DataBinding dbconn = new DataBinding();
                        if (reader.Read() == true) //該訂單有這筆外箱 
                        {
                            Console.WriteLine("READER");
                            if (ScanClass == "3") //掃描
                            {
                                Console.WriteLine("0");
                                //更改YWCP
                                StringBuilder sql = new StringBuilder();
                                sql.AppendFormat("update YWCP set SB = 3, USERID = '{0}' , USERDATE = GETDATE(),EXEDATE = GETDATE()  where CARTONBAR = '{1}'", USERID, this.tbScan.Text);
                                SqlCommand cmd = new SqlCommand(sql.ToString(), dbconn.connection);
                                dbconn.OpenConnection();
                                int result = cmd.ExecuteNonQuery();
                                if (result == 1)
                                {
                                    //MessageBox.Show("修改資料3成功!");
                                }

                                //修改DDZL
                                DataBinding conL = new DataBinding();
                                string strSQLL = string.Format("select * from YWCP where SB != 3 and  DDBH = '{0}'", DDBH);
                                SqlCommand cmdL = new SqlCommand(strSQLL, conL.connection);
                                conL.OpenConnection();
                                SqlDataReader readerL = cmdL.ExecuteReader();

                                if (readerL.Read() == true) //未全部
                                {

                                }
                                else //全出
                                {
                                    StringBuilder sqlS = new StringBuilder();
                                    sqlS.AppendFormat("update ddzl set YN = 5, USERID = '{0}' , USERDATE = GETDATE() where DDBH = '{1}'", USERID, DDBH);
                                    SqlCommand cmdS = new SqlCommand(sqlS.ToString(), dbconn.connection);
                                    dbconn.OpenConnection();
                                    int resultS = cmdS.ExecuteNonQuery();
                                    if (resultS == 1)
                                    {
                                        //MessageBox.Show("全數出貨完畢!");
                                    }
                                    DeleteDDBH();

                                }
                                Console.WriteLine("0-0");

                            }
                            else if (ScanClass == "4")  //驗貨
                            {
                                Console.WriteLine("1");
                                StringBuilder sql = new StringBuilder();
                                sql.AppendFormat("update YWCP set SB = '4', INSPECTCS=isnull(INSPECTCS,0)+1 , INSPECTDATE = GETDATE() , USERID = '{0}' , USERDATE = GETDATE() where CARTONBAR = '{1}'", USERID, this.tbScan.Text);
                                SqlCommand cmd = new SqlCommand(sql.ToString(), dbconn.connection);
                                dbconn.OpenConnection();
                                int result = cmd.ExecuteNonQuery();
                                if (result == 1)
                                {
                                    //MessageBox.Show("修改資料4成功!");                            
                                }

                                //減去內箱數量
                                MinusInnerOnce();
                                Console.WriteLine("1-1");

                            }
                            else if (ScanClass == "2")  //翻箱
                            {
                                Console.WriteLine("2");
                                StringBuilder sql = new StringBuilder();
                                sql.AppendFormat("update YWCP set SB = '2', OUTCS=isnull(OUTCS,0)+1 , OUTDATE = GETDATE() , USERID = '{0}' , USERDATE = GETDATE() where CARTONBAR = '{1}'", USERID, this.tbScan.Text);
                                SqlCommand cmd = new SqlCommand(sql.ToString(), dbconn.connection);
                                dbconn.OpenConnection();
                                int result = cmd.ExecuteNonQuery();
                                if (result == 1)
                                {
                                    //MessageBox.Show("修改資料2成功!");                            
                                }

                                //減去內箱數量
                                MinusInnerOnce();
                                Console.WriteLine("2-1");

                            }
                            else //驗貨翻箱
                            {
                                StringBuilder sql = new StringBuilder();
                                sql.AppendFormat("update YWCP set SB = '2', INSPECTCS=isnull(INSPECTCS,0)+1 , INSPECTDATE = GETDATE() , USERID = '{0}' , USERDATE = GETDATE() where CARTONBAR = '{1}'", USERID, this.tbScan.Text);
                                SqlCommand cmd = new SqlCommand(sql.ToString(), dbconn.connection);
                                dbconn.OpenConnection();
                                int result = cmd.ExecuteNonQuery();
                                if (result == 1)
                                {
                                    //MessageBox.Show("修改資料4成功!");                            
                                }
                            }


                            //刪除PALLETDETAIL

                            StringBuilder sqlD = new StringBuilder();
                            sqlD.AppendFormat("delete from PalletDetail where CARTONBAR = '{0}'", tbScan.Text.Trim());
                            SqlCommand cmdD = new SqlCommand(sqlD.ToString(), dbconn.connection);
                            dbconn.OpenConnection();
                            int resultD = cmdD.ExecuteNonQuery();
                            if (resultD == 1)
                            {
                                //MessageBox.Show("棧板綁定解除!");
                            }
                            Console.WriteLine("刪除PD");


                            //棧板無外箱清空
                            DataBinding con3 = new DataBinding();
                            string strSQL3 = string.Format("select * from PalletDetail where Pallet_NO = '{0}'", Palletnum);
                            SqlCommand cmd3 = new SqlCommand(strSQL3, con3.connection);
                            con3.OpenConnection();
                            SqlDataReader reader3 = cmd3.ExecuteReader();
                            Console.WriteLine(strSQL3);
                            Console.WriteLine(Palletnum);
                            if (reader3.Read() == true) //有外箱
                            {

                            }
                            else //沒有外箱
                            {
                                //修改PALLET
                                DataBinding con4 = new DataBinding();
                                string strSQL4 = string.Format("update Pallet set Usered = '0', USERID = '{0}' , USERDATE = GETDATE() where Pallet_NO = '{1}'", USERID, Palletnum);
                                SqlCommand cmd4 = new SqlCommand(strSQL4, con4.connection);
                                con4.OpenConnection();
                                Console.WriteLine(Palletnum);
                                Console.WriteLine(strSQL4);
                                int result4 = cmd4.ExecuteNonQuery();
                                if (result4 == 1)
                                {
                                    Console.WriteLine("棧板綁定解除!");
                                }
                                dbconn.CloseConnection();


                                //修改儲位
                                DataBinding con5 = new DataBinding();
                                string strSQL5 = string.Format("update FStorageAreaDetail set Pallet_NO = NULL where Pallet_NO = '{0}'", Palletnum);
                                SqlCommand cmd5 = new SqlCommand(strSQL5, con5.connection);
                                con5.OpenConnection();

                                Console.WriteLine(strSQL5);
                                int result5 = cmd5.ExecuteNonQuery();
                                if (result5 == 1)
                                {
                                    Console.WriteLine("儲位綁定解除!");
                                }
                                dbconn.CloseConnection();



                            }

                            tbScan.Text = "";
                            tbScan.Focus();




                            // MessageBox.Show("YES!", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                        else //無此外箱
                        {
                            MessageBox.Show("成品倉無此外箱 請重新掃描! Đơn hàng không có số hộp bên ngoài", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            tbScan.Text = "";
                            tbScan.Focus();
                        }
                    }
                    else
                    {
                        //選出棧板號
                        DataBinding connF = new DataBinding();
                        string sqlF = string.Format("select b.Pallet_NO as 棧板號 from YWCP as a left outer join (select * from PalletDetail) as b on a.CARTONBAR = b.CARTONBAR where a.CARTONBAR = '{0}'", tbScan.Text);
                        SqlCommand cmdF = new SqlCommand(sqlF, connF.connection);
                        SqlDataAdapter sdaF = new SqlDataAdapter(cmdF);
                        DataTable dtF = new DataTable();
                        sdaF.Fill(dtF);
                        connF.OpenConnection();

                        Palletnum = dtF.Rows[0]["棧板號"].ToString().Trim();
                        Console.WriteLine(Palletnum);



                        DataBinding con = new DataBinding();
                        string strSQL1 = string.Format("select * from YWCP where DDBH = '{0}' and CARTONBAR = '{1}' and SB = 1 or CARTONBAR = '{2}' and SB = 4 or CARTONBAR = '{3}' and SB = 6", DDBH, tbScan.Text.Trim(), tbScan.Text.Trim(), tbScan.Text.Trim());
                        SqlCommand cmda = new SqlCommand(strSQL1, con.connection);
                        con.OpenConnection();
                        SqlDataReader reader = cmda.ExecuteReader();

                        Console.WriteLine(strSQL1);

                        DataBinding dbconn = new DataBinding();
                        if (reader.Read() == true) //該訂單有這筆外箱 
                        {
                            Console.WriteLine("READER");
                            if (ScanClass == "4")  //驗貨
                            {
                                Console.WriteLine("1");
                                StringBuilder sql = new StringBuilder();
                                sql.AppendFormat("update YWCP set SB = '4', INSPECTCS=isnull(INSPECTCS,0)+1 , INSPECTDATE = GETDATE() , USERID = '{0}' , USERDATE = GETDATE() where CARTONBAR = '{1}'", TakeUser, this.tbScan.Text);

                                Console.WriteLine(sql);
                                //MessageBox.Show("123");

                                SqlCommand cmd = new SqlCommand(sql.ToString(), dbconn.connection);
                                dbconn.OpenConnection();
                                int result = cmd.ExecuteNonQuery();
                                if (result == 1)
                                {
                                    //MessageBox.Show("修改資料4成功!");                            
                                }

                                //減去內箱數量
                                MinusInnerOnce();
                                Console.WriteLine("1-1");

                            }
                            else if (ScanClass == "2")  //翻箱
                            {
                                Console.WriteLine("2");
                                StringBuilder sql = new StringBuilder();
                                sql.AppendFormat("update YWCP set SB = '2', OUTCS=isnull(OUTCS,0)+1 , OUTDATE = GETDATE() , USERID = '{0}' , USERDATE = GETDATE() where CARTONBAR = '{1}'", TakeUser, this.tbScan.Text);
                                SqlCommand cmd = new SqlCommand(sql.ToString(), dbconn.connection);
                                dbconn.OpenConnection();
                                int result = cmd.ExecuteNonQuery();
                                if (result == 1)
                                {
                                    //MessageBox.Show("修改資料2成功!");                            
                                }

                                //減去內箱數量
                                MinusInnerOnce();
                                Console.WriteLine("2-1");

                            }
                            else if (ScanClass == "5")//驗貨翻箱
                            {
                                StringBuilder sql = new StringBuilder();
                                sql.AppendFormat("update YWCP set SB = '2', INSPECTCS=isnull(INSPECTCS,0)+1  , OUTDATE = GETDATE() , USERID = '{0}' , USERDATE = GETDATE() where CARTONBAR = '{1}'", TakeUser, this.tbScan.Text);
                                SqlCommand cmd = new SqlCommand(sql.ToString(), dbconn.connection);
                                dbconn.OpenConnection();
                                int result = cmd.ExecuteNonQuery();
                                if (result == 1)
                                {
                                    //MessageBox.Show("修改資料4成功!");                            
                                }
                            }


                            //刪除PALLETDETAIL

                            StringBuilder sqlD = new StringBuilder();
                            sqlD.AppendFormat("delete from PalletDetail where CARTONBAR = '{0}'", tbScan.Text.Trim());
                            SqlCommand cmdD = new SqlCommand(sqlD.ToString(), dbconn.connection);
                            dbconn.OpenConnection();
                            int resultD = cmdD.ExecuteNonQuery();
                            if (resultD == 1)
                            {
                                //MessageBox.Show("棧板綁定解除!");
                            }
                            Console.WriteLine("刪除PD");


                            //棧板無外箱清空
                            DataBinding con3 = new DataBinding();
                            string strSQL3 = string.Format("select * from PalletDetail where Pallet_NO = '{0}'", Palletnum);
                            SqlCommand cmd3 = new SqlCommand(strSQL3, con3.connection);
                            con3.OpenConnection();
                            SqlDataReader reader3 = cmd3.ExecuteReader();
                            Console.WriteLine(strSQL3);
                            Console.WriteLine(Palletnum);
                            if (reader3.Read() == true) //有外箱
                            {

                            }
                            else //沒有外箱
                            {
                                //修改PALLET
                                DataBinding con4 = new DataBinding();
                                string strSQL4 = string.Format("update Pallet set Usered = '0', USERID = '{0}' , USERDATE = GETDATE() where Pallet_NO = '{1}'", USERID, Palletnum);
                                SqlCommand cmd4 = new SqlCommand(strSQL4, con4.connection);
                                con4.OpenConnection();
                                Console.WriteLine(Palletnum);
                                Console.WriteLine(strSQL4);
                                int result4 = cmd4.ExecuteNonQuery();
                                if (result4 == 1)
                                {
                                    Console.WriteLine("棧板綁定解除!");
                                }
                                dbconn.CloseConnection();


                                //修改儲位
                                DataBinding con5 = new DataBinding();
                                string strSQL5 = string.Format("update FStorageAreaDetail set Pallet_NO = NULL where Pallet_NO = '{0}'", Palletnum);
                                SqlCommand cmd5 = new SqlCommand(strSQL5, con5.connection);
                                con5.OpenConnection();

                                Console.WriteLine(strSQL5);
                                int result5 = cmd5.ExecuteNonQuery();
                                if (result5 == 1)
                                {
                                    Console.WriteLine("儲位綁定解除!");
                                }
                                dbconn.CloseConnection();
                            }

                            tbScan.Text = "";
                            tbScan.Focus();
                                                                                 
                            // MessageBox.Show("YES!", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                        else //無此外箱
                        {
                            MessageBox.Show("該訂單無此外箱 請重新掃描! Đơn hàng không có số hộp bên ngoài", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            tbScan.Text = "";
                            tbScan.Focus();
                        }
                    }
                }
                else 
                {
                    if (ScanClass == "2")  //翻箱
                    {
                        string ddzl3 = "";
                        DataBinding dbConn3 = new DataBinding();
                        string sql3 = string.Format("select CARTONBAR from PalletDetail where CARTONBAR = '{0}'", tbScan.Text);
                        Console.WriteLine(sql3);
                        SqlCommand cmd3 = new SqlCommand(sql3, dbConn3.connection);
                        dbConn3.OpenConnection();
                        SqlDataReader reader3 = cmd3.ExecuteReader();
                        if (reader3.Read())
                        {
                            ddzl3 = reader3["CARTONBAR"].ToString();
                        }
                        dbConn3.CloseConnection();
                        if (ddzl3 == "")
                        {
                            MessageBox.Show("並未綁定棧板，無此功能 Không thể cố định chắc pallet, không có chức năng này", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            tbScan.Text = "";
                            tbScan.Focus();
                        }
                        else
                        {
                            Console.WriteLine(ddzl3);
                            string[] sArray = ddzl3.Split(' ');
                            Console.WriteLine(sArray[0]);

                            if (sArray[0] == DDBH)
                            {
                                DataBinding con5 = new DataBinding();
                                string strSQL5 = string.Format("delete PalletDetail where CARTONBAR = '{0}'", tbScan.Text);
                                SqlCommand cmd5 = new SqlCommand(strSQL5, con5.connection);
                                con5.OpenConnection();

                                Console.WriteLine(strSQL5);
                                int result5 = cmd5.ExecuteNonQuery();
                                if (result5 == 1)
                                {

                                }
                                con5.CloseConnection();

                                dgvB.Visible = false;
                                dataGridView1.Visible = true;
                                int a = dataGridView1.Rows.Count;
                                dataGridView1.Rows.Add();
                                dataGridView1.Rows[a].Cells[0].Value = tbScan.Text;
                                tbScan.Text = "";
                                tbScan.Focus();

                                lbBOX.Text = dataGridView1.Rows.Count.ToString();
                            }
                            else 
                            {
                                MessageBox.Show("訂單號不符，請重新掃描 Mã đơn hàng không khớp, vui lòng quét lại", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                tbScan.Text = "";
                                tbScan.Focus();
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("訂單號不符，請重新掃描 Mã đơn hàng không khớp, vui lòng quét lại", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        tbScan.Text = "";
                        tbScan.Focus();
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("掃描外箱失敗 Quét thất bại", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                tbScan.Text = "";
                tbScan.Focus();
            }
        }


        #endregion

        #region 扣除內箱

        private void MinusInnerOnce()
        {
            try
            {
                //取出箱號
                DataBinding con1 = new DataBinding();
                string strSQL1 = string.Format("select CARTONNO from YWCP where CARTONBAR = '{0}'", tbScan.Text);
                SqlCommand cmd1 = new SqlCommand(strSQL1, con1.connection);
                con1.OpenConnection();
                SqlDataReader reader1 = cmd1.ExecuteReader();


                if (reader1.Read() == true) //有外箱
                {
                    CARTONNO = reader1.GetInt32(0);

                }
                con1.CloseConnection();
                Console.WriteLine(CARTONNO);

                #region 取出XH
                Console.WriteLine("selectXH");
                DataBinding conXH = new DataBinding();
                string xh = "";
                string sqlXH = string.Format("select XH from YWCP where CARTONBAR = '{0}'", tbScan.Text);
                SqlCommand cmdXH = new SqlCommand(sqlXH, conXH.connection);
                conXH.OpenConnection();
                SqlDataReader readerXH = cmdXH.ExecuteReader();
                if (readerXH.Read()) //取出箱號
                {
                    xh = readerXH["XH"].ToString();
                }
                Console.WriteLine(xh);
                //Console.WriteLine(cartonno);
                conXH.CloseConnection();

                #endregion

                string x = "";
                int y = 0;
                DataBinding con2 = new DataBinding();
                string strSQL2 = string.Format("select isnull(count(DDCC),0) as DDCC from YWBZPOS where XH = '{0}' and DDBH = '{1}'", xh, DDBH);
                SqlCommand cmd2 = new SqlCommand(strSQL2, con2.connection);
                con2.OpenConnection();     
                SqlDataReader reader2 = cmd2.ExecuteReader();
                if (reader2.Read() == true)
                {
                    x = reader2["DDCC"].ToString();
                }
                y = int.Parse(x);

                if (y == 1)
                {
                    Console.WriteLine("單一");

                    //取出單箱數量
                    DataBinding con3 = new DataBinding();
                    string strSQL3 = string.Format("select Qty,DDCC from YWBZPOS where XH = '{0}' and DDBH = '{1}'", xh, DDBH);
                    SqlCommand cmd3 = new SqlCommand(strSQL3, con3.connection);
                    con3.OpenConnection();
                    SqlDataReader reader3 = cmd3.ExecuteReader();


                    if (reader3.Read() == true) //取出內盒數
                    {
                        Qty = reader3.GetInt32(0);
                        DDCC = reader3.GetString(1);

                    }
                    con3.CloseConnection();
                    Console.WriteLine(Qty);
                    Console.WriteLine(DDCC);


                    //扣除該筆內盒數
                    DataBinding con4 = new DataBinding();
                    StringBuilder sql4 = new StringBuilder();
                    sql4.AppendFormat("update SCLH set SCQTY = SCQTY - '{0}' where XXCC = '{1}' and DDBH  = '{2}'", Qty, DDCC, DDBH);
                    SqlCommand cmd4 = new SqlCommand(sql4.ToString(), con4.connection);
                    con4.OpenConnection();
                    int result4 = cmd4.ExecuteNonQuery();
                    if (result4 == 1)
                    {
                        //MessageBox.Show("棧板綁定解除!");
                    }
                    con4.CloseConnection();

                }
                else if (y > 1)
                {


                    Console.WriteLine("多重");


                    int c;
                    //放入datatable
                    DataBinding conn = new DataBinding();
                    string sql = string.Format("select Qty,DDCC from YWBZPOS where XH = '{0}' and DDBH = '{1}'", xh, DDBH);
                    SqlCommand cmd = new SqlCommand(sql, conn.connection);
                    SqlDataAdapter sda = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    sda.Fill(dt);
                    conn.OpenConnection();
                    c = dt.Rows.Count;
                    Console.WriteLine(c);

                    for (int i = 0; i < c; i++)
                    {
                        DataBinding con4 = new DataBinding();
                        StringBuilder sql4 = new StringBuilder();
                        sql4.AppendFormat("update SCLH set SCQTY = SCQTY - '{0}' where XXCC = '{1}' and DDBH  = '{2}'", int.Parse(dt.Rows[i]["Qty"].ToString().Trim()), dt.Rows[i]["DDCC"].ToString().Trim(), DDBH);
                        SqlCommand cmd4 = new SqlCommand(sql4.ToString(), con4.connection);
                        con4.OpenConnection();
                        int result4 = cmd4.ExecuteNonQuery();
                        if (result4 == 1)
                        {
                            //MessageBox.Show("刪除"+i+"筆資料");
                        }
                        con4.CloseConnection();
                    }

                    conn.CloseConnection();


                }
                else
                {

                }
                con2.CloseConnection();
            }
            catch (Exception)
            {
                MessageBox.Show("內箱扣除失敗! Lỗi khấu trừ", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }


        }

        #endregion

        #region 掃描棧板方法

        private void PalletScan()
        {
            pallet = dgvA.CurrentRow.Cells[2].Value.ToString();

            if (pallet != "")
            {
                try
                {
                    //檢查有無該棧板
                    DataBinding con = new DataBinding();
                    string strSQL = string.Format("select * from PalletDetail where Pallet_NO = '{0}' ", pallet);
                    SqlCommand cmd = new SqlCommand(strSQL, con.connection);
                    con.OpenConnection();
                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read() == true)//有該棧板
                    {
                        con.CloseConnection();

                        //檢查棧板有無其他訂單

                        string c = "";
                        int C = 0;
                        DataBinding conn2 = new DataBinding();
                        string sql2 = string.Format("select count(distinct DDBH) as count from PalletDetail as a left outer join (select * from YWCP) as b on a.CARTONBAR = b.CARTONBAR where a.Pallet_NO = '{0}'", pallet);
                        SqlCommand cmd2 = new SqlCommand(sql2, conn2.connection);
                        SqlDataAdapter sda = new SqlDataAdapter(cmd2);
                        DataTable dt2 = new DataTable();
                        sda.Fill(dt2);
                        conn2.OpenConnection();

                        c = dt2.Rows[0]["count"].ToString().Trim();
                        conn2.CloseConnection();

                        C = int.Parse(c);


                        if (C > 1)//有多筆訂單
                        {
                            MessageBox.Show("有其他訂單，請選擇單箱出貨 Chọn một hộp", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            rbBox.Checked = true;

                        }
                        else//單一訂單 出貨
                        {
                            if (ScanClass == "3") //掃描出貨
                            {
                                //更改YWCP
                                DataBinding dbconn = new DataBinding();
                                StringBuilder sql = new StringBuilder();
                                sql.AppendFormat("UPDATE YWCP SET YWCP.SB = 3 ,EXEDATE = GETDATE(), USERID = '{0}' , USERDATE = GETDATE() FROM  YWCP INNER JOIN (select * from PalletDetail )as b ON YWCP.CARTONBAR = b.CARTONBAR where b.Pallet_NO = '{1}'", USERID, pallet);
                                SqlCommand cmdq = new SqlCommand(sql.ToString(), dbconn.connection);
                                dbconn.OpenConnection();
                                int result = cmdq.ExecuteNonQuery();
                                if (result == 1)
                                {
                                    //MessageBox.Show("修改整板資料成功!");
                                }
                                dbconn.CloseConnection();

                                ClearPallet();

                                //修改儲位
                                StringBuilder sqlS = new StringBuilder();
                                sqlS.AppendFormat("update FStorageAreaDetail set Pallet_NO = NULL where Pallet_NO = '{0}'", pallet);
                                SqlCommand cmdS = new SqlCommand(sqlS.ToString(), dbconn.connection);
                                dbconn.OpenConnection();
                                int resultS = cmdS.ExecuteNonQuery();
                                if (resultS == 1)
                                {
                                    //MessageBox.Show("棧板綁定解除!");
                                }
                                dbconn.CloseConnection();


                                //修改DDZL
                                DataBinding conD = new DataBinding();
                                string strSQLD = string.Format("select * from YWCP where SB != 3 and  DDBH = '{0}'", DDBH);
                                SqlCommand cmdD = new SqlCommand(strSQLD, conD.connection);
                                conD.OpenConnection();
                                SqlDataReader readerD = cmdD.ExecuteReader();

                                if (readerD.Read() == true) //未全部
                                {

                                }
                                else //全出
                                {
                                    conD.CloseConnection();

                                    StringBuilder sqlSS = new StringBuilder();
                                    sqlSS.AppendFormat("update ddzl set YN = 5, USERID = '{0}' , USERDATE = GETDATE() where DDBH = '{1}'", USERID, DDBH);
                                    SqlCommand cmdSS = new SqlCommand(sqlSS.ToString(), dbconn.connection);
                                    dbconn.OpenConnection();
                                    int resultSS = cmdSS.ExecuteNonQuery();
                                    if (resultSS == 1)
                                    {
                                        //MessageBox.Show("全數出貨完畢!");
                                    }
                                    dbconn.CloseConnection();
                                }

                                deletePD();


                            }
                            else if (ScanClass == "4")//驗貨出庫
                            {
                                //更改YWCP
                                DataBinding dbconn = new DataBinding();
                                StringBuilder sql = new StringBuilder();
                                sql.AppendFormat("UPDATE YWCP SET YWCP.SB = 4 ,INSPECTCS =isnull(INSPECTCS,0)+1, INSPECTDATE = GETDATE() , USERID = '{0}' , USERDATE = GETDATE() FROM  YWCP INNER JOIN (select * from PalletDetail )as b ON YWCP.CARTONBAR = b.CARTONBAR where b.Pallet_NO = '{1}'", USERID, pallet);
                                SqlCommand cmdq = new SqlCommand(sql.ToString(), dbconn.connection);
                                dbconn.OpenConnection();
                                int result = cmdq.ExecuteNonQuery();
                                if (result == 1)
                                {
                                    //MessageBox.Show("修改整板資料成功!");
                                }
                                dbconn.CloseConnection();

                                ClearPallet();

                                //修改儲位
                                StringBuilder sqlS = new StringBuilder();
                                sqlS.AppendFormat("update FStorageAreaDetail set Pallet_NO = NULL where Pallet_NO = '{0}'", pallet);
                                SqlCommand cmdS = new SqlCommand(sqlS.ToString(), dbconn.connection);
                                dbconn.OpenConnection();
                                int resultS = cmdS.ExecuteNonQuery();
                                if (resultS == 1)
                                {
                                    //MessageBox.Show("棧板綁定解除!");
                                }
                                dbconn.CloseConnection();

                                //
                                MInusPallet();

                                deletePD();
                                //扣除掃描數
                            }
                            else//翻箱出庫
                            {
                                DataBinding dbconn = new DataBinding();
                                StringBuilder sql = new StringBuilder();
                                sql.AppendFormat("UPDATE YWCP SET YWCP.SB = 2 ,OUTCS = isnull(OUTCS, 0)+1 ,OUTDATE = GETDATE(), USERID = '{0}' , USERDATE = GETDATE() FROM  YWCP INNER JOIN (select * from PalletDetail )as b ON YWCP.CARTONBAR = b.CARTONBAR where b.Pallet_NO = '{1}'", USERID, pallet);
                                SqlCommand cmdq = new SqlCommand(sql.ToString(), dbconn.connection);
                                dbconn.OpenConnection();
                                int result = cmdq.ExecuteNonQuery();
                                if (result == 1)
                                {
                                    //MessageBox.Show("修改整板資料成功!");
                                }
                                dbconn.CloseConnection();

                                ClearPallet();

                                //修改儲位
                                StringBuilder sqlS = new StringBuilder();
                                sqlS.AppendFormat("update FStorageAreaDetail set Pallet_NO = NULL where Pallet_NO = '{0}'", pallet);
                                SqlCommand cmdS = new SqlCommand(sqlS.ToString(), dbconn.connection);
                                dbconn.OpenConnection();
                                int resultS = cmdS.ExecuteNonQuery();
                                if (resultS == 1)
                                {
                                    //MessageBox.Show("棧板綁定解除!");
                                }
                                dbconn.CloseConnection();

                                MInusPallet();
                                deletePD();
                                //扣除掃描數
                            }

                        }
                    }
                    else//沒有該棧板
                    {
                        MessageBox.Show("查無該棧板，請重新掃描 Không có số pallet", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        tbScan.Text = "";
                    }

                }
                catch (Exception)
                {
                    MessageBox.Show("整板出貨有誤 Lỗi giao hàng", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {

            }

        }

        #endregion

        #region 棧板無外箱釋放

        private void ClearPallet()
        {
            pallet = dgvA.CurrentRow.Cells[2].Value.ToString();

            DataBinding dbconn = new DataBinding();
            StringBuilder sql = new StringBuilder();
            sql.AppendFormat("update Pallet set Usered  = '0' , USERID = '{0}' , USERDATE = GETDATE()  where Pallet_NO = '{1}'", USERID, pallet);
            SqlCommand cmd = new SqlCommand(sql.ToString(), dbconn.connection);
            dbconn.OpenConnection();
            int result = cmd.ExecuteNonQuery();
            if (result == 1)
            {

            }

        }

        #endregion

        #region 整版刪除PALLETDETAIL

        private void deletePD()
        {
            pallet = dgvA.CurrentRow.Cells[2].Value.ToString();
            //刪除PALLETDETAIL
            DataBinding dbconn = new DataBinding();
            StringBuilder sqlD = new StringBuilder();
            sqlD.AppendFormat("delete from PalletDetail where Pallet_NO = '{0}'", pallet);
            SqlCommand cmdD = new SqlCommand(sqlD.ToString(), dbconn.connection);
            dbconn.OpenConnection();
            int resultD = cmdD.ExecuteNonQuery();
            if (resultD == 1)
            {
                //MessageBox.Show("棧板綁定解除!");
            }
            Console.WriteLine("刪除PD");
        }

        #region 整板刪除

        private void MInusPallet()
        {
            pallet = dgvA.CurrentRow.Cells[2].Value.ToString();

            try
            {
                Console.WriteLine("++--++");
                int p;
                //取出箱號
                DataBinding conn = new DataBinding();
                string sql = string.Format("select CARTONBAR from PalletDetail where Pallet_NO = '{0}'", pallet);

                Console.WriteLine(sql);

                SqlCommand cmd = new SqlCommand(sql, conn.connection);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                conn.OpenConnection();
                p = dt.Rows.Count;
                Console.WriteLine(p);

                Console.WriteLine(dt.Rows[0][0].ToString());
                //Console.WriteLine(dt.Rows[1][0].ToString());

                #region 取出XH
                Console.WriteLine("selectXH");
                DataBinding conXH = new DataBinding();
                string xh = "";
                string sqlXH = string.Format("select XH from YWCP where CARTONBAR = '{0}'", tbScan.Text);
                SqlCommand cmdXH = new SqlCommand(sqlXH, conXH.connection);
                conXH.OpenConnection();
                SqlDataReader readerXH = cmdXH.ExecuteReader();
                if (readerXH.Read()) //取出箱號
                {
                    xh = readerXH["XH"].ToString();
                }
                Console.WriteLine(xh);
                //Console.WriteLine(cartonno);
                conXH.CloseConnection();

                #endregion


                for (int i = 0; i < p; i++)
                {
                    DataBinding con3 = new DataBinding();
                    string strSQL3 = string.Format("select CARTONNO from YWCP where CARTONBAR = '{0}'", dt.Rows[i][0].ToString());

                    Console.WriteLine(strSQL3);

                    SqlCommand cmd3 = new SqlCommand(strSQL3, con3.connection);
                    con3.OpenConnection();
                    SqlDataReader reader3 = cmd3.ExecuteReader();


                    if (reader3.Read() == true) //取出內盒數
                    {
                        Qty = reader3.GetInt32(0);

                        //比對是否多內盒
                        DataBinding con4 = new DataBinding();
                        string strSQL4 = string.Format("select isnull(count(DDCC),0) as DDCC from YWBZPOS where XH = '{0}' and DDBH = '{1}'", xh, DDBH);

                        Console.WriteLine(strSQL4);
                        int x = 0;
                        string y = "";
                        SqlCommand cmd4 = new SqlCommand(strSQL4, con4.connection);
                        con4.OpenConnection();
                        SqlDataReader reader4 = cmd4.ExecuteReader();
                        if (reader4.Read() == true) //多內盒
                        {
                            y = reader4["DDCC"].ToString();
                        }
                        x = int.Parse(y);
                        if (x>1) //多內盒
                        {
                            int c;
                            //放入datatable
                            DataBinding conD = new DataBinding();
                            string sqlD = string.Format("select CTS,DDCC from YWBZPOS where XH = '{0}' and DDBH = '{1}'", xh, DDBH);

                            Console.WriteLine(sqlD);

                            SqlCommand cmdD = new SqlCommand(sqlD, conD.connection);
                            SqlDataAdapter sdaD = new SqlDataAdapter(cmdD);
                            DataTable dtD = new DataTable();
                            sdaD.Fill(dtD);
                            conD.OpenConnection();
                            c = dtD.Rows.Count;
                            Console.WriteLine(c);

                            for (int j = 0; j < c; j++)
                            {
                                DataBinding conC = new DataBinding();
                                StringBuilder sqlC = new StringBuilder();
                                sqlC.AppendFormat("update SCLH set SCQTY = SCQTY - '{0}' where XXCC = '{1}' and DDBH  = '{2}'", int.Parse(dtD.Rows[j]["CTS"].ToString().Trim()), dtD.Rows[j]["DDCC"].ToString().Trim(), DDBH);

                                Console.WriteLine(sqlC);

                                SqlCommand cmdC = new SqlCommand(sqlC.ToString(), conC.connection);
                                conC.OpenConnection();
                                int result4 = cmdC.ExecuteNonQuery();
                                if (result4 == 1)
                                {
                                    //MessageBox.Show("刪除!" + j + "筆資料");
                                }
                                conC.CloseConnection();
                            }

                            conD.CloseConnection();




                        }
                        else if (x ==0)//單一內盒
                        {
                            int CTS2;
                            string DDCC2;

                            //取出箱數
                            DataBinding con5 = new DataBinding();
                            string strSQL5 = string.Format("select CTS,DDCC from YWBZPOS where XH = '{0}' and DDBH = '{1}'", xh, DDBH);

                            Console.WriteLine(strSQL5);

                            SqlCommand cmd5 = new SqlCommand(strSQL5, con5.connection);
                            con5.OpenConnection();
                            SqlDataReader reader5 = cmd5.ExecuteReader();
                            if (reader5.Read() == true) //多內盒
                            {
                                CTS2 = reader5.GetInt32(0);
                                DDCC2 = reader5.GetString(1);

                                Console.WriteLine(CTS2);
                                Console.WriteLine(DDCC2);
                                Console.WriteLine(DDBH);

                                //扣除該筆內盒數
                                DataBinding con6 = new DataBinding();
                                StringBuilder sql6 = new StringBuilder();
                                sql6.AppendFormat("update SCLH set SCQTY = SCQTY - '{0}' where XXCC = '{1}' and DDBH  = '{2}'", CTS2, DDCC2, DDBH);
                                SqlCommand cmd6 = new SqlCommand(sql6.ToString(), con6.connection);
                                con6.OpenConnection();
                                int result6 = cmd6.ExecuteNonQuery();
                                if (result6 == 1)
                                {
                                    //MessageBox.Show("棧板綁定解除!");
                                }
                                con6.CloseConnection();

                            }

                        }

                    }
                    con3.CloseConnection();

                    //Console.WriteLine(CTS);


                }         
            }
            catch (Exception)
            {
                MessageBox.Show("整板出貨失敗! Vận chuyển thất bại", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }


        #endregion

        #endregion

        #endregion

        #region 事件

        #region 切換棧板事件        

        private void DgvA_SelectionChanged(object sender, EventArgs e)
        {

        }




        #endregion

        #region 掃描事件

        private void TbScan_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)//如果输入的是回车键
            {
                if (tbScan.TextLength != 0)
                {
                    if (rbBox.Checked == true) //掃外箱
                    {

                        outerscan();
                        SearchData();

                    }
                    else //掃棧板
                    {
                        MessageBox.Show("整板出貨請雙擊左表棧板號 Nhấp vào số khay hai lần", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        tbScan.Text = "";
                        tbScan.Focus();
                    }

                }
                else
                {

                }

                int c = 0;
                c = dgvB.Rows.Count;
                Console.WriteLine(c);
                lbBOX.Text = c.ToString();

            }
        }


        #endregion

        #region 整板出貨事件

        private void DgvA_DoubleClick(object sender, EventArgs e)
        {
            if(rbPallet.Checked == true) //整板出貨
            {
                DialogResult dr = MessageBox.Show("確定要出貨這個棧板嗎? Chọn cái này Pallet?", "系統提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                if (dr == DialogResult.OK)
                {
                    PalletScan();
                    SearchData();
                    lbBOX.Text = dgvB.RowCount.ToString();
                    tbScan.Text = "";
                    tbScan.Focus();

                }
                else
                {

                }
            }
            else //不是整板出貨
            {
                MessageBox.Show("整板出貨失敗，請確定該棧板有無其他訂單外箱。或是未選擇整板出貨 Đơn hàng không đơn", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }



        #endregion

        #region 關閉事件

        private void TsbExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }



        #endregion

        #endregion

        private void RbBox_Click(object sender, EventArgs e)
        {
            tbScan.Focus();
        }

        private void CbClass_SelectedIndexChanged(object sender, EventArgs e)
        {
            tbScan.Focus();
        }

        private void WHSOFinishedGoods2_MouseUp(object sender, MouseEventArgs e)
        {
            tbScan.Focus();
        }

        private void DgvA_Click(object sender, EventArgs e)
        {
            tbScan.Focus();
        }

        private void DgvB_Click(object sender, EventArgs e)
        {
            tbScan.Focus();
        }

        private void DgvB_MouseUp(object sender, MouseEventArgs e)
        {
            tbScan.Focus();
        }

        private void DgvA_MouseUp(object sender, MouseEventArgs e)
        {
            tbScan.Focus();
        }

        private void DgvA_MouseClick(object sender, MouseEventArgs e)
        {
            tbScan.Focus();
        }

        private void tsbRClick_Click(object sender, EventArgs e)
        {
            try
            {
                dgvB.Visible = false;
                dataGridView1.Visible = true;
                int a = dataGridView1.Rows.Count;
                dataGridView1.Rows.Add();
                dataGridView1.Rows[a].Cells[0].Value = tbScan.Text;
                //tbScan.Text = "";
                //tbScan.Focus();
                lbBOX.Text = dataGridView1.Rows.Count.ToString();
            }
            catch (Exception) { }
        }
    }
}
