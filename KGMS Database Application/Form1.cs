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

namespace KGMS_Database_Application
{
    public partial class Form1 : Form
    {
        MyConnection mc;
        SqlCommand cmd;
        SqlDataReader dr;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            mc = new MyConnection();
            mc.conn.Open();
            pictureBox2.ImageLocation = Environment.CurrentDirectory + "\\" + "profile.jpg";
            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //if (textBox1.Text == "" && textBox2.Text == "")
            {
                Program.f2 = new MainMenu();
                Program.f2.Show();
            }
            this.Hide();
        }

    }
}
