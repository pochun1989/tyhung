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
    public partial class WHBIWarehouseDetail : Form
    {
        #region 變數

        public int selectID = 0;
        public string WarehouseID;
        DataSet ds = new DataSet(); // 儲存容器
        public string USERID;
        public string AREA;
        string companycode;

        #endregion

        #region 建構函式

        public WHBIWarehouseDetail()
        {
            InitializeComponent();
        }

        #endregion

        #region 載入

        private void WHBasicInformationWarehouseDetail_Load(object sender, EventArgs e)
        {
            try
            {
                AREA = Program.Area.area;

                if (AREA == "0")
                {
                    companycode = "VTY";
                }
                else if (AREA == "1")
                {
                    companycode = "LYF";
                }
                else if (AREA == "2")
                {
                    companycode = "LPB";
                }


                if (selectID == 0 && WarehouseID == null) // 新增事件
                {

                }
                else // 修改事件
                {
                    tbWHID.Enabled = false;
                }
            }
            catch (Exception) { }
            


        }

        #endregion                               

        #region 方法

        #region 檢查輸入
       
        private bool CheckInput()
        {
            bool ok = true;
            if (tbWarehouseName.Text.Trim().Length == 0)
            {
                MessageBox.Show("內容不可空白!", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                ok = false;
            }
            return ok;
        }

        #endregion

        #region 新增狀態的方法

        private void InsertData()
        {
            USERID = Program.User.userID;

            DataBinding connS = new DataBinding();
            string sqlS = string.Format("select * from KCZL where KCBH = '{0}'", tbWHID.Text);
            SqlCommand cmdS = new SqlCommand(sqlS, connS.connection);
            connS.OpenConnection();
            SqlDataReader readers = cmdS.ExecuteReader();
            if (readers.Read() == true)
            {
                MessageBox.Show("ID重複請重新輸入!", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                
                tbWHID.Text = "";

            }
            else
            {

                DataBinding dbconn = new DataBinding();
                try
                {
                    if (cbWarehouseClass.SelectedIndex == 0)
                    {
                        string sql = string.Format(
                     "insert into KCZL values( '{0}' ,'{1}', '{2}', GETDATE(), '{3}', '1', 'LTY', '1' , GETDATE(), '{4}' )", companycode,
                     tbWHID.Text, tbWarehouseName.Text.Trim(), USERID, USERID);
                        SqlCommand cmd = new SqlCommand(sql, dbconn.connection);
                        dbconn.OpenConnection();
                        int result = cmd.ExecuteNonQuery();
                        if (result == 1)
                        {
                            MessageBox.Show("新增資料成功!", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            
                            this.Close();
                        }

                    }
                    else if (cbWarehouseClass.SelectedIndex == 1)
                    {
                        string sql = string.Format(
                       "insert into KCZL values( '{0}' ,'{1}', '{2}', GETDATE(), '{3}', '1', 'LTY', '4' , GETDATE(), '{4}' )", companycode,
                       tbWHID.Text.Trim(), tbWarehouseName.Text.Trim(), USERID, USERID);
                        SqlCommand cmd = new SqlCommand(sql, dbconn.connection);
                        dbconn.OpenConnection();
                        int result = cmd.ExecuteNonQuery();
                        if (result == 1)
                        {
                            MessageBox.Show("新增資料成功!", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            
                            this.Close();
                        }
                    }
                    else if (cbWarehouseClass.SelectedIndex == 2)
                    {
                        string sql = string.Format(
                         "insert into KCZL values( '{0}' ,'{1}', '{2}', GETDATE(), '{3}', '1', 'LTY', '3' , GETDATE(), '{4}' )", companycode,
                         tbWHID.Text.Trim(), tbWarehouseName.Text.Trim(), USERID, USERID);
                        SqlCommand cmd = new SqlCommand(sql, dbconn.connection);
                        dbconn.OpenConnection();
                        int result = cmd.ExecuteNonQuery();
                        if (result == 1)
                        {
                            MessageBox.Show("新增資料成功!", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            
                            this.Close();
                        }
                    }
                    else if (cbWarehouseClass.SelectedIndex == 3)                       
                    {
                        string sql = string.Format(
                        "insert into KCZL values( '{0}' ,'{1}', '{2}', GETDATE(), '{3}', '1', 'LTY', '4' , GETDATE(), '{4}' )", companycode,
                        tbWHID.Text.Trim(), tbWarehouseName.Text.Trim(), USERID, USERID);
                        SqlCommand cmd = new SqlCommand(sql, dbconn.connection);
                        dbconn.OpenConnection();
                        int result = cmd.ExecuteNonQuery();
                        if (result == 1)
                        {
                            MessageBox.Show("新增資料成功!", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            
                            this.Close();
                        }
                    }
                    else
                    {

                    }

                }
                catch (Exception)
                {
                    MessageBox.Show("添加資料失敗!", "新增錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    dbconn.CloseConnection();
                }
            }
        }
        #endregion
        
        #region 修改狀態的方法

        private void UpdateData()
        {
            DataBinding dbconn = new DataBinding();
            USERID = Program.User.userID;
            try
            {
                if (cbWarehouseClass.SelectedIndex == 0)
                {
                    

                    StringBuilder sql = new StringBuilder();
                    sql.AppendFormat("update KCZL set KCMC ='{0}'", this.tbWarehouseName.Text.Trim());
                    sql.AppendFormat(",KCCLASS = 1");
                    sql.AppendFormat(",USERDATE = GETDATE()");
                    sql.AppendFormat(", USERID = '{0}' ", USERID);
                    sql.AppendFormat(" where KCBH = '{0}'", this.tbWHID.Text);
                    SqlCommand cmd = new SqlCommand(sql.ToString(), dbconn.connection);
                    dbconn.OpenConnection();
                    int result = cmd.ExecuteNonQuery();
                    if (result == 1)
                    {
                        MessageBox.Show("修改資料成功!", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        
                        this.Close();
                    }

                }
                else if(cbWarehouseClass.SelectedIndex == 1)
                {
                    Console.WriteLine("2");
                    StringBuilder sql = new StringBuilder();
                    sql.AppendFormat("update KCZL set KCMC ='{0}'", this.tbWarehouseName.Text.Trim());
                    sql.AppendFormat(",KCCLASS = 2");
                    sql.AppendFormat(",USERDATE = GETDATE()");
                    sql.AppendFormat(", USERID = '{0}'", USERID);
                    sql.AppendFormat(" where KCBH = '{0}'", this.tbWHID.Text);
                    SqlCommand cmd = new SqlCommand(sql.ToString(), dbconn.connection);
                    dbconn.OpenConnection();
                    int result = cmd.ExecuteNonQuery();
                    if (result == 1)
                    {
                        MessageBox.Show("修改資料成功!", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                       
                        this.Close();
                    }
                }
                else if(cbWarehouseClass.SelectedIndex == 2)
                {
                    Console.WriteLine("3");
                    StringBuilder sql = new StringBuilder();
                    sql.AppendFormat("update KCZL set KCMC ='{0}'", this.tbWarehouseName.Text.Trim());
                    sql.AppendFormat(",KCCLASS = 3");
                    sql.AppendFormat(",USERDATE = GETDATE()");
                    sql.AppendFormat(", USERID = '{0}' ", USERID);
                    sql.AppendFormat(" where KCBH = '{0}'", this.tbWHID.Text);
                    SqlCommand cmd = new SqlCommand(sql.ToString(), dbconn.connection);
                    dbconn.OpenConnection();
                    int result = cmd.ExecuteNonQuery();
                    if (result == 1)
                    {
                        MessageBox.Show("修改資料成功!", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        
                        this.Close();
                    }
                }
                else
                {
                    Console.WriteLine("4");
                    StringBuilder sql = new StringBuilder();
                    sql.AppendFormat("update KCZL set KCMC ='{0}'", this.tbWarehouseName.Text.Trim());
                    sql.AppendFormat(",KCCLASS = 4");
                    sql.AppendFormat(",USERDATE = GETDATE()");
                    sql.AppendFormat(", USERID = '{0}' ", USERID);
                    sql.AppendFormat(" where KCBH = '{0}'", this.tbWHID.Text);
                    SqlCommand cmd = new SqlCommand(sql.ToString(), dbconn.connection);
                    dbconn.OpenConnection();
                    int result = cmd.ExecuteNonQuery();
                    if (result == 1)
                    {
                        MessageBox.Show("修改資料成功!", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        
                        this.Close();
                    }
                }

                               
                
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
        
        #endregion

        #region 修改事件

        private void BtnSave_Click_1(object sender, EventArgs e)
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

    }
}
