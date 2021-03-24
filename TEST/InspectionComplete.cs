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
    public partial class InspectionComplete : Form
    {
        public InspectionComplete()
        {
            InitializeComponent();
        }

        DataSet ds = new DataSet(); // 儲存資料表容器  

        private void tsbQuery_Click(object sender, EventArgs e)
        {
            try
            {
                ds = new DataSet();
                DataBinding dbConn = new DataBinding();

                string sql = string.Format("select ywdd.DDBH,cfmdate from ywdd left join DDZL on YWDD.DDBH = DDZL.DDBH where cfmdate is not null and DDZL.YN != 3 and DDZL.YN != 5");

                Console.WriteLine(sql);
                SqlDataAdapter adapter = new SqlDataAdapter(sql, dbConn.connection);
                adapter.SelectCommand.CommandTimeout = 900;
                adapter.Fill(ds, "訂單表");
                //this.dgvDay.DataSource = this.ds.Tables[0];
            }
            catch (Exception) { }
        }
    }
}
