using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _16.Placeholder_Textbox
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void textBox1_MouseEnter(object sender, EventArgs e)
        {
            if (textBox1.Text == "ENTER YOUR NAME")
            {
                textBox1.Text = "";
                textBox1.ForeColor= Color.Black;
            }
        }

        private void textBox1_MouseLeave(object sender, EventArgs e)
        {

            if (textBox1.Text == "")
            {
                textBox1.Text = "ENTER YOUR NAME";
                textBox1.ForeColor = Color.Gray;
            }
        }

        private void textBox2_MouseEnter(object sender, EventArgs e)
        {
            if (textBox2.Text == "ENTER YOUR EMAIL")
            {
                textBox2.Text = "";
                textBox2.ForeColor = Color.Black;
            }
        }

        private void textBox2_MouseLeave(object sender, EventArgs e)
        {
            if (textBox2.Text == "")
            {
                textBox2.Text = "ENTER YOUR EMAIL";
                textBox2.ForeColor = Color.Gray;
            }
        }
    }
}
