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
    public partial class Emploee : UserControl
    {
        MyConnection mc;
        SqlCommand cmd;
        SqlDataReader dr;
        string selection;

        public Emploee()
        {
            InitializeComponent();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                dateTimePicker3.Enabled = true;
                dateTimePicker3.Visible = true;
            }
            else
                dateTimePicker3.Enabled = false;
            
        }

        public void select(string s)
        {
            dateTimePicker3.Visible = true;
            this.Visible = true;
            selection = s;
            mc = new MyConnection();
            if (selection == "Add")
            {
                comboBox1.Visible = false;
                textBox3.Visible = false;
                textBox1.Visible = true;
                comboBox2.Visible = true;
                textBox1.ReadOnly = true;
                button2.Text = "Add";
                mc.conn.Open();
                comboBox1.Visible = false;
                textBox1.Visible = true;
                cmd = new SqlCommand("select count(EID) from Emploee;", mc.conn);
                dr = cmd.ExecuteReader();
                if (dr.Read())
                    textBox1.Text = "EMP-00" + (Convert.ToInt32(dr[0]) + 1).ToString() + "-2017";
                mc.conn.Close();
                textBox2.Text = "";
                comboBox2.Text = "";
                textBox4.Text = "";
                textBox5.Text = "";
                textBox6.Text = "";
                textBox7.Text = "";
                dateTimePicker1.Value = dateTimePicker2.Value = dateTimePicker3.Value = System.DateTime.Now;
                checkBox1.Checked = false;
                comboBox2.Items.Clear();
                comboBox2.Items.Add("Male");
                comboBox2.Items.Add("Female");
                checkBox1.Visible = true;
                dateTimePicker3.Location = new Point(143, 239);
                dateTimePicker3.Size = new Size(194, 20);
                label9.Text = "Date of fire if any?";
                textBox2.ReadOnly = false;
                textBox3.ReadOnly = false;
                textBox4.ReadOnly = false;
                textBox5.ReadOnly = false;
                textBox6.ReadOnly = false;
                textBox7.ReadOnly = false;
                dateTimePicker1.Enabled = true;
                dateTimePicker2.Enabled = true;
                dateTimePicker3.Enabled = true;
            }
            else if (selection == "Search")
            {
                textBox3.Visible = true;
                comboBox2.Visible = false;
                textBox2.Text = "";
                textBox3.Text = "";
                textBox4.Text = "";
                textBox5.Text = "";
                textBox6.Text = "";
                textBox7.Text = "";
                dateTimePicker1.Value = dateTimePicker2.Value = dateTimePicker3.Value = System.DateTime.Now;
                comboBox1.Items.Clear();
                button2.Text = "Reset";
                textBox1.Visible = false;
                comboBox1.Visible = true;
                textBox3.Visible = true;
                comboBox2.Visible = false;
                mc.conn.Open();
                cmd = new SqlCommand("select EID from Emploee;", mc.conn);
                dr = cmd.ExecuteReader();
                while (dr.Read())
                    comboBox1.Items.Add(dr["EID"]);
                mc.conn.Close();
                textBox2.ReadOnly = true;
                textBox3.ReadOnly = true;
                textBox4.ReadOnly = true;
                textBox5.ReadOnly = true;
                textBox6.ReadOnly = true;
                textBox7.ReadOnly = true;
                label9.Text = "Date of fire";
                checkBox1.Visible = false;
                dateTimePicker3.Location = new Point(94, 239);
                dateTimePicker3.Size = new Size(243,20);
                dateTimePicker1.Enabled = false;
                dateTimePicker2.Enabled = false;
                dateTimePicker3.Enabled = false;
            }

            else if (selection == "Update")
            {
                textBox3.Visible = true;
                comboBox2.Visible = false;
                textBox2.Text = "";
                textBox4.Text = "";
                textBox5.Text = "";
                textBox6.Text = "";
                textBox7.Text = "";
                dateTimePicker1.Value = dateTimePicker2.Value = dateTimePicker3.Value = System.DateTime.Now;
                comboBox2.Text = "";
                comboBox1.Text = "";
                comboBox1.Items.Clear();
                mc.conn.Open();
                cmd = new SqlCommand("select EID from Emploee;", mc.conn);
                dr = cmd.ExecuteReader();
                while (dr.Read())
                    comboBox1.Items.Add(dr["EID"]);
                mc.conn.Close();
                button2.Text = "Update";
                textBox1.Visible = false;
                comboBox1.Visible = true;
                textBox3.Visible = false;
                comboBox2.Visible = true;
                comboBox2.Items.Clear();
                comboBox2.Items.Add("Male");
                comboBox2.Items.Add("Female");
                checkBox1.Visible = true;
                checkBox1.Checked = false;
                dateTimePicker3.Location = new Point(143, 239);
                dateTimePicker3.Size = new Size(194, 20);
                label9.Text = "Date of fire if any?";
                dateTimePicker2.Enabled = true;
                dateTimePicker2.Enabled = true;
                dateTimePicker3.Enabled = false;
                textBox2.ReadOnly = false;
                textBox3.ReadOnly = false;
                textBox4.ReadOnly = false;
                textBox5.ReadOnly = false;
                textBox6.ReadOnly = false;
                textBox7.ReadOnly = false;
            }

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

        private void button2_Click(object sender, EventArgs e)
        {
            if (selection == "Add")
            {
                if (textBox2.Text != "" && textBox4.Text != "" && textBox5.Text != "" && textBox6.Text != "" && textBox7.Text != "" && comboBox2.Text != "")
                {
                    if (checkBox1.Checked)
                    {
                        mc.conn.Open();
                        cmd = new SqlCommand("insert into Emploee Values(@EID, @EName, @EGender, @EDOB, @EAddress, @EPH, @EDesignation, @EDOH, @EDOF, @ESalary);", mc.conn);
                        cmd.Parameters.AddWithValue("@EID", textBox1.Text);
                        cmd.Parameters.AddWithValue("@EName", textBox2.Text);
                        cmd.Parameters.AddWithValue("@EGender", comboBox2.Text);
                        cmd.Parameters.AddWithValue("@EDOB", dateTimePicker1.Value.Date);
                        cmd.Parameters.AddWithValue("@EAddress", textBox4.Text);
                        cmd.Parameters.AddWithValue("@EPH", textBox5.Text);
                        cmd.Parameters.AddWithValue("@EDesignation", textBox6.Text);
                        cmd.Parameters.AddWithValue("@EDOH", dateTimePicker2.Value.Date);
                        cmd.Parameters.AddWithValue("@EDOF", dateTimePicker3.Value.Date);
                        cmd.Parameters.AddWithValue("@ESalary", textBox7.Text);
                    }
                    else
                    {
                        cmd = new SqlCommand("insert into Emploee(EID, EName, EGender, EDOB, EAddress, EPH, EDesignation, EDOH, ESalary) Values(@EID, @EName, @EGender, @EDOB, @EAddress, @EPH, @EDesignation, @EDOH, @ESalary);", mc.conn);
                        cmd.Parameters.AddWithValue("@EID", textBox1.Text);
                        cmd.Parameters.AddWithValue("@EName", textBox2.Text);
                        cmd.Parameters.AddWithValue("@EGender", comboBox2.Text);
                        cmd.Parameters.AddWithValue("@EDOB", dateTimePicker1.Value.Date);
                        cmd.Parameters.AddWithValue("@EAddress", textBox4.Text);
                        cmd.Parameters.AddWithValue("@EPH", textBox5.Text);
                        cmd.Parameters.AddWithValue("@EDesignation", textBox6.Text);
                        cmd.Parameters.AddWithValue("@EDOH", dateTimePicker2.Value.Date);
                        cmd.Parameters.AddWithValue("@ESalary", textBox7.Text);
                    }
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Emploee added!");
                    cmd = new SqlCommand("select count(EID) from Emploee;", mc.conn);
                    dr = cmd.ExecuteReader();
                    if (dr.Read())
                        textBox1.Text = "EMP-00" + (Convert.ToInt32(dr[0]) + 1).ToString() + "-2017";
                    mc.conn.Close();
                    textBox2.Text = "";
                    comboBox2.Text = "";
                    textBox4.Text = "";
                    textBox5.Text = "";
                    textBox6.Text = "";
                    textBox7.Text = "";
                    dateTimePicker1.Value = dateTimePicker2.Value = dateTimePicker3.Value = System.DateTime.Now;
                    checkBox1.Checked = false;
                }
                else
                    MessageBox.Show("Fill all text boxes!");
            }
            else if(selection == "Search")
            {
                textBox2.Text = "";
                textBox3.Text = "";
                textBox4.Text = "";
                textBox5.Text = "";
                textBox6.Text = "";
                textBox7.Text = "";
                dateTimePicker1.Value = dateTimePicker2.Value = dateTimePicker3.Value = System.DateTime.Now;
                comboBox1.Text = "";
                dateTimePicker3.Visible = true;
            }
            else if (selection == "Update")
            {
                mc.conn.Open();
                if (checkBox1.Checked)
                {
                    cmd = new SqlCommand("Update Emploee set EName=@EName, EGender=@EGender, EDOB=@EDOB, EAddress=@EAddress, EPH=@EPH, EDesignation=@EDesignation, EDOH=@EDOH, EDOF=@EDOF, ESalary=@ESalary where EID='" + comboBox1.Text + "';", mc.conn);
                    cmd.Parameters.AddWithValue("@EName", textBox2.Text);
                    cmd.Parameters.AddWithValue("@EGender", comboBox2.Text);
                    cmd.Parameters.AddWithValue("@EDOB", dateTimePicker1.Value.Date);
                    cmd.Parameters.AddWithValue("@EAddress", textBox4.Text);
                    cmd.Parameters.AddWithValue("@EPH", textBox5.Text);
                    cmd.Parameters.AddWithValue("@EDesignation", textBox6.Text);
                    cmd.Parameters.AddWithValue("@EDOH", dateTimePicker2.Value.Date);
                    cmd.Parameters.AddWithValue("@EDOF", dateTimePicker3.Value.Date);
                    cmd.Parameters.AddWithValue("@ESalary", textBox7.Text);
                }
                else
                {
                    cmd = new SqlCommand("Update Emploee set EName=@EName, EGender=@EGender, EDOB=@EDOB, EAddress=@EAddress, EPH=@EPH, EDesignation=@EDesignation, EDOH=@EDOH, ESalary=@ESalary where EID='" + comboBox1.Text + "';", mc.conn);
                    cmd.Parameters.AddWithValue("@EName", textBox2.Text);
                    cmd.Parameters.AddWithValue("@EGender", comboBox2.Text);
                    cmd.Parameters.AddWithValue("@EDOB", dateTimePicker1.Value.Date);
                    cmd.Parameters.AddWithValue("@EAddress", textBox4.Text);
                    cmd.Parameters.AddWithValue("@EPH", textBox5.Text);
                    cmd.Parameters.AddWithValue("@EDesignation", textBox6.Text);
                    cmd.Parameters.AddWithValue("@EDOH", dateTimePicker2.Value.Date);
                    cmd.Parameters.AddWithValue("@ESalary", textBox7.Text);
                }
                cmd.ExecuteNonQuery();
                mc.conn.Close();
                MessageBox.Show("Emploee Updated!");
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            dateTimePicker3.Visible = true;
            mc.conn.Open();
            cmd = new SqlCommand("select * from Emploee where EID='"+comboBox1.Text+"';",mc.conn);
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                textBox2.Text = dr["EName"].ToString();
                textBox3.Text = dr["EGender"].ToString();
                dateTimePicker1.Value = Convert.ToDateTime(dr["EDOB"].ToString());
                textBox4.Text = dr["EAddress"].ToString();
                textBox5.Text = dr["EPH"].ToString();
                textBox6.Text = dr["EDesignation"].ToString();
                dateTimePicker2.Value = Convert.ToDateTime(dr["EDOH"].ToString());
                try
                {
                    dateTimePicker3.Value = Convert.ToDateTime(dr["EDOF"].ToString());
                    checkBox1.Checked = true;
                    dateTimePicker3.Enabled = false;
                }
                catch (System.FormatException ee)
                {
                    dateTimePicker3.Visible = false;
                    checkBox1.Checked = false;
                }                   
                textBox7.Text = dr["ESalary"].ToString();
            }
            mc.conn.Close();
            if (selection == "Update")
            {
                textBox3.Visible = false;
                comboBox2.Visible = true;
                comboBox2.Items.Add("Male");
                comboBox2.Items.Add("Female");
                comboBox2.Text = textBox3.Text;
                textBox3.Text = "";
            }
            
        }

        private void Emploee_Load(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(button1,"Close");
            textBox5.KeyPress += keyPress;
            textBox7.KeyPress += keyPress;
            label1.BackColor = Color.Transparent;
            this.BackColor = Color.Transparent;
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
