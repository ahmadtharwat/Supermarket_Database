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
  
    public partial class Customer_update_profile : Form
    {
        static string connectionstring = "Data Source=OMAR\\SQLEXPRESS;Initial Catalog=supermarket2;Integrated Security=True";

        int id1;
        public Customer_update_profile()
        {
            InitializeComponent();
        }
        public void set(int id,string username,string name,string pass,string add)
        {
            id1 = id;
            textBox2.Text = username;
            textBox3.Text = pass;
            textBox4.Text = name;
            textBox5.Text = add;
        }

        private void Customer_update_profile_Load(object sender, EventArgs e)
        {
            label5.Text = id1.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "" || textBox5.Text == "" || textBox5.Text == "")
            {
                MessageBox.Show("please fill the whole fields");
            }

            else
            {
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

                    Customer_profile form = new Customer_profile();
                    form.set(id1);
                    form.Show();
                    Close();
                }

                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);

                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Customer_profile form = new Customer_profile();
            form.set(id1);
            form.Show();
            form.Close();
        }

        
    }
}
