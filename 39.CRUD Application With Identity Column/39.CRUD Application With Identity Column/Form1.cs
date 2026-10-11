using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.Data.SqlClient;

namespace _39.CRUD_Application_With_Identity_Column
{
    public partial class Form1 : Form
    {
        int i;
        string cs = ConfigurationManager.ConnectionStrings["dbcs"].ConnectionString;
        
        public Form1()
        {
            InitializeComponent();
            BindGridView();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(cs);
            string query = "insert into product_tbl values(@name,@company,@cat,@price,@stalk)";
            SqlCommand cmd= new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@name", textBox1.Text);
            cmd.Parameters.AddWithValue("@company", textBox2.Text);
            cmd.Parameters.AddWithValue("@cat", textBox3.Text);
            cmd.Parameters.AddWithValue("@price", textBox4.Text);
            cmd.Parameters.AddWithValue("@stalk", textBox5.Text);
            con.Open();
            int a = cmd.ExecuteNonQuery();

            if (a>0)
            {
                MessageBox.Show("Inserted !!");
                BindGridView();
                ResetControls();

            }
            else
            {
                MessageBox.Show("Not Inserted !!");

            }
            con.Close();

        }
        void BindGridView()
            {
                SqlConnection con = new SqlConnection(cs);
                string query = "select * from product_tbl";
                SqlDataAdapter sda = new SqlDataAdapter(query, con);
                DataTable data=new DataTable();
                sda.Fill(data);
                dataGridView1.DataSource = data;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                }

        private void dataGridView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            i = Convert.ToInt32 (dataGridView1.SelectedRows[0].Cells[0].Value);
            textBox1.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            textBox2.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
            textBox3.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
            textBox4.Text = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();
            textBox5.Text = dataGridView1.SelectedRows[0].Cells[5].Value.ToString();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(cs);
            string query = "update product_tbl set name=@name,company=@company,category=@cat,price=@price,stalk=@stalk where id=@id";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@id", i);
            cmd.Parameters.AddWithValue("@name", textBox1.Text);
            cmd.Parameters.AddWithValue("@company", textBox2.Text);
            cmd.Parameters.AddWithValue("@cat", textBox3.Text);
            cmd.Parameters.AddWithValue("@price", textBox4.Text);
            cmd.Parameters.AddWithValue("@stalk", textBox5.Text);
            con.Open();
            int a = cmd.ExecuteNonQuery();

            if (a > 0)
            {
                MessageBox.Show("Updated !!");
                BindGridView();
                ResetControls();

            }
            else
            {
                MessageBox.Show("Not Updated !!");

            }
            con.Close();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(cs);
            string query = "delete from product_tbl  where id=@id";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@id", i);
          
            con.Open();
            int a = cmd.ExecuteNonQuery();

            if (a > 0)
            {
                MessageBox.Show("Deleted !!");
                BindGridView();
                ResetControls();

            }
            else
            {
                MessageBox.Show("Not Deleted !!");

            }
            con.Close();
        }
        void ResetControls()
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
       

        }
    }
}
