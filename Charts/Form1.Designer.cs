namespace LabWork1
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.textBox_gamma = new System.Windows.Forms.TextBox();
            this.label_gamma = new System.Windows.Forms.Label();
            this.textBox_d = new System.Windows.Forms.TextBox();
            this.label_d = new System.Windows.Forms.Label();
            this.textBox_tf = new System.Windows.Forms.TextBox();
            this.label_h = new System.Windows.Forms.Label();
            this.label_tf = new System.Windows.Forms.Label();
            this.button_clear_gr = new System.Windows.Forms.Button();
            this.textBox_h = new System.Windows.Forms.TextBox();
            this.textBox_eps_gran = new System.Windows.Forms.TextBox();
            this.label_eps_gr = new System.Windows.Forms.Label();
            this.button_x = new System.Windows.Forms.Button();
            this.button_y = new System.Windows.Forms.Button();
            this.textBox_sigma = new System.Windows.Forms.TextBox();
            this.label_sigma = new System.Windows.Forms.Label();
            this.textBox_phi1 = new System.Windows.Forms.TextBox();
            this.textBox_phi2 = new System.Windows.Forms.TextBox();
            this.button_traj = new System.Windows.Forms.Button();
            this.label_phi1 = new System.Windows.Forms.Label();
            this.label_phi2 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button3 = new System.Windows.Forms.Button();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.button2 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.SuspendLayout();
            // 
            // chart1
            // 
            this.chart1.BackColor = System.Drawing.Color.WhiteSmoke;
            chartArea2.AxisX.IntervalOffsetType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Number;
            chartArea2.AxisX.IntervalType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Number;
            chartArea2.Name = "ChartArea1";
            chartArea2.Position.Auto = false;
            chartArea2.Position.Height = 100F;
            chartArea2.Position.Width = 90F;
            this.chart1.ChartAreas.Add(chartArea2);
            legend2.HeaderSeparator = System.Windows.Forms.DataVisualization.Charting.LegendSeparatorStyle.Line;
            legend2.ItemColumnSpacing = 20;
            legend2.MaximumAutoSize = 20F;
            legend2.Name = "Legend1";
            this.chart1.Legends.Add(legend2);
            this.chart1.Location = new System.Drawing.Point(169, 5);
            this.chart1.Name = "chart1";
            this.chart1.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.None;
            this.chart1.PaletteCustomColors = new System.Drawing.Color[] {
        System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(64))))),
        System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0))))),
        System.Drawing.Color.Violet,
        System.Drawing.Color.Red,
        System.Drawing.Color.Blue};
            this.chart1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.chart1.Size = new System.Drawing.Size(1070, 710);
            this.chart1.TabIndex = 0;
            this.chart1.Text = "График решения";
            // 
            // textBox_gamma
            // 
            this.textBox_gamma.Location = new System.Drawing.Point(84, 26);
            this.textBox_gamma.Name = "textBox_gamma";
            this.textBox_gamma.Size = new System.Drawing.Size(67, 20);
            this.textBox_gamma.TabIndex = 1;
            this.textBox_gamma.Text = "1,01";
            // 
            // label_gamma
            // 
            this.label_gamma.AutoSize = true;
            this.label_gamma.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_gamma.Location = new System.Drawing.Point(-3, 26);
            this.label_gamma.Name = "label_gamma";
            this.label_gamma.Size = new System.Drawing.Size(82, 20);
            this.label_gamma.TabIndex = 3;
            this.label_gamma.Text = "gamma =";
            // 
            // textBox_d
            // 
            this.textBox_d.Location = new System.Drawing.Point(84, 52);
            this.textBox_d.Name = "textBox_d";
            this.textBox_d.Size = new System.Drawing.Size(67, 20);
            this.textBox_d.TabIndex = 6;
            this.textBox_d.Text = "1";
            // 
            // label_d
            // 
            this.label_d.AutoSize = true;
            this.label_d.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_d.Location = new System.Drawing.Point(46, 52);
            this.label_d.Name = "label_d";
            this.label_d.Size = new System.Drawing.Size(32, 18);
            this.label_d.TabIndex = 7;
            this.label_d.Text = "d =";
            // 
            // textBox_tf
            // 
            this.textBox_tf.Location = new System.Drawing.Point(84, 104);
            this.textBox_tf.Name = "textBox_tf";
            this.textBox_tf.Size = new System.Drawing.Size(67, 20);
            this.textBox_tf.TabIndex = 11;
            this.textBox_tf.Text = "500";
            this.textBox_tf.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_tf_KeyPress);
            // 
            // label_h
            // 
            this.label_h.AutoSize = true;
            this.label_h.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_h.Location = new System.Drawing.Point(34, 226);
            this.label_h.Name = "label_h";
            this.label_h.Size = new System.Drawing.Size(44, 20);
            this.label_h.TabIndex = 13;
            this.label_h.Text = "h0 =";
            // 
            // label_tf
            // 
            this.label_tf.AutoSize = true;
            this.label_tf.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_tf.Location = new System.Drawing.Point(43, 104);
            this.label_tf.Name = "label_tf";
            this.label_tf.Size = new System.Drawing.Size(36, 20);
            this.label_tf.TabIndex = 14;
            this.label_tf.Text = "tf =";
            // 
            // button_clear_gr
            // 
            this.button_clear_gr.BackColor = System.Drawing.Color.White;
            this.button_clear_gr.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_clear_gr.Location = new System.Drawing.Point(16, 677);
            this.button_clear_gr.Name = "button_clear_gr";
            this.button_clear_gr.Size = new System.Drawing.Size(134, 46);
            this.button_clear_gr.TabIndex = 19;
            this.button_clear_gr.Text = "Очистить график";
            this.button_clear_gr.UseVisualStyleBackColor = false;
            this.button_clear_gr.Click += new System.EventHandler(this.button_clear_gr_Click);
            // 
            // textBox_h
            // 
            this.textBox_h.Location = new System.Drawing.Point(84, 226);
            this.textBox_h.Name = "textBox_h";
            this.textBox_h.Size = new System.Drawing.Size(67, 20);
            this.textBox_h.TabIndex = 10;
            this.textBox_h.Text = "0,01";
            this.textBox_h.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_h_KeyPress);
            // 
            // textBox_eps_gran
            // 
            this.textBox_eps_gran.Location = new System.Drawing.Point(84, 200);
            this.textBox_eps_gran.Name = "textBox_eps_gran";
            this.textBox_eps_gran.Size = new System.Drawing.Size(67, 20);
            this.textBox_eps_gran.TabIndex = 29;
            this.textBox_eps_gran.Text = "0,001";
            this.textBox_eps_gran.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_eps_gran_KeyPress);
            // 
            // label_eps_gr
            // 
            this.label_eps_gr.AutoSize = true;
            this.label_eps_gr.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_eps_gr.Location = new System.Drawing.Point(28, 200);
            this.label_eps_gr.Name = "label_eps_gr";
            this.label_eps_gr.Size = new System.Drawing.Size(51, 20);
            this.label_eps_gr.TabIndex = 30;
            this.label_eps_gr.Text = "εгр =";
            // 
            // button_x
            // 
            this.button_x.BackColor = System.Drawing.Color.White;
            this.button_x.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_x.Location = new System.Drawing.Point(15, 521);
            this.button_x.Name = "button_x";
            this.button_x.Size = new System.Drawing.Size(134, 44);
            this.button_x.TabIndex = 44;
            this.button_x.Text = "Построить phi1(t)";
            this.button_x.UseVisualStyleBackColor = false;
            this.button_x.Click += new System.EventHandler(this.button_x_Click);
            // 
            // button_y
            // 
            this.button_y.BackColor = System.Drawing.Color.White;
            this.button_y.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_y.Location = new System.Drawing.Point(15, 571);
            this.button_y.Name = "button_y";
            this.button_y.Size = new System.Drawing.Size(134, 44);
            this.button_y.TabIndex = 44;
            this.button_y.Text = "Построить phi2(t)";
            this.button_y.UseVisualStyleBackColor = false;
            this.button_y.Click += new System.EventHandler(this.button_y_Click_1);
            // 
            // textBox_sigma
            // 
            this.textBox_sigma.Location = new System.Drawing.Point(84, 78);
            this.textBox_sigma.Name = "textBox_sigma";
            this.textBox_sigma.Size = new System.Drawing.Size(67, 20);
            this.textBox_sigma.TabIndex = 45;
            this.textBox_sigma.Text = "1";
            // 
            // label_sigma
            // 
            this.label_sigma.AutoSize = true;
            this.label_sigma.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_sigma.Location = new System.Drawing.Point(7, 78);
            this.label_sigma.Name = "label_sigma";
            this.label_sigma.Size = new System.Drawing.Size(71, 20);
            this.label_sigma.TabIndex = 46;
            this.label_sigma.Text = "sigma =";
            // 
            // textBox_phi1
            // 
            this.textBox_phi1.Location = new System.Drawing.Point(108, 130);
            this.textBox_phi1.Name = "textBox_phi1";
            this.textBox_phi1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.textBox_phi1.Size = new System.Drawing.Size(43, 20);
            this.textBox_phi1.TabIndex = 47;
            this.textBox_phi1.Text = "1";
            // 
            // textBox_phi2
            // 
            this.textBox_phi2.Location = new System.Drawing.Point(108, 156);
            this.textBox_phi2.Name = "textBox_phi2";
            this.textBox_phi2.Size = new System.Drawing.Size(43, 20);
            this.textBox_phi2.TabIndex = 48;
            this.textBox_phi2.Text = "0";
            // 
            // button_traj
            // 
            this.button_traj.BackColor = System.Drawing.Color.White;
            this.button_traj.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_traj.Location = new System.Drawing.Point(16, 416);
            this.button_traj.Name = "button_traj";
            this.button_traj.Size = new System.Drawing.Size(134, 51);
            this.button_traj.TabIndex = 49;
            this.button_traj.Text = "Построить траекторию";
            this.button_traj.UseVisualStyleBackColor = false;
            this.button_traj.Click += new System.EventHandler(this.button_traj_Click);
            // 
            // label_phi1
            // 
            this.label_phi1.AutoSize = true;
            this.label_phi1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_phi1.Location = new System.Drawing.Point(7, 128);
            this.label_phi1.Name = "label_phi1";
            this.label_phi1.Size = new System.Drawing.Size(95, 20);
            this.label_phi1.TabIndex = 50;
            this.label_phi1.Text = "phi_1(0) = ";
            // 
            // label_phi2
            // 
            this.label_phi2.AutoSize = true;
            this.label_phi2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_phi2.Location = new System.Drawing.Point(8, 156);
            this.label_phi2.Name = "label_phi2";
            this.label_phi2.Size = new System.Drawing.Size(95, 20);
            this.label_phi2.TabIndex = 51;
            this.label_phi2.Text = "phi_2(0) = ";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.White;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Location = new System.Drawing.Point(14, 473);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(135, 42);
            this.button1.TabIndex = 52;
            this.button1.Text = "Построить предельный цикл";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(76, 283);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(89, 20);
            this.textBox1.TabIndex = 54;
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.White;
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.Location = new System.Drawing.Point(16, 621);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(133, 49);
            this.button3.TabIndex = 55;
            this.button3.Text = "Поиск предельных циклов при многих параметрах";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(74, 317);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(89, 20);
            this.textBox2.TabIndex = 56;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(-3, 318);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 19);
            this.label1.TabIndex = 58;
            this.label1.Text = "T_пц =";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(-3, 282);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 19);
            this.label2.TabIndex = 59;
            this.label2.Text = "Пр. цикл";
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Checked = true;
            this.checkBox1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox1.Location = new System.Drawing.Point(16, 375);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(131, 30);
            this.checkBox1.TabIndex = 60;
            this.checkBox1.Text = "Закрасить полосу и \r\nпостроить изоклины";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(4, 346);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 61;
            this.button2.Text = "button2";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click_3);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(85, 346);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 23);
            this.button4.TabIndex = 62;
            this.button4.Text = "button4";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click_1);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(1251, 734);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label_phi2);
            this.Controls.Add(this.label_phi1);
            this.Controls.Add(this.button_traj);
            this.Controls.Add(this.textBox_phi2);
            this.Controls.Add(this.textBox_phi1);
            this.Controls.Add(this.label_sigma);
            this.Controls.Add(this.textBox_sigma);
            this.Controls.Add(this.button_y);
            this.Controls.Add(this.button_x);
            this.Controls.Add(this.label_eps_gr);
            this.Controls.Add(this.textBox_eps_gran);
            this.Controls.Add(this.button_clear_gr);
            this.Controls.Add(this.label_tf);
            this.Controls.Add(this.label_h);
            this.Controls.Add(this.textBox_tf);
            this.Controls.Add(this.textBox_h);
            this.Controls.Add(this.label_d);
            this.Controls.Add(this.textBox_d);
            this.Controls.Add(this.label_gamma);
            this.Controls.Add(this.textBox_gamma);
            this.Controls.Add(this.chart1);
            this.Name = "Form1";
            this.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Система с одной связью";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.TextBox textBox_gamma;
        private System.Windows.Forms.Label label_gamma;
        private System.Windows.Forms.TextBox textBox_d;
        private System.Windows.Forms.Label label_d;
        private System.Windows.Forms.TextBox textBox_tf;
        private System.Windows.Forms.Label label_h;
        private System.Windows.Forms.Label label_tf;
        private System.Windows.Forms.Button button_clear_gr;
        private System.Windows.Forms.TextBox textBox_h;
        private System.Windows.Forms.TextBox textBox_eps_gran;
        private System.Windows.Forms.Label label_eps_gr;
        private System.Windows.Forms.Button button_x;
        private System.Windows.Forms.Button button_y;
        private System.Windows.Forms.TextBox textBox_sigma;
        private System.Windows.Forms.Label label_sigma;
        private System.Windows.Forms.TextBox textBox_phi1;
        private System.Windows.Forms.TextBox textBox_phi2;
        private System.Windows.Forms.Button button_traj;
        private System.Windows.Forms.Label label_phi1;
        private System.Windows.Forms.Label label_phi2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button4;
    }
}

