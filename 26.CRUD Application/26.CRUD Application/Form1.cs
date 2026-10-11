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

namespace _26.CRUD_Application
{
    public partial class Form1 : Form
    {
        string cs = ConfigurationManager.ConnectionStrings["dbcs"].ConnectionString;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void insertbtn_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(cs);

            string query2 = "select * from Employee where Id=@id";
            SqlCommand cmd2 = new SqlCommand(query2, con);
            cmd2.Parameters.AddWithValue("@id", idtb.Text);
            con.Open();
            SqlDataReader dr = cmd2.ExecuteReader();
            if (dr.HasRows == true)
            {
                MessageBox.Show(idtb.Text + " Id Alreadt Exists !!", "Failure", MessageBoxButtons.OK, MessageBoxIcon.Information);
                con.Close();
            }
            else
            {
                con.Close();

                string query = "insert into Employee values(@id,@name,@gender,@age,@desig,@salary)";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@id", idtb.Text);
                cmd.Parameters.AddWithValue("@name", nametb.Text);
                cmd.Parameters.AddWithValue("@gender", gendercombo.SelectedItem);
                cmd.Parameters.AddWithValue("@age", numericUpDown1.Value);
                cmd.Parameters.AddWithValue("@desig", dcombo.SelectedItem);
                cmd.Parameters.AddWithValue("@salary", salarytb.Text);

                con.Open();
                int a = cmd.ExecuteNonQuery();
                if (a > 0)
                {
                    MessageBox.Show("Inserted successfully !!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    BindGridView();

                }
                else
                {
                    MessageBox.Show("Insertion Failed !!", "Failure", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }

                con.Close();
                ResetControls();
            }
        }
        void BindGridView()
        {
            SqlConnection con = new SqlConnection(cs);
            string query = "select * from Employee";
            SqlDataAdapter sda = new SqlDataAdapter(query, con);
            DataTable data=new DataTable();
            sda.Fill(data);
            dataGridView1.DataSource = data;
        }

        private void viewbtn_Click(object sender, EventArgs e)
        {
            BindGridView();
        }

        private void updatebtn_Click(object sender, EventArgs e)
        {

            SqlConnection con = new SqlConnection(cs);
            string query = "update Employee set Id=@id,name=@name,gender=@gender,age=@age,designation=@desig,salary=@salary where id=@id";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@id", idtb.Text);
            cmd.Parameters.AddWithValue("@name", nametb.Text);
            cmd.Parameters.AddWithValue("@gender", gendercombo.SelectedItem);
            cmd.Parameters.AddWithValue("@age", numericUpDown1.Value);
            cmd.Parameters.AddWithValue("@desig", dcombo.SelectedItem);
            cmd.Parameters.AddWithValue("@salary", salarytb.Text);

            con.Open();
            int a = cmd.ExecuteNonQuery();
            if (a > 0)
            {
                MessageBox.Show("Updated successfully !!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                BindGridView();

            }
            else
            {
                MessageBox.Show("Updation Failed !!", "Failure", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }

            con.Close();
            ResetControls();

        }

        private void dataGridView1_MouseDown(object sender, MouseEventArgs e)
        {

        }

        private void dataGridView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            idtb.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            nametb.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            gendercombo.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
            numericUpDown1.Value =Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[3].Value);
            dcombo.Text = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();
            salarytb.Text = dataGridView1.SelectedRows[0].Cells[5].Value.ToString();

        }

        private void deletebtn_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(cs);
            string query = "delete from Employee where Id=@id";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@id", idtb.Text);
           
            con.Open();
            int a = cmd.ExecuteNonQuery();
            if (a > 0)
            {
                MessageBox.Show("Deleted successfully !!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                BindGridView();

            }
            else
            {
                MessageBox.Show("Deletion Failed !!", "Failure", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }

            con.Close();
            ResetControls();

        }

        private void resetbtn_Click(object sender, EventArgs e)
        {
            ResetControls();
        }
        void ResetControls()
        {
            idtb.Clear();
            nametb.Clear();
            gendercombo.SelectedItem = null;
            numericUpDown1.Value = 20;
            dcombo.SelectedItem = null;
            salarytb.Clear();
            idtb.Focus();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(cs);
            string query = "select * from Employee where name like @name  + '%'";
            SqlDataAdapter sda = new SqlDataAdapter(query, con);
            sda.SelectCommand.Parameters.AddWithValue("@name",searchtb.Text.Trim());
            DataTable data=new DataTable();
            sda.Fill(data);
            if (data.Rows.Count > 0)
            {
                dataGridView1.DataSource = data;
            }
            else
            {
                MessageBox.Show("No Rows Found !!");
                dataGridView1.DataSource = null;
            }
        }

        private void searchtb_TextChanged(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(cs);
            string query = "select * from Employee where name like @name  + '%'";
            SqlDataAdapter sda = new SqlDataAdapter(query, con);
            sda.SelectCommand.Parameters.AddWithValue("@name", searchtb.Text.Trim());
            DataTable data = new DataTable();
            sda.Fill(data);
            if (data.Rows.Count > 0)
            {
                dataGridView1.DataSource = data;
            }
            else
            {
                MessageBox.Show("No Rows Found !!");
                dataGridView1.DataSource = null;
            }
        }
    }
}
