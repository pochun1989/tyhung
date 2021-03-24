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
    public partial class StorePIC : Form
    {
        System.Timers.Timer t = new System.Timers.Timer(10000);
        public StorePIC()
        {
            InitializeComponent();
        }

        private void StorePIC_Load(object sender, EventArgs e)
        {
            position();

            t.Elapsed += new System.Timers.ElapsedEventHandler(Timer1_Tick);
            t.AutoReset = true;
            t.Enabled = true; //是否触发Elapsed事件
            t.Start();
        }

 

        #region 讀取SQL
        private void position()
        {
            string strConn = @"Data Source=192.168.11.15;Initial Catalog=LY_ERP;User Id=tyhung;Password=sa";
            //建立連接
            SqlConnection myConn = new SqlConnection(strConn);
            //打開連接
            myConn.Open();

            string LBLID = "";
            string FSANO = "";
            string FSALOCATION = "";
            string KCBH = "A001";

            //red
            for (int i = 1; i <= 9; i++)
            {
                FSANO = "A" + "0" + i;

                for (int j = 11; j <= 15; j++)
                {
                    FSALOCATION = j.ToString();

                    String strSQL = @"select * from FStorageAreaDetail where Pallet_NO is not NULL and FSA_NO = '" + FSANO + "' and FSA_Locate = '" + FSALOCATION + "' and KCBH = '" + KCBH + "'";

                    SqlCommand myCommand = new SqlCommand(strSQL, myConn);
                    SqlDataReader myDataReader = myCommand.ExecuteReader();
                    while (myDataReader.Read())
                    {
                        if (myDataReader["Pallet_NO"].ToString() != "")
                        {
                            LBLID = FSANO + FSALOCATION;

                            #region 判斷變色

                            if (LBLID == "A0915")
                            {
                                A0915.BackColor = System.Drawing.Color.Red;
                            }
                            else if (LBLID == "A0914")
                            {
                                A0914.BackColor = System.Drawing.Color.Red;
                            }
                            else if (LBLID == "A0913")
                            {
                                A0913.BackColor = System.Drawing.Color.Red;
                            }
                            else if (LBLID == "A0912")
                            {
                                A0912.BackColor = System.Drawing.Color.Red;
                            }
                            else if (LBLID == "A0911")
                            {
                                A0911.BackColor = System.Drawing.Color.Red;
                            }
                            else if (LBLID == "A0815")
                            {
                                A0815.BackColor = System.Drawing.Color.Red;
                            }
                            else if (LBLID == "A0814")
                            {
                                A0814.BackColor = System.Drawing.Color.Red;
                            }
                            else if (LBLID == "A0813")
                            {
                                A0813.BackColor = System.Drawing.Color.Red;
                            }
                            else if (LBLID == "A0812")
                            {
                                A0812.BackColor = System.Drawing.Color.Red;
                            }
                            else if (LBLID == "A0811")
                            {
                                A0811.BackColor = System.Drawing.Color.Red;
                            }
                            else if (LBLID == "A0715")
                            {
                                A0715.BackColor = System.Drawing.Color.Red;
                            }
                            else if (LBLID == "A0714")
                            {
                                A0714.BackColor = System.Drawing.Color.Red;
                            }
                            else if (LBLID == "A0713")
                            {
                                A0713.BackColor = System.Drawing.Color.Red;
                            }
                            else if (LBLID == "A0712")
                            {
                                A0712.BackColor = System.Drawing.Color.Red;
                            }
                            else if (LBLID == "A0711")
                            {
                                A0711.BackColor = System.Drawing.Color.Red;
                            }
                            else if (LBLID == "A0615")
                            {
                                A0615.BackColor = System.Drawing.Color.Red;
                            }
                            else if (LBLID == "A0614")
                            {
                                A0614.BackColor = System.Drawing.Color.Red;
                            }
                            else if (LBLID == "A0613")
                            {
                                A0613.BackColor = System.Drawing.Color.Red;
                            }
                            else if (LBLID == "A0612")
                            {
                                A0612.BackColor = System.Drawing.Color.Red;
                            }
                            else if (LBLID == "A0611")
                            {
                                A0611.BackColor = System.Drawing.Color.Red;
                            }
                            else if (LBLID == "A0514")
                            {
                                A0514.BackColor = System.Drawing.Color.Red;
                            }
                            else if (LBLID == "A0513")
                            {
                                A0513.BackColor = System.Drawing.Color.Red;
                            }
                            else if (LBLID == "A0512")
                            {
                                A0512.BackColor = System.Drawing.Color.Red;
                            }
                            else if (LBLID == "A0511")
                            {
                                A0511.BackColor = System.Drawing.Color.Red;
                            }
                            else if (LBLID == "A0415")
                            {
                                A0415.BackColor = System.Drawing.Color.Red;
                            }
                            else if (LBLID == "A0414")
                            {
                                A0414.BackColor = System.Drawing.Color.Red;
                            }
                            else if (LBLID == "A0413")
                            {
                                A0413.BackColor = System.Drawing.Color.Red;
                            }
                            else if (LBLID == "A0412")
                            {
                                A0412.BackColor = System.Drawing.Color.Red;
                            }
                            else if (LBLID == "A0411")
                            {
                                A0411.BackColor = System.Drawing.Color.Red;
                            }
                            else if (LBLID == "A0315")
                            {
                                A0315.BackColor = System.Drawing.Color.Red;
                            }
                            else if (LBLID == "A0314")
                            {
                                A0314.BackColor = System.Drawing.Color.Red;
                            }
                            else if (LBLID == "A0313")
                            {
                                A0313.BackColor = System.Drawing.Color.Red;
                            }
                            else if (LBLID == "A0312")
                            {
                                A0312.BackColor = System.Drawing.Color.Red;
                            }
                            else if (LBLID == "A0311")
                            {
                                A0311.BackColor = System.Drawing.Color.Red;
                            }
                            else if (LBLID == "A0215")
                            {
                                A0215.BackColor = System.Drawing.Color.Red;
                            }
                            else if (LBLID == "A0214")
                            {
                                A0214.BackColor = System.Drawing.Color.Red;
                            }
                            else if (LBLID == "A0213")
                            {
                                A0213.BackColor = System.Drawing.Color.Red;
                            }
                            else if (LBLID == "A0212")
                            {
                                A0212.BackColor = System.Drawing.Color.Red;
                            }
                            else if (LBLID == "A0211")
                            {
                                A0211.BackColor = System.Drawing.Color.Red;
                            }
                            else if (LBLID == "A0115")
                            {
                                A0115.BackColor = System.Drawing.Color.Red;
                            }
                            else if (LBLID == "A0114")
                            {
                                A0114.BackColor = System.Drawing.Color.Red;
                            }
                            else if (LBLID == "A0113")
                            {
                                A0113.BackColor = System.Drawing.Color.Red;
                            }
                            else if (LBLID == "A0112")
                            {
                                A0112.BackColor = System.Drawing.Color.Red;
                            }
                            else if (LBLID == "A0111")
                            {
                                A0111.BackColor = System.Drawing.Color.Red;
                            }



                            #endregion
                            //LBLID.BackColor

                        }
                    }
                    myDataReader.Close();
                }
            }


            for (int i = 10; i < 25; i++)
            {
                FSANO = "A" + i;
                for (int j = 11; j <= 15; j++)
                {
                    FSALOCATION = j.ToString();

                    String strSQL = @"select * from FStorageAreaDetail where Pallet_NO is not NULL and FSA_NO = '" + FSANO + "' and FSA_Locate = '" + FSALOCATION + "' and KCBH = '" + KCBH + "'";

                    SqlCommand myCommand = new SqlCommand(strSQL, myConn);
                    SqlDataReader myDataReader = myCommand.ExecuteReader();
                    while (myDataReader.Read())
                    {
                        if (myDataReader["Pallet_NO"].ToString() != "")
                        {
                            LBLID = FSANO + FSALOCATION;

                            #region 判斷顏色

                            if (LBLID == "A1015")
                            {
                                A1015.BackColor = System.Drawing.Color.Red;
                            }
                            else if (LBLID == "A1014")
                            {
                                A1014.BackColor = System.Drawing.Color.Red;
                            }
                            else if (LBLID == "A1013")
                            {
                                A1013.BackColor = System.Drawing.Color.Red;
                            }
                            else if (LBLID == "A1012")
                            {
                                A1012.BackColor = System.Drawing.Color.Red;
                            }
                            else if (LBLID == "A1012")
                            {
                                A1012.BackColor = System.Drawing.Color.Red;
                            }
                            else if (LBLID == "A1011")
                            {
                                A1011.BackColor = System.Drawing.Color.Red;
                            }
                            else if (LBLID == "A1114")
                            {
                                A1114.BackColor = System.Drawing.Color.Red;
                            }
                            else if (LBLID == "A1113")
                            {
                                A1113.BackColor = System.Drawing.Color.Red;
                            }
                            else if (LBLID == "A1112")
                            {
                                A1112.BackColor = System.Drawing.Color.Red;
                            }
                            else if (LBLID == "A1112")
                            {
                                A1112.BackColor = System.Drawing.Color.Red;
                            }
                            else if (LBLID == "A1111")
                            {
                                A1111.BackColor = System.Drawing.Color.Red;
                            }
                            else if (LBLID == "A1214")
                            {
                                A1214.BackColor = System.Drawing.Color.Red;
                            }
                            else if (LBLID == "A1213")
                            {
                                A1213.BackColor = System.Drawing.Color.Red;
                            }
                            else if (LBLID == "A1212")
                            {
                                A1212.BackColor = System.Drawing.Color.Red;
                            }
                            else if (LBLID == "A1211")
                            {
                                A1211.BackColor = System.Drawing.Color.Red;
                            }
                            else if (LBLID == "A1315")
                            {
                                A1315.BackColor = System.Drawing.Color.Red;
                            }
                            else if (LBLID == "A1314")
                            {
                                A1314.BackColor = System.Drawing.Color.Red;
                            }
                            else if (LBLID == "A1313")
                            {
                                A1313.BackColor = System.Drawing.Color.Red;
                            }
                            else if (LBLID == "A1312")
                            {
                                A1312.BackColor = System.Drawing.Color.Red;
                            }
                            else if (LBLID == "A1312")
                            {
                                A1312.BackColor = System.Drawing.Color.Red;
                            }
                            else if (LBLID == "A1311")
                            {
                                A1311.BackColor = System.Drawing.Color.Red;
                            }
                            else if (LBLID == "A1415")
                            {
                                A1415.BackColor = System.Drawing.Color.Red;
                            }
                            else if (LBLID == "A1414")
                            {
                                A1414.BackColor = System.Drawing.Color.Red;
                            }
                            else if (LBLID == "A1413")
                            {
                                A1413.BackColor = System.Drawing.Color.Red;
                            }
                            else if (LBLID == "A1412")
                            {
                                A1412.BackColor = System.Drawing.Color.Red;
                            }
                            else if (LBLID == "A1412")
                            {
                                A1412.BackColor = System.Drawing.Color.Red;
                            }
                            else if (LBLID == "A1411")
                            {
                                A1411.BackColor = System.Drawing.Color.Red;
                            }
                            else if (LBLID == "A1515")
                            {
                                A1515.BackColor = System.Drawing.Color.Red;
                            }
                            else if (LBLID == "A1514")
                            {
                                A1514.BackColor = System.Drawing.Color.Red;
                            }
                            else if (LBLID == "A1513")
                            {
                                A1513.BackColor = System.Drawing.Color.Red;
                            }
                            else if (LBLID == "A1512")
                            {
                                A1512.BackColor = System.Drawing.Color.Red;
                            }
                            else if (LBLID == "A1511")
                            {
                                A1511.BackColor = System.Drawing.Color.Red;
                            }
                            else if (LBLID == "A1615")
                            {
                                A1615.BackColor = System.Drawing.Color.Red;
                            }
                            else if (LBLID == "A1614")
                            {
                                A1614.BackColor = System.Drawing.Color.Red;
                            }
                            else if (LBLID == "A1613")
                            {
                                A1613.BackColor = System.Drawing.Color.Red;
                            }
                            else if (LBLID == "A1612")
                            {
                                A1612.BackColor = System.Drawing.Color.Red;
                            }
                            else if (LBLID == "A1611")
                            {
                                A1611.BackColor = System.Drawing.Color.Red;
                            }
                            else if (LBLID == "A1714")
                            {
                                A1714.BackColor = System.Drawing.Color.Red;
                            }
                            else if (LBLID == "A1713")
                            {
                                A1713.BackColor = System.Drawing.Color.Red;
                            }
                            else if (LBLID == "A1712")
                            {
                                A1712.BackColor = System.Drawing.Color.Red;
                            }
                            else if (LBLID == "A1711")
                            {
                                A1711.BackColor = System.Drawing.Color.Red;
                            }
                            else if (LBLID == "A1814")
                            {
                                A1814.BackColor = System.Drawing.Color.Red;
                            }
                            else if (LBLID == "A1813")
                            {
                                A1813.BackColor = System.Drawing.Color.Red;
                            }
                            else if (LBLID == "A1812")
                            {
                                A1812.BackColor = System.Drawing.Color.Red;
                            }
                            else if (LBLID == "A1811")
                            {
                                A1811.BackColor = System.Drawing.Color.Red;
                            }
                            else if (LBLID == "A1915")
                            {
                                A1915.BackColor = System.Drawing.Color.Red;
                            }
                            else if (LBLID == "A1914")
                            {
                                A1914.BackColor = System.Drawing.Color.Red;
                            }
                            else if (LBLID == "A1913")
                            {
                                A1913.BackColor = System.Drawing.Color.Red;
                            }
                            else if (LBLID == "A1912")
                            {
                                A1912.BackColor = System.Drawing.Color.Red;
                            }
                            else if (LBLID == "A1911")
                            {
                                A1911.BackColor = System.Drawing.Color.Red;
                            }
                            else if (LBLID == "A2015")
                            {
                                A2015.BackColor = System.Drawing.Color.Red;
                            }
                            else if (LBLID == "A2014")
                            {
                                A2014.BackColor = System.Drawing.Color.Red;
                            }
                            else if (LBLID == "A2013")
                            {
                                A2013.BackColor = System.Drawing.Color.Red;
                            }
                            else if (LBLID == "A2012")
                            {
                                A2012.BackColor = System.Drawing.Color.Red;
                            }
                            else if (LBLID == "A2011")
                            {
                                A2011.BackColor = System.Drawing.Color.Red;
                            }
                            else if (LBLID == "A2115")
                            {
                                A2115.BackColor = System.Drawing.Color.Red;
                            }
                            else if (LBLID == "A2114")
                            {
                                A2114.BackColor = System.Drawing.Color.Red;
                            }
                            else if (LBLID == "A2113")
                            {
                                A2113.BackColor = System.Drawing.Color.Red;
                            }
                            else if (LBLID == "A2112")
                            {
                                A2112.BackColor = System.Drawing.Color.Red;
                            }
                            else if (LBLID == "A2111")
                            {
                                A2111.BackColor = System.Drawing.Color.Red;
                            }
                            else if (LBLID == "A2215")
                            {
                                A2215.BackColor = System.Drawing.Color.Red;
                            }
                            else if (LBLID == "A2214")
                            {
                                A2214.BackColor = System.Drawing.Color.Red;
                            }
                            else if (LBLID == "A2213")
                            {
                                A2213.BackColor = System.Drawing.Color.Red;
                            }
                            else if (LBLID == "A2212")
                            {
                                A2212.BackColor = System.Drawing.Color.Red;
                            }
                            else if (LBLID == "A2211")
                            {
                                A2211.BackColor = System.Drawing.Color.Red;
                            }
                            else if (LBLID == "A2314")
                            {
                                A2314.BackColor = System.Drawing.Color.Red;
                            }
                            else if (LBLID == "A2313")
                            {
                                A2313.BackColor = System.Drawing.Color.Red;
                            }
                            else if (LBLID == "A2312")
                            {
                                A2312.BackColor = System.Drawing.Color.Red;
                            }
                            else if (LBLID == "A2311")
                            {
                                A2311.BackColor = System.Drawing.Color.Red;
                            }
                            else if (LBLID == "A2414")
                            {
                                A2414.BackColor = System.Drawing.Color.Red;
                            }
                            else if (LBLID == "A2413")
                            {
                                A2413.BackColor = System.Drawing.Color.Red;
                            }
                            else if (LBLID == "A2412")
                            {
                                A2412.BackColor = System.Drawing.Color.Red;
                            }
                            else if (LBLID == "A2411")
                            {
                                A2411.BackColor = System.Drawing.Color.Red;
                            }


                            #endregion


                        }
                    }
                    myDataReader.Close();
                }
            }


            //yellow
            for (int i = 1; i < 9; i++)
            {
                FSANO = "A" + "0" + i;

                for (int j = 11; j <= 15; j++)
                {
                    FSALOCATION = j.ToString();

                    String strSQL = @"select * from FStorageAreaDetail where Pallet_NO is not NULL and FSA_NO = '" + FSANO + "' and FSA_Locate = '" + FSALOCATION + "' and KCBH = '" + KCBH + "' and USERDATE > DateAdd(MINUTE,-3,GetDate())";

                    SqlCommand myCommand = new SqlCommand(strSQL, myConn);
                    SqlDataReader myDataReader = myCommand.ExecuteReader();
                    while (myDataReader.Read())
                    {
                        if (myDataReader["Pallet_NO"].ToString() != "")
                        {
                            LBLID = FSANO + FSALOCATION;

                            #region 判斷變色

                            if (LBLID == "A0915")
                            {
                                A0915.BackColor = System.Drawing.Color.Yellow;
                            }
                            else if (LBLID == "A0914")
                            {
                                A0914.BackColor = System.Drawing.Color.Yellow;
                            }
                            else if (LBLID == "A0913")
                            {
                                A0913.BackColor = System.Drawing.Color.Yellow;
                            }
                            else if (LBLID == "A0912")
                            {
                                A0912.BackColor = System.Drawing.Color.Yellow;
                            }
                            else if (LBLID == "A0911")
                            {
                                A0911.BackColor = System.Drawing.Color.Yellow;
                            }
                            else if (LBLID == "A0815")
                            {
                                A0815.BackColor = System.Drawing.Color.Yellow;
                            }
                            else if (LBLID == "A0814")
                            {
                                A0814.BackColor = System.Drawing.Color.Yellow;
                            }
                            else if (LBLID == "A0813")
                            {
                                A0813.BackColor = System.Drawing.Color.Yellow;
                            }
                            else if (LBLID == "A0812")
                            {
                                A0812.BackColor = System.Drawing.Color.Yellow;
                            }
                            else if (LBLID == "A0811")
                            {
                                A0811.BackColor = System.Drawing.Color.Yellow;
                            }
                            else if (LBLID == "A0715")
                            {
                                A0715.BackColor = System.Drawing.Color.Yellow;
                            }
                            else if (LBLID == "A0714")
                            {
                                A0714.BackColor = System.Drawing.Color.Yellow;
                            }
                            else if (LBLID == "A0713")
                            {
                                A0713.BackColor = System.Drawing.Color.Yellow;
                            }
                            else if (LBLID == "A0712")
                            {
                                A0712.BackColor = System.Drawing.Color.Yellow;
                            }
                            else if (LBLID == "A0711")
                            {
                                A0711.BackColor = System.Drawing.Color.Yellow;
                            }
                            else if (LBLID == "A0615")
                            {
                                A0615.BackColor = System.Drawing.Color.Yellow;
                            }
                            else if (LBLID == "A0614")
                            {
                                A0614.BackColor = System.Drawing.Color.Yellow;
                            }
                            else if (LBLID == "A0613")
                            {
                                A0613.BackColor = System.Drawing.Color.Yellow;
                            }
                            else if (LBLID == "A0612")
                            {
                                A0612.BackColor = System.Drawing.Color.Yellow;
                            }
                            else if (LBLID == "A0611")
                            {
                                A0611.BackColor = System.Drawing.Color.Yellow;
                            }
                            else if (LBLID == "A0514")
                            {
                                A0514.BackColor = System.Drawing.Color.Yellow;
                            }
                            else if (LBLID == "A0513")
                            {
                                A0513.BackColor = System.Drawing.Color.Yellow;
                            }
                            else if (LBLID == "A0512")
                            {
                                A0512.BackColor = System.Drawing.Color.Yellow;
                            }
                            else if (LBLID == "A0511")
                            {
                                A0511.BackColor = System.Drawing.Color.Yellow;
                            }
                            else if (LBLID == "A0415")
                            {
                                A0415.BackColor = System.Drawing.Color.Yellow;
                            }
                            else if (LBLID == "A0414")
                            {
                                A0414.BackColor = System.Drawing.Color.Yellow;
                            }
                            else if (LBLID == "A0413")
                            {
                                A0413.BackColor = System.Drawing.Color.Yellow;
                            }
                            else if (LBLID == "A0412")
                            {
                                A0412.BackColor = System.Drawing.Color.Yellow;
                            }
                            else if (LBLID == "A0411")
                            {
                                A0411.BackColor = System.Drawing.Color.Yellow;
                            }
                            else if (LBLID == "A0315")
                            {
                                A0315.BackColor = System.Drawing.Color.Yellow;
                            }
                            else if (LBLID == "A0314")
                            {
                                A0314.BackColor = System.Drawing.Color.Yellow;
                            }
                            else if (LBLID == "A0313")
                            {
                                A0313.BackColor = System.Drawing.Color.Yellow;
                            }
                            else if (LBLID == "A0312")
                            {
                                A0312.BackColor = System.Drawing.Color.Yellow;
                            }
                            else if (LBLID == "A0311")
                            {
                                A0311.BackColor = System.Drawing.Color.Yellow;
                            }
                            else if (LBLID == "A0215")
                            {
                                A0215.BackColor = System.Drawing.Color.Yellow;
                            }
                            else if (LBLID == "A0214")
                            {
                                A0214.BackColor = System.Drawing.Color.Yellow;
                            }
                            else if (LBLID == "A0213")
                            {
                                A0213.BackColor = System.Drawing.Color.Yellow;
                            }
                            else if (LBLID == "A0212")
                            {
                                A0212.BackColor = System.Drawing.Color.Yellow;
                            }
                            else if (LBLID == "A0211")
                            {
                                A0211.BackColor = System.Drawing.Color.Yellow;
                            }
                            else if (LBLID == "A0115")
                            {
                                A0115.BackColor = System.Drawing.Color.Yellow;
                            }
                            else if (LBLID == "A0114")
                            {
                                A0114.BackColor = System.Drawing.Color.Yellow;
                            }
                            else if (LBLID == "A0113")
                            {
                                A0113.BackColor = System.Drawing.Color.Yellow;
                            }
                            else if (LBLID == "A0112")
                            {
                                A0112.BackColor = System.Drawing.Color.Yellow;
                            }
                            else if (LBLID == "A0111")
                            {
                                A0111.BackColor = System.Drawing.Color.Yellow;
                            }



                            #endregion
                            //LBLID.BackColor

                        }
                    }
                    myDataReader.Close();
                }
            }


            for (int i = 10; i < 25; i++)
            {
                FSANO = "A" + i;
                for (int j = 11; j <= 15; j++)
                {
                    FSALOCATION = j.ToString();

                    String strSQL = @"select * from FStorageAreaDetail where Pallet_NO is not NULL and FSA_NO = '" + FSANO + "' and FSA_Locate = '" + FSALOCATION + "' and KCBH = '" + KCBH + "' and USERDATE > DateAdd(MINUTE,-3,GetDate())";

                    SqlCommand myCommand = new SqlCommand(strSQL, myConn);
                    SqlDataReader myDataReader = myCommand.ExecuteReader();
                    while (myDataReader.Read())
                    {
                        if (myDataReader["Pallet_NO"].ToString() != "")
                        {
                            LBLID = FSANO + FSALOCATION;

                            #region 判斷顏色

                            if (LBLID == "A1015")
                            {
                                A1015.BackColor = System.Drawing.Color.Yellow;
                            }
                            else if (LBLID == "A1014")
                            {
                                A1014.BackColor = System.Drawing.Color.Yellow;
                            }
                            else if (LBLID == "A1013")
                            {
                                A1013.BackColor = System.Drawing.Color.Yellow;
                            }
                            else if (LBLID == "A1012")
                            {
                                A1012.BackColor = System.Drawing.Color.Yellow;
                            }
                            else if (LBLID == "A1012")
                            {
                                A1012.BackColor = System.Drawing.Color.Yellow;
                            }
                            else if (LBLID == "A1011")
                            {
                                A1011.BackColor = System.Drawing.Color.Yellow;
                            }
                            else if (LBLID == "A1114")
                            {
                                A1114.BackColor = System.Drawing.Color.Yellow;
                            }
                            else if (LBLID == "A1113")
                            {
                                A1113.BackColor = System.Drawing.Color.Yellow;
                            }
                            else if (LBLID == "A1112")
                            {
                                A1112.BackColor = System.Drawing.Color.Yellow;
                            }
                            else if (LBLID == "A1112")
                            {
                                A1112.BackColor = System.Drawing.Color.Yellow;
                            }
                            else if (LBLID == "A1111")
                            {
                                A1111.BackColor = System.Drawing.Color.Yellow;
                            }
                            else if (LBLID == "A1214")
                            {
                                A1214.BackColor = System.Drawing.Color.Yellow;
                            }
                            else if (LBLID == "A1213")
                            {
                                A1213.BackColor = System.Drawing.Color.Yellow;
                            }
                            else if (LBLID == "A1212")
                            {
                                A1212.BackColor = System.Drawing.Color.Yellow;
                            }
                            else if (LBLID == "A1211")
                            {
                                A1211.BackColor = System.Drawing.Color.Yellow;
                            }
                            else if (LBLID == "A1315")
                            {
                                A1315.BackColor = System.Drawing.Color.Yellow;
                            }
                            else if (LBLID == "A1314")
                            {
                                A1314.BackColor = System.Drawing.Color.Yellow;
                            }
                            else if (LBLID == "A1313")
                            {
                                A1313.BackColor = System.Drawing.Color.Yellow;
                            }
                            else if (LBLID == "A1312")
                            {
                                A1312.BackColor = System.Drawing.Color.Yellow;
                            }
                            else if (LBLID == "A1312")
                            {
                                A1312.BackColor = System.Drawing.Color.Yellow;
                            }
                            else if (LBLID == "A1311")
                            {
                                A1311.BackColor = System.Drawing.Color.Yellow;
                            }
                            else if (LBLID == "A1415")
                            {
                                A1415.BackColor = System.Drawing.Color.Yellow;
                            }
                            else if (LBLID == "A1414")
                            {
                                A1414.BackColor = System.Drawing.Color.Yellow;
                            }
                            else if (LBLID == "A1413")
                            {
                                A1413.BackColor = System.Drawing.Color.Yellow;
                            }
                            else if (LBLID == "A1412")
                            {
                                A1412.BackColor = System.Drawing.Color.Yellow;
                            }
                            else if (LBLID == "A1412")
                            {
                                A1412.BackColor = System.Drawing.Color.Yellow;
                            }
                            else if (LBLID == "A1411")
                            {
                                A1411.BackColor = System.Drawing.Color.Yellow;
                            }
                            else if (LBLID == "A1515")
                            {
                                A1515.BackColor = System.Drawing.Color.Yellow;
                            }
                            else if (LBLID == "A1514")
                            {
                                A1514.BackColor = System.Drawing.Color.Yellow;
                            }
                            else if (LBLID == "A1513")
                            {
                                A1513.BackColor = System.Drawing.Color.Yellow;
                            }
                            else if (LBLID == "A1512")
                            {
                                A1512.BackColor = System.Drawing.Color.Yellow;
                            }
                            else if (LBLID == "A1511")
                            {
                                A1511.BackColor = System.Drawing.Color.Yellow;
                            }
                            else if (LBLID == "A1615")
                            {
                                A1615.BackColor = System.Drawing.Color.Yellow;
                            }
                            else if (LBLID == "A1614")
                            {
                                A1614.BackColor = System.Drawing.Color.Yellow;
                            }
                            else if (LBLID == "A1613")
                            {
                                A1613.BackColor = System.Drawing.Color.Yellow;
                            }
                            else if (LBLID == "A1612")
                            {
                                A1612.BackColor = System.Drawing.Color.Yellow;
                            }
                            else if (LBLID == "A1611")
                            {
                                A1611.BackColor = System.Drawing.Color.Yellow;
                            }
                            else if (LBLID == "A1714")
                            {
                                A1714.BackColor = System.Drawing.Color.Yellow;
                            }
                            else if (LBLID == "A1713")
                            {
                                A1713.BackColor = System.Drawing.Color.Yellow;
                            }
                            else if (LBLID == "A1712")
                            {
                                A1712.BackColor = System.Drawing.Color.Yellow;
                            }
                            else if (LBLID == "A1711")
                            {
                                A1711.BackColor = System.Drawing.Color.Yellow;
                            }
                            else if (LBLID == "A1814")
                            {
                                A1814.BackColor = System.Drawing.Color.Yellow;
                            }
                            else if (LBLID == "A1813")
                            {
                                A1813.BackColor = System.Drawing.Color.Yellow;
                            }
                            else if (LBLID == "A1812")
                            {
                                A1812.BackColor = System.Drawing.Color.Yellow;
                            }
                            else if (LBLID == "A1811")
                            {
                                A1811.BackColor = System.Drawing.Color.Yellow;
                            }
                            else if (LBLID == "A1915")
                            {
                                A1915.BackColor = System.Drawing.Color.Yellow;
                            }
                            else if (LBLID == "A1914")
                            {
                                A1914.BackColor = System.Drawing.Color.Yellow;
                            }
                            else if (LBLID == "A1913")
                            {
                                A1913.BackColor = System.Drawing.Color.Yellow;
                            }
                            else if (LBLID == "A1912")
                            {
                                A1912.BackColor = System.Drawing.Color.Yellow;
                            }
                            else if (LBLID == "A1911")
                            {
                                A1911.BackColor = System.Drawing.Color.Yellow;
                            }
                            else if (LBLID == "A2015")
                            {
                                A2015.BackColor = System.Drawing.Color.Yellow;
                            }
                            else if (LBLID == "A2014")
                            {
                                A2014.BackColor = System.Drawing.Color.Yellow;
                            }
                            else if (LBLID == "A2013")
                            {
                                A2013.BackColor = System.Drawing.Color.Yellow;
                            }
                            else if (LBLID == "A2012")
                            {
                                A2012.BackColor = System.Drawing.Color.Yellow;
                            }
                            else if (LBLID == "A2011")
                            {
                                A2011.BackColor = System.Drawing.Color.Yellow;
                            }
                            else if (LBLID == "A2115")
                            {
                                A2115.BackColor = System.Drawing.Color.Yellow;
                            }
                            else if (LBLID == "A2114")
                            {
                                A2114.BackColor = System.Drawing.Color.Yellow;
                            }
                            else if (LBLID == "A2113")
                            {
                                A2113.BackColor = System.Drawing.Color.Yellow;
                            }
                            else if (LBLID == "A2112")
                            {
                                A2112.BackColor = System.Drawing.Color.Yellow;
                            }
                            else if (LBLID == "A2111")
                            {
                                A2111.BackColor = System.Drawing.Color.Yellow;
                            }
                            else if (LBLID == "A2215")
                            {
                                A2215.BackColor = System.Drawing.Color.Yellow;
                            }
                            else if (LBLID == "A2214")
                            {
                                A2214.BackColor = System.Drawing.Color.Yellow;
                            }
                            else if (LBLID == "A2213")
                            {
                                A2213.BackColor = System.Drawing.Color.Yellow;
                            }
                            else if (LBLID == "A2212")
                            {
                                A2212.BackColor = System.Drawing.Color.Yellow;
                            }
                            else if (LBLID == "A2211")
                            {
                                A2211.BackColor = System.Drawing.Color.Yellow;
                            }
                            else if (LBLID == "A2314")
                            {
                                A2314.BackColor = System.Drawing.Color.Yellow;
                            }
                            else if (LBLID == "A2313")
                            {
                                A2313.BackColor = System.Drawing.Color.Yellow;
                            }
                            else if (LBLID == "A2312")
                            {
                                A2312.BackColor = System.Drawing.Color.Yellow;
                            }
                            else if (LBLID == "A2311")
                            {
                                A2311.BackColor = System.Drawing.Color.Yellow;
                            }
                            else if (LBLID == "A2414")
                            {
                                A2414.BackColor = System.Drawing.Color.Yellow;
                            }
                            else if (LBLID == "A2413")
                            {
                                A2413.BackColor = System.Drawing.Color.Yellow;
                            }
                            else if (LBLID == "A2412")
                            {
                                A2412.BackColor = System.Drawing.Color.Yellow;
                            }
                            else if (LBLID == "A2411")
                            {
                                A2411.BackColor = System.Drawing.Color.Yellow;
                            }


                            #endregion


                        }
                    }
                    myDataReader.Close();
                }
            }
        }


        #endregion

        private void Timer1_Tick(object sender, EventArgs e)
        {
            position();
        }
    }
}
