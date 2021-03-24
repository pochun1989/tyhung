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
using Excel = Microsoft.Office.Interop.Excel;

namespace TEST
{
    public partial class WHROStatusInWarehouse : Form
    {
        #region 建構函式

        public WHROStatusInWarehouse()
        {
            InitializeComponent();
        }

        #endregion

        #region 畫面載入

        private void WHROStatusInWarehouse_Load(object sender, EventArgs e)
        {
            //cbKCBH.IntegralHeight = false;
            //StatusData();
            Combobox();

            
        }

        #endregion

        #region 變數

        DataSet ds = new DataSet(); // 儲存資料表容器    
        DataSet ds2 = new DataSet();
        public string USERID;

        #endregion

        #region DataGridView方法
        
        private void StatusData()
        {
            ds = new DataSet();
            DataBinding dbConn = new DataBinding();
            try
            {
                if (tbKCBH.Text == "")
                {
                    if (tbOrder.Text == "")
                    {
                        string sql = string.Format("select ywcp.DDBH,XXZl.Article, YWDD.QTY as DDQty  , isnull(s.QTYCK+s.QTYKC+s.QTTRAN+s.QTYYH, 0) as okQty  , YWDD.QTY - isnull(s.QTYCK+s.QTYKC+s.QTTRAN+s.QTYYH, 0) as lackPairs    , s.QTYCH, s.QTYCK, s.QTYKC, s.QTTRAN, s.QTYYH, s.gg as StoreCheck,s.QTYPRE, CT.CTQty as DDCT     , count(ywcp.CARTONBAR) as CTQty, s.ctch + s.ctck + s.ctkc + s.ctyh + s.cttran as okQty2    , CT.CTQty - s.ctch - s.ctck - s.ctkc - s.ctyh - s.cttran as lackBOX    , s.ctch, s.ctck, s.ctkc, s.ctyh, s.cttran, s.PreStore, DDZL.ShipDate, isnull(DDZL.CCGB, 'U') as DDCC    , isnull(XXZl.CCGB, 'U') as XXCC, max(ywcp.USERDATE) as LastDate    , ddzl.khbh, XXZL.XieXing, XXZl.SheHao, XXZL.XieMing from YWCP left join ywdd on ywcp.DDBH = ywdd.DDBH AND ywcp.GSBH = YWDD.GSBH left join DDZL on ywdd.YSBH = DDZL.DDBH left join XXZL on XXZL.XieXing = DDZL.XieXing and XXZl.SheHao = DDZl.SheHao left join(SELECT GSBH, DDBH, SUM(CTS) AS CTQTY FROM YWBZPO GROUP BY GSBH, DDBH) CT on CT.DDBH = YWDD.DDBH AND CT.GSBH = YWDD.GSBH left join(select ddbh     , isnull(count(case  when ywcp.sb = 1 then YWCP.CARTONBAR  end), 0) as ctkc     , isnull(count(case  when ywcp.sb = 2 or ywcp.sb = 8  then YWCP.CARTONBAR  end), 0) as ctck     , isnull(count(case  when ywcp.sb = 3 then YWCP.CARTONBAR  end), 0) as ctch     , isnull(count(case  when ywcp.sb = 4 then YWCP.CARTONBAR  end), 0) as ctyh     , isnull(count(case  when ywcp.sb = 7 then YWCP.CARTONBAR  end), 0) as cttran    , isnull(count(case  when ywcp.sb = 9 then YWCP.CARTONBAR  end), 0) as PreStore   , isnull(sum(case  when ywcp.sb = 3  then YWCP.Qty  end), 0) as QTYCH     , isnull(sum(case  when ywcp.sb = 2 or ywcp.sb = 8 then YWCP.Qty  end), 0) as QTYCK     , isnull(sum(case  when ywcp.sb = 4  then YWCP.Qty  end), 0) as QTYYH    , isnull(sum(case  when ywcp.sb = 9  then YWCP.Qty  end), 0) as QTYPRE  , isnull(sum(case  when ywcp.sb = 7  then YWCP.Qty  end), 0) as QTTRAN     , isnull(sum(case  when ywcp.sb = 1  then YWCP.Qty  end), 0) as QTYKC   , count(case  when(FSA_Locate is null and ywcp.sb <> 3) then YWCP.CARTONBAR  end) as gg  from YWCP   left join PalletDetail on YWCP.CARTONBAR = PalletDetail.CARTONBAR   left join FStorageAreaDetail on PalletDetail.Pallet_NO = FStorageAreaDetail.Pallet_NO      group by DDBH) s on s.ddbh = ywcp.DDBH where CT.CTQty <> s.ctch and ddzl.yn <> '5' group by YWCP.DDBH, XXZL.XieXing, XXZl.SheHao, XXZl.Article, XXZL.XieMing     , DDZL.ShipDate, YWDD.QTY, CT.CTQty, DDZL.CCGB, XXZL.CCGB, s.ctch, s.ctck, s.ctkc, s.ctyh     , s.cttran, s.QTYCH, s.QTYCK, s.QTYKC, s.QTTRAN, s.QTYYH, ddzl.khbh, s.gg, s.PreStore,s.QTYPRE order by YWCP.DDBH");

                        Console.WriteLine(sql);
                        SqlDataAdapter adapter = new SqlDataAdapter(sql, dbConn.connection);
                        adapter.SelectCommand.CommandTimeout = 900;
                        adapter.Fill(ds, "訂單表");
                        this.dgvStatus.DataSource = this.ds.Tables[0];
                    }
                    else 
                    {

                        string sql = string.Format("select ywcp.DDBH,XXZl.Article, YWDD.QTY as DDQty  , isnull(s.QTYCK+s.QTYKC+s.QTTRAN+s.QTYYH, 0) as okQty  , YWDD.QTY - isnull(s.QTYCK+s.QTYKC+s.QTTRAN+s.QTYYH, 0) as lackPairs    , s.QTYCH, s.QTYCK, s.QTYKC, s.QTTRAN, s.QTYYH, s.gg as StoreCheck,s.QTYPRE, CT.CTQty as DDCT     , count(ywcp.CARTONBAR) as CTQty, s.ctch + s.ctck + s.ctkc + s.ctyh + s.cttran as okQty2    , CT.CTQty - s.ctch - s.ctck - s.ctkc - s.ctyh - s.cttran as lackBOX    , s.ctch, s.ctck, s.ctkc, s.ctyh, s.cttran, s.PreStore, DDZL.ShipDate, isnull(DDZL.CCGB, 'U') as DDCC    , isnull(XXZl.CCGB, 'U') as XXCC, max(ywcp.USERDATE) as LastDate    , ddzl.khbh, XXZL.XieXing, XXZl.SheHao, XXZL.XieMing from YWCP left join ywdd on ywcp.DDBH = ywdd.DDBH AND ywcp.GSBH = YWDD.GSBH left join DDZL on ywdd.YSBH = DDZL.DDBH left join XXZL on XXZL.XieXing = DDZL.XieXing and XXZl.SheHao = DDZl.SheHao left join(SELECT GSBH, DDBH, SUM(CTS) AS CTQTY FROM YWBZPO GROUP BY GSBH, DDBH) CT on CT.DDBH = YWDD.DDBH AND CT.GSBH = YWDD.GSBH left join(select ddbh     , isnull(count(case  when ywcp.sb = 1 then YWCP.CARTONBAR  end), 0) as ctkc     , isnull(count(case  when ywcp.sb = 2 or ywcp.sb = 8  then YWCP.CARTONBAR  end), 0) as ctck     , isnull(count(case  when ywcp.sb = 3 then YWCP.CARTONBAR  end), 0) as ctch     , isnull(count(case  when ywcp.sb = 4 then YWCP.CARTONBAR  end), 0) as ctyh     , isnull(count(case  when ywcp.sb = 7 then YWCP.CARTONBAR  end), 0) as cttran    , isnull(count(case  when ywcp.sb = 9 then YWCP.CARTONBAR  end), 0) as PreStore   , isnull(sum(case  when ywcp.sb = 3  then YWCP.Qty  end), 0) as QTYCH     , isnull(sum(case  when ywcp.sb = 2 or ywcp.sb = 8 then YWCP.Qty  end), 0) as QTYCK     , isnull(sum(case  when ywcp.sb = 4  then YWCP.Qty  end), 0) as QTYYH    , isnull(sum(case  when ywcp.sb = 9  then YWCP.Qty  end), 0) as QTYPRE  , isnull(sum(case  when ywcp.sb = 7  then YWCP.Qty  end), 0) as QTTRAN     , isnull(sum(case  when ywcp.sb = 1  then YWCP.Qty  end), 0) as QTYKC   , count(case  when(FSA_Locate is null and ywcp.sb <> 3) then YWCP.CARTONBAR  end) as gg  from YWCP   left join PalletDetail on YWCP.CARTONBAR = PalletDetail.CARTONBAR   left join FStorageAreaDetail on PalletDetail.Pallet_NO = FStorageAreaDetail.Pallet_NO      group by DDBH) s on s.ddbh = ywcp.DDBH where CT.CTQty <> s.ctch and ddzl.yn <> '5'  and YWCP.DDBH like '{0}%' group by YWCP.DDBH, XXZL.XieXing, XXZl.SheHao, XXZl.Article, XXZL.XieMing     , DDZL.ShipDate, YWDD.QTY, CT.CTQty, DDZL.CCGB, XXZL.CCGB, s.ctch, s.ctck, s.ctkc, s.ctyh     , s.cttran, s.QTYCH, s.QTYCK, s.QTYKC, s.QTTRAN, s.QTYYH, ddzl.khbh, s.gg, s.PreStore,s.QTYPRE order by YWCP.DDBH", tbOrder.Text.Trim());
                        //string sql = string.Format("select ywcp.DDBH,XXZl.Article, YWDD.QTY as DDQty, isnull(sum(case  when ywcp.sb > 0 then YWCP.Qty  end), 0) as okQty, YWDD.QTY - (isnull(sum(case  when ywcp.sb > 0 then YWCP.Qty  end), 0)) as lackPairs, s.QTYCH, s.QTYCK, s.QTYKC, s.QTTRAN, s.QTYYH, CT.CTQty as DDCT, count(ywcp.CARTONBAR) as CTQty, s.ctch + s.ctck + s.ctkc + s.ctyh + s.cttran as okQty2, CT.CTQty - s.ctch - s.ctck - s.ctkc - s.ctyh - s.cttran as lackBOX, s.ctch, s.ctck, s.ctkc, s.ctyh, s.cttran, DDZL.ShipDate, isnull(DDZL.CCGB, 'U') as DDCC, isnull(XXZl.CCGB, 'U') as XXCC, max(ywcp.USERDATE) as LastDate, ddzl.khbh, XXZL.XieXing, XXZl.SheHao, XXZL.XieMing from YWCP left join ywdd on ywcp.DDBH = ywdd.DDBH AND ywcp.GSBH = YWDD.GSBH left join DDZL on ywdd.YSBH = DDZL.DDBH left join XXZL on XXZL.XieXing = DDZL.XieXing and XXZl.SheHao = DDZl.SheHao left join(SELECT GSBH, DDBH, SUM(CTS) AS CTQTY FROM YWBZPO GROUP BY GSBH, DDBH) CT on CT.DDBH = YWDD.DDBH AND CT.GSBH = YWDD.GSBH left join (select ddbh, isnull(count(case  when ywcp.sb = 1 then YWCP.CARTONBAR  end), 0) as ctkc, isnull(count(case  when ywcp.sb = 2 or ywcp.sb = 8  then YWCP.CARTONBAR  end), 0) as ctck, isnull(count(case  when ywcp.sb = 3 then YWCP.CARTONBAR  end), 0) as ctch, isnull(count(case  when ywcp.sb = 4 then YWCP.CARTONBAR  end), 0) as ctyh, isnull(count(case  when ywcp.sb = 7 then YWCP.CARTONBAR  end), 0) as cttran, isnull(sum(case  when ywcp.sb = 3  then YWCP.Qty  end), 0) as QTYCH, isnull(sum(case  when ywcp.sb = 2 or ywcp.sb = 8 then YWCP.Qty  end), 0) as QTYCK, isnull(sum(case  when ywcp.sb = 4  then YWCP.Qty  end), 0) as QTYYH, isnull(sum(case  when ywcp.sb = 7  then YWCP.Qty  end), 0) as QTTRAN, isnull(sum(case  when ywcp.sb = 1  then YWCP.Qty  end), 0) as QTYKC from YWCP group by DDBH) s on s.ddbh = ywcp.DDBH where CT.CTQty <> s.ctch  and YWCP.DDBH like '{0}%' group by YWCP.DDBH, XXZL.XieXing, XXZl.SheHao, XXZl.Article, XXZL.XieMing, DDZL.ShipDate, YWDD.QTY, CT.CTQty, DDZL.CCGB, XXZL.CCGB, s.ctch, s.ctck, s.ctkc, s.ctyh, s.cttran, s.QTYCH, s.QTYCK, s.QTYKC, s.QTTRAN, s.QTYYH, ddzl.khbh order by YWCP.DDBH",tbOrder.Text.Trim());

                        Console.WriteLine(sql);
                        SqlDataAdapter adapter = new SqlDataAdapter(sql, dbConn.connection);
                        adapter.SelectCommand.CommandTimeout = 900;
                        adapter.Fill(ds, "訂單表");
                        this.dgvStatus.DataSource = this.ds.Tables[0];
                    }

                }
                else 
                {
                    if (tbOrder.Text == "")
                    {
                        string sql = string.Format("select ywcp.DDBH,XXZl.Article, YWDD.QTY as DDQty  , isnull(s.QTYCK+s.QTYKC+s.QTTRAN+s.QTYYH, 0) as okQty  , YWDD.QTY - isnull(s.QTYCK+s.QTYKC+s.QTTRAN+s.QTYYH, 0) as lackPairs    , s.QTYCH, s.QTYCK, s.QTYKC, s.QTTRAN, s.QTYYH, s.gg as StoreCheck,s.QTYPRE, CT.CTQty as DDCT     , count(ywcp.CARTONBAR) as CTQty, s.ctch + s.ctck + s.ctkc + s.ctyh + s.cttran as okQty2    , CT.CTQty - s.ctch - s.ctck - s.ctkc - s.ctyh - s.cttran as lackBOX    , s.ctch, s.ctck, s.ctkc, s.ctyh, s.cttran, s.PreStore, DDZL.ShipDate, isnull(DDZL.CCGB, 'U') as DDCC    , isnull(XXZl.CCGB, 'U') as XXCC, max(ywcp.USERDATE) as LastDate    , ddzl.khbh, XXZL.XieXing, XXZl.SheHao, XXZL.XieMing from YWCP left join ywdd on ywcp.DDBH = ywdd.DDBH AND ywcp.GSBH = YWDD.GSBH left join DDZL on ywdd.YSBH = DDZL.DDBH left join XXZL on XXZL.XieXing = DDZL.XieXing and XXZl.SheHao = DDZl.SheHao left join(SELECT GSBH, DDBH, SUM(CTS) AS CTQTY FROM YWBZPO GROUP BY GSBH, DDBH) CT on CT.DDBH = YWDD.DDBH AND CT.GSBH = YWDD.GSBH left join(select ddbh     , isnull(count(case  when ywcp.sb = 1 then YWCP.CARTONBAR  end), 0) as ctkc     , isnull(count(case  when ywcp.sb = 2 or ywcp.sb = 8  then YWCP.CARTONBAR  end), 0) as ctck     , isnull(count(case  when ywcp.sb = 3 then YWCP.CARTONBAR  end), 0) as ctch     , isnull(count(case  when ywcp.sb = 4 then YWCP.CARTONBAR  end), 0) as ctyh     , isnull(count(case  when ywcp.sb = 7 then YWCP.CARTONBAR  end), 0) as cttran    , isnull(count(case  when ywcp.sb = 9 then YWCP.CARTONBAR  end), 0) as PreStore   , isnull(sum(case  when ywcp.sb = 3  then YWCP.Qty  end), 0) as QTYCH     , isnull(sum(case  when ywcp.sb = 2 or ywcp.sb = 8 then YWCP.Qty  end), 0) as QTYCK     , isnull(sum(case  when ywcp.sb = 4  then YWCP.Qty  end), 0) as QTYYH    , isnull(sum(case  when ywcp.sb = 9  then YWCP.Qty  end), 0) as QTYPRE  , isnull(sum(case  when ywcp.sb = 7  then YWCP.Qty  end), 0) as QTTRAN     , isnull(sum(case  when ywcp.sb = 1  then YWCP.Qty  end), 0) as QTYKC   , count(case  when(FSA_Locate is null and ywcp.sb <> 3) then YWCP.CARTONBAR  end) as gg  from YWCP   left join PalletDetail on YWCP.CARTONBAR = PalletDetail.CARTONBAR   left join FStorageAreaDetail on PalletDetail.Pallet_NO = FStorageAreaDetail.Pallet_NO      group by DDBH) s on s.ddbh = ywcp.DDBH where CT.CTQty <> s.ctch and ddzl.yn <> '5' and YWCP.KCBH = '{0}' group by YWCP.DDBH, XXZL.XieXing, XXZl.SheHao, XXZl.Article, XXZL.XieMing     , DDZL.ShipDate, YWDD.QTY, CT.CTQty, DDZL.CCGB, XXZL.CCGB, s.ctch, s.ctck, s.ctkc, s.ctyh     , s.cttran, s.QTYCH, s.QTYCK, s.QTYKC, s.QTTRAN, s.QTYYH, ddzl.khbh, s.gg, s.PreStore,s.QTYPRE order by YWCP.DDBH ", tbKCBH.Text.Trim());

                        Console.WriteLine(sql);
                        SqlDataAdapter adapter = new SqlDataAdapter(sql, dbConn.connection);
                        adapter.SelectCommand.CommandTimeout = 900;
                        adapter.Fill(ds, "訂單表");
                        this.dgvStatus.DataSource = this.ds.Tables[0];
                    }
                    else
                    {
                        string sql = string.Format("select ywcp.DDBH,XXZl.Article, YWDD.QTY as DDQty  , isnull(s.QTYCK+s.QTYKC+s.QTTRAN+s.QTYYH, 0) as okQty  , YWDD.QTY - isnull(s.QTYCK+s.QTYKC+s.QTTRAN+s.QTYYH, 0) as lackPairs    , s.QTYCH, s.QTYCK, s.QTYKC, s.QTTRAN, s.QTYYH, s.gg as StoreCheck,s.QTYPRE, CT.CTQty as DDCT     , count(ywcp.CARTONBAR) as CTQty, s.ctch + s.ctck + s.ctkc + s.ctyh + s.cttran as okQty2    , CT.CTQty - s.ctch - s.ctck - s.ctkc - s.ctyh - s.cttran as lackBOX    , s.ctch, s.ctck, s.ctkc, s.ctyh, s.cttran, s.PreStore, DDZL.ShipDate, isnull(DDZL.CCGB, 'U') as DDCC    , isnull(XXZl.CCGB, 'U') as XXCC, max(ywcp.USERDATE) as LastDate    , ddzl.khbh, XXZL.XieXing, XXZl.SheHao, XXZL.XieMing from YWCP left join ywdd on ywcp.DDBH = ywdd.DDBH AND ywcp.GSBH = YWDD.GSBH left join DDZL on ywdd.YSBH = DDZL.DDBH left join XXZL on XXZL.XieXing = DDZL.XieXing and XXZl.SheHao = DDZl.SheHao left join(SELECT GSBH, DDBH, SUM(CTS) AS CTQTY FROM YWBZPO GROUP BY GSBH, DDBH) CT on CT.DDBH = YWDD.DDBH AND CT.GSBH = YWDD.GSBH left join(select ddbh     , isnull(count(case  when ywcp.sb = 1 then YWCP.CARTONBAR  end), 0) as ctkc     , isnull(count(case  when ywcp.sb = 2 or ywcp.sb = 8  then YWCP.CARTONBAR  end), 0) as ctck     , isnull(count(case  when ywcp.sb = 3 then YWCP.CARTONBAR  end), 0) as ctch     , isnull(count(case  when ywcp.sb = 4 then YWCP.CARTONBAR  end), 0) as ctyh     , isnull(count(case  when ywcp.sb = 7 then YWCP.CARTONBAR  end), 0) as cttran    , isnull(count(case  when ywcp.sb = 9 then YWCP.CARTONBAR  end), 0) as PreStore   , isnull(sum(case  when ywcp.sb = 3  then YWCP.Qty  end), 0) as QTYCH     , isnull(sum(case  when ywcp.sb = 2 or ywcp.sb = 8 then YWCP.Qty  end), 0) as QTYCK     , isnull(sum(case  when ywcp.sb = 4  then YWCP.Qty  end), 0) as QTYYH    , isnull(sum(case  when ywcp.sb = 9  then YWCP.Qty  end), 0) as QTYPRE  , isnull(sum(case  when ywcp.sb = 7  then YWCP.Qty  end), 0) as QTTRAN     , isnull(sum(case  when ywcp.sb = 1  then YWCP.Qty  end), 0) as QTYKC   , count(case  when(FSA_Locate is null and ywcp.sb <> 3) then YWCP.CARTONBAR  end) as gg  from YWCP   left join PalletDetail on YWCP.CARTONBAR = PalletDetail.CARTONBAR   left join FStorageAreaDetail on PalletDetail.Pallet_NO = FStorageAreaDetail.Pallet_NO      group by DDBH) s on s.ddbh = ywcp.DDBH where CT.CTQty <> s.ctch and ddzl.yn <> '5' and YWCP.DDBH like '{0}%' and YWCP.KCBH = '{1}' group by YWCP.DDBH, XXZL.XieXing, XXZl.SheHao, XXZl.Article, XXZL.XieMing     , DDZL.ShipDate, YWDD.QTY, CT.CTQty, DDZL.CCGB, XXZL.CCGB, s.ctch, s.ctck, s.ctkc, s.ctyh     , s.cttran, s.QTYCH, s.QTYCK, s.QTYKC, s.QTTRAN, s.QTYYH, ddzl.khbh, s.gg, s.PreStore,s.QTYPRE order by YWCP.DDBH", tbOrder.Text.Trim(), tbKCBH.Text.Trim());


                        Console.WriteLine(sql);
                        SqlDataAdapter adapter = new SqlDataAdapter(sql, dbConn.connection);
                        adapter.SelectCommand.CommandTimeout = 900;
                        adapter.Fill(ds, "訂單表");
                        this.dgvStatus.DataSource = this.ds.Tables[0];
                    }
                }
        }
            catch (Exception)
            {
                MessageBox.Show("載入失敗!", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                
            }
        }

        #endregion

        #region 藍色可驗貨

        private void Blue() 
        {
            try
            {
                int cd = 0;

                cd = dgvStatus.Rows.Count;

                for (int i = 0; i < cd; i++)
                {

                }
            }
            catch (Exception) { }
        }


        #endregion

        #region 離開按鈕

        private void TsbExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #endregion

        #region 變色

        private void Color() 
        {
            try
            {

                dgvStatus.Columns[15].DefaultCellStyle.BackColor = System.Drawing.Color.YellowGreen;
                dgvStatus.Columns[4].DefaultCellStyle.BackColor = System.Drawing.Color.YellowGreen;

                dgvStatus.Columns[3].DefaultCellStyle.BackColor = System.Drawing.Color.LightGreen;
                dgvStatus.Columns[5].DefaultCellStyle.BackColor = System.Drawing.Color.LightGreen;
                dgvStatus.Columns[6].DefaultCellStyle.BackColor = System.Drawing.Color.LightGreen;
                dgvStatus.Columns[7].DefaultCellStyle.BackColor = System.Drawing.Color.LightGreen;
                dgvStatus.Columns[8].DefaultCellStyle.BackColor = System.Drawing.Color.LightGreen;
                dgvStatus.Columns[2].DefaultCellStyle.BackColor = System.Drawing.Color.LightGreen;
                dgvStatus.Columns[9].DefaultCellStyle.BackColor = System.Drawing.Color.LightGreen;


                dgvStatus.Columns[10].DefaultCellStyle.BackColor = System.Drawing.Color.YellowGreen;
                dgvStatus.Columns[11].DefaultCellStyle.BackColor = System.Drawing.Color.LightYellow;
                dgvStatus.Columns[12].DefaultCellStyle.BackColor = System.Drawing.Color.LightYellow;
                dgvStatus.Columns[13].DefaultCellStyle.BackColor = System.Drawing.Color.LightYellow;
                dgvStatus.Columns[14].DefaultCellStyle.BackColor = System.Drawing.Color.LightYellow;
                dgvStatus.Columns[16].DefaultCellStyle.BackColor = System.Drawing.Color.LightYellow;
                dgvStatus.Columns[17].DefaultCellStyle.BackColor = System.Drawing.Color.LightYellow;
                dgvStatus.Columns[18].DefaultCellStyle.BackColor = System.Drawing.Color.LightYellow;
                dgvStatus.Columns[19].DefaultCellStyle.BackColor = System.Drawing.Color.LightYellow;

                int c = 0;
                c = dgvStatus.RowCount;
                for (int i = 0; i < c; i++)
                {
                    int a, b, f, d, g = 0;
                    a = int.Parse(dgvStatus.Rows[i].Cells[11].Value.ToString());
                    b = int.Parse(dgvStatus.Rows[i].Cells[13].Value.ToString());
                    f = int.Parse(dgvStatus.Rows[i].Cells[18].Value.ToString());
                    d = int.Parse(dgvStatus.Rows[i].Cells[16].Value.ToString());
                    g = int.Parse(dgvStatus.Rows[i].Cells[10].Value.ToString());
                    if (f > 0)
                    {
                        dgvStatus.Rows[i].DefaultCellStyle.ForeColor = System.Drawing.Color.Red;
                    }
                    else if (d > 0)
                    {
                        dgvStatus.Rows[i].DefaultCellStyle.ForeColor = System.Drawing.Color.Purple;
                    }
                    else if (a == b)
                    {
                        //string cp = "", cc = "";
                        //DataBinding dbConn = new DataBinding();
                        //string sql = string.Format("select count(isnull(FSA_NO,0)) as count from YWCP left join PalletDetail on YWCP.CARTONBAR = PalletDetail.CARTONBAR left join FStorageAreaDetail on PalletDetail.Pallet_NO = FStorageAreaDetail.Pallet_NO where DDBH = '{0}' and FSA_Locate is not null", dgvStatus.Rows[i].Cells[0].Value.ToString());
                        //SqlCommand cmd = new SqlCommand(sql, dbConn.connection);
                        //Console.WriteLine(sql);
                        //dbConn.OpenConnection();
                        //SqlDataReader reader = cmd.ExecuteReader();
                        //if (reader.Read()) //有資料
                        //{
                        //    cp = reader["count"].ToString();
                        //}
                        //dbConn.CloseConnection();

                        //DataBinding dbConn2 = new DataBinding();
                        //string sql2 = string.Format("select count(CARTONBAR) as count from PalletDetail where CARTONBAR like '{0}%'", dgvStatus.Rows[i].Cells[0].Value.ToString());
                        //SqlCommand cmd2 = new SqlCommand(sql2, dbConn2.connection);
                        //Console.WriteLine(sql2);
                        //dbConn2.OpenConnection();
                        //SqlDataReader reader2 = cmd2.ExecuteReader();
                        //if (reader2.Read()) //有資料
                        //{
                        //    cc = reader2["count"].ToString();
                        //}
                        //dbConn2.CloseConnection();

                        //Console.WriteLine(cp);
                        //Console.WriteLine(cc);

                        //if (cp == cc)
                        //{
                        //    dgvStatus.Rows[i].DefaultCellStyle.ForeColor = System.Drawing.Color.Blue;
                        //}
                        if (g == 0)
                        {
                            dgvStatus.Rows[i].DefaultCellStyle.ForeColor = System.Drawing.Color.Blue;
                        }
                        else 
                        {
                            dgvStatus.Rows[i].DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
                        }
                    }
                }

                Blue();
            }
            catch (Exception) { }
        }

        #endregion

        #region 查詢按鈕

        private void TsbQuery_Click(object sender, EventArgs e)
        {
            try
            {
                StatusData();
                Color();

            }
            catch (Exception)
            { }

        }

        #endregion

        #region 清空按鈕

        private void TspClear_Click(object sender, EventArgs e)
        {
            tbOrder.Text = "";
            tbCon.Text = "";
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

        #region CB

        private void Combobox()
        {
            //DataBinding dbconn = new DataBinding();
            //string sql1 = "select * from KCZL where KCCLASS = '2'";
            //SqlDataAdapter adapter1 = new SqlDataAdapter(sql1, dbconn.connection);
            //adapter1.Fill(ds2, "倉庫位置");
            //this.cbKCBH.DataSource = ds2.Tables[0];
            //this.cbKCBH.ValueMember = "KCBH";
            //this.cbKCBH.DisplayMember = "KCBH";
        }


        #endregion

        private void TsbExcel_Click(object sender, EventArgs e)
        {
            ExportExcel("report", dgvStatus);
        }

        private void DgvStatus_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                OrderDetail appw = new OrderDetail();
                appw.lbOrder.Text = dgvStatus.CurrentRow.Cells[0].Value.ToString();

                appw.Height = 500;
                appw.Width = 600;
                //appw.lbDDBH.Text = tbOrder.Text;

                appw.TopMost = true;
                appw.ShowDialog();
            }
            catch (Exception)
            { }
        }

        private void WHROStatusInWarehouse_Shown(object sender, EventArgs e)
        {
            tbOrder.Focus();
        }

        private void dgvStatus_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            Color();
        }
    }
}
