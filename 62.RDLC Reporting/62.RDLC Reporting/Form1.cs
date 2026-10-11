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

namespace _62.RDLC_Reporting
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //this.employeeTableAdapter1.Fill(this.rdlC_ReportsDataSet1.employee);

            //this.reportViewer1.RefreshReport();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem != null && NAMEtextBox1.Text != null)
            {
                this.employeeTableAdapter1.FillByBoth(this.rdlC_ReportsDataSet1.employee,NAMEtextBox1.Text ,comboBox1.SelectedItem.ToString());

                this.reportViewer1.RefreshReport();
            }
            else if (comboBox1.SelectedItem != null)
            {
                this.employeeTableAdapter1.FillByGender(this.rdlC_ReportsDataSet1.employee, comboBox1.SelectedItem.ToString());

                this.reportViewer1.RefreshReport();
            }

            else if (NAMEtextBox1.Text != "")
            {
                this.employeeTableAdapter1.FillByName(this.rdlC_ReportsDataSet1.employee, NAMEtextBox1.Text);

                this.reportViewer1.RefreshReport();

            }
            else if (IDtextBox1.Text != "")
            {
                this.employeeTableAdapter1.FillById(this.rdlC_ReportsDataSet1.employee, int.Parse(IDtextBox1.Text));

                this.reportViewer1.RefreshReport();

            }

            else
            {
                MessageBox.Show("Please Select one of th Field ...");
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.employeeTableAdapter1.Fill(this.rdlC_ReportsDataSet1.employee);

            this.reportViewer1.RefreshReport();
            NAMEtextBox1.Clear();
            comboBox1.SelectedItem = null;
        }
    }
}
