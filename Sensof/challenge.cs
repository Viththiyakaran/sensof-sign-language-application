using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;

namespace Sensof
{
    public partial class challenge : Form
    {
        public challenge()
        {
            InitializeComponent();
        }
        string ansfromdb, ansselect;

        int[] x = new int[8];
        returnclass rc = new returnclass();
        SqlConnection con;
        SqlCommand cmd;
        int score = 0, qid, second = 0;
        public static int p = 0;
       
        private void pictureBox5_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void challenge_Load(object sender, EventArgs e)
        {
            timer1.Interval = 1000;
            timer1.Start();
            
            Random r = new Random();
            qid = r.Next(1, 8);
            x[p] = qid;
           // MessageBox.Show(qid.ToString());


            displayquestion(qid);
        }

        public void displayquestion(int q_id)
        {
            //MessageBox.Show("Supberb");
            try
            {
                con = new SqlConnection("Data Source=DESKTOP-E8GI342;Initial Catalog=sensof;Integrated Security=True;");
                con.Open();

                cmd = new SqlCommand("Select q_image,queA,queB,queC,queD,quecorrect from challenge where qid ='" + q_id + "'", con);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();

                da.Fill(ds);


                if (ds.Tables[0].Rows.Count > 0)
                {
                    MemoryStream ms = new MemoryStream((byte[])ds.Tables[0].Rows[0]["q_image"]);
                    pictureBox2.Image = new Bitmap(ms);
                    label2.Text = (string)ds.Tables[0].Rows[0]["queA"];
                    label3.Text = (string)ds.Tables[0].Rows[0]["queB"];
                    label4.Text = (string)ds.Tables[0].Rows[0]["queC"];
                    label5.Text = (string)ds.Tables[0].Rows[0]["queD"];
                    ansfromdb = (string)ds.Tables[0].Rows[0]["quecorrect"];
                }

               
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            
            }
            con.Close();
            
        }

        public void universal(string ansselect)
        {

            if (p == 6)
            {
                this.Hide();
                challenge_over cho = new challenge_over();
                cho.Show();

            }


            if (ansselect.Equals(ansfromdb))
            {
                MessageBox.Show(null,"Superb you can ! " ,"Info",MessageBoxButtons.OK,MessageBoxIcon.Information);
                qid++;
                displayquestion(qid);
            l1:
                Random r = new Random();
                int s = r.Next(1, 8);

                bool c = search(x, s);

                if (c == true)
                {
                    goto l1;

                }
                else
                {
                    
                    p++;
                    bunifuGauge1.Value = p;
                    qid = s;
                    x[p] = qid;
                    displayquestion(qid);
                }
            }
            else
            {
                //MessageBox.Show("Challenge Over");
                this.Hide();
                challenge_over cho = new challenge_over();
                cho.Show();
                
               


            }

        }

        public static bool search(int[] x, int s)
        {
            bool c = false;
            for (int i = 0; i < x.Length; i++)
            {

                if (s == x[i])
                {
                    c = true;
                    break;
                }
            }

            return c;
        }

        private void label2_Click(object sender, EventArgs e)
        {
            ansselect = label2.Text;
            universal(ansselect);
            second = 0;
        }

        private void label3_Click(object sender, EventArgs e)
        {
            ansselect = label3.Text;
            universal(ansselect);
            second = 0;
        }

        private void label5_Click(object sender, EventArgs e)
        {
            ansselect = label5.Text;
            universal(ansselect);
            second = 0;
        }

        private void label4_Click(object sender, EventArgs e)
        {
            ansselect = label4.Text;
            universal(ansselect);
            second = 0;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
         
            second = second + 1;
            label6.Text = second.ToString();
           
            if (second >= 15)
            {
                timer1.Stop();
                //MessageBox.Show(null, "Alert", "Time", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Hide();
                challenge_over cho = new challenge_over();
                cho.Show();
            }
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
