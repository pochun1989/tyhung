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
    public partial class FSALOCATION : Form
    {
        public FSALOCATION()
        {
            InitializeComponent();
        }

        DataSet ds = new DataSet();
        DataSet ds2 = new DataSet();
        DataSet ds3 = new DataSet();

        private void FSALOCATION_Load(object sender, EventArgs e)
        {
            warehouse();
            ShelfNo();
            //Level();
        }

        #region 方法

        #region 倉庫

        private void warehouse()
        {
            DataBinding dbconn = new DataBinding();
            string sql1 = "select * from KCZL where KCCLASS = '2'";
            SqlDataAdapter adapter1 = new SqlDataAdapter(sql1, dbconn.connection);
            adapter1.Fill(ds, "倉庫位置");
            this.comboBox1.DataSource = ds.Tables[0];
            this.comboBox1.ValueMember = "KCBH";
            this.comboBox1.DisplayMember = "KCBH";
            dbconn.CloseConnection();
        }

        #endregion

        #region 貨架

        private void ShelfNo() 
        {
            DataBinding dbconn = new DataBinding();
            string sql1 = string.Format("select distinct FSA_NO from FStorageAreaDetail where KCBH = '{0}'", comboBox1.Text);
            SqlDataAdapter adapter1 = new SqlDataAdapter(sql1, dbconn.connection);
            adapter1.Fill(ds2, "倉庫位置");
            this.comboBox2.DataSource = ds2.Tables[0];
            this.comboBox2.ValueMember = "FSA_NO";
            this.comboBox2.DisplayMember = "FSA_NO";
            dbconn.CloseConnection();


            comboBox2.MaxDropDownItems = 8;
            comboBox2.IntegralHeight = false;
        }

        #endregion

        #region 層數

        private void Level() 
        {
            DataBinding dbconn = new DataBinding();
            string sql1 = string.Format("select distinct SUBSTRING( FSA_Locate,1,2) as FSA_Locate from FStorageAreaDetail where FSA_NO  = '{0}'", comboBox2.Text);
            SqlDataAdapter adapter1 = new SqlDataAdapter(sql1, dbconn.connection);
            adapter1.Fill(ds3, "倉庫位置");
            this.comboBox3.DataSource = ds3.Tables[0];
            this.comboBox3.ValueMember = "FSA_Locate";
            this.comboBox3.DisplayMember = "FSA_Locate";
            dbconn.CloseConnection();

            comboBox3.MaxDropDownItems = 8;
            comboBox3.IntegralHeight = false;
        }

        #endregion


        #endregion


        private void button1_Click(object sender, EventArgs e)
        {
            ds = new DataSet();
            DataBinding dbConn = new DataBinding();
            string sql = string.Format("select distinct a.FSA_Locate,a.Pallet_NO,c.DDBH from (select* from FStorageAreaDetail where KCBH = '{0}' and FSA_NO = '{1}' and FSA_Locate like '{2}%') as a left join (select* from PalletDetail ) as b on a.Pallet_NO = b.Pallet_NO left join(select* from YWCP) as c on b.CARTONBAR = c.CARTONBAR",comboBox1.Text,comboBox2.Text,comboBox3.Text);
            Console.WriteLine(sql);
            SqlDataAdapter adapter = new SqlDataAdapter(sql, dbConn.connection);

            adapter.Fill(ds, "訂單表");
            this.dataGridView1.DataSource = this.ds.Tables[0];

            dataGridView1.ReadOnly = true;

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //ShelfNo();
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            Level();
        }
    }
}
