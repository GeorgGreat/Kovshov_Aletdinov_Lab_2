using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GompGraphics_2_1
{
    public enum Algorithm { Equal, Pal, Hdtv }

    public partial class TheDifferenceDialogue : Form
    {
        public Algorithm alg1, alg2;

        public TheDifferenceDialogue()
        {
            InitializeComponent();
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true)
                alg1 = Algorithm.Hdtv;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true)
                alg1 = Algorithm.Pal;
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true)
                alg1 = Algorithm.Equal;
        }

        private void radioButton6_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true)
                alg2 = Algorithm.Hdtv;
        }

        private void radioButton5_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true)
                alg2 = Algorithm.Pal;
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true)
                alg2 = Algorithm.Equal;
        }

        

        
        
       



    }
}
