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
    public partial class Admin_product_function : Form
    {
        static string connectionstring = "Data Source=OMAR\\SQLEXPRESS;Initial Catalog=supermarket2;Integrated Security=True";

        SqlConnection con = new SqlConnection(connectionstring);
        public Admin_product_function()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Admin_functions form = new Admin_functions();
            form.Show();
            Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Admin_product_update form = new Admin_product_update();
            form.Show();
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Admin_product_add form = new Admin_product_add();
            form.Show();
            Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Admin_product_remove form = new Admin_product_remove();
            form.Show();
            Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string SQL = "select * from Product; ";
            DataTable dt = new DataTable();

            con.Open();
            SqlCommand smd = new SqlCommand(SQL, con);
            SqlDataReader rd = smd.ExecuteReader();
            dt.Load(rd);
            dataGridView1.DataSource = dt;
            con.Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
