using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.Data.SqlClient;

namespace _55.Shopping_Mart_Apllication_Part_1
{
    public partial class SIGNUP : Form
    {
        string cs = ConfigurationManager.ConnectionStrings["dbcs"].ConnectionString;

        public SIGNUP()
        {
            InitializeComponent();
        }

        private void SIGNUPbutton1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(cs);
            string query = "insert into signup values(@name,@surname,@gender,@age,@address,@email,@pass)";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@name", NAMEtextBox1.Text);
            cmd.Parameters.AddWithValue("@surname", SURNAMEtextBox2.Text);
            cmd.Parameters.AddWithValue("@gender", GENDERcomboBox1.SelectedItem);
            cmd.Parameters.AddWithValue("@age", numericUpDown1.Value);
            cmd.Parameters.AddWithValue("@address", ADDtextBox3.Text);
            cmd.Parameters.AddWithValue("@email", EMAILtextBox4.Text);
            cmd.Parameters.AddWithValue("@pass", PASStextBox5.Text);

            con.Open();
            int a = cmd.ExecuteNonQuery();
            if (a>0)
            {
                MessageBox.Show("Registered Successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                MessageBox.Show("Username is: " + NAMEtextBox1.Text + "\n \n" + "Password is: " + PASStextBox5.Text, "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.Hide();
                LOGIN loginform = new LOGIN();
                loginform.ShowDialog();
            }
            else
            {
                MessageBox.Show("Registration Failed", "Failure", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            con.Close();
        }
    }
}
