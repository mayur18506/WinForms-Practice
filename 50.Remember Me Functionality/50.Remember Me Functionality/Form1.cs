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

namespace _50.Remember_Me_Functionality
{
    public partial class Form1 : Form
    {
        string cs = ConfigurationManager.ConnectionStrings["dbcs"].ConnectionString;
        public Form1()
        {
            InitializeComponent();
            LoadCredentials();
        }
        void saveCredentials()
        {
            if (checkBox1.Checked == true)
            {
                Properties.Settings.Default.Username = usertextBox1.Text;
                Properties.Settings.Default.Password = passtextBox2.Text;
                Properties.Settings.Default.Save();
            }
            else
            {
                Properties.Settings.Default.Username = "";
                Properties.Settings.Default.Password = "";
                Properties.Settings.Default.Save();
            }
        }
        void LoadCredentials()
        {
            if (Properties.Settings.Default.Username != string.Empty)
            {
                usertextBox1.Text = Properties.Settings.Default.Username;
                passtextBox2.Text = Properties.Settings.Default.Password;
                checkBox1.Checked = true;

            }

        }

        private void lbutton1_Click(object sender, EventArgs e)
        {
            //if (usertextBox1.Text == "Mayur" && passtextBox2.Text == "Mayur123")
            //{
            //    MessageBox.Show("Login Successfull !!","success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    saveCredentials();
            //    this.Hide();
            //    Form2 f2=new Form2();
            //    f2.ShowDialog();
            //}
            //else
            //{
            //    MessageBox.Show("Username or Password is incorrect !!");
            //}

            if (string.IsNullOrEmpty(usertextBox1.Text) ==  true && string.IsNullOrEmpty(passtextBox2.Text) == true)
            {
                    MessageBox.Show("Both fields are required !!","Failure", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            else
            {
                SqlConnection conn = new SqlConnection(cs);
                string query = "select * from login where username = @user and password=@pass";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@user", usertextBox1.Text);
                cmd.Parameters.AddWithValue("@pass", passtextBox2.Text);
                conn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows == true)
                {
                        MessageBox.Show("Login Successfull !!","success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    saveCredentials();
                    this.Hide();
                    Form2 f2 = new Form2();
                    f2.ShowDialog();

                }
                else
                {
                        MessageBox.Show("Username or Password is incorrect !!", "Failure", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
                conn.Close();

            }
        }
    }
}
