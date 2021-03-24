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
    public partial class InspectionFix : Form
    {
        #region 建構函式

        public InspectionFix()
        {
            InitializeComponent();
        }
        #endregion

        #region 變數

        DataSet ds = new DataSet();

        #endregion

        #region 方法

        private void InsertData() 
        {
            try
            {
                DataBinding dbconn = new DataBinding();
                StringBuilder sql = new StringBuilder();
                sql.AppendFormat("update YWCP set SB = '8', OUTDATE = GETDATE(), OUTCS=isnull(OUTCS,0)+1 where CARTONBAR = '{0}'", textBox1.Text);

                SqlCommand cmd = new SqlCommand(sql.ToString(), dbconn.connection);
                dbconn.OpenConnection();
                int result = cmd.ExecuteNonQuery();
                if (result == 1)
                {
                    MessageBox.Show("新增資料成功!");
                }
            }
            catch (Exception) { }
        }

        #endregion

        #region 事件

        #region 畫面載入
        private void InspectionFix_Load(object sender, EventArgs e)
        {

        }

        #endregion

        #endregion

        private void tspClear_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
        }

        private void tspInsert_Click(object sender, EventArgs e)
        {
            InsertData();
            textBox1.Text = "";
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (textBox1.Text != "")
            {
                if (e.KeyCode == Keys.Enter)//如果输入的是回车键
                {
                    InsertData();
                    textBox1.Text = "";
                }
            }
        }

        private void InspectionFix_Shown(object sender, EventArgs e)
        {
            textBox1.Focus();
        }
    }
}
