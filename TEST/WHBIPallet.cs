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
    public partial class WHBIPallet : Form
    {

        #region 建構函式

        public WHBIPallet()
        {
            InitializeComponent();
        }

        #endregion

        #region 變數

        DataSet ds = new DataSet(); // 儲存資料表容器       
        public string USERID;
        
        #endregion        

        #region 畫面載入

        private void WHBIPallet_Load(object sender, EventArgs e)
        {
            PalletData();
            
        }

        #endregion

        #region 事件        

        #region 清空事件

        private void TspClear_Click(object sender, EventArgs e)
        {
            tbPalletLength.Text = "";
            tbPalletwidth.Text = "";
        }

        #endregion

        #region 新增事件

        private void TspInsert_Click(object sender, EventArgs e)
        {

            if (this.dgvPallet.DataSource == ds.Tables[0])
            {
                WHBIPalletDetail appw = new WHBIPalletDetail();
                appw.selectID = 0;
                appw.lbPalletID.Visible = false;
                appw.ShowDialog();
                this.PalletData(); // 重新綁定
            }
            else
            {
                MessageBox.Show("新增資料失敗! Dữ liệu mới thất bại!", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Error);      

            }
        }

        #endregion

        #region 離開事件

        private void TsbExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #endregion

        #region 修改事件

        private void TsbModify_Click(object sender, EventArgs e)
        {
            if (this.dgvPallet.DataSource == ds.Tables[0])
            {

                WHBIPalletDetail appw = new WHBIPalletDetail();
                appw.tbLength.Text = dgvPallet.CurrentRow.Cells[1].Value.ToString();
                appw.tbWidth.Text = dgvPallet.CurrentRow.Cells[2].Value.ToString();
                appw.tbColor.Text = dgvPallet.CurrentRow.Cells[3].Value.ToString();
                appw.dtpDate.Text = dgvPallet.CurrentRow.Cells[4].Value.ToString();
                appw.WarehouseID = dgvPallet.CurrentRow.Cells[0].Value.ToString();
                appw.lbPalletID.Text = dgvPallet.CurrentRow.Cells[0].Value.ToString();
                appw.tbNumber.Enabled = false;
                appw.ShowDialog();
                this.PalletData(); // 重新綁定
            }
            else
            {
                MessageBox.Show("沒有進入新增事件! Không tham gia sự kiện mới!", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Error);                
            }
        }

        #endregion

        #region 查詢事件

        private void TsbQuery_Click(object sender, EventArgs e)
        {
            if ( tbPalletLength.TextLength > 0 && tbPalletwidth.TextLength > 0 )
            {
                PalletQuery();
            }
            else
            {
                MessageBox.Show("請輸入長寬。Vui lòng nhập chiều dài và chiều rộng", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);                
            }
            
        }

        #endregion

        #region 停用事件

        private void TsbDelete_Click(object sender, EventArgs e)
        {
            DeleteData();
        }

        #endregion

        #endregion

        #region 方法        

        #region 載入棧板資料並綁定DataGridView方法

        /// <summary>
        /// 載入資產儲位資料,綁定dgv
        /// </summary>
        private void PalletData()
        {
            ds = new DataSet();
            DataBinding dbConn = new DataBinding();
            try
            {

                //DataGridViewCheckBoxColumn checkColumn = new DataGridViewCheckBoxColumn();
                //checkColumn.Name = "X";
                //checkColumn.HeaderText = "Barcode列印";
                //checkColumn.Width = 20;
                //checkColumn.ReadOnly = false;
                //checkColumn.FillWeight = 10; //if the datagridview is resized (on form resize) the checkbox won't take up too much; value is relative to the other columns' fill values
                //dgvPallet.Columns.Add(checkColumn);

                string sql = "select Pallet_NO as 棧板編號, Pallet_Length as 長, Pallet_Width as 寬, Pallet_Color as 顏色, CreatDATE as 購入日期, case when USERED = 1 then '使用中' when USERED = 0 then '未使用' END as '使用狀況' from Pallet where YN = 1";
                SqlDataAdapter adapter = new SqlDataAdapter(sql, dbConn.connection);
                adapter.Fill(ds, "棧板表");
                this.dgvPallet.DataSource = this.ds.Tables[0];

                
                dgvPallet.Columns[2].FillWeight = 180;
                //dgvPallet.Columns[4].FillWeight = 180;

                this.dgvPallet.AllowUserToAddRows = false;

                


            }
            catch (Exception)
            {
                MessageBox.Show("資料載入失敗! Tải dữ liệu không thành công!", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                
            }

        }

        #endregion

        #region 查詢棧板方法

        /// <summary>
        /// 查詢倉庫方法
        /// </summary>
        private void PalletQuery()
        {
            ds = new DataSet();
            DataBinding dbConn = new DataBinding();
            try
            {
                if ( ckbScrapped.Checked == true )
                {
                    string sql = string.Format("select Pallet_NO as 棧板編號, Pallet_Length as 長, Pallet_Width as 寬, Pallet_Color as 顏色, CreatDATE as 購入日期, case when USERED = 1 then '使用中' when USERED = 0 then '未使用' END as '使用狀況', case when YN = 1 then '使用' when YN = 0 then '報廢' END as '報廢' from Pallet where Pallet_Length = {0} and Pallet_Width = {1} ", tbPalletLength.Text, tbPalletwidth.Text);
                    SqlDataAdapter adapter = new SqlDataAdapter(sql, dbConn.connection);
                    adapter.Fill(ds, "棧板名");
                    this.dgvPallet.DataSource = this.ds.Tables[0];  
                }
                else
                {
                    string sql = string.Format("select Pallet_NO as 棧板編號, Pallet_Length as 長, Pallet_Width as 寬, Pallet_Color as 顏色, CreatDATE as 購入日期, case when USERED = 1 then '使用中' when USERED = 0 then '未使用' END as '使用狀況'  from Pallet where Pallet_Length = {0} and Pallet_Width = {1} and YN = 1", tbPalletLength.Text, tbPalletwidth.Text);
                    SqlDataAdapter adapter = new SqlDataAdapter(sql, dbConn.connection);
                    adapter.Fill(ds, "棧板名");
                    this.dgvPallet.DataSource = this.ds.Tables[0];
                }
                                 
            }
            catch (Exception)
            {
                MessageBox.Show("查詢錯誤! Lỗi truy vấn!", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Error);                
            }
        }



        #endregion        

        #region 刪除儲位資料的方法

        /// <summary>
        /// 資料刪除方法(使用dgv選擇的欄位)
        /// </summary>
        private void DeleteData()
        {
            if (this.dgvPallet.CurrentRow != null)
            {
                USERID =   Program.User.userID;
                Console.WriteLine(USERID);
                DialogResult dr = MessageBox.Show("確定要停用這個棧板嗎? Hãy chắc chắn để vô hiệu hóa?", "系統提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                if (dr == DialogResult.OK)
                {
                    DataBinding dbConn = new DataBinding();
                    try
                    {
                        //檢查棧板有無使用
                        DataBinding dbConn2 = new DataBinding();
                        string sql2 = string.Format("select Pallet_NO from PalletDetail where Pallet_NO = '{0}'", this.dgvPallet.CurrentRow.Cells[0].Value);
                        SqlCommand cmd2 = new SqlCommand(sql2, dbConn2.connection);
                        dbConn2.OpenConnection();
                        SqlDataReader reader2 = cmd2.ExecuteReader();
                        if (reader2.Read())
                        {
                            Console.WriteLine("1");
                            MessageBox.Show("棧板使用中，停用失敗!Đang sử dụng, việc hủy kích hoạt không thành công", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        }
                        else
                        {
                            dbConn2.CloseConnection();
                            Console.WriteLine("2");
                            StringBuilder sb = new StringBuilder();
                            sb.AppendFormat("UPDATE Pallet SET YN = 0 , USERID = '{0}', USERDATE = GETDATE() WHERE Pallet_NO = '{1}'", USERID, this.dgvPallet.CurrentRow.Cells[0].Value);
                            SqlCommand cmd = new SqlCommand(sb.ToString(), dbConn.connection);
                            dbConn.OpenConnection();
                            int result = cmd.ExecuteNonQuery();
                            if (result == 1)
                            {
                                MessageBox.Show("停用成功!Vô hiệu hóa thành công", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                this.PalletData();
                            }

                        }


                    }
                    catch (Exception)
                    {
                        MessageBox.Show("停用資料失敗!Không thể tắt dữ liệu", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    finally
                    {
                        dbConn.CloseConnection();
                    }
                }
            }
        }
        #endregion

        #endregion

        private void TsbPrint_Click(object sender, EventArgs e)
        {
            int c = 0;
            c = dgvPallet.Rows.Count;
            Console.WriteLine(c);
            
            BarcodeAll rcode = new BarcodeAll();
            rcode.dgvBARCODE.Columns.Add("Barcode1", "Barcode1");
            


            for (int i = 0; i < c; i++)
            {
                bool bar = true;
                bar = Convert.ToBoolean(dgvPallet.Rows[i].Cells[0].Value);
                
                if (bar == true)
                {
                    string addB = "";
                    addB = dgvPallet.Rows[i].Cells[2].Value.ToString();
                    
                    rcode.dgvBARCODE.Rows.Add(addB) ;
                    rcode.dgvBARCODE.Rows.Add("");
                }
                else
                {

                }
            }
            rcode.ShowDialog();
        }

        private void DgvPallet_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //
            //if (dgvPallet.CurrentRow.Cells[1].Selected)
            //{
            //    Barcode appw = new Barcode();
            //    //appw.selectID = 0;
            //    //appw.lbPalletID.Visible = false;
            //    appw.pallet = dgvPallet.CurrentRow.Cells[2].Value.ToString();
            //    appw.ShowDialog();
            //    //this.PalletData(); // 重新綁定
            //}
            //else
            //{
                
            //}
        }

        private void DgvPallet_Click(object sender, EventArgs e)
        {
            dgvPallet.Select();
        }
    }
}
