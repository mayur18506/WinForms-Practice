using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _8.CheckBox_Control
{
    public partial class Form1 : Form
    {
        string Text1 = "";
        string Text2 = "";
        string Text3 = "";
        string Text4 = "";

        public Form1()
        {
           
            InitializeComponent();
        }

        private void SAMSUNGCH_CheckedChanged(object sender, EventArgs e)
        {
            if (SAMSUNGCH.Checked == true)
            {
                Text1 = SAMSUNGCH.Text;
            }
            else
            {
                Text1 = "";
            }
        }

        private void IPHONECH_CheckedChanged(object sender, EventArgs e)
        {
            if (IPHONECH.Checked == true)
            {
                Text2 = IPHONECH.Text;
            }
            else
            {
                Text2 = "";
            }
        }

        private void NOKIACH_CheckedChanged(object sender, EventArgs e)
        {
            if (NOKIACH.Checked == true)
            {
                Text3 = NOKIACH.Text;
            }
            else
            {
                Text3 = "";
            }
        }

        private void OPPOCH_CheckedChanged(object sender, EventArgs e)
        {
            if (OPPOCH.Checked == true)
            {
                Text4 = OPPOCH.Text;
            }
            else
            {
                Text4 = "";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Your Selected Companies are : " + Text1 + " " + Text2 + " " + Text3 + " " + Text4 + " ");
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            button2.Enabled = checkBox1.Checked;
        }
    }
}
