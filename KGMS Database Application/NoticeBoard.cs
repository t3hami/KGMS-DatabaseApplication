using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KGMS_Database_Application
{
    public partial class NoticeBoard : UserControl
    {
        int pic = 1;
        public NoticeBoard()
        {
            InitializeComponent();
        }

        private void NoticeBoard_Load(object sender, EventArgs e)
        {
            pictureBox1.ImageLocation = Environment.CurrentDirectory + "\\" + "1.jpg";
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            toolTip2.SetToolTip(button2, "Next");
            toolTip3.SetToolTip(button3, "Previous");
            this.BackColor = SystemColors.Control;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (pic < 5)
                pic++;
            else
                pic = 1;
            pictureBox1.ImageLocation = Environment.CurrentDirectory + "\\" + pic.ToString() +".jpg";

            if (pic == 1)
                radioButton1.Checked = true;
            else if (pic == 2)
                radioButton2.Checked = true;
            else if (pic == 3)
                radioButton3.Checked = true;
            else if (pic == 4)
                radioButton4.Checked = true;
            else if (pic == 5)
                radioButton5.Checked = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (pic > 1)
                pic--;
            else
                pic = 5;
            pictureBox1.ImageLocation = Environment.CurrentDirectory + "\\" + pic.ToString() + ".jpg";

            if (pic == 1)
                radioButton1.Checked = true;
            else if (pic == 2)
                radioButton2.Checked = true;
            else if (pic == 3)
                radioButton3.Checked = true;
            else if (pic == 4)
                radioButton4.Checked = true;
            else if (pic == 5)
                radioButton5.Checked = true;
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            pictureBox1.ImageLocation = Environment.CurrentDirectory + "\\1.jpg";
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            pictureBox1.ImageLocation = Environment.CurrentDirectory + "\\2.jpg";
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            pictureBox1.ImageLocation = Environment.CurrentDirectory + "\\3.jpg";
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            pictureBox1.ImageLocation = Environment.CurrentDirectory + "\\4.jpg";
        }

        private void radioButton5_CheckedChanged(object sender, EventArgs e)
        {
            pictureBox1.ImageLocation = Environment.CurrentDirectory + "\\5.jpg";
        }
    }
}
