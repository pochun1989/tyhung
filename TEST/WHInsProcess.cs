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
    public partial class WHInsProcess : Form
    {
        //System.Timers.Timer t = new System.Timers.Timer(1000);

        #region 建構函式

        public WHInsProcess()
        {
            InitializeComponent();
        }

        #endregion

        #region 畫面載入
        private void WHInsProcess_Load(object sender, EventArgs e)
        {

        }

        #endregion

        #region 變數

        DataSet ds = new DataSet();
        DataSet ds2 = new DataSet();
        DataSet ds3 = new DataSet();
        public string USERID;
        int x = 0;

        #endregion


        private void query()
        {
            try
            {

                DataBinding dbConn = new DataBinding();
                string sql = string.Format("select CARTONNO,a.Qty,count(DDCC) Size, CASE WHEN SB = 6  THEN 1  WHEN SB = 1  THEN 0 end as choice from YWCP as a left join (select * from YWBZPOS where DDBH = '{0}') as b on a.CARTONNO between b.CTQ and b.CTZ where (a.DDBH = '{1}' and a.SB = 1) or (a.DDBH = '{2}' and a.SB = 6) group by CARTONNO,a.QTY ,sb order by CARTONNO", tbOrder.Text, tbOrder.Text, tbOrder.Text);
                SqlDataAdapter adapter = new SqlDataAdapter(sql, dbConn.connection);
                adapter.Fill(ds, "訂單表");
                this.dgvCarton.DataSource = this.ds.Tables[0];

                


            }
            catch (Exception)
            {
            }
        }

        private void amount()
        {
            try
            {
                DataBinding conn2 = new DataBinding();
                string sql2 = string.Format("select count(CARTONBAR) as amount from YWCP where DDBH = '{0}'", tbOrder.Text);
                SqlCommand cmd2 = new SqlCommand(sql2, conn2.connection);
                SqlDataAdapter sda = new SqlDataAdapter(cmd2);
                DataTable dt2 = new DataTable();
                sda.Fill(dt2);
                conn2.OpenConnection();

                lblAmount.Text = dt2.Rows[0]["amount"].ToString().Trim();
                conn2.CloseConnection();       

                
            }
            catch (Exception)
            {
            }

        }

        private void InWarehouse()
        {

            try
            {
                DataBinding conn2 = new DataBinding();
                string sql2 = string.Format("select count(CARTONBAR) as amount from YWCP where DDBH = '{0}' and SB = '1' or DDBH = '{1}' and SB = '6'", tbOrder.Text, tbOrder.Text);
                SqlCommand cmd2 = new SqlCommand(sql2, conn2.connection);
                SqlDataAdapter sda = new SqlDataAdapter(cmd2);
                DataTable dt2 = new DataTable();
                sda.Fill(dt2);
                conn2.OpenConnection();

                lblInWare.Text = dt2.Rows[0]["amount"].ToString().Trim();
                conn2.CloseConnection();
               
            }
            catch (Exception)
            {
            }
        }

        private void SelectBox()
        {
            try
            {
                DataBinding conn2 = new DataBinding();
                string sql2 = string.Format("select count(CARTONBAR) as amount from YWCP where DDBH = '{0}' and SB = '6'", tbOrder.Text);
                SqlCommand cmd2 = new SqlCommand(sql2, conn2.connection);
                SqlDataAdapter sda = new SqlDataAdapter(cmd2);
                DataTable ds3 = new DataTable();
                sda.Fill(ds3);
                conn2.OpenConnection();

                lblSB.Text = ds3.Rows[0]["amount"].ToString().Trim();
                conn2.CloseConnection();

            }
            catch (Exception)
            {
            }
        }

        private void TsbQuery_Click(object sender, EventArgs e)
        {
            try
            {
                query();
                amount();
                InWarehouse();
                SelectBox();
                int a = 0;
                string d = "";
                a = int.Parse(lblInWare.ToString()) / int.Parse(lblAmount.ToString()) * 100;
                d = a.ToString() + "%";
                //lblPercent.Text = b;
                int start = 0, length = 2;
                if (d.Length > 2)
                {
                    lblPercent.Text = d.Substring(start, length + 1) + "%";
                }
                else
                {
                    lblPercent.Text = d.Substring(start, length) + "%";
                }
            }
            catch (Exception) { }
        }

        private void TbOrder_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)//如果输入的是回车键
                {
                    query();
                    amount();
                    InWarehouse();
                    SelectBox();
                    double a,b,c = 0;
                    int f;
                    string d = "";
                    a = double.Parse(lblAmount.Text);
                    b = double.Parse(lblInWare.Text);
                    c = b / a*100;
                    Console.WriteLine(a);
                    Console.WriteLine(b);
                    Console.WriteLine(c);
                    d = c.ToString();
                    int start = 0, length = 2;

                    Console.WriteLine(d.Length);
                    if (d.Length > 2)
                    {
                        lblPercent.Text = d.Substring(start, length + 1) + "%";
                    }
                    else
                    {
                        lblPercent.Text = d.Substring(start , length) + "%";
                    }
                    Console.WriteLine(d.Substring(start , length));

                    
                }
            }
            catch (Exception) { }
        }

        private void DgvCarton_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                
                
               
                //dgvCarton.CurrentRow.Cells[0].Value.ToString();

                DataBinding con4 = new DataBinding();
                StringBuilder sql4 = new StringBuilder();
                sql4.AppendFormat("update YWCP set SB = '6' where CARTONNO = '{0}' and DDBH = '{1}'", dgvCarton.CurrentRow.Cells[0].Value.ToString(), tbOrder.Text);
                SqlCommand cmd4 = new SqlCommand(sql4.ToString(), con4.connection);
                con4.OpenConnection();
                int result4 = cmd4.ExecuteNonQuery();
                if (result4 == 1)
                {                   
                    //MessageBox.Show("棧板綁定解除!");
                }
                con4.CloseConnection();

                //增加選擇數量     

                SelectBox();

                //dgvCarton.Rows[1].Cells[2].Value.ToString().Trim();
                string y = "1";
                dgvCarton.CurrentRow.Cells[3].Value = y;

                //int z = 0;
                //z = dgvCarton.Rows.Count;
                //for (int i = 0; i < z; i++)
                //{
                //    dgvCarton.Rows.RemoveAt(0);
                //}

                //query();

            }
            catch (Exception)
            {

            }
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                WHInspectionForm al = new WHInspectionForm();
                al.lblOrder.Text = tbOrder.Text;
                al.ShowDialog();
            }
            catch (Exception) { }
        }

        private void TsbExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void clear()
        {
            tbOrder.Text = "";
            lblAmount.Text = "0";
            lblInWare.Text = "0";
            lblPercent.Text = "0";
            lblSB.Text = "0";



            int c = 0;
            c = dgvCarton.Rows.Count;
            //Console.WriteLine(c);


            for (int d = 0; d < c; d++)
            {
                dgvCarton.Rows.RemoveAt(0);
            }
        }

        private void TspClear_Click(object sender, EventArgs e)
        {
            clear();
           
        }
        


        private void DgvCarton_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            WHInspectionDetail al = new WHInspectionDetail();
            al.CARTONBAR = dgvCarton.CurrentRow.Cells[0].Value.ToString();
            al.DDBH = tbOrder.Text;
            al.ShowDialog();
        }

        private void TsbDelete_Click(object sender, EventArgs e)
        {
            //dgvCarton.CurrentRow.Cells[3].Value.ToString().Trim();

            try
            {
                DialogResult dr = MessageBox.Show("Do you want to repick this order?", "系統提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                if (dr == DialogResult.OK)
                {

                    DataBinding con4 = new DataBinding();
                    StringBuilder sql4 = new StringBuilder();
                    sql4.AppendFormat("update YWCP set SB = '1' where  DDBH = '{0}' and SB = '6'",  tbOrder.Text);
                    SqlCommand cmd4 = new SqlCommand(sql4.ToString(), con4.connection);
                    con4.OpenConnection();
                    int result4 = cmd4.ExecuteNonQuery();
                    if (result4 == 1)
                    {
                        //MessageBox.Show("棧板綁定解除!");
                    }
                    con4.CloseConnection();

                    clear();
                }
            }
            catch (Exception) { }
        }

        private void TsbExcel_Click(object sender, EventArgs e)
        {
            ExportExcel("report", dgvCarton);
        }

        #region EXCEL

        public static void ExportExcel(string fileName, DataGridView myDGV)
        {
            if (myDGV.Rows.Count > 0)
            {

                string saveFileName = "";
                //bool fileSaved = false;  
                SaveFileDialog saveDialog = new SaveFileDialog();
                saveDialog.DefaultExt = "xls";
                saveDialog.Filter = "Excel文件|*.xls";
                saveDialog.FileName = fileName;
                saveDialog.ShowDialog();
                saveFileName = saveDialog.FileName;
                if (saveFileName.IndexOf(":") < 0) return; //被点了取消   
                Microsoft.Office.Interop.Excel.Application xlApp = new Microsoft.Office.Interop.Excel.Application();
                if (xlApp == null)
                {
                    MessageBox.Show("无法创建Excel对象，可能您的机子未安装Excel");
                    return;
                }

                Microsoft.Office.Interop.Excel.Workbooks workbooks = xlApp.Workbooks;
                Microsoft.Office.Interop.Excel.Workbook workbook = workbooks.Add(Microsoft.Office.Interop.Excel.XlWBATemplate.xlWBATWorksheet);
                Microsoft.Office.Interop.Excel.Worksheet worksheet = (Microsoft.Office.Interop.Excel.Worksheet)workbook.Worksheets[1];//取得sheet1  

                //写入标题  
                for (int i = 0; i < myDGV.ColumnCount; i++)
                {
                    worksheet.Cells[1, i + 1] = myDGV.Columns[i].HeaderText;
                }
                //写入数值  
                for (int r = 0; r < myDGV.Rows.Count; r++)
                {
                    for (int i = 0; i < myDGV.ColumnCount; i++)
                    {
                        worksheet.Cells[r + 2, i + 1] = myDGV.Rows[r].Cells[i].Value;
                    }
                    System.Windows.Forms.Application.DoEvents();
                }
                worksheet.Columns.EntireColumn.AutoFit();//列宽自适应  
                                                         //   if (Microsoft.Office.Interop.cmbxType.Text != "Notification")  
                                                         //   {  
                                                         //       Excel.Range rg = worksheet.get_Range(worksheet.Cells[2, 2], worksheet.Cells[ds.Tables[0].Rows.Count + 1, 2]);  
                                                         //      rg.NumberFormat = "00000000";  
                                                         //   }  

                if (saveFileName != "")
                {
                    try
                    {
                        workbook.Saved = true;
                        workbook.SaveCopyAs(saveFileName);
                        //fileSaved = true;  
                    }
                    catch (Exception ex)
                    {
                        //fileSaved = false;  
                        MessageBox.Show("导出文件时出错,文件可能正被打开！\n" + ex.Message);
                    }

                }
                //else  
                //{  
                //    fileSaved = false;  
                //}  
                xlApp.Quit();
                GC.Collect();//强行销毁   
                             // if (fileSaved && System.IO.File.Exists(saveFileName)) System.Diagnostics.Process.Start(saveFileName); //打开EXCEL  
                MessageBox.Show("导出文件成功", "提示", MessageBoxButtons.OK);
            }
            else
            {
                MessageBox.Show("报表为空,无表格需要导出", "提示", MessageBoxButtons.OK);
            }

        }

        #endregion
    }
}
