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
    public partial class WHInspectionDetail : Form
    {
        
        public WHInspectionDetail()
        {
            InitializeComponent();
        }

        #region 變數

        public string CARTONBAR;
        public string DDBH;
        DataSet ds = new DataSet();
        DataSet ds2 = new DataSet();
        DataSet ds3 = new DataSet();
        public string USERID;

        #endregion
        private void WHInspectionDetail_Load(object sender, EventArgs e)
        {
            try
            {

                DataBinding dbConn = new DataBinding();
                string sql = string.Format("select DDCC,QTY from YWBZPOS where CTQ <= '{0}' and CTZ >= '{1}' and DDBH = '{2}' ", CARTONBAR, CARTONBAR, DDBH);
                SqlDataAdapter adapter = new SqlDataAdapter(sql, dbConn.connection);
                adapter.Fill(ds, "訂單表");
                this.dgvCarton.DataSource = this.ds.Tables[0];




            }
            catch (Exception)
            {
            }
        }

    
    }
}
