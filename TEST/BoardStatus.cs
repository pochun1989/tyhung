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
    public partial class BoardStatus : Form
    {
        System.Timers.Timer t = new System.Timers.Timer(100000);
        public BoardStatus()
        {
            InitializeComponent();
        }

        private void BoardStatus_Load(object sender, EventArgs e)
        {
            t.Elapsed += new System.Timers.ElapsedEventHandler(timer1_Tick);
            t.AutoReset = true;
            t.Enabled = true; //是否触发Elapsed事件
            t.Start();


            status();
        }


        public void status()
        {
            try
            {
                int storeN = 0;
                //儲位總數
                DataBinding conn = new DataBinding();
                string sql1 = string.Format("select count(FSA_NO) from FStorageAreaDetail where YN = 1 and KCBH = 'A001'");
                SqlCommand cmd1 = new SqlCommand(sql1, conn.connection);
                conn.OpenConnection();
                SqlDataReader reader1 = cmd1.ExecuteReader();
                if (reader1.Read())
                {
                    storeN = reader1.GetInt32(0);
                }
                Console.WriteLine(storeN);


                conn.CloseConnection();

                #region chart1設定

                int allBox = 0;
                int useBox = 0, emptyBox = 0, minus = 0;
                allBox = storeN * 2 * 2 * 5;
                //useBox = 100;

                int allcarcon = 140000;
                int cartonnum = 0;
                int cartonmin = 0;



                string sql10 = string.Format("select count(CARTONBAR) as count from YWCP where SB = 1");
                SqlCommand cmd10 = new SqlCommand(sql10, conn.connection);
                conn.OpenConnection();
                SqlDataReader reader10 = cmd10.ExecuteReader();
                if (reader10.Read()) //取出訂單號
                {
                    useBox = reader10.GetInt32(0);
                }
                conn.CloseConnection();


                lblS.Text = useBox.ToString();



                string sqlX = string.Format("select sum(Qty) from YWCP  where SB = 1");
                SqlCommand cmdX = new SqlCommand(sqlX, conn.connection);
                conn.OpenConnection();
                SqlDataReader readerX = cmdX.ExecuteReader();
                if (readerX.Read()) //取出訂單號
                {
                    cartonnum = readerX.GetInt32(0);
                }
                conn.CloseConnection();

                lbalcar.Text = allcarcon.ToString();
                lbcarnow.Text = cartonnum.ToString();

                cartonmin = allcarcon - cartonnum;

                if (cartonmin < 0)
                {
                    cartonmin = 0;
                }






                #endregion

                #region chart2設定


                int storeN2 = 0;


                string sql2 = string.Format("select count(FSA_NO) from FStorageAreaDetail where YN = 1 and Pallet_NO is not null and KCBH = 'A001'");
                SqlCommand cmd2 = new SqlCommand(sql2, conn.connection);
                conn.OpenConnection();
                SqlDataReader reader2 = cmd2.ExecuteReader();
                if (reader2.Read()) //取出訂單號
                {
                    storeN2 = reader2.GetInt32(0);
                }
                //Console.WriteLine(ddbh);


                conn.CloseConnection();

                //storeN2 = 189;

                lblE.Text = (storeN - storeN2).ToString();
                lblU.Text = storeN2.ToString();
                emptyBox = useBox + ((storeN - storeN2)*16);
                lblEA.Text = emptyBox.ToString();

                List<string> xData2 = new List<string>() { "Empty Area", "Using Area" };
                List<int> yData2 = new List<int>() { storeN - storeN2, storeN2 };
                //线条颜色
                chart2.Series[0].Color = Color.Green;
                //线条粗细
                chart2.Series[0].BorderWidth = 3;
                //标记点边框颜色      
                chart2.Series[0].MarkerBorderColor = Color.Black;
                //标记点边框大小
                chart2.Series[0].MarkerBorderWidth = 3;
                //标记点中心颜色
                chart2.Series[0].MarkerColor = Color.Red;
                //标记点大小
                chart2.Series[0].MarkerSize = 8;
                //标记点类型     
                chart2.Series[0].MarkerStyle = System.Windows.Forms.DataVisualization.Charting.MarkerStyle.Circle;
                //将文字移到外侧
                chart2.Series[0]["PieLabelStyle"] = "Outside";
                //绘制黑色的连线
                chart2.Series[0]["PieLineColor"] = "Black";

                chart2.Series[0].Points.DataBindXY(xData2, yData2);


                #endregion

                #region chart3設定

                int orderAll = 0, order = 0, left = 0;

                string sql3 = string.Format("select count (ddbh) from (select distinct ddbh from YWCP where SB!=3) as a");
                SqlCommand cmd3 = new SqlCommand(sql3, conn.connection);
                conn.OpenConnection();
                SqlDataReader reader3 = cmd3.ExecuteReader();
                if (reader3.Read()) //取出訂單號
                {
                    orderAll = reader3.GetInt32(0);
                }
                //Console.WriteLine(ddbh);

                conn.CloseConnection();

                string sql4 = string.Format("select count(DDBH) from (select distinct b.DDBH, b.indate, b.inspectdate, b.outdate, d.ShipDate from YWCP as a left join (select ddbh, count(cartonbar) as fin1, min(Indate) as indate, max(INSPECTDATE) as inspectdate, max(OUTDATE) as outdate from ywcp where (sb <> 0 and sb <> 3) group by ddbh) as b on a.DDBH = b.DDBH left join (select ddbh, count(cartonbar) as fin2 from ywcp group by ddbh) as c on a.DDBH = b.DDBH left join (select ddbh, shipdate, yn from DDZL) as d on a.ddbh = d.ddbh where(fin2 - fin1) = 0 ) as d");
                SqlCommand cmd4 = new SqlCommand(sql4, conn.connection);
                conn.OpenConnection();
                SqlDataReader reader4 = cmd4.ExecuteReader();
                if (reader4.Read()) //取出訂單號
                {
                    order = reader4.GetInt32(0);
                }
                //Console.WriteLine(ddbh);

                conn.CloseConnection();

                left = orderAll - order;

                lblW.Text = left.ToString();
                lblF.Text = order.ToString();

                List<string> xData3 = new List<string>() { "Working On", "Finished" };
                List<int> yData3 = new List<int>() { left, order };
                //线条颜色
                chart3.Series[0].Color = Color.Green;
                //线条粗细
                chart3.Series[0].BorderWidth = 3;
                //标记点边框颜色      
                chart3.Series[0].MarkerBorderColor = Color.Black;
                //标记点边框大小
                chart3.Series[0].MarkerBorderWidth = 3;
                //标记点中心颜色
                chart3.Series[0].MarkerColor = Color.Red;
                //标记点大小
                chart3.Series[0].MarkerSize = 8;
                //标记点类型     
                chart3.Series[0].MarkerStyle = System.Windows.Forms.DataVisualization.Charting.MarkerStyle.Circle;
                //将文字移到外侧
                chart3.Series[0]["PieLabelStyle"] = "Outside";
                //绘制黑色的连线
                chart3.Series[0]["PieLineColor"] = "Black";

                chart3.Series[0].Points.DataBindXY(xData3, yData3);


                minus = allBox - emptyBox;

                List<string> xData = new List<string>() { "store", "empty" };
                List<int> yData = new List<int>() { allBox, emptyBox };
                //线条颜色
                chart1.Series[0].Color = Color.Green;
                //线条粗细
                chart1.Series[0].BorderWidth = 3;
                //标记点边框颜色      
                chart1.Series[0].MarkerBorderColor = Color.Black;
                //标记点边框大小
                chart1.Series[0].MarkerBorderWidth = 3;
                //标记点中心颜色
                chart1.Series[0].MarkerColor = Color.Red;
                //标记点大小
                chart1.Series[0].MarkerSize = 8;
                //标记点类型     
                chart1.Series[0].MarkerStyle = System.Windows.Forms.DataVisualization.Charting.MarkerStyle.Circle;
                //将文字移到外侧
                chart1.Series[0]["PieLabelStyle"] = "Outside";
                //绘制黑色的连线
                chart1.Series[0]["PieLineColor"] = "Black";

                chart1.Series[0].Points.DataBindXY(xData, yData);

                #endregion

            }
            catch (Exception)
            {

            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            status();
        }

        private void panel3_DoubleClick(object sender, EventArgs e)
        {
            YWCPDDBHDetail Form = new YWCPDDBHDetail();
            Form.ShowDialog();
        }
    }
}
