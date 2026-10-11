using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _18.Date_and_Time
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            timer1.Start();

            //DateTime dt=DateTime.Now;
            //label1.Text = dt.ToString();
            //label1.Text = dt.ToLongDateString();
            //label1.Text = dt.ToShortDateString();
            //label1.Text = dt.ToLongTimeString();
            //label1.Text = dt.ToShortTimeString();

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            DateTime dt = DateTime.Now;
            label1.Text = dt.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            timer1.Stop();
       
        }
    }
}
