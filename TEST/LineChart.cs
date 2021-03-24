using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;


namespace TEST
{
    public partial class LineChart : Form
    {
        public LineChart()
        {
            InitializeComponent();
        }




        private void LineChart_Load(object sender, EventArgs e)
        {
            try
            {
                comboBox1.SelectedIndex = 0;
                comboBox2.SelectedIndex = 0;
            }
            catch (Exception) 
            {
            }
        }

        private void Start() 
        {
            try
            {
                chart1.Series.Clear();
                DataSet ds1 = new DataSet();
                DataSet ds2 = new DataSet();
                DataSet ds3 = new DataSet();
                if (comboBox1.SelectedIndex == 1) //month
                {
                    if (comboBox2.SelectedIndex == 0) //庫存
                    {
                        #region 今年

                        double[,] a1;
                        a1 = new double[,] { { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }, { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12 }, { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 } };

                        ds1 = new DataSet();
                        DataBinding dbConn = new DataBinding();
                        string sql = string.Format("select y,m,avg(FSIqty) as fsiqty,sum(fssqty) as fssqty from ( select year(countdate) as y, datepart(MONTH, countdate) as m, FSIqty, fssqty from countFS) a where a.y = year(getdate()) group by y, m");
                        SqlDataAdapter adapter = new SqlDataAdapter(sql, dbConn.connection);
                        adapter.Fill(ds1, "DATA");
                        dataGridView1.DataSource = ds1.Tables[0];

                        for (int i = 0; i < 12; i++)
                        {
                            a1.SetValue(double.Parse(dataGridView1.Rows[0].Cells[0].Value.ToString()), 0, i);
                        }

                        for (int i = 0; i < dataGridView1.Rows.Count; i++)
                        {
                            a1.SetValue(double.Parse(dataGridView1.Rows[i].Cells[2].Value.ToString()), 2, int.Parse(dataGridView1.Rows[i].Cells[1].Value.ToString()) - 1);
                        }

                        var chart = chart1.ChartAreas[0];
                        chart.AxisX.IntervalType = DateTimeIntervalType.Number;

                        chart.AxisX.LabelStyle.Format = "";
                        chart.AxisY.LabelStyle.Format = "";
                        chart.AxisY.LabelStyle.IsEndLabelVisible = true;

                        chart.AxisX.Minimum = 1;
                        chart.AxisX.Maximum = 12;
                        chart.AxisY.Minimum = 0;
                        chart.AxisY.Maximum = 240000;
                        chart.AxisX.Interval = 1;
                        chart.AxisY.Interval = 20000;

                        chart1.Series.Add("ThisYear");

                        //绘制折线图
                        //chart1.Series["line1"].ChartType = SeriesChartType.Line;
                        //绘制曲线图
                        chart1.Series["ThisYear"].ChartType = SeriesChartType.Spline;

                        chart1.Series["ThisYear"].Color = Color.Blue;
                        chart1.Series["ThisYear"].BorderWidth = 10;
                        chart1.Series[0].IsVisibleInLegend = true;
                        

                        chart1.Series["ThisYear"].Points.AddXY(1, a1[2, 0]);
                        chart1.Series["ThisYear"].Points.AddXY(2, a1[2, 1]);
                        chart1.Series["ThisYear"].Points.AddXY(3, a1[2, 2]);
                        chart1.Series["ThisYear"].Points.AddXY(4, a1[2, 3]);
                        chart1.Series["ThisYear"].Points.AddXY(5, a1[2, 4]);
                        chart1.Series["ThisYear"].Points.AddXY(6, a1[2, 5]);
                        chart1.Series["ThisYear"].Points.AddXY(7, a1[2, 6]);
                        chart1.Series["ThisYear"].Points.AddXY(8, a1[2, 7]);
                        chart1.Series["ThisYear"].Points.AddXY(9, a1[2, 8]);
                        chart1.Series["ThisYear"].Points.AddXY(10, a1[2, 9]);
                        chart1.Series["ThisYear"].Points.AddXY(11, a1[2, 10]);
                        chart1.Series["ThisYear"].Points.AddXY(12, a1[2, 11]);

                        #endregion

                        #region 前年
                        
                        double[,] a2;
                        a2 = new double[,] { { a1[0, 0]-1, a1[0, 0]-1, a1[0, 0]-1, a1[0, 0]-1, a1[0, 0] - 1, a1[0, 0] - 1, a1[0, 0] - 1, a1[0, 0] - 1, a1[0, 0] - 1, a1[0, 0] - 1, a1[0, 0] - 1, a1[0, 0] - 1 }, { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12 }, { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 } };

                        ds2 = new DataSet();
                        DataBinding dbConn2 = new DataBinding();
                        string sql2 = string.Format("select y,m,avg(FSIqty) as fsiqty,sum(fssqty) as fssqty from ( select year(countdate) as y, datepart(MONTH, countdate) as m, FSIqty, fssqty from countFS) a where a.y = year(getdate())-1 group by y, m");
                        SqlDataAdapter adapter2 = new SqlDataAdapter(sql2, dbConn2.connection);
                        adapter2.Fill(ds2, "DATA");
                        dataGridView1.DataSource = ds2.Tables[0];

                        //for (int i = 0; i < 12; i++)
                        //{
                        //    a2.SetValue(double.Parse(dataGridView1.Rows[0].Cells[0].Value.ToString()), 0, i);
                        //}

                        for (int i = 0; i < dataGridView1.Rows.Count; i++)
                        {
                            a2.SetValue(double.Parse(dataGridView1.Rows[i].Cells[2].Value.ToString()), 2, int.Parse(dataGridView1.Rows[i].Cells[1].Value.ToString()) - 1);
                        }
                                                                                                              
                        chart1.Series.Add("LastYear");

                        //绘制折线图
                        //chart1.Series["line1"].ChartType = SeriesChartType.Line;
                        //绘制曲线图
                        chart1.Series["LastYear"].ChartType = SeriesChartType.Spline;

                        chart1.Series["LastYear"].Color = Color.Red;
                        chart1.Series["LastYear"].BorderWidth = 10;
                        chart1.Series[1].IsVisibleInLegend = true;

                        chart1.Series["LastYear"].Points.AddXY(1, a2[2, 0]);
                        chart1.Series["LastYear"].Points.AddXY(2, a2[2, 1]);
                        chart1.Series["LastYear"].Points.AddXY(3, a2[2, 2]);
                        chart1.Series["LastYear"].Points.AddXY(4, a2[2, 3]);
                        chart1.Series["LastYear"].Points.AddXY(5, a2[2, 4]);
                        chart1.Series["LastYear"].Points.AddXY(6, a2[2, 5]);
                        chart1.Series["LastYear"].Points.AddXY(7, a2[2, 6]);
                        chart1.Series["LastYear"].Points.AddXY(8, a2[2, 7]);
                        chart1.Series["LastYear"].Points.AddXY(9, a2[2, 8]);
                        chart1.Series["LastYear"].Points.AddXY(10, a2[2, 9]);
                        chart1.Series["LastYear"].Points.AddXY(11, a2[2, 10]);
                        chart1.Series["LastYear"].Points.AddXY(12, a2[2, 11]);

                        #endregion

                        #region 去年

                        double[,] a3;
                        a3 = new double[,] { { a1[0, 0] - 2, a1[0, 0] - 2, a1[0, 0] - 2, a1[0, 0] - 2, a1[0, 0] - 2, a1[0, 0] - 2, a1[0, 0] - 2, a1[0, 0] - 2, a1[0, 0] - 2, a1[0, 0] - 2, a1[0, 0] - 2, a1[0, 0] - 2 }, { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12 }, { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 } };

                        ds3 = new DataSet();
                        DataBinding dbConn3 = new DataBinding();
                        string sql3 = string.Format("select y,m,avg(FSIqty) as fsiqty,sum(fssqty) as fssqty from ( select year(countdate) as y, datepart(MONTH, countdate) as m, FSIqty, fssqty from countFS) a where a.y = year(getdate())-2 group by y, m");
                        SqlDataAdapter adapter3 = new SqlDataAdapter(sql3, dbConn3.connection);
                        adapter3.Fill(ds3, "DATA");
                        dataGridView1.DataSource = ds3.Tables[0];

                        //for (int i = 0; i < 12; i++)
                        //{
                        //    a2.SetValue(double.Parse(dataGridView1.Rows[0].Cells[0].Value.ToString()), 0, i);
                        //}

                        for (int i = 0; i < dataGridView1.Rows.Count; i++)
                        {
                            a3.SetValue(double.Parse(dataGridView1.Rows[i].Cells[2].Value.ToString()), 2, int.Parse(dataGridView1.Rows[i].Cells[1].Value.ToString()) - 1);
                        }

                        chart1.Series.Add("TheYearBeforeLast");

                        //绘制折线图
                        //chart1.Series["line1"].ChartType = SeriesChartType.Line;
                        //绘制曲线图
                        chart1.Series["TheYearBeforeLast"].ChartType = SeriesChartType.Spline;

                        chart1.Series["TheYearBeforeLast"].Color = Color.Green;
                        chart1.Series["TheYearBeforeLast"].BorderWidth = 10;
                        chart1.Series[2].IsVisibleInLegend = true;

                        chart1.Series["TheYearBeforeLast"].Points.AddXY(1, a3[2, 0]);
                        chart1.Series["TheYearBeforeLast"].Points.AddXY(2, a3[2, 1]);
                        chart1.Series["TheYearBeforeLast"].Points.AddXY(3, a3[2, 2]);
                        chart1.Series["TheYearBeforeLast"].Points.AddXY(4, a3[2, 3]);
                        chart1.Series["TheYearBeforeLast"].Points.AddXY(5, a3[2, 4]);
                        chart1.Series["TheYearBeforeLast"].Points.AddXY(6, a3[2, 5]);
                        chart1.Series["TheYearBeforeLast"].Points.AddXY(7, a3[2, 6]);
                        chart1.Series["TheYearBeforeLast"].Points.AddXY(8, a3[2, 7]);
                        chart1.Series["TheYearBeforeLast"].Points.AddXY(9, a3[2, 8]);
                        chart1.Series["TheYearBeforeLast"].Points.AddXY(10, a3[2, 9]);
                        chart1.Series["TheYearBeforeLast"].Points.AddXY(11, a3[2, 10]);
                        chart1.Series["TheYearBeforeLast"].Points.AddXY(12, a3[2, 11]);

                        #endregion

                    }
                    else //出貨數
                    {
                        #region 今年

                        double[,] a1;
                        a1 = new double[,] { { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }, { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12 }, { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 } };

                        ds1 = new DataSet();
                        DataBinding dbConn = new DataBinding();
                        string sql = string.Format("select y,m,avg(FSIqty) as fsiqty,sum(fssqty) as fssqty from ( select year(countdate) as y, datepart(MONTH, countdate) as m, FSIqty, fssqty from countFS) a where a.y = year(getdate()) group by y, m");
                        SqlDataAdapter adapter = new SqlDataAdapter(sql, dbConn.connection);
                        adapter.Fill(ds1, "DATA");
                        dataGridView1.DataSource = ds1.Tables[0];

                        for (int i = 0; i < 12; i++)
                        {
                            a1.SetValue(double.Parse(dataGridView1.Rows[0].Cells[0].Value.ToString()), 0, i);
                        }

                        for (int i = 0; i < dataGridView1.Rows.Count; i++)
                        {
                            a1.SetValue(double.Parse(dataGridView1.Rows[i].Cells[3].Value.ToString()), 2, int.Parse(dataGridView1.Rows[i].Cells[1].Value.ToString()) - 1);
                        }

                        var chart = chart1.ChartAreas[0];
                        chart.AxisX.IntervalType = DateTimeIntervalType.Number;

                        chart.AxisX.LabelStyle.Format = "";
                        chart.AxisY.LabelStyle.Format = "";
                        chart.AxisY.LabelStyle.IsEndLabelVisible = true;

                        chart.AxisX.Minimum = 1;
                        chart.AxisX.Maximum = 12;
                        chart.AxisY.Minimum = 0;
                        chart.AxisY.Maximum = 150000;
                        chart.AxisX.Interval = 1;
                        chart.AxisY.Interval = 10000;

                        chart1.Series.Add("ThisYear");

                        //绘制折线图
                        //chart1.Series["line1"].ChartType = SeriesChartType.Line;
                        //绘制曲线图
                        chart1.Series["ThisYear"].ChartType = SeriesChartType.Spline;

                        chart1.Series["ThisYear"].Color = Color.Blue;
                        chart1.Series["ThisYear"].BorderWidth = 10;
                        chart1.Series[0].IsVisibleInLegend = true;

                        chart1.Series["ThisYear"].Points.AddXY(1, a1[2, 0]);
                        chart1.Series["ThisYear"].Points.AddXY(2, a1[2, 1]);
                        chart1.Series["ThisYear"].Points.AddXY(3, a1[2, 2]);
                        chart1.Series["ThisYear"].Points.AddXY(4, a1[2, 3]);
                        chart1.Series["ThisYear"].Points.AddXY(5, a1[2, 4]);
                        chart1.Series["ThisYear"].Points.AddXY(6, a1[2, 5]);
                        chart1.Series["ThisYear"].Points.AddXY(7, a1[2, 6]);
                        chart1.Series["ThisYear"].Points.AddXY(8, a1[2, 7]);
                        chart1.Series["ThisYear"].Points.AddXY(9, a1[2, 8]);
                        chart1.Series["ThisYear"].Points.AddXY(10, a1[2, 9]);
                        chart1.Series["ThisYear"].Points.AddXY(11, a1[2, 10]);
                        chart1.Series["ThisYear"].Points.AddXY(12, a1[2, 11]);

                        #endregion

                        #region 前年

                        double[,] a2;
                        a2 = new double[,] { { a1[0, 0] - 1, a1[0, 0] - 1, a1[0, 0] - 1, a1[0, 0] - 1, a1[0, 0] - 1, a1[0, 0] - 1, a1[0, 0] - 1, a1[0, 0] - 1, a1[0, 0] - 1, a1[0, 0] - 1, a1[0, 0] - 1, a1[0, 0] - 1 }, { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12 }, { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 } };

                        ds2 = new DataSet();
                        DataBinding dbConn2 = new DataBinding();
                        string sql2 = string.Format("select y,m,avg(FSIqty) as fsiqty,sum(fssqty) as fssqty from ( select year(countdate) as y, datepart(MONTH, countdate) as m, FSIqty, fssqty from countFS) a where a.y = year(getdate())-1 group by y, m");
                        SqlDataAdapter adapter2 = new SqlDataAdapter(sql2, dbConn2.connection);
                        adapter2.Fill(ds2, "DATA");
                        dataGridView1.DataSource = ds2.Tables[0];

                        //for (int i = 0; i < 12; i++)
                        //{
                        //    a2.SetValue(double.Parse(dataGridView1.Rows[0].Cells[0].Value.ToString()), 0, i);
                        //}

                        for (int i = 0; i < dataGridView1.Rows.Count; i++)
                        {
                            a2.SetValue(double.Parse(dataGridView1.Rows[i].Cells[3].Value.ToString()), 2, int.Parse(dataGridView1.Rows[i].Cells[1].Value.ToString()) - 1);
                        }

                        chart1.Series.Add("LastYear");

                        //绘制折线图
                        //chart1.Series["line1"].ChartType = SeriesChartType.Line;
                        //绘制曲线图
                        chart1.Series["LastYear"].ChartType = SeriesChartType.Spline;

                        chart1.Series["LastYear"].Color = Color.Red;
                        chart1.Series["LastYear"].BorderWidth = 10;
                        chart1.Series[1].IsVisibleInLegend = true;

                        chart1.Series["LastYear"].Points.AddXY(1, a2[2, 0]);
                        chart1.Series["LastYear"].Points.AddXY(2, a2[2, 1]);
                        chart1.Series["LastYear"].Points.AddXY(3, a2[2, 2]);
                        chart1.Series["LastYear"].Points.AddXY(4, a2[2, 3]);
                        chart1.Series["LastYear"].Points.AddXY(5, a2[2, 4]);
                        chart1.Series["LastYear"].Points.AddXY(6, a2[2, 5]);
                        chart1.Series["LastYear"].Points.AddXY(7, a2[2, 6]);
                        chart1.Series["LastYear"].Points.AddXY(8, a2[2, 7]);
                        chart1.Series["LastYear"].Points.AddXY(9, a2[2, 8]);
                        chart1.Series["LastYear"].Points.AddXY(10, a2[2, 9]);
                        chart1.Series["LastYear"].Points.AddXY(11, a2[2, 10]);
                        chart1.Series["LastYear"].Points.AddXY(12, a2[2, 11]);

                        #endregion

                        #region 去年

                        double[,] a3;
                        a3 = new double[,] { { a1[0, 0] - 2, a1[0, 0] - 2, a1[0, 0] - 2, a1[0, 0] - 2, a1[0, 0] - 2, a1[0, 0] - 2, a1[0, 0] - 2, a1[0, 0] - 2, a1[0, 0] - 2, a1[0, 0] - 2, a1[0, 0] - 2, a1[0, 0] - 2 }, { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12 }, { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 } };

                        ds3 = new DataSet();
                        DataBinding dbConn3 = new DataBinding();
                        string sql3 = string.Format("select y,m,avg(FSIqty) as fsiqty,sum(fssqty) as fssqty from ( select year(countdate) as y, datepart(MONTH, countdate) as m, FSIqty, fssqty from countFS) a where a.y = year(getdate())-2 group by y, m");
                        SqlDataAdapter adapter3 = new SqlDataAdapter(sql3, dbConn3.connection);
                        adapter3.Fill(ds3, "DATA");
                        dataGridView1.DataSource = ds3.Tables[0];

                        //for (int i = 0; i < 12; i++)
                        //{
                        //    a2.SetValue(double.Parse(dataGridView1.Rows[0].Cells[0].Value.ToString()), 0, i);
                        //}

                        for (int i = 0; i < dataGridView1.Rows.Count; i++)
                        {
                            a3.SetValue(double.Parse(dataGridView1.Rows[i].Cells[3].Value.ToString()), 2, int.Parse(dataGridView1.Rows[i].Cells[1].Value.ToString()) - 1);
                        }

                        chart1.Series.Add("TheYearBeforeLast");

                        //绘制折线图
                        //chart1.Series["line1"].ChartType = SeriesChartType.Line;
                        //绘制曲线图
                        chart1.Series["TheYearBeforeLast"].ChartType = SeriesChartType.Spline;

                        chart1.Series["TheYearBeforeLast"].Color = Color.Green;
                        chart1.Series["TheYearBeforeLast"].BorderWidth = 10;
                        chart1.Series[2].IsVisibleInLegend = true;

                        chart1.Series["TheYearBeforeLast"].Points.AddXY(1, a3[2, 0]);
                        chart1.Series["TheYearBeforeLast"].Points.AddXY(2, a3[2, 1]);
                        chart1.Series["TheYearBeforeLast"].Points.AddXY(3, a3[2, 2]);
                        chart1.Series["TheYearBeforeLast"].Points.AddXY(4, a3[2, 3]);
                        chart1.Series["TheYearBeforeLast"].Points.AddXY(5, a3[2, 4]);
                        chart1.Series["TheYearBeforeLast"].Points.AddXY(6, a3[2, 5]);
                        chart1.Series["TheYearBeforeLast"].Points.AddXY(7, a3[2, 6]);
                        chart1.Series["TheYearBeforeLast"].Points.AddXY(8, a3[2, 7]);
                        chart1.Series["TheYearBeforeLast"].Points.AddXY(9, a3[2, 8]);
                        chart1.Series["TheYearBeforeLast"].Points.AddXY(10, a3[2, 9]);
                        chart1.Series["TheYearBeforeLast"].Points.AddXY(11, a3[2, 10]);
                        chart1.Series["TheYearBeforeLast"].Points.AddXY(12, a3[2, 11]);

                        #endregion
                    }
                }
                else  //season
                {
                    if (comboBox2.SelectedIndex == 0) //庫存
                    {
                        #region 今年

                        double[,] a1;
                        a1 = new double[,] { { 0, 0, 0, 0}, { 1, 2, 3, 4}, { 100000, 100000, 100000, 100000 } };

                        ds1 = new DataSet();
                        DataBinding dbConn = new DataBinding();
                        string sql = string.Format("select y,m,avg(FSIqty) as fsiqty,sum(fssqty) as fssqty from ( select year(countdate) as y, datepart(quarter, countdate) as m, FSIqty, fssqty from countFS) a where a.y = year(getdate()) group by y, m");
                        SqlDataAdapter adapter = new SqlDataAdapter(sql, dbConn.connection);
                        adapter.Fill(ds1, "DATA");
                        dataGridView1.DataSource = ds1.Tables[0];

                        for (int i = 0; i < 4; i++)
                        {
                            a1.SetValue(double.Parse(dataGridView1.Rows[0].Cells[0].Value.ToString()), 0, i);
                        }

                        for (int i = 0; i < dataGridView1.Rows.Count; i++)
                        {
                            a1.SetValue(double.Parse(dataGridView1.Rows[i].Cells[2].Value.ToString()), 2, int.Parse(dataGridView1.Rows[i].Cells[1].Value.ToString()) - 1);
                        }

                        var chart = chart1.ChartAreas[0];
                        chart.AxisX.IntervalType = DateTimeIntervalType.Number;

                        chart.AxisX.LabelStyle.Format = "";
                        chart.AxisY.LabelStyle.Format = "";
                        chart.AxisY.LabelStyle.IsEndLabelVisible = true;

                        chart.AxisX.Minimum = 1;
                        chart.AxisX.Maximum = 4;
                        chart.AxisY.Minimum = 0;
                        chart.AxisY.Maximum = 240000;
                        chart.AxisX.Interval = 1;
                        chart.AxisY.Interval = 20000;

                        chart1.Series.Add("ThisYear");

                        //绘制折线图
                        //chart1.Series["line1"].ChartType = SeriesChartType.Line;
                        //绘制曲线图
                        chart1.Series["ThisYear"].ChartType = SeriesChartType.Spline;

                        chart1.Series["ThisYear"].Color = Color.Blue;
                        chart1.Series["ThisYear"].BorderWidth = 10;
                        chart1.Series[0].IsVisibleInLegend = true;

                        chart1.Series["ThisYear"].Points.AddXY(1, a1[2, 0]);
                        chart1.Series["ThisYear"].Points.AddXY(2, a1[2, 1]);
                        chart1.Series["ThisYear"].Points.AddXY(3, a1[2, 2]);
                        chart1.Series["ThisYear"].Points.AddXY(4, a1[2, 3]);


                        #endregion

                        #region 前年

                        double[,] a2;
                        a2 = new double[,] { { a1[0, 0] - 1, a1[0, 0] - 1, a1[0, 0] - 1, a1[0, 0] - 1,}, { 1, 2, 3, 4}, { 0, 0, 0, 0 } };

                        ds2 = new DataSet();
                        DataBinding dbConn2 = new DataBinding();
                        string sql2 = string.Format("select y,m,avg(FSIqty) as fsiqty,sum(fssqty) as fssqty from ( select year(countdate) as y, datepart(quarter, countdate) as m, FSIqty, fssqty from countFS) a where a.y = year(getdate())-1 group by y, m");
                        SqlDataAdapter adapter2 = new SqlDataAdapter(sql2, dbConn2.connection);
                        adapter2.Fill(ds2, "DATA");
                        dataGridView1.DataSource = ds2.Tables[0];

                        //for (int i = 0; i < 12; i++)
                        //{
                        //    a2.SetValue(double.Parse(dataGridView1.Rows[0].Cells[0].Value.ToString()), 0, i);
                        //}

                        for (int i = 0; i < dataGridView1.Rows.Count; i++)
                        {
                            a2.SetValue(double.Parse(dataGridView1.Rows[i].Cells[2].Value.ToString()), 2, int.Parse(dataGridView1.Rows[i].Cells[1].Value.ToString()) - 1);
                        }

                        chart1.Series.Add("LastYear");

                        //绘制折线图
                        //chart1.Series["line1"].ChartType = SeriesChartType.Line;
                        //绘制曲线图
                        chart1.Series["LastYear"].ChartType = SeriesChartType.Spline;

                        chart1.Series["LastYear"].Color = Color.Red;
                        chart1.Series["LastYear"].BorderWidth = 10;
                        chart1.Series[1].IsVisibleInLegend = true;

                        chart1.Series["LastYear"].Points.AddXY(1, a2[2, 0]);
                        chart1.Series["LastYear"].Points.AddXY(2, a2[2, 1]);
                        chart1.Series["LastYear"].Points.AddXY(3, a2[2, 2]);
                        chart1.Series["LastYear"].Points.AddXY(4, a2[2, 3]);


                        #endregion

                        #region 去年

                        double[,] a3;
                        a3 = new double[,] { { a1[0, 0] - 2, a1[0, 0] - 2, a1[0, 0] - 2, a1[0, 0] - 2 }, { 1, 2, 3, 4}, { 0, 0, 0, 0 } };

                        ds3 = new DataSet();
                        DataBinding dbConn3 = new DataBinding();
                        string sql3 = string.Format("select y,m,avg(FSIqty) as fsiqty,sum(fssqty) as fssqty from ( select year(countdate) as y, datepart(quarter, countdate) as m, FSIqty, fssqty from countFS) a where a.y = year(getdate())-2 group by y, m");
                        SqlDataAdapter adapter3 = new SqlDataAdapter(sql3, dbConn3.connection);
                        adapter3.Fill(ds3, "DATA");
                        dataGridView1.DataSource = ds3.Tables[0];

                        //for (int i = 0; i < 12; i++)
                        //{
                        //    a2.SetValue(double.Parse(dataGridView1.Rows[0].Cells[0].Value.ToString()), 0, i);
                        //}

                        for (int i = 0; i < dataGridView1.Rows.Count; i++)
                        {
                            a3.SetValue(double.Parse(dataGridView1.Rows[i].Cells[2].Value.ToString()), 2, int.Parse(dataGridView1.Rows[i].Cells[1].Value.ToString()) - 1);
                        }

                        chart1.Series.Add("TheYearBeforeLast");

                        //绘制折线图
                        //chart1.Series["line1"].ChartType = SeriesChartType.Line;
                        //绘制曲线图
                        chart1.Series["TheYearBeforeLast"].ChartType = SeriesChartType.Spline;

                        chart1.Series["TheYearBeforeLast"].Color = Color.Green;
                        chart1.Series["TheYearBeforeLast"].BorderWidth = 10;
                        chart1.Series[2].IsVisibleInLegend = true;

                        chart1.Series["TheYearBeforeLast"].Points.AddXY(1, a3[2, 0]);
                        chart1.Series["TheYearBeforeLast"].Points.AddXY(2, a3[2, 1]);
                        chart1.Series["TheYearBeforeLast"].Points.AddXY(3, a3[2, 2]);
                        chart1.Series["TheYearBeforeLast"].Points.AddXY(4, a3[2, 3]);


                        #endregion
                    }
                    else //出貨數
                    {
                        #region 今年

                        double[,] a1;
                        a1 = new double[,] { { 0, 0, 0, 0}, { 1, 2, 3, 4 }, { 0, 0, 0, 0 } };

                        ds1 = new DataSet();
                        DataBinding dbConn = new DataBinding();
                        string sql = string.Format("select y,m,avg(FSIqty) as fsiqty,sum(fssqty) as fssqty from ( select year(countdate) as y, datepart(quarter, countdate) as m, FSIqty, fssqty from countFS) a where a.y = year(getdate()) group by y, m");
                        SqlDataAdapter adapter = new SqlDataAdapter(sql, dbConn.connection);
                        adapter.Fill(ds1, "DATA");
                        dataGridView1.DataSource = ds1.Tables[0];

                        for (int i = 0; i < 4; i++)
                        {
                            a1.SetValue(double.Parse(dataGridView1.Rows[0].Cells[0].Value.ToString()), 0, i);
                        }

                        for (int i = 0; i < dataGridView1.Rows.Count; i++)
                        {
                            a1.SetValue(double.Parse(dataGridView1.Rows[i].Cells[3].Value.ToString()), 2, int.Parse(dataGridView1.Rows[i].Cells[1].Value.ToString()) - 1);
                        }

                        var chart = chart1.ChartAreas[0];
                        chart.AxisX.IntervalType = DateTimeIntervalType.Number;

                        chart.AxisX.LabelStyle.Format = "";
                        chart.AxisY.LabelStyle.Format = "";
                        chart.AxisY.LabelStyle.IsEndLabelVisible = true;

                        chart.AxisX.Minimum = 1;
                        chart.AxisX.Maximum = 4;
                        chart.AxisY.Minimum = 0;
                        chart.AxisY.Maximum = 300000;
                        chart.AxisX.Interval = 1;
                        chart.AxisY.Interval = 20000;

                        chart1.Series.Add("ThisYear");

                        //绘制折线图
                        //chart1.Series["line1"].ChartType = SeriesChartType.Line;
                        //绘制曲线图
                        chart1.Series["ThisYear"].ChartType = SeriesChartType.Spline;

                        chart1.Series["ThisYear"].Color = Color.Blue;
                        chart1.Series["ThisYear"].BorderWidth = 10;
                        chart1.Series[0].IsVisibleInLegend = true;

                        chart1.Series["ThisYear"].Points.AddXY(1, a1[2, 0]);
                        chart1.Series["ThisYear"].Points.AddXY(2, a1[2, 1]);
                        chart1.Series["ThisYear"].Points.AddXY(3, a1[2, 2]);
                        chart1.Series["ThisYear"].Points.AddXY(4, a1[2, 3]);


                        #endregion

                        #region 前年

                        double[,] a2;
                        a2 = new double[,] { { a1[0, 0] - 1, a1[0, 0] - 1, a1[0, 0] - 1, a1[0, 0] - 1 }, { 1, 2, 3, 4 }, { 0, 0, 0, 0 } };

                        ds2 = new DataSet();
                        DataBinding dbConn2 = new DataBinding();
                        string sql2 = string.Format("select y,m,avg(FSIqty) as fsiqty,sum(fssqty) as fssqty from ( select year(countdate) as y, datepart(quarter, countdate) as m, FSIqty, fssqty from countFS) a where a.y = year(getdate())-1 group by y, m");
                        SqlDataAdapter adapter2 = new SqlDataAdapter(sql2, dbConn2.connection);
                        adapter2.Fill(ds2, "DATA");
                        dataGridView1.DataSource = ds2.Tables[0];

                        //for (int i = 0; i < 12; i++)
                        //{
                        //    a2.SetValue(double.Parse(dataGridView1.Rows[0].Cells[0].Value.ToString()), 0, i);
                        //}

                        for (int i = 0; i < dataGridView1.Rows.Count; i++)
                        {
                            a2.SetValue(double.Parse(dataGridView1.Rows[i].Cells[3].Value.ToString()), 2, int.Parse(dataGridView1.Rows[i].Cells[1].Value.ToString()) - 1);
                        }

                        chart1.Series.Add("LastYear");

                        //绘制折线图
                        //chart1.Series["line1"].ChartType = SeriesChartType.Line;
                        //绘制曲线图
                        chart1.Series["LastYear"].ChartType = SeriesChartType.Spline;

                        chart1.Series["LastYear"].Color = Color.Red;
                        chart1.Series["LastYear"].BorderWidth = 10;
                        chart1.Series[1].IsVisibleInLegend = true;

                        chart1.Series["LastYear"].Points.AddXY(1, a2[2, 0]);
                        chart1.Series["LastYear"].Points.AddXY(2, a2[2, 1]);
                        chart1.Series["LastYear"].Points.AddXY(3, a2[2, 2]);
                        chart1.Series["LastYear"].Points.AddXY(4, a2[2, 3]);
 

                        #endregion

                        #region 去年

                        double[,] a3;
                        a3 = new double[,] { { a1[0, 0] - 2, a1[0, 0] - 2, a1[0, 0] - 2, a1[0, 0] - 2 }, { 1, 2, 3, 4 }, { 0, 0, 0, 0 } };

                        ds3 = new DataSet();
                        DataBinding dbConn3 = new DataBinding();
                        string sql3 = string.Format("select y,m,avg(FSIqty) as fsiqty,sum(fssqty) as fssqty from ( select year(countdate) as y, datepart(quarter, countdate) as m, FSIqty, fssqty from countFS) a where a.y = year(getdate())-2 group by y, m");
                        SqlDataAdapter adapter3 = new SqlDataAdapter(sql3, dbConn3.connection);
                        adapter3.Fill(ds3, "DATA");
                        dataGridView1.DataSource = ds3.Tables[0];

                        //for (int i = 0; i < 12; i++)
                        //{
                        //    a2.SetValue(double.Parse(dataGridView1.Rows[0].Cells[0].Value.ToString()), 0, i);
                        //}

                        for (int i = 0; i < dataGridView1.Rows.Count; i++)
                        {
                            a3.SetValue(double.Parse(dataGridView1.Rows[i].Cells[3].Value.ToString()), 2, int.Parse(dataGridView1.Rows[i].Cells[1].Value.ToString()) - 1);
                        }

                        chart1.Series.Add("TheYearBeforeLast");

                        //绘制折线图
                        //chart1.Series["line1"].ChartType = SeriesChartType.Line;
                        //绘制曲线图
                        chart1.Series["TheYearBeforeLast"].ChartType = SeriesChartType.Spline;

                        chart1.Series["TheYearBeforeLast"].Color = Color.Green;
                        chart1.Series["TheYearBeforeLast"].BorderWidth = 10;
                        chart1.Series[2].IsVisibleInLegend = true;

                        chart1.Series["TheYearBeforeLast"].Points.AddXY(1, a3[2, 0]);
                        chart1.Series["TheYearBeforeLast"].Points.AddXY(2, a3[2, 1]);
                        chart1.Series["TheYearBeforeLast"].Points.AddXY(3, a3[2, 2]);
                        chart1.Series["TheYearBeforeLast"].Points.AddXY(4, a3[2, 3]);


                        #endregion
                    }
                }

            }
            catch (Exception)
            {
            }
        }



        private void tsbQuery_Click(object sender, EventArgs e)
        {
            Start();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Start();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            Start();
        }
    }
}
