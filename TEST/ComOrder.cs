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
    public partial class ComOrder : Form
    {
        #region 建構函式

        public ComOrder()
        {
            InitializeComponent();
        }

        #endregion

        #region 畫面載入

        private void ComOrder_Load(object sender, EventArgs e)
        {
            tbOrder.Focus();
        }

        #endregion

        #region 變數
        DataSet ds = new DataSet(); // 儲存資料表容器    
        DataSet ds2 = new DataSet();
        #endregion

        private void TsbQuery_Click(object sender, EventArgs e)
        {
            ds = new DataSet();
            DataBinding dbConn = new DataBinding();

            if (tbOrder.Text == "")
            {
                string sql = string.Format(" select ywcp.DDBH,XXZl.Article, YWDD.QTY as DDQty, isnull(sum(case  when ywcp.sb > 0 then YWCP.Qty  end),0) as okQty ,YWDD.QTY-(isnull(sum(case  when ywcp.sb > 0 then YWCP.Qty  end),0)) as lackPairs ,s.QTYCH,s.QTYCK,s.QTYKC,s.QTYYH , CT.CTQty as DDCT, count(ywcp.CARTONBAR) as CTQty,s.ctch+s.ctck+s.ctkc+s.ctyh+s.cttran as okQty2, CT.CTQty-s.ctch-s.ctck-s.ctkc-s.ctyh-s.cttran as lackBOX ,s.ctch,s.ctck,s.ctkc,s.ctyh,s.cttran, DDZL.ShipDate, (ct.ctqty-s.ctkc-s.ctch-s.cttran) as ctlack, isnull(DDZL.CCGB,'U') as DDCC, isnull(XXZl.CCGB,'U') as XXCC, max(ywcp.USERDATE) as LastDate , ddzl.khbh , XXZL.XieXing, XXZl.SheHao,  XXZL.XieMing from YWCP left join ywdd on ywcp.DDBH=ywdd.DDBH AND ywcp.GSBH=YWDD.GSBH left join DDZL on ywdd.YSBH=DDZL.DDBH left join XXZL on XXZL.XieXing=DDZL.XieXing and XXZl.SheHao=DDZl.SheHao left join (SELECT GSBH,DDBH,SUM(CTS) AS CTQTY FROM YWBZPO GROUP BY GSBH,DDBH ) CT on CT.DDBH=YWDD.DDBH AND CT.GSBH=YWDD.GSBH left join (select * from DDZL where YN = 5 or YN = 3) as z on z.DDBH = YWCP.DDBH left join (select ddbh, isnull(count(case  when ywcp.sb = 1 then YWCP.CARTONBAR  end),0) as ctkc, isnull(count(case  when ywcp.sb = 2 or ywcp.sb = 8 then YWCP.CARTONBAR  end),0) as ctck, isnull(count(case  when ywcp.sb = 3 then YWCP.CARTONBAR  end),0) as ctch, isnull(count(case  when ywcp.sb = 4 then YWCP.CARTONBAR  end),0) as ctyh, isnull(count(case  when ywcp.sb = 7 then YWCP.CARTONBAR  end),0) as cttran, isnull(sum(case  when ywcp.sb =3  then YWCP.Qty  end),0) as QTYCH, isnull(sum(case  when ywcp.sb =2 or ywcp.sb = 8 then YWCP.Qty  end),0) as QTYCK, isnull(sum(case  when ywcp.sb =4  then YWCP.Qty  end),0) as QTYYH, isnull(sum(case  when ywcp.sb =1  then YWCP.Qty  end),0) as QTYKC from YWCP group by DDBH) s on s.ddbh=ywcp.DDBH where (ywcp.EXEDATE) between '{0}' and  DATEADD ( DAY, 1 , '{1}' ) and (z.YN = 3 or z.YN = 5) group by YWCP.DDBH,XXZL.XieXing,XXZl.SheHao, XXZl.Article, XXZL.XieMing, DDZL.ShipDate, YWDD.QTY, CT.CTQty, DDZL.CCGB, XXZL.CCGB, s.ctch,s.ctck,s.ctkc,s.ctyh,s.cttran,s.QTYCH,s.QTYCK,s.QTYKC,s.QTYYH, ddzl.khbh order by YWCP.DDBH ", dtpFrom.Text, dtpTo.Text);
                Console.WriteLine(sql);
                SqlDataAdapter adapter = new SqlDataAdapter(sql, dbConn.connection);
                adapter.SelectCommand.CommandTimeout = 900;
                adapter.Fill(ds, "訂單表");
                this.dgvOrder.DataSource = this.ds.Tables[0];
            }
            else
            {
                //string sql = string.Format(" select ywcp.DDBH,XXZl.Article, YWDD.QTY as DDQty, isnull(sum(case  when ywcp.sb > 0 then YWCP.Qty  end),0) as okQty ,YWDD.QTY-(isnull(sum(case  when ywcp.sb > 0 then YWCP.Qty  end),0)) as lackPairs ,s.QTYCH,s.QTYCK,s.QTYKC,s.QTYYH ,s.QTYTRAN, CT.CTQty as DDCT, count(ywcp.CARTONBAR) as CTQty,s.ctch+s.ctck+s.ctkc+s.ctyh as okQty2, CT.CTQty-s.ctch-s.ctck-s.ctkc-s.ctyh as lackBOX ,s.ctch,s.ctck,s.ctkc,s.ctyh, DDZL.ShipDate, (ct.ctqty-s.ctkc-s.ctch) as ctlack, isnull(DDZL.CCGB,'U') as DDCC, isnull(XXZl.CCGB,'U') as XXCC, max(ywcp.USERDATE) as LastDate , ddzl.khbh , XXZL.XieXing, XXZl.SheHao,  XXZL.XieMing from YWCP left join ywdd on ywcp.DDBH=ywdd.DDBH AND ywcp.GSBH=YWDD.GSBH left join DDZL on ywdd.YSBH=DDZL.DDBH left join XXZL on XXZL.XieXing=DDZL.XieXing and XXZl.SheHao=DDZl.SheHao left join (SELECT GSBH,DDBH,SUM(CTS) AS CTQTY FROM YWBZPO GROUP BY GSBH,DDBH ) CT on CT.DDBH=YWDD.DDBH AND CT.GSBH=YWDD.GSBH left join (select * from DDZL where YN = 5 or YN = 3) as z on z.DDBH = YWCP.DDBH left join (select ddbh, isnull(count(case  when ywcp.sb = 1 then YWCP.CARTONBAR  end),0) as ctkc, isnull(count(case  when ywcp.sb = 2 or ywcp.sb = 8 then YWCP.CARTONBAR  end),0) as ctck, isnull(count(case  when ywcp.sb = 3 then YWCP.CARTONBAR  end),0) as ctch, isnull(count(case  when ywcp.sb = 4 then YWCP.CARTONBAR  end),0) as ctyh, isnull(sum(case  when ywcp.sb =3  then YWCP.Qty  end),0) as QTYCH, isnull(sum(case  when ywcp.sb =2 or ywcp.sb = 8 then YWCP.Qty  end),0) as QTYCK, isnull(sum(case  when ywcp.sb =4  then YWCP.Qty  end),0) as QTYYH, isnull(sum(case  when ywcp.sb =1  then YWCP.Qty  end),0) as QTYKC, isnull(sum(case  when ywcp.sb =7  then YWCP.Qty  end),0) as QTYTRAN from YWCP group by DDBH) s on s.ddbh=ywcp.DDBH  where ywcp.DDBH like '{0}%' and (ywcp.EXEDATE) between '{1}' and  DATEADD ( DAY, 1 , '{2}' ) and (z.YN = 3 or z.YN = 5) group by YWCP.DDBH,XXZL.XieXing,XXZl.SheHao, XXZl.Article, XXZL.XieMing, DDZL.ShipDate, YWDD.QTY, CT.CTQty, DDZL.CCGB, XXZL.CCGB, s.ctch,s.ctck,s.ctkc,s.ctyh,s.QTYCH,s.QTYCK,s.QTYKC,s.QTYYH,s.QTYTRAN, ddzl.khbh order by YWCP.DDBH ", tbOrder.Text.Trim(), dtpFrom.Text, dtpTo.Text);
                string sql = string.Format(" select ywcp.DDBH,XXZl.Article, YWDD.QTY as DDQty, isnull(sum(case  when ywcp.sb > 0 then YWCP.Qty  end),0) as okQty ,YWDD.QTY-(isnull(sum(case  when ywcp.sb > 0 then YWCP.Qty  end),0)) as lackPairs ,s.QTYCH,s.QTYCK,s.QTYKC,s.QTYYH , CT.CTQty as DDCT, count(ywcp.CARTONBAR) as CTQty,s.ctch+s.ctck+s.ctkc+s.ctyh+s.cttran as okQty2, CT.CTQty-s.ctch-s.ctck-s.ctkc-s.ctyh-s.cttran as lackBOX ,s.ctch,s.ctck,s.ctkc,s.ctyh,s.cttran, DDZL.ShipDate, (ct.ctqty-s.ctkc-s.ctch-s.cttran) as ctlack, isnull(DDZL.CCGB,'U') as DDCC, isnull(XXZl.CCGB,'U') as XXCC, max(ywcp.USERDATE) as LastDate , ddzl.khbh , XXZL.XieXing, XXZl.SheHao,  XXZL.XieMing from YWCP left join ywdd on ywcp.DDBH=ywdd.DDBH AND ywcp.GSBH=YWDD.GSBH left join DDZL on ywdd.YSBH=DDZL.DDBH left join XXZL on XXZL.XieXing=DDZL.XieXing and XXZl.SheHao=DDZl.SheHao left join (SELECT GSBH,DDBH,SUM(CTS) AS CTQTY FROM YWBZPO GROUP BY GSBH,DDBH ) CT on CT.DDBH=YWDD.DDBH AND CT.GSBH=YWDD.GSBH left join (select * from DDZL where YN = 5 or YN = 3) as z on z.DDBH = YWCP.DDBH left join (select ddbh, isnull(count(case  when ywcp.sb = 1 then YWCP.CARTONBAR  end),0) as ctkc, isnull(count(case  when ywcp.sb = 2 or ywcp.sb = 8 then YWCP.CARTONBAR  end),0) as ctck, isnull(count(case  when ywcp.sb = 3 then YWCP.CARTONBAR  end),0) as ctch, isnull(count(case  when ywcp.sb = 4 then YWCP.CARTONBAR  end),0) as ctyh, isnull(count(case  when ywcp.sb = 7 then YWCP.CARTONBAR  end),0) as cttran, isnull(sum(case  when ywcp.sb =3  then YWCP.Qty  end),0) as QTYCH, isnull(sum(case  when ywcp.sb =2 or ywcp.sb = 8 then YWCP.Qty  end),0) as QTYCK, isnull(sum(case  when ywcp.sb =4  then YWCP.Qty  end),0) as QTYYH, isnull(sum(case  when ywcp.sb =1  then YWCP.Qty  end),0) as QTYKC from YWCP group by DDBH) s on s.ddbh=ywcp.DDBH where ywcp.DDBH like '{0}%' and (ywcp.EXEDATE) between '{1}' and  DATEADD ( DAY, 1 , '{2}' ) and (z.YN = 3 or z.YN = 5) group by YWCP.DDBH,XXZL.XieXing,XXZl.SheHao, XXZl.Article, XXZL.XieMing, DDZL.ShipDate, YWDD.QTY, CT.CTQty, DDZL.CCGB, XXZL.CCGB, s.ctch,s.ctck,s.ctkc,s.ctyh,s.cttran,s.QTYCH,s.QTYCK,s.QTYKC,s.QTYYH, ddzl.khbh order by YWCP.DDBH ", tbOrder.Text.Trim(), dtpFrom.Text, dtpTo.Text);

                Console.WriteLine(sql);
                SqlDataAdapter adapter = new SqlDataAdapter(sql, dbConn.connection);
                adapter.SelectCommand.CommandTimeout = 900;
                adapter.Fill(ds, "訂單表");
                this.dgvOrder.DataSource = this.ds.Tables[0];
            }

            dgvOrder.Columns[3].DefaultCellStyle.BackColor = System.Drawing.Color.LightGreen;
            dgvOrder.Columns[4].DefaultCellStyle.BackColor = System.Drawing.Color.YellowGreen;
            dgvOrder.Columns[5].DefaultCellStyle.BackColor = System.Drawing.Color.LightGreen;
            dgvOrder.Columns[6].DefaultCellStyle.BackColor = System.Drawing.Color.LightGreen;
            dgvOrder.Columns[7].DefaultCellStyle.BackColor = System.Drawing.Color.LightGreen;
            dgvOrder.Columns[8].DefaultCellStyle.BackColor = System.Drawing.Color.LightGreen;
            dgvOrder.Columns[2].DefaultCellStyle.BackColor = System.Drawing.Color.LightGreen;
            dgvOrder.Columns[9].DefaultCellStyle.BackColor = System.Drawing.Color.LightYellow;
            dgvOrder.Columns[10].DefaultCellStyle.BackColor = System.Drawing.Color.LightYellow;
            dgvOrder.Columns[11].DefaultCellStyle.BackColor = System.Drawing.Color.LightYellow;
            dgvOrder.Columns[12].DefaultCellStyle.BackColor = System.Drawing.Color.YellowGreen;
            dgvOrder.Columns[13].DefaultCellStyle.BackColor = System.Drawing.Color.LightYellow;
            dgvOrder.Columns[14].DefaultCellStyle.BackColor = System.Drawing.Color.LightYellow;
            dgvOrder.Columns[15].DefaultCellStyle.BackColor = System.Drawing.Color.LightYellow;
            dgvOrder.Columns[16].DefaultCellStyle.BackColor = System.Drawing.Color.LightYellow;
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
                    MessageBox.Show("未安装Excel。Chưa cài đặt EXCEL");
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
                        MessageBox.Show("文件出錯！\n" + ex.Message);
                    }

                }
                //else  
                //{  
                //    fileSaved = false;  
                //}  
                xlApp.Quit();
                GC.Collect();//强行销毁   
                             // if (fileSaved && System.IO.File.Exists(saveFileName)) System.Diagnostics.Process.Start(saveFileName); //打开EXCEL  
                MessageBox.Show("導出文件成功。Xuất tập tin thành công", "提示", MessageBoxButtons.OK);
            }
            else
            {
                MessageBox.Show("報表為空白。Báo cáo trống", "提示", MessageBoxButtons.OK);
            }

        }

        #endregion

        private void ComOrder_Shown(object sender, EventArgs e)
        {
            tbOrder.Focus();
        }

        private void TsbExcel_Click(object sender, EventArgs e)
        {
            ExportExcel("report", dgvOrder);
        }

        private void DgvOrder_DoubleClick(object sender, EventArgs e)
        {
            WHFinBox appw = new WHFinBox();
            appw.DDBH = dgvOrder.CurrentRow.Cells[0].Value.ToString();
            appw.ShowDialog();
        }
    }
}
