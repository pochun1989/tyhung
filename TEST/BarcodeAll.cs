using System;
using System.Activities.Expressions;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TEST
{
    public partial class BarcodeAll : Form
    {
        Bitmap bitmap;
        public BarcodeAll()
        {
            InitializeComponent();
        }

        private void BarcodeAll_Load(object sender, EventArgs e)
        {

        }



        private void Button1_Click(object sender, EventArgs e)
        {
            #region 方法1

            //printDocument1.Print();

            #endregion

            #region 方法2

 

            //Show the Print Preview Dialog.
            printPreviewDialog1.Document = printDocument1;
            printPreviewDialog1.PrintPreviewControl.Zoom = 1;
            printPreviewDialog1.ShowDialog();

            #endregion
            
        }


        private void Button2_Click(object sender, EventArgs e)
        {
            //顯示頁面設定對話方塊
            //PageSetupDialog MyDlg = new PageSetupDialog();
            //MyDlg.Document = this.printDocument1;
            //MyDlg.ShowDialog();
        }

        private void PrintDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {

            #region 方法1

            //Bitmap bm = new Bitmap(this.dgvBARCODE.Width, this.dgvBARCODE.Height);
            //dgvBARCODE.DrawToBitmap(bm, new Rectangle(0, 0, this.dgvBARCODE.Width, this.dgvBARCODE.Height));
            //e.Graphics.DrawImage(bm, 0, 0);

            #endregion

            #region 方法2

            //Resize DataGridView to full height.
            int height = dgvBARCODE.Height;
            dgvBARCODE.Height = dgvBARCODE.RowCount * dgvBARCODE.RowTemplate.Height * 3;

            //Create a Bitmap and draw the DataGridView on it.
            bitmap = new Bitmap(this.dgvBARCODE.Width, this.dgvBARCODE.Height);
            dgvBARCODE.DrawToBitmap(bitmap, new Rectangle(0, 0, this.dgvBARCODE.Width, this.dgvBARCODE.Height));

            //Resize DataGridView back to original height.
            dgvBARCODE.Height = height;

            //Print the contents.
            e.Graphics.DrawImage(bitmap, 0, 0);

            #endregion

        }
    }
}
