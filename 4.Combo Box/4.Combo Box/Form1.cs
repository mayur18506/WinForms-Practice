using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _4.Combo_Box
{
    public partial class Mycombobox : Form
    {
        public Mycombobox()
        {
            InitializeComponent();
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {

                if (HobbiesComboBox.Items.Contains(textBox1.Text))
                {
                    MessageBox.Show("Item Already Exists");
                }

                else
                {
                HobbiesComboBox.Items.Add(textBox1.Text);
            textBox1.Clear();
            textBox1.Focus();
                }
            }
            else
            {
                MessageBox.Show("Please Fill The Text Box");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

            MessageBox.Show("Total Items Are : " + HobbiesComboBox.Items.Count);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            HobbiesComboBox.Items.Remove(HobbiesComboBox.SelectedItem);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            HobbiesComboBox.Items.Clear();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            HobbiesComboBox.Sorted = true;
        }

        private void HobbiesComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            string lbl = HobbiesComboBox.SelectedItem.ToString();
            label3.Text = "Your Selected Item is :" + lbl;
            label3.Visible = true;
        }
    }
}
