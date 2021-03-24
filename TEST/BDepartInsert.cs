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
    public partial class BDepartInsert : Form
    {
        public BDepartInsert()
        {
            InitializeComponent();
        }

        #region 變數

        public string CARTONBAR;
        string ddbh;

        #endregion
        private void BDepartInsert_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                DataBinding conn2 = new DataBinding();
                //取出訂單號
                string sql102 = string.Format("select DDBH from YWCP where CARTONBAR = '{0}'", CARTONBAR);
                SqlCommand cmd102 = new SqlCommand(sql102, conn2.connection);
                conn2.OpenConnection();
                SqlDataReader reader102 = cmd102.ExecuteReader();
                if (reader102.Read()) //取出訂單號
                {
                    ddbh = reader102["DDBH"].ToString();
                }

                #region 修改SMDD
                if (textBox1.Text != "") 
                {
                    DataBinding con4 = new DataBinding();
                    StringBuilder sql4 = new StringBuilder();
                    sql4.AppendFormat("update SMDD set DepNO = '{0}' where DDBH = '{1}' and GXLB = 'A'", textBox1.Text, ddbh);
                    SqlCommand cmd4 = new SqlCommand(sql4.ToString(), con4.connection);
                    con4.OpenConnection();
                    int result4 = cmd4.ExecuteNonQuery();
                    if (result4 == 1)
                    {

                    }
                    con4.CloseConnection();

                    this.Close();
                }

                #endregion


            }
            catch (Exception) 
            {
            }
        }
    }
}
