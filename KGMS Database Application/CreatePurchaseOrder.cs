using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace KGMS_Database_Application
{
    public partial class CreatePurchaseOrder : UserControl
    {
        MyConnection mc;
        SqlCommand cmd;
        SqlDataReader dr;
        string[] pid = new string[100];
        int[] pqty = new int[100];
        int count = 0;
        string pID;
        int price, grandTotal=0;
        int PQuantity=0;

        public CreatePurchaseOrder()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            Program.f2.selectedButton.BackColor = SystemColors.Control;
            Program.f2.selectedButton.ForeColor = SystemColors.ControlText;
            Program.f2.groupBox2.Text = "";
            Program.f2.label1.Text = "Notice Board";
            Program.f2.label1.Location = new Point(331, 144);
            Program.f2.noticeBoard1.Visible = true;
            reload();
            Program.f2.setLocation();
        }

        private void CreateSalesOrder_Load(object sender, EventArgs e)
        {
            textBox3.KeyPress += keyPress;
            textBox6.KeyPress += keyPress;
        }

        private bool cusInfo()
        {
            if (comboBox1.Text=="")
            {
                comboBox1.Text = "";
                MessageBox.Show("Select Vendor first!");
                return false;
            }
            else
                return true;
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            if (textBox6.Text != "")
            {
                if (!cusInfo())
                    textBox6.Text = "";
            }
            if (textBox6.Text != "" && Convert.ToInt32(textBox6.Text) > PQuantity)
            {
                MessageBox.Show("Not enough quantity available..\n Max available quantity for provided product =" + PQuantity);
                textBox6.Text = "";
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cusInfo())
            {
                mc.conn.Open();
                cmd = new SqlCommand("select SalesPrice, PType, PID, PQuantity from Products where PName='" + comboBox1.Text + "';", mc.conn);
                dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    textBox5.Text = "Rs." + dr["SalesPrice"].ToString();
                    price = Convert.ToInt32(dr["SalesPrice"]);
                    if (dr["PType"].ToString() == "Dry")
                        label8.Text = "/Kg";
                    else
                        label8.Text = "";
                    pID = dr["PID"].ToString(); 
                    PQuantity = Convert.ToInt32(dr["PQuantity"]);

                }
                mc.conn.Close();
                button2.Enabled = true;
                textBox5.Enabled = true;
                textBox6.Enabled = true;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            cusInfo();
            if (textBox5.Text != "" && textBox6.Text != "")
            {
                pid[count] = pID;
                pqty[count] = Convert.ToInt32(textBox6.Text);
                count++;
                int total = Convert.ToInt32(textBox6.Text) * price;
                dataGridView1.Rows.Add(comboBox1.Text, textBox6.Text, (total).ToString());
                grandTotal += total;
                label8.Visible = true;
                label9.Text = "Grand Total = Rs." + grandTotal + "/=";
                comboBox1.Text = "";
                textBox5.Text = "";
                textBox6.Text = "";
            }
            button3.Enabled = true;
        }

        public void reload()
        {
            label9.Text = "";
            toolTip1.SetToolTip(button1, "Close");
            mc = new MyConnection();
            mc.conn.Open();
            cmd = new SqlCommand("select count(POID) from PO;", mc.conn);
            dr = cmd.ExecuteReader();
            if (dr.Read())
                textBox1.Text = "PO-00" + (Convert.ToInt32(dr[0]) + 1).ToString() + "-2017";
            dr.Close();
            comboBox1.Items.Clear();
            cmd = new SqlCommand("select PName from Products;", mc.conn);
            dr = cmd.ExecuteReader();
            while (dr.Read())
                comboBox1.Items.Add(dr["PName"]);
            dr.Close();
            cmd = new SqlCommand("select VID from Vendor;", mc.conn);
            dr = cmd.ExecuteReader();
            while (dr.Read())
                comboBox2.Items.Add(dr["VID"]);
            mc.conn.Close();
            label9.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            comboBox1.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            comboBox2.Text = "";
            button2.Enabled = false;
            button3.Enabled = false;
            textBox6.Enabled = false;
            comboBox1.Enabled = false;
            dateTimePicker1.Value = System.DateTime.Now;
            dataGridView1.Rows.Clear();
            pid = new string[100];
            pqty = new int[100];
            grandTotal = 0;
            price = 0;
            count = 0;
        }

        private void keyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar > (char)Keys.D9 || e.KeyChar < (char)Keys.D0) && e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true;
            }

            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            mc.conn.Open();
            cmd = new SqlCommand("insert into PO Values(@POID, @VID, @PODate, @DeliveryDate, @Total, 'No', 'Open');", mc.conn);
            cmd.Parameters.AddWithValue("@POID", textBox1.Text);
            cmd.Parameters.AddWithValue("@VID", comboBox2.Text);
            cmd.Parameters.AddWithValue("@PODate", System.DateTime.Now.Date);
            cmd.Parameters.AddWithValue("@DeliveryDate", dateTimePicker1.Value.Date);
            cmd.Parameters.AddWithValue("@Total", grandTotal);
            cmd.ExecuteNonQuery();
            for (int i = 0; i < count; i++)
            {
                cmd = new SqlCommand("insert into POProducts(POID, PID, POPQuantity) Values(@POID, @PID, @POPQuantity);", mc.conn);
                cmd.Parameters.AddWithValue("@POID", textBox1.Text);
                cmd.Parameters.AddWithValue("@PID", pid[i]);
                cmd.Parameters.AddWithValue("@POPQuantity", pqty[i]);
                cmd.ExecuteNonQuery();
            }
            mc.conn.Close();
            MessageBox.Show("Purchase order inserted!");
            reload();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            mc.conn.Open();
            cmd = new SqlCommand("select VName, VAddress from Vendor where VID='"+comboBox2.Text+"';",mc.conn);
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                textBox3.Text = dr["VName"].ToString();
                textBox4.Text = dr["VAddress"].ToString();
            }
            mc.conn.Close();
            comboBox1.Enabled = true;

        }
    }
}
