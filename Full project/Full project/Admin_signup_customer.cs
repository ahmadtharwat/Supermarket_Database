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
    public partial class Admin_signup_customer : Form
    {
        static string connectionstring = "Data Source=OMAR\\SQLEXPRESS;Initial Catalog=supermarket2;Integrated Security=True";
        SqlConnection sqlConnection = new SqlConnection(connectionstring);
        public Admin_signup_customer()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Admin_customer_functions form = new Admin_customer_functions();
            form.Show();
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if ( textBox22.Text == "" || textBox32.Text == "" || textBox42.Text == "" || textBox62.Text == "")
            {
                MessageBox.Show("please fill the whole fields");
            }
            else
            {


                try
                {
                    /*Check user name*/
                    SqlConnection con2 = new SqlConnection(connectionstring);
                    SqlCommand data2 = new SqlCommand("select username from Customer where username = '" + textBox22.Text + "'", con2);
                    con2.Open();
                    SqlDataReader reader = data2.ExecuteReader();
                    if (reader.HasRows)
                    {
                        label2.Text = "*This user name already exists";
                        con2.Close();
                    }




                    else
                    {
                        /********************/
                       
                            con2.Close();
                            label2.Text = "";
                            SqlCommand sqlCommand = new SqlCommand();
                            sqlCommand.Connection = sqlConnection;
                            sqlConnection.Open();
                            sqlCommand.CommandText = "insert into Customer (Address,cname,Cpassword ,username) values('" + textBox62.Text + "', '" + textBox42.Text + "', '" + textBox32.Text + "', '" + textBox22.Text + "')";
                            sqlCommand.ExecuteNonQuery();
                            sqlConnection.Close();
                            MessageBox.Show("insertion for customer done succefully");


                            Admin_customer_functions form = new Admin_customer_functions();
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

        private void Admin_signup_customer_Load(object sender, EventArgs e)
        {

        }
    }
}