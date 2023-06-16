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
    public partial class Admin_other_functions : Form
    {
        static string   connectionstring = "Data Source=OMAR\\SQLEXPRESS;Initial Catalog=supermarket2;Integrated Security=True";
        SqlConnection con = new SqlConnection(connectionstring);
        public Admin_other_functions()
        {
            InitializeComponent();
        }
        void search()
        {
            string SQL = "SELECT Pname, price, Quantity, Category FROM Product where Pname like '%" + textBox1.Text + "%'; ";
            DataTable dt = new DataTable();
            con.Open();
            SqlCommand smd = new SqlCommand(SQL, con);
            SqlDataReader rd = smd.ExecuteReader();
            dt.Load(rd);
            dataGridView1.DataSource = dt;
            con.Close();

        }

        private void button11_Click(object sender, EventArgs e)
        {
            Admin_functions form = new Admin_functions();
            form.Show();
            Close();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            string SQL = "SELECT * FROM product WHERE Quantity> 0; ";
            DataTable dt = new DataTable();
            con.Open();
            SqlCommand smd = new SqlCommand(SQL, con);
            SqlDataReader rd = smd.ExecuteReader();
            dt.Load(rd);
            dataGridView1.DataSource = dt;
            con.Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            search();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand Mycommand = new SqlCommand("SELECT * FROM Product WHERE Quantity< Restock_quantity", con);
            SqlDataAdapter dAdapter = new SqlDataAdapter(Mycommand);
            DataTable db = new DataTable();
            dAdapter.Fill(db);
            dataGridView1.ReadOnly = true;
            dataGridView1.DataSource = db;
            con.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand Mycommand = new SqlCommand("select Cname , Count(Orderid) as purchase_times from customer join Orders on Customer.cid = Orders.cid group by Cname having count(Orderid)>=3 ", con);
            SqlDataAdapter dAdapter = new SqlDataAdapter(Mycommand);
            DataTable db = new DataTable();
            dAdapter.Fill(db);
            dataGridView1.ReadOnly = true;
            dataGridView1.DataSource = db;
            con.Close();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            using (SqlConnection sqlconnection = new SqlConnection(connectionstring))
            {
                string Myquery = @"select distinct Customer.cid,Customer.cname from Customer,Orders where Customer.cId not in(select cid from Orders where Year = (select max(Orders.Year) from Orders))";
                SqlCommand mycommand = new SqlCommand(Myquery, sqlconnection);
                SqlDataAdapter dAdapter = new SqlDataAdapter(mycommand);
                DataSet ds = new DataSet();
                dAdapter.Fill(ds);
                dataGridView1.ReadOnly = true;
                dataGridView1.DataSource = ds.Tables[0];
                sqlconnection.Close();
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            SqlDataAdapter data = new SqlDataAdapter("select c.cId,c.cname,Total from Customer c, (select cId,Total from Orders o join( select  Top 1 OrderId,Sum(h.Number*p.Price)as Total from Has h Join Product p on h.pid=p.pid where h.Orderid in( Select Orderid from Orders Where Month=(select max(Orders.Month)from Orders) and Year = (select max(Orders.Year)from Orders)) Group by OrderId order by Total Desc) as p on o.Orderid=p.Orderid) o where c.cId=o.cId", con);
            DataTable dtb1 = new DataTable();
            data.Fill(dtb1);
            dataGridView1.DataSource = dtb1;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand Mycommand = new SqlCommand("select top 1 Product.Pname from product,Customer,Has,Orders where Has.Orderid=Orders.Orderid AND Has.pid=Product.pid AND Orders.cId=Customer.cId group by Product.Pname order by COUNT(Customer.cId) desc", con);
            SqlDataAdapter dAdapter = new SqlDataAdapter(Mycommand);
            DataTable db = new DataTable();
            dAdapter.Fill(db);
            dataGridView1.ReadOnly = true;
            dataGridView1.DataSource = db;
            con.Close();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (textBox2.Text == "" || textBox3.Text == "" )
            {
                MessageBox.Show("please fill the whole fields");
            }
            else
            {
                try
                {
                    con.Open();
                    SqlCommand Mycommand = new SqlCommand("select Product.Pname,Product.pid from product where Product.pid in (select Product.pid from product except select Has.pid from Has,Orders where Orders.Orderid=Has.Orderid AND Month='"+textBox2.Text+"' AND year='"+textBox3.Text+"')", con);
                    SqlDataAdapter dAdapter = new SqlDataAdapter(Mycommand);
                    DataTable db = new DataTable();
                    dAdapter.Fill(db);
                    dataGridView1.ReadOnly = true;
                    dataGridView1.DataSource = db;
                    con.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);

                }
                
            }
            
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlDataAdapter data = new SqlDataAdapter("select p.pid,Pname,Category,Price,Quantity,Restock_quantity,total as 'Total Sales' from Product p LEFT JOIN (select h.pid,count(DISTINCT  o.cid)as total from Has h,Orders o where h.Orderid=o.Orderid group by h.pid) o on p.pid=o.pid", con);
            DataTable dtb1 = new DataTable();
            data.Fill(dtb1);
            dataGridView1.DataSource = dtb1;


            foreach (DataRow row in dtb1.Rows)
            {
                object value = row["Total Sales"];
                if (value == DBNull.Value)
                    row["Total Sales"] = 0;

            }
        }

        private void Admin_other_functions_Load(object sender, EventArgs e)
        {
            SqlCommand comm = new SqlCommand();
            comm.Connection = con;
            con.Open();
            comm.CommandText = "select DISTINCT  category from Product";
            SqlDataReader reader;
            reader = comm.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Columns.Add("category", typeof(string));
            dt.Load(reader);
            comboBox1.ValueMember = "category";
            comboBox1.DataSource = dt;
            con.Close();


            SqlCommand comm2 = new SqlCommand();
            comm2.Connection = con;
            con.Open();
            comm2.CommandText = "select DISTINCT  category from Product";
            SqlDataReader reader2;
            reader2 = comm2.ExecuteReader();
            DataTable dt2 = new DataTable();
            dt2.Columns.Add("category", typeof(string));
            dt2.Load(reader2);
            comboBox2.ValueMember = "category";
            comboBox2.DataSource = dt2;
            con.Close();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            SqlDataAdapter data = new SqlDataAdapter("select Top 2 p.Category,Sum(h.Number)+0 as Total from Has h right JOIN Product p on h.pid=p.pid where( p.Category='" + comboBox1.Text.ToString() + "' or p.Category='" + comboBox2.Text.ToString() + "')  Group by p.Category order by Total Desc", con);
            DataTable dtb1 = new DataTable();
            data.Fill(dtb1);
            dataGridView1.DataSource = dtb1;
            int counter = 0;

            foreach (DataRow row in dtb1.Rows)
            {
                object value = row["Total"];
                if (value == DBNull.Value)
                    row["Total"] = 0;
                counter += 1;

            }
            if (counter == 1)
            {
                string z = dtb1.Rows[0].Field<string>("Category");
                label3.Text = "Congratulations ! you have displayed Total Number of sales for " + z + " products! Keep it up ;)";

            }
            else
            {
                int x = dtb1.Rows[0].Field<int>("Total");
                int y = dtb1.Rows[1].Field<int>("Total");

                string z = dtb1.Rows[0].Field<string>("Category");
                string w = dtb1.Rows[1].Field<string>("Category");

                if (x > y)
                {
                    label5.Text = "The super market sells " + z + " Products more than " + w + " Products";
                }
                else
                {
                    label5.Text = "The super market sells " + w + " equal to " + z + " Products";
                }

            }
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }
    }
}
