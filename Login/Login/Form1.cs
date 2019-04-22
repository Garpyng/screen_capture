using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Login
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

        }

        //metodos
        public void fx_user()
        {
            pictureBox3.Image = Properties.Resources.imguser2;
            panel1.BackColor = Color.FromArgb(51, 204, 204);
            textBox1.ForeColor = Color.FromArgb(51, 204, 204);
        }
        public void fx_user_default()
        {
            pictureBox3.Image = Properties.Resources.imguser1;
            panel1.BackColor = Color.White;
            textBox1.ForeColor = Color.White;
        }

        public void fx_pass()
        {
            pictureBox4.Image = Properties.Resources.imgpass2;
            panel2.BackColor = Color.FromArgb(51, 204, 204);
            textBox2.ForeColor = Color.FromArgb(51, 204, 204);
        }

        public void fx_pass_error()
        {
            pictureBox4.Image = Properties.Resources.imgpass_error;
            panel2.BackColor = Color.FromArgb(199, 0, 57);
            textBox2.ForeColor = Color.FromArgb(199, 0, 57);
        }

        public void fx_pass_default()
        {
            pictureBox4.Image = Properties.Resources.imgpass1;
            panel2.BackColor = Color.White;
            textBox2.ForeColor = Color.White;
        }

        private void textBox1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "Usuario")
            {
                textBox1.Clear();
            }
            if (textBox2.Text == "")
            {
                textBox2.Text = "****";
            }
            fx_user();
            fx_pass_default();
        }

        private void textBox2_Click(object sender, EventArgs e)
        {
            if (textBox2.Text == "****")
            {
                textBox2.Clear();
            }
            if (textBox1.Text == "")
            {
                textBox1.Text = "Usuario";
            }
            fx_pass();
            fx_user_default();
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                textBox2.Focus();
                if (textBox2.Text == "****")
                {
                    textBox2.Clear();
                }
                fx_pass();
                fx_user_default();
            }
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                if (textBox2.Text != "")
                {
                    fx_pass_default();
                    button1.Focus();
                }
                else
                {
                    fx_pass_error();
                }

            }
        }

        private void pictureBox1_MouseEnter(object sender, EventArgs e)
        {
            pictureBox1.Image = Properties.Resources.imgeli;
        }

        private void pictureBox1_MouseLeave(object sender, EventArgs e)
        {
            pictureBox1.Image = Properties.Resources.imgeli2;

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            Form2 f2 = new Form2();
            f2.Show();
            this.Hide();

        }
    }
    }
