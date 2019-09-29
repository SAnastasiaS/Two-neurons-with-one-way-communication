using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using System.IO;
using MathNet.Numerics.LinearAlgebra;
using MathNet.Numerics.LinearAlgebra.Double;

namespace LabWork1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        int r;
        int j = 0;
        char flagg = 'o';
        Vector<double> P1 = Vector<double>.Build.Dense(500000);
        Vector<double> P2 = Vector<double>.Build.Dense(500000);
        bool flag_isokl = false;
        //int[,] k = new int[100000, 100000];
        int count=0;





        private void DrawLine(double gamma, double d, double sigma, double x0, double y0, double h, double tfinal, double eps_gran, string s)
        {
            bool flag = false;
            double epsilon = 0.00001;

            double t_temp = 0;
            double h0 = h;


            TMyRK task = new TMyRK(gamma, d, sigma, 1);
            Matrix<double> XY0 = Matrix<double>.Build.Dense(2, 1);
            XY0[0, 0] = x0;
            XY0[1, 0] = y0;
            task.SetInit(0, XY0);
            int cc = 0;

            //for (int i = 0; i < 5; i++)
            //{
            count++;
            try
            {

                //Pass the filepath and filename to the StreamWriter Constructor
                string sss = "Line_" + count.ToString()+ ".txt";
                StreamWriter sw = new StreamWriter(sss);
                while ((tfinal - task.t) > eps_gran)
                {


                    if (task.XY[1, 0] > 2 * Math.PI || task.XY[0, 0] > 2 * Math.PI || task.XY[0, 0] < 0 || task.XY[1, 0] < 0)
                    {
                        if (task.XY[1, 0] > 2 * Math.PI)
                        {
                            flagg = 't';
                            task.XY[1, 0] = task.XY[1, 0] - 2 * Math.PI;
                        }
                        else if (task.XY[0, 0] > 2 * Math.PI)
                        {
                            flagg = 'r';
                            task.XY[0, 0] = task.XY[0, 0] - 2 * Math.PI;
                        }
                        else if (task.XY[0, 0] < 0)
                        {
                            flagg = 'b';
                            task.XY[0, 0] = 2 * Math.PI + task.XY[0, 0];
                        }
                        else if (task.XY[1, 0] < 0)
                        {
                            flagg = 'l';
                            task.XY[1, 0] = 2 * Math.PI + task.XY[1, 0];
                        }
                    }
                    //else
                    //{
                    {
                        if (r == 0)

                        {
                            chart1.Series[s].Points.AddXY(task.XY[0, 0], task.XY[1, 0]);
                        }
                        else
                        if (r == 1)
                        {
                            chart1.Series[s].Points.AddXY(task.t, task.XY[0, 0]);
                        }
                        else
                        if (r == 2)
                        {
                            chart1.Series[s].Points.AddXY(task.t, task.XY[1, 0]);
                        }
                    }
                    while ((task.t + h) > tfinal)
                    {
                        flag = true;
                        h = h / 2;
                    }
                    string ss = task.XY[0, 0].ToString() + " " + task.XY[1, 0].ToString();
                    //string ss2 = task.XY[1, 0].ToString();
                    sw.WriteLine(ss.Replace(",", "."));
                    task.NextStep(h);
                    cc++;
                }
                sw.Close();

            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }
            finally
            {
                Console.WriteLine("Executing finally block.");
            }
            //if (task.XY[1, 0] > 2*Math.PI || task.XY[0, 0] > 2*Math.PI || task.XY[0, 0] < 0 || task.XY[1, 0] < 0)
            //    break;


            //}


            //}


        }

        private void DrawLine_inv(double gamma, double d, double sigma, double x0, double y0, double h, double tfinal, double eps_gran, string s)
        {
            bool flag = false;
            double epsilon = 0.00001;

            double t_temp = 0;
            double h0 = -h;
            h = -h;


            TMyRK task = new TMyRK(gamma, d, sigma, 1);
            Matrix<double> XY0 = Matrix<double>.Build.Dense(2, 1);
            XY0[0, 0] = x0;
            XY0[1, 0] = y0;
            task.SetInit(tfinal, XY0);
            int cc = 0;

            //for (int i = 0; i < 5; i++)
            //{
            count++;
            try
            {

                //Pass the filepath and filename to the StreamWriter Constructor
                string sss = "Line_" + count.ToString() + ".txt";
                StreamWriter sw = new StreamWriter(sss);
                while (Math.Abs(0 - task.t) > eps_gran)
                {

                    if (task.XY[1, 0] > 2 * Math.PI || task.XY[0, 0] > 2 * Math.PI || task.XY[0, 0] < 0 || task.XY[1, 0] < 0)
                    {
                        if (task.XY[1, 0] > 2 * Math.PI)
                        {
                            flagg = 't';
                            task.XY[1, 0] = 0;
                        }
                        else if (task.XY[0, 0] > 2 * Math.PI)
                        {
                            flagg = 'r';
                            task.XY[0, 0] = 0;
                        }
                        else if (task.XY[0, 0] < 0)
                        {
                            flagg = 'b';
                            task.XY[0, 0] = 2 * Math.PI;
                        }
                        else if (task.XY[1, 0] < 0)
                        {
                            flagg = 'l';
                            task.XY[1, 0] = 2 * Math.PI;
                        }
                    }
                    //else
                    //{
                    {
                        if (r == 0)

                        {
                            chart1.Series[s].Points.AddXY(task.XY[0, 0], task.XY[1, 0]);
                        }
                        else
                        if (r == 1)
                        {
                            chart1.Series[s].Points.AddXY(task.t, task.XY[0, 0]);
                        }
                        else
                        if (r == 2)
                        {
                            chart1.Series[s].Points.AddXY(task.t, task.XY[1, 0]);
                        }
                    }
                    while ((task.t + h) < 0)
                    {
                        flag = true;
                        h = h / 2;
                    }
                    string ss = task.XY[0, 0].ToString() + " " + task.XY[1, 0].ToString();
                    //string ss2 = task.XY[1, 0].ToString();
                    sw.WriteLine(ss.Replace(",", "."));
                    task.NextStep(h);
                    cc++;
                }
                sw.Close();

            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }
            finally
            {
                Console.WriteLine("Executing finally block.");
            }
            //if (task.XY[1, 0] > 2*Math.PI || task.XY[0, 0] > 2*Math.PI || task.XY[0, 0] < 0 || task.XY[1, 0] < 0)
            //    break;


            //}


            //}


        }



        private void Form1_Load(object sender, EventArgs e)
        {

            //chart1.ChartAreas[0].AxisX.MajorGrid.Enabled = false;
            //chart1.ChartAreas[0].AxisY.MajorGrid.Enabled = false;
            //chart1.ChartAreas[0].AxisX.ScaleView.Zoom(-Math.PI, Math.PI);
            chart1.ChartAreas[0].CursorX.IsUserEnabled = true;
            chart1.ChartAreas[0].CursorX.IsUserSelectionEnabled = true;

            /*          chart1.ChartAreas[0].AxisX.ScrollBar.IsPositionedInside = true;*/
            chart1.ChartAreas[0].AxisX.MajorGrid.LineColor = Color.LightGray;
            chart1.ChartAreas[0].AxisY.MajorGrid.LineColor = Color.LightGray;
            chart1.ChartAreas[0].AxisX.ScaleView.Zoomable = true;

            chart1.ChartAreas[0].AxisY.Interval = 1;
            chart1.ChartAreas[0].CursorY.IsUserEnabled = true;
            chart1.ChartAreas[0].CursorY.IsUserSelectionEnabled = true;
            chart1.ChartAreas[0].AxisY.ScaleView.Zoomable = true;
            //chart1.ChartAreas[0].AxisY.ScrollBar.IsPositionedInside = true;
            chart1.ChartAreas[0].AxisX.Minimum = 0;
            chart1.ChartAreas[0].AxisY.Minimum = 0;
            chart1.ChartAreas[0].AxisX.Title = "phi_1";
            chart1.ChartAreas[0].AxisY.Title = "phi_2";
            chart1.ChartAreas[0].AxisY.Maximum = 2 * Math.PI;
        }




        private void button_clear_gr_Click(object sender, EventArgs e)
        {
            chart1.Series.Clear();
            count = 0;
            chart1.Legends.Clear();
            flag_isokl = false;
        }




        private void textBox_h_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (!Char.IsDigit(ch) && ch != 8 && (ch != ',' || textBox_h.Text.Contains(",")))
            {
                e.Handled = true;
            }
        }

        private void textBox_ε_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;

            e.Handled = true;

        }

        private void textBox_eps_gran_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (!Char.IsDigit(ch) && ch != 8 && (ch != ',' || textBox_eps_gran.Text.Contains(","))) //глянуть видео и доделать
            {
                e.Handled = true;
            }
        }




        private void textBox_tf_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (!Char.IsDigit(ch) && ch != 8 && (ch != ',' || textBox_tf.Text.Contains(","))) //глянуть видео и доделать
            {
                e.Handled = true;
            }
        }


        private void textBox_max_n_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;

            e.Handled = true;

        }








        private void button_y_Click_1(object sender, EventArgs e)
        {

            double phi1 = Convert.ToDouble(textBox_phi1.Text.ToString());
            double phi2 = Convert.ToDouble(textBox_phi2.Text.ToString());
            double gamma = Convert.ToDouble(textBox_gamma.Text.ToString());
            double h = Convert.ToDouble(textBox_h.Text.ToString());
            double tfinal = Convert.ToDouble(textBox_tf.Text.ToString());
            double eps_gran = Convert.ToDouble(textBox_eps_gran.Text.ToString());
            double d = Convert.ToDouble(textBox_d.Text.ToString());
            double sigma = Convert.ToDouble(textBox_sigma.Text.ToString());
            chart1.ChartAreas[0].AxisY.Title = "phi_2";
            chart1.ChartAreas[0].AxisX.Title = "t";
            r = 2;
            //chart1.Series.Add(j.ToString());
            //chart1.Series[j.ToString()].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;

            //if (Math.PI / 2 - sigma > 0)
            //{
            //    chart1.Series[j].Points.AddXY(0, Math.PI / 2 - sigma);
            //    chart1.Series[j].Points.AddXY(2*Math.PI, Math.PI / 2 - sigma);
            //}
            //j++;
            //chart1.Series.Add(j.ToString());
            //chart1.Series[j.ToString()].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.FastLine;
            //chart1.Series[j].Points.AddXY(0, Math.PI / 2 + sigma);
            //chart1.Series[j].Points.AddXY(2*Math.PI, Math.PI / 2 + sigma);
            chart1.ChartAreas[0].AxisX.Interval = 50;
            chart1.ChartAreas[0].AxisX.Maximum = tfinal;
            chart1.Series.Add(j.ToString());
            chart1.Series[j.ToString()].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.FastPoint;
            chart1.Legends.Add(j.ToString());
            string s = "(" + phi1.ToString() + ";" + phi2.ToString() + ")";
            chart1.Series[j.ToString()].LegendText = s;
            DrawLine(gamma, d, sigma, phi1, phi2, h, tfinal, eps_gran, j.ToString());
            j++;
        }



        private void button_traj_Click(object sender, EventArgs e)
        {
            double phi1 = Convert.ToDouble(textBox_phi1.Text.ToString());
            double phi2 = Convert.ToDouble(textBox_phi2.Text.ToString());
            double gamma = Convert.ToDouble(textBox_gamma.Text.ToString());
            double h = Convert.ToDouble(textBox_h.Text.ToString());
            double tfinal = Convert.ToDouble(textBox_tf.Text.ToString());
            double eps_gran = Convert.ToDouble(textBox_eps_gran.Text.ToString());
            double d = Convert.ToDouble(textBox_d.Text.ToString());
            double sigma = Convert.ToDouble(textBox_sigma.Text.ToString());
            chart1.ChartAreas[0].AxisY.Title = "phi_2";
            chart1.ChartAreas[0].AxisX.Title = "phi_1";
            r = 0;
            updateStripLines();
            //chart1.Series.Add(j.ToString());
            //chart1.Series[j.ToString()].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;

            //if (Math.PI / 2 - sigma > 0)
            //{
            //    chart1.Series[j].Points.AddXY(0, Math.PI / 2 - sigma);
            //    chart1.Series[j].Points.AddXY(2*Math.PI, Math.PI / 2 - sigma);
            //}
            //j++;
            //chart1.Series.Add(j.ToString());
            //chart1.Series[j.ToString()].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.FastLine;
            //chart1.Series[j].Points.AddXY(0, Math.PI / 2 + sigma);
            //chart1.Series[j].Points.AddXY(2*Math.PI, Math.PI / 2 + sigma);
            chart1.ChartAreas[0].AxisY.Maximum = 2 * Math.PI;
            chart1.ChartAreas[0].AxisY.Interval = 1;
            chart1.ChartAreas[0].AxisX.Maximum = 2 * Math.PI;
            chart1.ChartAreas[0].AxisX.Interval = 1;
            chart1.Series.Add(j.ToString());
            chart1.Series[j.ToString()].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.FastPoint;
            chart1.Legends.Add(j.ToString());
            chart1.Series[j.ToString()].MarkerSize = 3;
            string s = "(" + phi1.ToString() + ";" + phi2.ToString() + ")";
            chart1.Series[j.ToString()].LegendText = s;
            DrawLine(gamma, d, sigma, phi1, phi2, h, tfinal, eps_gran, j.ToString());
            j++;

            //chart1.Series.Add("100000");
            //chart1.Series["100000"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.FastPoint;
            //chart1.Series["100000"].MarkerSize = 10;
            //chart1.Series["100000"].Points.AddXY(Math.Asin(gamma), Math.Asin(gamma));
            //chart1.Series["100000"].Points.AddXY(Math.PI - Math.Asin(gamma), Math.PI - Math.Asin(gamma));


        }

        private void button_x_Click(object sender, EventArgs e)
        {
            double phi1 = Convert.ToDouble(textBox_phi1.Text.ToString());
            double phi2 = Convert.ToDouble(textBox_phi2.Text.ToString());
            double gamma = Convert.ToDouble(textBox_gamma.Text.ToString());
            double h = Convert.ToDouble(textBox_h.Text.ToString());
            double tfinal = Convert.ToDouble(textBox_tf.Text.ToString());
            double eps_gran = Convert.ToDouble(textBox_eps_gran.Text.ToString());
            double d = Convert.ToDouble(textBox_d.Text.ToString());
            double sigma = Convert.ToDouble(textBox_sigma.Text.ToString());
            chart1.ChartAreas[0].AxisY.Title = "phi_1";
            chart1.ChartAreas[0].AxisX.Title = "t";
            r = 1;
            //chart1.Series.Add(j.ToString());
            //chart1.Series[j.ToString()].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;

            //if (Math.PI / 2 - sigma > 0)
            //{
            //    chart1.Series[j].Points.AddXY(0, Math.PI / 2 - sigma);
            //    chart1.Series[j].Points.AddXY(2*Math.PI, Math.PI / 2 - sigma);
            //}
            //j++;
            //chart1.Series.Add(j.ToString());
            //chart1.Series[j.ToString()].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.FastLine;
            //chart1.Series[j].Points.AddXY(0, Math.PI / 2 + sigma);
            //chart1.Series[j].Points.AddXY(2*Math.PI, Math.PI / 2 + sigma);
            //chart1.ChartAreas[0].AxisY.ScaleView.Zoom(0, 50);
            chart1.ChartAreas[0].AxisX.Interval = 50;
            chart1.ChartAreas[0].AxisX.Maximum = tfinal;
            chart1.Series.Add(j.ToString());
            chart1.Series[j.ToString()].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.FastPoint;
            chart1.Series[j.ToString()].MarkerSize = 2;
            string s = "(" + phi1.ToString() + ";" + phi2.ToString() + ")";
            chart1.Series[j.ToString()].LegendText = s;
            DrawLine(gamma, d, sigma, phi1, phi2, h, tfinal, eps_gran, j.ToString());
            j++;
        }

        private void DrawCircle(double gamma, double d, double sigma, double x0, double y0, double h, double tfinal, double eps_gran, string s)
        {
            bool flag = false;
            double epsilon = 0.00001;

            double t_temp = 0;
            double h0 = h;
            double func = 100;

            TMyRK task = new TMyRK(gamma, d, sigma, 1);
            Matrix<double> XY0 = Matrix<double>.Build.Dense(2, 1);
            XY0[0, 0] = x0;
            XY0[1, 0] = y0;
            task.SetInit(0, XY0);

            bool counter = false;
            bool counter2 = false;
            bool counter3 = false;
            int counter4 = 0;
            bool counter5 = false;
            bool counter6 = false;
            double psi_1_old = x0;
            double psi_2_old = y0;
            double psi_1_new;
            double psi_2_new;
            double min = 100;
            double min2 = 100;
            int iter = -1;
            double t_old = 0, T;
            try
            {

                //Pass the filepath and filename to the StreamWriter Constructor
                StreamWriter sw = new StreamWriter("Test.txt");
                while ((tfinal - task.t) > eps_gran)
                {
                    iter++;

                    if (task.XY[1, 0] > 2 * Math.PI || task.XY[0, 0] > 2 * Math.PI || task.XY[0, 0] < 0 || task.XY[1, 0] < 0)
                    {
                        if (task.XY[1, 0] > 2 * Math.PI)
                        {
                            flagg = 't';
                            task.XY[1, 0] = 2 * Math.PI - task.XY[1, 0];
                        }
                        else if (task.XY[0, 0] > 2 * Math.PI)
                        {
                            flagg = 'r';
                            task.XY[0, 0] = 2 * Math.PI - task.XY[0, 0];
                        }
                        else if (task.XY[0, 0] < 0)
                        {
                            flagg = 'b';
                            task.XY[0, 0] = 2 * Math.PI + task.XY[0, 0];
                        }
                        else if (task.XY[1, 0] < 0)
                        {
                            flagg = 'l';
                            task.XY[1, 0] = 2 * Math.PI + task.XY[1, 0];
                        }
                    }

                    //else
                    //{

                    if (counter2 == true)
                    {
                        string ss = task.XY[0, 0].ToString() + " " + task.XY[1, 0].ToString();
                        //string ss2 = task.XY[1, 0].ToString();
                        sw.WriteLine(ss.Replace(",", "."));
                        if (r == 0)

                        {
                            chart1.Series[s].Points.AddXY(task.XY[0, 0], task.XY[1, 0]);
                        }
                        else
                        if (r == 1)
                        {
                            chart1.Series[s].Points.AddXY(task.t, task.XY[0, 0]);
                        }
                        else
                        if (r == 2)
                        {
                            chart1.Series[s].Points.AddXY(task.t, task.XY[1, 0]);
                        }
                    }
                    while ((task.t + h) > tfinal)
                    {
                        flag = true;
                        h = h / 2;
                    }
                    task.NextStep(h);
                    psi_1_new = task.XY[0, 0];
                    psi_2_new = task.XY[1, 0];
                    func = psi_2_new - 1;
                    if (counter5 == false && ((counter4 == 1 && func < 0) || (counter4 == -1 && func > 0)))
                    {
                        counter5 = true;
                    }
                    if (counter6 == false && counter5 == true && ((counter4 == 1 && func > 0) || (counter4 == -1 && func < 0)))
                    {
                        counter6 = true;
                    }
                    if (counter2 == true && counter3 == false && Math.Abs(func) < 0.0001 && Math.Abs(psi_1_old - psi_1_new) < 0.0001)
                    {
                        counter3 = true;

                        break;
                    }
                    if (counter == true && counter2 == false & Math.Abs(func) < 0.0001 && Math.Abs(psi_1_old - psi_1_new) < 0.0001 && counter6 == true)
                    {
                        counter2 = true;
                        psi_1_old = psi_1_new;
                        psi_2_old = psi_2_new;
                        textBox1.Text = "есть";
                        T = task.t - t_old;
                        textBox2.Text = T.ToString();



                    }
                    if (Math.Abs(func) < 0.0001)
                    {
                        if (counter2 == false)
                        {
                            t_old = task.t;
                        }
                        psi_1_old = task.XY[0, 0];
                        psi_2_old = task.XY[1, 0];
                    }

                    if (Math.Abs(func) < 0.0001 && counter == false)
                    {
                        counter = true;
                        psi_1_old = task.XY[0, 0];
                        psi_2_old = task.XY[1, 0];
                        if (func > 0)
                        {
                            counter4 = 1;
                        }
                        else
                        if (func < 0)
                        {
                            counter4 = -1;
                        }

                    }
                    double pp = psi_2_new;
                    min2 = Math.Abs(Math.Min(Math.Abs(psi_1_old - psi_1_new), min2));
                    min = Math.Abs(Math.Min(Math.Abs(func), min));
                }
                sw.Close();

            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }
            finally
            {
                Console.WriteLine("Executing finally block.");
            }
            if (counter2 == false)
            {
                textBox1.Text = "не найден";
            }
            //if (task.XY[1, 0] > 2*Math.PI || task.XY[0, 0] > 2*Math.PI || task.XY[0, 0] < 0 || task.XY[1, 0] < 0)
            //    break;


            //}


            //}


        }

        private void button1_Click(object sender, EventArgs e)
        {
            double phi1 = Convert.ToDouble(textBox_phi1.Text.ToString());
            double phi2 = Convert.ToDouble(textBox_phi2.Text.ToString());
            double gamma = Convert.ToDouble(textBox_gamma.Text.ToString());
            double h = Convert.ToDouble(textBox_h.Text.ToString());
            double tfinal = Convert.ToDouble(textBox_tf.Text.ToString());
            double eps_gran = Convert.ToDouble(textBox_eps_gran.Text.ToString());
            double d = Convert.ToDouble(textBox_d.Text.ToString());
            double sigma = Convert.ToDouble(textBox_sigma.Text.ToString());
            r = 0;
            chart1.ChartAreas[0].AxisY.Title = "phi_2";
            chart1.ChartAreas[0].AxisX.Title = "phi_1";

            chart1.ChartAreas[0].AxisX.Maximum = 2 * Math.PI;
            chart1.ChartAreas[0].AxisX.Interval = 1;
            chart1.Series.Add(j.ToString());
            chart1.Series[j.ToString()].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.FastPoint;
            chart1.Series[j.ToString()].MarkerSize = 4;
            DrawCircle(gamma, d, sigma, phi1, phi2, h, tfinal, eps_gran, j.ToString());
            chart1.Legends.Add(j.ToString());
            string s = "Уст. пр.ц.";
            chart1.Series[j.ToString()].LegendText = s;
            j++;
            chart1.Series.Add(j.ToString());
            chart1.Series[j.ToString()].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.FastPoint;
            chart1.Series[j.ToString()].MarkerSize = 4;
            Draw_unstableCircle(gamma, d, sigma, phi1, phi2, h, tfinal, eps_gran, j.ToString());
            chart1.Legends.Add(j.ToString());
            s = "Неуст. пр.ц.";
            chart1.Series[j.ToString()].LegendText = s;
            j++;

        }

        private void SearchCircle(double gamma, double d, double sigma, double x0, double y0, double h, double tfinal, double eps_gran)
        {
            bool flag = false;
            double epsilon = 0.00001;

            double t_temp = 0;
            double h0 = h;


            TMyRK task = new TMyRK(gamma, d, sigma, 1);
            Matrix<double> XY0 = Matrix<double>.Build.Dense(2, 1);
            XY0[0, 0] = x0;
            XY0[1, 0] = y0;
            task.SetInit(0, XY0);
            bool counter = false;
            bool counter2 = false;
            bool counter3 = false;
            int counter4 = 0;
            bool counter5 = false;
            bool counter6 = false;
            double psi_1_old = x0;
            double psi_2_old = y0;
            double psi_1_new;
            double psi_2_new;
            double min = 100;
            double min2 = 100;
            textBox1.Clear();
            while ((tfinal - task.t) > eps_gran)
            {


                if (task.XY[1, 0] > 2 * Math.PI || task.XY[0, 0] > 2 * Math.PI || task.XY[0, 0] < 0 || task.XY[1, 0] < 0)
                {
                    if (task.XY[1, 0] > 2 * Math.PI)
                    {
                        flagg = 't';
                        task.XY[1, 0] = 2 * Math.PI - task.XY[1, 0];
                    }
                    else if (task.XY[0, 0] > 2 * Math.PI)
                    {
                        flagg = 'r';
                        task.XY[0, 0] = 2 * Math.PI - task.XY[0, 0];
                    }
                    else if (task.XY[0, 0] < 0)
                    {
                        flagg = 'b';
                        task.XY[0, 0] = 2 * Math.PI+ task.XY[0, 0];
                    }
                    else if (task.XY[1, 0] < 0)
                    {
                        flagg = 'l';
                        task.XY[1, 0] = 2 * Math.PI+ task.XY[1, 0];
                    }
                }
                while ((task.t + h) > tfinal)
                {
                    flag = true;
                    h = h / 2;
                }
                task.NextStep(h);
                psi_1_new = task.XY[0, 0];
                psi_2_new = task.XY[1, 0];
                if (((counter4 == 1 && psi_2_new - 1 < 0) || (counter4 == -1 && psi_2_new - 1 > 0)))
                {
                    counter5 = true;
                }
                if (counter5 == true && ((counter4 == 1 && psi_2_new - 1 > 0) || (counter4 == -1 && psi_2_new - 1 < 0)))
                {
                    counter6 = true;
                }
                //if (counter2 == true & Math.Abs(psi_2_new - 5) < 0.00001 & Math.Abs(psi_1_old - psi_1_new) < 0.000000001)
                //{
                //    counter3 = true;
                //    break;
                //}
                if (counter == true & counter3 == false & Math.Abs(psi_2_new - 1) < 0.0001 & Math.Abs(psi_1_old - psi_1_new) < 0.0001 && counter6 == true)
                {
                    counter2 = true;
                    psi_1_old = psi_1_new;
                    psi_2_old = psi_2_new;
                    textBox1.Text = "да";
                }
                if (Math.Abs(psi_2_new - 1) < 0.0001)
                {
                    psi_1_old = task.XY[0, 0];
                    psi_2_old = task.XY[1, 0];
                }

                if (Math.Abs(psi_2_new - 1) < 0.0001 & counter == false)
                {
                    counter = true;
                    psi_1_old = task.XY[0, 0];
                    psi_2_old = task.XY[1, 0];
                    if (psi_2_new - 1 > 0)
                    {
                        counter4 = 1;
                    }
                    else
                    if (psi_2_new - 1 < 0)
                    {
                        counter4 = -1;
                    }
                }
                double pp = psi_2_new;
                min2 = Math.Abs(Math.Min(Math.Abs(psi_1_old - psi_1_new), min2));
                min = Math.Abs(Math.Min(Math.Abs(1 - psi_2_new), min));
            }

            //if (task.XY[1, 0] > 2*Math.PI || task.XY[0, 0] > 2*Math.PI || task.XY[0, 0] < 0 || task.XY[1, 0] < 0)
            //    break;


            //}


            //}

            if (counter2 == false)
            {
                textBox1.Text = "Нет";
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            double phi1 = Convert.ToDouble(textBox_phi1.Text.ToString());
            double phi2 = Convert.ToDouble(textBox_phi2.Text.ToString());
            double gamma = Convert.ToDouble(textBox_gamma.Text.ToString());
            double h = Convert.ToDouble(textBox_h.Text.ToString());
            double tfinal = Convert.ToDouble(textBox_tf.Text.ToString());
            double eps_gran = Convert.ToDouble(textBox_eps_gran.Text.ToString());
            double d = Convert.ToDouble(textBox_d.Text.ToString());
            double sigma = Convert.ToDouble(textBox_sigma.Text.ToString());
            SearchCircle(gamma, d, sigma, phi1, phi2, h, tfinal, eps_gran);
            //textBox1.Text = "Нет";
        }

        private void Diagramm(double gamma, double x0, double y0, double h, double tfinal, double eps_gran)
        {
            bool flag = false;
            double epsilon = 0.00001;

            double t_temp = 0;
            double h0 = h;
            double sigma, d;
            int i = 0;
            int j = 0;

            for (d = 0.01; d < 6; d = d + 0.1)
            {

                for (sigma = 0; sigma < 3; sigma = sigma + 0.1)
                {
                    //k[i, j] = 0;
                    TMyRK task = new TMyRK(gamma, d, sigma, 1);
                    Matrix<double> XY0 = Matrix<double>.Build.Dense(2, 1);
                    XY0[0, 0] = x0;
                    XY0[1, 0] = y0;
                    task.SetInit(0, XY0);
                    bool counter = false;
                    bool counter2 = false;
                    bool counter3 = false;
                    int counter4 = 0;
                    bool counter5 = false;
                    bool counter6 = false;
                    double psi_1_old = x0;
                    double psi_2_old = y0;
                    double psi_1_new;
                    double psi_2_new;
                    double min = 100;
                    double min2 = 100;
                    textBox1.Clear();
                    double func = 10;
                    while ((tfinal - task.t) > eps_gran)
                    {


                        if (task.XY[1, 0] > 2 * Math.PI || task.XY[0, 0] > 2 * Math.PI || task.XY[0, 0] < 0 || task.XY[1, 0] < 0)
                        {
                            if (task.XY[1, 0] > 2 * Math.PI)
                            {
                                flagg = 't';
                                task.XY[1, 0] = 0;
                            }
                            else if (task.XY[0, 0] > 2 * Math.PI)
                            {
                                flagg = 'r';
                                task.XY[0, 0] = 0;
                                //if (counter2 == true && counter3 == false)
                                //{ 
                                //k[i,j]++;
                                //}
                            }
                            else if (task.XY[0, 0] < 0)
                            {
                                flagg = 'b';
                                task.XY[0, 0] = 2 * Math.PI;
                            }
                            else if (task.XY[1, 0] < 0)
                            {
                                flagg = 'l';
                                task.XY[1, 0] = 2 * Math.PI;
                            }
                        }
                        while ((task.t + h) > tfinal)
                        {
                            flag = true;
                            h = h / 2;
                        }
                        task.NextStep(h);
                        psi_1_new = task.XY[0, 0];
                        psi_2_new = task.XY[1, 0];
                        func = psi_2_new-1;
                        if (counter5 == false && ((counter4 == 1 && func < 0) || (counter4 == -1 && func > 0)))
                        {
                            counter5 = true;
                        }
                        if (counter6 == false && counter5 == true && ((counter4 == 1 && func > 0) || (counter4 == -1 && func < 0)))
                        {
                            counter6 = true;
                        }
                        if (counter2 == true && counter3 == false && Math.Abs(func) < 0.001 && Math.Abs(psi_1_old - psi_1_new) < 0.0001 && Math.Abs(psi_2_old - psi_2_new) < 0.0001)
                        {
                            counter3 = true;
                            break;
                        }
                        if (counter == true && counter2 == false & Math.Abs(func) < 0.001 && Math.Abs(psi_1_old - psi_1_new) < 0.0001 && Math.Abs(psi_2_old - psi_2_new) < 0.0001 && counter6 == true)
                        {
                            counter2 = true;
                            psi_1_old = psi_1_new;
                            psi_2_old = psi_2_new;
                            P1[i] = d;
                            P2[j] = sigma;

                        }
                        if (Math.Abs(func) < 0.0001)
                        {
                            psi_1_old = task.XY[0, 0];
                            psi_2_old = task.XY[1, 0];
                        }

                        if (Math.Abs(func) < 0.0001 && counter == false)
                        {
                            counter = true;
                            psi_1_old = task.XY[0, 0];
                            psi_2_old = task.XY[1, 0];
                            if (func > 0)
                            {
                                counter4 = 1;
                            }
                            else
                            if (func < 0)
                            {
                                counter4 = -1;
                            }

                        }
                        //double pp = psi_2_new;
                        //min2 = Math.Abs(Math.Min(Math.Abs(psi_1_old - psi_1_new), min2));
                        //min = Math.Abs(Math.Min(Math.Abs(func), min));
                    }

                    //if (task.XY[1, 0] > 2*Math.PI || task.XY[0, 0] > 2*Math.PI || task.XY[0, 0] < 0 || task.XY[1, 0] < 0)
                    //    break;


                    //}


                    //}
                    j++;
                }
                i++;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            chart1.ChartAreas[0].AxisY.Maximum = Math.PI;
            chart1.ChartAreas[0].AxisY.Interval = 0.5;
            chart1.ChartAreas[0].AxisX.Maximum = 6;
            chart1.ChartAreas[0].AxisX.Interval = 1;
            double phi1 = Convert.ToDouble(textBox_phi1.Text.ToString());
            double phi2 = Convert.ToDouble(textBox_phi2.Text.ToString());
            double gamma = Convert.ToDouble(textBox_gamma.Text.ToString());
            double h = Convert.ToDouble(textBox_h.Text.ToString());
            double tfinal = Convert.ToDouble(textBox_tf.Text.ToString());
            double eps_gran = Convert.ToDouble(textBox_eps_gran.Text.ToString());
            double d = Convert.ToDouble(textBox_d.Text.ToString());
            double sigma = Convert.ToDouble(textBox_sigma.Text.ToString());
            chart1.ChartAreas[0].AxisY.Title = "sigma";
            chart1.ChartAreas[0].AxisX.Title = "d";
            Diagramm(gamma, phi1, phi2, h, tfinal, eps_gran);
            chart1.Series.Add("11");
            chart1.Series["11"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.FastPoint;
            chart1.Series["11"].MarkerSize = 10;
            chart1.Series["11"].MarkerStyle = MarkerStyle.Circle;
            chart1.Series["11"].Color = Color.Black;
            int i = 0;
            int j = 0;
            for (d = 0.01; d < 6; d = d + 0.1)
            {

                for (sigma = 0; sigma < 3; sigma = sigma + 0.1)
                {
                    chart1.Series["11"].Points.AddXY(P1[i], P2[j]);
                    j++;
                }
                i++;
            }

        }

        private void Draw_unstableCircle(double gamma, double d, double sigma, double x0, double y0, double h, double tfinal, double eps_gran, string s)
        {
            bool flag = false;
            double epsilon = 0.00001;

            double t_temp = 0;
            h = -h;
            double func = 100;

            TMyRK task = new TMyRK(gamma, d, sigma, 1);
            Matrix<double> XY0 = Matrix<double>.Build.Dense(2, 1);
            XY0[0, 0] = x0;
            XY0[1, 0] = y0;
            task.SetInit(tfinal, XY0);

            bool counter = false;
            bool counter2 = false;
            bool counter3 = false;
            int counter4 = 0;
            bool counter5 = false;
            bool counter6 = false;
            double psi_1_old = x0;
            double psi_2_old = y0;
            double psi_1_new;
            double psi_2_new;
            double min = 100;
            double min2 = 100;
            int iter = -1;
            double t_old = 0, T;
            try
            {

                //Pass the filepath and filename to the StreamWriter Constructor
                StreamWriter sw = new StreamWriter("Test2.txt");
                while (Math.Abs(0 - task.t) > eps_gran)
                {
                    iter++;

                    if (task.XY[1, 0] > 2 * Math.PI || task.XY[0, 0] > 2 * Math.PI || task.XY[0, 0] < 0 || task.XY[1, 0] < 0)
                    {
                        if (task.XY[1, 0] > 2 * Math.PI)
                        {
                            flagg = 't';
                            task.XY[1, 0] = 2 * Math.PI - task.XY[1, 0];
                        }
                        else if (task.XY[0, 0] > 2 * Math.PI)
                        {
                            flagg = 'r';
                            task.XY[0, 0] = 2 * Math.PI - task.XY[0, 0];
                        }
                        else if (task.XY[0, 0] < 0)
                        {
                            flagg = 'b';
                            task.XY[0, 0] = 2 * Math.PI + task.XY[0, 0];
                        }
                        else if (task.XY[1, 0] < 0)
                        {
                            flagg = 'l';
                            task.XY[1, 0] = 2 * Math.PI + task.XY[1, 0];
                        }
                    }

                    //else
                    //{

                    if (counter2 == true)
                    {
                        string ss = task.XY[0, 0].ToString() + " " + task.XY[1, 0].ToString();
                        //string ss2 = task.XY[1, 0].ToString();
                        sw.WriteLine(ss.Replace(",", "."));
                        if (r == 0)

                        {
                            chart1.Series[s].Points.AddXY(task.XY[0, 0], task.XY[1, 0]);
                        }
                        else
                        if (r == 1)
                        {
                            chart1.Series[s].Points.AddXY(task.t, task.XY[0, 0]);
                        }
                        else
                        if (r == 2)
                        {
                            chart1.Series[s].Points.AddXY(task.t, task.XY[1, 0]);
                        }
                    }
                    while ((task.t + h) < 0)
                    {
                        flag = true;
                        h = h / 2;
                    }
                    task.NextStep(h);
                    psi_1_new = task.XY[0, 0];
                    psi_2_new = task.XY[1, 0];
                    func = psi_2_new - 1;
                    if (counter5 == false && ((counter4 == 1 && func < 0) || (counter4 == -1 && func > 0)))
                    {
                        counter5 = true;
                    }
                    if (counter6 == false && counter5 == true && ((counter4 == 1 && func > 0) || (counter4 == -1 && func < 0)))
                    {
                        counter6 = true;
                    }
                    if (counter2 == true && counter3 == false && Math.Abs(func) < 0.0001 && Math.Abs(psi_1_old - psi_1_new) < 0.0001)
                    {
                        counter3 = true;

                        break;
                    }
                    if (counter == true && counter2 == false & Math.Abs(func) < 0.0001 && Math.Abs(psi_1_old - psi_1_new) < 0.0001 && counter6 == true)
                    {
                        counter2 = true;
                        psi_1_old = psi_1_new;
                        psi_2_old = psi_2_new;
                        textBox1.Text = "есть";



                    }
                    if (Math.Abs(func) < 0.0001)
                    {
                        psi_1_old = task.XY[0, 0];
                        psi_2_old = task.XY[1, 0];
                    }

                    if (Math.Abs(func) < 0.0001 && counter == false)
                    {
                        counter = true;
                        psi_1_old = task.XY[0, 0];
                        psi_2_old = task.XY[1, 0];
                        if (func > 0)
                        {
                            counter4 = 1;
                        }
                        else
                        if (func < 0)
                        {
                            counter4 = -1;
                        }

                    }
                    double pp = psi_2_new;
                    min2 = Math.Abs(Math.Min(Math.Abs(psi_1_old - psi_1_new), min2));
                    min = Math.Abs(Math.Min(Math.Abs(func), min));
                }
                sw.Close();

            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }
            finally
            {
                Console.WriteLine("Executing finally block.");
            }
            if (counter2 == false)
            {
                textBox1.Text = "не найден";
            }
            //if (task.XY[1, 0] > 2*Math.PI || task.XY[0, 0] > 2*Math.PI || task.XY[0, 0] < 0 || task.XY[1, 0] < 0)
            //    break;


            //}


            //}


        }

        private void button4_Click(object sender, EventArgs e)
        {
            double gamma = Convert.ToDouble(textBox_gamma.Text.ToString());

            double d = Convert.ToDouble(textBox_d.Text.ToString());
            double sigma = Convert.ToDouble(textBox_sigma.Text.ToString());

            chart1.Series.Add(10005.ToString());
            chart1.Series[10005.ToString()].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.FastPoint;
            chart1.Series[10005.ToString()].MarkerSize = 4;
            chart1.Series[10005.ToString()].Color = Color.LightGray;
            chart1.Series[10005.ToString()].MarkerStyle = MarkerStyle.Square;
            chart1.Legends.Add(10005.ToString());
            string s = "-";
            chart1.Series[10005.ToString()].LegendText = s;
            double p = Math.Asin(gamma - d);
            for (double i = 0; i < 2 * Math.PI; i = i + 0.01)
            {
                if (Math.PI / 2 - sigma > 0)
                {
                    for (double j = Math.PI / 2 - sigma; j < Math.PI / 2 + sigma; j = j + 0.01)
                    {
                        chart1.Series[10005.ToString()].Points.AddXY(i, j);
                    }
                }
                else
                {
                    for (double j = 0; j < Math.PI / 2 + sigma; j = j + 0.01)
                    {
                        chart1.Series[10005.ToString()].Points.AddXY(i, j);
                    }
                    for (double j = 2 * Math.PI - sigma + Math.PI / 2; j < 2*Math.PI; j = j + 0.01)
                    {
                        chart1.Series[10005.ToString()].Points.AddXY(i, j);
                    }
                }
            }
            if (d <= 2.01 && d >= 0.01)
            {
                chart1.Series.Add(10001.ToString());
                chart1.Series[10001.ToString()].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.FastPoint;
                chart1.Series[10001.ToString()].MarkerSize = 2;
                chart1.Series[10001.ToString()].Color = Color.Black;
                chart1.Legends.Add(10001.ToString());
                s = "-";
                chart1.Series[10001.ToString()].LegendText = s;

                chart1.Series.Add(10002.ToString());
                chart1.Series[10002.ToString()].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.FastPoint;
                chart1.Series[10002.ToString()].MarkerSize = 2;
                chart1.Series[10002.ToString()].Color = Color.Black;
                

                for (double i = 0; i < 2 * Math.PI; i = i + 0.01)
                {
                    if (i > Math.PI / 2 + sigma || i < Math.PI / 2 - sigma)
                    {
                        chart1.Series[10001.ToString()].Points.AddXY(p, i);
                        chart1.Series[10002.ToString()].Points.AddXY(Math.PI - p, i);
                    }
                }
                chart1.Legends.Add(10002.ToString());
                s = "-";
                chart1.Series[10002.ToString()].LegendText = s;
            }

            chart1.ChartAreas[0].AxisX.Maximum = 2 * Math.PI;
            chart1.ChartAreas[0].AxisX.Interval = 1;
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            
        }

        private void DrawMapping(double gamma, double d, double sigma, double x0, double y0, double h, double tfinal, double eps_gran, string s)
        {
            bool flag = false;
            double epsilon = 0.00001;

            double t_temp = 0;
            double h0 = h;


            TMyRK task = new TMyRK(gamma, d, sigma, 1);
            Matrix<double> XY0 = Matrix<double>.Build.Dense(2, 1);
            XY0[0, 0] = x0;
            XY0[1, 0] = y0;
            task.SetInit(0, XY0);
            int cc = 0;
            double temp_x = x0;
            //for (int i = 0; i < 5; i++)
            //{
            count++;
            try
            {

                //Pass the filepath and filename to the StreamWriter Constructor
                string sss = "Line_" + count.ToString() + ".txt";
                StreamWriter sw = new StreamWriter(sss);
                while ((tfinal - task.t) > eps_gran)
                {

                    if (task.XY[1, 0] > 2 * Math.PI || task.XY[0, 0] > 2 * Math.PI || task.XY[0, 0] < 0 || task.XY[1, 0] < 0)
                    {
                        if (task.XY[1, 0] > 2 * Math.PI)
                        {
                            flagg = 't';
                            task.XY[1, 0] = 0;
                        }
                        else if (task.XY[0, 0] > 2 * Math.PI)
                        {
                            flagg = 'r';
                            task.XY[0, 0] = 0;
                        }
                        else if (task.XY[0, 0] < 0)
                        {
                            flagg = 'b';
                            task.XY[0, 0] = 2 * Math.PI;
                        }
                        else if (task.XY[1, 0] < 0)
                        {
                            flagg = 'l';
                            task.XY[1, 0] = 2 * Math.PI;
                        }
                    }
                    //else
                    //{
                    
                    while ((task.t + h) > tfinal)
                    {
                        flag = true;
                        h = h / 2;
                    }
                    string ss = task.XY[0, 0].ToString() + " " + task.XY[1, 0].ToString();
                    //string ss2 = task.XY[1, 0].ToString();
                    sw.WriteLine(ss.Replace(",", "."));
                    task.NextStep(h);
                    cc++;
                    {
                        if (r == 0)

                        {
                            chart1.Series[s].Points.AddXY(temp_x, task.XY[0, 0]);
                        }
                        else
                        if (r == 1)
                        {
                            chart1.Series[s].Points.AddXY(task.t, task.XY[0, 0]);
                        }
                        else
                        if (r == 2)
                        {
                            chart1.Series[s].Points.AddXY(task.t, task.XY[1, 0]);
                        }
                    }
                    temp_x = task.XY[0, 0];
                }
                
                sw.Close();

            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }
            finally
            {
                Console.WriteLine("Executing finally block.");
            }
            //if (task.XY[1, 0] > 2*Math.PI || task.XY[0, 0] > 2*Math.PI || task.XY[0, 0] < 0 || task.XY[1, 0] < 0)
            //    break;
           

            
            //}


            //}


        }

        private void button2_Click_2(object sender, EventArgs e)
        {
            double phi1 = Convert.ToDouble(textBox_phi1.Text.ToString());
            double phi2 = Convert.ToDouble(textBox_phi2.Text.ToString());
            double gamma = Convert.ToDouble(textBox_gamma.Text.ToString());
            double h = Convert.ToDouble(textBox_h.Text.ToString());
            double tfinal = Convert.ToDouble(textBox_tf.Text.ToString());
            double eps_gran = Convert.ToDouble(textBox_eps_gran.Text.ToString());
            double d = Convert.ToDouble(textBox_d.Text.ToString());
            double sigma = Convert.ToDouble(textBox_sigma.Text.ToString());
            r = 0;
            //chart1.Series.Add(j.ToString());
            //chart1.Series[j.ToString()].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;

            //if (Math.PI / 2 - sigma > 0)
            //{
            //    chart1.Series[j].Points.AddXY(0, Math.PI / 2 - sigma);
            //    chart1.Series[j].Points.AddXY(2*Math.PI, Math.PI / 2 - sigma);
            //}
            //j++;
            //chart1.Series.Add(j.ToString());
            //chart1.Series[j.ToString()].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.FastLine;
            //chart1.Series[j].Points.AddXY(0, Math.PI / 2 + sigma);
            //chart1.Series[j].Points.AddXY(2*Math.PI, Math.PI / 2 + sigma);
            chart1.ChartAreas[0].AxisX.Maximum = 2 * Math.PI;
            chart1.ChartAreas[0].AxisX.Interval = 1;
            chart1.Series.Add(j.ToString());
            chart1.Series[j.ToString()].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.FastPoint;
            chart1.Legends.Add(j.ToString());
            chart1.Series[j.ToString()].MarkerSize = 3;
            string s = "(" + phi1.ToString() + ";" + phi2.ToString() + ")";
            chart1.Series[j.ToString()].LegendText = s;
            DrawMapping(gamma, d, sigma, phi1, phi2, h, tfinal, eps_gran, j.ToString());
            j++;

        }

        private void addStripLine(double y1, double y2)
        {
            StripLine stripLine = new StripLine();
            stripLine.Interval = 0;       // Set Strip lines interval to 0 for non periodic stuff
            stripLine.StripWidth = y2 - y1;    // the width of the highlighted area
            stripLine.IntervalOffset = y1;

            stripLine.BackColor = Color.LightSlateGray;
            chart1.ChartAreas[0].AxisY.StripLines.Add(stripLine);
        }

        private void updateStripLines()
        {
            double gamma = Convert.ToDouble(textBox_gamma.Text.ToString());

            double d = Convert.ToDouble(textBox_d.Text.ToString());
            double sigma = Convert.ToDouble(textBox_sigma.Text.ToString());
            string s = "-";
            double p = Math.Asin(gamma + d);
            chart1.ChartAreas[0].AxisY.StripLines.Clear();

            if (checkBox1.Checked)
            {
                if (Math.PI / 2 - sigma > 0)
                {
                    addStripLine(Math.PI / 2 - sigma, Math.PI / 2 + sigma);
                }
                else
                {
                    addStripLine(0.0, Math.PI / 2 + sigma);
                    addStripLine(Math.PI * 2.5 - sigma, Math.PI * 2.0);
                }
            }
            
            if (d+gamma <= 1 && flag_isokl!=true)
            {
                flag_isokl = true;
                chart1.Series.Add(10001.ToString());
                chart1.Series[10001.ToString()].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.FastPoint;
                chart1.Series[10001.ToString()].MarkerSize = 2;
                chart1.Series[10001.ToString()].Color = Color.Black;
                chart1.Legends.Add(10001.ToString());
                s = "изокл";
                chart1.Series[10001.ToString()].LegendText = s;

                chart1.Series.Add(10002.ToString());
                chart1.Series[10002.ToString()].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.FastPoint;
                chart1.Series[10002.ToString()].MarkerSize = 2;
                chart1.Series[10002.ToString()].Color = Color.Black;


                for (double i = 0; i < 2 * Math.PI; i = i + 0.01)
                {
                    if (i > Math.PI / 2 + sigma || i < Math.PI / 2 - sigma)
                    {
                        chart1.Series[10001.ToString()].Points.AddXY(p, i);
                        chart1.Series[10002.ToString()].Points.AddXY(Math.PI - p, i);
                    }
                }
                chart1.Legends.Add(10002.ToString());
                s = "изокл";
                chart1.Series[10002.ToString()].LegendText = s;
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            updateStripLines();
        }

        private void button2_Click_3(object sender, EventArgs e)
        {
            double phi1 = Convert.ToDouble(textBox_phi1.Text.ToString());
            double phi2 = Convert.ToDouble(textBox_phi2.Text.ToString());
            double gamma = Convert.ToDouble(textBox_gamma.Text.ToString());
            double h = Convert.ToDouble(textBox_h.Text.ToString());
            double tfinal = Convert.ToDouble(textBox_tf.Text.ToString());
            double eps_gran = Convert.ToDouble(textBox_eps_gran.Text.ToString());
            double d = Convert.ToDouble(textBox_d.Text.ToString());
            double sigma = Convert.ToDouble(textBox_sigma.Text.ToString());
            chart1.ChartAreas[0].AxisY.Title = "phi_2";
            chart1.ChartAreas[0].AxisX.Title = "phi_1";
            r = 0;
            updateStripLines();
            //chart1.Series.Add(j.ToString());
            //chart1.Series[j.ToString()].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;

            //if (Math.PI / 2 - sigma > 0)
            //{
            //    chart1.Series[j].Points.AddXY(0, Math.PI / 2 - sigma);
            //    chart1.Series[j].Points.AddXY(2*Math.PI, Math.PI / 2 - sigma);
            //}
            //j++;
            //chart1.Series.Add(j.ToString());
            //chart1.Series[j.ToString()].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.FastLine;
            //chart1.Series[j].Points.AddXY(0, Math.PI / 2 + sigma);
            //chart1.Series[j].Points.AddXY(2*Math.PI, Math.PI / 2 + sigma);
            chart1.ChartAreas[0].AxisX.Maximum = 2 * Math.PI;
            chart1.ChartAreas[0].AxisX.Interval = 1;
            for (double i = 0; i<=2*Math.PI; i = i+ 2 * Math.PI)
                for (double k = 0; k <= 6.28; k = k + 2)
                {
                    chart1.Series.Add(j.ToString());
                    chart1.Series[j.ToString()].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.FastPoint;
                    chart1.Legends.Add(j.ToString());
                    chart1.Series[j.ToString()].MarkerSize = 3;
                    string s = "(" + phi1.ToString() + ";" + phi2.ToString() + ")";
                    chart1.Series[j.ToString()].LegendText = s;
                    DrawLine(gamma, d, sigma, i, k, h, tfinal, eps_gran, j.ToString());
                    DrawLine_inv(gamma, d, sigma, i, k, h, tfinal, eps_gran, j.ToString());
                    j++;
                }
            for (double k = 0; k < 2 * Math.PI; k = k +2 * Math.PI)           
                for (double i = 0; i < 2 * Math.PI; i = i + 2)
                {
                    chart1.Series.Add(j.ToString());
                    chart1.Series[j.ToString()].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.FastPoint;
                    chart1.Legends.Add(j.ToString());
                    chart1.Series[j.ToString()].MarkerSize = 3;
                    string s = "(" + phi1.ToString() + ";" + phi2.ToString() + ")";
                    chart1.Series[j.ToString()].LegendText = s;
                    DrawLine(gamma, d, sigma, i, k, h, tfinal, eps_gran, j.ToString());
                    DrawLine_inv(gamma, d, sigma, i, k, h, tfinal, eps_gran, j.ToString());
                    j++;
                }

        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            double phi1 = Convert.ToDouble(textBox_phi1.Text.ToString());
            double phi2 = Convert.ToDouble(textBox_phi2.Text.ToString());
            double gamma = Convert.ToDouble(textBox_gamma.Text.ToString());
            double h = Convert.ToDouble(textBox_h.Text.ToString());
            double tfinal = Convert.ToDouble(textBox_tf.Text.ToString());
            double eps_gran = Convert.ToDouble(textBox_eps_gran.Text.ToString());
            double d = Convert.ToDouble(textBox_d.Text.ToString());
            double sigma = Convert.ToDouble(textBox_sigma.Text.ToString());
            chart1.ChartAreas[0].AxisY.Title = "sigma";
            chart1.ChartAreas[0].AxisX.Title = "d";
            chart1.ChartAreas[0].AxisX.Maximum = 6;
            chart1.ChartAreas[0].AxisX.Interval = 1;
            chart1.ChartAreas[0].AxisY.Maximum = Math.PI;
            chart1.ChartAreas[0].AxisY.Interval = 0.5;
            chart1.Series.Add("lll");
            chart1.Series["lll"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.FastPoint;
            chart1.Series["lll"].MarkerSize = 3;
            chart1.Series["lll"].MarkerStyle = MarkerStyle.Circle;
            chart1.Series["lll"].Color = Color.Black;
            int i = 0;
            int j = 0;
            for (d = 0.01; d < 6; d = d + 0.03)//состояния равновесия лежат вне полосы
            {

                for (sigma = 0; sigma < Math.PI; sigma = sigma + 0.03)
                {
                    if (d <= 1 - gamma && (((Math.PI / 2 - sigma > 0 && (Math.Asin(gamma) >= Math.PI / 2 + sigma || Math.Asin(gamma) <= Math.PI / 2 - sigma)))
                         || ((Math.PI / 2 - sigma < 0 && Math.Asin(gamma) <= 5 * Math.PI / 2 - sigma && Math.Asin(gamma) >= Math.PI / 2 + sigma))))
                    {
                        chart1.Series["lll"].Points.AddXY(d, sigma);
                    }
                    j++;

                }
                i++;
            }
            chart1.Legends.Add("lll");
            string s = "ср вне полосы";
            chart1.Series["lll"].LegendText = s;
            chart1.Series.Add("mmm");//состояния равновесия лежат в полосе
            chart1.Series["mmm"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.FastPoint;
            chart1.Series["mmm"].MarkerSize = 3;
            chart1.Series["mmm"].MarkerStyle = MarkerStyle.Cross;
            chart1.Series["mmm"].Color = Color.Red;
            chart1.Legends.Add("mmm");
            s = "ср в полосе";
            chart1.Series["mmm"].LegendText = s;
            for (d = 0.02; d < 6; d = d + 0.03)
            {

                for (sigma = 0.02; sigma < Math.PI; sigma = sigma + 0.03)
                {
                    if (gamma <= 1 && ((Math.PI / 2 - sigma > 0 && (Math.Asin(gamma) >= Math.PI / 2 - sigma && Math.Asin(gamma) <= Math.PI / 2 + sigma))
                         || (Math.PI / 2 - sigma < 0 && (Math.Asin(gamma) >= 5 * Math.PI / 2 - sigma || Math.Asin(gamma) <= Math.PI / 2 + sigma))))

                    {
                        chart1.Series["mmm"].Points.AddXY(d, sigma);
                    }
                    j++;

                }
                i++;
            }
            //chart1.Series.Add("000");
            //chart1.Series["000"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.FastPoint;
            //chart1.Series["000"].MarkerSize = 3;
            //chart1.Series["000"].MarkerStyle = MarkerStyle.Diamond;
            //chart1.Series["000"].Color = Color.Blue;
            //for (d = 0.03; d < 6; d = d + 0.03)
            //{

            //    for (sigma = 0.03; sigma < Math.PI; sigma = sigma + 0.03)
            //    {
            //        if (gamma + d <= 1 && ((Math.PI / 2 - sigma > 0 && (Math.Asin(gamma + d) >= Math.PI / 2 - sigma && Math.Asin(gamma) <= Math.PI / 2 + sigma))
            //             || (Math.PI / 2 - sigma < 0 && (Math.Asin(gamma + d) >= 5 * Math.PI / 2 - sigma || Math.Asin(gamma) <= Math.PI / 2 + sigma))))
            //        {
            //            chart1.Series["000"].Points.AddXY(d, sigma);
            //        }
            //        j++;

            //    }
            //    i++;
            //}
            //for (d = 0.01; d < 6; d = d + 0.1)
            //{

            //    for (sigma = 0; sigma < 2.4; sigma = sigma + 0.1)
            //    {
            //        chart1.Series["11"].Points.AddXY(P1[i], P2[j]);
            //        j++;
            //    }
            //    i++;
            //}

            //for (d = 2.01; d < 6; d = d + 0.5)
            //{

            //    for (sigma = 0; sigma < 2.5; sigma = sigma + 0.5)
            //    {
            //        if (k[i,j]-2==1)
            //        {
            //            chart1.Series["11"].Color = Color.Red;
            //            chart1.Series["11"].Points.AddXY(P1[i], P2[j]);
            //        }
            //        if (k[i, j] - 2 == 2)
            //        {
            //            chart1.Series["11"].Color = Color.Blue;
            //            chart1.Series["11"].Points.AddXY(P1[i], P2[j]);
            //        }

            //        j++;
            //    }
            //    i++;
            //}
        }
    }
}
