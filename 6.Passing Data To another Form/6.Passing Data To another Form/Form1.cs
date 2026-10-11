using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _6.Passing_Data_To_another_Form
{
    public partial class Form1 : Form
    {
        public static string Text1;
        public static string Text2;
        public static string Text3;

        public Form1()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text !="" && textBox2.Text != "" && textBox3.Text !="")
            {
           
            Text1 = textBox1.Text;
            Text2 = textBox2.Text;
            Text3 = textBox3.Text;

            Form2 f2 = new Form2();
            f2.Show();

            }
            else
            {
                MessageBox.Show("Please Fill The Fields");
            }
        }
    }
}
