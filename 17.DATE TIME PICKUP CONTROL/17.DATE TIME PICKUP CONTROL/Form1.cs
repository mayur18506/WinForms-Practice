using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _17.DATE_TIME_PICKUP_CONTROL
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show(dateTimePicker1.Value.ToString());
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show(dateTimePicker2.Value.ToString("hh:mm:ss-tt"));

        }

        private void button3_Click(object sender, EventArgs e)
        {
            MessageBox.Show(dateTimePicker3.Value.ToString("dd/MM/yyyy hh:mm:ss:tt"));

        }
    }
}
