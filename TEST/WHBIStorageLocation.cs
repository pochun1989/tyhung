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
    public partial class WHBIStorageLocation : Form
    {
        #region 變數

        DataSet ds = new DataSet(); // 儲存資料表容器     
        DataSet ds2 = new DataSet();
        public string USERID;

        #endregion

        #region 建構函式
        public WHBIStorageLocation()
        {
            InitializeComponent();
        }


        #endregion

        #region 畫面載入

        private void WHBIStorageLocation_Load(object sender, EventArgs e)
        {
            USERID = Program.User.userID;
            

            cbWarehouse.MaxDropDownItems = 8;
            cbWarehouse.IntegralHeight = false;
            #region CB載入

            DataBinding dbconn = new DataBinding();
            string sql1 = "select * from KCZL where YN = 1";
            SqlDataAdapter adapter1 = new SqlDataAdapter(sql1, dbconn.connection);
            adapter1.Fill(ds, "倉庫位置");
            this.cbWarehouse.DataSource = ds.Tables[0];
            this.cbWarehouse.ValueMember = "KCBH";
            this.cbWarehouse.DisplayMember = "KCBH";


            #endregion

            StorageLocationdata();
        }

        #endregion        

        #region 方法

        #region 載入儲位的資料並綁定DataGridView方法

        /// <summary>
        /// 載入資產儲位資料,綁定dgv
        /// </summary>
        private void StorageLocationdata()
        {
            
            DataBinding dbConn = new DataBinding();
            try
            {
                string sql = "SELECT KCBH as 倉庫編號, FSA_NO as 貨架編號, FSA_Level as 貨架層數, FSA_Grid as 貨架格數,MEMO as 備註, case when YN=1 then '使用中' when YN=0 then '停用'  END as 倉庫類別 FROM FStorageArea";
                SqlDataAdapter adapter = new SqlDataAdapter(sql, dbConn.connection);
                adapter.Fill(ds2, "儲位表");
                this.dgvStorageLocation.DataSource = this.ds2.Tables[0];


                this.dgvStorageLocation.AllowUserToAddRows = false;
            }
            catch (Exception)
            {
                MessageBox.Show("儲位載入失敗! Đang tải không thành công", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Error);                
            }
        }

        #endregion        

        #region 查詢儲位       

        /// <summary>
        /// 查詢倉庫方法
        /// </summary>
        private void StorageQuery()
        {
           
                ds = new DataSet();
                DataBinding dbConn = new DataBinding();
                try
                {
                    string sql = string.Format("SELECT KCBH as 倉庫編號, FSA_NO as 貨架編號, FSA_Level as 貨架層數, FSA_Grid as 貨架格數,MEMO as 備註,  case when YN=1 then '使用中' when YN=0 then '停用'  END as 倉庫類別 FROM FStorageArea where KCBH = '{0}'", cbWarehouse.Text.Trim());
                    SqlDataAdapter adapter = new SqlDataAdapter(sql, dbConn.connection);
                    adapter.Fill(ds, "儲位名");
                    this.dgvStorageLocation.DataSource = this.ds.Tables[0];
                }
                catch (Exception)
                {
                    MessageBox.Show("儲位查詢錯誤! Lỗi truy vấn", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    
                }
            
        }

        #endregion

        #region 刪除儲位資料的方法
       
        private void DeleteData()
        {
            if (this.dgvStorageLocation.CurrentRow != null)
            {
                DialogResult dr = MessageBox.Show("確定要停用這個儲位嗎? Hãy chắc chắn để vô hiệu hóa?", "系統提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                if (dr == DialogResult.OK)
                {
                    
                    try
                    {
                        
                        DataBinding con = new DataBinding();
                        string strSQL1 = string.Format("select Pallet_NO from FStorageAreaDetail where KCBH = '{0}' and FSA_NO = '{1}' and (Pallet_NO is not NUll)", this.dgvStorageLocation.CurrentRow.Cells[0].Value, this.dgvStorageLocation.CurrentRow.Cells[1].Value);
                        SqlCommand cmda = new SqlCommand(strSQL1, con.connection);
                        con.OpenConnection();
                        SqlDataReader reader = cmda.ExecuteReader();                      
                     

                        if (reader.Read() == true)
                        {
                            MessageBox.Show("停用失敗 請先解除綁定棧板! Vô hiệu hóa thất bại", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            DataBinding dbConn2 = new DataBinding();
                            StringBuilder sb2 = new StringBuilder();
                            sb2.AppendFormat("update FStorageAreaDetail set YN = 0 , USERID = '{0}', USERDATE = GETDATE() where KCBH = '{1}' and FSA_NO = '{2}'",USERID, this.dgvStorageLocation.CurrentRow.Cells[0].Value, this.dgvStorageLocation.CurrentRow.Cells[1].Value);
                            SqlCommand cmd2 = new SqlCommand(sb2.ToString(), dbConn2.connection);
                            dbConn2.OpenConnection();
                            int result2 = cmd2.ExecuteNonQuery();



                            DataBinding dbConn3 = new DataBinding();
                            StringBuilder sb3 = new StringBuilder();
                            sb3.AppendFormat("update FStorageArea set YN = 0 , USERID = '{0}', USERDATE = GETDATE() where KCBH = '{1}' and FSA_NO = '{2}'", USERID, this.dgvStorageLocation.CurrentRow.Cells[0].Value, this.dgvStorageLocation.CurrentRow.Cells[1].Value);
                            SqlCommand cmd3 = new SqlCommand(sb3.ToString(), dbConn3.connection);
                            dbConn3.OpenConnection();
                            int result3 = cmd3.ExecuteNonQuery();

                            if ( result2>0 && result3>0 )
                            {
                                MessageBox.Show("停用成功! Vô hiệu hóa thành công", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                int c = 0;
                                c = dgvStorageLocation.Rows.Count;
                                Console.WriteLine(c);


                                for (int d = 0; d < c; d++)
                                {
                                    dgvStorageLocation.Rows.RemoveAt(0);

                                }
                                c -= 1;
                                StorageLocationdata();
                            }
                            else
                            {
                                MessageBox.Show("停用變更失敗! Thay đổi không thành công", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                           
                        }
                        reader.Close();
                        
                        //con.Close();


                        #region 失敗的停用

                        //DataBinding dbConn1 = new DataBinding();

                        //StringBuilder sb1 = new StringBuilder();
                        //sb1.AppendFormat("select Pallet_NO from FStorageAreaDetail where KCBH = '{0}' and FSA_NO = '{1}' and (Pallet_NO is not NUll)", lbA.Text, lbB.Text);


                        //SqlCommand cmd1 = new SqlCommand(sb1.ToString(), dbConn1.connection);
                        //dbConn1.OpenConnection();
                        //int result = cmd1.ExecuteNonQuery();

                        //string strSQL = "select Pallet_NO from FStorageAreaDetail where KCBH = '1' and FSA_NO = '2' and (Pallet_NO is not NUll)";
                        //SqlCommand cmd = new SqlCommand(strSQL, dbConn1.connection);
                        //int result = cmd.ExecuteNonQuery();
                        ////SqlDataReader reader = cmd.ExecuteReader();

                        //if (result > 0)
                        //{
                        //    MessageBox.Show("停用失敗 請先解除綁定棧板!", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        //}
                        //else
                        //{

                        //    MessageBox.Show("停用成功", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        //}

                        //dbConn1.CloseConnection();


                        #endregion

                    }
                    catch (Exception)
                    {
                        MessageBox.Show("刪除資料失敗! Xóa dữ liệu không thành công", "刪除錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    finally
                    {
                        
                    }
                }
            }
        }

        #endregion

        #endregion

        #region 事件

        #region 查詢
        private void TsbQuery_Click(object sender, EventArgs e)
        {
            StorageQuery();
        }

        #endregion

        #region 關閉

        private void TsbExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #endregion

        #region 修改

        private void TsbModify_Click(object sender, EventArgs e)
        {
            //if (dgvStorageLocation.CurrentRow.Cells[0].Value.ToString() != "")
            //{
            //    if (this.dgvStorageLocation.DataSource == ds2.Tables[0])
            //    {
            try
            {
                WHBIStorageLocationDetail appw = new WHBIStorageLocationDetail();
                appw.cbWarehouseID.Text = dgvStorageLocation.CurrentRow.Cells[0].Value.ToString();
                appw.tbShelfNo.Text = dgvStorageLocation.CurrentRow.Cells[1].Value.ToString();
                appw.tbShelfLevel.Text = dgvStorageLocation.CurrentRow.Cells[2].Value.ToString();
                appw.tbShelfGrid.Text = dgvStorageLocation.CurrentRow.Cells[3].Value.ToString();
                appw.tbMemo.Text = dgvStorageLocation.CurrentRow.Cells[4].Value.ToString();

                appw.KCBH = dgvStorageLocation.CurrentRow.Cells[0].Value.ToString();
                appw.FSANO = dgvStorageLocation.CurrentRow.Cells[1].Value.ToString();
                appw.WarehouseID = dgvStorageLocation.CurrentRow.Cells[0].Value.ToString();
                appw.ShowDialog();

                int c = 0;
                c = dgvStorageLocation.Rows.Count;
                Console.WriteLine(c);


                for (int d = 0; d < c; d++)
                {
                    dgvStorageLocation.Rows.RemoveAt(0);

                }
                c -= 1;

                this.StorageLocationdata(); // 重新綁定
            }
            catch (Exception) { }
            //    }
            //    else
            //    {
            //        MessageBox.Show("編輯資料失敗! Chỉnh sửa dữ liệu không thành công", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    }
            //}
            //else
            //{ }
            ////this.StorageLocationdata();
        }

        #endregion

        #region 新增       

        private void TspInsert_Click_1(object sender, EventArgs e)
        {
            
                WHBIStorageLocationDetail appw = new WHBIStorageLocationDetail();
                appw.selectID = 0;
                appw.ShowDialog();

                int c = 0;
                c = dgvStorageLocation.Rows.Count;
                Console.WriteLine(c);


                for (int d = 0; d < c; d++)
                {
                    dgvStorageLocation.Rows.RemoveAt(0);
                }
                c -= 1;

                this.StorageLocationdata(); // 重新綁定
           
        }
        #endregion

        #region 刪除

        private void TsbDelete_Click(object sender, EventArgs e)
        {
            DeleteData();
        }





        #endregion

        #endregion

        private void CbWarehouse_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                StorageQuery();
            }
            else
            { }
        }

        private void CbWarehouse_SelectedIndexChanged(object sender, EventArgs e)
        {
            StorageQuery();
        }
    }
}
