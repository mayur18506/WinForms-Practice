using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Configuration;
using System.Data.SqlClient;

namespace _23.Sign_up_with_Log_in_form
{
    public partial class SIGN_UP : Form
    {
        string pattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";

        string passpattern = @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,}$";


        public SIGN_UP()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void ID_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(ID.Text) == true)
            {
                ID.Focus();
                errorProvider1.SetError(this.ID, "Please fill the ID");
            }
            else
            {
                errorProvider1.Clear();
            }
        }

        private void ID_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (char.IsDigit(ch) == true ) 
            {
                e.Handled = false;
            }
            else if (ch==8)
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void name_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(name.Text) == true)
            {
                name.Focus();
                errorProvider2.SetError(this.name, "Please fill the Name");
            }
            else
            {
                errorProvider2.Clear();
            }
        }

        private void name_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (char.IsLetter(ch) == true)
            {
                e.Handled = false;
            }
            else if (ch == 8)
            {
                e.Handled = false;
            }
            else if (ch == 32)
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void fname_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(fname.Text) == true)
            {
                fname.Focus();
                errorProvider3.SetError(this.fname, "Please fill the Name");
            }
            else
            {
                errorProvider3.Clear();
            }
        }

        private void fname_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (char.IsLetter(ch) == true)
            {
                e.Handled = false;
            }
            else if (ch == 8)
            {
                e.Handled = false;
            }
            else if (ch == 32)
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void suename_TextChanged(object sender, EventArgs e)
        {

        }

        private void suename_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(suename.Text) == true)
            {
                suename.Focus();
                errorProvider4.SetError(this.suename, "Please fill the Surname");
            }
            else
            {
                errorProvider4.Clear();
            }
        }

        private void suename_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (char.IsLetter(ch) == true)
            {
                e.Handled = false;
            }
            else if (ch == 8)
            {
                e.Handled = false;
            }
            else if (ch == 32)
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void gender_Leave(object sender, EventArgs e)
        {
            if (gender.SelectedItem == null)
            {
                errorProvider5.SetError(this.gender, "Please select a gender");
            }
            else
            {
                errorProvider5.Clear();
            }
        }

        private void standard_Leave(object sender, EventArgs e)
        {
            if (standard.Value == 0)
            {
                standard.Focus();
                errorProvider6.SetError(this.standard, "Please select a Class");
            }
            else
            {
                errorProvider6.Clear();
            }
        }

        private void email_Leave(object sender, EventArgs e)
        {
            if (Regex.IsMatch(email.Text,pattern) == false)
            {
                email.Focus();
                errorProvider7.SetError(this.email, "Invalid Email");
            }
            else
            {
                errorProvider7.Clear();
            }
        }

        private void pass_Leave(object sender, EventArgs e)
        {
            if (Regex.IsMatch(pass.Text, passpattern) == false)
            {
                pass.Focus();
                errorProvider8.SetError(this.pass,"UPPERCASE ,LOWERCASE, NUMBERS , SYMBOLS");
            }
            else
            {
                errorProvider8.Clear();
            }
        }

        private void textBox7_Leave(object sender, EventArgs e)
        {
            if (pass.Text != textBox7.Text)
            {
                textBox7.Focus();
                errorProvider9.SetError(this.textBox7, "Password is not Match");
            }
            else
            {
                errorProvider9.Clear();
            }
        }

        private void submit_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(ID.Text) == true)
            {
                ID.Focus();
                errorProvider1.SetError(this.ID, "Please fill the ID");
            }
            else if (string.IsNullOrEmpty(name.Text) == true)
            {
                name.Focus();
                errorProvider2.SetError(this.name, "Please fill the Name");
            }

            else if (string.IsNullOrEmpty(fname.Text) == true)
            {
                fname.Focus();
                errorProvider3.SetError(this.fname, "Please fill the Name");
            }
            else if (string.IsNullOrEmpty(suename.Text) == true)
            {
                suename.Focus();
                errorProvider4.SetError(this.suename, "Please fill the Surname");
            }
            else if (gender.SelectedItem == null)
            {
                errorProvider5.SetError(this.gender, "Please select a gender");
            }

            else if (standard.Value == 0)
            {
                standard.Focus();
                errorProvider6.SetError(this.standard, "Please select a Class");
            }
            else if (Regex.IsMatch(email.Text, pattern) == false)
            {
                email.Focus();
                errorProvider7.SetError(this.email, "Invalid Email");
            }
            else if (Regex.IsMatch(pass.Text, passpattern) == false)
            {
                pass.Focus();
                errorProvider8.SetError(this.pass, "UPPERCASE ,LOWERCASE, NUMBERS , SYMBOLS");
            }

            else if (pass.Text != textBox7.Text)
            {
                textBox7.Focus();
                errorProvider9.SetError(this.textBox7, "Password is not Match");
            }
            else
            {
                string cs = ConfigurationManager.ConnectionStrings["dbcs"].ConnectionString;
                SqlConnection con=new SqlConnection(cs);

                string query2 = "select * from signup where ID=@id";
                SqlCommand cmd2= new SqlCommand(query2, con);
                cmd2.Parameters.AddWithValue("@id", ID.Text);

                con.Open();
                SqlDataReader rd = cmd2.ExecuteReader();
                if (rd.HasRows == true)
                {
                    MessageBox.Show(ID.Text + "ID Already Exist !!", "Faliure", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    con.Close();
                }
                else
                {
                    con.Close();
                    string query = "insert into signup values (@id,@name,@fname,@surname,@gender,@class,@email,@pass)";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@id", ID.Text);
                    cmd.Parameters.AddWithValue("@name", name.Text);
                    cmd.Parameters.AddWithValue("@fname", fname.Text);
                    cmd.Parameters.AddWithValue("@surname", suename.Text);
                    cmd.Parameters.AddWithValue("@gender", gender.SelectedItem);
                    cmd.Parameters.AddWithValue("@class", standard.Value);
                    cmd.Parameters.AddWithValue("@email", email.Text);
                    cmd.Parameters.AddWithValue("@pass", pass.Text);

                    con.Open();
                    int a = cmd.ExecuteNonQuery();
                    if (a > 0)
                    {
                        MessageBox.Show("Registered Sucessfully !!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        MessageBox.Show("Your Email is: " + email.Text + " \n \n" + "Your Password is: " + pass.Text , "Success", MessageBoxButtons.OK,MessageBoxIcon.Information);
                        this.Hide(); 
                        LOGIN Page = new LOGIN();
                        Page.Show();
                    }
                    else
                    {
                        MessageBox.Show("Registered Failed !!", "Failure", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    }
                    con.Close();
                }
            }
        }

        private void reset_Click(object sender, EventArgs e)
        {
            ID.Clear();
            name.Clear();
            fname.Clear();
            suename.Clear();
            gender.SelectedItem = null;
            standard.Value = 0;
            email.Clear();
            pass.Clear();
            textBox7.Clear();

        }
    }
}
