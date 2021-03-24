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
    public partial class WHBIPalletDetail : Form
    {
        #region 建構函式

        public WHBIPalletDetail()
        {
            InitializeComponent();
        }

        #endregion

        #region 變數

        public int selectID = 0;
        public string WarehouseID;
        DataSet ds = new DataSet(); // 儲存容器
        string maxD  = "";
        int L, W;
        public string USERID;

        #endregion

        #region 畫面載入

        private void WHBIPalletDetail_Load(object sender, EventArgs e)
        {
            USERID = Program.User.userID;
            if (selectID == 0 && WarehouseID == null) // 新增事件
            {
                
            }
            else // 修改事件
            {
                dtpDate.Enabled = false;
                tbNumber.Enabled = false;
                L = int.Parse(tbLength.Text);
                W = int.Parse(tbWidth.Text);
            }


        }


        #endregion

        #region 方法        

        #region 插入日期方法

        private void InsertData()
        {

            DataBinding con = new DataBinding();
            string strSQL1 = string.Format("select * from pallet where Pallet_NO like '{0}{1}{2}%'", dtpDate.Text, tbLength.Text, tbWidth.Text);
            SqlCommand cmda = new SqlCommand(strSQL1, con.connection);
            con.OpenConnection();            
            SqlDataReader reader = cmda.ExecuteReader();

            int result ;

            if (reader.Read() == true) //當天有插入過棧板
            {
                reader.Close();

                DataBinding conn = new DataBinding();
                string sql = string.Format("select * from pallet where Pallet_NO like '{0}{1}{2}%' order by Pallet_NO desc", dtpDate.Text, tbLength.Text, tbWidth.Text);
                SqlCommand cmd = new SqlCommand(sql, conn.connection);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                conn.OpenConnection();


                maxD = dt.Rows[0]["Pallet_NO"].ToString().Trim();
                int a = maxD.Length;
                Console.WriteLine(a);
                Console.WriteLine(maxD);
                Console.WriteLine(maxD.GetType());

                //Console.WriteLine(maxD);
                //maxD = "190529220003";

                Int64 Q = Int64.Parse(maxD);


                DataBinding dbconn = new DataBinding();
                for (int i = 1; i <= int.Parse(tbNumber.Text); i++)
                {
                    dtpDate.CustomFormat = "yy-MM-dd";





                    //double Z = double.Parse(i);


                    //var M = int.Parse(maxD); 

                    string sql1 = string.Format("insert into Pallet values ('{0}','{1}','{2}','{3}','{4}',GETDATE(),'{5}',GETDATE(),'{6}',1,0)", Q + i, tbLength.Text.Trim(), tbWidth.Text.Trim(), tbColor.Text.Trim(), "20" + dtpDate.Text, USERID, USERID);
                    SqlCommand cmd1 = new SqlCommand(sql1, dbconn.connection);
                    dbconn.OpenConnection();
                    result = cmd1.ExecuteNonQuery();
                    if (result == 1)
                    {
                        //MessageBox.Show("新增資料成功!");

                    }


                }
                MessageBox.Show("新增資料成功! Bổ sung thông tin thành công", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                
                reader.Close();
                this.Close();



            }
           
            else //當天沒有插入棧板
            {
                if (tbNumber.TextLength == 1) //數量個位數
                {

                    DataBinding dbconn = new DataBinding();
                    for (int i = 1; i <= int.Parse(tbNumber.Text); i++)
                    {
                        string str = dtpDate.Text + tbLength.Text + tbWidth.Text + "000" + i;
                        string sql1 = string.Format("insert into Pallet values ('{0}','{1}','{2}','{3}','{4}',GETDATE(),'{5}',GETDATE(),'{6}',1,0)", str, tbLength.Text.Trim(), tbWidth.Text.Trim(), tbColor.Text.Trim(), dtpDate.Text,USERID,USERID);
                        SqlCommand cmd1 = new SqlCommand(sql1, dbconn.connection);
                        dbconn.OpenConnection();
                        result = cmd1.ExecuteNonQuery();
                        if (result == 1)
                        {
                            //MessageBox.Show("新增資料成功!");

                        }
                    }
                    MessageBox.Show("新增資料成功! Bổ sung thông tin thành công", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    
                    this.Close();
                }
                else if (tbNumber.TextLength == 2) //數量十位數
                {

                    DataBinding dbconn = new DataBinding();
                    for (int i = 1; i <= int.Parse(tbNumber.Text); i++)
                    {
                        if (i < 10)
                        {
                            string str = dtpDate.Text + tbLength.Text + tbWidth.Text + "000" + i;
                            string sql1 = string.Format("insert into Pallet values ('{0}','{1}','{2}','{3}','{4}',GETDATE(),'{5}',GETDATE(),'{6}',1,0)", str, tbLength.Text.Trim(), tbWidth.Text.Trim(), tbColor.Text.Trim(), dtpDate.Text, USERID,USERID);
                            SqlCommand cmd1 = new SqlCommand(sql1, dbconn.connection);
                            dbconn.OpenConnection();
                            result = cmd1.ExecuteNonQuery();
                            if (result == 1)
                            {
                                //MessageBox.Show("新增資料成功!");

                            }
                        }
                        else
                        {
                            string str = dtpDate.Text + tbLength.Text + tbWidth.Text + "00" + i;
                            string sql1 = string.Format("insert into Pallet values ('{0}','{1}','{2}','{3}','{4}',GETDATE(),'{5}',GETDATE(),'{6}',1,0)", str, tbLength.Text.Trim(), tbWidth.Text.Trim(), tbColor.Text.Trim(), dtpDate.Text, USERID,USERID);
                            SqlCommand cmd1 = new SqlCommand(sql1, dbconn.connection);
                            dbconn.OpenConnection();
                            result = cmd1.ExecuteNonQuery();
                            if (result == 1)
                            {
                                //MessageBox.Show("新增資料成功!");

                            }
                        }
                    }
                    MessageBox.Show("新增資料成功! Bổ sung thông tin thành công", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    
                    this.Close();
                }
                else if (tbNumber.TextLength == 3) //數量百位數
                {

                    DataBinding dbconn = new DataBinding();
                    for (int i = 1; i <= int.Parse(tbNumber.Text); i++)
                    {
                        if (i < 10)
                        {
                            string str = dtpDate.Text + tbLength.Text + tbWidth.Text + "000" + i;
                            string sql1 = string.Format("insert into Pallet values ('{0}','{1}','{2}','{3}','{4}',GETDATE(),'{5}',GETDATE(),'{6}',1,0)", str, tbLength.Text.Trim(), tbWidth.Text.Trim(), tbColor.Text.Trim(), dtpDate.Text, USERID,USERID);
                            SqlCommand cmd1 = new SqlCommand(sql1, dbconn.connection);
                            dbconn.OpenConnection();
                            result = cmd1.ExecuteNonQuery();
                            if (result == 1)
                            {
                                //MessageBox.Show("新增資料成功!");

                            }
                        }
                        else if (i < 100)
                        {
                            string str = dtpDate.Text + tbLength.Text + tbWidth.Text + "00" + i;
                            string sql1 = string.Format("insert into Pallet values ('{0}','{1}','{2}','{3}','{4}',GETDATE(),'{5}',GETDATE(),'{6}',1,0)", str, tbLength.Text.Trim(), tbWidth.Text.Trim(), tbColor.Text.Trim(), dtpDate.Text, USERID,USERID);

                            SqlCommand cmd1 = new SqlCommand(sql1, dbconn.connection);
                            dbconn.OpenConnection();
                            result = cmd1.ExecuteNonQuery();
                            if (result == 1)
                            {
                                //MessageBox.Show("新增資料成功!");
                            }
                        }
                        else
                        {
                            string str = dtpDate.Text + tbLength.Text + tbWidth.Text + "0" + i;
                            string sql1 = string.Format("insert into Pallet values ('{0}','{1}','{2}','{3}','{4}',GETDATE(),'{5}',GETDATE(),'{6}',1,0)", str, tbLength.Text.Trim(), tbWidth.Text.Trim(), tbColor.Text.Trim(), dtpDate.Text, USERID,USERID);
                            SqlCommand cmd1 = new SqlCommand(sql1, dbconn.connection);
                            dbconn.OpenConnection();
                            result = cmd1.ExecuteNonQuery();
                            if (result == 1)
                            {
                                //MessageBox.Show("新增資料成功!");
                            }
                        }
                    }
                    MessageBox.Show("新增資料成功! Bổ sung thông tin thành công", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                   
                    this.Close();
                }
                else if (tbNumber.TextLength == 4) //數量千位數
                {
                    DataBinding dbconn = new DataBinding();
                    for (int i = 1; i <= int.Parse(tbNumber.Text); i++)
                    {
                        if (i < 10)
                        {
                            string str = dtpDate.Text + tbLength.Text + tbWidth.Text + "000" + i;
                            string sql1 = string.Format("insert into Pallet values ('{0}','{1}','{2}','{3}','{4}',GETDATE(),'{5}',GETDATE(),'{6}',1,0)", str, tbLength.Text.Trim(), tbWidth.Text.Trim(), tbColor.Text.Trim(), dtpDate.Text, USERID,USERID);
                            SqlCommand cmd1 = new SqlCommand(sql1, dbconn.connection);
                            dbconn.OpenConnection();
                            result = cmd1.ExecuteNonQuery();
                            if (result == 1)
                            {
                                //MessageBox.Show("新增資料成功!");

                            }
                        }
                        else if (i < 100)
                        {
                            string str = dtpDate.Text + tbLength.Text + tbWidth.Text + "00" + i;
                            string sql1 = string.Format("insert into Pallet values ('{0}','{1}','{2}','{3}','{4}',GETDATE(),'{5}',GETDATE(),'{6}',1,0)", str, tbLength.Text.Trim(), tbWidth.Text.Trim(), tbColor.Text.Trim(), dtpDate.Text, USERID,USERID);
                            SqlCommand cmd1 = new SqlCommand(sql1, dbconn.connection);
                            dbconn.OpenConnection();
                            result = cmd1.ExecuteNonQuery();
                            if (result == 1)
                            {
                                //MessageBox.Show("新增資料成功!");
                            }
                        }
                        else if (i < 1000)
                        {
                            string str = dtpDate.Text + tbLength.Text + tbWidth.Text + "0" + i;
                            string sql1 = string.Format("insert into Pallet values ('{0}','{1}','{2}','{3}','{4}',GETDATE(),'{5}',GETDATE(),'{6}',1,0)", str, tbLength.Text.Trim(), tbWidth.Text.Trim(), tbColor.Text.Trim(), dtpDate.Text, USERID,USERID);
                            SqlCommand cmd1 = new SqlCommand(sql1, dbconn.connection);
                            dbconn.OpenConnection();
                            result = cmd1.ExecuteNonQuery();
                            if (result == 1)
                            {
                                //MessageBox.Show("新增資料成功!");
                            }
                        }
                        else
                        {
                            string str = dtpDate.Text + tbLength.Text + tbWidth.Text + i;
                            string sql1 = string.Format("insert into Pallet values ('{0}','{1}','{2}','{3}','{4}',GETDATE(),'{5}',GETDATE(),'{6}',1,0)", str, tbLength.Text.Trim(), tbWidth.Text.Trim(), tbColor.Text.Trim(), dtpDate.Text, USERID,USERID);
                            SqlCommand cmd1 = new SqlCommand(sql1, dbconn.connection);
                            dbconn.OpenConnection();
                            result = cmd1.ExecuteNonQuery();
                            if (result == 1)
                            {
                                //MessageBox.Show("新增資料成功!");
                            }
                        }
                    }
                    MessageBox.Show("新增資料成功! Bổ sung thông tin thành công", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    
                    this.Close();
                }
            }






            cmda.Dispose();




        }

        #endregion                        

        #region 檢查輸入方法

        /// <summary>
        /// 檢查是否輸入
        /// </summary>
        /// <returns> true過, false不過 </returns>
        private bool CheckInput()
        {
            bool ok = true;
            if (tbLength.Text.Trim().Length == 0 || tbWidth.Text.Trim().Length == 0 || tbColor.Text.Trim().Length == 0)
            {
                MessageBox.Show("內容不可空白! Nội dung không được để trống", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                ok = false;
            }
            return ok;
        }

        #endregion

        #region 修改狀態的方法

        /// <summary>
        /// 修改選取的地點資料
        /// </summary>
        private void UpdateData()
        {
            DataBinding dbconn = new DataBinding();
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendFormat("update Pallet set Pallet_Length ='{0}'", this.tbLength.Text);
                sql.AppendFormat(",Pallet_Width = '{0}'", this.tbWidth.Text);
                sql.AppendFormat(",Pallet_Color = '{0}'", this.tbColor.Text);
                sql.AppendFormat(",USERDATE = GETDATE()");
                sql.AppendFormat(", USERID = '{0}' ", USERID);
                sql.AppendFormat(" where Pallet_NO = '{0}'", this.lbPalletID.Text);
                SqlCommand cmd = new SqlCommand(sql.ToString(), dbconn.connection);
                dbconn.OpenConnection();
                int result = cmd.ExecuteNonQuery();
                if (result == 1)
                {
                    MessageBox.Show("修改資料成功! Sửa đổi dữ liệu thành công", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    
                    this.Close();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("更新資料失敗! Cập nhật dữ liệu thất bại", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                dbconn.CloseConnection();
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
                }
                else // 修改
                {
                    UpdateData();
                }
            }


            
        }

        #endregion        

        #region 離開事件

        private void BtnExit_Click(object sender, EventArgs e)
        {
            this.Close();
            
        }


        #endregion

        #endregion
        
    }
}
