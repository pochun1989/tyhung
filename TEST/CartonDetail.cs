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
    public partial class CartonDetail : Form
    {
        #region 建構函式
        public CartonDetail()
        {
            InitializeComponent();
        }
        #endregion

        #region 變數
        DataSet ds = new DataSet(); // 儲存資料表容器    
        DataSet ds2 = new DataSet();

        #endregion

        #region 畫面載入
        private void CartonDetail_Load(object sender, EventArgs e)
        {

        }
        #endregion

        #region 方法

        #region 載入CARTON

        private void CartonDate() 
        {
            ds = new DataSet();
            DataBinding dbConn = new DataBinding();

            string sql = string.Format("select CARTONBAR,qty,DepNo,KCBH,XH,CASE WHEN SB = 1 THEN '在庫 trong kho'  WHEN SB = 2 THEN '翻箱 tái chế'  WHEN SB = 3 THEN '出貨 đã xuất hàng' WHEN SB = 4 THEN '驗貨 kiểm hàng' WHEN SB = 6 THEN '待驗貨 chờ kiểm'  WHEN SB = 7 THEN '封箱 đóng thùng' WHEN SB = 8 THEN '單箱翻箱 tái chế thùng đơn' END as'狀態 trạng thái' ,INDATE as '第一次入庫日期', LastInDate as '最後入庫日期 ngày nhập kho cuối' ,OUTDATE as '翻箱日期 ngày tái chế' ,INSPECTDATE as '驗箱日期 ngày kiểm hàng' ,EXEDATE as '出貨日期 ngày xuất hàng' ,USERID as '最後使用者 người sử dụng cuối' ,USERDATE as '最後使用日期 ngày sử dụng cuối' from YWCP where DDBH = '{0}'", textBox1.Text);

            Console.WriteLine(sql);
            SqlDataAdapter adapter = new SqlDataAdapter(sql, dbConn.connection);
            adapter.SelectCommand.CommandTimeout = 900;
            adapter.Fill(ds, "訂單表");
            this.dgvCarton.DataSource = this.ds.Tables[0];
        }

        #endregion

        #region 細節

        private void detail()
        {
            try
            {
                ds = new DataSet();
                DataBinding dbConn = new DataBinding();

                string sql5 = string.Format("select XXCC as '尺寸', a.QTY as '入庫雙數', b.LHLabel as '內盒標號' from YWBZPOS as a left outer join (select * from SCLH) as b on a.DDCC = b.XXCC and a.DDBH = b.DDBH  where a.DDBH = '{0}' and XH = '{1}'", textBox1.Text, dgvCarton.CurrentRow.Cells[4].Value.ToString());

                Console.WriteLine(sql5);

                SqlDataAdapter adapter = new SqlDataAdapter(sql5, dbConn.connection);
                adapter.Fill(ds, "內箱表");
                this.dgvDetail.DataSource = this.ds.Tables[0];
            }
            catch (Exception) { }
        }

        #endregion

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

        #endregion

        #region 事件

        #endregion

        private void dgvCarton_SelectionChanged(object sender, EventArgs e)
        {
            detail();
        }

        private void tsbQuery_Click(object sender, EventArgs e)
        {
            CartonDate();
        }

        private void tspClear_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
        }

        private void tsbExcel_Click(object sender, EventArgs e)
        {
            ExportExcel("report", dgvCarton);
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)//如果输入的是回车键
            {
                CartonDate();
            }
        }
    }
}
