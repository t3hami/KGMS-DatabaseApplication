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
    public partial class Vendor : UserControl
    {
        MyConnection mc;
        SqlCommand cmd;
        SqlDataReader dr;
        string selection;

        public Vendor()
        {
            InitializeComponent();
        }

        private void Vendor_Load(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(this.button1, "Close");
            textBox5.KeyPress += keyPress;
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
            Program.f2.setLocation();
        }

        public void select(string s)
        {
            selection = s;
            comboBox1.Text = "";
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            textBox7.Text = "";
            mc = new MyConnection();
            mc.conn.Open();
            if (selection == "Add")
            {
                comboBox1.Visible = false;
                textBox1.Visible = true;
                cmd = new SqlCommand("select count(VID) from Vendor;", mc.conn);
                dr = cmd.ExecuteReader();
                if (dr.Read())
                    textBox1.Text = "VEN-00" + (Convert.ToInt32(dr[0]) + 1).ToString() + "-2017";
                mc.conn.Close();
                textBox1.ReadOnly = true;
                textBox7.Text = "Active";
                button2.Visible = true;
                button2.Text = "Add";
                textBox2.ReadOnly = false;
                textBox3.ReadOnly = false;
                textBox4.ReadOnly = false;
                textBox5.ReadOnly = false;
                textBox6.ReadOnly = false;
            }
            else if (selection == "Search")
            {
                comboBox1.Items.Clear();
                comboBox1.Visible = true;
                textBox1.Visible = false;
                button2.Visible = true;
                button2.Text = "Reset";
                cmd = new SqlCommand("select VID from Vendor;",mc.conn);
                dr = cmd.ExecuteReader();
                while (dr.Read())
                    comboBox1.Items.Add(dr["VID"]);
                mc.conn.Close();
                textBox2.ReadOnly = true;
                textBox3.ReadOnly = true;
                textBox4.ReadOnly = true;
                textBox5.ReadOnly = true;
                textBox6.ReadOnly = true;
            }
            else if (selection == "Update")
            {
                comboBox1.Items.Clear();
                cmd = new SqlCommand("select VID from Vendor;", mc.conn);
                dr = cmd.ExecuteReader();
                while (dr.Read())
                    comboBox1.Items.Add(dr["VID"]);
                mc.conn.Close();
                comboBox1.Visible = true;
                textBox1.Visible = false;
                button2.Text = "Update";
                button2.Visible = true;
                textBox2.ReadOnly = false;
                textBox3.ReadOnly = false;
                textBox4.ReadOnly = false;
                textBox5.ReadOnly = false;
                textBox6.ReadOnly = false;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (selection == "Add")
            {
                if (textBox2.Text != "" && textBox3.Text != "" && textBox4.Text != "" && textBox5.Text != "" && textBox6.Text != "")
                {
                    mc.conn.Open();
                    cmd = new SqlCommand("insert into Vendor Values(@VID, @VName, @VAddress, @VContactPerson, @VCPPH, @VCPEmail, @VStatus);", mc.conn);
                    cmd.Parameters.AddWithValue("@VID", textBox1.Text);
                    cmd.Parameters.AddWithValue("@VName", textBox2.Text);
                    cmd.Parameters.AddWithValue("@VAddress", textBox3.Text);
                    cmd.Parameters.AddWithValue("@VContactPerson", textBox4.Text);
                    cmd.Parameters.AddWithValue("@VCPPH", textBox5.Text);
                    cmd.Parameters.AddWithValue("@VCPEmail", textBox6.Text);
                    cmd.Parameters.AddWithValue("@VStatus", textBox7.Text);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Vendor Added!");
                    cmd = new SqlCommand("select count(VID) from Vendor;", mc.conn);
                    dr = cmd.ExecuteReader();
                    if (dr.Read())
                        textBox1.Text = "VEN-00" + (Convert.ToInt32(dr[0]) + 1).ToString() + "-2017";
                    mc.conn.Close();
                    textBox2.Text = "";
                    textBox3.Text = "";
                    textBox4.Text = "";
                    textBox5.Text = "";
                    textBox6.Text = "";
                    textBox7.Text = "";
                }
                else
                    MessageBox.Show("Fill all text boxes!");
            }
            else if (selection == "Search")
            {
                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
                textBox4.Text = "";
                textBox5.Text = "";
                textBox6.Text = "";
                textBox7.Text = "";
                comboBox1.Text = "";
            }
            else if (selection == "Update")
            {
                if (textBox2.Text != "" && textBox3.Text != "" && textBox4.Text != "" && textBox5.Text != "" && textBox6.Text != "")
                {
                    mc.conn.Open();
                    cmd = new SqlCommand("update Vendor set VName=@VName, VAddress=@VAddress, VContactPerson=@VContactPerson, VCPPH=@VCPPH, VCPEmail=@VCPEmail where VID='"+comboBox1.Text+"';", mc.conn);
                    cmd.Parameters.AddWithValue("@VName", textBox2.Text);
                    cmd.Parameters.AddWithValue("@VAddress", textBox3.Text);
                    cmd.Parameters.AddWithValue("@VContactPerson", textBox4.Text);
                    cmd.Parameters.AddWithValue("@VCPPH", textBox5.Text);
                    cmd.Parameters.AddWithValue("@VCPEmail", textBox6.Text);
                    cmd.ExecuteNonQuery();
                    mc.conn.Close();
                    MessageBox.Show("Vendor Updated!");
                }
                else
                    MessageBox.Show("Fill all text boxes!");
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            mc.conn.Open();
            cmd = new SqlCommand("select * from Vendor where VID='"+comboBox1.Text+"';",mc.conn);
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                textBox2.Text = dr["VName"].ToString();
                textBox3.Text = dr["VAddress"].ToString();
                textBox4.Text = dr["VContactPerson"].ToString();
                textBox5.Text = dr["VCPPH"].ToString();
                textBox6.Text = dr["VCPEmail"].ToString();
                textBox7.Text = dr["VStatus"].ToString();
            }
            mc.conn.Close();
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
    }
}
