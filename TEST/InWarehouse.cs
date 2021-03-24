using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Media;

namespace TEST
{
    public partial class InWarehouse : Form
    {
        public InWarehouse()
        {
            InitializeComponent();
            _soundPlayer = new SoundPlayer("thund.wav");
        }

        private SoundPlayer _soundPlayer;
        DataSet ds = new DataSet();
        DataSet ds2 = new DataSet();
        DataSet ds3 = new DataSet();
        public string USERID;
        string count = "";
        public string myDate2 = "";
        double x = 0.0,y = 0.0;
        double z ;
        string data = "";
        double ddbhcheck = 0.0;
        int qty = 0;

        //[DllImport("kernel32.dll")]
        //private static extern int Beep(int dwFreq, int dwDuration);

        private void InWarehouse_Load(object sender, EventArgs e)
        {
            try
            {
                USERID = Program.User.userID;
                KCBH();
                tbBarcode.Focus();
                serialPort1.Open();
                
                //string[] stringArray = new string[20];

                //Sound(stringArray);
            }
            catch (Exception) { }
        }

        private void KCBH()
        {
            DataBinding dbconn = new DataBinding();
            string sql1 = "select * from KCZL where YN = 1 and KCCLASS = 2";
            SqlDataAdapter adapter1 = new SqlDataAdapter(sql1, dbconn.connection);
            adapter1.Fill(ds, "倉庫");
            this.cbKCBH.DataSource = ds.Tables[0];
            this.cbKCBH.ValueMember = "KCBH";
            this.cbKCBH.DisplayMember = "KCBH";

            cbKCBH.MaxDropDownItems = 8;
            cbKCBH.IntegralHeight = false;
        }

        private void stand() 
        {
            try
            {
                DataBinding conn2d = new DataBinding();

                string sql1d = string.Format("select isnull(sgw,0) as sgw, Qty from YWCP where CARTONBAR = '{0}'", tbBarcode.Text);
                Console.WriteLine(sql1d);
                SqlCommand cmd1d = new SqlCommand(sql1d, conn2d.connection);
                conn2d.OpenConnection();
                SqlDataReader reader1d = cmd1d.ExecuteReader();
                if (reader1d.Read()) //取出訂單號
                {
                    ddbhcheck = double.Parse(reader1d["sgw"].ToString());
                    qty = int.Parse(reader1d["Qty"].ToString());
                }
                Console.WriteLine(ddbhcheck);
                Console.WriteLine(qty);
                conn2d.CloseConnection();
            }
            catch (Exception) { }
        }

        #region scan

        private void scan()
        {
            try 
            {
                DataBinding con5 = new DataBinding();
                StringBuilder sql5 = new StringBuilder();
                sql5.AppendFormat("update YWCP set SB = 1, USERID = '{0}',USERDATE = GETDATE(),LastInDate = GETDATE(),rgw = '{1}', KCBH = '{2}' where CARTONBAR = '{3}'", USERID,z.ToString(), cbKCBH.Text, tbBarcode.Text);
                Console.WriteLine(sql5);
                SqlCommand cmd5 = new SqlCommand(sql5.ToString(), con5.connection);
                con5.OpenConnection();
                int result5 = cmd5.ExecuteNonQuery();
                if (result5 == 1)
                {
                    
                }
                con5.CloseConnection();
            }
            catch(Exception){ }
        }

        private void dgvA() 
        {
            try
            {
                int a = 0;
                a = dgvOuter.Rows.Count;
                for (int i = 0; i < a; i++)
                {
                    dgvOuter.Rows.RemoveAt(0);
                }
                ds3 = new DataSet();

                DataBinding dbConn2 = new DataBinding();
                string sql5 = string.Format("select DDBH,CARTONNO,case when SB = 1 then 'da nhap kho已入庫' end as status,INDATE,LastInDate from YWCP where SB = 1 and LastInDate >= '{0}' and KCBH = '{1}' order by Lastindate Desc", myDate2, cbKCBH.Text);
                Console.WriteLine(sql5);

                SqlDataAdapter adapter = new SqlDataAdapter(sql5, dbConn2.connection);
                adapter.Fill(ds3);
                dgvOuter.DataSource = ds3.Tables[0];
            }
            catch (Exception) { }
        }

        #endregion

        private void tbBarcode_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                Console.WriteLine(z);
                //Console.WriteLine("subclass  e.ToString => {0}", a.Salary.ToString());
                label4.Text = z.ToString();
                //serialPort1.Open();
                if (e.KeyCode == Keys.Enter)//如果输入的是回车键
                {
                    //serialPort1.Open();

                    if (tbBarcode.Text == "")//誤觸判定
                    {
                    }
                    else//進入掃描事件
                    {
                        //MessageBox.Show(z.ToString());
                        //if (z == 0)
                        //{
                        //    MessageBox.Show("請先秤重", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        //    tbBarcode.Text = "";
                        //    tbBarcode.Focus();
                        //    _soundPlayer.Play();
                        //}
                        //else
                        //{
                            DataBinding dbConnScan = new DataBinding();
                            //檢查是否為封箱狀態
                            string sqlp = string.Format("select SB from YWCP where CARTONBAR = '{0}'", tbBarcode.Text);
                            Console.WriteLine(sqlp);
                            SqlCommand cmdp = new SqlCommand(sqlp, dbConnScan.connection);
                            dbConnScan.OpenConnection();
                            SqlDataReader readerp = cmdp.ExecuteReader();
                            if (readerp.Read()) //取出箱號
                            {
                                count = readerp["SB"].ToString();
                            }
                            //Console.WriteLine(cartonno);
                            dbConnScan.CloseConnection();

                            if (count == "0")
                            {
                                MessageBox.Show("vẫn chưa scan niêm phong thùng, cảm phiền trả về hiện trường尚未封箱掃描，請退回產線", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                tbBarcode.Text = "";
                                tbBarcode.Focus();
                            }
                            else if (count == "1")
                            {
                                MessageBox.Show("đã nhập kho已入庫", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                tbBarcode.Text = "";
                                tbBarcode.Focus();
                            }
                            else if (count == "2")
                            {
                                MessageBox.Show("vẫn chưa scan niêm phong thùng, cảm phiền trả về hiện trường尚未封箱掃描，請退回產線", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                tbBarcode.Text = "";
                                tbBarcode.Focus();
                            }
                            else if (count == "3")
                            {
                                MessageBox.Show("đã xuất hàng已出貨", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                tbBarcode.Text = "";
                            }
                            else if (count == "4")
                            {
                                MessageBox.Show("chưa scan niêm phong thùng, cảm phiền scan lại尚未封箱掃描，請先掃描", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                tbBarcode.Text = "";
                                tbBarcode.Focus();
                            }
                            else if (count == "9")
                            {
                            MessageBox.Show("thùng này đang là trạng thái bán thành phẩm, scan trước để xuất khỏi kho bán thành phẩm 此外箱為半成品狀態，請先掃描出半成品庫", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            tbBarcode.Text = "";
                            tbBarcode.Focus();
                            }
                            else if (count == "7")
                            {

                            scan();
                            //serialPort1.Close();
                            dgvA();
                            int b = 0;
                            b = dgvOuter.Rows.Count;
                            lbBOX.Text = b.ToString();
                            tbBarcode.Text = "";
                            tbBarcode.Focus();
                            //label1.Text = "";
                            //讀取重量
                            //stand();

                                //if (ddbhcheck == 0)
                                //{
                                //    MessageBox.Show("查無標準重量，請洽IT", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                //    _soundPlayer.Play();
                                //    tbBarcode.Text = "";
                                //    tbBarcode.Focus();
                                //}
                                //else
                                //{
                                //    x = ddbhcheck;
                                //    y = ddbhcheck / (qty * 2);
                                //    label1.Text = ddbhcheck.ToString();


                                //    //重量比較
                                //    if (Math.Abs(x - z) >= y)
                                //    {
                                //        MessageBox.Show("超出誤差值請退回現場", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                //        _soundPlayer.Play();
                                //        tbBarcode.Text = "";
                                //        tbBarcode.Focus();
                                //        label1.Text = "0";
                                //    }
                                //    else
                                //    {
                                //        scan();
                                //        //serialPort1.Close();
                                //        dgvA();
                                //        int b = 0;
                                //        b = dgvOuter.Rows.Count;
                                //        lbBOX.Text = b.ToString();
                                //        tbBarcode.Text = "";
                                //        tbBarcode.Focus();
                                //        label1.Text = "";
                                //    }
                                //}

                            }
                        //}
                    }
                }
                label1.Text = "0";
                label4.Text = "0";
                //z = 0;
            }
            catch (Exception) { }
        }

        private void cbKCBH_Click(object sender, EventArgs e)
        {
            //tbBarcode.Focus();
        }

        private void InWarehouse_Activated(object sender, EventArgs e)
        {
            tbBarcode.Focus();
        }

        private void InWarehouse_Shown(object sender, EventArgs e)
        {
            tbBarcode.Focus();
        }

        private void tspInsert_Click(object sender, EventArgs e)
        {

        }

        private void dgvOuter_Click(object sender, EventArgs e)
        {
            tbBarcode.Focus();
        }

        //class subclass
        //{
        //    private double salary = 0.0;
        //    //salary 成員則是透過公用唯讀屬性存取
        //    public double Salary
        //    {
        //        get { return salary; }
        //        set { salary = value; }
        //    }
        //}

        private void serialPort1_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {
            try
            {
                //subclass a = new subclass();

                string data = "";
                data = serialPort1.ReadExisting();
                Console.WriteLine(data);
                z = double.Parse(data.Substring(7,5));

                //a.Salary = z;

                Console.WriteLine("----------");
                Console.WriteLine(z.ToString());
                setZ(z);
                //MessageBox.Show(z.ToString());
            }
            catch (Exception) { }
        }

        private void setZ(double z) {
            this.z = z;
        }
               
        //public enum Music
        //{
        //    Do = 523,
        //    Re = 587,
        //    Mi = 659,
        //    Fa = 698,
        //    So = 784,
        //    La = 880,
        //    Ti = 988,
        //    Do2 = 1046
        //}

        //static void Sound(string[] args)
        //{
        //    Beep((int)Music.Do, 300);
        //    Beep((int)Music.Do, 300);
        //    Beep((int)Music.So, 300);
        //    Beep((int)Music.So, 300);
        //    Beep((int)Music.La, 300);
        //    Beep((int)Music.La, 300);
        //    Beep((int)Music.So, 600);

        //    Beep((int)Music.Fa, 300);
        //    Beep((int)Music.Fa, 300);
        //    Beep((int)Music.Mi, 300);
        //    Beep((int)Music.Mi, 300);
        //    Beep((int)Music.Re, 300);
        //    Beep((int)Music.Re, 300);
        //    Beep((int)Music.Do, 600);

        //    Beep((int)Music.So, 300);
        //    Beep((int)Music.So, 300);
        //    Beep((int)Music.Fa, 300);
        //    Beep((int)Music.Fa, 300);
        //    Beep((int)Music.Mi, 300);
        //    Beep((int)Music.Mi, 300);
        //    Beep((int)Music.Re, 600);

        //    Beep((int)Music.So, 300);
        //    Beep((int)Music.So, 300);
        //    Beep((int)Music.Fa, 300);
        //    Beep((int)Music.Fa, 300);
        //    Beep((int)Music.Mi, 300);
        //    Beep((int)Music.Mi, 300);
        //    Beep((int)Music.Re, 600);

        //    Beep((int)Music.Do, 300);
        //    Beep((int)Music.Do, 300);
        //    Beep((int)Music.So, 300);
        //    Beep((int)Music.So, 300);
        //    Beep((int)Music.La, 300);
        //    Beep((int)Music.La, 300);
        //    Beep((int)Music.So, 600);

        //    Beep((int)Music.Fa, 300);
        //    Beep((int)Music.Fa, 300);
        //    Beep((int)Music.Mi, 300);
        //    Beep((int)Music.Mi, 300);
        //    Beep((int)Music.Re, 300);
        //    Beep((int)Music.Re, 300);
        //    Beep((int)Music.Do, 600);

        //}
    }
}
