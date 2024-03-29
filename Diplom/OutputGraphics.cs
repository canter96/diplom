﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Diplom
{
    public partial class OutputGraphics : Form
    {
        public static double op_delta;
        public OutputGraphics()
        {
            InitializeComponent();
        }
        public void main(Chart chart, double[] ToGraph, string name, int number, double[] k1, double[] k2)
        {
            string max = "";
            string r = "";
            double radius = 0.0;

            chart.Series.Clear();
            chart.BorderlineColor = Color.Black;
            chart.BorderlineDashStyle = ChartDashStyle.Solid;
            chart.BorderlineWidth = 1;

            ChartArea chartArea = chart.ChartAreas[0];
            chartArea.BackColor = Color.White;
            chartArea.AxisX.LabelStyle.Format = "F0";
            chartArea.AxisX.Minimum = 0.0;
            chartArea.AxisX.Maximum = 100;
            chartArea.AxisX.Interval = 10;



            Series seriesNumber = new Series($"Зображення номер {number}");

            Series seriesFirstImage1 = new Series($"Графік: {name}");
            seriesFirstImage1.ChartType = SeriesChartType.Spline;
            seriesFirstImage1.Color = Color.Black;
            seriesFirstImage1.BorderWidth = 2;

            Series seriesFirstImage2 = new Series("Робоча область");
            seriesFirstImage2.ChartType = SeriesChartType.Area;
            seriesFirstImage2.Color = Color.LightGray;

            Series seriesFirstImage3 = new Series("Оптимальный радиус");
            seriesFirstImage3.ChartType = SeriesChartType.Line;
            seriesFirstImage3.Color = Color.Blue;
            seriesFirstImage3.BorderWidth = 2;

            double temp = 0.0;
            double maxgr = 0d;
            int maxEl = 0;
            for (int i = 0, j = 0; i < ToGraph.Length; i++)
            {
                if (Double.IsNaN(ToGraph[i]))
                {
                    temp = 0.0;
                }
                else
                {
                    temp = ToGraph[i];
                }
                if (k1[i] >= 0.5 && k2[i] < 0.5)
                {
                    if (j == 77)
                    {
                        seriesFirstImage2.Points.AddXY(i, 0);
                        j = 78;
                    }
                    seriesFirstImage2.Points.AddXY(i, temp);
                    if (ToGraph[i] > maxgr)
                    {
                        maxgr = ToGraph[i];
                    }
                    //індекс максимального елементу середнього графіка 
                    maxEl = Array.IndexOf(ToGraph, maxgr);
                    radius++;
                }
                else
                {
                    j = 77;
                    seriesFirstImage2.Points.AddXY(i - 1, 0);
                }
                seriesFirstImage1.Points.AddXY(i, temp);
            }
            seriesFirstImage3.Points.AddXY(maxEl, 0);
            seriesFirstImage3.Points.AddXY(maxEl, maxgr);
            seriesFirstImage3.Points.AddXY(maxEl, 0);
            max = maxEl + ";" + max;
            r = radius + ";" + r;
            Series seriesRadius = new Series($"Радиус = {r}");
            Series seriesmax = new Series($"Оптимальный радиус = {max}");

            chart.Series.Add(seriesNumber);
            chart.Series.Add(seriesFirstImage1);
            chart.Series.Add(seriesFirstImage2);
            chart.Series.Add(seriesFirstImage3);
            chart.Series.Add(seriesmax);
            chart.Series.Add(seriesRadius);

            radius = 0.0;
            if (Form1.parallel == true || Form1.consistent == true)
            {
                op_delta = maxEl;
            }
        }
        public void GetGraph(Chart chart, double[] ToGraph, string name, int number)
        {
            Form1 form1 = new Form1();
            string max = "";
            string r = "";
            double radius = 0.0;

            chart.Series.Clear();
            chart.BorderlineColor = Color.Black;
            chart.BorderlineDashStyle = ChartDashStyle.Solid;
            chart.BorderlineWidth = 1;

            ChartArea chartArea = chart.ChartAreas[0];
            chartArea.BackColor = Color.White;
            chartArea.AxisX.LabelStyle.Format = "F0";
            chartArea.AxisX.Minimum = 0.0;
            chartArea.AxisX.Maximum = form1.sourseData.Length * 3;
            chartArea.AxisX.Interval = 50;



            Series seriesNumber = new Series($"Зображення номер {number}");

            Series seriesFirstImage1 = new Series($"Графік: {name}");
            seriesFirstImage1.ChartType = SeriesChartType.Line;
            seriesFirstImage1.Color = Color.Black;
            seriesFirstImage1.BorderWidth = 2;

            Series seriesFirstImage2 = new Series("Робоча область");
            seriesFirstImage2.ChartType = SeriesChartType.Area;
            seriesFirstImage2.Color = Color.LightGray;

            Series seriesFirstImage3 = new Series("Оптимальный радиус");
            seriesFirstImage3.ChartType = SeriesChartType.Line;
            seriesFirstImage3.Color = Color.Blue;
            seriesFirstImage3.BorderWidth = 2;

            double temp = 0.0;
            double maxgr = 0d;
            int maxEl = 0;
            for (int i = 0; i < ToGraph.Length; i++)
            {
                seriesFirstImage1.Points.AddXY(i, ToGraph[i]);
            }
            seriesFirstImage3.Points.AddXY(maxEl, 0);
            seriesFirstImage3.Points.AddXY(maxEl, maxgr);
            seriesFirstImage3.Points.AddXY(maxEl, 0);
            max = maxEl + ";" + max;
            r = radius + ";" + r;
            Series seriesRadius = new Series($"Радиус = {r}");
            Series seriesmax = new Series($"Оптимальный радиус = {form1.sourseData.Length}");

            chart.Series.Add(seriesNumber);
            chart.Series.Add(seriesFirstImage1);
            chart.Series.Add(seriesFirstImage2);
            chart.Series.Add(seriesFirstImage3);
            chart.Series.Add(seriesmax);
            chart.Series.Add(seriesRadius);

            radius = 0.0;
            if (Form1.parallel == true || Form1.consistent == true)
            {
                op_delta = maxEl;
            }
        }
        private void chart2_Click(object sender, EventArgs e)
        {

        }

        private void OutputGraphics_Load(object sender, EventArgs e)
        {

        }
    }
}
