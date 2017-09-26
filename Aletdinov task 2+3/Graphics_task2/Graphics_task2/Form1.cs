using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Graphics_task2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
        }

        byte[] rgbValues;
        byte[] newrgbValues;
        float[] Hvalues;
        float[] Svalues;
        float[] Vvalues;
        int[] redValues = new int[256];
        int[] blueValues = new int[256];
        int[] greenValues = new int[256];
        Graphics g;
        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            paintWind.Image = Bitmap.FromFile(openFileDialog1.FileName);
            g = Graphics.FromImage(paintWind.Image);
            Bitmap bmp = paintWind.Image as Bitmap;

            // Lock the bitmap's bits.  
            Rectangle rect = new Rectangle(0, 0, bmp.Width, bmp.Height);
            System.Drawing.Imaging.BitmapData bmpData =
                bmp.LockBits(rect, System.Drawing.Imaging.ImageLockMode.ReadWrite,
                bmp.PixelFormat);

            // Get the address of the first line.
            IntPtr ptr = bmpData.Scan0;

            // Declare an array to hold the bytes of the bitmap.
            int bytes = Math.Abs(bmpData.Stride) * bmp.Height;
            rgbValues = new byte[bytes];

            // Copy the RGB values into the array.
            System.Runtime.InteropServices.Marshal.Copy(ptr, rgbValues, 0, bytes);

            // Set every third value to 255. A 24bpp bitmap will look red.  
            for (int counter = 0; counter < rgbValues.Length; counter += 3)
            {
                if (!checkBoxBlue.Checked)
                    rgbValues[counter] = 0; // blue
                if (!checkBoxRed.Checked)
                    rgbValues[counter + 2] = 0; //red
                if (!checkBoxGreen.Checked)
                    rgbValues[counter + 1] = 0; //green
            }

            // Copy the RGB values back to the bitmap
            System.Runtime.InteropServices.Marshal.Copy(rgbValues, 0, ptr, bytes);

            // Unlock the bits.
            bmp.UnlockBits(bmpData);

            int i = 0;
            for (int counter = 0; counter < rgbValues.Length; counter += 3)
            {
                //bmp.SetPixel(i % bmp.Width, i / bmp.Width,
                //    Color.FromArgb(rgbValues[counter], rgbValues[counter + 1], rgbValues[counter + 2]));
                i++;

            }
            paintWind.Refresh();

        }

        private void checkBoxRed_CheckedChanged(object sender, EventArgs e)
        {
            if(g != null)
                openFileDialog1_FileOk(sender, null);
        }

        
        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void checkBoxGreen_CheckedChanged(object sender, EventArgs e)
        {
            if (g != null)
                openFileDialog1_FileOk(sender, null);
        }

        private void checkBoxBlue_CheckedChanged(object sender, EventArgs e)
        {
            if (g != null)
                openFileDialog1_FileOk(sender, null);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (g != null && rgbValues!=null && 
                (checkBoxRed.Checked || checkBoxBlue.Checked || checkBoxGreen.Checked))
            {
                
                blueValues = new int[256];
                redValues = new int[256];
                greenValues = new int[256];
                    for (int counter = 0; counter < rgbValues.Length; counter += 3)
                    {

                        blueValues[rgbValues[counter]]++;
                        greenValues[rgbValues[counter + 1]]++;
                        redValues[rgbValues[counter + 2]]++;
                    }
                    chart1.ChartAreas[0].AxisX.Minimum = 0;
                    chart1.ChartAreas[0].AxisX.Maximum = 255;
                    chart1.Series["Green"].Points.Clear();
                    chart1.Series["Blue"].Points.Clear();
                    chart1.Series["Red"].Points.Clear();
                for(int i=0;i<256;i++)
                {
                    if (checkBoxRed.Checked)
                        chart1.Series["Red"].Points.AddXY(i, redValues[i]);
                    if (checkBoxBlue.Checked)
                        chart1.Series["Blue"].Points.AddXY(i, blueValues[i]);
                    if (checkBoxGreen.Checked)
                        chart1.Series["Green"].Points.AddXY(i, greenValues[i]);   
                }
				chart1.Visible = true;
            }
                
        }

        private void chart1_DragOver(object sender, DragEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            chart1.Visible = false;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (rgbValues != null)
            {
                Hvalues = new float[rgbValues.Length / 3];
                Svalues = new float[rgbValues.Length / 3];
                Vvalues = new float[rgbValues.Length / 3];
                int i = 0;
                for (int counter = 0; counter < rgbValues.Length; counter += 3)
                {
                    float R = rgbValues[counter + 2] / 255f, G = rgbValues[counter + 1] / 255f, B = rgbValues[counter] / 255f;
                    float max = Math.Max(R, Math.Max(G, B)), min = Math.Min(R, Math.Min(G, B));
                    float H, S, V;

                    if (max == min)
                        H = 0;
                    else
                    {
                        if (max == R && G >= B)
                            H = 60 * (G - B) / (max - min);
                        else
                        {
                            if (max == R && G < B)
                                H = 60 * (G - B) / (max - min) + 360;
                            else
                            {
                                if (max == G)
                                    H = 60 * (B - R) / (max - min) + 120;
                                else
                                    H = 60 * (R - G) / (max - min) + 240;
                            }
                        }
                    }

                    if (max == 0)
                        S = 0;
                    else
                        S = 1 - min / max;

                    V = max;

                    Hvalues[i] = H;
                    Svalues[i] = S;
                    Vvalues[i] = V;
                    i++;
                }
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (rgbValues != null)
            {
				button4_Click(null, null);
				newrgbValues = new byte[rgbValues.Length];
                int counter = 0;
                for (int i = 0; i < Hvalues.Length; i++)
                {
					Vvalues[i] += (float)numericValue.Value / 100;
					if (Vvalues[i] > 1)
						Vvalues[i] = 1;
					if (Vvalues[i] < 0)
						Vvalues[i] = 0;

					Hvalues[i] += (float)numericHue.Value / 60;
					if (Hvalues[i] > 360)
						Hvalues[i] = 360;
					if (Hvalues[i] < 0)
						Hvalues[i] = 0;

					Svalues[i] += (float)numericSaturation.Value / 100;
					if (Svalues[i] > 1)
						Svalues[i] = 1;
					if (Svalues[i] < 0)
						Svalues[i] = 0;

					float C = (Vvalues[i]) * (1-Svalues[i]);
					float H = (Hvalues[i] / 60);
                    float X = C * (1 - Math.Abs(H % 2 - 1));

                    float r, g, b;
                    switch ((int)Math.Floor(H))
                    {
                        case 0:
                            r = C; g = X; b = 0;
                            break;
                        case 1:
                            r = X; g = C; b = 0;
                            break;
                        case 2:
                            r = 0; g = C; b = X;
                            break;
                        case 3:
                            r = 0; g = X; b = C;
                            break;
                        case 4:
                            r = X; g = 0; b = C;
                            break;
                        case 5:
                            r = C; g = 0; b = X;
                            break;
                        default:
                            r = 0; g = 0; b = 0;
                            break;
                    }

                    float m = (Vvalues[i]) - C;
                    newrgbValues[counter] = (byte)Math.Round((b + m) * 255); // blue
                    newrgbValues[counter + 2] = (byte)Math.Round((r + m) * 255); //red
                    newrgbValues[counter + 1] = (byte)Math.Round((g + m) * 255); //green
                    counter += 3;

                }

                Bitmap bmp = paintWind.Image as Bitmap;

                // Lock the bitmap's bits.  
                Rectangle rect = new Rectangle(0, 0, bmp.Width, bmp.Height);
                System.Drawing.Imaging.BitmapData bmpData =
                    bmp.LockBits(rect, System.Drawing.Imaging.ImageLockMode.ReadWrite,
                    bmp.PixelFormat);

                // Get the address of the first line.
                IntPtr ptr = bmpData.Scan0;

                // Declare an array to hold the bytes of the bitmap.
                int bytes = Math.Abs(bmpData.Stride) * bmp.Height;

                // Copy the RGB values back to the bitmap
                System.Runtime.InteropServices.Marshal.Copy(newrgbValues, 0, ptr, bytes);

                // Unlock the bits.
                bmp.UnlockBits(bmpData);

                paintWind.Refresh();

            }
        }

		private void button6_Click(object sender, EventArgs e)
		{
			if (rgbValues != null)
			{
				numericHue.Value = 0;
				numericSaturation.Value = 0;
				numericValue.Value = 0;
				button5_Click(null, null);
			}
		}

		private void saveFileDialog1_FileOk(object sender, CancelEventArgs e)
		{
			paintWind.Image.Save(saveFileDialog1.FileName);
		}

		private void button7_Click(object sender, EventArgs e)
		{
			
		}
	}
}
