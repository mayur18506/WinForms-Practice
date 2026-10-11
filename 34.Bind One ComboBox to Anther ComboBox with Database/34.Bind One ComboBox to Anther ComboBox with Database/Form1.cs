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

namespace _34.Bind_One_ComboBox_to_Anther_ComboBox_with_Database
{
    public partial class Form1 : Form
    {
        string cs = ConfigurationManager.ConnectionStrings["dbcs"].ConnectionString;
        DataRow dr;
        public Form1()
        {
            InitializeComponent();
            BindContryCombo();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        void BindContryCombo()
        {
            SqlConnection con = new SqlConnection(cs);
            string query = "select * from countries";
            SqlDataAdapter sda = new SqlDataAdapter(query, con);
            DataTable data = new DataTable();
            sda.Fill(data);
            dr = data.NewRow();
            dr.ItemArray = new object[] {0,"--Select Country--"};
            data.Rows.InsertAt(dr,0);
            comboBox1.DisplayMember = "Name";
            comboBox1.ValueMember = "Country_Id";
            comboBox1.DataSource = data;
        }


        void BindCitiesCombo(int CountryId)
        {
            SqlConnection con = new SqlConnection(cs);
            string query = "select * from cities where Country_Id =@c_Id";
            SqlDataAdapter sda = new SqlDataAdapter(query, con);
            sda.SelectCommand.Parameters.AddWithValue("@c_id",CountryId);
            DataTable data = new DataTable();
            sda.Fill(data);
            dr = data.NewRow();
            dr.ItemArray = new object[] { 0, "--Select City--" };
            data.Rows.InsertAt(dr, 0);
            comboBox2.DisplayMember = "Name";
            comboBox2.ValueMember = "City_Id";
            comboBox2.DataSource = data;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedValue.ToString() != null)
            {
                int CountryId =Convert.ToInt32(comboBox1.SelectedValue.ToString());
                BindCitiesCombo(CountryId);
            }
        }
    }
}
