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

namespace _55.Shopping_Mart_Apllication_Part_1
{
    public partial class LOGIN : Form
    {
        public static string username = "";
        string cs = ConfigurationManager.ConnectionStrings["dbcs"].ConnectionString;

        public LOGIN()
        {
            InitializeComponent();
        }

        private void loginbutton1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(cs);
            string query = "select * from signup where name =@user and password =@pass";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@user", usernametextBox1.Text);
            cmd.Parameters.AddWithValue("@pass", passtextBox2.Text);

            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows == true)
            {
                MessageBox.Show("Login Successfull !!","Success",MessageBoxButtons.OK,MessageBoxIcon.Information);
                username = usernametextBox1.Text;
                Form1 mainform = new Form1();
                mainform.ShowDialog();
            }
            else
            {
                MessageBox.Show("Login Failed !!","Failure",MessageBoxButtons.OK,MessageBoxIcon.Information);

            }
            con.Close();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            bool check = checkBox1.Checked;
            switch (checkBox1.Checked)
            {
                case true:
                    passtextBox2.UseSystemPasswordChar = false;
                    break;

                default:
                    passtextBox2.UseSystemPasswordChar = true;
                    break;
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            SIGNUP su=new SIGNUP();
            this.Hide();
            su.ShowDialog();
        }
    }
}
