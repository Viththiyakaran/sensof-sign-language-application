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
using System.Speech;
using System.Speech.Recognition;
using System.Text.RegularExpressions;
namespace Sensof
{
    public partial class textprct : Form
    {
        SqlConnection con;
        SqlCommand cmd;
        int a = 0;
       
        public textprct()
        {
            InitializeComponent();
        }

        private void textprct_Load(object sender, EventArgs e)
        {
            textBox1.Focus();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void pictureBox5_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void bunifuFlatButton2_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < a; i++)
            {
                foreach (Control control in this.Controls)
                {
                    PictureBox picture = control as PictureBox;
                    if (picture != null)
                    {
                        this.Controls.Remove(picture);
                    }
                }

                
            }

           
                

           
            textBox1.Clear();
            textBox1.Focus();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

            try
            {
                int x = 250, y = 100;


                con = new SqlConnection("Data Source=DESKTOP-E8GI342;Initial Catalog=sensof;Integrated Security=True;");
                con.Open();

                /*string s1 = textBox1.Text;
                string[] s2 = s1.Split(' ');
                foreach (string s3 in s2)*/



                string s1 = textBox1.Text;
                char[] ch = s1.ToCharArray();
                foreach (char c in ch)
                {


                    Console.WriteLine(c);

                    cmd = new SqlCommand("Select * from sign_letter where sign_name ='" + c + "'", con);

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataSet ds = new DataSet();

                    da.Fill(ds);


                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        MemoryStream ms = new MemoryStream((byte[])ds.Tables[0].Rows[0]["sign_image"]);
                        //pictureBox1.Image = new Bitmap(ms);

                        PictureBox pb = new PictureBox();
                        pb.Height = 120;
                        pb.Width = 100;
                        pb.Name = "picbox" + a;
                        pb.Image = new Bitmap(ms);
                        pb.Location = new Point(x, y);
                        pb.SizeMode = PictureBoxSizeMode.StretchImage;
                        Controls.Add(pb);
                        x += 100;
                        Console.WriteLine(pb.Location);
                        a += 1;

                        if (x > 1275 && y == 100)
                        {
                            x = 250;
                            y = 300;
                            pb.Height = 120;
                            pb.Width = 100;
                            pb.Name = "picbox" + a;
                            pb.Image = new Bitmap(ms);
                            pb.Location = new Point(x, y);
                            pb.SizeMode = PictureBoxSizeMode.StretchImage;
                            Controls.Add(pb);
                            x += 100;
                            Console.WriteLine(pb.Name);
                            a += 1;


                        }

                        if (x > 1275 && y == 300)
                        {
                            x = 250;
                            y = 500;
                            pb.Height = 120;
                            pb.Width = 100;
                            pb.Name = "picbox" + a;
                            pb.Image = new Bitmap(ms);
                            pb.Location = new Point(x, y);
                            pb.SizeMode = PictureBoxSizeMode.StretchImage;
                            Controls.Add(pb);
                            x += 100;
                            Console.WriteLine(pb.Name);
                            a += 1;


                        }
                        // y += 100;

                        //pb.Refresh();


                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            
            }

            con.Close();

        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsControl(e.KeyChar) || char.IsLetter(e.KeyChar))
            {
                return;
            }
            e.Handled = true;
        }

        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
            SpeechRecognitionEngine recognizer = new SpeechRecognitionEngine();
            Grammar dictationGrammar = new DictationGrammar();
            recognizer.LoadGrammar(dictationGrammar);
            try
            {
                bunifuFlatButton1.ButtonText = "Speak Now";
                recognizer.SetInputToDefaultAudioDevice();
                RecognitionResult result = recognizer.Recognize();
                textBox1.Text = result.Text;
                //bunifuFlatButton1.Text = result.Text;
               
            }
            catch (InvalidOperationException exception)
            {
                bunifuFlatButton1.Text = String.Format("Could not recognize input from default aduio device. Is a microphone or sound card available?\r\n{0} - {1}.", exception.Source, exception.Message);
            }
            finally
            {
                recognizer.UnloadAllGrammars();
            }    
        }
    }
}
