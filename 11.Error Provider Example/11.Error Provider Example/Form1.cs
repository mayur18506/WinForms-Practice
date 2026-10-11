using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _11.Error_Provider_Example
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox1.Text))
            {
                textBox1.Focus();
                //MessageBox.Show("Please Fill the Name !!");
                errorProvider1.SetError(this.textBox1, "Please Fill the Name !!");
            }
            else
            {
                errorProvider1.Clear();
            }
        }

        private void label2_Leave(object sender, EventArgs e)
        {
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox1.Text))
            {
                textBox1.Focus();
                //MessageBox.Show("Please Fill the Name !!");
                errorProvider1.SetError(this.textBox1, "Please Fill the Name !!");
            }
        
             else if (string.IsNullOrEmpty(textBox2.Text))
            {
                textBox2.Focus();
                //MessageBox.Show("Please Fill the Name !!");
                errorProvider2.SetError(this.textBox2, "Please Fill the Age !!");
            }
            else
            {
                MessageBox.Show("Welcome !!");
            }
        }

        private void textBox2_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox2.Text))
            {
                textBox2.Focus();
                //MessageBox.Show("Please Fill the Age !!");
                errorProvider2.SetError(this.textBox2, "Please Fill the Ahe !!");
            }
            else
            {
                errorProvider2.Clear();
            }
        }
    }
}
