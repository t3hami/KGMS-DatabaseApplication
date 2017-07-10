using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KGMS_Database_Application
{
    public partial class MainMenu : Form
    {
        public Button selectedButton;

        public MainMenu()
        {
            InitializeComponent();
            SetStyle(ControlStyles.SupportsTransparentBackColor, true);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void MainMenu_Load(object sender, EventArgs e)
        {
            /*pictureBox1.ImageLocation = Environment.CurrentDirectory + "\\" + "cover.jpg";
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;*/
            this.BackgroundImage = Image.FromFile(Environment.CurrentDirectory + "\\back.jpg");
            groupBox2.Text = "";
            label4.BackColor = Color.Transparent;
            label2.BackColor = Color.Transparent;
            label3.BackColor = Color.Transparent;
            label5.BackColor = Color.Transparent;
            groupBox2.BackColor = Color.Transparent;

            button2.BackgroundImage = Image.FromFile(Environment.CurrentDirectory + "\\button1.jpg");
            button3.BackgroundImage = Image.FromFile(Environment.CurrentDirectory + "\\button1.jpg");
            button5.BackgroundImage = Image.FromFile(Environment.CurrentDirectory + "\\button1.jpg");
            button7.BackgroundImage = Image.FromFile(Environment.CurrentDirectory + "\\button1.jpg");
            button9.BackgroundImage = Image.FromFile(Environment.CurrentDirectory + "\\button1.jpg");
            button10.BackgroundImage = Image.FromFile(Environment.CurrentDirectory + "\\button1.jpg");
            button11.BackgroundImage = Image.FromFile(Environment.CurrentDirectory + "\\button1.jpg");
            button13.BackgroundImage = Image.FromFile(Environment.CurrentDirectory + "\\button1.jpg");
            button16.BackgroundImage = Image.FromFile(Environment.CurrentDirectory + "\\button1.jpg");
            button18.BackgroundImage = Image.FromFile(Environment.CurrentDirectory + "\\button1.jpg");
            button6.BackgroundImage = Image.FromFile(Environment.CurrentDirectory + "\\button1.jpg");
            button17.BackgroundImage = Image.FromFile(Environment.CurrentDirectory + "\\button1.jpg");
        }

        private void MainMenu_FormClosing(object sender, FormClosingEventArgs e)
        {
            Program.f1.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            selectedButton = button2;
            setColor(button2);
            createSalesOrder1.Visible = true;
            groupBox2.Text = "";
            label1.Text = "Create Sales Order";
            label1.Location = new Point(307, 144);
            controlInvisible(createSalesOrder1);

            button5.Location = new Point(28, 71);
            button7.Location = new Point(28, 127);
            button13.Location = new Point(28, 183);
            button2.Location = new Point(61, 317);
            button3.Location = new Point(28, 373);
            button16.Location = new Point(28, 429);

            button9.Location = new Point(633, 71);
            button10.Location = new Point(633, 127);
            button11.Location = new Point(633, 183);
            button6.Location = new Point(633, 317);
            button17.Location = new Point(633, 373);
            button18.Location = new Point(633, 429);
        }
        private void setColor(Button b)
        {
            button2.BackgroundImage = Image.FromFile(Environment.CurrentDirectory + "\\button1.jpg");
            button3.BackgroundImage = Image.FromFile(Environment.CurrentDirectory + "\\button1.jpg");
            button5.BackgroundImage = Image.FromFile(Environment.CurrentDirectory + "\\button1.jpg");
            button7.BackgroundImage = Image.FromFile(Environment.CurrentDirectory + "\\button1.jpg");
            button9.BackgroundImage = Image.FromFile(Environment.CurrentDirectory + "\\button1.jpg");
            button10.BackgroundImage = Image.FromFile(Environment.CurrentDirectory + "\\button1.jpg");
            button11.BackgroundImage = Image.FromFile(Environment.CurrentDirectory + "\\button1.jpg");
            button13.BackgroundImage = Image.FromFile(Environment.CurrentDirectory + "\\button1.jpg");
            button16.BackgroundImage = Image.FromFile(Environment.CurrentDirectory + "\\button1.jpg");
            button18.BackgroundImage = Image.FromFile(Environment.CurrentDirectory + "\\button1.jpg");
            button6.BackgroundImage = Image.FromFile(Environment.CurrentDirectory + "\\button1.jpg");
            button17.BackgroundImage = Image.FromFile(Environment.CurrentDirectory + "\\button1.jpg");

            b.BackgroundImage = Image.FromFile(Environment.CurrentDirectory + "\\back.jpg");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            selectedButton = button3;
            setColor(button3);
            searchSalesOrder1.Visible = true;
            groupBox2.Text = "";
            label1.Text = "Delivery Chalan";
            label1.Location = new Point(320, 144);
            controlInvisible(searchSalesOrder1);
            searchSalesOrder1.showControl();

            button5.Location = new Point(28, 71);
            button7.Location = new Point(28, 127);
            button13.Location = new Point(28, 183);
            button2.Location = new Point(28, 317);
            button3.Location = new Point(61, 373);
            button16.Location = new Point(28, 429);

            button9.Location = new Point(633, 71);
            button10.Location = new Point(633, 127);
            button11.Location = new Point(633, 183);
            button6.Location = new Point(633, 317);
            button17.Location = new Point(633, 373);
            button18.Location = new Point(633, 429);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            selectedButton = button5;
            setColor(button5);
            createPurchaseOrder1.Visible = true;
            groupBox2.Text = "";
            label1.Text = "Create Purchase Order";
            label1.Location = new Point(291, 144);
            controlInvisible(createPurchaseOrder1);
            createPurchaseOrder1.reload();

            button5.Location = new Point(61, 71);
            button7.Location = new Point(28, 127);
            button13.Location = new Point(28, 183);
            button2.Location = new Point(28, 317);
            button3.Location = new Point(28, 373);
            button16.Location = new Point(28, 429);

            button9.Location = new Point(633, 71);
            button10.Location = new Point(633, 127);
            button11.Location = new Point(633, 183);
            button6.Location = new Point(633, 317);
            button17.Location = new Point(633, 373);
            button18.Location = new Point(633, 429);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            selectedButton = button6;
            setColor(button6);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            selectedButton = button7;
            setColor(button7);
            searchPurchaseOrder1.Visible = true;
            groupBox2.Text = "";
            label1.Text = "Goods Receiving Note";
            label1.Location = new Point(291, 144);
            controlInvisible(searchPurchaseOrder1);
            searchPurchaseOrder1.showControl();

            button5.Location = new Point(28, 71);
            button7.Location = new Point(61, 127);
            button13.Location = new Point(28, 183);
            button2.Location = new Point(28, 317);
            button3.Location = new Point(28, 373);
            button16.Location = new Point(28, 429);

            button9.Location = new Point(633, 71);
            button10.Location = new Point(633, 127);
            button11.Location = new Point(633, 183);
            button6.Location = new Point(633, 317);
            button17.Location = new Point(633, 373);
            button18.Location = new Point(633, 429);
        }

        private void button9_Click(object sender, EventArgs e)
        {
            selectedButton = button9;
            setColor(button9);
            Program.f2.vendor1.select("Add");
            groupBox2.Text = "";
            label1.Text = "Add Vendor";
            label1.Location = new Point(327, 144);
            controlInvisible(vendor1);
            button9.Location = new Point(633, 71);
            button5.Location = new Point(28, 71);
            button7.Location = new Point(28, 127);
            button13.Location = new Point(28, 183);
            button2.Location = new Point(28, 317);
            button3.Location = new Point(28, 373);
            button16.Location = new Point(28, 429);

            button9.Location = new Point(594, 71);
            button10.Location = new Point(633, 127);
            button11.Location = new Point(633, 183);
            button6.Location = new Point(633, 317);
            button17.Location = new Point(633, 373);
            button18.Location = new Point(633, 429);

         
            
        }

        private void button10_Click(object sender, EventArgs e)
        {
            selectedButton = button10;
            setColor(button10);
            Program.f2.vendor1.select("Search");
            groupBox2.Text = "";
            label1.Text = "Search Vendor";
            label1.Location = new Point(327, 144);
            controlInvisible(vendor1);

            button9.Location = new Point(633, 71);
            button5.Location = new Point(28, 71);
            button7.Location = new Point(28, 127);
            button13.Location = new Point(28, 183);
            button2.Location = new Point(28, 317);
            button3.Location = new Point(28, 373);
            button16.Location = new Point(28, 429);

            button9.Location = new Point(633, 71);
            button10.Location = new Point(594, 127);
            button11.Location = new Point(633, 183);
            button6.Location = new Point(633, 317);
            button17.Location = new Point(633, 373);
            button18.Location = new Point(633, 429);

            
        }

        private void button11_Click(object sender, EventArgs e)
        {
            selectedButton = button11;
            setColor(button11);
            Program.f2.vendor1.select("Update");
            groupBox2.Text = "";
            label1.Text = "Update Vendor";
            label1.Location = new Point(327, 144);
            controlInvisible(vendor1);

            button9.Location = new Point(633, 71);
            button5.Location = new Point(28, 71);
            button7.Location = new Point(28, 127);
            button13.Location = new Point(28, 183);
            button2.Location = new Point(28, 317);
            button3.Location = new Point(28, 373);
            button16.Location = new Point(28, 429);

            button9.Location = new Point(633, 71);
            button10.Location = new Point(633, 127);
            button11.Location = new Point(594, 183);
            button6.Location = new Point(633, 317);
            button17.Location = new Point(633, 373);
            button18.Location = new Point(633, 429);
        }

        private void button13_Click(object sender, EventArgs e)
        {
            selectedButton = button13;
            setColor(button13);
            groupBox2.Text = "";
            label1.Text = "Invoice Payable";
            label1.Location = new Point(320, 144);
            invoicePayable1.Visible = true;
            invoicePayable1.reload();
            controlInvisible(invoicePayable1);

            button5.Location = new Point(28, 71);
            button7.Location = new Point(28, 127);
            button13.Location = new Point(61, 183);
            button2.Location = new Point(28, 317);
            button3.Location = new Point(28, 373);
            button16.Location = new Point(28, 429);

            button9.Location = new Point(633, 71);
            button10.Location = new Point(633, 127);
            button11.Location = new Point(633, 183);
            button6.Location = new Point(633, 317);
            button17.Location = new Point(633, 373);
            button18.Location = new Point(633, 429);
        }

        private void button14_Click(object sender, EventArgs e)
        {
            
        }

        private void button16_Click(object sender, EventArgs e)
        {
            selectedButton = button16;
            setColor(button16);
            invoiceReceivable1.Visible = true;
            groupBox2.Text = "";
            label1.Text = "Invoice Receivable";
            label1.Location = new Point(307, 144);
            controlInvisible(invoiceReceivable1);
            invoiceReceivable1.reload();

            button5.Location = new Point(28, 71);
            button7.Location = new Point(28, 127);
            button13.Location = new Point(28, 183);
            button2.Location = new Point(28, 317);
            button3.Location = new Point(28, 373);
            button16.Location = new Point(61, 429);

            button9.Location = new Point(633, 71);
            button10.Location = new Point(633, 127);
            button11.Location = new Point(633, 183);
            button6.Location = new Point(633, 317);
            button17.Location = new Point(633, 373);
            button18.Location = new Point(633, 429);
        }

        private void button15_Click(object sender, EventArgs e)
        {
            
        }

        private void button12_Click(object sender, EventArgs e)
        {
           
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            
        }

        private void button6_Click_1(object sender, EventArgs e)
        {
            selectedButton = button6;
            groupBox2.Text = "";
            label1.Text = "Add Emploee";
            label1.Location = new Point(327, 144);
            controlInvisible(emploee1);
            setColor(button6);
            Program.f2.emploee1.select("Add");

            button9.Location = new Point(633, 71);
            button5.Location = new Point(28, 71);
            button7.Location = new Point(28, 127);
            button13.Location = new Point(28, 183);
            button2.Location = new Point(28, 317);
            button3.Location = new Point(28, 373);
            button16.Location = new Point(28, 429);

            button9.Location = new Point(633, 71);
            button10.Location = new Point(633, 127);
            button11.Location = new Point(633, 183);
            button6.Location = new Point(594, 317);
            button17.Location = new Point(633, 373);
            button18.Location = new Point(633, 429);
        }

        private void button17_Click(object sender, EventArgs e)
        {
            selectedButton = button17;
            setColor(button17);
            groupBox2.Text = "";
            label1.Text = "Search Emploee";
            label1.Location = new Point(327, 144);
            controlInvisible(emploee1);
            Program.f2.emploee1.select("Search");

            button9.Location = new Point(633, 71);
            button5.Location = new Point(28, 71);
            button7.Location = new Point(28, 127);
            button13.Location = new Point(28, 183);
            button2.Location = new Point(28, 317);
            button3.Location = new Point(28, 373);
            button16.Location = new Point(28, 429);

            button9.Location = new Point(633, 71);
            button10.Location = new Point(633, 127);
            button11.Location = new Point(633, 183);
            button6.Location = new Point(633, 317);
            button17.Location = new Point(594, 373);
            button18.Location = new Point(633, 429);
        }

        private void button18_Click(object sender, EventArgs e)
        {
            selectedButton = button18;
            setColor(button18);
            groupBox2.Text = "";
            label1.Text = "Update Emploee";
            label1.Location = new Point(327, 144);
            controlInvisible(emploee1);
            Program.f2.emploee1.select("Update");

            button9.Location = new Point(633, 71);
            button5.Location = new Point(28, 71);
            button7.Location = new Point(28, 127);
            button13.Location = new Point(28, 183);
            button2.Location = new Point(28, 317);
            button3.Location = new Point(28, 373);
            button16.Location = new Point(28, 429);

            button9.Location = new Point(633, 71);
            button10.Location = new Point(633, 127);
            button11.Location = new Point(633, 183);
            button6.Location = new Point(633, 317);
            button17.Location = new Point(633, 373);
            button18.Location = new Point(594, 429);
        }

        private void button8_Click(object sender, EventArgs e)
        {
           
        }

        private void button4_Click(object sender, EventArgs e)
        {
            
        }

        private void controlInvisible(UserControl u)
        {
            emploee1.Visible = false;
            vendor1.Visible = false;
            createSalesOrder1.Visible = false;
            searchSalesOrder1.Visible = false;
            createPurchaseOrder1.Visible = false;
            searchPurchaseOrder1.Visible = false;
            invoiceReceivable1.Visible = false;
            invoicePayable1.Visible = false;
            noticeBoard1.Visible = false;
            u.Visible = true;
        }

        private void button1_Click_2(object sender, EventArgs e)
        {
            
        }

        private void button8_Click_1(object sender, EventArgs e)
        {
            
        }

        private void button9_MouseHover(object sender, EventArgs e)
        {
            button9.Font = new Font(button9.Font.Name, button9.Font.SizeInPoints+1, FontStyle.Underline);
        }

        private void button9_MouseLeave(object sender, EventArgs e)
        {
            
            button9.Font = new Font(button9.Font.Name, button9.Font.SizeInPoints-1);
        }

        public void setLocation()
        {
            button9.Location = new Point(633, 71);
            button5.Location = new Point(28, 71);
            button7.Location = new Point(28, 127);
            button13.Location = new Point(28, 183);
            button2.Location = new Point(28, 317);
            button3.Location = new Point(28, 373);
            button16.Location = new Point(28, 429);

            button9.Location = new Point(633, 71);
            button10.Location = new Point(633, 127);
            button11.Location = new Point(633, 183);
            button6.Location = new Point(633, 317);
            button17.Location = new Point(633, 373);
            button18.Location = new Point(633, 429);

            button2.BackgroundImage = Image.FromFile(Environment.CurrentDirectory + "\\button1.jpg");
            button3.BackgroundImage = Image.FromFile(Environment.CurrentDirectory + "\\button1.jpg");
            button5.BackgroundImage = Image.FromFile(Environment.CurrentDirectory + "\\button1.jpg");
            button7.BackgroundImage = Image.FromFile(Environment.CurrentDirectory + "\\button1.jpg");
            button9.BackgroundImage = Image.FromFile(Environment.CurrentDirectory + "\\button1.jpg");
            button10.BackgroundImage = Image.FromFile(Environment.CurrentDirectory + "\\button1.jpg");
            button11.BackgroundImage = Image.FromFile(Environment.CurrentDirectory + "\\button1.jpg");
            button13.BackgroundImage = Image.FromFile(Environment.CurrentDirectory + "\\button1.jpg");
            button16.BackgroundImage = Image.FromFile(Environment.CurrentDirectory + "\\button1.jpg");
            button18.BackgroundImage = Image.FromFile(Environment.CurrentDirectory + "\\button1.jpg");
            button6.BackgroundImage = Image.FromFile(Environment.CurrentDirectory + "\\button1.jpg");
            button17.BackgroundImage = Image.FromFile(Environment.CurrentDirectory + "\\button1.jpg");

            button2.ForeColor = SystemColors.ControlLight;
            button3.ForeColor = SystemColors.ControlLight;
            button5.ForeColor = SystemColors.ControlLight;
            button7.ForeColor = SystemColors.ControlLight;
            button9.ForeColor = SystemColors.ControlLight;
            button10.ForeColor = SystemColors.ControlLight;
            button11.ForeColor = SystemColors.ControlLight;
            button13.ForeColor = SystemColors.ControlLight;
            button16.ForeColor = SystemColors.ControlLight;
            button18.ForeColor = SystemColors.ControlLight;
            button6.ForeColor = SystemColors.ControlLight;
            button17.ForeColor = SystemColors.ControlLight;
        }

        private void button5_MouseHover(object sender, EventArgs e)
        {
            button5.Font = new Font(button5.Font.Name, button5.Font.SizeInPoints + 1, FontStyle.Underline);
        }

        private void button5_MouseLeave(object sender, EventArgs e)
        {
            button5.Font = new Font(button5.Font.Name, button5.Font.SizeInPoints - 1);
        }

        private void button7_MouseHover(object sender, EventArgs e)
        {
            button7.Font = new Font(button7.Font.Name, button7.Font.SizeInPoints + 1, FontStyle.Underline);
        }

        private void button7_MouseLeave(object sender, EventArgs e)
        {
            button7.Font = new Font(button7.Font.Name, button7.Font.SizeInPoints - 1);
        }

        private void button13_MouseHover(object sender, EventArgs e)
        {
            button13.Font = new Font(button13.Font.Name, button13.Font.SizeInPoints + 1, FontStyle.Underline);
        }

        private void button13_MouseLeave(object sender, EventArgs e)
        {
            button13.Font = new Font(button13.Font.Name, button13.Font.SizeInPoints - 1);
        }

        private void button2_MouseLeave(object sender, EventArgs e)
        {
            button2.Font = new Font(button2.Font.Name, button2.Font.SizeInPoints - 1);
        }

        private void button2_MouseHover(object sender, EventArgs e)
        {
            button2.Font = new Font(button2.Font.Name, button2.Font.SizeInPoints + 1, FontStyle.Underline);
        }

        private void button3_MouseHover(object sender, EventArgs e)
        {
            button3.Font = new Font(button3.Font.Name, button3.Font.SizeInPoints + 1, FontStyle.Underline);
        }

        private void button3_MouseLeave(object sender, EventArgs e)
        {
            button3.Font = new Font(button3.Font.Name, button3.Font.SizeInPoints - 1);
        }

        private void button16_MouseHover(object sender, EventArgs e)
        {
            button16.Font = new Font(button16.Font.Name, button16.Font.SizeInPoints + 1, FontStyle.Underline);
        }

        private void button16_MouseLeave(object sender, EventArgs e)
        {
            button16.Font = new Font(button16.Font.Name, button16.Font.SizeInPoints - 1);
        }

        private void button10_MouseHover(object sender, EventArgs e)
        {
            button10.Font = new Font(button10.Font.Name, button10.Font.SizeInPoints + 1, FontStyle.Underline);
        }

        private void button10_MouseLeave(object sender, EventArgs e)
        {
            button10.Font = new Font(button10.Font.Name, button10.Font.SizeInPoints - 1);
        }

        private void button11_MouseHover(object sender, EventArgs e)
        {
            button11.Font = new Font(button11.Font.Name, button11.Font.SizeInPoints + 1, FontStyle.Underline);
        }

        private void button11_MouseLeave(object sender, EventArgs e)
        {
            button11.Font = new Font(button11.Font.Name, button11.Font.SizeInPoints - 1);
        }

        private void button6_MouseHover(object sender, EventArgs e)
        {
            button6.Font = new Font(button6.Font.Name, button6.Font.SizeInPoints + 1, FontStyle.Underline);
        }

        private void button6_MouseLeave(object sender, EventArgs e)
        {
            button6.Font = new Font(button6.Font.Name, button6.Font.SizeInPoints - 1);
        }

        private void button17_MouseHover(object sender, EventArgs e)
        {
            button17.Font = new Font(button17.Font.Name, button17.Font.SizeInPoints + 1, FontStyle.Underline);
        }

        private void button17_MouseLeave(object sender, EventArgs e)
        {
            button17.Font = new Font(button17.Font.Name, button17.Font.SizeInPoints - 1);
        }

        private void button18_MouseHover(object sender, EventArgs e)
        {
            button18.Font = new Font(button18.Font.Name, button18.Font.SizeInPoints + 1, FontStyle.Underline);
        }

        private void button18_MouseLeave(object sender, EventArgs e)
        {
            button18.Font = new Font(button18.Font.Name, button18.Font.SizeInPoints - 1);
        }
    }
}
