using _48.CODE_FIRST_APPROCH_EF.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _48.CODE_FIRST_APPROCH_EF
{
    public partial class Form1 : Form
    {
        int id = 0;
        Employee model = new Employee();
        DatabaseContext db = new DatabaseContext();
        public Form1()
        {
            InitializeComponent();
            bindGridView();
        }
        void bindGridView()
        {
            dataGridView1.DataSource = db.Employees.ToList<Employee>();
        }
        void ResetControls()
        {
            NAMEtextBox1.Clear();
            GENDERcomboBox1.SelectedItem= null;
            AGEtextBox3.Clear();
            DESIGtextBox4.Clear();
        }

        private void Ibutton1_Click(object sender, EventArgs e)
        {
            model.Name=NAMEtextBox1.Text;
            model.Gender = GENDERcomboBox1.SelectedItem.ToString();
            model.Age = Convert.ToInt32(AGEtextBox3.Text);
            model.Designation=DESIGtextBox4.Text;
            db.Employees.Add(model);
            int a =  db.SaveChanges();
            if (a>0)
            {
                MessageBox.Show("Data Inserted !!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                bindGridView();
                ResetControls();
            }
            else
            {
                MessageBox.Show("Data Not Inserted !!", "Failure", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
        }

        private void dataGridView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            id =Convert.ToInt32 (dataGridView1.SelectedRows[0].Cells[0].Value);
            model = db.Employees.Where(x => x.Id == id).FirstOrDefault();
            NAMEtextBox1.Text = model.Name;
            GENDERcomboBox1.SelectedItem = model.Gender;
            AGEtextBox3.Text = model.Age.ToString();
            DESIGtextBox4.Text = model.Designation;
        }

        private void Ubutton2_Click(object sender, EventArgs e)
        {
            model.Id = id;
            model.Name = NAMEtextBox1.Text;
            model.Gender=GENDERcomboBox1.SelectedItem.ToString();
            model.Age =Convert.ToInt32 (AGEtextBox3.Text);
            model.Designation = DESIGtextBox4.Text;

            db.Entry(model).State = EntityState.Modified;
            int a =  db.SaveChanges();

            if (a > 0)
            {
                MessageBox.Show("Data Updated !!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                bindGridView();
                ResetControls();
            }
            else
            {
                MessageBox.Show("Data Not Updated !!", "Failure", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
        }

        private void Dbutton3_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Are you sure to delete data?", "Alert", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dr == DialogResult.Yes)
            {
                model = db.Employees.Where(x => x.Id == id).FirstOrDefault();
                db.Entry(model).State = EntityState.Deleted;

                int a = db.SaveChanges();

                if (a > 0)
                {
                    MessageBox.Show("Data Deleted !!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    bindGridView();
                    ResetControls();
                }
                else
                {
                    MessageBox.Show("Data Not Deleted !!", "Failure", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
            }
            else
            {
                MessageBox.Show("You have cancelled the delete operation");
            }
        }
    }
}
