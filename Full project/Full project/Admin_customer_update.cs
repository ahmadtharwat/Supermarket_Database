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
    public partial class Admin_customer_update : Form
    {
        static string connectionstring = "Data Source=OMAR\\SQLEXPRESS;Initial Catalog=supermarket2;Integrated Security=True";
        public Admin_customer_update()
        {
            InitializeComponent();
        }

        private void Admin_customer_update_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Admin_customer_functions form = new Admin_customer_functions();
            form.Show();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "" || textBox5.Text == "" || textBox5.Text == "" || textBox1.Text == "")
            {
                MessageBox.Show("please fill the whole fields");
            }

            else
            {
                 SqlConnection con2 = new SqlConnection(connectionstring);
                SqlCommand data2 = new SqlCommand("select username from Customer where cId = '" + textBox1.Text + "'", con2);
                con2.Open();
                SqlDataReader reader = data2.ExecuteReader();
                if (reader.HasRows)
                {
                    label5.Text = "";
                    con2.Close();
                     con2 = new SqlConnection(connectionstring);
                     data2 = new SqlCommand("select username from Customer where username = '" + textBox2.Text + "' and cId !='"+textBox1.Text+"'", con2);
                    con2.Open();
                     reader = data2.ExecuteReader();
                    if (reader.HasRows)
                    {
                        label7.Text = "*This user name already exists";
                        con2.Close();
                    }
                    else
                    {
                        con2.Close();
                        string id1 = textBox1.Text;
                        try
                        {

                            SqlConnection sqlConnection = new SqlConnection(connectionstring);
                            SqlCommand sqlCommand = new SqlCommand();
                            sqlCommand.Connection = sqlConnection;
                            sqlConnection.Open();
                            sqlCommand.CommandText = "update Customer   set Address='" + textBox5.Text + "'     where cId ='" + id1 + "' ";
                            sqlCommand.ExecuteNonQuery();
                            sqlCommand.CommandText = "update Customer   set cname='" + textBox4.Text + "'     where cId ='" + id1 + "' ";
                            sqlCommand.ExecuteNonQuery();
                            sqlCommand.CommandText = "update Customer   set Cpassword='" + textBox3.Text + "'     where cId ='" + id1 + "' ";
                            sqlCommand.ExecuteNonQuery();
                            sqlCommand.CommandText = "update Customer   set username='" + textBox2.Text + "'     where cId ='" + id1 + "' ";
                            sqlCommand.ExecuteNonQuery();
                            sqlConnection.Close();
                            MessageBox.Show("update has been done succefully");

                            Admin_customer_functions form = new Admin_customer_functions();
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
                    label5.Text = "*This id does not Exist";
                    con2.Close();
                }
            }


        }
    }
}