using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;


namespace GompGraphics_2_1 
{
    public partial class Form1 : Form // задание 1 - Ковшов Г.Я. Комманда: Ковшов, Алетдинов
    {
        public Form1()
        {
            InitializeComponent();
            InitComboBox1();
            CreateGraphic();
            dialogue = new TheDifferenceDialogue();
            
        }

        Graphics g,g2,g3,f;
        Bitmap bmp,bmp2,bmp3,gisto;
        String path, path2;
        byte[] rgbValues;
        int[] intensity = new int[256];
        int[] difference_intensity = new int[256];
        TheDifferenceDialogue dialogue;


        void CreateGraphic()
        {
            gisto = new Bitmap(this.pictureBox2.Width, this.pictureBox2.Height);
            f = Graphics.FromImage(gisto);

        }
		void CreateGraphic2()
		{
			bmp2 = new Bitmap(this.pictureBox3.Width, this.pictureBox3.Height);
			g2 = Graphics.FromImage(gisto);
			pictureBox3.Width = bmp.Width;
			pictureBox3.Height = bmp.Height;
			pictureBox3.Invalidate();
			bmp3 = new Bitmap(this.pictureBox4.Width, this.pictureBox4.Height);
			g3 = Graphics.FromImage(gisto);
			pictureBox4.Width = bmp.Width;
			pictureBox4.Height = bmp.Height;
			pictureBox4.Invalidate();

		}



		delegate double MathFunc(double x, double y, double z);
        MathFunc GetFunction()
        {
            switch (comboBox1.Items[comboBox1.SelectedIndex].ToString())
            {
                case "Равные Веса":
                    return (x, y, z)=> x / 3 + y / 3 + z / 3;
                case "PAL":
                    return (x, y, z) => (int)Math.Round(0.299 * x) + (int)Math.Round(0.587 * y) + (int)Math.Round(0.114 * z);
                case "HDTV":
                    return (x, y, z) => (int)Math.Round(0.2126 * x) + (int)Math.Round(0.7152 * y) + (int)Math.Round(0.0722 * z); 
                default:
                    throw new NotImplementedException();
            }
        }


        private void gistogram()
        {
            int i = 0;

            double yScale = this.hScrollBar1.Value;

            f.Clear(Color.White);
			int max = 0;

            for (int j = 0; j < intensity.Length; j++)
            {
				if (intensity[j] > max) { max = intensity[j]; }
                i = i + 1;
                f.DrawLine(Pens.Black, i, this.pictureBox2.Height - (int)Math.Round(intensity[j] / yScale), i, this.pictureBox2.Height);
            }
            pictureBox2.Refresh();
			//pictureBox2.Location = pictureBox1.Location;
			//label6.Location = new Point(pictureBox2.Location.X - 30, pictureBox2.Location.Y);
			//label3.Location = new Point(pictureBox2.Location.X - 15, pictureBox2.Height + pictureBox2.Location.Y + 60);
			//label4.Location = new Point(pictureBox2.Location.X + pictureBox2.Width + 30, pictureBox2.Height + 60);
			//label5.Location = new Point(pictureBox2.Location.X + pictureBox2.Width/2 - 25, pictureBox2.Height);

			string myString = max.ToString(); //hScrollBar1.Value.ToString();

			label6.Text = "Max =" + myString;
		}

        
        // Процесс преобразующий исходное изображение в "оттенки серого" по выбранному пользователю методу, по нажатию кнопки "Обработать изображение"
        private void process (MathFunc func)
       {


           // Lock the bitmap's bits.  
           Rectangle rect = new Rectangle(0, 0, bmp2.Width, bmp2.Height);
           System.Drawing.Imaging.BitmapData bmpData =
               bmp.LockBits(rect, System.Drawing.Imaging.ImageLockMode.ReadWrite,
               bmp.PixelFormat);

           // Get the address of the first line.
           IntPtr ptr = bmpData.Scan0;

           // Declare an array to hold the bytes of the bitmap.
           int bytes = Math.Abs(bmpData.Stride) * bmp2.Height;
           rgbValues = new byte[bytes];

           // Copy the RGB values into the array.
           System.Runtime.InteropServices.Marshal.Copy(ptr, rgbValues, 0, bytes);

           // Set every third value to 255. A 24bpp bitmap will look red.  
           //for (int counter = 0; counter < rgbValues.Length; counter += 3)
           //{
               //rgbValues[counter+1] = 255;                                
           //}
           // Copy the RGB values back to the bitmap
          // System.Runtime.InteropServices.Marshal.Copy(rgbValues, 0, ptr, bytes);

           // Unlock the bits.
           bmp.UnlockBits(bmpData);
			
           
           int i = 0;
           for (int counter = 0; counter < rgbValues.Length; counter += 3)
           {
               int weight = (int)(func(rgbValues[counter], rgbValues[counter + 1], rgbValues[counter + 2]));
               bmp2.SetPixel(i % bmp2.Width, i / bmp2.Width,
                   Color.FromArgb(weight, weight, weight));
               i++;
               intensity[weight]++;
                //if (intensity[weight] > max) { max = intensity[weight]; }

            }
           pictureBox3.Refresh();
			pictureBox3.Location = new Point(433, 88);

			gistogram();

        }

        // Процесс обработки изображения, показывающий разницу между двумя методами
        private void theDifferenceProcess(MathFunc algol1, MathFunc algol2)
        {
            
                // Lock the bitmap's bits.  
                Rectangle rect = new Rectangle(0, 0, bmp3.Width, bmp3.Height);
                System.Drawing.Imaging.BitmapData bmpData =
                    bmp3.LockBits(rect, System.Drawing.Imaging.ImageLockMode.ReadWrite,
                    bmp3.PixelFormat);

                // Get the address of the first line.
                IntPtr ptr = bmpData.Scan0;

                // Declare an array to hold the bytes of the bitmap.
                int bytes = Math.Abs(bmpData.Stride) * bmp3.Height;
                rgbValues = new byte[bytes];

                // Copy the RGB values into the array.
                System.Runtime.InteropServices.Marshal.Copy(ptr, rgbValues, 0, bytes);

                // Set every third value to 255. A 24bpp bitmap will look red.  
                for (int counter = 0; counter < rgbValues.Length; counter += 3)
                {
                    //rgbValues[counter+1] = 255;                                
                }
                // Copy the RGB values back to the bitmap
                //System.Runtime.InteropServices.Marshal.Copy(rgbValues, 0, ptr, bytes);

                // Unlock the bits.
                bmp3.UnlockBits(bmpData);


                int i = 0;
                for (int counter = 0; counter < rgbValues.Length; counter += 3)
                {
                    int weight1 = (int)(algol1(rgbValues[counter], rgbValues[counter + 1], rgbValues[counter + 2]));
                    int weight2 = (int)(algol2(rgbValues[counter], rgbValues[counter + 1], rgbValues[counter + 2]));
                int weight = Math.Abs(weight1 - weight2);
                bmp.SetPixel(i % bmp3.Width, i / bmp3.Width,
                        Color.FromArgb(weight, weight, weight));
                    i++;
                    difference_intensity[weight]++;


                }
                pictureBox4.Refresh();
			pictureBox1.Location = new Point(433, 447);

			// gistogram();

		}

       



        private void button1_Click(object sender, EventArgs e)
        {
            if (File.Exists(path))
            {
                process(GetFunction());
				MathFunc algol1, algol2;
				algol1 = (x, y, z) => x / 3 + y / 3 + z / 3;
				algol2 = GetFunction();
				theDifferenceProcess(algol1, algol2);
                pictureBox1.Location = new Point(433, 447);

            }
            else MessageBox.Show("Нет загруженного изображения", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);


        }




        private void button2_Click(object sender, EventArgs e)
        {


            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                path = openFileDialog1.FileName;
                path2 = path;
                pictureBox1.Image = Bitmap.FromFile(path);
				pictureBox3.Image = Bitmap.FromFile(path);
				pictureBox4.Image = Bitmap.FromFile(path);
			}
                               
            g = Graphics.FromImage(pictureBox1.Image);
            bmp = pictureBox1.Image as Bitmap;
            /*pictureBox1.Width = bmp.Width;
            pictureBox1.Height = bmp.Height;*/
			//pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
			pictureBox1.Invalidate();

			g2 = Graphics.FromImage(pictureBox1.Image);
			bmp2 = pictureBox3.Image as Bitmap;
			/*pictureBox3.Width = bmp.Width;
			pictureBox3.Height = bmp.Height;*/
			pictureBox3.Invalidate();
			pictureBox3.Location = new Point(pictureBox1.Location.X, pictureBox1.Location.Y);


			g3 = Graphics.FromImage(pictureBox1.Image);
			bmp3 = pictureBox4.Image as Bitmap;
			/*pictureBox4.Width = bmp.Width;
			pictureBox4.Height = bmp.Height;*/
			pictureBox4.Invalidate();
			pictureBox4.Location = new Point(pictureBox1.Location.X, pictureBox1.Location.Y);

			gisto = new Bitmap(this.pictureBox2.Width, this.pictureBox2.Height);
            f = Graphics.FromImage(gisto);
            //pictureBox2.Location = new Point(pictureBox1.Width + pictureBox1.Location.X + 15, pictureBox2.Location.Y);
            pictureBox2.Invalidate();
			

			for (int i = 0; i < intensity.Length; i++)
            {
                intensity[i] = 0;
            }

            for (int i = 0; i < difference_intensity.Length; i++)
            {
                difference_intensity[i] = 0;

            }

        }

        private void pictureBox2_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawImage(gisto, 0, 0);
        }

        private void button4_Click(object sender, EventArgs e)
        {
        
         gistogram();
            
            

        }

		private void button5_Click(object sender, EventArgs e)
        {
            if (dialogue.ShowDialog() == DialogResult.OK)
            {
                MathFunc algol1, algol2;
                switch (dialogue.alg1)
                {
                    case Algorithm.Equal:
                        algol1 = (x, y, z) => x / 3 + y / 3 + z / 3;
                        break;
                    case Algorithm.Pal:
                        algol1 = (x, y, z) => (int)Math.Round(0.299 * x) + (int)Math.Round(0.587 * y) + (int)Math.Round(0.114 * z);
                        break;
                    case Algorithm.Hdtv:
                        algol1 = (x, y, z) => (int)Math.Round(0.2126 * x) + (int)Math.Round(0.7152 * y) + (int)Math.Round(0.0722 * z);
                        break;
                    default:
                        throw new NotImplementedException();
                }
                switch (dialogue.alg2)
                {
                    case Algorithm.Equal:
                        algol2 = (x, y, z) => x / 3 + y / 3 + z / 3;
                        break;
                    case Algorithm.Pal:
                        algol2 = (x, y, z) => (int)Math.Round(0.299 * x) + (int)Math.Round(0.587 * y) + (int)Math.Round(0.114 * z);
                        break;
                    case Algorithm.Hdtv:
                        algol2 = (x, y, z) => (int)Math.Round(0.2126 * x) + (int)Math.Round(0.7152 * y) + (int)Math.Round(0.0722 * z);
                        break;
                    default:
                        throw new NotImplementedException();
                }
                 theDifferenceProcess(algol1,algol2);
                pictureBox1.Location = new Point(433, 88);
                difference_gistogram();
            }

               
            }

		private void button6_Click(object sender, EventArgs e)
		{
			pictureBox2.Location = new Point(pictureBox1.Width + pictureBox1.Location.X + 15, pictureBox2.Location.Y);
			label6.Location = new Point(pictureBox2.Location.X - 15, pictureBox2.Location.Y);
			label3.Location = new Point(pictureBox2.Location.X - 15, pictureBox2.Height + 60);
			label4.Location = new Point(pictureBox2.Location.X + pictureBox2.Width - 15, pictureBox2.Height + 60);
			label5.Location = new Point(pictureBox2.Location.X + pictureBox2.Width / 2 - 15, pictureBox2.Height + 60);
		}

		private void button3_Click_1(object sender, EventArgs e)
        {
            if (File.Exists(path2) == true)
            {

                pictureBox1.Image = Bitmap.FromFile(path);
                g = Graphics.FromImage(pictureBox1.Image);
                bmp = pictureBox1.Image as Bitmap;
                pictureBox1.Invalidate();
                for(int i = 0; i<intensity.Length; i++)
                {
                    intensity[i] = 0;
                    
                }
                for (int i = 0; i < difference_intensity.Length; i++)
                {
                    difference_intensity[i]=0;

                }
                pictureBox1.Location = new Point(12, 88);
                pictureBox3.Location = new Point(pictureBox1.Location.X, pictureBox1.Location.Y);
                pictureBox4.Location = new Point(pictureBox1.Location.X, pictureBox1.Location.Y);

                
            }
            else MessageBox.Show("Нет загруженного изображения", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            
        }

        void InitComboBox1()
        {
            comboBox1.Items.Add("Равные Веса");
            comboBox1.Items.Add("PAL");
            comboBox1.Items.Add("HDTV");
            comboBox1.SelectedIndex = 0;
        }

    }
}
