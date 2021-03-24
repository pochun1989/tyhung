using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Drawing.Printing;
using System.Windows.Forms;
using System.Windows.Documents;

namespace TEST
{
    class DataGridViewPrint
    {

        //要列印的gridview
        private DataGridView TheDataGridView;
        //要傳給印表機的檔案
        private PrintDocument ThePrintDocument;
        //是否居中
        private bool IsCenterOnPage;
        //是否還有標題
        private bool IsWithTitle;
        //是否
        private bool IsWithPaging;
        //標題名稱
        private string TheTitleText;
        //標題字型
        private Font TheTitleFont;
        //標題顏色
        private Color TheTitleColor;

        //當前的行數
        static int CurrentRow = 0;
        //頁數
        public static int PageNumber = 0;

        //紙張的寬度
        private int PageWidth;
        //紙張的長度
        private int PageHeight;
        //左間距
        private int LeftMargin;
        //頂間距
        private int TopMatgin;
        //右間距
        private int RightMargin;
        //底間距
        private int BottomMargin;
        private float CurrentY;

        //列頭的高度
        private float RowHeaderHeight;
        //每行的高度
        private List RowsHeight;
        //每列的寬度
        private List ColumnsWidth;
        //整個表格的寬度
        private float TheDataGridViewWidth;
        public static List mColumnPoints;
        public static List mColumPointsWidth;
        public static int mColumnPoint;


        
        ///
        /// 有參建構函式
        ///
        /// 要列印的DataGridView
        /// 要傳給印表機的列印檔案
        /// 是否居中
        /// 是否包含標題
        /// 標題名稱
        /// 標題文字格式
        /// 標題的顏色
        ///
        public DataGridViewPrint(DataGridView theDataGridView, PrintDocument thePrintDocument, bool isCennterOnPage, bool isWithTitle, string theTitleText, Font theTitleFont, Color theTitleColor, bool isWithPaing)
        {
            TheDataGridView = theDataGridView;
            ThePrintDocument = thePrintDocument;
            IsCenterOnPage = isCennterOnPage;
            IsWithTitle = isWithTitle;
            IsWithPaging = isWithPaing;
            TheTitleText = theTitleText;
            TheTitleFont = theTitleFont;
            TheTitleColor = theTitleColor;
            IsWithPaging = isWithPaing;

            RowsHeight = new List();
            ColumnsWidth = new List();

            mColumnPoints = new List();
            mColumPointsWidth = new List();

            //根據使用者所選紙張縱向還是橫向來獲得紙張的高度和寬度
            if (!ThePrintDocument.DefaultPageSettings.Landscape)
            {
                //縱向
                PageWidth = ThePrintDocument.DefaultPageSettings.PaperSize.Width;
                PageHeight = ThePrintDocument.DefaultPageSettings.PaperSize.Height;
                LeftMargin = 10;
                RightMargin = 10;
                TopMatgin = 20;
                BottomMargin = 20;
            }
            else
            {
                //橫向
                PageWidth = ThePrintDocument.DefaultPageSettings.PaperSize.Height;
                PageHeight = ThePrintDocument.DefaultPageSettings.PaperSize.Width;
                LeftMargin = 20;
                RightMargin = 20;
            }
        }

    }


}
