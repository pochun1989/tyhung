﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TEST
{
    class DataBinding2
    {
        // 資料庫連結字串(公司)

        /// <summary>
        /// New_ERP
        /// </summary>
        //private string _connString = @"Data Source=192.168.11.15;Initial Catalog=New_ERP;User Id=NP;Password=tyhung";
        /// <summary>
        /// LY_test
        /// </summary>
        private string _connString2 = @"Data Source=192.168.11.15;Initial Catalog=LY_test;User Id=NP;Password=tyhung";

        // 資料庫連結字串(本機)
        //private string _connString = @"Data Source=.;Initial Catalog=LY_TEST;User Id=ad;Password=ad";
        //private string _connString = @"Data Source = 192.168.11.15; Initial Catalog = New_ERP ; User Id = NP ; Password = tyhung ";
        //private string _connString = @"Data Source=.;Initial Catalog=LY_ERP;User Id=ad;Password=ad";
        private string _connString = @"Data Source=192.168.11.8;Initial Catalog=LTY;User Id=LY_HRM;Password=P@ssw0rd";
        //private string _connString = @"Data Source=192.168.25.10;Initial Catalog=YF_HRM;User Id=readhr;Password=123P@ss";

        #region New_ERP

        // connection < property
        #region 連線存取

        private SqlConnection _connection; // 連線欄位
        /// <summary>
        /// 連線對象
        /// </summary>
        public SqlConnection connection
        {
            get
            {
                if (_connection == null)
                {
                    string AREA;
                    AREA = Program.Area.area;
                    if (AREA == "0")
                    {
                        //companycode = "VTY";
                        _connString = @"Data Source=192.168.11.8;Initial Catalog=LTY;User Id=LY_HRM;Password=P@ssw0rd";

                    }
                    else if (AREA == "1")
                    {
                        //companycode = "LYF";
                        _connString = @"Data Source=192.168.25.10;Initial Catalog=YF_HRM;User Id=readhr;Password=123P@ss";
                    }
                    else if (AREA == "2")
                    {
                        //companycode = "LPB";
                        _connString = @"Data Source=192.168.14.30;Initial Catalog=HRM_TT;User Id=tyhung;Password=sa";
                    }

                    _connection = new SqlConnection(_connString);
                }
                return _connection;
            }
        }

        #endregion

        // OpenConnection() < method
        #region 開啟資料庫連接

        /// <summary>
        /// 開啟資料庫連接
        /// </summary>
        public void OpenConnection()
        {
            if (connection.State == ConnectionState.Closed)
            {
                connection.Open();
            }
            else if (connection.State == ConnectionState.Broken)
            {
                connection.Close();
                connection.Open();
            }
        }

        #endregion 

        // CloseConnection() < method
        #region 關閉資料庫連接

        /// <summary>
        /// 關閉資料庫連接
        /// </summary>
        public void CloseConnection()
        {
            if (connection.State == ConnectionState.Open || connection.State == ConnectionState.Broken)
            {
                connection.Close();
            }
        }

        #endregion   

        #endregion

        #region LY_test

        // connection < property
        #region 連線存取

        private SqlConnection _connection2; // 連線欄位
        /// <summary>
        /// 連線對象
        /// </summary>
        public SqlConnection connection2
        {
            get
            {
                if (_connection2 == null)
                {
                    _connection2 = new SqlConnection(_connString2);
                }
                return _connection2;
            }
        }

        #endregion

        // OpenConnection() < method
        #region 開啟資料庫連接

        /// <summary>
        /// 開啟資料庫連接
        /// </summary>
        public void OpenConnectionLY_test()
        {
            if (connection.State == ConnectionState.Closed)
            {
                connection.Open();
            }
            else if (connection.State == ConnectionState.Broken)
            {
                connection.Close();
                connection.Open();
            }
        }

        #endregion 

        // CloseConnection() < method
        #region 關閉資料庫連接

        /// <summary>
        /// 關閉資料庫連接
        /// </summary>
        public void CloseConnectionLY_test()
        {
            if (connection.State == ConnectionState.Open || connection.State == ConnectionState.Broken)
            {
                connection.Close();
            }
        }

        #endregion   

        #endregion



    }
}
