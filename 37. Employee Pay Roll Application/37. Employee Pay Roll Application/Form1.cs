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

namespace _37.Employee_Pay_Roll_Application
{
    public partial class Form1 : Form
    {
        string cs = ConfigurationManager.ConnectionStrings["dbcs"].ConnectionString;
        public Form1()
        {
            InitializeComponent();
            LoadEmployeeData();     
            Total_NetSalary1();
            Total_Employees();
        }

        private void IDtextBox1_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(IDtextBox1.Text))
            {
                IDtextBox1.Focus();
                errorProvider1.SetError(this.IDtextBox1, "Please Enter Id !!");
            }
            else
            {
                errorProvider1.Clear();
            }
        }

        private void NAMEtextBox2_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(NAMEtextBox2.Text))
            {
                NAMEtextBox2.Focus();
                errorProvider2.SetError(this.NAMEtextBox2, "Please Enter Name !!");
            }
            else
            {
                errorProvider2.Clear();
            }
        }

        private void DESIGtextBox3_Leave(object sender, EventArgs e)
        {

            if (string.IsNullOrEmpty(DESIGtextBox3.Text))
            {
                DESIGtextBox3.Focus();
                errorProvider3.SetError(this.DESIGtextBox3, "Please Enter Designation !!");
            }
            else
            {
                errorProvider3.Clear();
            }
        }

        private void BASICPAYtextBox4_Leave(object sender, EventArgs e)
        {

            if (string.IsNullOrEmpty(BASICPAYtextBox4.Text))
            {
                BASICPAYtextBox4.Focus();
                errorProvider4.SetError(this.BASICPAYtextBox4, "Please Enter Basic Pay !!");
            }
            else
            {
                errorProvider4.Clear();
            }
        }

        private void BASICPAYtextBox4_TextChanged(object sender, EventArgs e)
        {
            int CA, MA, HR, grosspay, IT, netsalary;
            int basicpay = 0;
            if (string.IsNullOrEmpty(BASICPAYtextBox4.Text))
            {
                BASICPAYtextBox4.Focus();
                errorProvider4.SetError(this.BASICPAYtextBox4, "Please Fill the Required Field !!");

            }
            else
            {
                errorProvider4.Clear();
                basicpay = Convert.ToInt32(BASICPAYtextBox4.Text);

            }

            if (basicpay >= 40000)
            {
                CA = (int)(basicpay * 0.40);
                CtextBox5.Text = CA.ToString();

                MA = (int)(basicpay * 0.30);
                MtextBox6.Text = MA.ToString();

                HR = (int)(basicpay * 0.20);
                HRtextBox7.Text = HR.ToString();

                grosspay = basicpay + CA + MA + HR;
                GPtextBox8.Text = grosspay.ToString();

                if (grosspay >= 60000)
                {
                    IT = (int)(grosspay * 0.03);
                    ITtextbox.Text = IT.ToString();
                    netsalary = grosspay - IT;
                    NStextBox10.Text = netsalary.ToString();
                }
                else if (grosspay >= 50000)
                {
                    IT = (int)(grosspay * 0.02);
                    ITtextbox.Text = IT.ToString();
                    netsalary = grosspay - IT;
                    NStextBox10.Text = netsalary.ToString();
                }
            }
            else if (basicpay >= 30000)
            {
                CA = (int)(basicpay * 0.35);
                CtextBox5.Text = CA.ToString();

                MA = (int)(basicpay * 0.25);
                MtextBox6.Text = MA.ToString();

                HR = (int)(basicpay * 0.15);
                HRtextBox7.Text = HR.ToString();

                grosspay = basicpay + CA + MA + HR;
                GPtextBox8.Text = grosspay.ToString();

                if (grosspay >= 60000)
                {
                    IT = (int)(grosspay * 0.03);
                    ITtextbox.Text = IT.ToString();
                    netsalary = grosspay - IT;
                    NStextBox10.Text = netsalary.ToString();
                }
                else if (grosspay >= 50000)
                {
                    IT = (int)(grosspay * 0.02);
                    ITtextbox.Text = IT.ToString();
                    netsalary = grosspay - IT;
                    NStextBox10.Text = netsalary.ToString();
                }
            }
            else
            {
                CA =3000;
                CtextBox5.Text = CA.ToString();

                MA = 2000;
                MtextBox6.Text = MA.ToString();

                HR = 1000;
                HRtextBox7.Text = HR.ToString();

                grosspay = basicpay + CA + MA + HR;
                GPtextBox8.Text = grosspay.ToString();

                
                ITtextbox.Text = "No Tax Applied";
                netsalary = grosspay ;
                NStextBox10.Text = netsalary.ToString();
            }
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            IDtextBox1.Clear();
            NAMEtextBox2.Clear();
            DESIGtextBox3.Clear();
            BASICPAYtextBox4.Clear();
            CtextBox5.Clear();
            MtextBox6.Clear();
            HRtextBox7.Clear();
            GPtextBox8.Clear();
            ITtextbox .Clear();
            NStextBox10 .Clear();
        }

        private void INSERT_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(IDtextBox1.Text) ||
        string.IsNullOrWhiteSpace(NAMEtextBox2.Text) ||
        string.IsNullOrWhiteSpace(DESIGtextBox3.Text) ||
        string.IsNullOrWhiteSpace(BASICPAYtextBox4.Text))
            {
                MessageBox.Show("Please fill all required fields.",
                                "Validation",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (SqlConnection con = new SqlConnection(cs))
                {
                    string query = @"INSERT INTO EmployeePayroll
                            (ID, Name, Designation, BasicPay,
                             Conveyance, Medical, HouseRent,
                             GrossPay, IncomeTax, NetSalary)
                            VALUES
                            (@ID, @Name, @Designation, @BasicPay,
                             @Conveyance, @Medical, @HouseRent,
                             @GrossPay, @IncomeTax, @NetSalary)";

                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@ID", Convert.ToInt32(IDtextBox1.Text));
                        cmd.Parameters.AddWithValue("@Name", NAMEtextBox2.Text);
                        cmd.Parameters.AddWithValue("@Designation", DESIGtextBox3.Text);
                        cmd.Parameters.AddWithValue("@BasicPay", Convert.ToDecimal(BASICPAYtextBox4.Text));
                        cmd.Parameters.AddWithValue("@Conveyance", Convert.ToDecimal(CtextBox5.Text));
                        cmd.Parameters.AddWithValue("@Medical", Convert.ToDecimal(MtextBox6.Text));
                        cmd.Parameters.AddWithValue("@HouseRent", Convert.ToDecimal(HRtextBox7.Text));
                        cmd.Parameters.AddWithValue("@GrossPay", Convert.ToDecimal(GPtextBox8.Text));

                        decimal incomeTax = 0;

                        if (ITtextbox.Text != "No Tax Applied")
                        {
                            incomeTax = Convert.ToDecimal(ITtextbox.Text);
                        }

                        cmd.Parameters.AddWithValue("@IncomeTax", incomeTax);
                        cmd.Parameters.AddWithValue("@NetSalary", Convert.ToDecimal(NStextBox10.Text));

                        con.Open();

                        int result = cmd.ExecuteNonQuery();

                        if (result > 0)
                        {
                            MessageBox.Show("Employee Inserted Successfully!",
                                            "Success",
                                            MessageBoxButtons.OK,
                                            MessageBoxIcon.Information);
                            LoadEmployeeData();
                            Total_NetSalary1();
                            Total_Employees();

                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                if (ex.Number == 2627)
                {
                    MessageBox.Show("Employee ID already exists!");
                }
                else
                {
                    MessageBox.Show(ex.Message);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void UPDATE_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(cs))
                {
                    string query = @"UPDATE EmployeePayroll SET
                            Name = @Name,
                            Designation = @Designation,
                            BasicPay = @BasicPay,
                            Conveyance = @Conveyance,
                            Medical = @Medical,
                            HouseRent = @HouseRent,
                            GrossPay = @GrossPay,
                            IncomeTax = @IncomeTax,
                            NetSalary = @NetSalary
                            WHERE ID = @ID";

                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@ID",
                            Convert.ToInt32(IDtextBox1.Text));

                        cmd.Parameters.AddWithValue("@Name",
                            NAMEtextBox2.Text);

                        cmd.Parameters.AddWithValue("@Designation",
                            DESIGtextBox3.Text);

                        cmd.Parameters.AddWithValue("@BasicPay",
                            Convert.ToDecimal(BASICPAYtextBox4.Text));

                        cmd.Parameters.AddWithValue("@Conveyance",
                            Convert.ToDecimal(CtextBox5.Text));

                        cmd.Parameters.AddWithValue("@Medical",
                            Convert.ToDecimal(MtextBox6.Text));

                        cmd.Parameters.AddWithValue("@HouseRent",
                            Convert.ToDecimal(HRtextBox7.Text));

                        cmd.Parameters.AddWithValue("@GrossPay",
                            Convert.ToDecimal(GPtextBox8.Text));

                        decimal incomeTax = 0;

                        if (ITtextbox.Text != "No Tax Applied")
                        {
                            incomeTax = Convert.ToDecimal(ITtextbox.Text);
                        }

                        cmd.Parameters.AddWithValue("@IncomeTax", incomeTax);

                        cmd.Parameters.AddWithValue("@NetSalary",
                            Convert.ToDecimal(NStextBox10.Text));

                        con.Open();

                        int result = cmd.ExecuteNonQuery();

                        if (result > 0)
                        {
                            MessageBox.Show("Employee Updated Successfully!",
                                            "Success",
                                            MessageBoxButtons.OK,
                                            MessageBoxIcon.Information);
                            //LoadEmployeeData();
                            Total_NetSalary1();

                            LoadEmployeeData();
                            ClearFields();
                        }
                        else
                        {
                            MessageBox.Show("Employee ID not found!");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void DELETE_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult result = MessageBox.Show(
                    "Are you sure you want to delete this employee?",
                    "Confirm Delete",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    using (SqlConnection con = new SqlConnection(cs))
                    {
                        string query =
                            "DELETE FROM EmployeePayroll WHERE ID = @ID";

                        using (SqlCommand cmd = new SqlCommand(query, con))
                        {
                            cmd.Parameters.AddWithValue(
                                "@ID",
                                Convert.ToInt32(IDtextBox1.Text));

                            con.Open();

                            int rows = cmd.ExecuteNonQuery();

                            if (rows > 0)
                            {
                                MessageBox.Show(
                                    "Employee Deleted Successfully!",
                                    "Success",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Information);
                                //LoadEmployeeData();
                                Total_NetSalary1();

                                ClearFields();
                                LoadEmployeeData();
                            }
                            else
                            {
                                MessageBox.Show("Employee ID not found!");
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            LoadEmployeeData();
            //LoadEmployeeData();

            dataGridView1.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.Fill;

            dataGridView1.SelectionMode =
                DataGridViewSelectionMode.FullRowSelect;

            dataGridView1.MultiSelect = false;

            dataGridView1.ReadOnly = true;

            dataGridView1.AllowUserToAddRows = false;
        }
        private void LoadEmployeeData()
        {
            try
            {
                using (SqlConnection con = new SqlConnection(cs))
                {
                    string query = "SELECT * FROM EmployeePayroll";

                    SqlDataAdapter da =
                        new SqlDataAdapter(query, con);

                    DataTable dt = new DataTable();

                    da.Fill(dt);

                    dataGridView1.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "Database Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }

        }
        private void RESET_Click(object sender, EventArgs e)
        {
            ClearFields();
        }
            private void ClearFields()
        {
            IDtextBox1.Clear();
            NAMEtextBox2.Clear();
            DESIGtextBox3.Clear();
            BASICPAYtextBox4.Clear();
            CtextBox5.Clear();
            MtextBox6.Clear();
            HRtextBox7.Clear();
            GPtextBox8.Clear();
            ITtextbox.Clear();
            NStextBox10.Clear();

            IDtextBox1.Focus();
        }

        private void MDKEFM(object sender, EventArgs e)
        {

        }

        private void SEARCH1_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void SEARCH_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(cs))
                {
                    string query = "SELECT * FROM EmployeePayroll WHERE ID = @ID";

                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue(
                            "@ID",
                            Convert.ToInt32(IDtextBox1.Text));

                        con.Open();

                        SqlDataReader dr = cmd.ExecuteReader();

                        if (dr.Read())
                        {
                            NAMEtextBox2.Text = dr["Name"].ToString();
                            DESIGtextBox3.Text = dr["Designation"].ToString();
                            BASICPAYtextBox4.Text = dr["BasicPay"].ToString();
                            CtextBox5.Text = dr["Conveyance"].ToString();
                            MtextBox6.Text = dr["Medical"].ToString();
                            HRtextBox7.Text = dr["HouseRent"].ToString();
                            GPtextBox8.Text = dr["GrossPay"].ToString();

                            decimal tax = Convert.ToDecimal(dr["IncomeTax"]);

                            if (tax == 0)
                            {
                                ITtextbox.Text = "No Tax Applied";
                            }
                            else
                            {
                                ITtextbox.Text = tax.ToString("0.00");
                            }

                            NStextBox10.Text = dr["NetSalary"].ToString();
                        }
                        else
                        {
                            MessageBox.Show("Employee not found!");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];

                IDtextBox1.Text = row.Cells["ID"].Value.ToString();
                NAMEtextBox2.Text = row.Cells["Name"].Value.ToString();
                DESIGtextBox3.Text = row.Cells["Designation"].Value.ToString();
                BASICPAYtextBox4.Text = row.Cells["BasicPay"].Value.ToString();
                CtextBox5.Text = row.Cells["Conveyance"].Value.ToString();
                MtextBox6.Text = row.Cells["Medical"].Value.ToString();
                HRtextBox7.Text = row.Cells["HouseRent"].Value.ToString();
                GPtextBox8.Text = row.Cells["GrossPay"].Value.ToString();

                decimal tax = Convert.ToDecimal(row.Cells["IncomeTax"].Value);

                if (tax == 0)
                {
                    ITtextbox.Text = "No Tax Applied";
                }
                else
                {
                    ITtextbox.Text = tax.ToString("0.00");
                }

                NStextBox10.Text = row.Cells["NetSalary"].Value.ToString();
            }
        }

        private void Total_NetSalary1()
        {
            SqlConnection con = new SqlConnection(cs);
            string query = "select sum (netsalary) from EmployeePayroll";
            SqlCommand cmd = new SqlCommand(query, con);
            con.Open();
            int a = Convert.ToInt32(cmd.ExecuteScalar());
            textBox2.Text = a.ToString();
            con.Close();

        }
        private void Total_Employees()
        {
            SqlConnection con = new SqlConnection(cs);
            string query = "select count(id) from EmployeePayroll";
            SqlCommand cmd = new SqlCommand(query, con);
            con.Open();
            int a = Convert.ToInt32(cmd.ExecuteScalar());
            textBox1.Text = a.ToString();
            con.Close();

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            IDtextBox1.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            NAMEtextBox2.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            DESIGtextBox3.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
            BASICPAYtextBox4.Text= dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
          
        }
    }

    }

    

