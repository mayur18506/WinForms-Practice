using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _1.My_First_Form
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            MessageBox.Show("Hello " + textBox1.Text);
            //MessageBox.Show("WELCOME TO WINFORMS !!");
            label3.Text=textBox1.Text;
            label3.Visible = true;
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
