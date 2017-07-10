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
    public partial class InvoicePayable : UserControl
    {
        MyConnection mc;
        SqlCommand cmd;
        SqlDataReader dr;
        double total = 0;
        double totalWithTax = 0;

        public InvoicePayable()
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
            Program.f2.setLocation();
        }

        private void DC_Load(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(button1,"Close");
        }

        public void reload()
        {
            comboBox1.Items.Clear();
            mc = new MyConnection();
            mc.conn.Open();
            cmd = new SqlCommand("select POID from PO where GoodsReceived='Yes' and POStatus='Open';", mc.conn);
            dr = cmd.ExecuteReader();
            string[] poid = new string[100];
            int count = 0;
            while (dr.Read())
            {
                poid[count] = dr["POID"].ToString();
                count++;
            }
            dr.Close();
            for (int i = 0; i < count; i++)
            {
                cmd = new SqlCommand("select GRNID from GRN where POID='" + poid[i] + "';", mc.conn);
                dr = cmd.ExecuteReader();
                if (dr.Read())
                    comboBox1.Items.Add(dr["GRNID"]);
                dr.Close();
            }
            cmd = new SqlCommand("select count(IPID) from InvoicePayable;",mc.conn);
            dr = cmd.ExecuteReader();
            if (dr.Read())
                textBox1.Text = (Convert.ToInt32(dr[0]) + 1).ToString();

            mc.conn.Close();
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            textBox7.Text = "";
            textBox8.Text = "";
            comboBox1.Text = "";
            dataGridView1.Rows.Clear();
            button2.Enabled = false;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            mc.conn.Open();
            cmd = new SqlCommand("select * from GRN where GRNID='"+comboBox1.Text+"';", mc.conn);
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                textBox5.Text = dr["GRDate"].ToString();
                textBox6.Text = dr["POID"].ToString();

            }
            dr.Close();
            cmd = new SqlCommand("select * from PO where POID='" + textBox6.Text + "';", mc.conn);
            dr = cmd.ExecuteReader();
            string vid = "";
            if (dr.Read())
            {
                vid = dr["VID"].ToString();
                total = Convert.ToInt32(dr["Total"]);
                textBox7.Text = "Rs." + total.ToString();
                totalWithTax = total + total * 0.17;
                textBox8.Text = "Rs." + totalWithTax.ToString();
            }
            dr.Close();
            cmd = new SqlCommand("select VName, VContactPerson, VAddress from Vendor where VID='"+vid+"';", mc.conn);
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                textBox2.Text = dr["VName"].ToString();
                textBox3.Text = dr["VContactPerson"].ToString();
                textBox4.Text = dr["VAddress"].ToString();
            }
            dr.Close();
            cmd = new SqlCommand("select * from POProducts where POID='" + textBox6.Text + "';", mc.conn);
            dr = cmd.ExecuteReader();
            int count = 0;
            string[] quantity = new string[100];
            string[] pid = new string[100];
            while (dr.Read())
            {
                quantity[count] = dr["POPQuantity"].ToString();
                pid[count] = dr["PID"].ToString();
                count++;
            }
            dr.Close();
            dataGridView1.Rows.Clear();
            for (int i = 0; i < count; i++)
            {
                SqlCommand cmd1 = new SqlCommand("select PName, SalesPrice from Products where PID='" + pid[i] + "';", mc.conn);
                SqlDataReader dr1 = cmd1.ExecuteReader();
                if (dr1.Read())
                {
                    dataGridView1.Rows.Add(dr1["PName"], quantity[i], (Convert.ToInt32(quantity[i]) * Convert.ToInt32(dr1["SalesPrice"])).ToString());
                }
                dr1.Close();
            }

            mc.conn.Close();
            button2.Enabled = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            mc.conn.Open();
            cmd = new SqlCommand("update PO set POStatus='Close' where POID='"+textBox6.Text+"';", mc.conn);
            cmd.ExecuteNonQuery();
            cmd = new SqlCommand("insert into InvoicePayable(GRNID, IPDate) Values(@GRNID, @IPDate);", mc.conn);
            cmd.Parameters.AddWithValue("@GRnID", comboBox1.Text);
            cmd.Parameters.AddWithValue("@IPDate", System.DateTime.Now.Date);
            cmd.ExecuteNonQuery();
            mc.conn.Close();
            MessageBox.Show("Invoice Payable created!");
            comboBox1.Items.Remove(comboBox1.Text);
            reload();
        }
    }
}
