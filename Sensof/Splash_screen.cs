using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sensof
{
    public partial class Splash_screen : Form
    {

        int move = 0;
        public Splash_screen()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            panelside.Left += 2;


            if (panelside.Left > 150)
            {

                panelside.Left = 0;

            }

            if (panelside.Left < 0)
            {
                move = 2;
            }

            /*progressBar1.Increment(1);
            if (progressBar1.Value == 100)
            {
                timer1.Stop();
            }*/
        }

        private void loading_Load(object sender, EventArgs e)
        {
           
        }
    }
}
