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
    public partial class WHInspectionForm : Form
    {
        #region 建構函式

        public WHInspectionForm()
        {
            InitializeComponent();
        }

        #endregion

        #region 變數

        DataSet ds = new DataSet();
        DataSet ds2 = new DataSet();
        DataSet ds3 = new DataSet();
        public string USERID;
        int x = 0;

        #endregion

        #region 畫面載入
        private void WHInspectionForm_Load(object sender, EventArgs e)
        {
            pallet();
        }
        #endregion

        private void pallet()
        {
            try
            {
                DataBinding dbConn = new DataBinding();
                string sql = string.Format("select c.FSA_NO,c.FSA_Locate,c.Pallet_NO,count(b.CARTONBAR) as amount from YWCP as a left join (select * from PalletDetail )as b on a.CARTONBAR = b.CARTONBAR left join FStorageAreaDetail as c on b.Pallet_NO = c.Pallet_NO where a.SB = 6 and a.DDBH = '{0}' group by c.Pallet_NO,c.FSA_NO,c.FSA_Locate order by c.Pallet_NO ", lblOrder.Text);
                SqlDataAdapter adapter = new SqlDataAdapter(sql, dbConn.connection);
                adapter.Fill(ds, "訂單表");
                this.dgvPallet.DataSource = this.ds.Tables[0];

                int b;
                b = dgvPallet.Width;
                dgvPallet.Columns[0].FillWeight = b / 8;
                dgvPallet.Columns[1].FillWeight = b / 8;
                dgvPallet.Columns[2].FillWeight = b / 8 * 3;

                DataBinding dbConn2 = new DataBinding();
                string sql2 = string.Format("select a.CARTONBAR,a.Qty,a.LastInDate  from YWCP as a left join (select * from PalletDetail )as b on a.CARTONBAR = b.CARTONBAR where a.SB = 6 and a.DDBH = '{0}' and b.Pallet_NO = '{1}' order by a.CARTONBAR", lblOrder.Text, dgvPallet.CurrentRow.Cells[2].Value.ToString());
                SqlDataAdapter adapter2 = new SqlDataAdapter(sql2, dbConn2.connection);
                adapter2.Fill(ds2, "訂單表");
                this.dgvDetail.DataSource = this.ds2.Tables[0];

                int a;
                a = dgvDetail.Width;
                dgvDetail.Columns[0].FillWeight = a / 2;
                dgvDetail.Columns[1].FillWeight = a / 8;
                dgvDetail.Columns[2].FillWeight = a / 8 * 3;

            }
            catch (Exception) { }
        }

        private void DgvPallet_SelectionChanged(object sender, EventArgs e)
        {
            
        }

        private void DgvPallet_Click(object sender, EventArgs e)
        {
            int Z;
            Z = dgvDetail.Rows.Count;
            for (int i = 0; i < Z-1; i++)
            {
                dgvDetail.Rows.RemoveAt(0);
            }
            try
            {              

                DataBinding dbConn = new DataBinding();
                string sql = string.Format("select a.CARTONBAR,a.Qty,a.LastInDate  from YWCP as a left join (select * from PalletDetail )as b on a.CARTONBAR = b.CARTONBAR where a.SB = 6 and a.DDBH = '{0}' and b.Pallet_NO = '{1}' order by a.CARTONBAR", lblOrder.Text, dgvPallet.CurrentRow.Cells[2].Value.ToString());
                SqlDataAdapter adapter = new SqlDataAdapter(sql, dbConn.connection);
                adapter.Fill(ds2, "訂單表");
                this.dgvDetail.DataSource = this.ds2.Tables[0];

                int a;
                a = dgvDetail.Width;
                dgvDetail.Columns[0].FillWeight = a/2;
                dgvDetail.Columns[1].FillWeight = a/8;
                dgvDetail.Columns[2].FillWeight = a/8*3;

            }
            catch (Exception) { }
        }

        private void BtnScan_Click(object sender, EventArgs e)
        {
            IDCHECK al = new IDCHECK();
            al.DDBH = lblOrder.Text;
            al.SCCLASS = "4";
            al.ShowDialog();
        }

        private void DgvDetail_MouseHover(object sender, EventArgs e)
        {
            
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            WHScanCode al = new WHScanCode();
            al.ShowDialog();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            WHScanCamera2 al = new WHScanCamera2();
            al.ShowDialog();
        }
    }
}
