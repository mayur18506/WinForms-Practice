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

namespace _32.BIND_COMBO_BOX
{
    public partial class Form1 : Form
    {
        string cs = ConfigurationManager.ConnectionStrings["dbcs"].ConnectionString;
        public Form1()
        {
            InitializeComponent();
        }
        void BindComboBox()
        {
            SqlConnection con = new SqlConnection(cs);
            string query = "select * from myemployees";
            SqlCommand cmd = new SqlCommand(query, con);
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                string name = dr.GetString(1);
                comboBox1.Items.Add(name);
            }
            con.Close();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            BindComboBox();
        }
    }
}
