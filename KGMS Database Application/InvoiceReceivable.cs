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
    public partial class InvoiceReceivable : UserControl
    {
        MyConnection mc;
        SqlCommand cmd;
        SqlDataReader dr;
        double total = 0;
        double totalWithTax = 0;

        public InvoiceReceivable()
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
            cmd = new SqlCommand("select SOID from SO where GoodsDelivered='Yes' and SOStatus='Open';", mc.conn);
            dr = cmd.ExecuteReader();
            string[] soid = new string[100];
            int count = 0;
            while (dr.Read())
            {
                soid[count] = dr["SOID"].ToString();
                count++;
            }
            dr.Close();
            for (int i = 0; i < count; i++)
            {
                cmd = new SqlCommand("select DCID from DC where SOID='" + soid[i] + "';", mc.conn);
                dr = cmd.ExecuteReader();
                if (dr.Read())
                    comboBox1.Items.Add(dr["DCID"]);
                dr.Close();
            }
            cmd = new SqlCommand("select count(IRID) from InvoiceReceivable;",mc.conn);
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
            cmd = new SqlCommand("select * from DC where DCID='"+comboBox1.Text+"';", mc.conn);
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                textBox5.Text = dr["DCDate"].ToString();
                textBox6.Text = dr["SOID"].ToString();

            }
            dr.Close();
            cmd = new SqlCommand("select * from SO where SOID='" + textBox6.Text + "';", mc.conn);
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                textBox2.Text = dr["CustomerName"].ToString();
                textBox3.Text = dr["CustomerPhone"].ToString();
                textBox4.Text = dr["CustomerAddress"].ToString();
                total = Convert.ToInt32(dr["Total"]);
                textBox7.Text = "Rs." + total.ToString();
                totalWithTax = total + total * 0.17;
                textBox8.Text = "Rs." + totalWithTax.ToString();
            }
            dr.Close();
            cmd = new SqlCommand("select * from SOProducts where SOID='" + textBox6.Text + "';", mc.conn);
            dr = cmd.ExecuteReader();
            int count = 0;
            string[] quantity = new string[100];
            string[] pid = new string[100];
            while (dr.Read())
            {
                quantity[count] = dr["SOPQuantity"].ToString();
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
            cmd = new SqlCommand("update SO set SOStatus='Close' where SOID='"+textBox6.Text+"';", mc.conn);
            cmd.ExecuteNonQuery();
            cmd = new SqlCommand("insert into InvoiceReceivable(DCID, IRDate) Values(@DCID, @IRDate);", mc.conn);
            cmd.Parameters.AddWithValue("@DCID", comboBox1.Text);
            cmd.Parameters.AddWithValue("@IRDate", System.DateTime.Now.Date);
            cmd.ExecuteNonQuery();
            mc.conn.Close();
            MessageBox.Show("Invoice Receivable created!");
            comboBox1.Items.Remove(comboBox1.Text);
            reload();
        }
    }
}
