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
    public partial class DayReportDetail : Form
    {
        #region 建構函式
        public DayReportDetail()
        {
            InitializeComponent();
        }
        #endregion

        #region 變數
        public string style;
        public string ddbh;
        public string date;
        DataSet ds2 = new DataSet();
        #endregion

        #region 方法

        private void CartonData() 
        {
            try
            {                
                ds2 = new DataSet();
                DataBinding dbConn = new DataBinding();
                if (style == "0")
                {
                    string sql = string.Format("select CARTONNO from YWCP where DDBH = '{0}' and LastInDate between DATEADD(DAY,0,'{1}') and DATEADD(DAY, 1,'{2}')", ddbh,date,date);

                    SqlDataAdapter adapter = new SqlDataAdapter(sql, dbConn.connection);
                    adapter.SelectCommand.CommandTimeout = 900;
                    adapter.Fill(ds2, "訂單表");
                    this.dgvCARTON.DataSource = this.ds2.Tables[0];
                }
                else if (style == "1") 
                {
                    string sql = string.Format("select CARTONNO from YWCP where DDBH = '{0}' and OUTDATE between DATEADD(DAY,0,'{1}') and DATEADD(DAY, 1,'{2}')", ddbh,date,date);

                    SqlDataAdapter adapter = new SqlDataAdapter(sql, dbConn.connection);
                    adapter.SelectCommand.CommandTimeout = 900;
                    adapter.Fill(ds2, "訂單表");
                    this.dgvCARTON.DataSource = this.ds2.Tables[0];
                }
                else if (style == "2")
                {
                    string sql = string.Format("select CARTONNO from YWCP where DDBH = '{0}' and INSPECTDATE between DATEADD(DAY,0,'{1}') and DATEADD(DAY, 1,'{2}')", ddbh,date,date);

                    SqlDataAdapter adapter = new SqlDataAdapter(sql, dbConn.connection);
                    adapter.SelectCommand.CommandTimeout = 900;
                    adapter.Fill(ds2, "訂單表");
                    this.dgvCARTON.DataSource = this.ds2.Tables[0];
                }
            }
            catch (Exception) 
            {

            }
        }

        #endregion

        #region 事件

        #endregion

        private void DayReportDetail_Load(object sender, EventArgs e)
        {
            CartonData();
        }

        private void dgvCARTON_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
