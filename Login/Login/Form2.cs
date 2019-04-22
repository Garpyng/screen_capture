using System;
using System.Collections;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace Login
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        //variables globales para mover el formulario
        public int xClick = 0, yClick = 0;
        private void button1_Click(object sender, EventArgs e)
        {
            Thread t = new Thread(stream);
            t.Start();
        }
        public ArrayList collection = new ArrayList();
        Bitmap bm;
        Graphics g;
        private void capturar()
        {
           
                try
                {
                    int ancho = Screen.PrimaryScreen.WorkingArea.Width;
                    int alto = Screen.PrimaryScreen.WorkingArea.Height;
                    bm = new Bitmap(ancho, alto);
                    g = Graphics.FromImage(bm);
                    g.CopyFromScreen(0, 0, 0, 0, bm.Size);
                    pictureBox1.Image = bm;
                    collection.Add(bm);
            }
                catch (ArgumentException d) {
                    MessageBox.Show("Error "+ d);
                }
            
        }

        private void stream()
        {
            try
            {
                System.Net.WebRequest request =
                System.Net.WebRequest.Create("https://i.gifer.com/7OhN.gif");
                System.Net.WebResponse response = request.GetResponse();
                System.IO.Stream responseStream = response.GetResponseStream();
                Bitmap bitmap2 = new Bitmap(responseStream);
                pictureBox1.Image = bitmap2;

            }
            catch (System.Net.WebException)
            {
                MessageBox.Show("There was an error opening the image file."
                   + "Check the URL");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
          
            
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            timer1.Enabled = false;
            Application.Exit();
            
        }

        private void pictureBox3_MouseEnter(object sender, EventArgs e)
        {
            pictureBox3.Image = Properties.Resources.imgeli;
        }

        private void pictureBox3_MouseLeave(object sender, EventArgs e)
        {
            pictureBox3.Image = Properties.Resources.imgeli2;
        }
        int graba_act = 0;
        private void pictureBox2_MouseEnter(object sender, EventArgs e)
        {
            if (graba_act == 0)
            {
                pictureBox2.Image = Properties.Resources.grabar1_64;
            }
           
            
        }

        private void pictureBox2_MouseLeave(object sender, EventArgs e)
        {
            if (graba_act == 0)
            {
                pictureBox2.Image = Properties.Resources.grabar2_64;
            }
        
            
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            pictureBox2.Image = Properties.Resources.grabar_64;
            if (graba_act == 1)
            {
                graba_act = 0;
                pictureBox2.Image = Properties.Resources.grabar1_64;
                timer1.Enabled = false;
            }
            else
            {
                collection.Clear();
                this.WindowState = FormWindowState.Minimized;
                timer1.Interval = 1000/20;
                graba_act = 1;
                timer1.Enabled = true;
            }
        }

        private void pictureBox4_MouseEnter(object sender, EventArgs e)
        {
            pictureBox4.Image = Properties.Resources.captura_de_pantalla2_64;
        }

        private void pictureBox4_MouseLeave(object sender, EventArgs e)
        {
            pictureBox4.Image = Properties.Resources.captura_de_pantalla_64;
        }
        //Mover el formulario con el mouse
        private void Form2_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left)

            { xClick = e.X; yClick = e.Y;
                this.Cursor = Cursors.Default;
            }

            else

            {
                this.Cursor = Cursors.Hand;
                this.Left = this.Left + (e.X - xClick); this.Top = this.Top + (e.Y - yClick); }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            capturar();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            try
            {
                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    this.Hide();
                    Thread.Sleep(500);
                    bm = new Bitmap(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height);
                    g = Graphics.FromImage(bm);
                    g.CopyFromScreen(0, 0, 0, 0, bm.Size);
                    pictureBox1.Image = bm;
                    
                    // Saves the image.
                    bm.Save(saveFileDialog1.FileName);
                    // After the screenshot is taken the Form reappears.
                    this.Show();
                }
            }

            catch (Exception i)
            {
                MessageBox.Show("Error: " + i.Message);
            }
        }

       
    }

}
