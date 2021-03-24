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
    public partial class YWCPDDBHDetail : Form
    {
        public YWCPDDBHDetail()
        {
            InitializeComponent();
        }

        private void YWCPDDBHDetail_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        #region 變數

        DataSet ds = new DataSet();

        #endregion

        #region 畫面載入

        private void LoadData() 
        {
            try
            {
                ds = new DataSet();
                DataBinding dbConn = new DataBinding();
                string sql = "select distinct b.DDBH,b.indate,b.inspectdate,b.outdate,d.ShipDate,fin2 as box from YWCP as a left join  (select ddbh, count(cartonbar)as fin1 ,min(Indate) as indate, max(INSPECTDATE) as inspectdate,max(OUTDATE) as outdate from ywcp where (sb <> 0 and sb<>3 ) group by ddbh) as b on a.DDBH = b.DDBH left join (select ddbh, count(cartonbar) as fin2 from ywcp group by ddbh) as c on a.DDBH = b.DDBH left join (select ddbh, shipdate, yn from DDZL) as d on a.ddbh = d.ddbh where(fin2 - fin1) = 0 order by ShipDate";
                SqlDataAdapter adapter = new SqlDataAdapter(sql, dbConn.connection);
                adapter.Fill(ds, "棧板表");
                this.dgvOuter.DataSource = this.ds.Tables[0];
            }
            catch (Exception) { }
        }

        #endregion
    }
}
