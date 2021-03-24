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
    public partial class DDBHBACK : Form
    {
        public DDBHBACK()
        {
            InitializeComponent();
        }

        private void DDBHBACK_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox2.Text =="31912" )
                {
                    int result;
                    DataBinding dbconn = new DataBinding();
                    string sql1 = string.Format("insert into DDBHTemp values('{0}')", textBox1.Text);
                    SqlCommand cmd1 = new SqlCommand(sql1, dbconn.connection);
                    dbconn.OpenConnection();
                    result = cmd1.ExecuteNonQuery();
                    if (result == 1)
                    {
                        MessageBox.Show("新增資料成功! Bổ sung thông tin thành công", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else 
                {

                }
            }
            catch (Exception) { }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox2.Text == "31912")
                {
                    int result;
                    DataBinding dbconn = new DataBinding();
                    string sql1 = string.Format("delete DDBHTemp where DDBH = '{0}'", textBox1.Text);
                    SqlCommand cmd1 = new SqlCommand(sql1, dbconn.connection);
                    dbconn.OpenConnection();
                    result = cmd1.ExecuteNonQuery();
                    if (result == 1)
                    {
                        MessageBox.Show("刪除資料成功! Bổ sung thông tin thành công", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else 
                {

                }
            }
            catch (Exception) { }
        }
    }
}
