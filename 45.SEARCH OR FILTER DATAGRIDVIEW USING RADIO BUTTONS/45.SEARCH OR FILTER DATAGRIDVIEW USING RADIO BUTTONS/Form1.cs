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

namespace _45.SEARCH_OR_FILTER_DATAGRIDVIEW_USING_RADIO_BUTTONS
{
    public partial class Form1 : Form
    {
        string cs = ConfigurationManager.ConnectionStrings["dbcs"].ConnectionString;
        public Form1()
        {
            InitializeComponent();
            BindGridView();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(cs);
            string query = "select * from employee1 where gender='male'";
            SqlDataAdapter sda = new SqlDataAdapter(query, con);
            DataTable data=new DataTable();
            sda.Fill(data);


            dataGridView1.Rows.Clear();
            foreach (DataRow row in data.Rows)
            {
                int index = dataGridView1.Rows.Add();
                dataGridView1.Rows[index].Cells[0].Value = row["ID"].ToString();
                dataGridView1.Rows[index].Cells[1].Value = row["NAME"].ToString();
                dataGridView1.Rows[index].Cells[2].Value = row["GENDER"].ToString();
                dataGridView1.Rows[index].Cells[3].Value = row["SALARY"].ToString();

            }

            //dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            //dataGridView1.DataSource = data;
        }
        void BindGridView()
        {
            SqlConnection con = new SqlConnection(cs);
            string query = "select * from employee1 ";
            SqlDataAdapter sda = new SqlDataAdapter(query, con);
            DataTable data = new DataTable();
            sda.Fill(data);

            dataGridView1.Rows.Clear();
            foreach (DataRow row in data.Rows)
            {
                int index = dataGridView1.Rows.Add();
                dataGridView1.Rows[index].Cells[0].Value = row["ID"].ToString();
                dataGridView1.Rows[index].Cells[1].Value = row["NAME"].ToString();
                dataGridView1.Rows[index].Cells[2].Value = row["GENDER"].ToString();
                dataGridView1.Rows[index].Cells[3].Value = row["SALARY"].ToString();

            }

            //dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            //dataGridView1.DataSource = data;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(cs);
            string query = "select * from employee1 where gender='female'";
            SqlDataAdapter sda = new SqlDataAdapter(query, con);
            DataTable data = new DataTable();
            sda.Fill(data);


            dataGridView1.Rows.Clear();
            foreach (DataRow row in data.Rows)
            {
                int index = dataGridView1.Rows.Add();
                dataGridView1.Rows[index].Cells[0].Value = row["ID"].ToString();
                dataGridView1.Rows[index].Cells[1].Value = row["NAME"].ToString();
                dataGridView1.Rows[index].Cells[2].Value = row["GENDER"].ToString();
                dataGridView1.Rows[index].Cells[3].Value = row["SALARY"].ToString();

            }

            //dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            //dataGridView1.DataSource = data;
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(cs);
            string query = "select * from employee1 ";
            SqlDataAdapter sda = new SqlDataAdapter(query, con);
            DataTable data = new DataTable();
            sda.Fill(data);


            dataGridView1.Rows.Clear();
            foreach (DataRow row in data.Rows)
            {
                int index = dataGridView1.Rows.Add();
                dataGridView1.Rows[index].Cells[0].Value = row["ID"].ToString();
                dataGridView1.Rows[index].Cells[1].Value = row["NAME"].ToString();
                dataGridView1.Rows[index].Cells[2].Value = row["GENDER"].ToString();
                dataGridView1.Rows[index].Cells[3].Value = row["SALARY"].ToString();

            }

            //dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            //dataGridView1.DataSource = data;
        }
    }
}
