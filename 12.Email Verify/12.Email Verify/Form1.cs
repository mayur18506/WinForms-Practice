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

namespace _12.Email_Verify
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        string pattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";
        private void textBox1_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox1.Text) == true)
            {
                textBox1.Focus();
                errorProvider1.SetError(this.textBox1, "Please Fill the Name !!");
            }
            else
            {
                errorProvider1.Clear();
            }
        }

        private void textBox2_Leave(object sender, EventArgs e)
        {
            if (Regex.IsMatch(textBox2.Text, pattern) == false)
            {
                textBox2.Focus();
                errorProvider2.SetError(this.textBox2, "INVALID EMAIL !!");
                
            }
          
            else
            {
                errorProvider2.Clear();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox1.Text) == true)
            {
                textBox1.Focus();
                errorProvider1.SetError(this.textBox1, "Please Fill the Name !!");
            }
            else if (Regex.IsMatch(textBox2.Text, pattern) == false)
            {
                errorProvider2.SetError(this.textBox2, "Please Fill the Email !!");
                textBox2.Focus();
            }
            else 
            { 
            MessageBox.Show("Welcome", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
           }
        }
    }
}
