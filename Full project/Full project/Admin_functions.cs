using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Full_project
{
    public partial class Admin_functions : Form
    {
        public Admin_functions()
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
            Admin_customer_functions form = new Admin_customer_functions();
            form.Show();
            Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Admin_other_functions form = new Admin_other_functions();
            form.Show();
            Close();
        }

        private void Admin_functions_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Admin_product_function form = new Admin_product_function();
            form.Show();
            Close();
        }
    }
}
