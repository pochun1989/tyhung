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
    public partial class WHStorageNow : Form
    {

        #region 建構函式
        public WHStorageNow()
        {
            InitializeComponent();
        }

        #endregion

        #region 變數

        DataSet ds = new DataSet(); // 儲存資料表容器    
        DataSet ds2 = new DataSet();
        public string USERID;

        #endregion

        #region 畫面載入

        private void WHStorageNow_Load(object sender, EventArgs e)
        {
            
        }

        #endregion

        #region 方法

        #region 全部
        private void start()
        {
            try
            {
                ds = new DataSet();
                DataBinding dbConn = new DataBinding();

                string sql = string.Format("select ywcp.DDBH,XXZl.Article, YWDD.QTY as DDQty ,YWDD.QTY-s.QTYKC as WIPQTY , isnull(s.QTYCK+s.QTYKC+s.QTTRAN+s.QTYYH, 0) as okQty, YWDD.QTY - (isnull(s.QTYCK+s.QTYKC+s.QTTRAN+s.QTYYH, 0)) as lackPairs, s.QTYCH, s.QTYCK, s.QTYKC, s.QTTRAN, s.QTYYH, s.gg as StoreCheck, CT.CTQty as DDCT, count(ywcp.CARTONBAR) as CTQty,CT.CTQty-s.ctkc as WIPCTN , s.ctch + s.ctck + s.ctkc + s.ctyh + s.cttran as okQty2, CT.CTQty - s.ctch - s.ctck - s.ctkc - s.ctyh - s.cttran as lackBOX, s.ctch, s.ctck, s.ctkc, s.ctyh, s.cttran, DDZL.ShipDate, isnull(DDZL.CCGB, 'U') as DDCC, isnull(XXZl.CCGB, 'U') as XXCC, max(ywcp.USERDATE) as LastDate, ddzl.khbh, XXZL.XieXing, XXZl.SheHao, XXZL.XieMing from YWCP left join ywdd on ywcp.DDBH = ywdd.DDBH AND ywcp.GSBH = YWDD.GSBH left join DDZL on ywdd.YSBH = DDZL.DDBH left join XXZL on XXZL.XieXing = DDZL.XieXing and XXZl.SheHao = DDZl.SheHao left join(SELECT GSBH, DDBH, SUM(CTS) AS CTQTY FROM YWBZPO GROUP BY GSBH, DDBH) CT on CT.DDBH = YWDD.DDBH AND CT.GSBH = YWDD.GSBH left join(select ddbh, isnull(count(case  when ywcp.sb = 1 then YWCP.CARTONBAR  end), 0) as ctkc, isnull(count(case  when ywcp.sb = 2 or ywcp.sb = 8  then YWCP.CARTONBAR  end), 0) as ctck, isnull(count(case  when ywcp.sb = 3 then YWCP.CARTONBAR  end), 0) as ctch, isnull(count(case  when ywcp.sb = 4 then YWCP.CARTONBAR  end), 0) as ctyh, isnull(count(case  when ywcp.sb = 7 then YWCP.CARTONBAR  end), 0) as cttran, isnull(sum(case  when ywcp.sb = 3  then YWCP.Qty  end), 0) as QTYCH, isnull(sum(case  when ywcp.sb = 2 or ywcp.sb = 8 then YWCP.Qty  end), 0) as QTYCK, isnull(sum(case  when ywcp.sb = 4  then YWCP.Qty  end), 0) as QTYYH, isnull(sum(case  when ywcp.sb = 7  then YWCP.Qty  end), 0) as QTTRAN, isnull(sum(case  when ywcp.sb = 1  then YWCP.Qty  end), 0) as QTYKC, count(case  when(FSA_Locate is null and ywcp.sb <> 3) then YWCP.CARTONBAR  end) as gg  from YWCP left join PalletDetail on YWCP.CARTONBAR = PalletDetail.CARTONBAR   left join FStorageAreaDetail on PalletDetail.Pallet_NO = FStorageAreaDetail.Pallet_NO      group by DDBH) s on s.ddbh = ywcp.DDBH where CT.CTQty <> s.ctch and ddzl.yn <> '5' and YWCP.SB = 1 group by YWCP.DDBH, XXZL.XieXing, XXZl.SheHao, XXZl.Article, XXZL.XieMing, DDZL.ShipDate, YWDD.QTY, CT.CTQty, DDZL.CCGB, XXZL.CCGB, s.ctch, s.ctck, s.ctkc, s.ctyh, s.cttran, s.QTYCH, s.QTYCK, s.QTYKC, s.QTTRAN, s.QTYYH, ddzl.khbh, s.gg order by YWCP.DDBH");

                Console.WriteLine(sql);
                SqlDataAdapter adapter = new SqlDataAdapter(sql, dbConn.connection);
                adapter.SelectCommand.CommandTimeout = 900;
                adapter.Fill(ds, "訂單表");
                this.dgvWarehouse.DataSource = this.ds.Tables[0];


            }
            catch (Exception)
            { }
        }
        #endregion

        #region 當天

        private void today()
        {
            ds = new DataSet();
            DataBinding dbConn = new DataBinding();

            string sql = string.Format("select ywcp.DDBH,XXZl.Article, YWDD.QTY as DDQty, isnull(sum(case  when ywcp.sb > 0 then YWCP.Qty  end),0) as okQty ,YWDD.QTY-(isnull(sum(case  when ywcp.sb > 0 then YWCP.Qty  end),0)) as lackPairs ,s.QTYCH,s.QTYCK,s.QTYKC,s.QTYYH , CT.CTQty as DDCT, count(ywcp.CARTONBAR) as CTQty,s.ctch+s.ctck+s.ctkc+s.ctyh as okQty2, CT.CTQty-s.ctch-s.ctck-s.ctkc-s.ctyh as lackBOX , s.ctch,s.ctck,s.ctkc,s.ctyh, DDZL.ShipDate, (ct.ctqty-s.ctkc-s.ctch) as ctlack, isnull(DDZL.CCGB,'U') as DDCC, isnull(XXZl.CCGB,'U') as XXCC, max(ywcp.USERDATE) as LastDate , ddzl.khbh , XXZL.XieXing, XXZl.SheHao,  XXZL.XieMing from YWCP left join ywdd on ywcp.DDBH=ywdd.DDBH AND ywcp.GSBH=YWDD.GSBH left join DDZL on ywdd.YSBH=DDZL.DDBH left join XXZL on XXZL.XieXing=DDZL.XieXing and XXZl.SheHao=DDZl.SheHao left join (SELECT GSBH,DDBH,SUM(CTS) AS CTQTY FROM YWBZPO GROUP BY GSBH,DDBH ) CT on CT.DDBH=YWDD.DDBH AND CT.GSBH=YWDD.GSBH left join 	(select ddbh, isnull(count(case  when ywcp.sb = 1 then YWCP.CARTONBAR  end),0) as ctkc, isnull(count(case  when ywcp.sb = 2 or ywcp.sb = 8 then YWCP.CARTONBAR  end),0) as ctck, isnull(count(case  when ywcp.sb = 3 then YWCP.CARTONBAR  end),0) as ctch, isnull(count(case  when ywcp.sb = 4 then YWCP.CARTONBAR  end),0) as ctyh, isnull(sum(case  when ywcp.sb =3  then YWCP.Qty  end),0) as QTYCH, isnull(sum(case  when ywcp.sb =2 or ywcp.sb = 8 then YWCP.Qty  end),0) as QTYCK, isnull(sum(case  when ywcp.sb =4  then YWCP.Qty  end),0) as QTYYH, isnull(sum(case  when ywcp.sb =1  then YWCP.Qty  end),0) as QTYKC from YWCP group by DDBH) s on s.ddbh=ywcp.DDBH where CT.CTQty<>s.ctch   and YWCP.SB = 1 group by YWCP.DDBH,XXZL.XieXing,XXZl.SheHao, XXZl.Article, XXZL.XieMing, DDZL.ShipDate, YWDD.QTY, CT.CTQty, DDZL.CCGB, XXZL.CCGB, s.ctch,s.ctck,s.ctkc,s.ctyh,s.QTYCH,s.QTYCK,s.QTYKC,s.QTYYH, ddzl.khbh order by YWCP.DDBH ");
           

            Console.WriteLine(sql);
            SqlDataAdapter adapter = new SqlDataAdapter(sql, dbConn.connection);
            adapter.SelectCommand.CommandTimeout = 900;
            adapter.Fill(ds, "訂單表");
            this.dgvWarehouse.DataSource = this.ds.Tables[0];
        }

        #endregion

        #region 細節

        private void detail()
        {
            try
            {
                ds = new DataSet();
                DataBinding dbConn = new DataBinding();

                string sql = string.Format("select LHLabel,QTY,SCQTY,XXCC from SCLH where DDBH = '{0}'", dgvWarehouse.CurrentRow.Cells[0].Value.ToString());

                Console.WriteLine(sql);
                SqlDataAdapter adapter = new SqlDataAdapter(sql, dbConn.connection);
                adapter.SelectCommand.CommandTimeout = 900;
                adapter.Fill(ds, "訂單表");
                this.dgvDetail.DataSource = this.ds.Tables[0];
            }
            catch (Exception) { }
        }

        #endregion

        #region 變色

        private void ColorChange()
        {
           
        }

        #endregion

        #endregion

        #region 事件

        #endregion

        private void TsbExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
                                                    
            WHToday al = new WHToday();
            //al.TopLevel = false; // 在最上層
            //al.FormBorderStyle = FormBorderStyle.None; // 清除邊框
            //splitContainer1.Panel2.Controls.Add(al); // 工作表加視窗

            //al.Width = splitContainer1.Panel2.Width;
            //al.Height = splitContainer1.Panel2.Height;
            al.Show(); // 視窗顯示
        }

        private void DgvWarehouse_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                OrderDetail appw = new OrderDetail();
                appw.lbOrder.Text = dgvWarehouse.CurrentRow.Cells[0].Value.ToString();

                appw.Height = 500;
                appw.Width = 600;
                //appw.lbDDBH.Text = tbOrder.Text;

                appw.TopMost = true;
                appw.ShowDialog();
            }
            catch (Exception)
            { }
        }

        private void DgvWarehouse_SelectionChanged(object sender, EventArgs e)
        {
            detail();
        }

        private void TsbExcel_Click(object sender, EventArgs e)
        {
            ExportExcel("report", dgvWarehouse);
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

        private void DgvDetail_DoubleClick(object sender, EventArgs e)
        {
            ChangeScqty Form = new ChangeScqty();
            Form.ddbh = dgvWarehouse.CurrentRow.Cells[0].Value.ToString();
            Form.lhlabel = dgvDetail.CurrentRow.Cells[0].Value.ToString();
            Form.scqty = dgvDetail.CurrentRow.Cells[2].Value.ToString();

            Form.Show();

            start();
        }

        private void TsbQuery_Click(object sender, EventArgs e)
        {
            try
            {
                start();

                dgvWarehouse.Columns[0].Width = 100;

                dgvWarehouse.Columns[2].DefaultCellStyle.BackColor = System.Drawing.Color.LightGreen;
                dgvWarehouse.Columns[3].DefaultCellStyle.BackColor = System.Drawing.Color.YellowGreen;
                dgvWarehouse.Columns[4].DefaultCellStyle.BackColor = System.Drawing.Color.LightGreen;
                dgvWarehouse.Columns[5].DefaultCellStyle.BackColor = System.Drawing.Color.LightGreen;
                dgvWarehouse.Columns[6].DefaultCellStyle.BackColor = System.Drawing.Color.LightGreen;
                dgvWarehouse.Columns[7].DefaultCellStyle.BackColor = System.Drawing.Color.LightGreen;
                dgvWarehouse.Columns[8].DefaultCellStyle.BackColor = System.Drawing.Color.LightGreen;
                dgvWarehouse.Columns[9].DefaultCellStyle.BackColor = System.Drawing.Color.LightGreen;
                dgvWarehouse.Columns[10].DefaultCellStyle.BackColor = System.Drawing.Color.LightGreen;


                dgvWarehouse.Columns[11].DefaultCellStyle.BackColor = System.Drawing.Color.YellowGreen;
                dgvWarehouse.Columns[12].DefaultCellStyle.BackColor = System.Drawing.Color.LightYellow;
                dgvWarehouse.Columns[13].DefaultCellStyle.BackColor = System.Drawing.Color.LightYellow;
                dgvWarehouse.Columns[14].DefaultCellStyle.BackColor = System.Drawing.Color.YellowGreen;
                dgvWarehouse.Columns[15].DefaultCellStyle.BackColor = System.Drawing.Color.LightYellow;
                dgvWarehouse.Columns[16].DefaultCellStyle.BackColor = System.Drawing.Color.LightYellow;
                dgvWarehouse.Columns[17].DefaultCellStyle.BackColor = System.Drawing.Color.LightYellow;
                dgvWarehouse.Columns[18].DefaultCellStyle.BackColor = System.Drawing.Color.LightYellow;
                dgvWarehouse.Columns[19].DefaultCellStyle.BackColor = System.Drawing.Color.LightYellow;
                dgvWarehouse.Columns[20].DefaultCellStyle.BackColor = System.Drawing.Color.LightYellow;
                dgvWarehouse.Columns[21].DefaultCellStyle.BackColor = System.Drawing.Color.LightYellow;

                int c = 0;
                c = dgvWarehouse.RowCount;
                //MessageBox.Show(dgvWarehouse.Rows[0].Cells[14].Value.ToString());

                int a = 0, b = 0, f = 0, d = 0;

                for (int i = 0; i < c; i++)
                {
                    if (dgvWarehouse.Rows[i].Cells[9].Value.ToString() != "") 
                    {
                        a = int.Parse(dgvWarehouse.Rows[i].Cells[9].Value.ToString());
                    }
                    if (dgvWarehouse.Rows[i].Cells[10].Value.ToString() != "") 
                    {
                        b = int.Parse(dgvWarehouse.Rows[i].Cells[10].Value.ToString());
                    }
                    if (dgvWarehouse.Rows[i].Cells[14].Value.ToString() != "")
                    {
                        f = int.Parse(dgvWarehouse.Rows[i].Cells[14].Value.ToString());
                    }
                    if (dgvWarehouse.Rows[i].Cells[16].Value.ToString() != "")                    
                    {
                        d = int.Parse(dgvWarehouse.Rows[i].Cells[16].Value.ToString());
                    }


                    if (f > 0)
                    {
                        dgvWarehouse.Rows[i].DefaultCellStyle.ForeColor = System.Drawing.Color.Red;
                        Console.WriteLine("Red");
                    }
                    else if (d > 0)
                    {
                        dgvWarehouse.Rows[i].DefaultCellStyle.ForeColor = System.Drawing.Color.Purple;
                        Console.WriteLine("Purple");
                    }
                    else if (a == b)
                    {
                        dgvWarehouse.Rows[i].DefaultCellStyle.ForeColor = System.Drawing.Color.Blue;
                        Console.WriteLine("Blue");
                    }

                }
            }
            catch (Exception) { }
        }

        private void tsButton_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void dgvWarehouse_SelectionChanged_1(object sender, EventArgs e)
        {
            detail();
        }
    }
}
