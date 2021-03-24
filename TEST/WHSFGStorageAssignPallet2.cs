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
    public partial class WHSFGStorageAssignPallet2 : Form
    {

        #region 建構函式

        public WHSFGStorageAssignPallet2()
        {
            InitializeComponent();
        }

        #endregion

        #region 變數

        DataSet ds = new DataSet();
        DataSet ds2 = new DataSet();
        DataSet ds3 = new DataSet();
        string pdsn = "";
        public string USERID;


        #endregion

        #region 畫面載入

        private void WHSFGStorageAssignPallet2_Shown(object sender, EventArgs e)
        {
            tbPalletNumber.Focus();
        }

        #endregion

        #region Radio button

        private void Choicebtn()
        {
            DataBinding dbconn1 = new DataBinding();
            try
            {
                string sql = string.Format("select * from Palletdetail where Pallet_NO = '{0}'", tbPalletNumber.Text);
                SqlCommand cmd = new SqlCommand(sql, dbconn1.connection);
                dbconn1.OpenConnection();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    rbMove.Enabled = true;
                    rbMove.Checked = true;

                }
                else
                {
                    rbMove.Enabled = false;
                    rbAdd.Checked = true;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("讀取資料錯誤 Đọc lỗi dữ liệu", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }




        }

        #endregion

        #region 載入棧板

        private void SearchData()
        {
            if (tbPalletNumber.Text != "")
            {
                Choicebtn();
                ds = new DataSet();
                DataBinding dbConn = new DataBinding();
                try
                {
                    string sql = string.Format("select Pallet_NO as 棧板號, COUNT(PD_SN) as 箱數 from PalletDetail  where Pallet_NO = '{0}' GROUP BY Pallet_NO", tbPalletNumber.Text);
                    SqlDataAdapter adapter = new SqlDataAdapter(sql, dbConn.connection);
                    adapter.Fill(ds, "棧板表");
                    this.dgvPallet.DataSource = this.ds.Tables[0];

                }
                catch (Exception)
                {
                    MessageBox.Show("棧板載入失敗! Đọc lỗi dữ liệu", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }


                ds2 = new DataSet();
                DataBinding dbConn2 = new DataBinding();
                try
                {
                    string sql = string.Format("select distinct a.CARTONBAR as 外箱標, a.XH as 序號, a.Qty as 數量,a.KCBH as 倉庫編號,a.CKBH as 貨架編號,a.INCS as 入庫次數, a.INDATE as 第一次入庫日期, a.USERID as 使用者, a.DDBH as 訂單編號, b.Pallet_NO as 棧板編號 , c.Article as 物品, c.XieMing as 鞋名 from YWCP as a left outer join (select * from PalletDetail) as b on a.CARTONBAR = b.CARTONBAR left outer join (select * from SMDD) as c on c.DDBH = a.DDBH  where  b.Pallet_NO = '{0}'", tbPalletNumber.Text);
                    SqlDataAdapter adapter = new SqlDataAdapter(sql, dbConn2.connection);
                    adapter.Fill(ds2, "外箱表");
                    this.dgvBox.DataSource = this.ds2.Tables[0];
                }
                catch (Exception)
                {
                    MessageBox.Show("棧板載入失敗! Đọc lỗi dữ liệu", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }

                dgvPallet.Columns[0].FillWeight = 260;

            }
            else
            {

            }
        }

        #endregion

        #region 檢查棧板

        private void check()
        {
            
        }

        #endregion

        #region 清空事件

        private void TspClear_Click(object sender, EventArgs e)
        {
            tbPalletNumber.Text = "";
            tbOuterBox.Text = "";
            dgvPallet.Columns.Clear();
            dgvBox.Columns.Clear();
            pdsn = "";
            tbPalletNumber.Focus();
        }

        #endregion

        #region 關閉事件

        private void TsbExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #endregion

        #region 搜尋棧板

        private void TbPalletNumber_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)//如果输入的是回车键
            {
                if (tbPalletNumber.TextLength == 0)
                {

                }
                else
                {
                    DataBinding dbconn1 = new DataBinding();

                    string sql = string.Format("select Pallet_NO from pallet where Pallet_NO = '{0}'", tbPalletNumber.Text);
                    SqlCommand cmd = new SqlCommand(sql, dbconn1.connection);
                    dbconn1.OpenConnection();
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        SearchData();
                        tbOuterBox.Focus();

                    }
                    else
                    {
                        MessageBox.Show("查無此棧板 sai số pallet", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        tbPalletNumber.Text = "";
                        tbPalletNumber.Focus();
                    }
                    
                }

            }
        }

        #endregion

        #region Move檢查
        private void RbMove_Click(object sender, EventArgs e)
        {
            DataBinding dbconn1 = new DataBinding();
            try
            {
                string sql = string.Format("select * from Pallet as a left outer join (select * from PalletDetail) as b on a.Pallet_NO = b.Pallet_NO where USERED = '1' and a.Pallet_NO = '{0}'", tbPalletNumber.Text);
                SqlCommand cmd = new SqlCommand(sql, dbconn1.connection);
                dbconn1.OpenConnection();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    rbMove.Checked = true;

                }
                else
                {
                    MessageBox.Show("請先加入箱子 Quét hộp trước", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    
                    rbAdd.Checked = true;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("讀取資料錯誤 Đọc lỗi dữ liệu", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                
            }
            tbOuterBox.Focus();
        }
        #endregion

        #region 外箱綁定棧板

        private void InsertBox()
        {
            //取出重複外箱
            DataBinding dbconnx = new DataBinding(); 
            string sqlx = string.Format("select * from PalletDetail where CARTONBAR = '{0}'", tbOuterBox.Text);
            SqlCommand cmdx = new SqlCommand(sqlx, dbconnx.connection);
            dbconnx.OpenConnection();
            SqlDataReader readerx = cmdx.ExecuteReader();
            if (readerx.Read())
            {
                MessageBox.Show("外箱重複 Cùng hộp bên ngoài", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                
                tbOuterBox.Text = "";
            }
            else
            {
                dbconnx.CloseConnection();
                //比對外箱是否已出庫
                string sqlo = string.Format("select * from YWCP where CARTONBAR = '{0}' and (SB = 1) ", tbOuterBox.Text);
                SqlCommand cmdo = new SqlCommand(sqlo, dbconnx.connection);
                dbconnx.OpenConnection();
                SqlDataReader readero = cmdo.ExecuteReader();
                if (readero.Read())
                {
                    //檢查外箱使用沒

                    dbconnx.CloseConnection();
                    //比對外箱是否已出庫
                    string sqlQ = string.Format("select * from YWCP where CARTONBAR = '{0}' and SB is NULL ", tbOuterBox.Text);
                    SqlCommand cmdQ = new SqlCommand(sqlQ, dbconnx.connection);
                    dbconnx.OpenConnection();
                    SqlDataReader readerQ = cmdQ.ExecuteReader();
                    if (readerQ.Read())
                    {
                        MessageBox.Show("外箱尚未使用，請先將外箱掃描入庫 Kho không có hộp này. Cần quét.", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        tbOuterBox.Text = "";

                    }
                    else
                    {

                        DataBinding dbconn1 = new DataBinding(); //取出最大值

                        try
                        {

                            string sql = string.Format("SELECT MAX (PD_SN)+1 as PDSN FROM PalletDetail where Pallet_NO = '{0}'", tbPalletNumber.Text);
                            SqlCommand cmd = new SqlCommand(sql, dbconn1.connection);
                            dbconn1.OpenConnection();
                            SqlDataReader reader = cmd.ExecuteReader();
                            if (reader.Read())
                            {
                                pdsn = reader["PDSN"].ToString();

                            }
                        }
                        catch (Exception)
                        {
                            MessageBox.Show("讀取資料錯誤 Đọc lỗi dữ liệu", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Error);

                        }
                        finally
                        {
                            dbconn1.CloseConnection();
                        }

                        DataBinding dbconn = new DataBinding();  //插入棧板細節
                        try
                        {

                            if (pdsn != "") //有資料
                            {

                                string sql = string.Format("insert into PalletDetail values ('{0}','{1}','{2}', GETDATE(),'{3}')", tbPalletNumber.Text.Trim(), pdsn, tbOuterBox.Text, USERID);
                                SqlCommand cmd = new SqlCommand(sql, dbconn.connection);
                                dbconn.OpenConnection();
                                int result = cmd.ExecuteNonQuery();
                                if (result == 1)
                                {
                                    //MessageBox.Show("插入棧板資料成功!");

                                }
                            }
                            else  //沒資料
                            {

                                string sql = string.Format("insert into PalletDetail values ('{0}',1,'{1}', GETDATE(),'{2}')", tbPalletNumber.Text.Trim(), tbOuterBox.Text, USERID);
                                SqlCommand cmd = new SqlCommand(sql, dbconn.connection);
                                dbconn.OpenConnection();
                                int result = cmd.ExecuteNonQuery();
                                if (result == 1)
                                {
                                    //MessageBox.Show("插入棧板資料成功!");

                                }
                            }
                        }
                        catch (Exception)
                        {
                            MessageBox.Show("添加資料失敗! Dữ liệu mới thất bại", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        finally
                        {
                            dbconn.CloseConnection();
                        }

                        DataBinding dbconn2 = new DataBinding();   //更改Pallet狀態
                        try
                        {
                            string sql = string.Format("Update Pallet set USERID ='{0}', USERDATE = GETDATE(), USERED = 1 where Pallet_NO = '{1}'", USERID, tbPalletNumber.Text.Trim());
                            SqlCommand cmd = new SqlCommand(sql, dbconn2.connection);
                            dbconn2.OpenConnection();
                            int result = cmd.ExecuteNonQuery();
                            if (result == 1)
                            {
                                //MessageBox.Show("新增資料成功!");

                            }
                        }
                        catch (Exception)
                        {
                            MessageBox.Show("更改Pallet狀態資料失敗! Không thể thay đổi dữ liệu", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        finally
                        {
                            dbconn2.CloseConnection();
                        }

                        DataBinding dbconn3 = new DataBinding();   //sb = 1
                        try
                        {

                            string sql = string.Format("update YWCP set  USERID = '{0}' , USERDATE = GETDATE() where CARTONBAR = '{1}'", USERID, tbOuterBox.Text.Trim());

                            Console.WriteLine(sql);

                            SqlCommand cmd = new SqlCommand(sql, dbconn3.connection);
                            dbconn3.OpenConnection();
                            int result = cmd.ExecuteNonQuery();
                            if (result == 1)
                            {
                                //MessageBox.Show("新增資料成功!");

                            }
                        }
                        catch (Exception)
                        {
                            MessageBox.Show("更改YWCP資料失敗! Không thể thay đổi dữ liệu", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        finally
                        {
                            dbconn3.CloseConnection();
                        }

                        tbOuterBox.Text = "";
                        tbOuterBox.Focus();


                    }


                    

                }
                else
                {
                    MessageBox.Show("外箱尚未入庫", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    tbOuterBox.Text = "";
                    
                }

            }




        }

        #endregion

        #region 移動箱子

        private void Movebox()
        {
            DataBinding dbconn2 = new DataBinding();   //刪除綁定外箱
            try
            {
                DataBinding dbconnx = new DataBinding(); //取出重複外箱
                string sqlx = string.Format("select * from PalletDetail where CARTONBAR = '{0}' and Pallet_NO =  '{1}'", tbOuterBox.Text.Trim(), tbPalletNumber.Text.Trim());
                SqlCommand cmdx = new SqlCommand(sqlx, dbconnx.connection);
                dbconnx.OpenConnection();
                SqlDataReader readerx = cmdx.ExecuteReader();
                if (readerx.Read()) //還有外箱
                {
                    string sql1 = string.Format("delete PalletDetail where CARTONBAR = '{0}'", tbOuterBox.Text.Trim());
                    SqlCommand cmd1 = new SqlCommand(sql1, dbconn2.connection);
                    dbconn2.OpenConnection();
                    int result1 = cmd1.ExecuteNonQuery();
                    if (result1 == 1)
                    {
                        //MessageBox.Show("新增資料成功!");

                    }
                }
                else //沒有外箱
                {
                    MessageBox.Show("該棧板無此外箱", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                                                          


            }
            catch (Exception)
            {
                MessageBox.Show("刪除綁定外箱失敗!", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                dbconn2.CloseConnection();
            }


            try
            {
               DataBinding dbconnx = new DataBinding(); //取出重複外箱
               string sqlx = string.Format("select * from PalletDetail where Pallet_NO = '{0}'", tbPalletNumber.Text);
               SqlCommand cmdx = new SqlCommand(sqlx, dbconnx.connection);
               dbconnx.OpenConnection();
               SqlDataReader readerx = cmdx.ExecuteReader();
               if (readerx.Read()) //還有外箱
               {
              
               }
               else //沒有外箱
               {
                    DataBinding dbconn3 = new DataBinding();
                    DataBinding dbconn4 = new DataBinding();
                    try
                    {
                        string sql = string.Format("update FStorageAreaDetail set Pallet_NO = NULL,USERID = '{0}' where Pallet_NO = '{1}'", USERID, tbPalletNumber.Text.Trim());
                        SqlCommand cmd = new SqlCommand(sql, dbconn3.connection);
                        dbconn3.OpenConnection();
                        int result = cmd.ExecuteNonQuery();
                        if (result == 1)
                        {
                            //MessageBox.Show("新增資料成功!");

                        }

                        string sql4 = string.Format("update Pallet set USERID = '{0}', Usered = '0' where Pallet_NO = '{1}'", USERID, tbPalletNumber.Text.Trim());
                        SqlCommand cmd4 = new SqlCommand(sql4, dbconn4.connection);
                        dbconn4.OpenConnection();
                        int result4 = cmd4.ExecuteNonQuery();
                        if (result4 == 1)
                        {
                            //MessageBox.Show("新增資料成功!");

                        }
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("更改FS狀態資料失敗!", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    finally
                    {
                        dbconn3.CloseConnection();
                    }

                    Choicebtn();

                }
            }
            catch (Exception)
            {
                MessageBox.Show("刪除綁定外箱失敗!", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                dbconn2.CloseConnection();
            }

            //載入
            SearchData();
            //清空
            tbOuterBox.Text = "";


        }

        #endregion

        #region 選擇外箱

        private void TbOuterBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)//如果输入的是回车键
            {
                if (tbOuterBox.TextLength == 0)
                {
                }
                else
                {
                    if (rbAdd.Checked == true) //新增箱子
                    {

                     InsertBox();
                     SearchData();
                     rbMove.Enabled = true;
                     rbAdd.Checked = true;
                     //Choicebtn();
                    }
                    else  //移動箱子
                    {
                        Movebox();

                    }
                                       
                   
                }
            }
        }




        #endregion

        private void WHSFGStorageAssignPallet2_Load(object sender, EventArgs e)
        {
            USERID = Program.User.userID;
        }

        private void DgvPallet_MouseClick(object sender, MouseEventArgs e)
        {
            tbOuterBox.Focus();
        }

        private void DgvPallet_MouseUp(object sender, MouseEventArgs e)
        {
            tbOuterBox.Focus();
        }

        private void DgvBox_MouseClick(object sender, MouseEventArgs e)
        {
            tbOuterBox.Focus();
        }

        private void DgvBox_MouseUp(object sender, MouseEventArgs e)
        {
            tbOuterBox.Focus();
        }

        private void RbAdd_Click(object sender, EventArgs e)
        {
            tbOuterBox.Focus();
        }

        private void BtnSTORE_Click(object sender, EventArgs e)
        {
            WHSFGAssignStoreLocation appw = new WHSFGAssignStoreLocation();
            appw.PalletNO = tbPalletNumber.Text.Trim();            
            appw.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (tbPalletNumber.Text == "")
                {
                    MessageBox.Show("Scan First");
                }
                else 
                {
                    DialogResult dr = MessageBox.Show("確定要刪除? Delete?", "系統提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                    if (dr == DialogResult.OK)
                    {
                        DataBinding con4 = new DataBinding();
                        StringBuilder sql4 = new StringBuilder();
                        sql4.AppendFormat("delete PalletDetail  where Pallet_NO = '{0}'", tbPalletNumber.Text);
                        Console.WriteLine(sql4);
                        SqlCommand cmd4 = new SqlCommand(sql4.ToString(), con4.connection);

                        con4.OpenConnection();
                        int result4 = cmd4.ExecuteNonQuery();
                        if (result4 == 1)
                        {
                            //MessageBox.Show("刪除資料成功!", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        con4.CloseConnection();

                        MessageBox.Show("刪除資料成功!", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                    SearchData();
                }
            }
            catch (Exception) { }
        }
    }
    
}
