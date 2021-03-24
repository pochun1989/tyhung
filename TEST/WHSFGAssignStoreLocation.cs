using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TEST
{
    public partial class WHSFGAssignStoreLocation : Form
    {
        #region 變數

        public string USERID;
        public string PalletNO = "";

        #endregion

        #region 建構函式

        public WHSFGAssignStoreLocation()
        {
            InitializeComponent();

            cbShelfNumber.IntegralHeight = false;
            cbUsefulStorage.IntegralHeight = false;

            cbShelfNumber.DataSource = SelectCBShelf();//綁定數據
            cbShelfNumber.DisplayMember = "FSA_NO";//下拉列表中顯示的值
            cbShelfNumber.ValueMember = "FSA_NO";//綁定的值增加刪除用

           

        }

        #endregion

        #region CBShelf方法

        public DataTable SelectCBShelf()
        {
            double a = 0, b = 0, c = 0;

            DataBinding dbConn1 = new DataBinding();
            string sql1 = string.Format("select COUNT(FSA_Locate) as count from FStorageAreaDetail where KCBH = '{0}'", cbKCBH.Text.Trim());
            Console.WriteLine(sql1);
            SqlCommand cmd1 = new SqlCommand(sql1, dbConn1.connection);
            dbConn1.OpenConnection();
            SqlDataReader reader1 = cmd1.ExecuteReader();
            if (reader1.Read())
            {
                a = double.Parse(reader1["count"].ToString());
            }
            dbConn1.CloseConnection();

            DataBinding dbConn2 = new DataBinding();
            string sql2 = string.Format("select COUNT(FSA_Locate) as count from FStorageAreaDetail where KCBH = '{0}' and Pallet_NO is not null", cbKCBH.Text.Trim());
            Console.WriteLine(sql2);
            SqlCommand cmd2 = new SqlCommand(sql2, dbConn2.connection);
            dbConn2.OpenConnection();
            SqlDataReader reader2 = cmd2.ExecuteReader();
            if (reader2.Read())
            {
                b = double.Parse(reader2["count"].ToString());
            }
            dbConn2.CloseConnection();

            c = b / a;

            if (c > 0.9)
            {
                DataBinding conn = new DataBinding();
                string sql = string.Format("select b.FSA_NO from KCZL as a left outer join (select * from FStorageArea where YN = '1') as b  on a.KCBH = b.KCBH where KCCLASS = '2' and b.YN = '1' and a.YN = '1' and a.KCBH = '{0}'", cbKCBH.Text.Trim());
                SqlCommand cmd = new SqlCommand(sql, conn.connection);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                cmd.Dispose();
                return dt;
            }
            else 
            {
                DataBinding conn = new DataBinding();
                string sql = string.Format("select b.FSA_NO from KCZL as a left outer join (select * from FStorageArea where YN = '1') as b  on a.KCBH = b.KCBH where KCCLASS = '2' and b.YN = '1' and a.YN = '1' and a.KCBH = '{0}' and FSA_NO not like 'T%'", cbKCBH.Text.Trim());
                SqlCommand cmd = new SqlCommand(sql, conn.connection);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                cmd.Dispose();
                return dt;
            }


        }

        #endregion

        #region CBUseful方法

        public DataTable SelectCBUseful0()
        {

            DataBinding conn1 = new DataBinding();
            string sql1 = string.Format("select distinct a.KCBH from FStorageArea as a left outer join KCZL as b on a.KCBH = b.KCBH where KCCLASS = 2");
            SqlCommand cmd1 = new SqlCommand(sql1, conn1.connection);
            SqlDataAdapter sda1 = new SqlDataAdapter(cmd1);
            DataTable dt1 = new DataTable();
            sda1.Fill(dt1);
            cmd1.Dispose();
            return dt1;
        }



        public DataTable SelectCBUseful()
        {

            DataBinding conn1 = new DataBinding();
            string sql1 = string.Format("select FSA_Locate from FStorageAreaDetail  where (Pallet_NO is NULL) AND FSA_NO = '{0}' AND YN = '1'  and KCBH = '{1}'", cbShelfNumber.Text.Trim(), cbKCBH.Text.Trim());
            SqlCommand cmd1 = new SqlCommand(sql1, conn1.connection);
            SqlDataAdapter sda1 = new SqlDataAdapter(cmd1);
            DataTable dt1 = new DataTable();
            sda1.Fill(dt1);
            cmd1.Dispose();
            return dt1;
        }

        public DataTable SelectCBUseful2()
        {
            
                
                DataBinding conn1 = new DataBinding();
                string sql1 = string.Format("select FSA_Locate from FStorageAreaDetail  where (Pallet_NO is NULL) AND FSA_NO = '{0}'", cbShelfNumber.Text.Trim());
                SqlCommand cmd1 = new SqlCommand(sql1, conn1.connection);
                SqlDataAdapter sda1 = new SqlDataAdapter(cmd1);
                DataTable dt1 = new DataTable();
                sda1.Fill(dt1);
                cmd1.Dispose();                
            
            return dt1;
        }

        public DataTable SelectCBUseful3()
        {
            double a = 0; 
            double b = 0;

            DataBinding dbConn4 = new DataBinding();
            string sql4 = string.Format("select a.KCBH,C,D from( (select KCBH, COUNT(FSA_Locate) as C from FStorageAreaDetail where KCBH = '{0}' group by KCBH)a left join(select KCBH, COUNT(FSA_Locate) as D from FStorageAreaDetail where KCBH = '{0}' and Pallet_NO is null group by KCBH)b on a.KCBH = b.KCBH) ", cbKCBH.Text.Trim());
            Console.WriteLine(sql4);
            SqlCommand cmd4 = new SqlCommand(sql4, dbConn4.connection);
            dbConn4.OpenConnection();
            SqlDataReader reader4 = cmd4.ExecuteReader();
            if (reader4.Read())
            {
                a = double.Parse(reader4["C"].ToString());
                b = double.Parse(reader4["D"].ToString());
            }
            dbConn4.CloseConnection();

            Console.WriteLine(a + "/" + b);
            Console.WriteLine(b / a);

            if (b / a > 0.9)
            {
                DataBinding conn1 = new DataBinding();
                string sql1 = string.Format("select distinct FSA_NO from FStorageAreaDetail where KCBH = '{0}' and YN = 1", cbKCBH.Text.Trim());
                SqlCommand cmd1 = new SqlCommand(sql1, conn1.connection);
                SqlDataAdapter sda1 = new SqlDataAdapter(cmd1);
                DataTable dt1 = new DataTable();
                sda1.Fill(dt1);
                cmd1.Dispose();
                return dt1;
            }
            else 
            {
                DataBinding conn1 = new DataBinding();
                string sql1 = string.Format("select distinct FSA_NO from FStorageAreaDetail where KCBH = '{0}' and YN = 1 and FSA_NO not like 'T%'", cbKCBH.Text.Trim());
                SqlCommand cmd1 = new SqlCommand(sql1, conn1.connection);
                SqlDataAdapter sda1 = new SqlDataAdapter(cmd1);
                DataTable dt1 = new DataTable();
                sda1.Fill(dt1);
                cmd1.Dispose();
                return dt1;
            }

        }

        #endregion

        #region 選出儲存格

        private void CbShelfNumber_SelectionChangeCommitted(object sender, EventArgs e)
        {
            
        }

        #endregion
        

        #region 關閉按鈕

        private void TsbExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        #endregion

        #region 清空按鈕

        private void TspClear_Click(object sender, EventArgs e)
        {
            tbPalletNumber.Text = "";
        }

        #endregion

        #region 新增按鈕

        private void TspInsert_Click(object sender, EventArgs e)
        {
            InsertData();
        }

        #endregion

        #region 重整

        private void reload()
        {
            cbUsefulStorage.DataSource = SelectCBUseful();//綁定數據
            cbUsefulStorage.DisplayMember = "FSA_Locate";//下拉列表中顯示的值
            cbUsefulStorage.ValueMember = "FSA_Locate";//綁定的值增加刪除用
        }


        #endregion

        #region InsertData

        private void InsertData()
        {
            DataBinding dbconn = new DataBinding();
            try
            {
                Console.WriteLine("0");
                DataBinding dbconn1 = new DataBinding();
                //檢查棧板是否使用中
                string sql = string.Format("select * from Pallet where YN = '1' and Usered = '1' and Pallet_NO = '{0}'", tbPalletNumber.Text.Trim());
                SqlCommand cmd = new SqlCommand(sql, dbconn1.connection);
                dbconn1.OpenConnection();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    dbconn1.CloseConnection();
                    Console.WriteLine("1");
                    //檢查棧板是否以綁定
                    string sql1 = string.Format("select Pallet_NO from FStorageAreaDetail where Pallet_NO = '{0}' ", tbPalletNumber.Text);
                    SqlCommand cmd1 = new SqlCommand(sql1, dbconn1.connection);
                    dbconn1.OpenConnection();
                    SqlDataReader reader1 = cmd1.ExecuteReader();
                    if (reader1.Read())
                    {
                        MessageBox.Show("重複綁定!", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        
                        tbPalletNumber.Text = "";
                    }
                    else
                    {
                        Console.WriteLine("0");
                        //綁定儲位
                        string sql2 = string.Format(
                            "UPDATE FStorageAreaDetail SET Pallet_NO = '{0}' ,USERID = '{1}', USERDATE = GETDATE() WHERE FSA_Locate = '{2}' AND FSA_NO = '{3}' and KCBH = '{4}'", tbPalletNumber.Text, USERID, cbUsefulStorage.Text, cbShelfNumber.Text, cbKCBH.Text);

                        SqlCommand cmd2 = new SqlCommand(sql2, dbconn.connection);
                        dbconn.OpenConnection();
                        int result2 = cmd2.ExecuteNonQuery();
                        if (result2 == 1)
                        {
                            MessageBox.Show("新增資料成功! Đã thêm thành công", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Information);                            
                        }

                    }                   

                }
                else
                {
                    MessageBox.Show("棧板未使用，請重新掃描 Pallet trống", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    
                    tbPalletNumber.Text = "";
                }

            }
            catch (Exception)
            {
                MessageBox.Show("綁定儲位失敗! Thất bại", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                dbconn.CloseConnection();
            }
        }


        #endregion

        private void WHSFGAssignStoreLocation_Load(object sender, EventArgs e)
        {
            tbPalletNumber.Text = PalletNO;

            USERID = Program.User.userID;
            DataSet ds = new DataSet();
            ds = new DataSet();
            DataBinding dbConn = new DataBinding();
            try
            {
                cbKCBH.DataSource = SelectCBUseful0();//綁定數據
                cbKCBH.DisplayMember = "KCBH";//下拉列表中顯示的值
                cbKCBH.ValueMember = "KCBH";//綁定的值增加刪除用

                cbKCBH.MaxDropDownItems = 8;
                cbKCBH.IntegralHeight = false;
                cbShelfNumber.MaxDropDownItems = 8;
                cbShelfNumber.IntegralHeight = false;
                cbUsefulStorage.MaxDropDownItems = 8;
                cbUsefulStorage.IntegralHeight = false;



            }
            catch (Exception)
            {
                MessageBox.Show("載入失敗! Thất bại", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                
            }
        }

        private void TbPalletNumber_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)//如果输入的是回车键
            {
                InsertData();
                reload();
                tbPalletNumber.Text = "";

            }                
        }

        private void CbShelfNumber_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbUsefulStorage.Text = "";
            cbUsefulStorage.DataSource = SelectCBUseful();//綁定數據
            cbUsefulStorage.DisplayMember = "FSA_Locate";//下拉列表中顯示的值
            cbUsefulStorage.ValueMember = "FSA_Locate";//綁定的值增加刪除用
            picture();
        }

        #region 讀取圖片方法

        private void picture()
        {
            //try
            //{
            //    DataBinding conn = new DataBinding();
            //    string strSql = string.Format("select ImageFS from FStorageAreaDetail where FSA_NO = '{0}' ", cbShelfNumber.Text.Trim(), cbUsefulStorage.Text.Trim());
            //    //string strSql = "select ImageFS from FStorageAreaDetail where KCBH = 'A01' and FSA_NO = '1'";
            //    SqlCommand cmd = new SqlCommand(strSql, conn.connection);
            //    conn.OpenConnection();
            //    SqlDataReader reader = cmd.ExecuteReader();
            //    reader.Read();
            //    MemoryStream ms = new MemoryStream((byte[])reader["ImageFS"]);

            //    Console.WriteLine(strSql);

            //    Image image = Image.FromStream(ms, true);
            //    reader.Close();
            //    conn.CloseConnection();
            //    pictureBox1.Image = image;
            //}
            //catch (Exception)
            //{

            //}




            //byte[] imagebytes = null;
            //DataBinding con = new DataBinding();
            //con.OpenConnection();
            //SqlCommand com = new SqlCommand("select ImageFS from FStorageAreaDetail where KCBH = 'A01' and FSA_NO = '1' ", con.connection);
            //SqlDataReader dr = com.ExecuteReader();
            //while (dr.Read())
            //{
            //    imagebytes = (byte[])dr.GetValues(1);
            //}
            //dr.Close();
            //com.Clone();
            //con.CloseConnection();
            //MemoryStream ms = new MemoryStream(imagebytes);
            //Bitmap bmpt = new Bitmap(ms);
            //pictureBox1.Image = bmpt;
                       

        }

        #endregion

        private void CbUsefulStorage_SelectedIndexChanged(object sender, EventArgs e)
        {
            picture();
        }

        private void CbKCBH_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbShelfNumber.DataSource = SelectCBUseful3();//綁定數據
            cbShelfNumber.DisplayMember = "FSA_NO";//下拉列表中顯示的值
            cbShelfNumber.ValueMember = "FSA_NO";//綁定的值增加刪除用
        }
    }
}
