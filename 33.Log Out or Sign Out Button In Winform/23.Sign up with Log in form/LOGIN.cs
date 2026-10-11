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

namespace _23.Sign_up_with_Log_in_form
{
    public partial class LOGIN : Form
    {
        public LOGIN()
        {
            InitializeComponent();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            SIGN_UP su=new SIGN_UP();
            this.Hide();
            su.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string cs = ConfigurationManager.ConnectionStrings["dbcs"].ConnectionString;
            SqlConnection con = new SqlConnection(cs);

            string query2 = "select * from signup where email=@email and pass=@pass";
            SqlCommand cmd2 = new SqlCommand(query2, con);
            cmd2.Parameters.AddWithValue("@email", textBox1.Text);
            cmd2.Parameters.AddWithValue("@pass", textBox2.Text);

            con.Open();
            SqlDataReader rd = cmd2.ExecuteReader();
            if (rd.HasRows == true)
            {
                    MessageBox.Show("LOGIN SUCCESSFULLY !!", "SUCCESS", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            else
            {
                    MessageBox.Show("LOGIN FAILED !!", "FAILURE", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            con.Close();

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            //textBox2.UseSystemPasswordChar = false;

        }
    }
}
