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
    public partial class WHToday : Form
    {
        #region 建構函式

        public WHToday()
        {
            InitializeComponent();
        }

        #endregion

        #region 變數

        DataSet ds = new DataSet(); // 儲存資料表容器    
        DataSet ds2 = new DataSet();
        public string USERID;

        #endregion

        #region 建構函式

        private void WHToday_Load(object sender, EventArgs e)
        {
            wtoday();
            //order();
        }

        #endregion

        #region 方法

        #region 總表

        private void wtoday()
        {
            ds = new DataSet();
            DataBinding dbConn = new DataBinding();

            string sql = string.Format("select Datename(year,GetDate())+'-'+Datename(month,GetDate())+'-'+Datename(day,GetDate()),count(CARTONBAR) as CTQTY, SUM(QTY) as QTY  from YWCP where LastInDate >= Datename(year,GetDate())+'-'+Datename(month,GetDate())+'-'+Datename(day,GetDate())");

            Console.WriteLine(sql);
            SqlDataAdapter adapter = new SqlDataAdapter(sql, dbConn.connection);
            adapter.SelectCommand.CommandTimeout = 900;
            adapter.Fill(ds, "訂單表");
            this.dgvAll.DataSource = this.ds.Tables[0];

            order();
        }

        #endregion

        #region 訂單

        private void order()
        {
            ds2 = new DataSet();
            DataBinding dbConn = new DataBinding();

            string sql = string.Format("select a.DDBH,a.Pairs,b.CTQTY,b.QTY from DDZL as a left join(select DDBH, count(CARTONBAR) as CTQTY, sum(Qty) as QTY from YWCP where LastInDate >= '2019/08/30' group by DDBH) as b on a.DDBH = b.DDBH where QTY > 0");

            Console.WriteLine(sql);
            SqlDataAdapter adapter = new SqlDataAdapter(sql, dbConn.connection);
            adapter.SelectCommand.CommandTimeout = 900;
            adapter.Fill(ds2, "訂單表");
            this.dgvCartonbar.DataSource = this.ds2.Tables[0];
        }



        #endregion

        #endregion

        private void DgvCartonbar_DoubleClick(object sender, EventArgs e)
        {
            ChangeScqty Form = new ChangeScqty();
            Form.ddbh = dgvAll.CurrentRow.Cells[0].ToString();
            //Form.lhlabel = 
        }
    }
}
