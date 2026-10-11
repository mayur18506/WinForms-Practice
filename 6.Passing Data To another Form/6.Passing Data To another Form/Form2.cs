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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            //label2.Text = Form1.Text1;
            //label3.Text = Form1.Text2;
            //label4.Text = Form1.Text3;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            label2.Text = Form1.Text1;
            label3.Text = Form1.Text2;
            label4.Text = Form1.Text3;

            label2.Visible = true;
            label3.Visible = true;
            label4.Visible = true;

        }
    }
}
