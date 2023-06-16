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
    public partial class Admin_product_add : Form
    {
        static string connectionstring = "Data Source=OMAR\\SQLEXPRESS;Initial Catalog=supermarket2;Integrated Security=True";
        SqlConnection sqlConnection = new SqlConnection(connectionstring);
        public Admin_product_add()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "" || textBox5.Text == "")
            {
                MessageBox.Show("please fill the whole fields");
            }
            else
            {


                try
                {
                    /*Check user name*/
                    SqlConnection con2 = new SqlConnection(connectionstring);
                    SqlCommand data2 = new SqlCommand("select pname from Product where Pname = '" + textBox5.Text + "'", con2);
                    con2.Open();
                    SqlDataReader reader = data2.ExecuteReader();
                    if (reader.HasRows)
                    {
                        label6.Text = "*Another product exist with the same name";
                        con2.Close();
                    }




                    else
                    {
                        /********************/

                        con2.Close();
                        label6.Text = "";

                        SqlCommand sqlCommand = new SqlCommand();
                        sqlCommand.Connection = sqlConnection;
                        sqlConnection.Open();
                        sqlCommand.CommandText = "insert into Product (Price,Quantity,Restock_quantity,Category,Pname) values('" + textBox5.Text + "', '" + textBox2.Text + "', '" + textBox3.Text + "', '" + textBox4.Text + "' ,'" + textBox1.Text + "')";
                        sqlCommand.ExecuteNonQuery();
                        sqlConnection.Close();
                        MessageBox.Show("insertion for product done succefully");


                        Admin_product_function form = new Admin_product_function();
                        form.Show();
                        Close();
                    }






                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);

                }

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Admin_product_function form = new Admin_product_function();
            form.Show();
            Close();
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
