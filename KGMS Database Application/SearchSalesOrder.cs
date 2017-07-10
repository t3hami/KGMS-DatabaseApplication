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
    public partial class SearchSalesOrder : UserControl
    {
        MyConnection mc;
        SqlCommand cmd;
        SqlDataReader dr;
        int sno = 0;

        public SearchSalesOrder()
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

        private void SearchSalesOrder_Load(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(button1,"Close");
        }

        public void showControl()
        {
            reload();
            comboBox1.Items.Clear();
            mc = new MyConnection();
            mc.conn.Open();
            cmd = new SqlCommand("select SOID from SO where GoodsDelivered='No';", mc.conn);
            dr = cmd.ExecuteReader();
            while (dr.Read())
                comboBox1.Items.Add(dr["SOID"]);
            dr.Close();
            cmd = new SqlCommand("select count(DCID) from DC;", mc.conn);
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                sno = (Convert.ToInt32(dr[0]) + 1);
                textBox6.Text = "DC-00" + sno.ToString() + "-2017";
            }
            mc.conn.Close();

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            mc.conn.Open();
            cmd = new SqlCommand("select * from SO where SOID='"+comboBox1.Text+"';", mc.conn);
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                textBox2.Text = dr["CustomerName"].ToString();
                textBox3.Text = dr["CustomerPhone"].ToString();
                textBox4.Text = dr["CustomerAddress"].ToString();
                textBox5.Text = "Rs." + dr["Total"].ToString();
                textBox1.Text = dr["SODate"].ToString();
            }
            dr.Close();
            cmd = new SqlCommand("select * from SOProducts where SOID='"+comboBox1.Text+"';", mc.conn);
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
        }

        public void reload()
        {
            comboBox1.Text = "";
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox5.Text = "";
            dataGridView1.Rows.Clear();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            mc.conn.Open();
            cmd = new SqlCommand("update SO set GoodsDelivered='Yes' where SOID='" + comboBox1.Text + "';", mc.conn);
            cmd.ExecuteNonQuery();
            cmd = new SqlCommand("insert into DC Values(@DCID, @SOID, @DCDate, @SNO);", mc.conn);
            cmd.Parameters.AddWithValue("@DCID", textBox6.Text);
            cmd.Parameters.AddWithValue("@SOID", comboBox1.Text);
            cmd.Parameters.AddWithValue("@DCDate", System.DateTime.Now.Date);
            cmd.Parameters.AddWithValue("@SNO", sno);
            cmd.ExecuteNonQuery();
            mc.conn.Close();

            MessageBox.Show("DC Created!");
            comboBox1.Items.Remove(comboBox1.Text);
            showControl();
        }
    }
}
