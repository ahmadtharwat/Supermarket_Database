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
    public partial class Admin_login_form : Form
    {
        static string connectionstring = "Data Source=OMAR\\SQLEXPRESS;Initial Catalog=supermarket2;Integrated Security=True";

        public Admin_login_form()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox51.Text == "" || textBox41.Text == "")
            {
                MessageBox.Show("please fill the whole fields");
            }
            else
            {



                /*Check user name*/
                SqlConnection con2 = new SqlConnection(connectionstring);
                SqlDataAdapter data2 = new SqlDataAdapter("select * from Admins where Name = '" + textBox41.Text + "' and Apassword = '" + textBox51.Text + "'", con2);
                con2.Open();
                try
                {
                    DataTable dtb1 = new DataTable();
                    data2.Fill(dtb1);
                    label61.Text = "";


                    con2.Close();

                    Admin_functions form = new Admin_functions();
                    form.Show();
                    Close();

                }
                catch
                {
                    label61.Text = "*Worng Infromation";
                    con2.Close();
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Main form = new Main();

            form.Show();

            Close();
        }

        private void Admin_login_form_Load(object sender, EventArgs e)
        {

        }
    }
}