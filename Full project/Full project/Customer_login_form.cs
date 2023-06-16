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
    public partial class Customer_login_form : Form
    {
        static string connectionstring = "Data Source=OMAR\\SQLEXPRESS;Initial Catalog=supermarket2;Integrated Security=True";

        public Customer_login_form()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Customer__Main form = new Customer__Main();

            form.Show();

            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox5.Text == "" || textBox4.Text == "")
            {
                MessageBox.Show("please fill the whole fields");
            }
            else
            {



                /*Check user name*/
                SqlConnection con2 = new SqlConnection(connectionstring);
                SqlDataAdapter data2 = new SqlDataAdapter("select * from Customer where username = '" + textBox4.Text + "' and Cpassword = '" + textBox5.Text + "'", con2);
                con2.Open();
                try
                {
                    DataTable dtb1 = new DataTable();
                    data2.Fill(dtb1);
                    label6.Text = "";
                    int x = dtb1.Rows[0].Field<int>("cId");

                    con2.Close();

                    Customer_profile form = new Customer_profile();
                    form.set(x);
                    form.Show();
                    Close();

                }
                catch
                {
                    label6.Text = "*Worng Infromation";
                    con2.Close();
                }



            }
        }

        private void Customer_login_form_Load(object sender, EventArgs e)
        {

        }

        private void Customer_login_form_Load_1(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            if (textBox5.Text == "" || textBox4.Text == "")
            {
                MessageBox.Show("please fill the whole fields");
            }
            else
            {



                /*Check user name*/
                SqlConnection con2 = new SqlConnection(connectionstring);
                SqlDataAdapter data2 = new SqlDataAdapter("select * from Customer where username = '" + textBox4.Text + "' and Cpassword = '" + textBox5.Text + "'", con2);
                con2.Open();
                try
                {
                    DataTable dtb1 = new DataTable();
                    data2.Fill(dtb1);
                    label6.Text = "";
                    int x = dtb1.Rows[0].Field<int>("cId");

                    con2.Close();

                    Customer_profile form = new Customer_profile();
                    form.set(x);
                    form.Show();
                    Close();

                }
                catch
                {
                    label6.Text = "*Worng Infromation";
                    con2.Close();
                }

            }
        }
    }
}
