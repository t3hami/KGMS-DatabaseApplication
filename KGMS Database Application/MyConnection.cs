using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data.Sql;

namespace KGMS_Database_Application
{
    public partial class MyConnection : Form
    {
        public SqlConnection conn;
        public MyConnection()
        {
            InitializeComponent();
            conn = new SqlConnection();
            conn.ConnectionString =
            "Data Source=DESKTOP-QS7KFTJ;" +
            "Initial Catalog=KGMS;" +
            "User id=sa;" +
            "Password=123;";
        }
    }
}
