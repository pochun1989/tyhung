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
    public partial class WHFinBox : Form
    {
        #region 建構函式

        public WHFinBox()
        {
            InitializeComponent();
        }

        #endregion

        #region 變數

        DataSet ds = new DataSet(); // 儲存資料表容器    
        DataSet ds2 = new DataSet();
        public string USERID;
        public string DDBH;
        #endregion

        #region 畫面載入

        private void WHFinBox_Load(object sender, EventArgs e)
        {
            carton();
        }

        #endregion

        private void carton()
        {
            try
            {
                ds = new DataSet();
                DataBinding dbConn = new DataBinding();

                string sql = string.Format("select CARTONNO from YWCP where DDBH = '{0}' and SB = 3 ", DDBH);

                Console.WriteLine(sql);
                SqlDataAdapter adapter = new SqlDataAdapter(sql, dbConn.connection);
                adapter.SelectCommand.CommandTimeout = 900;
                adapter.Fill(ds, "訂單表");
                this.dgvDetail.DataSource = this.ds.Tables[0];
            }
            catch (Exception) { }
        }

    }
}
