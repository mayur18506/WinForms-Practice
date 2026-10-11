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

namespace _13.Password__Confirm_Password
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        string pattern = @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,}$";
        private void textBox1_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox1.Text) == true)
            {
                textBox1.Focus();
                errorProvider1.SetError(this.textBox1, "Please enter Username");
            }
            else
            {
                errorProvider1.Clear();
            }
        }

        private void textBox2_Leave(object sender, EventArgs e)
        {
            if (Regex.IsMatch(textBox2.Text,pattern) == false)
            {
                textBox2.Focus();
                errorProvider2.SetError(this.textBox2, "UPPERCASE , LOWERCASE, SPECIAL CHARACTERS");
            }
            else
            {
                errorProvider2.Clear();
            }
        }

        private void textBox3_Leave(object sender, EventArgs e)
        {
            if (textBox2.Text != textBox3.Text)
            {
                textBox2.Focus();
                errorProvider3.SetError(this.textBox3, "Password is not Identical");
            }
            else
            {
                errorProvider3.Clear();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox1.Text) == true)
            {
                textBox1.Focus();
                errorProvider1.SetError(this.textBox1, "Please enter Username");
            }

            else if (Regex.IsMatch(textBox2.Text, pattern) == false)
            {
                textBox2.Focus();
                errorProvider2.SetError(this.textBox2, "UPPERCASE , LOWERCASE, SPECIAL CHARACTERS");
            }
            else if (textBox2.Text != textBox3.Text)
            {
                textBox3.Focus();
                errorProvider3.SetError(this.textBox3, "Password is not Identical");

            }
            else
            {
                MessageBox.Show("Welcome");
            }

          }

        }
}
