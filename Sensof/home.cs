using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
namespace Sensof
{
    public partial class home : Form
    {
        public home()
        {
            Thread th = new Thread(new ThreadStart(formRun));
            th.Start();
            Thread.Sleep(12500);
           
            InitializeComponent();
            th.Abort();
            timer1.Start();
        }

        public void formRun()
        {
            Application.Run(new Splash_screen());
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Do you exit the SENSOF", "EXIT", MessageBoxButtons.YesNoCancel,
          MessageBoxIcon.Information);

            if (dr == DialogResult.Yes)
            {
                this.Close();
            }
            else
            { 
            
            }

            
        }

        private void bunifuFlatButton2_Click(object sender, EventArgs e)
        {
            textprct text = new textprct();
            text.Show();
        }

        private void bunifuFlatButton3_Click(object sender, EventArgs e)
        {
            challenge ch = new challenge();
            ch.Show();
        }

        private void bunifuFlatButton4_Click(object sender, EventArgs e)
        {
            
        }

        private void bunifuFlatButton5_Click(object sender, EventArgs e)
        {
            Form1 pass = new Form1();
            pass.Show();
        }

        private void bunifuFlatButton6_Click(object sender, EventArgs e)
        {
            develop de = new develop();
            de.Show();
        }

        private void home_Load(object sender, EventArgs e)
        {
            
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            textprct tp = new textprct();
            tp.Show();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            textprct tp = new textprct();
            tp.Show();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            DateTime datetime = DateTime.Now;
            time_lbl.Text = datetime.ToString();
        }

        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {

        }
    }
}
