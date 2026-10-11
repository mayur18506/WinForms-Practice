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

namespace _29.CRUD_APPLICATION_USING_LISTBOX
{
    public partial class Form1 : Form
    {
        string cs = ConfigurationManager.ConnectionStrings["dbcs"].ConnectionString;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Fill_ListBox();
        }

        void Fill_ListBox()
        {
            listBox1.Items.Clear();
            SqlConnection con = new SqlConnection(cs);
            string query = "select name from sports";
            SqlCommand cmd = new SqlCommand(query,con);
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                string name = dr.GetString(0);
                listBox1.Items.Add(name);
            }
            con.Close();
            listBox1.Sorted = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(cs);
            string query = "insert into sports values(@name)";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@name",textBox1.Text);
            con.Open();
             int a = cmd.ExecuteNonQuery();
            if (a>0)
            {
                MessageBox.Show("Inserted !!");
                Fill_ListBox();
                textBox1.Clear();
                textBox1.Focus();
            }
            else
            {
                MessageBox.Show("Not Inserted !!");

            }
            con.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(cs);
            string query = "update sports set name = @name where name = @name1";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@name", textBox1.Text);
            cmd.Parameters.AddWithValue("@name1", listBox1.SelectedItem);

            con.Open();
            int a = cmd.ExecuteNonQuery();
            if (a > 0)
            {
                MessageBox.Show("Updated !!");
                Fill_ListBox();
                textBox1.Clear();
                textBox1.Focus();

            }
            else
            {
                MessageBox.Show("Not Updated !!");

            }
            con.Close();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox1.Text = listBox1.SelectedItem.ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(cs);
            string query = "delete from sports where name = @name  ";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@name", listBox1.SelectedItem);

            con.Open();
            int a = cmd.ExecuteNonQuery();
            if (a > 0)
            {
                MessageBox.Show("Deleted !!");
                Fill_ListBox();
                textBox1.Clear();
                textBox1.Focus();

            }
            else
            {
                MessageBox.Show("Not Deleted !!");

            }
            con.Close();
        }
    }
}
