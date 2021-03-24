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
    public partial class WHSFGScanin2 : Form
    {
        #region 建構函式

        public WHSFGScanin2()
        {
            InitializeComponent();
        }

        #endregion

        #region 變數

        public string USERID;
        public string AREA;
        //DateTime myDate = DateTime.Now;
        public string myDate2 = "";
        //string myDateString = "";
        string outer = "";
        DataSet ds = new DataSet();
        DataSet dsDep = new DataSet();
        DataSet ds2 = new DataSet();
        int cartonno = 0;
        string ddbh = "";
        string sb = "";
        int count = 0;
        string ddbh2 = "";
        string ddbh3 = "0";
        double pass,pass2 = 0;
        string ifisnull = "";
        string a = "";
        string ckbh,companycode;
        int ddbhCheck = 0;
        string cartonbarxh;
        //string DDCC = "";
        //string CTS = "";
        double data;
        int btnc = 0;

        #endregion

        #region 畫面載入

        private void WHSFGScanin2_Load(object sender, EventArgs e)
        {
            try
            {
                comboBox1.SelectedIndex = 0;
                USERID = Program.User.userID;
                AREA = Program.Area.area;

                if (AREA == "0")
                {
                    ckbh = "VTY";
                }
                else if (AREA == "1")                
                {
                    ckbh = "LYF";
                }
                else if (AREA == "2") 
                {
                    ckbh = "LBT";
                }

                if (AREA == "0")
                {
                    companycode = "LTY";
                }
                else if (AREA == "1")
                {
                    companycode = "LYF";
                }
                else if (AREA == "2")
                {
                    companycode = "LBT";
                }
                //tring myDateString = myDate.ToString("yyyy-MM-dd HH:mm:ss");
                //Console.WriteLine(myDateString);

                KCBH();

                ATable();

                CBDep();
            }
            catch (Exception) 
            { }
        }

        #region 載入游標焦點事件

        private void WHSFGScanin2_Shown(object sender, EventArgs e)
        {
            tbBarcode.Focus();
        }

        #endregion

        #endregion        

        #region 事件

        #region 清空事件

        private void TspClear_Click(object sender, EventArgs e)
        {
            tbBarcode.Text = "";
            cbScanInner.Checked = true;
        }

        #endregion

        #region 離開事件

        private void TsbExit_Click(object sender, EventArgs e)
        {
            if (outer == "")
            {
                this.Close();
            }
            else
            {
                MessageBox.Show("請先掃滿內箱，或是刪除該外箱 Xoa so hop trưoc", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Information);                
            }
            

        }


        #endregion

        #region MyRegion

        private void scan()
        {
            //檢查封箱
            DataBinding dbConnScan = new DataBinding();
            string Scan7 = "0";

            string sqlScan = string.Format("select count(DDBH) as count from YWCP where SB = '7' and CARTONBAR = '{0}'", tbBarcode.Text);
            SqlCommand cmdScan = new SqlCommand(sqlScan, dbConnScan.connection);
            dbConnScan.OpenConnection();
            SqlDataReader readerScan = cmdScan.ExecuteReader();
            if (readerScan.Read()) //取出訂單號
            {
                Scan7 = readerScan["count"].ToString();
            }
            //Console.WriteLine(ddbh);
            dbConnScan.CloseConnection();
            if (Scan7 != "1")
            {
                string Scan9 = "0";
                DataBinding db2 = new DataBinding();
                string scan = string.Format("select count(DDBH) as count from YWCP where SB = '9' and CARTONBAR = '{0}'", tbBarcode.Text);
                SqlCommand cmd2s = new SqlCommand(scan, db2.connection);
                db2.OpenConnection();
                SqlDataReader scan2 = cmd2s.ExecuteReader();
                if (scan2.Read()) //取出訂單號
                {
                    Scan9 = scan2["count"].ToString();
                }
                //Console.WriteLine(ddbh);
                db2.CloseConnection();

                if (Scan9 != "1")
                {
                    if (cbScanInner.Checked != true)//只掃外箱
                    {
                        BDepartment();
                        //if (a == "0")
                        //{
                        //    MessageBox.Show("生管沒有排程，請洽生管。Khong quan ly quy trinh", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        //}
                        //else
                        //{
                        lbNumber.Text = "0";
                        if (outer == "")//沒有綁定外箱
                        {
                            DataBinding dbConn = new DataBinding();
                            DataBinding dbConn2 = new DataBinding();
                            DataBinding dbConn3 = new DataBinding();
                            #region 取出訂單號

                            //取出訂單號
                            string sql = string.Format("select DDBH from YWCP where CARTONBAR = '{0}' ", tbBarcode.Text);
                            SqlCommand cmd = new SqlCommand(sql, dbConn.connection);
                            dbConn.OpenConnection();
                            SqlDataReader reader = cmd.ExecuteReader();
                            if (reader.Read()) //取出訂單號
                            {
                                ddbh = reader.GetString(0);
                            }
                            //Console.WriteLine(ddbh);
                            dbConn.CloseConnection();

                            #endregion

                            #region 取出CARTONNO

                            //取出CARTONNO
                            string sql1 = string.Format("select CARTONNO from YWCP where CARTONBAR = '{0}' ", tbBarcode.Text);
                            SqlCommand cmd1 = new SqlCommand(sql1, dbConn.connection);
                            dbConn.OpenConnection();
                            SqlDataReader reader1 = cmd1.ExecuteReader();
                            if (reader1.Read()) //取出箱號
                            {
                                cartonno = reader1.GetInt32(0);
                            }
                            //Console.WriteLine(cartonno);
                            dbConn.CloseConnection();

                            #endregion


                            #region 有無此外箱 且尚未出庫入庫
                            string sqlG = string.Format("select CARTONBAR from YWCP where CARTONBAR = '{0}'", tbBarcode.Text);
                            SqlCommand cmdG = new SqlCommand(sqlG, dbConn3.connection);
                            dbConn3.OpenConnection();
                            SqlDataReader readerG = cmdG.ExecuteReader();
                            if (readerG.Read())
                            {
                                //有無此外箱 且尚未出庫入庫
                                string sql2 = string.Format("select CARTONBAR from YWCP where (CARTONBAR = '{0}' and SB !=1 and SB != 3 and SB ! = 7) or (CARTONBAR = '{1}' and SB is NULL)", tbBarcode.Text, tbBarcode.Text);
                                SqlCommand cmds2 = new SqlCommand(sql2, dbConn.connection);
                                dbConn.OpenConnection();
                                SqlDataReader reader2 = cmds2.ExecuteReader();
                                if (reader2.Read()) //尚未入庫
                                {

                                    //檢查QTY
                                    DataBinding dbconnh = new DataBinding();
                                    string sqlh = string.Format("select CARTONBAR from YWCP where CARTONBAR = '{0}' and QTY = '0' ", tbBarcode.Text);
                                    SqlCommand cmdh = new SqlCommand(sqlh, dbconnh.connection);
                                    dbconnh.OpenConnection();
                                    SqlDataReader readerh = cmdh.ExecuteReader();

                                    if (readerh.Read()) //為0
                                    {
                                        MessageBox.Show("外箱包裝數量為0", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        tbBarcode.Text = "";
                                        outer = "";
                                        tbBarcode.Focus();
                                    }
                                    else
                                    {
                                        #region 入庫
                                        dbConn.CloseConnection();

                                        //檢查SB型態
                                        DataBinding conn3 = new DataBinding();
                                        string sql3 = string.Format("select SB from YWCP where CARTONBAR = '{0}'", tbBarcode.Text);
                                        SqlCommand cmd3 = new SqlCommand(sql3, conn3.connection);
                                        SqlDataAdapter sda3 = new SqlDataAdapter(cmd3);
                                        DataTable dt3 = new DataTable();
                                        sda3.Fill(dt3);
                                        conn3.OpenConnection();
                                        sb = dt3.Rows[0][0].ToString();

                                        if (sb == "0") //新入庫
                                        {
                                            //修改LASTINDATE
                                            DataBinding conC = new DataBinding();
                                            StringBuilder sqlC = new StringBuilder();
                                            sqlC.AppendFormat("update YWCP set LastIndate = GETDATE(), KCBH = '{0}' where CARTONBAR = '{1}'", cbKCBH.Text.Trim(), tbBarcode.Text);

                                            Console.WriteLine(sqlC);

                                            SqlCommand cmdC = new SqlCommand(sqlC.ToString(), conC.connection);
                                            conC.OpenConnection();
                                            int result4 = cmdC.ExecuteNonQuery();
                                            if (result4 == 1)
                                            {
                                                //MessageBox.Show("新入庫");
                                            }
                                            conC.CloseConnection();

                                            #region 載入A表

                                            ATable();

                                            #endregion



                                            ////修改SCLH
                                            #region 取出DDCC 

                                            //取出DDCC

                                            //比對是否多內盒
                                            string x = "";
                                            int y = 0;
                                            DataBinding con4 = new DataBinding();
                                            string strSQL4 = string.Format("select isnull(count(DDCC),0) as DDCC from YWBZPOS where CTQ <= '{0}' and CTZ >= '{1}' and DDBH = '{2}'", cartonno, cartonno, ddbh);

                                            Console.WriteLine(strSQL4);

                                            SqlCommand cmd4 = new SqlCommand(strSQL4, con4.connection);
                                            con4.OpenConnection();
                                            SqlDataReader reader4 = cmd4.ExecuteReader();
                                            if (reader4.Read() == true) //多內盒
                                            {
                                                x = reader4["DDCC"].ToString();
                                            }
                                            y = int.Parse(x);

                                            if (y > 1) //多內盒
                                            {
                                                int c;
                                                //放入datatable
                                                DataBinding conD = new DataBinding();
                                                string sqlD = string.Format("select QTY,DDCC from YWBZPOS where CTQ <= '{0}' and CTZ >= '{1}' and DDBH = '{2}'", cartonno, cartonno, ddbh);

                                                Console.WriteLine(sqlD);

                                                SqlCommand cmdD = new SqlCommand(sqlD, conD.connection);
                                                SqlDataAdapter sdaD = new SqlDataAdapter(cmdD);
                                                DataTable dtD = new DataTable();
                                                sdaD.Fill(dtD);
                                                conD.OpenConnection();
                                                c = dtD.Rows.Count;
                                                Console.WriteLine(c);


                                                //加入內盒
                                                for (int j = 0; j < c; j++)
                                                {
                                                    DataBinding conE = new DataBinding();
                                                    StringBuilder sqlE = new StringBuilder();
                                                    sqlE.AppendFormat("update SCLH set SCQTY = SCQTY + '{0}' where XXCC = '{1}' and DDBH  = '{2}'", int.Parse(dtD.Rows[j]["QTY"].ToString().Trim()), dtD.Rows[j]["DDCC"].ToString().Trim(), ddbh);

                                                    Console.WriteLine(sqlE);

                                                    SqlCommand mdE = new SqlCommand(sqlE.ToString(), conE.connection);
                                                    conE.OpenConnection();
                                                    int esultE = mdE.ExecuteNonQuery();
                                                    if (esultE == 1)
                                                    {
                                                        //MessageBox.Show("刪除!" + j + "筆資料");
                                                    }
                                                    conE.CloseConnection();
                                                }

                                                conD.CloseConnection();


                                                //檢查有無超過
                                                int cd = 0;

                                                for (int j = 0; j < c; j++)
                                                {
                                                    DataBinding con5 = new DataBinding();
                                                    string strSQL5 = string.Format("select * from SCLH where XXCC = '{0}' and DDBH = '{1}' and QTY < SCQTY", dtD.Rows[j]["DDCC"].ToString().Trim(), ddbh);

                                                    Console.WriteLine(strSQL5);

                                                    SqlCommand cmd5 = new SqlCommand(strSQL5, con5.connection);
                                                    con5.OpenConnection();
                                                    SqlDataReader reader5 = cmd5.ExecuteReader();
                                                    if (reader5.Read() == true) //多內盒
                                                    {
                                                        cd++;
                                                    }
                                                }

                                                if (cd > 0) //超過
                                                {
                                                    //扣除
                                                    for (int j = 0; j < c; j++)
                                                    {
                                                        DataBinding conE = new DataBinding();
                                                        StringBuilder sqlE = new StringBuilder();
                                                        sqlE.AppendFormat("update SCLH set SCQTY = SCQTY - '{0}' where XXCC = '{1}' and DDBH  = '{2}'", int.Parse(dtD.Rows[j]["QTY"].ToString().Trim()), dtD.Rows[j]["DDCC"].ToString().Trim(), ddbh);

                                                        Console.WriteLine(sqlE);

                                                        SqlCommand mdE = new SqlCommand(sqlE.ToString(), conE.connection);
                                                        conE.OpenConnection();
                                                        int esultE = mdE.ExecuteNonQuery();
                                                        if (esultE == 1)
                                                        {
                                                            //MessageBox.Show("刪除!" + j + "筆資料");
                                                        }
                                                        conE.CloseConnection();
                                                    }

                                                    MessageBox.Show("內箱數量超出，請洽IT相關人員 Vuot qua so luong", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                                    dgvOuter.Rows.RemoveAt(0);
                                                    //lbDepartment.Text = "";
                                                    lbNumber.Text = "0";

                                                }
                                                else //未超過
                                                {
                                                    //YWCP
                                                    #region 修改YWCP

                                                    DataBinding conn = new DataBinding();
                                                    StringBuilder sqln = new StringBuilder();
                                                    sqln.AppendFormat("update YWCP set INDATE = GETDATE() ,LastIndate = GETDATE() ,SB = 7, INCS=isnull(INCS,0)+1,USERDATE = GETDATE(),USERID = '{0}' where CARTONBAR = '{1}'", USERID, tbBarcode.Text);

                                                    Console.WriteLine(sqln);

                                                    SqlCommand cmdn = new SqlCommand(sqln.ToString(), conn.connection);
                                                    conn.OpenConnection();
                                                    int resultn = cmdn.ExecuteNonQuery();
                                                    if (resultn == 1)
                                                    {
                                                        //MessageBox.Show("新入庫");
                                                    }
                                                    conn.CloseConnection();

                                                    #endregion
                                                }





                                            }
                                            else if (y == 1)//單一內盒
                                            {
                                                int QTY;
                                                string DDCC2;

                                                //取出箱數
                                                DataBinding con5 = new DataBinding();
                                                string strSQL5 = string.Format("select QTY,DDCC from YWBZPOS where CTQ <= '{0}' and CTZ >= '{1}' and DDBH = '{2}'", cartonno, cartonno, ddbh);

                                                Console.WriteLine(strSQL5);

                                                SqlCommand cmd5 = new SqlCommand(strSQL5, con5.connection);
                                                con5.OpenConnection();
                                                SqlDataReader reader5 = cmd5.ExecuteReader();
                                                if (reader5.Read() == true)
                                                {
                                                    QTY = reader5.GetInt32(0);
                                                    DDCC2 = reader5.GetString(1);

                                                    Console.WriteLine(QTY);
                                                    Console.WriteLine(DDCC2);
                                                    Console.WriteLine(ddbh);

                                                    //加入該筆內盒數
                                                    DataBinding con6 = new DataBinding();
                                                    StringBuilder sql6 = new StringBuilder();
                                                    sql6.AppendFormat("update SCLH set SCQTY = SCQTY + '{0}' where XXCC = '{1}' and DDBH  = '{2}'", QTY, DDCC2, ddbh);
                                                    SqlCommand cmd6 = new SqlCommand(sql6.ToString(), con6.connection);
                                                    con6.OpenConnection();
                                                    int result6 = cmd6.ExecuteNonQuery();
                                                    if (result6 == 1)
                                                    {
                                                        //MessageBox.Show("棧板綁定解除!");
                                                    }
                                                    con6.CloseConnection();

                                                    //檢查是否超出
                                                    DataBinding con7 = new DataBinding();
                                                    string strSQL7 = string.Format("select * from SCLH where XXCC = '{0}' and DDBH = '{1}' and QTY < SCQTY", DDCC2, ddbh);

                                                    Console.WriteLine(strSQL7);

                                                    SqlCommand cmd7 = new SqlCommand(strSQL7, con7.connection);
                                                    con7.OpenConnection();
                                                    SqlDataReader reader7 = cmd7.ExecuteReader();
                                                    if (reader7.Read() == true) //超出
                                                    {
                                                        //扣除
                                                        DataBinding con8 = new DataBinding();
                                                        StringBuilder sql8 = new StringBuilder();
                                                        sql8.AppendFormat("update SCLH set SCQTY = SCQTY - '{0}' where XXCC = '{1}' and DDBH  = '{2}'", QTY, DDCC2, ddbh);
                                                        SqlCommand cmd8 = new SqlCommand(sql8.ToString(), con8.connection);
                                                        con8.OpenConnection();
                                                        int result8 = cmd8.ExecuteNonQuery();
                                                        if (result8 == 1)
                                                        {
                                                            MessageBox.Show("內箱數量超出，請洽IT相關人員 Vuot qua so luong", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                                        }
                                                        con8.CloseConnection();

                                                        //刪除A

                                                        dgvOuter.Rows.RemoveAt(0);
                                                        //lbDepartment.Text = "";
                                                        lbNumber.Text = "0";

                                                    }
                                                    else //未超出
                                                    {
                                                        #region 修改YWCP

                                                        DataBinding conn = new DataBinding();
                                                        StringBuilder sqln = new StringBuilder();
                                                        sqln.AppendFormat("update YWCP set INDATE = GETDATE() ,LastIndate = GETDATE() ,SB = 7, incs=isnull(incs,0)+1 ,USERDATE = GETDATE(),USERID = '{0}' where CARTONBAR = '{1}'", USERID, tbBarcode.Text);

                                                        Console.WriteLine(sqln);

                                                        SqlCommand cmdn = new SqlCommand(sqln.ToString(), conn.connection);
                                                        conn.OpenConnection();
                                                        int resultn = cmdn.ExecuteNonQuery();
                                                        if (resultn == 1)
                                                        {
                                                            //MessageBox.Show("新入庫");
                                                        }
                                                        conn.CloseConnection();

                                                        #endregion
                                                    }

                                                }
                                            }

                                            #endregion




                                            tbBarcode.Text = "";
                                            tbBarcode.Focus();
                                            outer = "";

                                        }
                                        else //驗貨、翻箱入庫
                                        {
                                            //修改YWCP
                                            DataBinding conC = new DataBinding();
                                            StringBuilder sqlC = new StringBuilder();
                                            sqlC.AppendFormat("update YWCP set LastIndate = GETDATE(), KCBH = '{0}'  where CARTONBAR = '{1}'", cbKCBH.Text.Trim(), tbBarcode.Text);

                                            Console.WriteLine(sqlC);

                                            SqlCommand cmdC = new SqlCommand(sqlC.ToString(), conC.connection);
                                            conC.OpenConnection();
                                            int result4 = cmdC.ExecuteNonQuery();
                                            if (result4 == 1)
                                            {
                                                //MessageBox.Show("翻驗入庫");
                                            }
                                            conC.CloseConnection();

                                            #region 載入A表

                                            ATable();

                                            #endregion

                                            ////修改SCLH
                                            #region 修改SCLH 

                                            //取出DDCC

                                            //比對是否多內盒
                                            string x = "";
                                            int y = 0;
                                            DataBinding con4 = new DataBinding();
                                            string strSQL4 = string.Format("select isnull(count(DDCC),0) as DDCC from YWBZPOS where CTQ <= '{0}' and CTZ >= '{1}' and DDBH = '{2}'", cartonno, cartonno, ddbh);

                                            Console.WriteLine(strSQL4);

                                            SqlCommand cmd4 = new SqlCommand(strSQL4, con4.connection);
                                            con4.OpenConnection();
                                            SqlDataReader reader4 = cmd4.ExecuteReader();
                                            if (reader4.Read() == true)
                                            {
                                                x = reader4["DDCC"].ToString();
                                            }
                                            y = int.Parse(x);

                                            if (y > 1) //多內盒
                                            {
                                                int c;
                                                //放入datatable
                                                DataBinding conD = new DataBinding();
                                                string sqlD = string.Format("select QTY,DDCC from YWBZPOS where CTQ <= '{0}' and CTZ >= '{1}' and DDBH = '{2}'", cartonno, cartonno, ddbh);

                                                Console.WriteLine(sqlD);

                                                SqlCommand cmdD = new SqlCommand(sqlD, conD.connection);
                                                SqlDataAdapter sdaD = new SqlDataAdapter(cmdD);
                                                DataTable dtD = new DataTable();
                                                sdaD.Fill(dtD);
                                                conD.OpenConnection();
                                                c = dtD.Rows.Count;
                                                Console.WriteLine(c);


                                                //加入內盒
                                                for (int j = 0; j < c; j++)
                                                {
                                                    DataBinding conE = new DataBinding();
                                                    StringBuilder sqlE = new StringBuilder();
                                                    sqlE.AppendFormat("update SCLH set SCQTY = SCQTY + '{0}' where XXCC = '{1}' and DDBH  = '{2}'", int.Parse(dtD.Rows[j]["QTY"].ToString().Trim()), dtD.Rows[j]["DDCC"].ToString().Trim(), ddbh);

                                                    Console.WriteLine(sqlE);

                                                    SqlCommand mdE = new SqlCommand(sqlE.ToString(), conE.connection);
                                                    conE.OpenConnection();
                                                    int esultE = mdE.ExecuteNonQuery();
                                                    if (esultE == 1)
                                                    {
                                                        //MessageBox.Show("刪除!" + j + "筆資料");
                                                    }
                                                    conE.CloseConnection();
                                                }

                                                conD.CloseConnection();


                                                //檢查有無超過
                                                int cd = 0;

                                                for (int j = 0; j < c; j++)
                                                {
                                                    DataBinding con5 = new DataBinding();
                                                    string strSQL5 = string.Format("select * from SCLH where XXCC = '{0}' and DDBH = '{1}' and QTY < SCQTY", dtD.Rows[j]["DDCC"].ToString().Trim(), ddbh);

                                                    Console.WriteLine(strSQL5);

                                                    SqlCommand cmd5 = new SqlCommand(strSQL5, con5.connection);
                                                    con5.OpenConnection();
                                                    SqlDataReader reader5 = cmd5.ExecuteReader();
                                                    if (reader5.Read() == true) //多內盒
                                                    {
                                                        cd++;
                                                    }
                                                }

                                                if (cd > 0) //超過
                                                {
                                                    //扣除
                                                    for (int j = 0; j < c; j++)
                                                    {
                                                        DataBinding conE = new DataBinding();
                                                        StringBuilder sqlE = new StringBuilder();
                                                        sqlE.AppendFormat("update SCLH set SCQTY = SCQTY - '{0}' where XXCC = '{1}' and DDBH  = '{2}'", int.Parse(dtD.Rows[j]["QTY"].ToString().Trim()), dtD.Rows[j]["DDCC"].ToString().Trim(), ddbh);

                                                        Console.WriteLine(sqlE);

                                                        SqlCommand mdE = new SqlCommand(sqlE.ToString(), conE.connection);
                                                        conE.OpenConnection();
                                                        int esultE = mdE.ExecuteNonQuery();
                                                        if (esultE == 1)
                                                        {
                                                            //MessageBox.Show("刪除!" + j + "筆資料");
                                                        }
                                                        conE.CloseConnection();
                                                    }

                                                    MessageBox.Show("內箱數量超出，請洽IT相關人員 Vuot qua so luong", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                                    dgvOuter.Rows.RemoveAt(0);
                                                    //lbDepartment.Text = "";
                                                    lbNumber.Text = "0";

                                                }
                                                else //未超過
                                                {
                                                    //YWCP
                                                    #region 修改YWCP

                                                    //修改YWCP
                                                    DataBinding conY = new DataBinding();
                                                    StringBuilder sqlY = new StringBuilder();
                                                    sqlY.AppendFormat("update YWCP set LastIndate = GETDATE() ,SB = 7, incs=isnull(incs,0)+1 ,USERDATE = GETDATE(),USERID = '{0}' where CARTONBAR = '{1}'", USERID, tbBarcode.Text);

                                                    Console.WriteLine(sqlY);

                                                    SqlCommand cmdY = new SqlCommand(sqlY.ToString(), conY.connection);
                                                    conY.OpenConnection();
                                                    int resultY = cmdY.ExecuteNonQuery();
                                                    if (resultY == 1)
                                                    {
                                                        //MessageBox.Show("翻驗入庫");
                                                    }
                                                    conY.CloseConnection();

                                                    #endregion
                                                }





                                            }
                                            else if (y == 1)//單一內盒
                                            {
                                                int QTY;
                                                string DDCC2;

                                                //取出箱數
                                                DataBinding con5 = new DataBinding();
                                                string strSQL5 = string.Format("select QTY,DDCC from YWBZPOS where CTQ <= '{0}' and CTZ >= '{1}' and DDBH = '{2}'", cartonno, cartonno, ddbh);

                                                Console.WriteLine(strSQL5);

                                                SqlCommand cmd5 = new SqlCommand(strSQL5, con5.connection);
                                                con5.OpenConnection();
                                                SqlDataReader reader5 = cmd5.ExecuteReader();
                                                if (reader5.Read() == true)
                                                {
                                                    QTY = reader5.GetInt32(0);
                                                    DDCC2 = reader5.GetString(1);

                                                    Console.WriteLine(QTY);
                                                    Console.WriteLine(DDCC2);
                                                    Console.WriteLine(ddbh);

                                                    //加入該筆內盒數
                                                    DataBinding con6 = new DataBinding();
                                                    StringBuilder sql6 = new StringBuilder();
                                                    sql6.AppendFormat("update SCLH set SCQTY = SCQTY + '{0}' where XXCC = '{1}' and DDBH  = '{2}'", QTY, DDCC2, ddbh);
                                                    SqlCommand cmd6 = new SqlCommand(sql6.ToString(), con6.connection);
                                                    con6.OpenConnection();
                                                    int result6 = cmd6.ExecuteNonQuery();
                                                    if (result6 == 1)
                                                    {
                                                        //MessageBox.Show("棧板綁定解除!");
                                                    }
                                                    con6.CloseConnection();

                                                    //檢查是否超出
                                                    DataBinding con7 = new DataBinding();
                                                    string strSQL7 = string.Format("select * from SCLH where XXCC = '{0}' and DDBH = '{1}' and QTY < SCQTY", DDCC2, ddbh);

                                                    Console.WriteLine(strSQL7);

                                                    SqlCommand cmd7 = new SqlCommand(strSQL7, con7.connection);
                                                    con7.OpenConnection();
                                                    SqlDataReader reader7 = cmd7.ExecuteReader();
                                                    if (reader7.Read() == true) //超出
                                                    {
                                                        //扣除
                                                        DataBinding con8 = new DataBinding();
                                                        StringBuilder sql8 = new StringBuilder();
                                                        sql8.AppendFormat("update SCLH set SCQTY = SCQTY - '{0}' where XXCC = '{1}' and DDBH  = '{2}'", QTY, DDCC2, ddbh);
                                                        SqlCommand cmd8 = new SqlCommand(sql8.ToString(), con8.connection);
                                                        con8.OpenConnection();
                                                        int result8 = cmd8.ExecuteNonQuery();
                                                        if (result8 == 1)
                                                        {
                                                            MessageBox.Show("內箱數量超出，請洽IT相關人員 Vuot qua so luong", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                                        }
                                                        con8.CloseConnection();

                                                        //刪除A

                                                        dgvOuter.Rows.RemoveAt(0);
                                                        //lbDepartment.Text = "";
                                                        lbNumber.Text = "0";

                                                    }
                                                    else //未超出
                                                    {
                                                        #region 修改YWCP

                                                        //修改YWCP
                                                        DataBinding conY = new DataBinding();
                                                        StringBuilder sqlY = new StringBuilder();
                                                        sqlY.AppendFormat("update YWCP set LastIndate = GETDATE() ,SB = 7, incs=isnull(incs,0)+1,USERDATE = GETDATE(),USERID = '{0}' where CARTONBAR = '{1}'", USERID, tbBarcode.Text);

                                                        Console.WriteLine(sqlY);

                                                        SqlCommand cmdY = new SqlCommand(sqlY.ToString(), conY.connection);
                                                        conY.OpenConnection();
                                                        int resultY = cmdY.ExecuteNonQuery();
                                                        if (resultY == 1)
                                                        {
                                                            //MessageBox.Show("翻驗入庫");
                                                        }
                                                        conY.CloseConnection();

                                                        #endregion
                                                    }

                                                }
                                            }

                                            #endregion


                                            tbBarcode.Text = "";
                                            tbBarcode.Focus();
                                            outer = "";
                                        }


                                        #endregion
                                    }


                                }
                                else //已入庫或無外箱
                                {
                                    dbConn.CloseConnection();
                                    MessageBox.Show("外箱已入庫或封箱 Da co trong kho", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    //lbDepartment.Text = "";
                                    tbBarcode.Text = "";
                                    tbBarcode.Focus();
                                }
                                #endregion


                            }
                            else
                            {
                                MessageBox.Show("無此外箱 Hop khong co du lieu", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                tbBarcode.Text = "";
                                tbBarcode.Focus();
                                //lbDepartment.Text = "";
                            }

                        }
                        else//已綁定外箱
                        {
                            MessageBox.Show("請先掃完上一筆外箱，或是刪除 Xoa hop truoc", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            tbBarcode.Text = "";
                            tbBarcode.Focus();

                        }
                        //}

                        ATable();
                    }
                    else //掃外箱加內箱
                    {
                        Console.WriteLine("內外");
                        DataBinding dbConn = new DataBinding();
                        DataBinding dbConn2 = new DataBinding();
                        DataBinding dbConnV = new DataBinding();
                        #region 取出訂單號

                        //取出訂單號
                        string sql = string.Format("select DDBH from YWCP where CARTONBAR = '{0}' ", tbBarcode.Text);
                        SqlCommand cmd = new SqlCommand(sql, dbConn.connection);
                        dbConn.OpenConnection();
                        SqlDataReader reader = cmd.ExecuteReader();
                        if (reader.Read()) //取出訂單號
                        {
                            ddbh = reader.GetString(0);
                        }
                        //Console.WriteLine(ddbh);
                        dbConn.CloseConnection();
                        Console.WriteLine(ddbh);
                        #endregion

                        #region 取出CARTONNO

                        //取出CARTONNO
                        string sql1 = string.Format("select CARTONNO from YWCP where CARTONBAR = '{0}' ", tbBarcode.Text);
                        SqlCommand cmd1 = new SqlCommand(sql1, dbConn.connection);
                        dbConn.OpenConnection();
                        SqlDataReader reader1 = cmd1.ExecuteReader();
                        if (reader1.Read()) //取出箱號
                        {
                            cartonno = reader1.GetInt32(0);
                        }
                        Console.WriteLine(cartonno);
                        //Console.WriteLine(cartonno);
                        dbConn.CloseConnection();

                        #endregion


                        string sql0 = string.Format("select CARTONBAR from YWCP where CARTONBAR = '{0}' ", tbBarcode.Text);
                        SqlCommand cmd0 = new SqlCommand(sql0, dbConn.connection);
                        dbConn.OpenConnection();
                        SqlDataReader reader0 = cmd0.ExecuteReader();
                        //判斷內外箱
                        if (reader0.Read()) //外箱
                        {
                            if (outer == "") //尚未綁定
                            {

                                BDepartment();
                                //if (a == "0")
                                //{
                                //    MessageBox.Show("生管沒有排程，請洽生管 Quan ly khong co quy trinh lap ke hoach ", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                //}
                                //else
                                //{

                                lbNumber.Text = "0";
                                dbConn.CloseConnection();
                                //有無此外箱 且尚未出庫入庫
                                string sql2 = string.Format("select CARTONBAR from YWCP where (CARTONBAR = '{0}' and SB !=1 and SB != 3) or (CARTONBAR = '{1}' and SB is NULL)", tbBarcode.Text, tbBarcode.Text);
                                SqlCommand cmd2 = new SqlCommand(sql2, dbConn.connection);
                                dbConn.OpenConnection();
                                SqlDataReader reader2 = cmd2.ExecuteReader();

                                if (reader2.Read()) //尚未入庫
                                {
                                    //檢查QTY
                                    DataBinding dbconnh = new DataBinding();
                                    string sqlh = string.Format("select CARTONBAR from YWCP where CARTONBAR = '{0}' and QTY = '0' ", tbBarcode.Text);
                                    SqlCommand cmdh = new SqlCommand(sqlh, dbconnh.connection);
                                    dbconnh.OpenConnection();
                                    SqlDataReader readerh = cmdh.ExecuteReader();

                                    if (readerh.Read()) //為0
                                    {
                                        MessageBox.Show("外箱包裝數量為0 Thong tin hop la 0", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        tbBarcode.Text = "";
                                        outer = "";
                                        tbBarcode.Focus();

                                    }
                                    else
                                    {
                                        #region 入庫

                                        outer = tbBarcode.Text;

                                        //Lastindate 插入現在時間
                                        //Console.WriteLine(myDateString);

                                        DataBinding con4 = new DataBinding();
                                        StringBuilder sql4 = new StringBuilder();
                                        sql4.AppendFormat(" update YWCP set LastIndate = GETDATE(),KCBH = '{1}' where CARTONBAR = '{0}' ", tbBarcode.Text, cbKCBH.Text);
                                        SqlCommand cmd4 = new SqlCommand(sql4.ToString(), con4.connection);
                                        con4.OpenConnection();
                                        int result4 = cmd4.ExecuteNonQuery();
                                        if (result4 == 1)
                                        {
                                            //MessageBox.Show("插入時間");
                                        }
                                        con4.CloseConnection();

                                        //比對時間 LastIndate > myDateString顯示在 A 表

                                        ATable();



                                        #endregion

                                        #region 取出XH
                                        Console.WriteLine("selectXH");
                                        DataBinding conXH = new DataBinding();
                                        string xh = "";
                                        string sqlXH = string.Format("select XH from YWCP where CARTONBAR = '{0}'", tbBarcode.Text);
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

                                        //顯示B表
                                        string sql5 = string.Format("select XXCC as '尺寸', a.QTY as '入庫雙數', b.LHLabel as '內盒標號' from YWBZPOS as a left outer join (select * from SCLH) as b on a.DDCC = b.XXCC and a.DDBH = b.DDBH  where a.DDBH = '{0}' and XH = '{1}'", ddbh, xh);

                                        Console.WriteLine(sql5);

                                        SqlDataAdapter adapter = new SqlDataAdapter(sql5, dbConn2.connection);
                                        adapter.Fill(ds2, "內箱表");
                                        this.dgvInner.DataSource = this.ds2.Tables[0];

                                        int c;
                                        c = dgvInner.RowCount;
                                        for (int i = 0; i < c; i++)
                                        {
                                            dgvInner.Rows[i].Cells[0].Value = "0";
                                        }

                                        //int W = 0;
                                        //W = dgvInner.Width;
                                        //dgvInner.Columns[0].Width = W / 6;
                                        //dgvInner.Columns[1].Width = W / 6;
                                        //dgvInner.Columns[2].Width = W / 2;
                                        //dgvInner.Columns[3].Width = W / 6;

                                        cartonbarxh = tbBarcode.Text;
                                        tbBarcode.Text = "";
                                        tbBarcode.Focus();


                                        #endregion
                                    }




                                }
                                else //已入庫或無外箱
                                {
                                    MessageBox.Show("外箱已入庫 thùng đã nhập kho", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                    tbBarcode.Text = "";
                                    tbBarcode.Focus();
                                    //lbDepartment.Text = "";
                                    outer = "";
                                }

                                //}


                            }
                            else //已經綁定外箱
                            {
                                MessageBox.Show("請先掃完上一筆外箱，或是刪除 Xoa hop truoc", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                tbBarcode.Text = "";
                                tbBarcode.Focus();
                            }
                        }
                        else //內箱
                        {
                            if (outer == "") //尚未綁定外箱
                            {
                                MessageBox.Show("請先綁定外箱 Quet hop truoc", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                //lbDepartment.Text = "";
                                tbBarcode.Text = "";
                                tbBarcode.Focus();
                            }
                            else //已綁定外箱
                            {
                                //取出DDBH
                                DataBinding conn = new DataBinding();
                                DataBinding conn2 = new DataBinding();

                                #region 取出訂單號

                                //取出訂單號
                                string sql10 = string.Format("select DDBH from YWCP where CARTONBAR = '{0}' ", tbBarcode.Text);
                                SqlCommand cmd10 = new SqlCommand(sql10, conn.connection);
                                conn.OpenConnection();
                                SqlDataReader reader10 = cmd10.ExecuteReader();
                                if (reader10.Read()) //取出訂單號
                                {
                                    ddbh = reader10.GetString(0);
                                }
                                //Console.WriteLine(ddbh);
                                conn.CloseConnection();
                                Console.WriteLine(ddbh);
                                #endregion

                                #region 取出CARTONNO

                                //取出CARTONNO
                                string sql11 = string.Format("select CARTONNO from YWCP where CARTONBAR = '{0}' ", tbBarcode.Text);
                                SqlCommand cmd11 = new SqlCommand(sql11, conn.connection);
                                conn.OpenConnection();
                                SqlDataReader reader11 = cmd11.ExecuteReader();
                                if (reader11.Read()) //取出箱號
                                {
                                    cartonno = reader11.GetInt32(0);
                                }
                                Console.WriteLine(cartonno);
                                //Console.WriteLine(cartonno);
                                conn.CloseConnection();

                                #endregion

                                //檢查該訂單有無該內盒
                                string sql12 = string.Format("select LHLabel from SCLH where DDBH = '{0}' and LHLabel = '{1}' ", ddbh, tbBarcode.Text);
                                SqlCommand cmd12 = new SqlCommand(sql12, conn.connection);
                                conn.OpenConnection();
                                SqlDataReader reader12 = cmd12.ExecuteReader();

                                if (reader12.Read()) //訂單有內盒
                                {

                                    conn.CloseConnection();

                                    if (checkBox1.Checked == true) //內盒問題
                                    {
                                        //檢查內盒是否已滿
                                        string sql13 = string.Format("select * from SCLH where QTY = SCQTY and LHLabel = '{0}' and DDBH = '{1}'", tbBarcode.Text, ddbh);
                                        Console.WriteLine(sql13);
                                        SqlCommand cmd13 = new SqlCommand(sql13, conn.connection);
                                        conn.OpenConnection();
                                        SqlDataReader reader13 = cmd13.ExecuteReader();

                                        if (reader13.Read()) //已滿
                                        {
                                            MessageBox.Show("內盒已滿，請重新掃描 Vuot qua si luong", "系統提示");
                                            //lbDepartment.Text = "";
                                            tbBarcode.Text = "";
                                            tbBarcode.Focus();
                                        }
                                        else //未滿
                                        {
                                            #region 取出XH
                                            Console.WriteLine("selectXH");
                                            DataBinding conXH = new DataBinding();
                                            string xh = "";
                                            string sqlXH = string.Format("select XH from YWCP where CARTONBAR = '{0}'", cartonbarxh);
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

                                            //檢查是否內箱符合
                                            int p = 0;
                                            int n = 0;
                                            DataBinding connX = new DataBinding();
                                            string sqlX = string.Format("select LHLabel from YWBZPOS as a left outer join (select * from SCLH) as b on a.DDCC = b.XXCC and a.DDBH = b.DDBH where a.DDBH = '{0}' and XH = '{1}' ", ddbh, xh);

                                            Console.WriteLine(sqlX);

                                            SqlCommand cmdX = new SqlCommand(sqlX, connX.connection);
                                            SqlDataAdapter sdaX = new SqlDataAdapter(cmdX);
                                            DataTable dtX = new DataTable();
                                            sdaX.Fill(dtX);
                                            connX.OpenConnection();
                                            p = dtX.Rows.Count;

                                            //鎖定
                                            Program.Modifytype.modify = "1";


                                            for (int i = 0; i < p; i++)
                                            {
                                                if (dtX.Rows[i][0].ToString() == tbBarcode.Text.Trim()) //內箱相同增加
                                                {


                                                    if (int.Parse(dgvInner.Rows[i].Cells[0].Value.ToString()) == int.Parse(dgvInner.Rows[i].Cells[2].Value.ToString())) //數量超過
                                                    {
                                                        //MessageBox.Show("超出內盒掃描數量，請退回");
                                                    }
                                                    else
                                                    {
                                                        n++; //比對有幾筆相同+

                                                        //SCQTY + 1 
                                                        DataBinding con4 = new DataBinding();
                                                        StringBuilder sql4 = new StringBuilder();
                                                        sql4.AppendFormat(" update SCLH set SCQTY = SCQTY+1 where LHLabel = '{0}' and DDBH = '{1}' ", tbBarcode.Text, ddbh);
                                                        SqlCommand cmd4 = new SqlCommand(sql4.ToString(), con4.connection);
                                                        con4.OpenConnection();
                                                        int result4 = cmd4.ExecuteNonQuery();
                                                        if (result4 == 1)
                                                        {
                                                            //MessageBox.Show("SCQTY+1");
                                                        }
                                                        con4.CloseConnection();

                                                        //count ++
                                                        count++;
                                                        lbNumber.Text = count.ToString();

                                                        //檢查外箱掃滿沒 取出QTY
                                                        string sql6 = string.Format("select QTY from YWCP where CARTONNO = '{0}' and DDBH = '{1}'", cartonno, ddbh);

                                                        Console.WriteLine(sql6);

                                                        SqlCommand cmd6 = new SqlCommand(sql6, conn2.connection);
                                                        SqlDataAdapter sda6 = new SqlDataAdapter(cmd6);
                                                        DataTable dt6 = new DataTable();
                                                        sda6.Fill(dt6);
                                                        conn2.OpenConnection();
                                                        conn2.CloseConnection();

                                                        //Console.WriteLine(dt6.Rows[0]["QTY"].ToString().Trim());
                                                        int QTY = 0;
                                                        QTY = int.Parse(dt6.Rows[0]["QTY"].ToString().Trim());
                                                        Console.WriteLine(QTY);

                                                        Scanin();

                                                        if (QTY == count)// QTY = COUNT 已滿
                                                        {
                                                            //解除鎖定
                                                            Program.Modifytype.modify = "0";
                                                            YWCPKCBH();

                                                            //檢查SB型態
                                                            DataBinding conn3 = new DataBinding();
                                                            string sql3 = string.Format("select SB from YWCP where CARTONBAR = '{0}'", outer);
                                                            SqlCommand cmd3 = new SqlCommand(sql3, conn3.connection);
                                                            SqlDataAdapter sda3 = new SqlDataAdapter(cmd3);
                                                            DataTable dt3 = new DataTable();
                                                            sda3.Fill(dt3);
                                                            conn3.OpenConnection();
                                                            sb = dt3.Rows[0][0].ToString();

                                                            if (sb == "0") //新入庫
                                                            {
                                                                //修改LASTINDATE
                                                                DataBinding conC = new DataBinding();
                                                                StringBuilder sqlC = new StringBuilder();
                                                                sqlC.AppendFormat("update YWCP set INDATE = GETDATE() ,LastIndate = GETDATE(),USERDATE = GETDATE(),USERID = '{0}', MEMO = MEMO + '{2}' where CARTONBAR = '{1}'", USERID, outer, tbBarcode.Text + "/");

                                                                Console.WriteLine(sqlC);

                                                                SqlCommand cmdC = new SqlCommand(sqlC.ToString(), conC.connection);
                                                                conC.OpenConnection();
                                                                int resultC = cmdC.ExecuteNonQuery();
                                                                if (resultC == 1)
                                                                {
                                                                    //MessageBox.Show("新入庫");
                                                                }
                                                                conC.CloseConnection();




                                                                DataBinding connm = new DataBinding();
                                                                StringBuilder sqln = new StringBuilder();
                                                                sqln.AppendFormat("update YWCP set INDATE = GETDATE() ,LastIndate = GETDATE() ,SB = 7, incs=isnull(incs,0)+1  where CARTONBAR = '{0}'", outer);

                                                                Console.WriteLine(sqln);

                                                                SqlCommand cmdn = new SqlCommand(sqln.ToString(), connm.connection);
                                                                connm.OpenConnection();
                                                                int resultn = cmdn.ExecuteNonQuery();
                                                                if (resultn == 1)
                                                                {
                                                                    //MessageBox.Show("新入庫");
                                                                }

                                                                connm.CloseConnection();

                                                                #region 載入A表

                                                                ATable();

                                                                #endregion

                                                                //清空B表
                                                                int c = 0;
                                                                c = dgvInner.Rows.Count;
                                                                Console.WriteLine(c);


                                                                for (int d = 0; d < c; d++)
                                                                {
                                                                    dgvInner.Rows.RemoveAt(0);
                                                                }


                                                                tbBarcode.Text = "";
                                                                tbBarcode.Focus();
                                                                outer = "";
                                                                count = 0;
                                                            }
                                                            else //驗貨、翻箱入庫
                                                            {
                                                                //修改YWCP
                                                                DataBinding conC = new DataBinding();
                                                                StringBuilder sqlC = new StringBuilder();
                                                                sqlC.AppendFormat("update YWCP set LastIndate = GETDATE() where CARTONBAR = '{0}'", outer);

                                                                Console.WriteLine(sqlC);

                                                                SqlCommand cmdC = new SqlCommand(sqlC.ToString(), conC.connection);
                                                                conC.OpenConnection();
                                                                int resultC = cmdC.ExecuteNonQuery();
                                                                if (resultC == 1)
                                                                {
                                                                    //MessageBox.Show("翻驗入庫");
                                                                }
                                                                conC.CloseConnection();



                                                                #region 修改YWCP

                                                                //修改YWCP
                                                                DataBinding conY = new DataBinding();
                                                                StringBuilder sqlY = new StringBuilder();
                                                                sqlY.AppendFormat("update YWCP set LastIndate = GETDATE() ,SB = 7, incs=isnull(incs,0)+1,USERDATE = GETDATE(),USERID = '{0}'  where CARTONBAR = '{1}'", USERID, outer);

                                                                Console.WriteLine(sqlY);

                                                                SqlCommand cmdY = new SqlCommand(sqlY.ToString(), conY.connection);
                                                                conY.OpenConnection();
                                                                int resultY = cmdY.ExecuteNonQuery();
                                                                if (resultY == 1)
                                                                {
                                                                    //MessageBox.Show("翻驗入庫");
                                                                }
                                                                conY.CloseConnection();

                                                                #endregion

                                                                #region 載入A表

                                                                ATable();

                                                                #endregion

                                                                //清空B表
                                                                int c = 0;
                                                                c = dgvInner.Rows.Count;
                                                                Console.WriteLine(c);


                                                                for (int d = 0; d < c; d++)
                                                                {
                                                                    dgvInner.Rows.RemoveAt(0);
                                                                }

                                                                tbBarcode.Text = "";
                                                                tbBarcode.Focus();
                                                                outer = "";
                                                                count = 0;
                                                            }


                                                        }
                                                        else //未滿
                                                        {

                                                        }
                                                    }

                                                }
                                                else //內箱不同
                                                {

                                                }
                                            }

                                            if (n >= 1)
                                            {
                                                n = 0;
                                                tbBarcode.Text = "";
                                                tbBarcode.Focus();
                                            }
                                            else
                                            {
                                                n = 0;
                                                MessageBox.Show("內盒錯誤，請退回重裝 Hop duoc dong goi khong ch inh xac", "系統提示");

                                                tbBarcode.Text = "";
                                                tbBarcode.Focus();

                                            }




                                        }
                                    }
                                    else
                                    {
                                        //檢查內盒是否已滿
                                        string sql13 = string.Format("select * from SCLH where QTY = SCQTY and LHLabel = '{0}' and DDBH = '{1}'", tbBarcode.Text, ddbh);
                                        Console.WriteLine(sql13);
                                        SqlCommand cmd13 = new SqlCommand(sql13, conn.connection);
                                        conn.OpenConnection();
                                        SqlDataReader reader13 = cmd13.ExecuteReader();

                                        if (reader13.Read()) //已滿
                                        {
                                            MessageBox.Show("內盒已滿，請重新掃描 Vuot qua si luong", "系統提示");
                                            //lbDepartment.Text = "";
                                            tbBarcode.Text = "";
                                            tbBarcode.Focus();
                                        }
                                        else //未滿
                                        {
                                            #region 取出XH
                                            Console.WriteLine("selectXH");
                                            DataBinding conXH = new DataBinding();
                                            string xh = "";
                                            string sqlXH = string.Format("select XH from YWCP where CARTONBAR = '{0}'", cartonbarxh);
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

                                            //檢查是否內箱符合
                                            int p = 0;
                                            int n = 0;
                                            DataBinding connX = new DataBinding();
                                            string sqlX = string.Format("select LHLabel from YWBZPOS as a left outer join (select * from SCLH) as b on a.DDCC = b.XXCC and a.DDBH = b.DDBH where a.DDBH = '{0}' and XH = '{1}' ", ddbh, xh);

                                            Console.WriteLine(sqlX);

                                            SqlCommand cmdX = new SqlCommand(sqlX, connX.connection);
                                            SqlDataAdapter sdaX = new SqlDataAdapter(cmdX);
                                            DataTable dtX = new DataTable();
                                            sdaX.Fill(dtX);
                                            connX.OpenConnection();
                                            p = dtX.Rows.Count;

                                            //鎖定
                                            Program.Modifytype.modify = "1";


                                            for (int i = 0; i < p; i++)
                                            {
                                                if (dtX.Rows[i][0].ToString() == tbBarcode.Text.Trim()) //內箱相同增加
                                                {


                                                    if (int.Parse(dgvInner.Rows[i].Cells[0].Value.ToString()) == int.Parse(dgvInner.Rows[i].Cells[2].Value.ToString())) //數量超過
                                                    {
                                                        //MessageBox.Show("超出內盒掃描數量，請退回");
                                                    }
                                                    else
                                                    {
                                                        n++; //比對有幾筆相同+

                                                        //SCQTY + 1 
                                                        DataBinding con4 = new DataBinding();
                                                        StringBuilder sql4 = new StringBuilder();
                                                        sql4.AppendFormat(" update SCLH set SCQTY = SCQTY+1 where LHLabel = '{0}' and DDBH = '{1}' ", tbBarcode.Text, ddbh);
                                                        SqlCommand cmd4 = new SqlCommand(sql4.ToString(), con4.connection);
                                                        con4.OpenConnection();
                                                        int result4 = cmd4.ExecuteNonQuery();
                                                        if (result4 == 1)
                                                        {
                                                            //MessageBox.Show("SCQTY+1");
                                                        }
                                                        con4.CloseConnection();

                                                        //count ++
                                                        count++;
                                                        lbNumber.Text = count.ToString();

                                                        //檢查外箱掃滿沒 取出QTY
                                                        string sql6 = string.Format("select QTY from YWCP where CARTONNO = '{0}' and DDBH = '{1}'", cartonno, ddbh);

                                                        Console.WriteLine(sql6);

                                                        SqlCommand cmd6 = new SqlCommand(sql6, conn2.connection);
                                                        SqlDataAdapter sda6 = new SqlDataAdapter(cmd6);
                                                        DataTable dt6 = new DataTable();
                                                        sda6.Fill(dt6);
                                                        conn2.OpenConnection();
                                                        conn2.CloseConnection();

                                                        //Console.WriteLine(dt6.Rows[0]["QTY"].ToString().Trim());
                                                        int QTY = 0;
                                                        QTY = int.Parse(dt6.Rows[0]["QTY"].ToString().Trim());
                                                        Console.WriteLine(QTY);

                                                        Scanin();

                                                        if (QTY == count)// QTY = COUNT 已滿
                                                        {
                                                            //解除鎖定
                                                            Program.Modifytype.modify = "0";
                                                            YWCPKCBH();

                                                            //檢查SB型態
                                                            DataBinding conn3 = new DataBinding();
                                                            string sql3 = string.Format("select SB from YWCP where CARTONBAR = '{0}'", outer);
                                                            SqlCommand cmd3 = new SqlCommand(sql3, conn3.connection);
                                                            SqlDataAdapter sda3 = new SqlDataAdapter(cmd3);
                                                            DataTable dt3 = new DataTable();
                                                            sda3.Fill(dt3);
                                                            conn3.OpenConnection();
                                                            sb = dt3.Rows[0][0].ToString();

                                                            if (sb == "0") //新入庫
                                                            {
                                                                //修改LASTINDATE
                                                                DataBinding conC = new DataBinding();
                                                                StringBuilder sqlC = new StringBuilder();
                                                                sqlC.AppendFormat("update YWCP set INDATE = GETDATE() ,LastIndate = GETDATE(),USERDATE = GETDATE(),USERID = '{0}' where CARTONBAR = '{1}'", USERID, outer);

                                                                Console.WriteLine(sqlC);

                                                                SqlCommand cmdC = new SqlCommand(sqlC.ToString(), conC.connection);
                                                                conC.OpenConnection();
                                                                int resultC = cmdC.ExecuteNonQuery();
                                                                if (resultC == 1)
                                                                {
                                                                    //MessageBox.Show("新入庫");
                                                                }
                                                                conC.CloseConnection();




                                                                DataBinding connm = new DataBinding();
                                                                StringBuilder sqln = new StringBuilder();
                                                                sqln.AppendFormat("update YWCP set INDATE = GETDATE() ,LastIndate = GETDATE() ,SB = 7, incs=isnull(incs,0)+1  where CARTONBAR = '{0}'", outer);

                                                                Console.WriteLine(sqln);

                                                                SqlCommand cmdn = new SqlCommand(sqln.ToString(), connm.connection);
                                                                connm.OpenConnection();
                                                                int resultn = cmdn.ExecuteNonQuery();
                                                                if (resultn == 1)
                                                                {
                                                                    //MessageBox.Show("新入庫");
                                                                }

                                                                connm.CloseConnection();

                                                                #region 載入A表

                                                                ATable();

                                                                #endregion

                                                                //清空B表
                                                                int c = 0;
                                                                c = dgvInner.Rows.Count;
                                                                Console.WriteLine(c);


                                                                for (int d = 0; d < c; d++)
                                                                {
                                                                    dgvInner.Rows.RemoveAt(0);
                                                                }


                                                                tbBarcode.Text = "";
                                                                tbBarcode.Focus();
                                                                outer = "";
                                                                count = 0;
                                                            }
                                                            else //驗貨、翻箱入庫
                                                            {
                                                                //修改YWCP
                                                                DataBinding conC = new DataBinding();
                                                                StringBuilder sqlC = new StringBuilder();
                                                                sqlC.AppendFormat("update YWCP set LastIndate = GETDATE() where CARTONBAR = '{0}'", outer);

                                                                Console.WriteLine(sqlC);

                                                                SqlCommand cmdC = new SqlCommand(sqlC.ToString(), conC.connection);
                                                                conC.OpenConnection();
                                                                int resultC = cmdC.ExecuteNonQuery();
                                                                if (resultC == 1)
                                                                {
                                                                    //MessageBox.Show("翻驗入庫");
                                                                }
                                                                conC.CloseConnection();



                                                                #region 修改YWCP

                                                                //修改YWCP
                                                                DataBinding conY = new DataBinding();
                                                                StringBuilder sqlY = new StringBuilder();
                                                                sqlY.AppendFormat("update YWCP set LastIndate = GETDATE() ,SB = 7, incs=isnull(incs,0)+1,USERDATE = GETDATE(),USERID = '{0}'  where CARTONBAR = '{1}'", USERID, outer);

                                                                Console.WriteLine(sqlY);

                                                                SqlCommand cmdY = new SqlCommand(sqlY.ToString(), conY.connection);
                                                                conY.OpenConnection();
                                                                int resultY = cmdY.ExecuteNonQuery();
                                                                if (resultY == 1)
                                                                {
                                                                    //MessageBox.Show("翻驗入庫");
                                                                }
                                                                conY.CloseConnection();

                                                                #endregion

                                                                #region 載入A表

                                                                ATable();

                                                                #endregion

                                                                //清空B表
                                                                int c = 0;
                                                                c = dgvInner.Rows.Count;
                                                                Console.WriteLine(c);


                                                                for (int d = 0; d < c; d++)
                                                                {
                                                                    dgvInner.Rows.RemoveAt(0);
                                                                }

                                                                tbBarcode.Text = "";
                                                                tbBarcode.Focus();
                                                                outer = "";
                                                                count = 0;
                                                                btnc = 0;
                                                            }


                                                        }
                                                        else //未滿
                                                        {

                                                        }
                                                    }

                                                }
                                                else //內箱不同
                                                {

                                                }
                                            }

                                            if (n >= 1)
                                            {
                                                n = 0;
                                                tbBarcode.Text = "";
                                                tbBarcode.Focus();
                                            }
                                            else
                                            {
                                                n = 0;
                                                MessageBox.Show("內盒錯誤，請退回重裝 Hop duoc dong goi khong ch inh xac", "系統提示");

                                                tbBarcode.Text = "";
                                                tbBarcode.Focus();

                                            }




                                        }
                                    }

                                }
                                else //訂單沒有內盒
                                {
                                    MessageBox.Show("查無此內盒，請重新掃描 DONG HOP SAI", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                    DataBinding con4 = new DataBinding();
                                    StringBuilder sql4 = new StringBuilder();
                                    sql4.AppendFormat("update YWCP set err_count = isnull(err_count,0) +1 where CARTONBAR = '{0}' ", outer);
                                    SqlCommand cmd4 = new SqlCommand(sql4.ToString(), con4.connection);
                                    con4.OpenConnection();
                                    int result4 = cmd4.ExecuteNonQuery();
                                    if (result4 == 1)
                                    {
                                        //MessageBox.Show("SCQTY+1");
                                    }
                                    con4.CloseConnection();

                                    tbBarcode.Text = "";
                                    tbBarcode.Focus();

                                }



                            }






                        }



                    }
                }
                else
                {
                    MessageBox.Show("thùng này đang là trạng thái bán thành phẩm, scan trước để xuất khỏi kho bán thành phẩm 此外箱為半成品狀態，請先掃描出半成品庫", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
            }
            else 
            {
                MessageBox.Show("此外箱已經封箱掃描過 Thung hang da duoc dan niem phong va scan", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }


            dgvOuter.Columns[0].FillWeight = 140;
            dgvOuter.Columns[1].FillWeight = 60;
            dgvOuter.Columns[5].FillWeight = 140;
        }

        #endregion

        #region 掃描事件

        private void TbBarcode_KeyDown(object sender, KeyEventArgs e)
        {
            if (checkBox1.Checked == false)
            {
                //string myDateString = myDate.ToString("yyyy-MM-dd HH:mm:ss");
                if (e.KeyCode == Keys.Enter)//如果输入的是回车键
                {
                    if (tbBarcode.Text == "")//誤觸判定
                    {
                    }
                    else//進入掃描事件
                    {
                        try
                        {
                            DataBinding dbConnp = new DataBinding();
                            DataBinding dbConnp2 = new DataBinding();
                            DataBinding dbConnp3 = new DataBinding();
                            //判斷是否領料

                            string sqlp = string.Format("select DDBH from YWCP where CARTONBAR = '{0}' ", tbBarcode.Text);
                            SqlCommand cmdp = new SqlCommand(sqlp, dbConnp.connection);
                            dbConnp.OpenConnection();
                            SqlDataReader readerp = cmdp.ExecuteReader();
                            if (readerp.Read()) //取出箱號
                            {
                                ddbh3 = readerp.GetString(0);
                            }
                            //Console.WriteLine(cartonno);
                            dbConnp.CloseConnection();


                            LackTake();
                            if (data > 0) //有領料
                            {
                                pass = 1;
                                scan();
                            }
                            else
                            {
                                CheckDDBH();
                                if (ddbhCheck == 1) //繞過
                                {
                                    pass = 1;
                                    scan();
                                }
                                else //彈出視窗
                                {
                                    DataBinding conn2 = new DataBinding();

                                    #region 取出訂單號

                                    //取出訂單號
                                    string sql1 = string.Format("select DDBH from YWCP where CARTONBAR = '{0}'", tbBarcode.Text);
                                    SqlCommand cmd1 = new SqlCommand(sql1, conn2.connection);
                                    conn2.OpenConnection();
                                    SqlDataReader reader1 = cmd1.ExecuteReader();
                                    if (reader1.Read()) //取出訂單號
                                    {
                                        ddbh = reader1.GetString(0);
                                    }
                                    //Console.WriteLine(ddbh);
                                    conn2.CloseConnection();
                                    //Console.WriteLine(ddbh);
                                    #endregion

                                    //取出訂單號
                                    DataBinding conn = new DataBinding();
                                    string data = "";
                                    string sql10 = string.Format("select zlzls2.clbh from zlzls2 left join ddzl on ddzl.ddbh=zlzls2.ZLBH left join XXZL on XXZL.XieXing=DDZL.XieXing and XXZL.SheHao=DDZL.SheHao left join ( SELECT xiexing,shehao,bwbh,/*clbh,*/ flbh,MAX(CLTX) AS CLTX FROM (select xx.xiexing,xx.shehao,xx.bwbh,clbh,fl.flbh,xx.cltx from xxzls xx left join xxbwfl fl on fl.xiexing=xx.xiexing and fl.bwbh=xx.bwbh union all select vn.xiexing,vn.shehao,bwbh,clbh,flbh,'0' as cltx from xxzlsvn vn ) VV GROUP BY xiexing,shehao,bwbh, /*clbh,*/ flbh  ) xv on ZLZLS2.BWBH=xv.BWBH and XXZL.XieXing=xv.XieXing and XXZL.SHEHAO=xv.SHEHAO join XXBWFLS on xxbwfls.FLBH=Xv.FLBH left join (select KCLLS.SCBH,KCLLS.CLBH, isnull(sum(KCLLS.Qty),0) as Qty, isnull( KCLLS.DFL,'N') as DFL from  KCLLS where  KCLLS.SCBH= '{0}' and kclls.ckbh='{1}' and TempQty > 0 group by KCLLS.SCBH, KCLLS.CLBH,KCLLS.DFL) KCLLS on KCLLS.SCBH=zlzls2.ZLBH and KCLLS.CLBH=zlzls2.CLBH and xxbwfls.DFL=kclls.DFL where zlzls2.ZLBH = '{2}' and mjbh='ZZZZZZZZZZ' and zlzls2.CLSL > 0  and kclls.DFL in ('C','S','A') and QTY = 0 and substring(zlzls2.CLBH,1,1) <> 'H' and substring(zlzls2.CLBH,1,1) <> 'F' and zlzls2.clbh not like 'HOP%' and zlzls2.clbh not like 'HSL%' and zlzls2.clbh not like 'HTB%' and zlzls2.clbh not like 'HCR%' and zlzls2.clbh not like 'HYL%'", ddbh, ckbh, ddbh);
                                    SqlCommand cmd10 = new SqlCommand(sql10, conn.connection);
                                    conn.OpenConnection();
                                    SqlDataReader reader10 = cmd10.ExecuteReader();
                                    if (reader10.Read()) //取出訂單號
                                    {
                                        data = reader10.GetString(0);
                                    }
                                    MessageBox.Show("此料號" + data + " 未領料。 Đơn hàng này vẫn chưa lãnh, liên hệ Điều độ", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    conn.CloseConnection();
                                }
                            }
                        }
                        catch (Exception)
                        {
                            MessageBox.Show("掃描錯誤 Loi quet", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }

                    }


                    //顯示外箱數
                    int l = 0;
                    l = dgvOuter.Rows.Count;
                    Console.WriteLine(l);
                    lbBOX.Text = l.ToString();


                }
            }

        }


        #endregion

        #region 方法

        #region 後門訂單

        private void CheckDDBH() 
        {
            DataBinding conn = new DataBinding();
            string sql10 = string.Format("select count(DDBH) as count from DDBHTemp where DDBH = '{0}'", ddbh);
            SqlCommand cmd10 = new SqlCommand(sql10, conn.connection);
            conn.OpenConnection();
            SqlDataReader reader10 = cmd10.ExecuteReader();
            if (reader10.Read()) //取出訂單號
            {
                ddbhCheck = int.Parse(reader10["count"].ToString());
            }
            conn.CloseConnection();
        }

        #endregion

        #region 增加掃描數

        private void Scanin()
        {
            try
            {
                DataBinding dbConn = new DataBinding();
                DataBinding dbConn1 = new DataBinding();
                string ddbhI = "";
                //string xxcc = "";
                DataBinding dbConn4 = new DataBinding();
                int x = 0;

                DataBinding dbConn3 = new DataBinding();
                //選出訂單號
                string sql3 = string.Format("select DDBH from YWCP where CARTONBAR = '{0}' ", outer);
                SqlCommand cmd3 = new SqlCommand(sql3, dbConn3.connection);
                dbConn3.OpenConnection();
                SqlDataReader reader3 = cmd3.ExecuteReader();
                if (reader3.Read()) //取出訂單號
                {
                    ddbhI = reader3.GetString(0);

                }
                Console.WriteLine(ddbhI);
                dbConn3.CloseConnection();

                //取出CARTONNO
                string sql1 = string.Format("select CARTONNO from YWCP where CARTONBAR = '{0}' ", outer);
                SqlCommand cmd1 = new SqlCommand(sql1, dbConn.connection);
                dbConn.OpenConnection();
                SqlDataReader reader1 = cmd1.ExecuteReader();
                if (reader1.Read()) //取出箱號
                {
                    cartonno = reader1.GetInt32(0);
                }
                Console.WriteLine(cartonno);
                dbConn.CloseConnection();

                //增加掃描數      

                #region 取出XH
                Console.WriteLine("selectXH");
                DataBinding conXH = new DataBinding();
                string xh = "";
                string sqlXH = string.Format("select XH from YWCP where CARTONBAR = '{0}'", cartonbarxh);
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

                string sql4 = string.Format("select count(DDCC) as count from YWBZPOS where DDBH = '{0}' and XH = '{1}'", ddbhI , xh);
                SqlCommand cmd4 = new SqlCommand(sql4, dbConn4.connection);
                dbConn4.OpenConnection();
                SqlDataReader reader4 = cmd4.ExecuteReader();
                if (reader4.Read()) //取出掃描數
                {
                    x = reader4.GetInt32(0);

                }
                dbConn4.CloseConnection();

                Console.WriteLine(x);

                for (int i = 0; i < x; i++)
                {

                    string inn = "";
                    inn = dgvInner.Rows[i].Cells[3].Value.ToString().Trim();


                    Console.WriteLine(inn);
                    Console.WriteLine(tbBarcode.Text);
                    if (inn == tbBarcode.Text.Trim())
                    {
                            Console.WriteLine(inn);

                            int cou = 0;
                            cou = int.Parse(dgvInner.Rows[i].Cells[0].Value.ToString());
                            Console.WriteLine(cou);
                            cou += 1;
                            Console.WriteLine(cou);
                            dgvInner.Rows[i].Cells[0].Value = cou;
                        
                    }


                }
            }
            catch (Exception)
            {
                MessageBox.Show("增加掃描錯誤 Tang loi quet", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Error);                
            }



        }

        #endregion

        #region 載入A表

        private void ATable()
        {
            //string myDateString = myDate.ToString("yyyy-MM-dd HH:mm:ss");
            ds = new DataSet();
            DataBinding dbConnA = new DataBinding();
            try
            {
                if (comboBox1.SelectedIndex == 2)
                {
                    string sqlA = string.Format("select a.DDBH as 訂單編號, a.CARTONNO as 箱號, a.Qty as Qty, c.Article as Article, b.KHPO as 客人PO, case when a.SB = 0 then 'nhap kho moi新入庫' when a.SB = 1 then 'da nhap kho已入庫' when a.SB = 2 then 'nhap kho tai che翻箱入庫' when a.SB = 3 then 'daxuat hang已出貨' when a.SB = 4 then 'nhap kho kiem hang驗貨入庫' when a.SB = 7 then 'Dong hop封箱完成' END as 'Nha nuoc狀態', a.DepNO as 成型部門 from YWCP as a left outer join (select * from ddzl) as b on a.DDBH = b.DDBH left outer join (select * from SMDD where  GXLB = 'A') as c on a.DDBH = c.DDBH where a.LastIndate >= '{0}' and KCBH = '{1}' ORDER BY a.LastIndate DESC", myDate2, cbKCBH.Text);
                    Console.WriteLine(sqlA);
                    SqlDataAdapter adapter = new SqlDataAdapter(sqlA, dbConnA.connection);
                    adapter.Fill(ds, "外箱表");
                    this.dgvOuter.DataSource = this.ds.Tables[0];
                    Console.WriteLine(sqlA);
                }
                else 
                {
                    string sqlA = string.Format("select a.DDBH as 訂單編號, a.CARTONNO as 箱號, a.Qty as Qty, c.Article as Article, b.KHPO as 客人PO, case when a.SB = 0 then 'nhap kho moi新入庫' when a.SB = 1 then 'da nhap kho已入庫' when a.SB = 2 then 'nhap kho tai che翻箱入庫' when a.SB = 3 then 'daxuat hang已出貨' when a.SB = 4 then 'nhap kho kiem hang驗貨入庫' when a.SB = 7 then 'Dong hop封箱完成' END as 'Nha nuoc狀態', a.DepNO as 成型部門 from YWCP as a left outer join (select * from ddzl) as b on a.DDBH = b.DDBH left outer join (select * from SMDD where  GXLB = 'A') as c on a.DDBH = c.DDBH where a.LastIndate >= '{0}' and a.DepNO = '{1}' and KCBH = '{2}' ORDER BY a.LastIndate DESC", myDate2, cbDep.SelectedValue, cbKCBH.Text);
                    Console.WriteLine(sqlA);
                    SqlDataAdapter adapter = new SqlDataAdapter(sqlA, dbConnA.connection);
                    adapter.Fill(ds, "外箱表");
                    this.dgvOuter.DataSource = this.ds.Tables[0];
                    Console.WriteLine(sqlA);
                }

            }
            catch (Exception)
            {
                MessageBox.Show("外箱載入失敗! Tai khong thanh cong!", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                
            }
        }
        #endregion

        #region 顯示缺少領料

        private void LackTake()
        {
            //DialogResult dr = MessageBox.Show("確定要刪除 " + this.dgvBigTypeData.CurrentRow.Cells[1].Value + " 這筆資料嗎?", "系統提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);

            DataBinding conn = new DataBinding();
            DataBinding conn2 = new DataBinding();
            DataBinding conn2d = new DataBinding();
            #region 取出訂單號

            //取出訂單號
            string sql1 = string.Format("select DDBH from YWCP where CARTONBAR = '{0}'", tbBarcode.Text);
            SqlCommand cmd1 = new SqlCommand(sql1, conn2.connection);
            conn2.OpenConnection();
            SqlDataReader reader1 = cmd1.ExecuteReader();
            if (reader1.Read()) //取出訂單號
            {
                ddbh = reader1["DDBH"].ToString();
            }
            //Console.WriteLine(ddbh);
            conn2.CloseConnection();
            Console.WriteLine(ddbh);


            #endregion


            //取出訂單號

            #region 檢查有無此訂單
            int ddbhcheck = 0;

            string sql1d = string.Format("select count(isnull(DDBH,0)) as count from DDZL where DDBH = '{0}'", ddbh);
            Console.WriteLine(sql1d);
            SqlCommand cmd1d = new SqlCommand(sql1d, conn2d.connection);
            conn2d.OpenConnection();
            SqlDataReader reader1d = cmd1d.ExecuteReader();
            if (reader1d.Read()) //取出訂單號
            {
                ddbhcheck = int.Parse(reader1d["count"].ToString());
            }
            Console.WriteLine(ddbhcheck);
            conn2d.CloseConnection();
            #endregion

            if (ddbhcheck > 0)
            {
                string sql10 = string.Format("select isnull(qty,0) as qty from (select min(isnull(kclls.qty, 0)) as qty from zlzls2 left join ddzl on ddzl.ddbh = zlzls2.ZLBH left join XXZL on XXZL.XieXing = DDZL.XieXing and XXZL.SheHao = DDZL.SheHao left join(SELECT xiexing, shehao, bwbh,/*clbh,*/ flbh, MAX(CLTX) AS CLTX FROM(select xx.xiexing, xx.shehao, xx.bwbh, clbh, fl.flbh, xx.cltx from xxzls xx left join xxbwfl fl on fl.xiexing = xx.xiexing and fl.bwbh = xx.bwbh union all select vn.xiexing, vn.shehao, bwbh, clbh, flbh, '0' as cltx from xxzlsvn vn ) VV GROUP BY xiexing, shehao, bwbh, /*clbh,*/ flbh) xv on ZLZLS2.BWBH = xv.BWBH and XXZL.XieXing = xv.XieXing and XXZL.SHEHAO = xv.SHEHAO left join XXBWFLS on xxbwfls.FLBH = Xv.FLBH left join(select KCLLS.SCBH, KCLLS.CLBH, isnull(sum(KCLLS.Qty), 0) as Qty, isnull(KCLLS.DFL, 'N') as DFL from KCLLS where KCLLS.SCBH = '{0}'  and kclls.ckbh = '{1}' and TempQty > 0 group by KCLLS.SCBH, KCLLS.CLBH, KCLLS.DFL) KCLLS on KCLLS.SCBH = zlzls2.ZLBH and KCLLS.CLBH = zlzls2.CLBH and xxbwfls.DFL = kclls.DFL where zlzls2.ZLBH = '{2}' and mjbh = 'ZZZZZZZZZZ' and zlzls2.CLSL > 0 and kclls.DFL in ('C', 'S', 'A') and substring(zlzls2.CLBH, 1, 1) <> 'H' and substring(zlzls2.CLBH, 1, 1) <> 'F' and zlzls2.clbh not like 'HOP%' and zlzls2.clbh not like 'HSL%' and zlzls2.clbh not like 'HTB%' and zlzls2.clbh not like 'HCR%' and zlzls2.clbh not like 'HYL%') as a", ddbh, ckbh, ddbh);
                Console.WriteLine(sql10);
                SqlCommand cmd10 = new SqlCommand(sql10, conn.connection);
                conn.OpenConnection();
                SqlDataReader reader10 = cmd10.ExecuteReader();
                if (reader10.Read()) //取出訂單號
                {
                    data = double.Parse(reader10["qty"].ToString());
                }
                conn.CloseConnection();

                Console.WriteLine(data);
            }
            else
            {
                MessageBox.Show("KHÔNG TÌM THẤY ĐƠN HÀNG, LIÊN HỆ ĐƠN VỊ NGHIỆP VỤ XNK 查無此訂單，請洽業務單位", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        #endregion

        #region 載入部門號

        private void BDepartment()
        {
            try
            {
                DataBinding conn = new DataBinding();
                //驗貨
                string sb = "";
                string sql10 = string.Format("select count(CARTONBAR) as count from YWCP where SB = 4 and CARTONBAR =  '{0}'", tbBarcode.Text);
                SqlCommand cmd10 = new SqlCommand(sql10, conn.connection);
                conn.OpenConnection();
                SqlDataReader reader10 = cmd10.ExecuteReader();
                if (reader10.Read()) //取出訂單號
                {
                    sb = reader10["count"].ToString();
                }

                if (sb == "1")
                {

                }
                else
                {

                    #region 修改YWCP

                    DataBinding con4 = new DataBinding();
                    StringBuilder sql4 = new StringBuilder();
                    sql4.AppendFormat("update YWCP set DepNO = '{0}' where CARTONBAR = '{1}'", cbDep.SelectedValue, tbBarcode.Text);
                    SqlCommand cmd4 = new SqlCommand(sql4.ToString(), con4.connection);
                    con4.OpenConnection();
                    int result4 = cmd4.ExecuteNonQuery();
                    if (result4 == 1)
                    {

                    }
                    con4.CloseConnection();
                }
            }
            catch (Exception) { }

            #endregion


            //#region 檢查訂單

            //DataBinding conn2 = new DataBinding();
            ////取出訂單號
            //string sql102 = string.Format("select count(b.DepNO) as count from YWCP as a left outer join SMDD as b on a.DDBH = b.YSBH where a.CARTONBAR = '{0}' and b.GXLB = 'A' ", tbBarcode.Text);
            //SqlCommand cmd102 = new SqlCommand(sql102, conn2.connection);
            //conn2.OpenConnection();
            //SqlDataReader reader102 = cmd102.ExecuteReader();
            //if (reader102.Read()) //取出訂單號
            //{
            //    a = reader102["count"].ToString();
            //}
            ////Console.WriteLine(ddbh);
            //conn2.CloseConnection();
            ////Console.WriteLine(ddbh);

            //#endregion
            //if (a != "0")
            //{               

            //}


        }



        #endregion

        #region CBDep

        private void CBDep() 
        {
            #region CB載入
                                    
            DataBinding dbconn = new DataBinding();
            string sql1 = string.Format("select * from BDepartment where GSBH='{0}' and PlanYN='1' and useYN='1' and gxlb='A' order by DepName", companycode);
            Console.WriteLine(sql1);
            SqlDataAdapter adapter1 = new SqlDataAdapter(sql1, dbconn.connection);
            adapter1.Fill(dsDep, "倉庫位置");
            this.cbDep.DataSource = dsDep.Tables[0];
            this.cbDep.ValueMember = "ID";
            this.cbDep.DisplayMember = "DepName";


            #endregion
        }

        #endregion

        #region CB方法 

        private void KCBH()
        {
            DataBinding dbconn = new DataBinding();
            string sql1 = "select * from KCZL where YN = 1 and KCCLASS = 2";
            SqlDataAdapter adapter1 = new SqlDataAdapter(sql1, dbconn.connection);
            adapter1.Fill(ds, "倉庫");
            this.cbKCBH.DataSource = ds.Tables[0];
            this.cbKCBH.ValueMember = "KCBH";
            this.cbKCBH.DisplayMember = "KCBH";

            cbKCBH.MaxDropDownItems = 8;
            cbKCBH.IntegralHeight = false;
        }

        #endregion

        #region 更改YWCP倉庫方法

        private void YWCPKCBH()
        {
            DataBinding con4 = new DataBinding();
            StringBuilder sql4 = new StringBuilder();
            sql4.AppendFormat(" update YWCP set KCBH = '{0}' where CARTONBAR = '{1}' ", cbKCBH.Text, outer);
            SqlCommand cmd4 = new SqlCommand(sql4.ToString(), con4.connection);
            con4.OpenConnection();
            int result4 = cmd4.ExecuteNonQuery();
            if (result4 == 1)
            {
                //MessageBox.Show("插入KCBH");
                Console.WriteLine("KCBHKCBH");
            }
            con4.CloseConnection();
        }

        #endregion

        #endregion

        private void TsbDelete_Click(object sender, EventArgs e)
        {   
            DialogResult dr = MessageBox.Show("確定要停用這個外箱嗎? Ban co chac chan muon xoa", "系統提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
            if (dr == DialogResult.OK)
            {
                btnc = 0;
                if (outer == "") //沒綁定外箱
                {
                    MessageBox.Show("未綁定外箱", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Information);                    
                }
                else
                {
                    try
                    {
                        DataBinding dbConn = new DataBinding();
                        
                        #region 取出訂單號

                        //取出訂單號
                        string sql = string.Format("select DDBH from YWCP where CARTONBAR = '{0}' ", outer);
                        SqlCommand cmd = new SqlCommand(sql, dbConn.connection);
                        dbConn.OpenConnection();
                        SqlDataReader reader = cmd.ExecuteReader();
                        if (reader.Read()) //取出訂單號
                        {
                            ddbh = reader.GetString(0);
                        }
                        //Console.WriteLine(ddbh);
                        dbConn.CloseConnection();
                        Console.WriteLine(ddbh);
                        #endregion                                               

                        //取出CARTONNO
                        string sql1 = string.Format("select CARTONNO from YWCP where CARTONBAR = '{0}' ", outer);
                        SqlCommand cmd1 = new SqlCommand(sql1, dbConn.connection);
                        dbConn.OpenConnection();
                        SqlDataReader reader1 = cmd1.ExecuteReader();
                        if (reader1.Read()) //取出箱號
                        {
                            cartonno = reader1.GetInt32(0);
                        }
                        Console.WriteLine(cartonno);

                        dbConn.CloseConnection();

                        //判斷有幾筆資料
                        int a = 0;
                        a = dgvInner.Rows.Count;
                        Console.WriteLine(a);
                        Console.WriteLine(dgvInner.Rows[0].Cells[2].Value.ToString());
                        Console.WriteLine(dgvInner.Rows[0].Cells[3].Value.ToString());
                        a -= 1;
                        //Console.WriteLine(a);

                        //扣除已掃內箱
                        for (int i = 0; i <= a; i++)
                        {
                            DataBinding con5 = new DataBinding();
                            StringBuilder sql5 = new StringBuilder();
                            sql5.AppendFormat("update SCLH set SCQTY = SCQTY - '{0}' where LHLabel = '{1}' and  DDBH = '{2}'", dgvInner.Rows[i].Cells[0].Value.ToString(), dgvInner.Rows[i].Cells[3].Value.ToString(), ddbh);
                            SqlCommand cmd5 = new SqlCommand(sql5.ToString(), con5.connection);
                            con5.OpenConnection();
                            int result5 = cmd5.ExecuteNonQuery();
                            if (result5 == 1)
                            {
                                Console.WriteLine("扣除SCLH");
                            }
                            con5.CloseConnection();
                            
                        }

                        //刪除最後入時間
                        DataBinding con6 = new DataBinding();
                        StringBuilder sql6 = new StringBuilder();
                        sql6.AppendFormat("update YWCP set LastIndate = NULL where CARTONBAR = '{0}'", outer);
                        SqlCommand cmd6 = new SqlCommand(sql6.ToString(), con6.connection);
                        con6.OpenConnection();
                        int result6 = cmd6.ExecuteNonQuery();
                        if (result6 == 1)
                        {
                            
                        }
                        con6.CloseConnection();

                        ATable();

                        int c = 0;
                        c = dgvInner.Rows.Count;
                        Console.WriteLine(c);
                        
                        
                        for (int d = 0; d < c; d++)
                        {
                            dgvInner.Rows.RemoveAt(0);
                        }


                        //dgvOuter.Rows.RemoveAt(0);


                        //解除鎖定
                        Program.Modifytype.modify = "0";


                    }
                    catch(Exception)
                    {
                        MessageBox.Show("刪除失敗 Xoa that bai", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        
                    }
                    outer = "";
                    ddbh = "";
                    tbBarcode.Text = "";
                    lbNumber.Text = "0";
                    count = 0;
                }
            }
        }

        private void CbScanInner_Click(object sender, EventArgs e)
        {
            tbBarcode.Focus();
        }

        private void WHSFGScanin2_KeyDown(object sender, KeyEventArgs e)
        {
            tbBarcode.Focus();
        }

        private void TbBarcode_MouseDown(object sender, MouseEventArgs e)
        {
            tbBarcode.Focus();
        }

        private void DgvOuter_MouseClick(object sender, MouseEventArgs e)
        {
            tbBarcode.Focus();
        }

        private void DgvOuter_MouseUp(object sender, MouseEventArgs e)
        {
            tbBarcode.Focus();
        }

        private void DgvInner_MouseClick(object sender, MouseEventArgs e)
        {
            tbBarcode.Focus();
        }

        private void DgvInner_MouseUp(object sender, MouseEventArgs e)
        {
            tbBarcode.Focus();
        }

        private void CbKCBH_MouseUp(object sender, MouseEventArgs e)
        {
            tbBarcode.Focus();
        }

        private void CbKCBH_SelectedIndexChanged(object sender, EventArgs e)
        {
            tbBarcode.Focus();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            DDBHBACK Form = new DDBHBACK();
            Form.Show();
        }

        private void cbDep_SelectedIndexChanged(object sender, EventArgs e)
        {
            Console.WriteLine(cbDep.SelectedValue);
            tbBarcode.Focus();
        }

        private void cbDep_Click(object sender, EventArgs e)
        {
            tbBarcode.Enabled = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                btnc++;

                if (btnc < 4)
                {
                    if (tbBarcode.Text == "")//誤觸判定
                    {
                    }
                    else//進入掃描事件
                    {
                        try
                        {
                            DataBinding dbConnp = new DataBinding();
                            DataBinding dbConnp2 = new DataBinding();
                            DataBinding dbConnp3 = new DataBinding();
                            //判斷是否領料

                            string sqlp = string.Format("select DDBH from YWCP where CARTONBAR = '{0}' ", tbBarcode.Text);
                            SqlCommand cmdp = new SqlCommand(sqlp, dbConnp.connection);
                            dbConnp.OpenConnection();
                            SqlDataReader readerp = cmdp.ExecuteReader();
                            if (readerp.Read()) //取出箱號
                            {
                                ddbh3 = readerp.GetString(0);
                            }
                            //Console.WriteLine(cartonno);
                            dbConnp.CloseConnection();


                            LackTake();
                            if (data > 0) //有領料
                            {
                                pass = 1;
                                scan();
                            }
                            else
                            {
                                CheckDDBH();
                                if (ddbhCheck == 1) //繞過
                                {
                                    pass = 1;
                                    scan();
                                }
                                else //彈出視窗
                                {
                                    DataBinding conn2 = new DataBinding();

                                    #region 取出訂單號

                                    //取出訂單號
                                    string sql1 = string.Format("select DDBH from YWCP where CARTONBAR = '{0}'", tbBarcode.Text);
                                    SqlCommand cmd1 = new SqlCommand(sql1, conn2.connection);
                                    conn2.OpenConnection();
                                    SqlDataReader reader1 = cmd1.ExecuteReader();
                                    if (reader1.Read()) //取出訂單號
                                    {
                                        ddbh = reader1.GetString(0);
                                    }
                                    //Console.WriteLine(ddbh);
                                    conn2.CloseConnection();
                                    //Console.WriteLine(ddbh);
                                    #endregion

                                    //取出訂單號
                                    DataBinding conn = new DataBinding();
                                    string data = "";
                                    string sql10 = string.Format("select zlzls2.clbh from zlzls2 left join ddzl on ddzl.ddbh=zlzls2.ZLBH left join XXZL on XXZL.XieXing=DDZL.XieXing and XXZL.SheHao=DDZL.SheHao left join ( SELECT xiexing,shehao,bwbh,/*clbh,*/ flbh,MAX(CLTX) AS CLTX FROM (select xx.xiexing,xx.shehao,xx.bwbh,clbh,fl.flbh,xx.cltx from xxzls xx left join xxbwfl fl on fl.xiexing=xx.xiexing and fl.bwbh=xx.bwbh union all select vn.xiexing,vn.shehao,bwbh,clbh,flbh,'0' as cltx from xxzlsvn vn ) VV GROUP BY xiexing,shehao,bwbh, /*clbh,*/ flbh  ) xv on ZLZLS2.BWBH=xv.BWBH and XXZL.XieXing=xv.XieXing and XXZL.SHEHAO=xv.SHEHAO join XXBWFLS on xxbwfls.FLBH=Xv.FLBH left join (select KCLLS.SCBH,KCLLS.CLBH, isnull(sum(KCLLS.Qty),0) as Qty, isnull( KCLLS.DFL,'N') as DFL from  KCLLS where  KCLLS.SCBH= '{0}' and kclls.ckbh='{1}' and TempQty > 0 group by KCLLS.SCBH, KCLLS.CLBH,KCLLS.DFL) KCLLS on KCLLS.SCBH=zlzls2.ZLBH and KCLLS.CLBH=zlzls2.CLBH and xxbwfls.DFL=kclls.DFL where zlzls2.ZLBH = '{2}' and mjbh='ZZZZZZZZZZ' and zlzls2.CLSL > 0  and kclls.DFL in ('C','S','A') and QTY = 0 and substring(zlzls2.CLBH,1,1) <> 'H' and substring(zlzls2.CLBH,1,1) <> 'F' and zlzls2.clbh not like 'HOP%' and zlzls2.clbh not like 'HSL%' and zlzls2.clbh not like 'HTB%' and zlzls2.clbh not like 'HCR%' and zlzls2.clbh not like 'HYL%'", ddbh, ckbh, ddbh);
                                    SqlCommand cmd10 = new SqlCommand(sql10, conn.connection);
                                    conn.OpenConnection();
                                    SqlDataReader reader10 = cmd10.ExecuteReader();
                                    if (reader10.Read()) //取出訂單號
                                    {
                                        data = reader10.GetString(0);
                                    }
                                    MessageBox.Show("此料號" + data + " 未領料。 Đơn hàng này vẫn chưa lãnh, liên hệ Điều độ", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    conn.CloseConnection();
                                }
                            }
                        }
                        catch (Exception)
                        {
                            MessageBox.Show("掃描錯誤 Loi quet", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }

                    }


                    //顯示外箱數
                    int l = 0;
                    l = dgvOuter.Rows.Count;
                    Console.WriteLine(l);
                    lbBOX.Text = l.ToString();
                }
                else
                {
                    MessageBox.Show("手動輸入內盒過多，請刪除外箱後詢問業務 DU LIEU HOP NHAP THU CONG NHIEU LAN, SAU KHI XOA THONG TIN THUNG GOI HOI NGHIEP VU");
                }
            }
            catch (Exception) { }

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                button1.Visible = true;
            }
            else 
            {
                button1.Visible = false;
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == 0) 
            {
                cbDep.Visible = true;
            }
            else if (comboBox1.SelectedIndex == 1)
            {
                cbDep.Visible = true;
            }
            else if (comboBox1.SelectedIndex == 2)
            {
                cbDep.Visible = false;
                tbBarcode.Enabled = true;
                tbBarcode.Focus();
            }
        }

        private void CbKCBH_MouseHover(object sender, EventArgs e)
        {
            tbBarcode.Focus();
        }
    }
}
