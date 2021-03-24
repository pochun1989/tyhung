using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TEST
{
    public partial class ChangeScqty : Form
    {
        #region 建構函式

        public ChangeScqty()
        {
            InitializeComponent();
        }

        #endregion

        #region 變數
        public string ddbh, lhlabel, scqty;
        string pass = "31912";

        private void Button1_Click(object sender, EventArgs e)
        {
            if (tbPass.Text == pass)
            {
                updatedata();
                this.Close();
            }
            else
            {
                MessageBox.Show("密碼錯誤 Sai mật khẩu");
                this.Close();
            }
        }
        #endregion

        #region 畫面載入
        private void ChangeScqty_Load(object sender, EventArgs e)
        {
            tbScqty.Text = scqty;
        }

        #endregion

        #region 方法

        #region save

        private void updatedata()
        {
            DataBinding con4 = new DataBinding();
            StringBuilder sql4 = new StringBuilder();
            sql4.AppendFormat(" update SCLH set SCQTY = '{0}' where DDBH = '{1}' and LHLabel = '{2}' ", tbScqty.Text, ddbh,lhlabel);
            SqlCommand cmd4 = new SqlCommand(sql4.ToString(), con4.connection);
            con4.OpenConnection();
            int result4 = cmd4.ExecuteNonQuery();
            if (result4 == 1)
            {

            }
            con4.CloseConnection();
        }

        #endregion
        #endregion

        #region 事件

        #endregion


    }
}
