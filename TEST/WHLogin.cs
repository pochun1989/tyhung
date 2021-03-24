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
    public partial class WHLogin : Form
    {
        public WHLogin()
        {
            InitializeComponent();
        }

        #region 變數

        User user = new User();
        public static string a, b;
        
        #endregion

        #region 登入按鈕
        // 登入按鈕
        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (CheckInput()) // 非空驗證
            {
                if (DBLogin()) // 登入方法(驗證資料庫帳密)
                {
                    Mainpage sp = new Mainpage();
                    sp.Show();
                    sp.WindowState = FormWindowState.Maximized;
                    

                    Program.User.userID = tbAcc.Text;

                    this.Hide();
                    
                }
            }
        }

        #endregion

        #region 離開按鈕

        // 離開按鈕
        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        #endregion

        #region 方法

        #region 帳密非空驗證

        /// <summary>
        /// 帳密驗證null
        /// </summary>
        private bool CheckInput()
        {
            if (tbAcc.Text.Trim() == "" || tbPwd.Text.Trim() == "")
            {
                MessageBox.Show("請輸入帳號與密碼!", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                
                return false;
            }
            return true;
        }

        private void WHLogin_Load(object sender, EventArgs e)
        {
            comboBox1.SelectedIndex = 0;
        }

        private void BtnExit_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void TbPwd_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)//如果输入的是回车键
            {
                if (CheckInput()) // 非空驗證
                {
                    if (DBLogin()) // 登入方法(驗證資料庫帳密)
                    {
                        Mainpage sp = new Mainpage();
                        sp.Show();



                        Program.User.userID = tbAcc.Text;

                        this.Hide();

                    }
                }
            }
        }

        private void WHLogin_Shown(object sender, EventArgs e)
        {
            tbAcc.Focus();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Program.Area.area = comboBox1.SelectedIndex.ToString();

        }


        #endregion

        #region 登入方法

        /// <summary>
        /// 登入方法
        /// </summary>
        /// <returns></returns>
        private bool DBLogin()
        {
            bool flag = false;
            string acc = tbAcc.Text.Trim();
            string pwd = tbPwd.Text.Trim();
            DataBinding dBconnect = new DataBinding();
            try
            {
                // SQL語句(登入)
                string sql = string.Format("select UserID,PWD from Busers where UserID='{0}' and PWD='{1}'", acc, pwd);
                // command命令
                SqlCommand cmd = new SqlCommand(sql, dBconnect.connection);
                // 開資料庫連接
                dBconnect.OpenConnection();
                // 執行
                SqlDataReader reader = cmd.ExecuteReader();
                // 判斷
                if (reader.Read()) // 下一筆資料(列)
                {
                    
                    // 以列開始算(索引以欄)
                    user.userID = reader[0].ToString();
                    

                    user.password = reader[1].ToString();
                    flag = true;


                }
                else
                {
                    MessageBox.Show("帳號密碼有誤!", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Error);                    
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("登入異常 : " + ex.Message);
            }
            finally
            {
                // 關資料庫連接
                dBconnect.CloseConnection();
            }
            return flag;
        }

        #endregion

        #endregion


    }
}
