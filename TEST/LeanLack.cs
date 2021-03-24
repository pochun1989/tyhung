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
    public partial class LeanLack : Form
    {
        public LeanLack()
        {
            InitializeComponent();
        }

        DataSet ds1 = new DataSet();

        private void LeanLack_Load(object sender, EventArgs e)
        {
            try
            {
                ds1 = new DataSet();
                DataBinding dbConn = new DataBinding();

                string sql = string.Format("select * from YWCP where DDBH = '{0}' and SB = '0'", label2.Text);
                Console.WriteLine(sql);
                SqlDataAdapter adapter = new SqlDataAdapter(sql, dbConn.connection);
                adapter.SelectCommand.CommandTimeout = 900;
                adapter.Fill(ds1, "訂單表");
                this.dataGridView1.DataSource = this.ds1.Tables[0];

                dataGridView1.Columns[0].Width = 200;
            }
            catch (Exception) { }
        }
    }
}
