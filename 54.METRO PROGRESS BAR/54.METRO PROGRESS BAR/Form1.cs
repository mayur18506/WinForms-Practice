using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MetroFramework;
using MetroFramework.Forms;

namespace _54.METRO_PROGRESS_BAR
{
    public partial class Form1 : MetroForm
    {
        public Form1()
        {
            InitializeComponent();
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            metroProgressBar1.Increment(1);
            int value = metroProgressBar1.Value;
            metroLabel1.Text = "Processing..." + value + "%";
            metroLabel1.Visible = true;

            if (metroProgressBar1.Value == 100)
            {
                timer1.Stop();
                metroLabel1.Text = "Processing..." + value + " Done";
                this.Hide();
                Form2 f2=new Form2();
                f2.Show();

            }
        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void metroButton2_Click(object sender, EventArgs e)
        {
            timer1.Stop();
        }
    }
}
