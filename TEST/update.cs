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
    public partial class update : Form
    {
        #region 建構函式
        public update()
        {
            InitializeComponent();
        }

        #endregion

        #region 畫面載入

        private void Update_Load(object sender, EventArgs e)
        {

        }


        #endregion

        private void Button1_Click(object sender, EventArgs e)
        {
            int c = 0;
            DataBinding conD = new DataBinding();
            DataBinding con1 = new DataBinding();

            string sqlD = "select distinct DDBH from YWCP where SB = 3 and EXEDATE > DATEADD(DAY,  -10, GETDATE())";
            Console.WriteLine(sqlD);

            SqlCommand cmdD = new SqlCommand(sqlD, conD.connection);
            SqlDataAdapter sdaD = new SqlDataAdapter(cmdD);
            DataTable dtD = new DataTable();
            sdaD.Fill(dtD);
            conD.OpenConnection();
            c = dtD.Rows.Count;
            Console.WriteLine(c);

            for (int j = 0; j < c; j++)
            {
                string DDBH = dtD.Rows[j]["DDBH"].ToString().Trim();
                DataBinding conE = new DataBinding();
                StringBuilder sqlE = new StringBuilder();
                sqlE.AppendFormat("update DDZL set YN = 5 where DDBH = '{0}'",DDBH);

                Console.WriteLine(sqlE);

                SqlCommand mdE = new SqlCommand(sqlE.ToString(), conE.connection);
                conE.OpenConnection();
                int esultE = mdE.ExecuteNonQuery();
                if (esultE == 1)
                {
                    DataBinding con5 = new DataBinding();
                    string strSQL5 = string.Format("select * from YWCP where SB <> 3 and SB <> 0 and DDBH = '{0}'", DDBH);

                    Console.WriteLine(strSQL5);

                    SqlCommand cmd5 = new SqlCommand(strSQL5, con5.connection);
                    con5.OpenConnection();
                    SqlDataReader reader5 = cmd5.ExecuteReader();
                    if (reader5.Read() == true) 
                    {
                        DataBinding conEk = new DataBinding();
                        StringBuilder sqlEk = new StringBuilder();
                        sqlEk.AppendFormat("update DDZL set YN = 3 where DDBH = '{0}'", DDBH);

                        Console.WriteLine(sqlEk);

                        SqlCommand mdEk = new SqlCommand(sqlEk.ToString(), conEk.connection);
                        conEk.OpenConnection();
                        int esultEk = mdEk.ExecuteNonQuery();
                        if (esultEk == 1)
                        {
                        }
                        conEk.CloseConnection();
                    }
                    con5.CloseConnection();


                    //DataBinding con6 = new DataBinding();
                    //string strSQL6 = string.Format("select * from YWCP where SB =0 and DDBH = '{0}'", DDBH);

                    //Console.WriteLine(strSQL6);

                    //SqlCommand cmd6 = new SqlCommand(strSQL6, con6.connection);
                    //con6.OpenConnection();
                    //SqlDataReader reader6 = cmd6.ExecuteReader();
                    //if (reader6.Read() == true)
                    //{
                    //    DataBinding conEk = new DataBinding();
                    //    StringBuilder sqlEk = new StringBuilder();
                    //    sqlEk.AppendFormat("update DDZL set YN = 1 where DDBH = '{0}'", DDBH);

                    //    Console.WriteLine(sqlEk);

                    //    SqlCommand mdEk = new SqlCommand(sqlEk.ToString(), conEk.connection);
                    //    conEk.OpenConnection();
                    //    int esultEk = mdEk.ExecuteNonQuery();
                    //    if (esultEk == 1)
                    //    {
                    //    }
                    //    conEk.CloseConnection();
                    //}
                    //con6.CloseConnection();
                }
                conE.CloseConnection();
            }
            MessageBox.Show("RELOAD完畢");

            
        }



    }
}
