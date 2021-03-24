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
    public partial class LineDaily : Form
    {

        System.Timers.Timer t = new System.Timers.Timer(1000);
        public LineDaily()
        {
            InitializeComponent();
        }

        DataSet ds = new DataSet();
        int b = 0;
        int a = 0, d = 0, f = 0;
        string z, y;

        public string AREA;
        string companycode;
        #region bar

        private void barload() 
        {
            try
            {



                int q;
                q = int.Parse(label3.Text);

                if (q < 1000)
                {
                    progressBar1.Value = 10;
                }
                else if (q < 2000)
                {
                    progressBar1.Value = 20;
                }
                else if (q < 3000)
                {
                    progressBar1.Value = 30;
                }
                else if (q < 4000)
                {
                    progressBar1.Value = 40;
                }
                else if (q < 5000)
                {
                    progressBar1.Value = 50;
                }
                else if (q < 6000)
                {
                    progressBar1.Value = 60;
                }
                else if (q < 7000)
                {
                    progressBar1.Value = 70;
                }
                else if (q < 8000)
                {
                    progressBar1.Value = 80;
                }
                else if (q < 9000)
                {
                    progressBar1.Value = 90;
                }
                else 
                {
                    progressBar1.Value = 100;
                }

            }
            catch (Exception) { }
        }

        #endregion

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                AbnormalCTN Form = new AbnormalCTN();
                Form.ShowDialog();
            }
            catch (Exception) { }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            try
            {
                a = 0;
                d = 0;
                f = 0;

                int c = 0;
                c = dataGridView1.Rows.Count;
                Console.WriteLine(c);


                for (int d = 0; d < c; d++)
                {
                    dataGridView1.Rows.RemoveAt(0);
                }

                DataBinding dbConnA = new DataBinding();
                string sqlA = string.Format("select  z.DepName, isnull((isnull(c.異常未入庫,0)+isnull(a.掃描未入庫,0)),0) as 'SOTKCHUYEN (線上庫存數)',isnull(a.掃描未入庫,0) as 'SCANHT (掃描完成)',isnull(b.入庫數,0) as 'SOTHUNG 入庫箱數',  (isnull(a.掃描未入庫,0)+isnull(b.入庫數,0))  as 'HTTRONGNGAY 當天完成箱數',  (isnull(a.箱數7,0)+isnull(b.箱數1,0)) as 'SO DOI TRONG NGA當天完成雙數' from (select ID,DepName from BDepartment where gsbh = '{0}' and PlanYN = '1' and useYN = '1' and gxlb = 'A') as z left join(select DepNO, count(CARTONBAR) as '掃描未入庫',SUM(Qty)as '箱數7' from YWCP where LastInDate between Convert(varchar(10), Getdate(), 111) and DATEADD(DAY, 1, Convert(varchar(10), Getdate(), 111))  and INCS = '1' and SB = '7' group by DepNO) as a on z.ID = a.DepNO left join(select DepNO, count(CARTONBAR) as '入庫數' ,SUM(Qty)as '箱數1'from YWCP  where INDATE between Convert(varchar(10), Getdate(), 111) and DATEADD(DAY, 1, Convert(varchar(10), Getdate(), 111)) and SB = '1' group by DepNO) as b on z.ID = b.DepNO left join (select DepNO, count(CARTONBAR) as '異常未入庫'  from YWCP where LastInDate < Convert(varchar(10), Getdate(), 111) and SB = 7 group by DepNO) as c on z.ID = c.DepNO ORDER BY 'SO DOI TRONG NGA當天完成雙數' desc", companycode);
                SqlDataAdapter adapter = new SqlDataAdapter(sqlA, dbConnA.connection);
                adapter.Fill(ds, "外箱表");
                this.dataGridView1.DataSource = this.ds.Tables[0];
                Console.WriteLine(sqlA);

                dataGridView1.Columns[1].DefaultCellStyle.BackColor = System.Drawing.Color.LightGray;
                dataGridView1.Columns[5].DefaultCellStyle.BackColor = System.Drawing.Color.LightGreen;

                string str = System.Environment.NewLine;
                dataGridView1.Columns[0].HeaderText = "BO PHAN" + str + "部門";
                dataGridView1.Columns[1].HeaderText = "SO TK CHUYEN" + str + "線上庫存數";
                dataGridView1.Columns[2].HeaderText = "SCAN HT" + str + "掃描完成";
                dataGridView1.Columns[3].HeaderText = "SO THUNG" + str + "入庫箱數";
                dataGridView1.Columns[4].HeaderText = "HT TRONG NGAY" + str + "當天完成箱數";
                dataGridView1.Columns[5].HeaderText = "SO DOI TRONG NGA" + str + "當天完成雙數";


                a = dataGridView1.Rows.Count;
                for (int i = 0; i < a; i++)
                {
                    d += int.Parse(dataGridView1.Rows[i].Cells[4].Value.ToString());
                    f += int.Parse(dataGridView1.Rows[i].Cells[5].Value.ToString());
                }

                z = "" + d;
                y = "" + f;
                label4.Visible = true;
                label3.Visible = true;

                label4.Text = z;
                label3.Text = y;

                barload();
            }
            catch (Exception) { }
        }

        private void LineDaily_Load(object sender, EventArgs e)
        {
            try
            {
                AREA = Program.Area.area;

                if (AREA == "0")
                {
                    companycode = "LTY";
                }
                else if (AREA == "1")
                {
                    companycode = "LYF";
                }
                else if (AREA == "2")
                {
                    companycode = "LBT";
                }


                t.Elapsed += new System.Timers.ElapsedEventHandler(timer1_Tick);
                t.AutoReset = true;
                t.Enabled = true; //是否触发Elapsed事件
                t.Start();


                DataBinding dbConnA = new DataBinding();
                string sqlA = string.Format("select  z.DepName, isnull((isnull(c.異常未入庫,0)+isnull(a.掃描未入庫,0)),0) as 'SOTKCHUYEN (線上庫存數)',isnull(a.掃描未入庫,0) as 'SCANHT (掃描完成)',isnull(b.入庫數,0) as 'SOTHUNG 入庫箱數',  (isnull(a.掃描未入庫,0)+isnull(b.入庫數,0))  as 'HTTRONGNGAY 當天完成箱數',  (isnull(a.箱數7,0)+isnull(b.箱數1,0)) as 'SO DOI TRONG NGA當天完成雙數' from (select ID,DepName from BDepartment where gsbh = '{0}' and PlanYN = '1' and useYN = '1' and gxlb = 'A') as z left join(select DepNO, count(CARTONBAR) as '掃描未入庫',SUM(Qty)as '箱數7' from YWCP where LastInDate between Convert(varchar(10), Getdate(), 111) and DATEADD(DAY, 1, Convert(varchar(10), Getdate(), 111))  and INCS = '1' and SB = '7' group by DepNO) as a on z.ID = a.DepNO left join(select DepNO, count(CARTONBAR) as '入庫數' ,SUM(Qty)as '箱數1'from YWCP  where INDATE between Convert(varchar(10), Getdate(), 111) and DATEADD(DAY, 1, Convert(varchar(10), Getdate(), 111)) and SB = '1' group by DepNO) as b on z.ID = b.DepNO left join (select DepNO, count(CARTONBAR) as '異常未入庫'  from YWCP where LastInDate < Convert(varchar(10), Getdate(), 111) and SB = 7 group by DepNO) as c on z.ID = c.DepNO ORDER BY 'SO DOI TRONG NGA當天完成雙數' desc", companycode);
                SqlDataAdapter adapter = new SqlDataAdapter(sqlA, dbConnA.connection);
                adapter.Fill(ds, "外箱表");
                this.dataGridView1.DataSource = this.ds.Tables[0];
                Console.WriteLine(sqlA);

                dataGridView1.Columns[1].DefaultCellStyle.BackColor = System.Drawing.Color.LightGray; 
                dataGridView1.Columns[5].DefaultCellStyle.BackColor = System.Drawing.Color.LightGreen;


                string str = System.Environment.NewLine;
                dataGridView1.Columns[0].HeaderText = "BO PHAN" + str + "部門";
                dataGridView1.Columns[1].HeaderText = "SO TK CHUYEN" + str + "線上庫存數";
                dataGridView1.Columns[2].HeaderText = "SCAN HT" + str + "掃描完成";
                dataGridView1.Columns[3].HeaderText = "SO THUNG" + str + "入庫箱數";
                dataGridView1.Columns[4].HeaderText = "HT TRONG NGAY" + str + "當天完成箱數";
                dataGridView1.Columns[5].HeaderText = "SO DOI TRONG NGA" + str + "當天完成雙數";





                a = dataGridView1.Rows.Count;
                for (int i = 0; i < a; i++)
                {
                    d += int.Parse(dataGridView1.Rows[i].Cells[4].Value.ToString());
                    f += int.Parse(dataGridView1.Rows[i].Cells[5].Value.ToString());
                }

                z = "" + d;
                y = "" + f;
                label4.Visible = true;
                label3.Visible = true;

                label4.Text = z;
                label3.Text = y;

                barload();
            }
            catch (Exception) { }
        }



        private void timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                //b++;
                //Console.WriteLine(b);
                ////label1.Text = b.ToString();
                ////string a = label1.Text;

                ////b = int.Parse(a);
                ////b++;
                ////label1.Text = b.ToString();



                //int c = 0;
                //c = dataGridView1.Rows.Count;
                //Console.WriteLine(c);


                //for (int d = 0; d < c; d++)
                //{
                //    dataGridView1.Rows.RemoveAt(0);
                //}

                //DataBinding dbConnA = new DataBinding();
                //string sqlA = string.Format("select z.DepName,isnull(a.掃描未入庫,0) as 'SCAN HT掃描完成',isnull(b.入庫數,0) as 'SO THUNG入庫箱數',  (isnull(a.掃描未入庫,0)+isnull(b.入庫數,0))  as 'HT TRONG NGAY當天完成箱數',  (isnull(a.箱數7,0)+isnull(b.箱數1,0)) as 'SO DOI TRONG NGA當天完成雙數',isnull(c.異常未入庫,0) as 'NK KHAC入庫異常箱數'from (select ID,DepName from BDepartment where gsbh = 'LTY' and PlanYN = '1' and useYN = '1' and gxlb = 'A') as z left join(select DepNO, count(CARTONBAR) as '掃描未入庫',SUM(Qty)as '箱數7' from YWCP where LastInDate between Convert(varchar(10), Getdate(), 111) and DATEADD(DAY, 1, Convert(varchar(10), Getdate(), 111))  and INCS = '1' and SB = '7' group by DepNO) as a on z.ID = a.DepNO left join(select DepNO, count(CARTONBAR) as '入庫數' ,SUM(Qty)as '箱數1'from YWCP  where LastInDate between Convert(varchar(10), Getdate(), 111) and DATEADD(DAY, 1, Convert(varchar(10), Getdate(), 111)) and INCS = '1' and SB = '1' group by DepNO) as b on z.ID = b.DepNO left join (select DepNO, count(CARTONBAR) as '異常未入庫'  from YWCP where LastInDate < Convert(varchar(10), Getdate(), 111) and SB = 7 group by DepNO) as c on z.ID = c.DepNO ORDER BY 'SO DOI TRONG NGA當天完成雙數' desc");
                //SqlDataAdapter adapter = new SqlDataAdapter(sqlA, dbConnA.connection);
                //adapter.Fill(ds, "外箱表");
                //this.dataGridView1.DataSource = this.ds.Tables[0];
                //Console.WriteLine(sqlA);

                //dataGridView1.Columns[4].DefaultCellStyle.BackColor = System.Drawing.Color.LightGreen;
                //dataGridView1.Columns[5].DefaultCellStyle.BackColor = System.Drawing.Color.OrangeRed;


                //a = dataGridView1.Rows.Count;
                //for (int i = 0; i < a; i++)
                //{
                //    d += int.Parse(dataGridView1.Rows[i].Cells[3].Value.ToString());
                //    f += int.Parse(dataGridView1.Rows[i].Cells[4].Value.ToString());
                //}

                //z = "" + d;
                //y = "" + f;
                //label4.Visible = true;
                //label3.Visible = true;
                //label4.Text = z;
                //label3.Text = y;
            }
            catch (Exception) { }
        }
    }
}
