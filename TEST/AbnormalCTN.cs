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
    public partial class AbnormalCTN : Form
    {
        public AbnormalCTN()
        {
            InitializeComponent();
        }

        DataSet dsDep = new DataSet();
        DataSet ds1 = new DataSet();
        public string AREA;
        string companycode;

        private void AbnormalCTN_Load(object sender, EventArgs e)
        {
            try
            {
                AREA = Program.Area.area;

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

                CBDep();
            }
            catch (Exception) { }
        }

        private void CBDep()
        {
            #region CB載入

            DataBinding dbconn = new DataBinding();
            string sql1 = string.Format("select * from BDepartment where gsbh='{0}' and PlanYN='1' and useYN='1' and gxlb='A' order by DepName", companycode);
            SqlDataAdapter adapter1 = new SqlDataAdapter(sql1, dbconn.connection);
            adapter1.Fill(dsDep, "倉庫位置");
            this.comboBox1.DataSource = dsDep.Tables[0];
            this.comboBox1.ValueMember = "ID";
            this.comboBox1.DisplayMember = "DepName";


            #endregion
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                ds1 = new DataSet();
                DataBinding dbConn = new DataBinding();

                string sql = string.Format("select DDBH,CARTONBAR,INDATE from YWCP where SB = 7 and LastInDate < Convert(varchar(10), Getdate(), 111) and DepNO = '{0}'", comboBox1.SelectedValue);

                Console.WriteLine(sql);
                SqlDataAdapter adapter = new SqlDataAdapter(sql, dbConn.connection);
                adapter.SelectCommand.CommandTimeout = 900;
                adapter.Fill(ds1, "訂單表");
                this.dataGridView1.DataSource = this.ds1.Tables[0];

                label2.Text = dataGridView1.Rows.Count.ToString();
            }
            catch (Exception) { }
        }
    }
}
