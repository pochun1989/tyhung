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
    public partial class WHROStorageInquiry : Form
    {
        #region 建構函式

        public WHROStorageInquiry()
        {
            InitializeComponent();
        }

        #endregion

        #region 變數

        DataSet ds = new DataSet(); // 儲存資料表容器    
        DataSet ds2 = new DataSet();
        public string USERID;
        string DDBH = "";

        #endregion

        #region 畫面載入

        private void WHROStorageInquiry_Load(object sender, EventArgs e)
        {
            tbOrder.Focus();
        }

        #endregion

        #region 方法

        #region DDZL方法

        private void dgvA()
        {
            ds = new DataSet();
            DataBinding dbConn = new DataBinding();

            if (tbOrder.Text != "")
            {
                DDBH = tbOrder.Text;
                string sql = string.Format("Select ddbh, Pairs,ARTICLE,XieXing from ddzl Where ShipDate <= GETDATE() and ddzt <> 'C' and(yn <> 5 or yn <> 3) and DDBH ='{0}'", tbOrder.Text.Trim());
                Console.WriteLine(sql);
                SqlDataAdapter adapter = new SqlDataAdapter(sql, dbConn.connection);
                
                adapter.Fill(ds, "訂單表");
                this.dgvDDZL.DataSource = this.ds.Tables[0];



                ds2 = new DataSet();
                DataBinding dbConn2 = new DataBinding();

                if (tbOrder.Text == "")
                {

                }
                else
                {
                    string sql2 = string.Format("select cartonbar, (KCBH+FSA_NO+FSA_Locate) as storelocate from PalletDetail as p left join FStorageAreaDetail as f on p.Pallet_NO = f.Pallet_NO where left(cartonbar, len(cartonbar) - 5) = '{0}' ", DDBH);
                    Console.WriteLine(sql2);
                    SqlDataAdapter adapter2 = new SqlDataAdapter(sql2, dbConn2.connection);

                    adapter2.Fill(ds2, "訂單表");
                    this.dgvCARTON.DataSource = this.ds2.Tables[0];
                }
            }
            else
            {
                string sql = string.Format("Select ddbh, Pairs,ARTICLE,XieXing from ddzl Where ShipDate <= GETDATE() and ddzt <> 'C' and(yn <> 5 or yn <> 3) ");
                Console.WriteLine(sql);
                SqlDataAdapter adapter = new SqlDataAdapter(sql, dbConn.connection);

                adapter.Fill(ds, "訂單表");
                this.dgvDDZL.DataSource = this.ds.Tables[0];
            }
        }

        #endregion

        #region Order方法

        private void dgvB()
        {
            ds2 = new DataSet();
            DataBinding dbConn2 = new DataBinding();

            if (tbOrder.Text == "")
            {
                
            }
            else
            {
                int c = 0;
                c =  dgvCARTON.RowCount;

                for (int i = 0 ; i < c; i++)
                {
                    dgvCARTON.Rows.RemoveAt(0);
                }


                string sql = string.Format("select cartonbar, (KCBH+FSA_NO+FSA_Locate) as storelocate from PalletDetail as p left join FStorageAreaDetail as f on p.Pallet_NO = f.Pallet_NO where left(cartonbar, len(cartonbar) - 5) = '{0}'  and f.Pallet_NO is not NULL  ", tbOrder.Text.Trim());
                Console.WriteLine(sql);
                SqlDataAdapter adapter = new SqlDataAdapter(sql, dbConn2.connection);

                adapter.Fill(ds2, "訂單表");
                this.dgvCARTON.DataSource = this.ds2.Tables[0];
            }
        }

        #endregion

        #endregion

        #region 事件

        #region MAP事件

        private void Button1_Click(object sender, EventArgs e)
        {
            //StorePIC pic = new StorePIC();
            //pic.Width = 1200;
            //pic.Height = 600;
            //pic.Show();

            FSALOCATION Form = new FSALOCATION();
            Form.ShowDialog();

        }

        #endregion

        #endregion

        private void TsbQuery_Click(object sender, EventArgs e)
        {
            dgvA();
        }

        private void DgvDDZL_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                tbOrder.Text = dgvDDZL.CurrentRow.Cells[0].Value.ToString();
                dgvB();
            }
            catch (Exception)
            { }
        }

        private void TbOrder_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)//如果输入的是回车键
            {
                dgvA();                
            }
            
        }

        private void TspClear_Click(object sender, EventArgs e)
        {
            tbOrder.Text = "";
            int b = 0;
            b = dgvDDZL.Rows.Count;
            Console.WriteLine(b);

            for (int d = 0; d < b; d++)
            {
                dgvDDZL.Rows.RemoveAt(0);
            }



            int c = 0;
            c = dgvCARTON.Rows.Count;
            Console.WriteLine(c);

            for (int d = 0; d < c; d++)
            {
                dgvCARTON.Rows.RemoveAt(0);
            }
        }

        private void DgvCARTON_DoubleClick(object sender, EventArgs e)
        {
            try
            {

                USERID = Program.User.userID;
                Console.WriteLine(USERID);
                DialogResult dr = MessageBox.Show("確定要取出這個儲位嗎?", "系統提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                if (dr == DialogResult.OK)
                {
                    string aa, bb, cc = "";
                    aa = dgvCARTON.CurrentRow.Cells[1].Value.ToString();
                    bb = aa.Substring(4, 3);
                    cc = aa.Substring(7, 4);
                    //MessageBox.Show(bb);
                    //MessageBox.Show(cc);

                    ////取出棧板號
                    //DataBinding conn2 = new DataBinding();
                    //string sql2 = string.Format("select Pallet_NO from FStorageAreaDetail where FSA_NO = '{0}' and FSA_Locate = '{1}'", bb, cc);
                    //Console.WriteLine(sql2);
                    //SqlCommand cmd2 = new SqlCommand(sql2, conn2.connection);
                    //SqlDataAdapter sda = new SqlDataAdapter(cmd2);
                    //DataTable dt2 = new DataTable();
                    //sda.Fill(dt2);
                    //conn2.OpenConnection();

                    //pID = dt2.Rows[0]["Pallet_NO"].ToString().Trim();
                    //conn2.CloseConnection();

                    //棧板解除綁定除位
                    DataBinding dbconn = new DataBinding();
                    StringBuilder sql = new StringBuilder();
                    sql.AppendFormat("update FStorageAreaDetail set Pallet_NO = NULL, USERDATE = GETDATE(), USERID = '{0}' where FSA_NO = '{1}' and FSA_Locate = '{2}'", USERID, bb, cc);
                    Console.WriteLine(sql);
                    SqlCommand cmd = new SqlCommand(sql.ToString(), dbconn.connection);
                    dbconn.OpenConnection();
                    int result = cmd.ExecuteNonQuery();
                    if (result == 1)
                    {

                    }


                    ////外箱解除綁定儲位
                    //DataBinding dbconn2 = new DataBinding();
                    //StringBuilder sqlD = new StringBuilder();
                    //sqlD.AppendFormat("delete from PalletDetail where Pallet_NO = '{0}'", pID);
                    //SqlCommand cmdD = new SqlCommand(sqlD.ToString(), dbconn2.connection);
                    //dbconn2.OpenConnection();
                    //int resultD = cmdD.ExecuteNonQuery();
                    //if (resultD == 1)
                    //{

                    //}
                    MessageBox.Show("儲位綁定解除!", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    dgvB();

                }
            }
            catch (Exception)
            { }
        }

        private void WHROStorageInquiry_Shown(object sender, EventArgs e)
        {
            tbOrder.Focus();
        }
    }
}
