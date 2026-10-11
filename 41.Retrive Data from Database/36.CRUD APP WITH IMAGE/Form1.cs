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
using System.IO;
using System.Security.AccessControl;
using _36.CRUD_APP_WITH_IMAGE.Properties;

namespace _36.CRUD_APP_WITH_IMAGE
{
    public partial class Form1 : Form
    {
        string cs = ConfigurationManager.ConnectionStrings["dbcs"].ConnectionString;
        public Form1()
        {
            InitializeComponent();
            BindGridView();
            BindComboBox();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd= new OpenFileDialog();
            ofd.Title = "Select Image";
            //ofd.Filter = "PNG FILEs (*.png) | *.png";
            ofd.Filter = "All FILES (*.*) | *.*";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.Image = new Bitmap(ofd.FileName);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(cs);
            string query = "insert into STUDENT_DETAILS values(@id,@name,@age,@img)";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@id", textBox1.Text);
            cmd.Parameters.AddWithValue("@name", textBox2.Text);
            cmd.Parameters.AddWithValue("@age", numericUpDown1.Value);
            cmd.Parameters.AddWithValue("@img", SavePhoto());
            con.Open();
            int a=cmd.ExecuteNonQuery();
            if (a>0)
            {
                MessageBox.Show("Data Inserted !!");
                BindGridView();
                ResetControls();
                BindComboBox();


            }
            else
            {
                MessageBox.Show("Data Not Inserted !!");

            }
            con.Close();
        }

        private byte[] SavePhoto()
        {
            MemoryStream ms= new MemoryStream();
            pictureBox1.Image.Save(ms, pictureBox1.Image.RawFormat);
            return ms.GetBuffer();
        }

        void BindGridView()
        {
            SqlConnection con = new SqlConnection(cs);
            string query = "select * from STUDENT_DETAILS";
            SqlDataAdapter sda = new SqlDataAdapter(query, con);
            DataTable data =new DataTable();
            sda.Fill(data);
            dataGridView1.DataSource = data;
            DataGridViewImageColumn dvg = new DataGridViewImageColumn();
            dvg = (DataGridViewImageColumn)dataGridView1.Columns[3];
            dvg.ImageLayout = DataGridViewImageCellLayout.Stretch;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.RowTemplate.Height = 50;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ResetControls();
        }
        void ResetControls()
        {
            textBox1.Clear();
            textBox2.Clear();
            numericUpDown1.Value = 0;
            pictureBox1.Image = Resources.images;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(cs);
            string query = "update STUDENT_DETAILS set id = @id, name=@name, age=@age, picture=@img where id = @id";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@id", textBox1.Text);
            cmd.Parameters.AddWithValue("@name", textBox2.Text);
            cmd.Parameters.AddWithValue("@age", numericUpDown1.Value);
            cmd.Parameters.AddWithValue("@img", SavePhoto());
            con.Open();
            int a = cmd.ExecuteNonQuery();
            if (a > 0)
            {
                MessageBox.Show("Data Updated !!");
                BindGridView();
                ResetControls();
                BindComboBox();


            }
            else
            {
                MessageBox.Show("Data Not Updated !!");

            }
            con.Close();
        }

        private void dataGridView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            textBox1.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            textBox2.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            numericUpDown1.Value =Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[2].Value);
            pictureBox1.Image = GetPhoto((byte[]) dataGridView1.SelectedRows[0].Cells[3].Value);



        }

        private Image GetPhoto(byte[] photo)
        {
            MemoryStream ms = new MemoryStream(photo);
            return Image.FromStream(ms);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(cs);
            string query = "delete from STUDENT_DETAILS where id = @id";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@id", textBox1.Text);
           
            con.Open();
            int a = cmd.ExecuteNonQuery();
            if (a > 0)
            {
                MessageBox.Show("Data Deleted !!");
                BindGridView();
                ResetControls();
                BindComboBox();


            }
            else
            {
                MessageBox.Show("Data Not Deleted !!");

            }
            con.Close();
        }
        void BindComboBox()
        {
            comboBox1.Items.Clear();
            SqlConnection con = new SqlConnection(cs);
            string query = "select * from STUDENT_DETAILS";
            SqlCommand cmd=new SqlCommand(query, con);
            con.Open();
            SqlDataReader dr=cmd.ExecuteReader();
            while (dr.Read())
            {
                int id = dr.GetInt32(0);
                comboBox1.Items.Add(id);
            }
            con.Close() ;

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem.ToString() != null)
            {
                int id =Convert.ToInt32 (comboBox1.SelectedItem.ToString());

                SqlConnection con = new SqlConnection(cs);
                string query = "select * from STUDENT_DETAILS where id=@id";
                SqlDataAdapter sda=new SqlDataAdapter(query, con);
                sda.SelectCommand.Parameters.AddWithValue("@id", id);
                DataTable data=new DataTable();
                sda.Fill(data);
                if (data.Rows.Count >0)
                {
                    textBox3.Text = data.Rows[0]["name"].ToString();
                    textBox4.Text = data.Rows[0]["age"].ToString();

                    MemoryStream ms = new MemoryStream((byte[])data.Rows[0]["picture"]);
                    pictureBox2.Image = new Bitmap(ms);
                }
            }
        }
    }
}
