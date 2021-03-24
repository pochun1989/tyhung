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
    public partial class OrderDetail : Form
    {

        #region 建構函式

        public OrderDetail()
        {
            InitializeComponent();
        }

        #endregion

        #region 畫面載入

        private void OrderDetail_Load(object sender, EventArgs e)
        {
            OrderData();
            int x = 0;
            x = dgvOrderDetail.Width;
            dgvOrderDetail.Columns[2].FillWeight = 200;
            //dgvOrderDetail.Columns[1].FillWeight = x/8;
            //dgvOrderDetail.Columns[0].FillWeight = x/8*3;
        }

        #endregion

        #region 變數

        public string ordernum = "";
        DataSet ds = new DataSet();    
        DataSet ds2 = new DataSet();

        #endregion

        #region 方法

        private void OrderData()
        {
            try
            {
                ds = new DataSet();
                DataBinding dbConn = new DataBinding();
                string sql = string.Format("select cartonno,Qty,LastInDate from YWCP where SB = 1 and DDBH  = '{0}'", this.lbOrder.Text);


                Console.WriteLine(sql);
                SqlDataAdapter adapter = new SqlDataAdapter(sql, dbConn.connection);
                adapter.SelectCommand.CommandTimeout = 900;
                adapter.Fill(ds, "訂單表");
                this.dgvOrderDetail.DataSource = this.ds.Tables[0];
            }
            catch (Exception)
            {

            }
        }

        #endregion

        #region 事件

        #endregion

        private void DgvOrderDetail_SelectionChanged(object sender, EventArgs e)
        {
            int x = 0;
            string y = "";
            //x = dgvOrderDetail.CurrentRow.Cells[1].Value.ToString();
            y = dgvOrderDetail.CurrentRow.Cells[0].Value.ToString();
            x = int.Parse(y); 
            try
            {
                ds2 = new DataSet();
                DataBinding dbConn = new DataBinding();
                string sql = string.Format("select DDCC,Qty from YWBZPOS where DDBH = '{0}' and CTQ <= '{1}' and CTZ >= '{2}'", this.lbOrder.Text,x,x);


                Console.WriteLine(sql);
                SqlDataAdapter adapter = new SqlDataAdapter(sql, dbConn.connection);
                adapter.SelectCommand.CommandTimeout = 900;
                adapter.Fill(ds2, "訂單表");
                this.dgvInner.DataSource = this.ds2.Tables[0];
            }
            catch (Exception)
            {

            }

        }

        private void TsbExcel_Click(object sender, EventArgs e)
        {
            ExportExcel("report", dgvOrderDetail);
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
