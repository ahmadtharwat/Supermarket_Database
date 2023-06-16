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
    public partial class Customer_Search_product : Form
    {
        static string connectionstring = "Data Source=OMAR\\SQLEXPRESS;Initial Catalog=supermarket2;Integrated Security=True";

        public Customer_Search_product()
        {
            InitializeComponent();
        }
        void search()
        {
            string SQL = "SELECT Pname, price, Quantity, Category FROM Product where Pname like '%" + textBox1.Text + "%'; ";
            DataTable dt = new DataTable();
            SqlConnection con = new SqlConnection("Data Source=OMAR\\SQLEXPRESS;Initial Catalog=supermarket2;Integrated Security=True");
            con.Open();
            SqlCommand smd = new SqlCommand(SQL, con);
            SqlDataReader rd = smd.ExecuteReader();
            dt.Load(rd);
            dataGridView1.DataSource = dt;
            con.Close();

        }
        private void Form1_Load(object sender, EventArgs e)
        {
            string SQL = "SELECT Pname, price, Quantity, Category FROM Product";
            DataTable dt = new DataTable();
            SqlConnection con = new SqlConnection(connectionstring);
            con.Open();
            SqlCommand smd = new SqlCommand(SQL, con);
            SqlDataReader rd = smd.ExecuteReader();
            dt.Load(rd);
            dataGridView1.DataSource = dt;
            con.Close();

        }

     

        private void Customer_Search_product_TextChanged(object sender, EventArgs e)
        {
            search();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var form = (Customer_profile)Tag;
            form.Show();
            Hide();
        }
    }
}
