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
    public partial class CreateSalesOrder : UserControl
    {
        MyConnection mc;
        SqlCommand cmd;
        SqlDataReader dr;
        string[] pid = new string[100];
        int[] pqty = new int[100];
        int count = 0;
        string pID;
        int price, grandTotal=0;
        int PQuantity = 0;

        public CreateSalesOrder()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            Program.f2.selectedButton.BackColor = SystemColors.Control;
            Program.f2.selectedButton.ForeColor = SystemColors.ControlText;
            Program.f2.groupBox2.Text = "";
            Program.f2.noticeBoard1.Visible = true;
            Program.f2.label1.Text = "Notice Board";
            Program.f2.label1.Location = new Point(331, 144);
            reload();
            Program.f2.setLocation();
        }

        private void CreateSalesOrder_Load(object sender, EventArgs e)
        {
            label9.Text = "";
            toolTip1.SetToolTip(button1,"Close");
            mc = new MyConnection();
            mc.conn.Open();
            cmd = new SqlCommand("select count(SOID) from SO;", mc.conn);
            dr = cmd.ExecuteReader();
            if (dr.Read())
                textBox1.Text = "SO-00" + (Convert.ToInt32(dr[0]) + 1).ToString() + "-2017";
            dr.Close();
            cmd = new SqlCommand("select PName from Products;", mc.conn);
            dr = cmd.ExecuteReader();
            while (dr.Read())
                comboBox1.Items.Add(dr["PName"]);
            mc.conn.Close();
            textBox3.KeyPress += keyPress;
            textBox6.KeyPress += keyPress;
        }

        private bool cusInfo()
        {
            if (textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "")
            {
                comboBox1.Text = "";
                MessageBox.Show("Fill Customer Information first!");
                comboBox1.Text = "";
                if (textBox2.Text == "")
                    textBox2.Focus();
                else if (textBox3.Text == "")
                    textBox3.Focus();
                else if (textBox4.Text == "")
                    textBox4.Focus();
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

        private void reload()
        {
            label9.Text = "";
            toolTip1.SetToolTip(button1, "Close");
            mc = new MyConnection();
            mc.conn.Open();
            cmd = new SqlCommand("select count(SOID) from SO;", mc.conn);
            dr = cmd.ExecuteReader();
            if (dr.Read())
                textBox1.Text = "SO-00" + (Convert.ToInt32(dr[0]) + 1).ToString() + "-2017";
            dr.Close();
            comboBox1.Items.Clear();
            cmd = new SqlCommand("select PName from Products;", mc.conn);
            dr = cmd.ExecuteReader();
            while (dr.Read())
                comboBox1.Items.Add(dr["PName"]);
            mc.conn.Close();
            label9.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            comboBox1.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            comboBox1.Enabled = false;
            textBox6.Enabled = false; ;
            button2.Enabled = false;
            button3.Enabled = false;
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
            //Edit: Alternative
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            mc.conn.Open();
            cmd = new SqlCommand("insert into SO Values(@SOID, @CustomerName, @SODate, @Total, @CustomerPhone, @CustomerAddress, 'No', 'Open');", mc.conn);
            cmd.Parameters.AddWithValue("@SOID", textBox1.Text);
            cmd.Parameters.AddWithValue("@CustomerName", textBox2.Text);
            cmd.Parameters.AddWithValue("@SODate", System.DateTime.Now.Date);
            cmd.Parameters.AddWithValue("@Total", grandTotal);
            cmd.Parameters.AddWithValue("@CustomerPhone", textBox3.Text);
            cmd.Parameters.AddWithValue("@CustomerAddress", textBox4.Text);
            cmd.ExecuteNonQuery();
            for (int i = 0; i < count; i++)
            {
                cmd = new SqlCommand("insert into SOProducts(SOID, PID, SOPQuantity) Values(@SOID, @PID, @SOPQuantity);", mc.conn);
                cmd.Parameters.AddWithValue("@SOID", textBox1.Text);
                cmd.Parameters.AddWithValue("@PID", pid[i]);
                cmd.Parameters.AddWithValue("@SOPQuantity", pqty[i]);
                cmd.ExecuteNonQuery();
                cmd = new SqlCommand("select PQuantity from Products where PID=@PID;", mc.conn);
                cmd.Parameters.AddWithValue("@PID",pid[i]);
                dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    SqlCommand cmd1 = new SqlCommand("update Products set PQuantity=@PQuantity where PID=@PID;",mc.conn );
                    cmd1.Parameters.AddWithValue("@PQuantity", (Convert.ToInt32(dr["PQuantity"]) - pqty[i]).ToString());
                    cmd1.Parameters.AddWithValue("@PID",pid[i]);
                    dr.Close();
                    cmd1.ExecuteNonQuery();
                }
            }
            mc.conn.Close();
            MessageBox.Show("Sale order inserted!");
            reload();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (textBox2.Text != "" && textBox3.Text != "" && textBox4.Text != "")
            {
                comboBox1.Enabled=true;
            }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            if (textBox2.Text != "" && textBox3.Text != "" && textBox4.Text != "")
            {
                comboBox1.Enabled = true;
            }
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            if (textBox2.Text != "" && textBox3.Text != "" && textBox4.Text != "")
            {
                comboBox1.Enabled = true;
            }
        }
    }
}
