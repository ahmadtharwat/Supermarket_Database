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
    
    public partial class Admin_customer_functions : Form
    {
        static string connectionstring = "Data Source=OMAR\\SQLEXPRESS;Initial Catalog=supermarket2;Integrated Security=True";

        SqlConnection con = new SqlConnection(connectionstring);
        public Admin_customer_functions()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string SQL = "select * from Customer; ";
            DataTable dt = new DataTable();
            
            con.Open();
            SqlCommand smd = new SqlCommand(SQL, con);
            SqlDataReader rd = smd.ExecuteReader();
            dt.Load(rd);
            dataGridView1.DataSource = dt;
            con.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Admin_functions form = new Admin_functions();
            form.Show();
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Admin_signup_customer form = new Admin_signup_customer();
            form.Show();
            Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Admin_customer_update form = new Admin_customer_update();
            form.Show();
            Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Admin_customer_remove form = new Admin_customer_remove();
            form.Show();
            Close();
        }

        private void Admin_customer_functions_Load(object sender, EventArgs e)
        {

        }
    }
}
