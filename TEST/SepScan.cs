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
    public partial class SepScan : Form
    {
        public SepScan()
        {
            InitializeComponent();
        }

        DataSet ds = new DataSet();
        int a = 0, b = 0;

        private void tbBarcode_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)//如果输入的是回车键
                {
                    a = dataGridView1.RowCount;
                    DataBinding dbConn = new DataBinding();

                    string sql = string.Format("select CARTONBAR,KCBH,FSA_NO,FSA_Locate from (select distinct Pallet_NO, CARTONBAR from PalletDetail where CARTONBAR like '{0}%') as b left join(select * from FStorageAreaDetail ) as a on a.Pallet_NO = b.Pallet_NO order by CARTONBAR", tbBarcode.Text);
                    SqlDataAdapter adapter = new SqlDataAdapter(sql, dbConn.connection);
                    adapter.Fill(ds, "訂單表");
                    this.dataGridView1.DataSource = this.ds.Tables[0];
                    b = dataGridView1.RowCount;



                    if (a == b) 
                    {
                        MessageBox.Show("Vẫn chưa cố định vị trí đặt pallet 並未綁定棧板儲位");
                    }

                    dataGridView1.Columns[0].Width = 150;
                }
            }
            catch (Exception) { }
        }
    }
}
