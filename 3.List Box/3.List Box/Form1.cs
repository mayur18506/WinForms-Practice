using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _3.List_Box
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FruitsListBox.Items.Add(textBox1.Text);
            textBox1.Clear();
            textBox1.Focus();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int count=  FruitsListBox.Items.Count ;
            MessageBox.Show("List Items Are: " + count.ToString());
        }

        private void button3_Click(object sender, EventArgs e)
        {
            FruitsListBox.Sorted = true;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //FruitsListBox.Items.Remove(FruitsListBox.SelectedItem);

            FruitsListBox.Items.RemoveAt(FruitsListBox.SelectedIndex);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            FruitsListBox.Items.Clear();
        }
    }
}
