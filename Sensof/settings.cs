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
    public partial class settings : Form
    {
        SqlConnection Conn = new SqlConnection("Data Source=DESKTOP-E8GI342;Initial Catalog=sensof;Integrated Security=True;");
        string ImageLocation = "";
        SqlCommand Cmd;
   
        public settings()
        {
            InitializeComponent();
        }

        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
            
        }

        private void bunifuFlatButton3_Click(object sender, EventArgs e)
        {
           
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void bunifuGradientPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog Dialog = new OpenFileDialog();
            Dialog.Filter = "Image files (*.jpg, *.jpeg, *.jpe, *.jfif, *.png) | *.jpg; *.jpeg; *.jpe; *.jfif; *.png";
            if (Dialog.ShowDialog() == DialogResult.OK)
            {
                ImageLocation = Dialog.FileName.ToString();
                pictureBox2.ImageLocation = ImageLocation;


            }
        }

        private void bunifuFlatButton1_Click_1(object sender, EventArgs e)
        {
            try
             {

                 if (textBox1.Text == "")
                 {

                     MessageBox.Show("Please check your things ", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

                 }
                 else if (ImageLocation == null)
                 {
                     MessageBox.Show("Please check your things ", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);


                 }

                 else
                 {
                    byte[] images = null;
                    FileStream Stream = new FileStream(ImageLocation, FileMode.Open, FileAccess.Read);
                    BinaryReader Br = new BinaryReader(Stream);
                    images = Br.ReadBytes((int)Stream.Length);
                    Conn.Open();

                    string Sql = "insert into sign_letter(sign_name,sign_image) values('" + textBox1.Text + "',@images)";
                    Cmd = new SqlCommand(Sql, Conn);
                    Cmd.Parameters.Add(new SqlParameter("@images", images));
                    int N = Cmd.ExecuteNonQuery();
                    Conn.Close();  
                    MessageBox.Show("Successfuly Inserted Data", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //MessageBox.Show("Insert Image" + N.ToString());
                    textBox1.Text = "";
                    pictureBox2.Image = null;
                    datashow();
                   
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            
            }
            
           
        }

        private void settings_Load(object sender, EventArgs e)
        {
            datashow();
        }

        public void datashow()
        {
            Conn.Open();
            SqlDataAdapter da = new SqlDataAdapter("select id as ID, sign_name as SIGN_NAME, sign_image as IMAGE from sign_letter",Conn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            Conn.Close();
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsControl(e.KeyChar) || char.IsLetter(e.KeyChar))
            {
                return;
            }
            e.Handled = true;




            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (textBox2.Text == "")
            {
                MessageBox.Show("Please Check the textbox", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                textBox2.Focus();

            }
            else
            {

                Conn.Open();
                Cmd = new SqlCommand("Select * from sign_letter where sign_name ='" + textBox2.Text + "'", Conn);

                SqlDataAdapter da = new SqlDataAdapter(Cmd);
                DataSet ds = new DataSet();

                da.Fill(ds);


                if (ds.Tables[0].Rows.Count > 0)
                {
                    MemoryStream ms = new MemoryStream((byte[])ds.Tables[0].Rows[0]["sign_image"]);
                    pictureBox3.Image = new Bitmap(ms);


                }
                else
                {

                    MessageBox.Show("Sorry ! It's not here", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                
                }


                Conn.Close();

            }
        }

        private void bunifuFlatButton2_Click(object sender, EventArgs e)
        {

            if (textBox2.Text == "")
            {

                MessageBox.Show("Please check your things ", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                textBox2.Focus();
            }
            else if (ImageLocation == null)
            {
                MessageBox.Show("Please check your things ", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);


            }
            else
            {
                byte[] images = null;
                FileStream Stream = new FileStream(ImageLocation, FileMode.Open, FileAccess.Read);
                BinaryReader Br = new BinaryReader(Stream);
                images = Br.ReadBytes((int)Stream.Length);
                Conn.Open();

                string Sql = "update sign_letter set sign_image=@images where sign_name ='" + textBox2.Text + "'";
                // string Sql = "insert into sign_letter(sign_name,sign_image) values('" + textBox1.Text + "',@images)";
                Cmd = new SqlCommand(Sql, Conn);
                Cmd.Parameters.Add(new SqlParameter("@images", images));
                int N = Cmd.ExecuteNonQuery();
                Conn.Close();

                MessageBox.Show("Successfuly Updated Data", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //MessageBox.Show("Insert Image" + N.ToString());
                textBox2.Text = "";
                pictureBox3.Image = null;
                datashow();


            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OpenFileDialog Dialog = new OpenFileDialog();
            Dialog.Filter = "Image files (*.jpg, *.jpeg, *.jpe, *.jfif, *.png) | *.jpg; *.jpeg; *.jpe; *.jfif; *.png";
            if (Dialog.ShowDialog() == DialogResult.OK)
            {
                ImageLocation = Dialog.FileName.ToString();
                pictureBox3.ImageLocation = ImageLocation;


            }
        }

        private void button5_Click(object sender, EventArgs e)
        {

            if (textBox3.Text == "")
            {
                MessageBox.Show("Please Check the textbox", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                textBox3.Focus();

            }
            else
            {

                Conn.Open();
                Cmd = new SqlCommand("Select * from sign_letter where sign_name ='" + textBox3.Text + "'", Conn);

                SqlDataAdapter da = new SqlDataAdapter(Cmd);
                DataSet ds = new DataSet();

                da.Fill(ds);


                if (ds.Tables[0].Rows.Count > 0)
                {
                    MemoryStream ms = new MemoryStream((byte[])ds.Tables[0].Rows[0]["sign_image"]);
                    pictureBox4.Image = new Bitmap(ms);


                }
                else
                {

                    MessageBox.Show("It's not here", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                
                }


                Conn.Close();

            }
        }

        private void bunifuFlatButton3_Click_1(object sender, EventArgs e)
        {

            if (textBox3.Text == "")
            {

                MessageBox.Show("Please check your things ", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                textBox3.Focus();
            }
            else
            {

                Conn.Open();
                //string Sql = "update sign_letter set sign_image=@images where sign_name ='" + textBox2.Text + "'";
                string Sql = "Delete from sign_letter where sign_name = '" + textBox3.Text + "'";
                Cmd = new SqlCommand(Sql, Conn);
                int N = Cmd.ExecuteNonQuery();
                Conn.Close();
                //MessageBox.Show("Insert Image" + N.ToString());
                MessageBox.Show("Successfuly Deleted ", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

                textBox3.Text = "";
                pictureBox4.Image = null;
                datashow();
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsControl(e.KeyChar) || char.IsLetter(e.KeyChar))
            {
                return;
            }
            e.Handled = true;
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsControl(e.KeyChar) || char.IsLetter(e.KeyChar))
            {
                return;
            }
            e.Handled = true;
        }

        
    }
}
