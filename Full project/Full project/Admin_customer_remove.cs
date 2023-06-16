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
    public partial class Admin_customer_remove : Form
    {
        static string connectionstring = "Data Source=OMAR\\SQLEXPRESS;Initial Catalog=supermarket2;Integrated Security=True";

        public Admin_customer_remove()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                MessageBox.Show("please fill the cId field");
            }
            else {
                SqlConnection con2 = new SqlConnection(connectionstring);
                SqlCommand data2 = new SqlCommand("select username from Customer where cId = '" + textBox1.Text + "'", con2);
                con2.Open();
                SqlDataReader reader = data2.ExecuteReader();
                if (reader.HasRows)
                {
                    con2.Close();
                    try
                    {
                        SqlConnection sqlConnection = new SqlConnection(connectionstring);
                        SqlCommand sqlCommand = new SqlCommand();
                        sqlCommand.Connection = sqlConnection;
                        sqlConnection.Open();
                        sqlCommand.CommandText = "delete from Customer where cId ='" + textBox1.Text + "' ";
                        sqlCommand.ExecuteNonQuery();
                        sqlConnection.Close();
                        MessageBox.Show("deletion for customer done succefully");
                        Admin_customer_functions form = new Admin_customer_functions();
                        form.Show();
                        Close();
                    }

                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);

                    }
                }
                else
                {
                    label2.Text = "*Wrong input";
                    con2.Close();
                }
            }

           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Admin_customer_functions form = new Admin_customer_functions();
            form.Show();
            this.Close();
        }

        private void Admin_customer_remove_Load(object sender, EventArgs e)
        {

        }
    }
}
