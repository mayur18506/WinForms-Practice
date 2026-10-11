using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace _5.Link_Label_Control
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void MyLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("http://www.google.com");

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.MyLink.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
        }
    }
}
