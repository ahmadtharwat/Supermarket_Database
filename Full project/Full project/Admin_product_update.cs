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
    public partial class Admin_product_update : Form
    {
        static string connectionstring = "Data Source=OMAR\\SQLEXPRESS;Initial Catalog=supermarket2;Integrated Security=True";
        public Admin_product_update()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "" || textBox5.Text == "" || textBox5.Text == "" || textBox1.Text == "" || textBox6.Text == "")
            {
                MessageBox.Show("please fill the whole fields");
            }

            else
            {
                SqlConnection con2 = new SqlConnection(connectionstring);
                SqlCommand data2 = new SqlCommand("select pid from Product where pid = '" + textBox6.Text + "'", con2);
                con2.Open();
                SqlDataReader reader = data2.ExecuteReader();
                if (reader.HasRows)
                {
                    label7.Text = "";
                    con2.Close();
                    con2 = new SqlConnection(connectionstring);
                    data2 = new SqlCommand("select Pname from Product where Pname = '" + textBox5.Text + "' and pid !='" + textBox6.Text + "'", con2);
                    con2.Open();
                    reader = data2.ExecuteReader();
                    if (reader.HasRows)
                    {
                        label6.Text = "*This Product Name already exists";
                        con2.Close();
                    }
                    else
                    {
                        con2.Close();
                        string id1 = textBox6.Text;
                        try
                        {

                            SqlConnection sqlConnection = new SqlConnection(connectionstring);
                            SqlCommand sqlCommand = new SqlCommand();
                            sqlCommand.Connection = sqlConnection;
                            sqlConnection.Open();
                            sqlCommand.CommandText = "update Product   set Pname='" + textBox5.Text + "'     where pid ='" + id1 + "' ";
                            sqlCommand.ExecuteNonQuery();
                            sqlCommand.CommandText = "update Product   set Quantity='" + textBox2.Text + "'     where pid ='" + id1 + "' ";
                            sqlCommand.ExecuteNonQuery();
                            sqlCommand.CommandText = "update Product   set Restock_quantity='" + textBox3.Text + "'     where pid ='" + id1 + "' ";
                            sqlCommand.ExecuteNonQuery();
                            sqlCommand.CommandText = "update Product   set Category='" + textBox4.Text + "'     where pid ='" + id1 + "' ";
                            sqlCommand.ExecuteNonQuery();
                            sqlCommand.CommandText = "update Product   set Price='" + textBox1.Text + "'     where pid ='" + id1 + "' ";
                            sqlCommand.ExecuteNonQuery();
                            sqlConnection.Close();
                            MessageBox.Show("update has been done succefully");

                            Admin_product_function form = new Admin_product_function();
                            form.Show();
                            Close();
                        }

                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);

                        }
                    }

                }
                else
                {
                    label7.Text = "*This id does not Exist";
                    con2.Close();
                }
            }
        }

        private void Admin_product_update_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Admin_product_function form = new Admin_product_function();
            form.Show();
            this.Close();
        }
    }
}