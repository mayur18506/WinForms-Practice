using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace _42.Date_tme_Picker_In_Databse
{
    public partial class Form1 : Form
    {
        string cs = ConfigurationManager.ConnectionStrings["dbcs"].ConnectionString;
        public Form1()
        {
            InitializeComponent();
            BindGridView();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(cs);
            string query = "insert into date_time values(@id,@name,@doj,@toj,@dob)";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@id", textBox1.Text);
            cmd.Parameters.AddWithValue("@name", textBox2.Text);
            cmd.Parameters.AddWithValue("@doj", dateTimePicker1.Value.ToString("dd-MM-yyyy"));
            cmd.Parameters.AddWithValue("@toj", dateTimePicker2.Value.ToString("hh:mm:ss-tt"));
            cmd.Parameters.AddWithValue("@dob", dateTimePicker3.Value.ToString("dd-MM-yyyy hh:mm:ss-tt"));

            con.Open();
            int a = cmd.ExecuteNonQuery();
            if (a > 0)
            {
                MessageBox.Show("Record Inserted !!");
                BindGridView();

            }
            else
            {
                MessageBox.Show("Record Inserted !!");

            }
            con.Close();
        }
        void BindGridView()
        {
            SqlConnection con = new SqlConnection(cs);
            string query = "select * from date_time";
            SqlDataAdapter sda = new SqlDataAdapter(query, con);
            DataTable data = new DataTable();
            sda.Fill(data);
            dataGridView1.DataSource = data;
        }

        private void dataGridView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            textBox1.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            textBox2.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            dateTimePicker1.Value = DateTime.ParseExact(dataGridView1.SelectedRows[0].Cells[3].Value.ToString(), "dd-MM-yyyy", System.Globalization.CultureInfo.InvariantCulture);
            dateTimePicker2.Value = DateTime.ParseExact(dataGridView1.SelectedRows[0].Cells[4].Value.ToString(), "hh:mm:ss-tt", System.Globalization.CultureInfo.InvariantCulture);
            dateTimePicker3.Value = DateTime.ParseExact(dataGridView1.SelectedRows[0].Cells[5].Value.ToString(), "dd-MM-yyyy hh:mm:ss-tt", System.Globalization.CultureInfo.InvariantCulture);


        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(cs);
            string query = "update date_time set id=@id,name=@name,doj=@doj,toj=@toj,dob=@dob where id=@id";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@id", textBox1.Text);
            cmd.Parameters.AddWithValue("@name", textBox2.Text);
            cmd.Parameters.AddWithValue("@doj", dateTimePicker1.Value.ToString("dd-MM-yyyy"));
            cmd.Parameters.AddWithValue("@toj", dateTimePicker2.Value.ToString("hh:mm:ss-tt"));
            cmd.Parameters.AddWithValue("@dob", dateTimePicker3.Value.ToString("dd-MM-yyyy hh:mm:ss-tt"));

            con.Open();
            int a = cmd.ExecuteNonQuery();
            if (a > 0)
            {
                MessageBox.Show("Record Updated !!");
                BindGridView();

            }
            else
            {
                MessageBox.Show("Record Not Updated !!");

            }
            con.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(cs);
            string query = "delete from date_time where id=@id";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@id", textBox1.Text);

            con.Open();
            int a = cmd.ExecuteNonQuery();
            if (a > 0)
            {
                MessageBox.Show("Record Deleted !!");
                BindGridView();

            }
            else
            {
                MessageBox.Show("Record Not Deleted !!");

            }
            con.Close();
        }
    }
}

