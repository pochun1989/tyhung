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
    public partial class InspectionInsert : Form
    {
        public InspectionInsert()
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

                string sql = string.Format("select a.DDBH,Inwarehouse,AllCTN from (select DDBH, COUNT(CARTONBAR) as Inwarehouse from YWCP where SB = 1 and INSPECTCS is not null  group by DDBH) as a left join (select DDBH, COUNT(CARTONBAR) as AllCTN from YWCP group by DDBH) as b on a.DDBH = b.DDBH");

                Console.WriteLine(sql);
                SqlDataAdapter adapter = new SqlDataAdapter(sql, dbConn.connection);
                adapter.SelectCommand.CommandTimeout = 900;
                adapter.Fill(ds, "訂單表");
                dataGridView1.DataSource = this.ds.Tables[0];
            }
            catch (Exception) { }
        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                int a = 0, b = 0;
                a = int.Parse(dataGridView1.CurrentRow.Cells[1].Value.ToString());
                b = int.Parse(dataGridView1.CurrentRow.Cells[2].Value.ToString());
                if (a == b)
                {
                    DataBinding con4 = new DataBinding();
                    StringBuilder sql4 = new StringBuilder();
                    sql4.AppendFormat("update YWDD set cfmdate = GETDATE() where DDBH = '{0}'", dataGridView1.CurrentRow.Cells[0].Value.ToString());
                    Console.WriteLine(sql4);
                    SqlCommand cmd4 = new SqlCommand(sql4.ToString(), con4.connection);

                    con4.OpenConnection();
                    int result4 = cmd4.ExecuteNonQuery();
                    if (result4 == 1)
                    {
                        MessageBox.Show("驗貨確認", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else 
                {
                    MessageBox.Show("尚未入庫完成", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception) { }
        }
    }
}
