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
    public partial class WHBIWarehouse : Form
    {
        #region 建構函式

        public WHBIWarehouse()
        {
            InitializeComponent();
        }

        #endregion

        #region 變數

        DataSet ds = new DataSet(); // 儲存資料表容器   
        public string USERID;

        #endregion

        #region 事件

        #region 畫面載入

        private void WHBasicInformationWarehouse_Load(object sender, EventArgs e)
        {
            cbWarehouseType.IntegralHeight = false;


            USERID = Program.User.userID;
            Warehousedata();
        }

        #endregion        

        #region 新增按鈕

        private void TspInsert_Click(object sender, EventArgs e)
        {

            if (this.dgvWarehouse.DataSource == ds.Tables[0])
            {
                WHBIWarehouseDetail appw = new WHBIWarehouseDetail();
                appw.selectID = 0;
                appw.ShowDialog();
                this.Warehousedata(); // 重新綁定
            }
            else
            {
                MessageBox.Show("沒有進入新增資料事件!", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Error);               
            }

        }

        #endregion

        #region 刪除按鈕

        private void TsbDelete_Click(object sender, EventArgs e)
        {

            if (this.dgvWarehouse.DataSource == ds.Tables[0])
            {
                DeleteData();
            }
            else
            {
                MessageBox.Show("刪除失敗!", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Error);                
            }
        }

        #endregion

        #region 查詢按鈕

        private void TsbQuery_Click(object sender, EventArgs e)
        {
            WarehouseQuery();
        }

        #endregion

        #region 修改按鈕

        private void TsbModify_Click(object sender, EventArgs e)
        {
            if (this.dgvWarehouse.DataSource == ds.Tables[0])
            {

                WHBIWarehouseDetail appw = new WHBIWarehouseDetail();   
                appw.tbWHID.Text = dgvWarehouse.CurrentRow.Cells[0].Value.ToString();
                appw.tbWarehouseName.Text = dgvWarehouse.CurrentRow.Cells[1].Value.ToString();
                appw.cbWarehouseClass.Text = dgvWarehouse.CurrentRow.Cells[2].Value.ToString();
                appw.WarehouseID = dgvWarehouse.CurrentRow.Cells[0].Value.ToString();
                //appw.WarehouseID = dgvWarehouse.CurrentRow.Cells[0].Value.ToString();
                appw.ShowDialog();
                this.Warehousedata(); // 重新綁定
            }
            else
            {
                MessageBox.Show("沒有進入編輯資料事件!", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                
            }
            
        }

        #endregion

        #region 離開按鈕

        private void TsbExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #endregion

        #region 下拉事件

        private void CbWarehouseType_SelectedIndexChanged(object sender, EventArgs e)
        {
            WarehouseQuery();
        }

        #endregion

        #endregion

        #region 方法

        #region 載入倉庫儲位的資料並綁定DataGridView方法

        /// <summary>
        /// 載入資產儲位資料,綁定dgv
        /// </summary>
        private void Warehousedata()
        {
            ds = new DataSet();
            DataBinding dbConn = new DataBinding();
            try
            {
                string sql = "select KCBH as 倉庫編號, KCMC as 倉庫名稱, case when KCCLASS=1 then '原物料倉' when KCCLASS=2 then '成品倉' when KCCLASS=3 then 'BC品倉' when KCCLASS=4 then '總務倉' END as 倉庫類別, case when YN=0 then '失效' when YN=1 then '有效' END  as 識別 from KCZL where YN = '1'";
                SqlDataAdapter adapter = new SqlDataAdapter(sql, dbConn.connection);
                adapter.Fill(ds, "倉庫表");
                this.dgvWarehouse.DataSource = this.ds.Tables[0];
                dgvWarehouse.Columns[0].FillWeight = 50;

                this.dgvWarehouse.AllowUserToAddRows = false;
            }
            catch (Exception)
            {
                MessageBox.Show("資產儲位載入失敗!", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Error);               
            }
        }

        #endregion

        #region 查詢倉庫方法

        /// <summary>
        /// 查詢倉庫方法
        /// </summary>
        private void WarehouseQuery()
        {
            ds = new DataSet();
            DataBinding dbConn = new DataBinding();
            try
            {
                if (cbWarehouseType.SelectedIndex == 0)
                {
                    string sql = string.Format("select KCBH as '倉庫編號',KCMC as '倉庫名稱' ,case when KCCLASS=1 then '原物料倉' when KCCLASS=2 then '成品倉' when KCCLASS=3 then 'BC品倉' when KCCLASS=4 then '總務倉' END AS 倉庫類別,case when YN=1 then '有效' when YN = 0 then '失效' END as 識別  FROM KCZL ");
                    SqlDataAdapter adapter = new SqlDataAdapter(sql, dbConn.connection);
                    adapter.Fill(ds, "倉庫名");
                    this.dgvWarehouse.DataSource = this.ds.Tables[0];
                }
                else if (cbWarehouseType.SelectedIndex == 1)
                {
                    string sql = string.Format("select KCBH as '倉庫編號',KCMC as '倉庫名稱' ,case when KCCLASS=1 then '原物料倉' when KCCLASS=2 then '成品倉' when KCCLASS=3 then 'BC品倉' when KCCLASS=4 then '總務倉' END AS 倉庫類別,case when YN=1 then '有效' when YN = 0 then '失效' END as 識別  FROM KCZL where KCCLASS = '1'");
                    SqlDataAdapter adapter = new SqlDataAdapter(sql, dbConn.connection);
                    adapter.Fill(ds, "倉庫名");
                    this.dgvWarehouse.DataSource = this.ds.Tables[0];
                }
                else if (cbWarehouseType.SelectedIndex == 2)
                {
                    string sql = string.Format("select KCBH as '倉庫編號',KCMC as '倉庫名稱' ,case when KCCLASS=1 then '原物料倉' when KCCLASS=2 then '成品倉' when KCCLASS=3 then 'BC品倉' when KCCLASS=4 then '總務倉' END AS 倉庫類別,case when YN=1 then '有效' when YN = 0 then '失效' END as 識別  FROM KCZL where KCCLASS = '2'");
                    SqlDataAdapter adapter = new SqlDataAdapter(sql, dbConn.connection);
                    adapter.Fill(ds, "倉庫名");
                    this.dgvWarehouse.DataSource = this.ds.Tables[0];
                }
                else if (cbWarehouseType.SelectedIndex == 3)
                {
                    string sql = string.Format("select KCBH as '倉庫編號',KCMC as '倉庫名稱' ,case when KCCLASS=1 then '原物料倉' when KCCLASS=2 then '成品倉' when KCCLASS=3 then 'BC品倉' when KCCLASS=4 then '總務倉' END AS 倉庫類別,case when YN=1 then '有效' when YN = 0 then '失效' END as 識別  FROM KCZL where KCCLASS = '3'");
                    SqlDataAdapter adapter = new SqlDataAdapter(sql, dbConn.connection);
                    adapter.Fill(ds, "倉庫名");
                    this.dgvWarehouse.DataSource = this.ds.Tables[0];
                }
                else
                {
                    string sql = string.Format("select KCBH as '倉庫編號',KCMC as '倉庫名稱' ,case when KCCLASS=1 then '原物料倉' when KCCLASS=2 then '成品倉' when KCCLASS=3 then 'BC品倉' when KCCLASS=4 then '總務倉' END AS 倉庫類別,case when YN=1 then '有效' when YN = 0 then '失效' END as 識別  FROM KCZL where KCCLASS = '4'");
                    SqlDataAdapter adapter = new SqlDataAdapter(sql, dbConn.connection);
                    adapter.Fill(ds, "倉庫名");
                    this.dgvWarehouse.DataSource = this.ds.Tables[0];
                }



                
            }
            catch (Exception)
            {
                MessageBox.Show("倉庫查詢功能錯誤!", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Error);                
            }
        }

        #endregion

        #region 刪除儲位資料的方法

        /// <summary>
        /// 資料刪除方法(使用dgv選擇的欄位)
        /// </summary>
        private void DeleteData()
        {
            if (this.dgvWarehouse.CurrentRow != null)
            {
                DialogResult dr = MessageBox.Show("確定要停用 " + this.dgvWarehouse.CurrentRow.Cells[1].Value + " 這個倉庫嗎?", "系統提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                if (dr == DialogResult.OK)
                {
                    DataBinding dbConn1 = new DataBinding();
                    try
                    {
                        //StringBuilder sb1 = new StringBuilder();
                        //sb1.AppendFormat("select * from FStorageArea as a left outer join (select * from KCZL) as b on a.KCBH = b.KCBH where a.YN = 1 and b.KCBH = '{0}'", this.dgvWarehouse.CurrentRow.Cells[0].Value);
                        //SqlCommand cmd1 = new SqlCommand(sb1.ToString(), dbConn1.connection);
                        //dbConn1.OpenConnection();
                        //int result1 = cmd1.ExecuteNonQuery();

                        string sql = string.Format("select * from FStorageArea as a left outer join (select * from KCZL) as b on a.KCBH = b.KCBH where a.YN = 1 and b.KCBH = '{0}'", this.dgvWarehouse.CurrentRow.Cells[0].Value);
                        SqlCommand cmd1 = new SqlCommand(sql, dbConn1.connection);
                        dbConn1.OpenConnection();
                        SqlDataReader reader = cmd1.ExecuteReader();





                        if (reader.Read())  //下面有使用 不可停用
                        {
                            MessageBox.Show("刪除失敗 請先停用儲存區!", "刪除錯誤", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            DataBinding dbConn = new DataBinding();
                            try
                            {
                                StringBuilder sb = new StringBuilder();
                                sb.AppendFormat("UPDATE KCZL SET YN = 0 ,USERID = '{0}',USERDATE = GETDATE() WHERE KCBH='{1}'", USERID, this.dgvWarehouse.CurrentRow.Cells[0].Value);
                                SqlCommand cmd = new SqlCommand(sb.ToString(), dbConn.connection);
                                dbConn.OpenConnection();
                                int result = cmd.ExecuteNonQuery();
                                if (result == 1)
                                {
                                    MessageBox.Show("停用成功!", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    this.Warehousedata();
                                }
                            }
                            catch (Exception)
                            {
                                MessageBox.Show("刪除資料失敗!", "刪除錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            finally
                            {
                                dbConn.CloseConnection();
                            }
                        }
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("刪除資料失敗!", "刪除錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);                  
                    }
                    finally
                    {
                        dbConn1.CloseConnection();
                    }
                }
            }
        }

        #endregion

        #endregion

    }
}
