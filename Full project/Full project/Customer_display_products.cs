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

namespace Full_project
{
    public partial class Customer_display_products : Form
    {
        string connectionstring = "Data Source=OMAR\\SQLEXPRESS;Initial Catalog=supermarket2;Integrated Security=True";

        public Customer_display_products()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
             string SQL = "select Pname,Category,Price,Quantity from Product WHERE Quantity> 0; ";
            DataTable dt = new DataTable();
            SqlConnection con = new SqlConnection(connectionstring);
            con.Open();
            SqlCommand smd = new SqlCommand(SQL, con);
            SqlDataReader rd = smd.ExecuteReader();
            dt.Load(rd);
            dataGridView1.DataSource = dt;
            con.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var form = (Customer_profile)Tag;
            form.Show();
            Hide();
        }
    }
}
