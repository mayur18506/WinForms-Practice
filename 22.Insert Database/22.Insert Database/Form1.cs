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
using System.Configuration;

namespace _22.Insert_Database
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox1.Text) == true)
            {
                textBox1.Focus();
                errorProvider1.SetError(this.textBox1, "Please fill the Id");
            }
            else if (string.IsNullOrEmpty(textBox2.Text) == true)
            {
                textBox1.Focus();
                errorProvider2.SetError(this.textBox2, "Please fill the Name");
            }
            else if (comboBox1.SelectedItem == null)
            {
                comboBox1.Focus();
                errorProvider3.SetError(this.comboBox1, "Please select Gender");
            }
            else if (string.IsNullOrEmpty(textBox4.Text) == true)
            {
                textBox4.Focus();
                errorProvider4.SetError(this.textBox4, "Please fill the Address");
            }
            else
            {
            
            string cs = ConfigurationManager.ConnectionStrings["dbcs"].ConnectionString;

            SqlConnection con = new SqlConnection(cs);

            string query2 = "select * from customer where C_ID =@cid";
            SqlCommand cmd2= new SqlCommand(query2, con);
            cmd2.Parameters.AddWithValue("@cid", textBox1.Text);
            con.Open();
            SqlDataReader rd= cmd2.ExecuteReader();   //Select Statement

            if (rd.HasRows == true)
            {
                MessageBox.Show(textBox1.Text + "id already exist !!");
            }
            else
            {
                con.Close();
                string query = "insert into customer values (@cid,@cname,@cgender,@cadd)";

                SqlCommand cmd = new SqlCommand(query, con);

                cmd.Parameters.AddWithValue("@cid", textBox1.Text);
                cmd.Parameters.AddWithValue("@cname", textBox2.Text);
                cmd.Parameters.AddWithValue("@cgender", comboBox1.SelectedItem);
                cmd.Parameters.AddWithValue("@cadd", textBox4.Text);

                con.Open();

                int a = cmd.ExecuteNonQuery();    // insert, update, delete
                if (a > 0)
                {
                    MessageBox.Show("Customer has been Added !!");
                }
                else
                {
                    MessageBox.Show("Customer insertion Failed !!");

                }
                con.Close();
            }

            }

        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox1.Text) == true)
            {
                textBox1.Focus();
                errorProvider1.SetError(this.textBox1, "Please fill the Id");
            }
            else
            {
                errorProvider1.Clear();
            }
        }

        private void textBox2_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox2.Text) == true)
            {
                textBox1.Focus();
                errorProvider2.SetError(this.textBox2, "Please fill the Name");
            }
            else
            {
                errorProvider2.Clear();
            }
        }

        private void comboBox1_Leave(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem == null)
            {
                comboBox1.Focus();
                errorProvider3.SetError(this.comboBox1, "Please select Gender");
            }
            else
            {
                errorProvider3.Clear();
            }
        }

        private void textBox4_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox4.Text) == true)
            {
                textBox4.Focus();
                errorProvider4.SetError(this.textBox4, "Please fill the Address");
            }
            else
            {
                errorProvider4.Clear();
            }
        }
    }
}