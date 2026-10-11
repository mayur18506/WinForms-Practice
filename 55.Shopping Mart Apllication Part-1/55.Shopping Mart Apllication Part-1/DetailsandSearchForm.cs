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
    public partial class DetailsandSearchForm : Form
    {
        string cs = ConfigurationManager.ConnectionStrings["dbcs"].ConnectionString;

        public DetailsandSearchForm()
        {
            InitializeComponent();
            BindGridview();
        }

        void BindGridview()
        {

            SqlConnection con = new SqlConnection(cs);
            string query = "sp_getBothTableData";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter sda = new SqlDataAdapter();
            sda.SelectCommand = cmd;
            DataTable data = new DataTable();
            sda.Fill(data);
            dataGridView1.DataSource = data;
        }

        private void DetailsandSearchForm_Load(object sender, EventArgs e)
        {

        }

        private void SEARCHbutton1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(cs);
            string query = "sp_getBothTableDataByInvoicee";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@invoiceID", SEARCHtextBox1.Text);
            SqlDataAdapter sda = new SqlDataAdapter();
            //sda.SelectCommand.Parameters.AddWithValue("@invoiceID",SEARCHtextBox1.Text);
            sda.SelectCommand = cmd;
            DataTable data = new DataTable();
            sda.Fill(data);
            dataGridView1.DataSource = data;
            dataGridView1.Columns[10].Visible = false;
            finalcosttextBox1.Text = dataGridView1.Rows[0].Cells[10].Value.ToString();
        }

        private void searchdatetimebutton1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(cs);
            string query = "sp_getBothTableDataByDateTime";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@firstDate", dateTimePicker1.Value);
            cmd.Parameters.AddWithValue("@secondDate", dateTimePicker2.Value);

            SqlDataAdapter sda = new SqlDataAdapter();
            //sda.SelectCommand.Parameters.AddWithValue("@invoiceID",SEARCHtextBox1.Text);
            sda.SelectCommand = cmd;
            DataTable data = new DataTable();
            sda.Fill(data);
            dataGridView1.DataSource = data;
         
        }

        private void resetbutton1_Click(object sender, EventArgs e)
        {
           BindGridview();
        }
    }
}
