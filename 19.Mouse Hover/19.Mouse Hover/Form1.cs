using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _19.Mouse_Hover
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_MouseHover(object sender, EventArgs e)
        {
            label1.Text = "Mouse is on the button !!";
            button1.BackColor= Color.GreenYellow;
            button1.ForeColor= Color.Red;
            button1.Font = new Font("hobo std", 22);
            button1.Width = 200;
            button1.Height = 150;
        }

        private void button1_MouseLeave(object sender, EventArgs e)
        {
            label1.Text = "Mouse is left from the button !!";
            button1.BackColor = Color.Silver;
            button1.ForeColor = Color.Black;
            button1.Font = new Font("Microsoft Sans Serif", 11);
            button1.Width = 100;
            button1.Height = 100;
        }
    }
}
