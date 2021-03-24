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
    public partial class WHBIStorageLocationDetail : Form
    {
        #region 變數

        public int selectID = 0;
        public string WarehouseID;
        public string KCBH = "";
        DataSet ds = new DataSet(); // 儲存容器
        DataSet ds2 = new DataSet();
        int a, b;
        public string FSANO;
        public string USERID;
        string warehouse;

        #endregion

        #region 建構函式

        public WHBIStorageLocationDetail()
        {
            InitializeComponent();
        }

        #endregion        

        #region 畫面載入

        private void WHBIStorageLocationDetail_Load(object sender, EventArgs e)
        {
            cbWhname.IntegralHeight = false;

            if (selectID == 0 && WarehouseID == null) // 新增事件
            {
                this.GetComboboxSort();
            }
            else // 修改事件
            {
                a = int.Parse(tbShelfLevel.Text);
                b = int.Parse(tbShelfGrid.Text);
                //cbWarehouseID.Enabled = false;
                lbWHName.Visible = false;
                cbWhname.Visible = false;
                USERID = Program.User.userID;
                cbWhname.Enabled = false;

            }
        }

        #endregion

        #region 方法

        #region 新增FStorageArea狀態的方法

        private void InsertData()
        {
            string WHID = "";
            warehouse = cbWhname.Text;
            USERID = Program.User.userID;

            //取出倉庫號碼
            DataBinding con3 = new DataBinding();
            string strSQL3 = string.Format("select KCBH from KCZL where KCBH = '{0}'", warehouse);
            SqlCommand cmd3 = new SqlCommand(strSQL3, con3.connection);
            con3.OpenConnection();
            SqlDataReader reader3 = cmd3.ExecuteReader();

            if (reader3.Read() == true) //有外箱
            {
                WHID = reader3[0].ToString(); 
            }
            Console.WriteLine(WHID);
            

            DataBinding dbconn = new DataBinding();
            try
            {
                // 判斷MEMO文字
                if (tbMemo.TextLength>0)
                {
                    string sql = string.Format("insert into FStorageArea values( '{0}', '{1}', '{2}', '{3}', '{4}', GETDATE(), '{5}', GETDATE(), '{6}', '1')", warehouse, tbShelfNo.Text.Trim(), tbShelfLevel.Text.Trim(), tbShelfGrid.Text.Trim(), tbMemo.Text, USERID, USERID);
                    Console.WriteLine(sql);
                    SqlCommand cmd = new SqlCommand(sql, dbconn.connection);
                    dbconn.OpenConnection();
                    int result = cmd.ExecuteNonQuery();
                    if (result == 1)
                    {
                        MessageBox.Show("新增資料成功! Bổ sung thông tin thành công", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("新增資料失敗! Dữ liệu mới thất bại", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Error);                        
                    }
                }
                else
                {
                    string sql = string.Format("insert into FStorageArea values( '{0}', '{1}', '{2}', '{3}', NULL, GETDATE(), '{4}', GETDATE(), '{5}', '1')", warehouse, tbShelfNo.Text.Trim(), tbShelfLevel.Text.Trim(), tbShelfGrid.Text.Trim(), USERID, USERID);
                    Console.WriteLine(sql);
                    SqlCommand cmd = new SqlCommand(sql, dbconn.connection);
                    dbconn.OpenConnection();
                    int result = cmd.ExecuteNonQuery();
                    if (result == 1)
                    {
                        MessageBox.Show("新增資料成功! Bổ sung thông tin thành công", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("新增資料失敗! Dữ liệu mới thất bại", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Error);                        
                    }
                }
                    
               

            }
            catch (Exception)
            {
                MessageBox.Show("添加資料失敗! Dữ liệu mới thất bại", "新增錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                dbconn.CloseConnection();
            }
        }





        #endregion

        #region 取得下拉選單方法

        private void GetComboboxSort()
        {
            //DataBinding dbconn = new DataBinding();
            //try
            //{
            //    // 1.讀取類別明細
            //    string sql1 = "select KCBH from KCZL";
            //    SqlDataAdapter adapter1 = new SqlDataAdapter(sql1, dbconn.connection);
            //    adapter1.Fill(ds, "類別明細表");
            //    this.cbWarehouseID.DataSource = ds.Tables[0];
            //    this.cbWarehouseID.ValueMember = "KCBH";
            //    this.cbWarehouseID.DisplayMember = "KCBH";

            //}
            //catch (Exception)
            //{
            //    MessageBox.Show("下拉選單錯誤!");
            //}

            DataBinding dbconn2 = new DataBinding();
            try
            {
                // 1.讀取類別明細
                string sql1 = "select KCMC,KCBH from KCZL where YN = 1";
                SqlDataAdapter adapter2 = new SqlDataAdapter(sql1, dbconn2.connection);
                adapter2.Fill(ds2, "類別明細表");
                this.cbWhname.DataSource = ds2.Tables[0];
                this.cbWhname.ValueMember = "KCBH";
                this.cbWhname.DisplayMember = "KCBH";
                

            }
            catch (Exception)
            {
                MessageBox.Show("下拉選單錯誤!", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                
            }

        }

        #endregion

        #region 檢查輸入
       
        private bool CheckInput()
        {
            bool ok = true;
            if ( tbShelfNo.Text.Trim().Length == 0 || tbShelfLevel.Text.Trim().Length == 0 || tbShelfGrid.Text.Trim().Length == 0 )
            {
                MessageBox.Show("內容不可空白!", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                ok = false;
            }
            return ok;
        }

        #endregion

        #region 新增FStorageAreaDetail狀態的方法

        private void InsertData2()
        {
            string WHID = "";
            warehouse = cbWhname.Text;
            

            //取出倉庫號碼
            DataBinding con3 = new DataBinding();
            string strSQL3 = string.Format("select KCBH from KCZL where KCBH = '{0}'", warehouse);
            SqlCommand cmd3 = new SqlCommand(strSQL3, con3.connection);
            con3.OpenConnection();
            SqlDataReader reader3 = cmd3.ExecuteReader();

            if (reader3.Read() == true) //有外箱
            {
                WHID = reader3[0].ToString();
            }
            Console.WriteLine(WHID);



            USERID = Program.User.userID;
            for (int i = 1; i <= int.Parse(tbShelfLevel.Text); i++)
                {
                    for (int j = 1; j <= int.Parse(tbShelfGrid.Text); j++)
                    {
                        DataBinding conn = new DataBinding();
                        try
                        {
                            string a = Convert.ToString(i);
                            string b = Convert.ToString(j);

                            if (a.Length == 1) 
                            {
                            a = "0" + a;
                            }

                        if (b.Length == 1)
                        {
                            b = "0" + b;
                        }

                        var x =  b + a ;

                            string sql = string.Format("insert into FStorageAreaDetail values( '{0}', '{1}', '{2}', NULL, GETDATE(), '{3}', GETDATE(), '{4}', '1',NULL)", WHID, tbShelfNo.Text.Trim(), x, USERID, USERID);

                            Console.WriteLine(sql);
                            SqlCommand cmd = new SqlCommand(sql, conn.connection);
                            conn.OpenConnection();
                            int result = cmd.ExecuteNonQuery();
                            if (result == 1)
                            {
                                //MessageBox.Show("新增資料成功!");
                                this.Close();
                            }

                        }
                        catch (Exception)
                        {
                            MessageBox.Show("添加資料失敗!", "新增錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        finally
                        {
                            conn.CloseConnection();
                        }
                    }
                }
           
        }





        #endregion        

        #region 修改狀態的方法

        /// <summary>
        /// 修改選取的地點資料
        /// </summary>
        private void UpdateData()
        {
            USERID = Program.User.userID;
            DataBinding dbconn = new DataBinding();
            try
            {                
                if (a > int.Parse(tbShelfLevel.Text) && b > int.Parse(tbShelfGrid.Text)) //兩個都刪除
                {
                    string sql = string.Format("update FStorageAreaDetail set YN = 0, USERID = '{0}', USERDATE = GETDATE() where FSA_NO = '{1}'", USERID, tbShelfNo.Text.Trim());
                    SqlCommand cmd = new SqlCommand(sql, dbconn.connection);
                    dbconn.OpenConnection();
                    int result = cmd.ExecuteNonQuery();
                    dbconn.CloseConnection();

                    for (int i = 1; i <= int.Parse(tbShelfLevel.Text); i++)
                    {
                        for (int j = 1; j <= int.Parse(tbShelfGrid.Text); j++)
                        {

                            try
                            {
                                string a = Convert.ToString(i);
                                string b = Convert.ToString(j);

                                if (a.Length == 1)
                                {
                                    a = "0" + a;
                                }

                                if (b.Length == 1)
                                {
                                    b = "0" + b;
                                }

                                var x = a + b;

                                string sql1 = string.Format("update FStorageAreaDetail set YN = 1, USERID = '{0}', USERDATE = GETDATE() where FSA_NO = '{1}' and FSA_Locate = '{2}'", USERID, tbShelfNo.Text.Trim(), x);
                                SqlCommand cmd1 = new SqlCommand(sql1, dbconn.connection);
                                dbconn.OpenConnection();
                                int result1 = cmd1.ExecuteNonQuery();
                                dbconn.CloseConnection();                              

                            }
                            catch (Exception)
                            {
                                MessageBox.Show("修改資料失敗!", "修改錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            finally
                            {
                                dbconn.CloseConnection();
                            }
                        }
                    }
                    

                }

                else if (a > int.Parse(tbShelfLevel.Text) && b < int.Parse(tbShelfGrid.Text)) //Y增加 X刪除
                {
                    #region 刪除部分
                    Console.WriteLine("Y增加 X刪除");

                    string sql = string.Format("update FStorageAreaDetail set YN = 0 , USERID = '{0}', USERDATE = GETDATE() where  FSA_NO = '{1}'", USERID , tbShelfNo.Text.Trim());

                    Console.WriteLine(sql);

                    SqlCommand cmd = new SqlCommand(sql, dbconn.connection);
                    dbconn.OpenConnection();
                    int result = cmd.ExecuteNonQuery();
                    dbconn.CloseConnection();


                    for (int i = 1; i <= int.Parse(tbShelfLevel.Text); i++)
                    {
                        for (int j = 1; j <= b; j++)
                        {

                            try
                            {
                                string m = Convert.ToString(i);
                                string n = Convert.ToString(j);

                                if (m.Length == 1)
                                {
                                    m = "0" + m;
                                }

                                if (n.Length == 1)
                                {
                                    n = "0" + n;
                                }

                                var x = m + n;

                                string sql2 = string.Format("update FStorageAreaDetail set YN = 1, USERID = '{0}',USERDATE = GETDATE() where FSA_Locate = '{1}' and FSA_NO = '{2}'", USERID, x, tbShelfNo.Text.Trim());

                                Console.WriteLine(sql2);

                                SqlCommand cmd2 = new SqlCommand(sql2, dbconn.connection);
                                dbconn.OpenConnection();
                                int result2 = cmd2.ExecuteNonQuery();
                                dbconn.CloseConnection();
                            }
                            catch (Exception)
                            {
                                MessageBox.Show("修改資料失敗XXX!", "修改錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            finally
                            {
                                dbconn.CloseConnection();
                            }
                        }
                    }

                    #endregion

                    #region 新增部分

                    for (int i = 1; i <= int.Parse(tbShelfLevel.Text); i++)
                    {
                        for (int j = 1; j <= int.Parse(tbShelfGrid.Text); j++)
                        {
                            string m = Convert.ToString(i);
                            string n = Convert.ToString(j);

                            if (m.Length == 1)
                            {
                                m = "0" + m;
                            }

                            if (n.Length == 1)
                            {
                                n = "0" + n;
                            }

                            var x = m + n;

                            DataBinding connF = new DataBinding();
                            string sqlF = string.Format("select count(FSA_NO) as count from FStorageAreaDetail where FSA_Locate = '{0}' and FSA_NO = '{1}' and KCBH = '{2}'", x, tbShelfNo.Text.Trim(), KCBH);
                            SqlCommand cmdF = new SqlCommand(sqlF, connF.connection);
                            SqlDataAdapter sdaF = new SqlDataAdapter(cmdF);
                            DataTable dtF = new DataTable();
                            sdaF.Fill(dtF);
                            connF.OpenConnection();

                            int q;
                            q = int.Parse(dtF.Rows[0]["count"].ToString());

                            Console.WriteLine(q);
                            connF.CloseConnection();

                            if (q > 0) //有這個
                            {
                                string sql4 = string.Format("update FStorageAreaDetail set YN = 1, USERID = '{0}',USERDATE = GETDATE() where FSA_Locate = '{1}' and FSA_NO = '{2}'", USERID, x, tbShelfNo.Text.Trim());

                                Console.WriteLine(sql4);

                                SqlCommand cmd4 = new SqlCommand(sql4, dbconn.connection);
                                dbconn.OpenConnection();
                                int result2 = cmd4.ExecuteNonQuery();
                                dbconn.CloseConnection();

                            }
                            else  //沒重複 新增
                            {
                                DataBinding dbconn3 = new DataBinding();
                                string sql3 = string.Format("insert into FStorageAreaDetail values ( '{0}', '{1}', '{2}', NULL, GETDATE(), '{3}', GETDATE(), '{4}', 1 , NULL)", cbWarehouseID.Text.Trim(), tbShelfNo.Text.Trim(), x, USERID, USERID);

                                Console.WriteLine(sql3);

                                SqlCommand cmd3 = new SqlCommand(sql3, dbconn3.connection);
                                dbconn3.OpenConnection();
                                int result3 = cmd3.ExecuteNonQuery();
                                if (result3 == 1)
                                {
                                    //MessageBox.Show("新增資料成功!"+x);

                                }
                                dbconn3.CloseConnection();

                            }
                            //reader.Close();

                        }
                    }


                    #endregion

                   

                }

                else if (a < int.Parse(tbShelfLevel.Text) && b > int.Parse(tbShelfGrid.Text)) //X增加 Y刪除
                {
                    Console.WriteLine("123456");
                    #region 刪除部分

                    string sql = string.Format("update FStorageAreaDetail set YN = 0 , USERID = '{0}', USERDATE = GETDATE() where  FSA_NO = '{1}'", USERID, tbShelfNo.Text.Trim());
                    SqlCommand cmd = new SqlCommand(sql, dbconn.connection);
                    dbconn.OpenConnection();
                    int result = cmd.ExecuteNonQuery();
                    dbconn.CloseConnection();


                    for (int i = 1; i <= a; i++)
                    {
                        for (int j = 1; j <= int.Parse(tbShelfGrid.Text); j++)
                        {

                            try
                            {
                                string m = Convert.ToString(i);
                                string n = Convert.ToString(j);

                                if (m.Length == 1)
                                {
                                    m = "0" + m;
                                }

                                if (n.Length == 1)
                                {
                                    n = "0" + n;
                                }

                                var x = m + n;
 
                                string sql2 = string.Format("update FStorageAreaDetail set YN = 1 , USERID = '{0}', USERDATE = GETDATE() where FSA_Locate = '{1}' and FSA_NO = '{2}'", USERID, x, tbShelfNo.Text.Trim());
                                SqlCommand cmd2 = new SqlCommand(sql2, dbconn.connection);
                                dbconn.OpenConnection();
                                int result2 = cmd2.ExecuteNonQuery();
                                dbconn.CloseConnection();
                            }
                            catch (Exception)
                            {
                                MessageBox.Show("修改資料失敗XXX!", "修改錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            finally
                            {
                                dbconn.CloseConnection();
                            }
                        }
                    }

                    #endregion

                    #region 新增部分

                    for (int i = 1; i <= int.Parse(tbShelfLevel.Text); i++)
                    {
                        for (int j = 1; j <= int.Parse(tbShelfGrid.Text); j++)
                        {
                            string m = Convert.ToString(i);
                            string n = Convert.ToString(j);

                            if (m.Length == 1)
                            {
                                m = "0" + m;
                            }

                            if (n.Length == 1)
                            {
                                n = "0" + n;
                            }

                            var x = m + n;


                            DataBinding dbconn2 = new DataBinding();
                            string sql2 = string.Format("select count(FSA_NO) as count from FStorageAreaDetail where FSA_Locate = '{0}' and FSA_NO = '{1}' and KCBH = '{2}'", x, tbShelfNo.Text.Trim(), KCBH);
                            SqlCommand cmd2 = new SqlCommand(sql2, dbconn2.connection);
                            dbconn2.OpenConnection();
                            SqlDataReader reader = cmd2.ExecuteReader();
                            if (reader.Read()) //有這個
                            {
                                string sql4 = string.Format("update FStorageAreaDetail set YN = 1, USERID = '{0}',USERDATE = GETDATE() where FSA_Locate = '{1}' and FSA_NO = '{2}'", USERID, x, tbShelfNo.Text.Trim());

                                Console.WriteLine(sql4);

                                SqlCommand cmd4 = new SqlCommand(sql4, dbconn.connection);
                                dbconn.OpenConnection();
                                int result2 = cmd4.ExecuteNonQuery();
                                dbconn.CloseConnection();

                            }
                            else  //沒重複 新增
                            {
                                DataBinding dbconn3 = new DataBinding();
                                string sql3 = string.Format("insert into FStorageAreaDetail values ( '{0}', '{1}', '{2}', NULL, GETDATE(), '{3}', GETDATE(), '{4}', 1, NULL)", cbWarehouseID.Text.Trim(), tbShelfNo.Text.Trim(), x, USERID, USERID);
                                SqlCommand cmd3 = new SqlCommand(sql3, dbconn3.connection);
                                dbconn3.OpenConnection();
                                int result3 = cmd3.ExecuteNonQuery();
                                if (result3 == 1)
                                {
                                    //MessageBox.Show("新增資料成功!" + x);
                                }
                                dbconn3.CloseConnection();

                            }
                            reader.Close();
                            dbconn2.CloseConnection();

                        }
                    }


                    #endregion
                }
                else if (a < int.Parse(tbShelfLevel.Text) && b < int.Parse(tbShelfGrid.Text)) //XY都新增
                {
                    #region 新增部分

                    for (int i = 1; i <= int.Parse(tbShelfLevel.Text); i++)
                    {
                        for (int j = 1; j <= int.Parse(tbShelfGrid.Text); j++)
                        {
                            string m = Convert.ToString(i);
                            string n = Convert.ToString(j);

                            if (m.Length == 1)
                            {
                                m = "0" + m;
                            }

                            if (n.Length == 1)
                            {
                                n = "0" + n;
                            }

                            var x = m + n;


                            DataBinding dbconn2 = new DataBinding();
                            string sql2 = string.Format("select count(FSA_NO) as count from FStorageAreaDetail where FSA_Locate = '{0}' and FSA_NO = '{1}' and KCBH = '{2}'", x, tbShelfNo.Text.Trim(), KCBH);
                            SqlCommand cmd2 = new SqlCommand(sql2, dbconn2.connection);
                            dbconn2.OpenConnection();
                            SqlDataReader reader = cmd2.ExecuteReader();
                            if (reader.Read()) //有這個
                            {
                                string sql4 = string.Format("update FStorageAreaDetail set YN = 1, USERID = '{0}',USERDATE = GETDATE() where FSA_Locate = '{1}' and FSA_NO = '{2}'", USERID, x, tbShelfNo.Text.Trim());

                                Console.WriteLine(sql4);

                                SqlCommand cmd4 = new SqlCommand(sql4, dbconn.connection);
                                dbconn.OpenConnection();
                                int result2 = cmd4.ExecuteNonQuery();
                                dbconn.CloseConnection();

                            }
                            else  //沒重複 新增
                            {
                                DataBinding dbconn3 = new DataBinding();
                                string sql3 = string.Format("insert into FStorageAreaDetail values ( '{0}', '{1}', '{2}', NULL, GETDATE(), '{3}', GETDATE(), '{4}', 1 , NULL)", cbWarehouseID.Text.Trim(), tbShelfNo.Text.Trim(), x, USERID, USERID);
                                SqlCommand cmd3 = new SqlCommand(sql3, dbconn3.connection);
                                dbconn3.OpenConnection();
                                int result3 = cmd3.ExecuteNonQuery();
                                if (result3 == 1)
                                {
                                    //MessageBox.Show("新增資料成功!" + x);

                                }
                                dbconn3.CloseConnection();

                            }
                            reader.Close();
                            dbconn2.CloseConnection();

                        }
                    }


                    #endregion
                }
                else if (a > int.Parse(tbShelfLevel.Text) && b == int.Parse(tbShelfGrid.Text)) //X刪除
                {
                    #region 刪除部分

                    string sql = string.Format("update FStorageAreaDetail set YN = 0 , USERID = '{0}', USERDATE = GETDATE() where  FSA_NO = '{1}'", USERID, tbShelfNo.Text.Trim());
                    SqlCommand cmd = new SqlCommand(sql, dbconn.connection);
                    dbconn.OpenConnection();
                    int result = cmd.ExecuteNonQuery();
                    dbconn.CloseConnection();


                    for (int i = 1; i <= int.Parse(tbShelfLevel.Text); i++)
                    {
                        for (int j = 1; j <= int.Parse(tbShelfGrid.Text); j++)
                        {

                            try
                            {
                                string m = Convert.ToString(i);
                                string n = Convert.ToString(j);

                                if (m.Length == 1)
                                {
                                    m = "0" + m;
                                }

                                if (n.Length == 1)
                                {
                                    n = "0" + n;
                                }

                                var x = m + n;

                                string sql2 = string.Format("update FStorageAreaDetail set YN = 1 ,USERID = '{0}' ,USERDATE = GETDATE where FSA_Locate = '{1}' and FSA_NO = '{2}'", USERID, x, tbShelfNo.Text.Trim());
                                SqlCommand cmd2 = new SqlCommand(sql2, dbconn.connection);
                                dbconn.OpenConnection();
                                int result2 = cmd2.ExecuteNonQuery();
                                dbconn.CloseConnection();
                            }
                            catch (Exception)
                            {
                                MessageBox.Show("修改資料失敗XXX!", "修改錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            finally
                            {
                                dbconn.CloseConnection();
                            }
                        }
                    }

                    #endregion
                    
                }
                else if (a < int.Parse(tbShelfLevel.Text) && b == int.Parse(tbShelfGrid.Text)) //X增加
                {


                    #region 新增部分

                    for (int i = 1; i <= int.Parse(tbShelfLevel.Text); i++)
                    {
                        for (int j = 1; j <= int.Parse(tbShelfGrid.Text); j++)
                        {
                            string m = Convert.ToString(i);
                            string n = Convert.ToString(j);

                            if (m.Length == 1)
                            {
                                m = "0" + m;
                            }

                            if (n.Length == 1)
                            {
                                n = "0" + n;
                            }

                            var x = m + n;

                            DataBinding connF = new DataBinding();
                            string sqlF = string.Format("select count(FSA_NO) as count from FStorageAreaDetail where FSA_Locate = '{0}' and FSA_NO = '{1}' and KCBH = '{2}'", x, tbShelfNo.Text.Trim(), KCBH);
                            SqlCommand cmdF = new SqlCommand(sqlF, connF.connection);
                            SqlDataAdapter sdaF = new SqlDataAdapter(cmdF);
                            DataTable dtF = new DataTable();
                            sdaF.Fill(dtF);
                            connF.OpenConnection();

                            int q;
                            q = int.Parse(dtF.Rows[0]["count"].ToString());

                            Console.WriteLine(q);
                            connF.CloseConnection();

                            if (q > 0) //有這個
                            {
                                string sql4 = string.Format("update FStorageAreaDetail set YN = 1, USERID = '{0}',USERDATE = GETDATE() where FSA_Locate = '{1}' and FSA_NO = '{2}'", USERID, x, tbShelfNo.Text.Trim());

                                Console.WriteLine(sql4);

                                SqlCommand cmd4 = new SqlCommand(sql4, dbconn.connection);
                                dbconn.OpenConnection();
                                int result2 = cmd4.ExecuteNonQuery();
                                dbconn.CloseConnection();

                            }
                            else  //沒重複 新增
                            {
                                DataBinding dbconn3 = new DataBinding();
                                string sql3 = string.Format("insert into FStorageAreaDetail values ( '{0}', '{1}', '{2}', NULL, GETDATE(), '{3}', GETDATE(), '{4}', 1 , NULL)", cbWarehouseID.Text.Trim(), tbShelfNo.Text.Trim(), x, USERID, USERID);

                                Console.WriteLine(sql3);

                                SqlCommand cmd3 = new SqlCommand(sql3, dbconn3.connection);
                                dbconn3.OpenConnection();
                                int result3 = cmd3.ExecuteNonQuery();
                                if (result3 == 1)
                                {
                                    //MessageBox.Show("新增資料成功!"+x);

                                }
                                dbconn3.CloseConnection();

                            }
                            //reader.Close();

                        }
                    }


                    #endregion

                }
                else if (a == int.Parse(tbShelfLevel.Text) && b > int.Parse(tbShelfGrid.Text)) //Y刪除
                {
                    #region 刪除部分

                    string sql = string.Format("update FStorageAreaDetail set YN = 0 ,USERID = '{0}', USERDATE = GETDATE()  where  FSA_NO = '{1}'", USERID, tbShelfNo.Text.Trim());
                    SqlCommand cmd = new SqlCommand(sql, dbconn.connection);
                    dbconn.OpenConnection();
                    int result = cmd.ExecuteNonQuery();
                    dbconn.CloseConnection();


                    for (int i = 1; i <= int.Parse(tbShelfLevel.Text); i++)
                    {
                        for (int j = 1; j <= int.Parse(tbShelfGrid.Text); j++)
                        {

                            try
                            {
                                string m = Convert.ToString(i);
                                string n = Convert.ToString(j);

                                if (m.Length == 1)
                                {
                                    m = "0" + m;
                                }

                                if (n.Length == 1)
                                {
                                    n = "0" + n;
                                }

                                var x = m + n;

                                string sql2 = string.Format("update FStorageAreaDetail set YN = 1, USERID = '{0}', USERDATE = GETDATE() where FSA_Locate = '{1}' and FSA_NO = '{2}'", USERID, x, tbShelfNo.Text.Trim());
                                SqlCommand cmd2 = new SqlCommand(sql2, dbconn.connection);
                                dbconn.OpenConnection();
                                int result2 = cmd2.ExecuteNonQuery();
                                dbconn.CloseConnection();
                            }
                            catch (Exception)
                            {
                                MessageBox.Show("修改資料失敗XXX!", "修改錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            finally
                            {
                                dbconn.CloseConnection();
                            }
                        }
                    }

                    #endregion                    
                }
                else if (a == int.Parse(tbShelfLevel.Text) && b < int.Parse(tbShelfGrid.Text)) //Y新增
                {
                    #region 新增部分

                    for (int i = 1; i <= int.Parse(tbShelfLevel.Text); i++)
                    {
                        for (int j = 1; j <= int.Parse(tbShelfGrid.Text); j++)
                        {
                            string m = Convert.ToString(i);
                            string n = Convert.ToString(j);

                            if (m.Length == 1)
                            {
                                m = "0" + m;
                            }

                            if (n.Length == 1)
                            {
                                n = "0" + n;
                            }

                            var x = m + n;

                            DataBinding connF = new DataBinding();
                            string sqlF = string.Format("select count(FSA_NO) as count from FStorageAreaDetail where FSA_Locate = '{0}' and FSA_NO = '{1}'", x, tbShelfNo.Text.Trim());
                            SqlCommand cmdF = new SqlCommand(sqlF, connF.connection);
                            SqlDataAdapter sdaF = new SqlDataAdapter(cmdF);
                            DataTable dtF = new DataTable();
                            sdaF.Fill(dtF);
                            connF.OpenConnection();

                            int q;
                            q = int.Parse(dtF.Rows[0]["count"].ToString());

                            Console.WriteLine(q);
                            connF.CloseConnection();

                            if (q > 0) //有這個
                            {
                                string sql4 = string.Format("update FStorageAreaDetail set YN = 1, USERID = '{0}',USERDATE = GETDATE() where FSA_Locate = '{1}' and FSA_NO = '{2}'", USERID, x, tbShelfNo.Text.Trim());

                                Console.WriteLine(sql4);

                                SqlCommand cmd4 = new SqlCommand(sql4, dbconn.connection);
                                dbconn.OpenConnection();
                                int result2 = cmd4.ExecuteNonQuery();
                                dbconn.CloseConnection();

                            }
                            else  //沒重複 新增
                            {
                                DataBinding dbconn3 = new DataBinding();
                                string sql3 = string.Format("insert into FStorageAreaDetail values ( '{0}', '{1}', '{2}', NULL, GETDATE(), '{3}', GETDATE(), '{4}', 1 , NULL)", cbWarehouseID.Text.Trim(), tbShelfNo.Text.Trim(), x, USERID, USERID);

                                Console.WriteLine(sql3);

                                SqlCommand cmd3 = new SqlCommand(sql3, dbconn3.connection);
                                dbconn3.OpenConnection();
                                int result3 = cmd3.ExecuteNonQuery();
                                if (result3 == 1)
                                {
                                    //MessageBox.Show("新增資料成功!"+x);

                                }

                                dbconn3.CloseConnection();
                            }
                            //reader.Close();

                        }
                    }


                    #endregion
                }
                else //相等
                { }

                #region 修改部分

                //修改FStorageArea
                string sqlu = string.Format("update FStorageArea set USERDATE = GETDATE(), USERID = '{0}' , MEMO = '{1}', FSA_NO = '{2}' , FSA_Level = '{3}', FSA_Grid = '{4}' where KCBH = '{5}' and FSA_NO = '{6}'", USERID, tbMemo.Text.Trim(), tbShelfNo.Text.Trim(), tbShelfLevel.Text.Trim(), tbShelfGrid.Text.Trim(), cbWarehouseID.Text.Trim(), FSANO);
                SqlCommand cmdu = new SqlCommand(sqlu, dbconn.connection);
                dbconn.OpenConnection();
                int resultu = cmdu.ExecuteNonQuery();
                if (resultu >= 1)
                {
                    //MessageBox.Show("新增資料成功!");

                }
                dbconn.CloseConnection();
                //修改 FStorageAreaDetail
                for (int i = 1; i <= int.Parse(tbShelfLevel.Text); i++)
                {
                    for (int j = 1; j <= int.Parse(tbShelfGrid.Text); j++)
                    {
                        string m = Convert.ToString(i);
                        string n = Convert.ToString(j);

                        if (m.Length == 1)
                        {
                            m = "0" + m;
                        }

                        if (n.Length == 1)
                        {
                            n = "0" + n;
                        }

                        var x = m + n;

                        string sqlD = string.Format("update FStorageAreaDetail set YN = 1 where KCBH = '{0}' and FSA_NO = '{1}' and  FSA_Locate = '{2}'", cbWarehouseID.Text.Trim(), tbShelfNo.Text.Trim(), x);
                        SqlCommand cmdD = new SqlCommand(sqlD, dbconn.connection);
                        dbconn.OpenConnection();
                        int resultD = cmdD.ExecuteNonQuery();
                        if (resultD >= 1)
                        {
                            //MessageBox.Show("新增資料成功!");

                        }
                        dbconn.CloseConnection();
                    }
                }


                #endregion

                MessageBox.Show("修改資料成功!", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                
                this.Close();



            }
            catch (Exception)
            {
                MessageBox.Show("更新資料失敗!", "更新錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                dbconn.CloseConnection();
            }
        }

        #endregion

        #region 插入圖片方法

        private void image2()
        {
            //openFileDialog1.Filter = "jpg|*.JPG|*.png|*.GIF|*.BMP|*.BMP|*";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string fullpath = openFileDialog1.FileName;
                FileStream fs = new FileStream(fullpath, FileMode.Open);
                byte[] imagebytes = new byte[fs.Length];
                BinaryReader br = new BinaryReader(fs);
                imagebytes = br.ReadBytes(Convert.ToInt32(fs.Length));

                DataBinding con = new DataBinding();
                con.OpenConnection();

                string strSql = string.Format("update FStorageAreaDetail set ImageFS = (@ImageList) where KCBH = '{0}' and FSA_NO = '{1}'", KCBH, tbShelfNo.Text.Trim());
                //string strSql = "select ImageFS from FStorageAreaDetail where KCBH = 'A01' and FSA_NO = '1'";
                SqlCommand com = new SqlCommand(strSql, con.connection);

                //SqlCommand com = new SqlCommand("update FStorageAreaDetail set ImageFS = (@ImageList) where KCBH = 'A01' and FSA_NO = 'A2'", con.connection);

                com.Parameters.Add("ImageLIst", SqlDbType.Image);
                com.Parameters["ImageList"].Value = imagebytes;

                Console.WriteLine(strSql);
                com.ExecuteNonQuery();
                con.CloseConnection();
            }

        }

        private void image1()
        {
            //openFileDialog1.Filter = "jpg|*.JPG|*.png|*.GIF|*.BMP|*.BMP|*";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string fullpath = openFileDialog1.FileName;
                FileStream fs = new FileStream(fullpath, FileMode.Open);
                byte[] imagebytes = new byte[fs.Length];
                BinaryReader br = new BinaryReader(fs);
                imagebytes = br.ReadBytes(Convert.ToInt32(fs.Length));

                DataBinding con = new DataBinding();
                con.OpenConnection();

                string strSql = string.Format("update FStorageAreaDetail set ImageFS = (@ImageList) where KCBH = '{0}' and FSA_NO = '{1}'", warehouse, tbShelfNo.Text.Trim());
                //string strSql = "select ImageFS from FStorageAreaDetail where KCBH = 'A01' and FSA_NO = '1'";
                SqlCommand com = new SqlCommand(strSql, con.connection);

                //SqlCommand com = new SqlCommand("update FStorageAreaDetail set ImageFS = (@ImageList) where KCBH = 'A01' and FSA_NO = 'A2'", con.connection);

                com.Parameters.Add("ImageLIst", SqlDbType.Image);
                com.Parameters["ImageList"].Value = imagebytes;

                Console.WriteLine(strSql);
                com.ExecuteNonQuery();
                con.CloseConnection();
            }

        }
        #endregion



        #endregion

        #region 事件

        #region 儲存事件

        private void BtnSave_Click(object sender, EventArgs e)
        {
            if (CheckInput())
            {
                // 判斷目前是新增還是修改狀態
                if (selectID == 0 && WarehouseID == null) // 新增
                {                    
                    InsertData();
                    InsertData2();
                    //image1();


                }
                else // 修改
                {
                    
                    UpdateData();
                    //image2();
                }
            }           
        }

        #endregion

        #region 關閉事件

        private void BtnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #endregion

        #endregion

    }
}
