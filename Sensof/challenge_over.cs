using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sensof
{
    public partial class challenge_over : Form
    {
        public challenge_over()
        {
            InitializeComponent();
        }

        private void challenge_over_Load(object sender, EventArgs e)
        {
            int marks;
            marks =  challenge.p;

            if (marks >= 10)
            {
                label1.Text = " WELLDONE \n\tScore : " + marks;
            }
            else if (marks >= 5)
            {

                label1.Text = " SUPERB \n\tScore : " + marks;
            }
            else
            {
                label1.Text = "KEEP TRY \n\tScore : " + marks;
            }

            
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
