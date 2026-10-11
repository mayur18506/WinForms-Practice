using _49.DATABASE_FIRST_APPROCH_CRUD.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _49.DATABASE_FIRST_APPROCH_CRUD
{
    public partial class Form1 : Form
    {
        int id = 0;
        student model = new student();
        DatabaseFirstDBEntities db = new DatabaseFirstDBEntities();
        public Form1()
        {
            InitializeComponent();
            bindGridView();
        }
        void Resetcontrols()
        {
            nametextBox1.Clear();
            gendercomboBox1.SelectedItem = null;
            agetextBox3.Clear();
            classtextBox4.Clear();
        }
        void bindGridView()
        {
            dataGridView1.DataSource = db.students.ToList<student>();
        }

        private void ibutton1_Click(object sender, EventArgs e)
        {
            model.name=nametextBox1.Text.Trim();
            model.gender=gendercomboBox1.SelectedItem.ToString();
            model.age=Convert.ToInt32 (agetextBox3.Text.Trim());
            model.standard=Convert.ToInt32(classtextBox4.Text.Trim());
            db.students.Add(model);
            int a=db.SaveChanges();
            if (a>0)
            {
                MessageBox.Show("Data Inserted Sucessfully !!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                bindGridView();
                Resetcontrols();
            }
            else
            {
                MessageBox.Show("Data Insertion Failed !!", "Failure", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
        }

        private void rbutton4_Click(object sender, EventArgs e)
        {
            Resetcontrols();
        }

        private void dataGridView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            id =Convert.ToInt32 (dataGridView1.SelectedRows[0].Cells[0].Value);
            model = db.students.Where(x => x.id == id).FirstOrDefault();
            nametextBox1.Text = model.name;
            gendercomboBox1.SelectedItem = model.gender;
            agetextBox3.Text = model.age.ToString();
            classtextBox4.Text = model.standard.ToString();

        }

        private void ubutton2_Click(object sender, EventArgs e)
        {
            model.id = id;
            model.name = nametextBox1.Text.Trim();
            model.gender = gendercomboBox1.SelectedItem.ToString();
            model.age = Convert.ToInt32(agetextBox3.Text.Trim());
            model.standard = Convert.ToInt32(classtextBox4.Text.Trim());
            db.Entry(model).State = EntityState.Modified;
            int a = db.SaveChanges();
            if (a > 0)
            {
                MessageBox.Show("Data Updated Sucessfully !!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                bindGridView();
                Resetcontrols();
            }
            else
            {
                MessageBox.Show("Data Updation Failed !!", "Failure", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
        }

        private void dbutton3_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Are you sure to delete data?", "Alert", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dr == DialogResult.Yes)
            {
            model = db.students.Where(x => x.id == id).FirstOrDefault();
                db.Entry(model).State = EntityState.Deleted;
                int a = db.SaveChanges();
                if (a > 0)
                {
                    MessageBox.Show("Data Deleted Sucessfully !!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    bindGridView();
                    Resetcontrols();
                }
                else
                {
                    MessageBox.Show("Data Deletion Failed !!", "Failure", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
            }
            else
            {
                    MessageBox.Show("Yoh have cancelled the delete operation !!", "Abort", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
        }
    }
}
