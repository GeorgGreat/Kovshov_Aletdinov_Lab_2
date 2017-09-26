namespace Graphics_task2
{
    partial class Form1
    {
        /// <summary>
        /// Требуется переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Обязательный метод для поддержки конструктора - не изменяйте
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
			System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea9 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
			System.Windows.Forms.DataVisualization.Charting.Legend legend9 = new System.Windows.Forms.DataVisualization.Charting.Legend();
			System.Windows.Forms.DataVisualization.Charting.Series series25 = new System.Windows.Forms.DataVisualization.Charting.Series();
			System.Windows.Forms.DataVisualization.Charting.Series series26 = new System.Windows.Forms.DataVisualization.Charting.Series();
			System.Windows.Forms.DataVisualization.Charting.Series series27 = new System.Windows.Forms.DataVisualization.Charting.Series();
			this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
			this.paintWind = new System.Windows.Forms.PictureBox();
			this.button1 = new System.Windows.Forms.Button();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.checkBoxBlue = new System.Windows.Forms.CheckBox();
			this.checkBoxGreen = new System.Windows.Forms.CheckBox();
			this.checkBoxRed = new System.Windows.Forms.CheckBox();
			this.button2 = new System.Windows.Forms.Button();
			this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
			this.button3 = new System.Windows.Forms.Button();
			this.numericHue = new System.Windows.Forms.NumericUpDown();
			this.button4 = new System.Windows.Forms.Button();
			this.button5 = new System.Windows.Forms.Button();
			this.numericSaturation = new System.Windows.Forms.NumericUpDown();
			this.numericValue = new System.Windows.Forms.NumericUpDown();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.button6 = new System.Windows.Forms.Button();
			this.button7 = new System.Windows.Forms.Button();
			this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
			((System.ComponentModel.ISupportInitialize)(this.paintWind)).BeginInit();
			this.groupBox1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.numericHue)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.numericSaturation)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.numericValue)).BeginInit();
			this.SuspendLayout();
			// 
			// openFileDialog1
			// 
			this.openFileDialog1.FileName = "openFileDialog1";
			this.openFileDialog1.FileOk += new System.ComponentModel.CancelEventHandler(this.openFileDialog1_FileOk);
			// 
			// paintWind
			// 
			this.paintWind.Location = new System.Drawing.Point(12, 55);
			this.paintWind.Name = "paintWind";
			this.paintWind.Size = new System.Drawing.Size(768, 514);
			this.paintWind.TabIndex = 0;
			this.paintWind.TabStop = false;
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(12, 6);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(75, 43);
			this.button1.TabIndex = 1;
			this.button1.Text = "LOAD";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.checkBoxBlue);
			this.groupBox1.Controls.Add(this.checkBoxGreen);
			this.groupBox1.Controls.Add(this.checkBoxRed);
			this.groupBox1.Location = new System.Drawing.Point(93, 1);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(124, 48);
			this.groupBox1.TabIndex = 2;
			this.groupBox1.TabStop = false;
			this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
			// 
			// checkBoxBlue
			// 
			this.checkBoxBlue.AutoSize = true;
			this.checkBoxBlue.Checked = true;
			this.checkBoxBlue.CheckState = System.Windows.Forms.CheckState.Checked;
			this.checkBoxBlue.Location = new System.Drawing.Point(86, 19);
			this.checkBoxBlue.Name = "checkBoxBlue";
			this.checkBoxBlue.Size = new System.Drawing.Size(33, 17);
			this.checkBoxBlue.TabIndex = 2;
			this.checkBoxBlue.Text = "B";
			this.checkBoxBlue.UseVisualStyleBackColor = true;
			this.checkBoxBlue.CheckedChanged += new System.EventHandler(this.checkBoxBlue_CheckedChanged);
			// 
			// checkBoxGreen
			// 
			this.checkBoxGreen.AutoSize = true;
			this.checkBoxGreen.Checked = true;
			this.checkBoxGreen.CheckState = System.Windows.Forms.CheckState.Checked;
			this.checkBoxGreen.Location = new System.Drawing.Point(46, 19);
			this.checkBoxGreen.Name = "checkBoxGreen";
			this.checkBoxGreen.Size = new System.Drawing.Size(34, 17);
			this.checkBoxGreen.TabIndex = 1;
			this.checkBoxGreen.Text = "G";
			this.checkBoxGreen.UseVisualStyleBackColor = true;
			this.checkBoxGreen.CheckedChanged += new System.EventHandler(this.checkBoxGreen_CheckedChanged);
			// 
			// checkBoxRed
			// 
			this.checkBoxRed.AutoSize = true;
			this.checkBoxRed.Checked = true;
			this.checkBoxRed.CheckState = System.Windows.Forms.CheckState.Checked;
			this.checkBoxRed.Location = new System.Drawing.Point(6, 19);
			this.checkBoxRed.Name = "checkBoxRed";
			this.checkBoxRed.Size = new System.Drawing.Size(34, 17);
			this.checkBoxRed.TabIndex = 0;
			this.checkBoxRed.Text = "R";
			this.checkBoxRed.UseVisualStyleBackColor = true;
			this.checkBoxRed.CheckedChanged += new System.EventHandler(this.checkBoxRed_CheckedChanged);
			// 
			// button2
			// 
			this.button2.Location = new System.Drawing.Point(223, 6);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(75, 43);
			this.button2.TabIndex = 3;
			this.button2.Text = "Histogram";
			this.button2.UseVisualStyleBackColor = true;
			this.button2.Click += new System.EventHandler(this.button2_Click);
			// 
			// chart1
			// 
			chartArea9.Name = "ChartArea1";
			this.chart1.ChartAreas.Add(chartArea9);
			legend9.Name = "Legend1";
			this.chart1.Legends.Add(legend9);
			this.chart1.Location = new System.Drawing.Point(12, 55);
			this.chart1.Name = "chart1";
			this.chart1.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.None;
			series25.ChartArea = "ChartArea1";
			series25.Legend = "Legend1";
			series25.Name = "Blue";
			series26.ChartArea = "ChartArea1";
			series26.Color = System.Drawing.Color.Red;
			series26.Legend = "Legend1";
			series26.Name = "Red";
			series27.ChartArea = "ChartArea1";
			series27.Color = System.Drawing.Color.Green;
			series27.Legend = "Legend1";
			series27.Name = "Green";
			this.chart1.Series.Add(series25);
			this.chart1.Series.Add(series26);
			this.chart1.Series.Add(series27);
			this.chart1.Size = new System.Drawing.Size(768, 514);
			this.chart1.TabIndex = 4;
			this.chart1.Text = "chart1";
			this.chart1.Visible = false;
			this.chart1.DragOver += new System.Windows.Forms.DragEventHandler(this.chart1_DragOver);
			// 
			// button3
			// 
			this.button3.Location = new System.Drawing.Point(304, 6);
			this.button3.Name = "button3";
			this.button3.Size = new System.Drawing.Size(78, 43);
			this.button3.TabIndex = 5;
			this.button3.Text = "Hide";
			this.button3.UseVisualStyleBackColor = true;
			this.button3.Click += new System.EventHandler(this.button3_Click);
			// 
			// numericHue
			// 
			this.numericHue.Location = new System.Drawing.Point(388, 29);
			this.numericHue.Maximum = new decimal(new int[] {
            360,
            0,
            0,
            0});
			this.numericHue.Minimum = new decimal(new int[] {
            360,
            0,
            0,
            -2147483648});
			this.numericHue.Name = "numericHue";
			this.numericHue.Size = new System.Drawing.Size(53, 20);
			this.numericHue.TabIndex = 6;
			// 
			// button4
			// 
			this.button4.Location = new System.Drawing.Point(571, 6);
			this.button4.Name = "button4";
			this.button4.Size = new System.Drawing.Size(75, 43);
			this.button4.TabIndex = 7;
			this.button4.Text = "HSV";
			this.button4.UseVisualStyleBackColor = true;
			this.button4.Visible = false;
			this.button4.Click += new System.EventHandler(this.button4_Click);
			// 
			// button5
			// 
			this.button5.Location = new System.Drawing.Point(636, 6);
			this.button5.Name = "button5";
			this.button5.Size = new System.Drawing.Size(60, 43);
			this.button5.TabIndex = 8;
			this.button5.Text = "Refresh";
			this.button5.UseVisualStyleBackColor = true;
			this.button5.Click += new System.EventHandler(this.button5_Click);
			// 
			// numericSaturation
			// 
			this.numericSaturation.Location = new System.Drawing.Point(447, 29);
			this.numericSaturation.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
			this.numericSaturation.Name = "numericSaturation";
			this.numericSaturation.Size = new System.Drawing.Size(53, 20);
			this.numericSaturation.TabIndex = 9;
			// 
			// numericValue
			// 
			this.numericValue.Location = new System.Drawing.Point(506, 29);
			this.numericValue.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
			this.numericValue.Name = "numericValue";
			this.numericValue.Size = new System.Drawing.Size(53, 20);
			this.numericValue.TabIndex = 10;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(397, 13);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(27, 13);
			this.label1.TabIndex = 11;
			this.label1.Text = "Hue";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(445, 13);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(55, 13);
			this.label2.TabIndex = 11;
			this.label2.Text = "Saturation";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(514, 13);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(34, 13);
			this.label3.TabIndex = 11;
			this.label3.Text = "Value";
			// 
			// button6
			// 
			this.button6.Location = new System.Drawing.Point(571, 6);
			this.button6.Name = "button6";
			this.button6.Size = new System.Drawing.Size(59, 43);
			this.button6.TabIndex = 12;
			this.button6.Text = "Reset";
			this.button6.UseVisualStyleBackColor = true;
			this.button6.Click += new System.EventHandler(this.button6_Click);
			// 
			// button7
			// 
			this.button7.Location = new System.Drawing.Point(700, 6);
			this.button7.Name = "button7";
			this.button7.Size = new System.Drawing.Size(75, 43);
			this.button7.TabIndex = 13;
			this.button7.Text = "SAVE";
			this.button7.UseVisualStyleBackColor = true;
			this.button7.Click += new System.EventHandler(this.button7_Click);
			// 
			// saveFileDialog1
			// 
			this.saveFileDialog1.FileOk += new System.ComponentModel.CancelEventHandler(this.saveFileDialog1_FileOk);
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(787, 581);
			this.Controls.Add(this.button7);
			this.Controls.Add(this.button6);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.numericValue);
			this.Controls.Add(this.numericSaturation);
			this.Controls.Add(this.button5);
			this.Controls.Add(this.button4);
			this.Controls.Add(this.numericHue);
			this.Controls.Add(this.button3);
			this.Controls.Add(this.chart1);
			this.Controls.Add(this.button2);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.paintWind);
			this.Name = "Form1";
			this.Text = "RGB Shower";
			this.Load += new System.EventHandler(this.Form1_Load);
			((System.ComponentModel.ISupportInitialize)(this.paintWind)).EndInit();
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.numericHue)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.numericSaturation)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.numericValue)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.PictureBox paintWind;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox checkBoxBlue;
        private System.Windows.Forms.CheckBox checkBoxGreen;
        private System.Windows.Forms.CheckBox checkBoxRed;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.NumericUpDown numericHue;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.NumericUpDown numericSaturation;
        private System.Windows.Forms.NumericUpDown numericValue;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Button button6;
		private System.Windows.Forms.Button button7;
		private System.Windows.Forms.SaveFileDialog saveFileDialog1;
	}
}

