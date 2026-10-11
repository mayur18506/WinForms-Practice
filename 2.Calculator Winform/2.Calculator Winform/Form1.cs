using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _2.Calculator_Winform
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && textBox2.Text != "")
            {

                int num1 = int.Parse(textBox1.Text);
                int num2 = int.Parse(textBox2.Text);

                int result = num1 + num2;
                //MessageBox.Show("Addition result is : " + result.ToString());

                label4.Text = "Addition Result Is: " + result.ToString();
                label4.Visible = true;
            }
            else
            {
                MessageBox.Show("Please Fill Both Fields !!");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && textBox2.Text != "")
            {

                int num1 = int.Parse(textBox1.Text);
                int num2 = int.Parse(textBox2.Text);

                int result = num1 - num2;
                //MessageBox.Show("Addition result is : " + result.ToString());

                label4.Text = "Substraction Result Is: " + result.ToString();
                label4.Visible = true;
            }
            else
            {
                MessageBox.Show("Please Fill Both Fields !!");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && textBox2.Text != "")
            {

                int num1 = int.Parse(textBox1.Text);
                int num2 = int.Parse(textBox2.Text);

                int result = num1 * num2;
                //MessageBox.Show("Addition result is : " + result.ToString());

                label4.Text = "Multiplication Result Is: " + result.ToString();
                label4.Visible = true;
            }
            else
            {
                MessageBox.Show("Please Fill Both Fields !!");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && textBox2.Text != "")
            {

                int num1 = int.Parse(textBox1.Text);
                int num2 = int.Parse(textBox2.Text);

                int result = num1 / num2;
                //MessageBox.Show("Addition result is : " + result.ToString());

                label4.Text = "Division Result Is: " + result.ToString();
                label4.Visible = true;
            }
            else
            {
                MessageBox.Show("Please Fill Both Fields !!");
            }
        }
    }
}
