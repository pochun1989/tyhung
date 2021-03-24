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
    public partial class LeanDetail : Form
    {
        public LeanDetail()
        {
            InitializeComponent();
        }

        DataSet dsDep = new DataSet();
        DataSet ds1 = new DataSet();
        DataSet ds2 = new DataSet();

        public string AREA;
        string companycode;

        private void LeanDetail_Load(object sender, EventArgs e)
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

        private void tsbQuery_Click(object sender, EventArgs e)
        {
            try
            {
                ds2 = new DataSet();
                DataBinding dbConn = new DataBinding();

                string sql = string.Format("select a.DDBH,CTN,pairs,isnull(b.sb,0) as lack from (select DDBH, count(CARTONBAR) as CTN, SUM(Qty) as pairs from YWCP where DepNO = '{0}' and LastInDate between DATEADD(DAY, 0, '{1}') and DATEADD(DAY, 1, '{2}') and SB != 0 group by DDBH) a left join(select DDBH, COUNT(SB) as sb from YWCP where SB = 0 group by DDBH) as b on a.DDBH = b.DDBH",comboBox1.SelectedValue, dtpFrom.Text,dtpTo.Text);

                Console.WriteLine(sql);
                SqlDataAdapter adapter = new SqlDataAdapter(sql, dbConn.connection);
                adapter.SelectCommand.CommandTimeout = 900;
                adapter.Fill(ds2, "訂單表");
                this.dataGridView1.DataSource = this.ds2.Tables[0];
                label4.Visible = true;
                label6.Visible = true;

                int a = 0,b = 0,c = 0;
                string z, y;
                a = dataGridView1.Rows.Count;
                for (int i = 0; i < a; i++) 
                {
                    b += int.Parse(dataGridView1.Rows[i].Cells[1].Value.ToString());
                    c += int.Parse(dataGridView1.Rows[i].Cells[2].Value.ToString());
                }
                Console.WriteLine(b);
                Console.WriteLine(c);
                z = "" + b;
                y = "" + c;

                label4.Text = z;
                label6.Text = y;
            }
            catch (Exception) { }
        }

        private void tsbExcel_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                ds1 = new DataSet();
                DataBinding dbConn = new DataBinding();

                string sql = string.Format("select CARTONNO as CTN,case when SB =1 then 'NHAP KHO入庫' when SB =2 then 'TAI CHE翻箱' when SB =3 then 'XUAT KHO出庫' when SB =4 then 'KIEM HANG驗貨' when SB =7 then 'HOAN THANH TC封箱完成'  END as 'TRANG THAI狀態',INCS as 'SO LAN NK入庫次數',INDATE as 'NGAY NK L1    第一次入庫日',OUTCS as 'SO LAN TC翻箱次數',OUTDATE as 'NGAY TC翻箱日期',INSPECTCS as 'SO LAN KH驗貨次數',INSPECTDATE as 'NGAY KH驗貨日期', LastInDate as 'NGAY NK CUOI最後入庫日',USERDATE as 'NSD CUOI最後使用日' from YWCP where  DepNO = '{0}' and SB != 0 and LastInDate between DATEADD(DAY,0,'{1}') and DATEADD(DAY,1,'{2}')  and DDBH = '{3}'", comboBox1.SelectedValue, dtpFrom.Text, dtpTo.Text, dataGridView1.CurrentRow.Cells[0].Value.ToString());

                Console.WriteLine(sql);
                SqlDataAdapter adapter = new SqlDataAdapter(sql, dbConn.connection);
                adapter.SelectCommand.CommandTimeout = 900;
                adapter.Fill(ds1, "訂單表");
                this.dataGridView2.DataSource = this.ds1.Tables[0];
            }
            catch (Exception) { }
        }

        private void dataGridView2_SelectionChanged(object sender, EventArgs e)
        {
            try
            {

            }
            catch (Exception) { }
        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                LeanLack Form = new LeanLack();
                Form.label2.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                Form.label3.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
                Form.ShowDialog();
            }
            catch (Exception) { }
        }
    }
}
