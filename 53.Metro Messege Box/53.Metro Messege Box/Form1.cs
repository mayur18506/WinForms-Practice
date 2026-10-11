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

namespace _53.Metro_Messege_Box
{
    public partial class Form1 : MetroForm
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //MetroFramework.MetroMessageBox.Show(this, "Welcome " + textBox1.Text,"WelcomeM",MessageBoxButtons.OK,MessageBoxIcon.Information,150);
        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            MetroFramework.MetroMessageBox.Show(this, "Welcome " + metroTextBox1.Text, "Welcome", MessageBoxButtons.OK, MessageBoxIcon.Information, 150);

        }

        private void metroTile1_Click(object sender, EventArgs e)
        {
            MetroFramework.MetroMessageBox.Show(this, "OK", "METRO MESSEGE BOX", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void metroTile2_Click(object sender, EventArgs e)
        {
            MetroFramework.MetroMessageBox.Show(this, "YES NO", "METRO MESSEGE BOX", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

        }

        private void metroTile4_Click(object sender, EventArgs e)
        {
            MetroFramework.MetroMessageBox.Show(this, "ERROR", "METRO MESSEGE BOX", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }

        private void metroTile5_Click(object sender, EventArgs e)
        {
            MetroFramework.MetroMessageBox.Show(this, "WARNING", "METRO MESSEGE BOX", MessageBoxButtons.OK, MessageBoxIcon.Warning);

        }

        private void metroTile3_Click(object sender, EventArgs e)
        {
            MetroFramework.MetroMessageBox.Show(this, "NONE", "METRO MESSEGE BOX", MessageBoxButtons.OK, MessageBoxIcon.None);

        }

        private void metroTile6_Click(object sender, EventArgs e)
        {
            DialogResult dr = MetroFramework.MetroMessageBox.Show(this, "YES / NO / CANCEL", "METRO MESSEGE BOX", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information);
            if (dr == DialogResult.Yes)
            {
                MetroFramework.MetroMessageBox.Show(this, "YOU HAVE SUCCESSFULLY DONE", "METRO MESSEGE BOX", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            else if (dr == DialogResult.No)
            {
                MetroFramework.MetroMessageBox.Show(this, "YOU ARE NOT AGREE", "METRO MESSEGE BOX", MessageBoxButtons.OK, MessageBoxIcon.None);

            }
            else
            {
                MetroFramework.MetroMessageBox.Show(this, "YOU HAVE CANCELLED THE OPERATION", "METRO MESSEGE BOX", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void metroTile7_Click(object sender, EventArgs e)
        {
          MetroFramework.MetroMessageBox.Show(this, "STOP", "METRO MESSEGE BOX", MessageBoxButtons.OK, MessageBoxIcon.Stop);
          
        }
    }
}
