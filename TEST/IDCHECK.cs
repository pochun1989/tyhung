using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TEST
{
    public partial class IDCHECK : Form
    {
        #region 建構函式

        public IDCHECK()
        {
            InitializeComponent();
        }

        #endregion
        #region 變數

        DataSet ds = new DataSet();
        DataSet ds2 = new DataSet();
        public string SCCLASS = "";
        public string DDBH = "";
        string TakeID = "";
        #endregion

        #region 畫面載入

        private void IDCHECK_Load(object sender, EventArgs e)
        {

        }

        #endregion

        #region 方法

        #region 搜尋方法

        private void Search()
        {

            try
            {
                
                

                DataBinding2 conn = new DataBinding2();
                string strSql = string.Format("select NV_Image from ST_NHANVIEN where NV_Ma = '{0}'", tbID.Text.Trim());
                
                SqlCommand cmd = new SqlCommand(strSql, conn.connection);
                conn.OpenConnection();
                SqlDataReader reader = cmd.ExecuteReader();
                reader.Read();
                MemoryStream ms = new MemoryStream((byte[])reader["NV_Image"]);



                Image image = Image.FromStream(ms, true);
                reader.Close();
                conn.CloseConnection();
                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                pictureBox1.Image = image;
                
            }
            catch (Exception)
            {

            }
        }
        #endregion

        #endregion




        #region 事件

        #region 搜尋事件

        private void BtnSearch_Click(object sender, EventArgs e)
        {
            if (tbID.Text != "")
            {
                TakeID = "";
                pictureBox1.Image = null;
                //tbID.Text = "";
                Search();
                TakeID = tbID.Text.Trim();
                lbID.Text = TakeID;
                lbID.Visible = true;
                tbID.Text = "";
            }
            else
            {
                MessageBox.Show("請輸入ID", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }



        #endregion

        #endregion

        private void TbID_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)//如果输入的是回车键
            {
                TakeID = "";
                pictureBox1.Image = null;
                //tbID.Text = "";
                Search();
                TakeID = tbID.Text.Trim();
                lbID.Text = TakeID;
                lbID.Visible = true;
                tbID.Text = "";
            }
        }

        #region 關閉

        private void Button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #endregion

        private void BtnConfirm_Click(object sender, EventArgs e)
        {
            if (TakeID != "")
            {
                WHSOFinishedGoods2 appw = new WHSOFinishedGoods2();
                appw.DDBH = DDBH;
                appw.ScanClass = SCCLASS;
                appw.TakeUser = TakeID;
                appw.Height = 600;
                appw.Width = 1250;
                appw.lbDDBH.Text = DDBH;
                appw.ShowDialog();
                this.Close();
                TakeID = "";
                pictureBox1.Image = null;
                tbID.Text = "";
                lbID.Visible = false;
            }
            else
            {
                MessageBox.Show("PLZ ENTER USERID。Vui lòng nhập ID", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void IDCHECK_Shown(object sender, EventArgs e)
        {
            tbID.Focus();
        }
    }
}
