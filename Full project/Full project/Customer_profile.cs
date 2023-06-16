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
    public partial class Customer_profile : Form
    {
        static string connectionstring = "Data Source=OMAR\\SQLEXPRESS;Initial Catalog=supermarket2;Integrated Security=True";

        string  add, name, username,password;
        int id;
        public Customer_profile()
        {
            InitializeComponent();
        }
        public void set(int x)
        {
            SqlConnection con2 = new SqlConnection(connectionstring);
            SqlDataAdapter data2 = new SqlDataAdapter("select * from Customer where cId = "+x, con2);
                con2.Open();
                
                    DataTable dtb1 = new DataTable();
                    data2.Fill(dtb1);
                   
                    id = dtb1.Rows[0].Field<int>("cId");
                    name = dtb1.Rows[0].Field<string>("cname");
                    add  = dtb1.Rows[0].Field<string>("Address");
                    username = dtb1.Rows[0].Field<string>("username");
                    password = dtb1.Rows[0].Field<string>("Cpassword");
            
        }

        

        private void Customer_profile_Load(object sender, EventArgs e)
        {
            label5.Text = id.ToString();
            label6.Text = username;
            label7.Text = name;
            label8.Text = add;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Customer__Main form = new Customer__Main();

            form.Show();

            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Customer_update_profile form = new Customer_update_profile();
            form.set(id,username,name,password,add);
            form.Show();
            Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection sqlConnection = new SqlConnection(connectionstring);
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = sqlConnection;
                sqlConnection.Open();
                sqlCommand.CommandText = "delete from Customer where cId ='" + id + "' ";
                sqlCommand.ExecuteNonQuery();
                sqlConnection.Close();
                MessageBox.Show("deletion has beeen done succefully");
                Customer__Main form = new Customer__Main();

                form.Show();

                Close();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Customer_Search_product form = new Customer_Search_product();
            form.Tag= this;
            form.Show();
            Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Customer_display_products form = new Customer_display_products();
            form.Tag = this;
            form.Show();
            Hide();
        }
    }
}
