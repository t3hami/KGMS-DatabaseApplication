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
    public partial class SearchPurchaseOrder : UserControl
    {
        MyConnection mc;
        SqlCommand cmd;
        SqlDataReader dr;
        int sno=0;
        int count = 0;
        int[] quantity = new int[100];
        string[] pid = new string[100];

        public SearchPurchaseOrder()
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

        private void SearchPurchaseOrder_Load(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(button1,"Close");
        }

        public void showControl()
        {
            reload();
            comboBox1.Items.Clear();
            mc = new MyConnection();
            mc.conn.Open();
            cmd = new SqlCommand("select POID from PO where GoodsReceived='No' and POStatus='Open';", mc.conn);
            dr = cmd.ExecuteReader();
            while (dr.Read())
                comboBox1.Items.Add(dr["POID"]);
            dr.Close();
            cmd = new SqlCommand("select count(GRNID) from GRN;", mc.conn);
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                sno = (Convert.ToInt32(dr[0]) + 1);
                textBox7.Text = "GRN-00" + sno.ToString() + "-2017";
            }
            mc.conn.Close();

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            mc.conn.Open();
            cmd = new SqlCommand("select * from PO where POID='"+comboBox1.Text+"';", mc.conn);
            dr = cmd.ExecuteReader();
            string vendorID="";
            if (dr.Read())
            {
                vendorID = dr["VID"].ToString();
                textBox1.Text = dr["PODate"].ToString();
                textBox6.Text = dr["DeliveryDate"].ToString();
                textBox5.Text = "Rs." + dr["Total"].ToString();
            }
            dr.Close();
            cmd = new SqlCommand("select VName, VContactPerson, VAddress from Vendor where VID='"+vendorID+"';",mc.conn);
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                textBox2.Text = dr["VName"].ToString();
                textBox3.Text = dr["VContactPerson"].ToString();
                textBox4.Text = dr["VAddress"].ToString();
            }
            dr.Close();
            cmd = new SqlCommand("select * from POProducts where POID='"+comboBox1.Text+"';", mc.conn);
            dr = cmd.ExecuteReader();
            
            while (dr.Read())
            {
                quantity[count] = Convert.ToInt32(dr["POPQuantity"]);
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

        public void reload()
        {
            comboBox1.Text = "";
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox5.Text = "";
            textBox6.Clear();
            dataGridView1.Rows.Clear();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            mc.conn.Open();
            cmd = new SqlCommand("update PO set GoodsReceived='Yes' where POID='"+comboBox1.Text+"';", mc.conn);
            cmd.ExecuteNonQuery();
            cmd = new SqlCommand("insert into GRN Values(@GRNID, @POID, @GRDate, @SNO);", mc.conn);
            cmd.Parameters.AddWithValue("@GRNID", textBox7.Text);
            cmd.Parameters.AddWithValue("@POID", comboBox1.Text);
            cmd.Parameters.AddWithValue("@GRDate", System.DateTime.Now.Date);
            cmd.Parameters.AddWithValue("@SNO", sno);
            cmd.ExecuteNonQuery();
            for (int i = 0; i < count; i++)
            {
                cmd = new SqlCommand("select PQuantity from Products where PID=@PID;", mc.conn);
                cmd.Parameters.AddWithValue("@PID", pid[i]);
                dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    SqlCommand cmd1 = new SqlCommand("update Products set PQuantity=@PQuantity where PID=@PID;", mc.conn);
                    cmd1.Parameters.AddWithValue("@PQuantity", (Convert.ToInt32(dr["PQuantity"]) + quantity[i]).ToString());
                    cmd1.Parameters.AddWithValue("@PID", pid[i]);
                    dr.Close();
                    cmd1.ExecuteNonQuery();
                }
            }

            mc.conn.Close();

            MessageBox.Show("GRN Created!");
            comboBox1.Items.Remove(comboBox1.Text);
            showControl();

        }

    }
}
