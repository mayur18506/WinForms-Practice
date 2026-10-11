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

namespace _46.AUTO_INCREMENT_TEXTBOX_VALUE
{
    
    public partial class Form1 : Form
    {
        string cs = ConfigurationManager.ConnectionStrings["dbcs"].ConnectionString;
        public Form1()
        {
            InitializeComponent();
            getIncrementId();
            BindGridView();

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        void getIncrementId()
        {
            using (SqlConnection con = new SqlConnection(cs))
            {
                string query = "SELECT ISNULL(MAX(id), 0) + 1 FROM tbl";

                SqlCommand cmd = new SqlCommand(query, con);

                con.Open();

                int nextId = Convert.ToInt32(cmd.ExecuteScalar());

                con.Close();

                idtextBox1.Text = nextId.ToString();
            }
        }

        private void insertbutton1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(cs);
            string query = "insert into tbl values(@id,@name,@age)";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@id", idtextBox1.Text);
            cmd.Parameters.AddWithValue("@name", nametextBox2.Text);
            cmd.Parameters.AddWithValue("@age", agetextBox3.Text);
            con.Open();
            int a = cmd.ExecuteNonQuery();
            if (a>0)
            {
                MessageBox.Show("Inserted !!");
                getIncrementId();
                BindGridView();
                nametextBox2.Text = "";
                agetextBox3.Text = "";
            }
            else
            {
                MessageBox.Show("Not Inserted !!");

            }
            con.Close();
        }
        void BindGridView()
        {
            SqlConnection con = new SqlConnection(cs);
            string query = "select * from tbl";
            SqlDataAdapter sda = new SqlDataAdapter(query, con);
            DataTable data = new DataTable();
            sda.Fill(data);
            dataGridView1.DataSource = data;
        }

        private void dataGridView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            idtextBox1.Text=dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            nametextBox2.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            agetextBox3.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();



        }

        private void updatebutton2_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(cs);
            string query = "update tbl set name=@name,age=@age where id=@id";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@id", idtextBox1.Text);
            cmd.Parameters.AddWithValue("@name", nametextBox2.Text);
            cmd.Parameters.AddWithValue("@age", agetextBox3.Text);
            con.Open();
            int a = cmd.ExecuteNonQuery();
            if (a > 0)
            {
                MessageBox.Show("Updated !!");
                getIncrementId();
                BindGridView();
                nametextBox2.Text = "";
                agetextBox3.Text = "";
            }
            else
            {
                MessageBox.Show("Not Updated !!");

            }
            con.Close();
        }

        private void deletebutton3_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(cs);
            string query = "delete from tbl where id=@id";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@id", idtextBox1.Text);
          
            con.Open();
            int a = cmd.ExecuteNonQuery();
            if (a > 0)
            {
                MessageBox.Show("Deleted !!");
                getIncrementId();
                BindGridView();
                nametextBox2.Text = "";
                agetextBox3.Text = "";
            }
            else
            {
                MessageBox.Show("Not Deleted !!");

            }
            con.Close();
        }
    }
}
