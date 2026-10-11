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
    public partial class Form1 : Form
    {
        int finalCost = 0;
        int SrNo = 0;
        int tax = 0;
        string cs = ConfigurationManager.ConnectionStrings["dbcs"].ConnectionString;

        public Form1()
        {
            InitializeComponent();
            getinvoiceid();
            USERtextBox2.Text = LOGIN.username;
            GetItems();
            dataGridView1.ColumnCount = 8;
            dataGridView1.Columns[0].Name = "SR NO";
            dataGridView1.Columns[1].Name = "ITEM NAME";
            dataGridView1.Columns[2].Name = "UNIT PRICE";
            dataGridView1.Columns[3].Name = "DISCOUNT";
            dataGridView1.Columns[4].Name = "QUANTITY";
            dataGridView1.Columns[5].Name = "SUBTOTAL";
            dataGridView1.Columns[6].Name = "TAX";
            dataGridView1.Columns[7].Name = "TOTAL COST";



        }

        void GetItems()
        {
            ITEMcomboBox1.Items.Clear();
            SqlConnection con = new SqlConnection(cs);
            string query = "select * from items_tbl";
            SqlCommand cmd = new SqlCommand(query, con);
            con.Open();

            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                string item_name = dr.GetString(1);
                ITEMcomboBox1.Items.Add(item_name);

            }
            ITEMcomboBox1.Sorted = true;
            con.Close();
        }
        void getPrice()
        {
            if (ITEMcomboBox1.SelectedItem == null)
            {

            }
            else
            {

                int price = 0;
                SqlConnection con = new SqlConnection(cs);
                string query = "select item_price from items_tbl where item_name=@name";
                SqlDataAdapter sda = new SqlDataAdapter(query, con);
                sda.SelectCommand.Parameters.AddWithValue("@name", ITEMcomboBox1.SelectedItem.ToString());
                DataTable data = new DataTable();
                sda.Fill(data);

                if (data.Rows.Count > 0)
                {
                    price = Convert.ToInt32(data.Rows[0]["item_price"]);

                }
                PRICEtextBox3.Text = price.ToString();

            }
        }

        void getDiscount()
        {
            if (ITEMcomboBox1.SelectedItem == null)
            {

            }
            else
            {
                int discount = 0;
                SqlConnection con = new SqlConnection(cs);
                string query = "select item_discount from items_tbl where item_name=@name";
                SqlDataAdapter sda = new SqlDataAdapter(query, con);
                sda.SelectCommand.Parameters.AddWithValue("@name", ITEMcomboBox1.SelectedItem.ToString());
                DataTable data = new DataTable();
                sda.Fill(data);

                if (data.Rows.Count > 0)
                {
                    discount = Convert.ToInt32(data.Rows[0]["item_discount"]);

                }
                DISCOUNTtextBox4.Text = discount.ToString();

            }
        }
        private void ITEMcomboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            getPrice();
            getDiscount();
            QUANTITYtextBox6.Enabled = true;
        }

        private void QUANTITYtextBox6_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(QUANTITYtextBox6.Text) == true)
            {

            }
            else
            {
                int price = Convert.ToInt32(PRICEtextBox3.Text);
                int discount = Convert.ToInt32(DISCOUNTtextBox4.Text);
                int quantity = Convert.ToInt32(QUANTITYtextBox6.Text);

                int subtotal = price * quantity;
                subtotal = subtotal - discount * quantity;
                SUBTOTALtextBox7.Text = subtotal.ToString();
            }
        }

        private void SUBTOTALtextBox7_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(SUBTOTALtextBox7.Text) == true)
            {

            }
            else
            {
                int subtTotal = Convert.ToInt32(SUBTOTALtextBox7.Text);

                if (subtTotal >= 10000)
                {
                    tax = (int)(subtTotal * 0.15);
                    TAXtextBox8.Text = tax.ToString();

                }
                else if (subtTotal >= 6000)
                {
                    tax = (int)(subtTotal * 0.10);
                    TAXtextBox8.Text = tax.ToString();

                }
                else if (subtTotal >= 3000)
                {
                    tax = (int)(subtTotal * 0.07);
                    TAXtextBox8.Text = tax.ToString();

                }
                if (subtTotal >= 1000)
                {
                    tax = (int)(subtTotal * 0.05);
                    TAXtextBox8.Text = tax.ToString();

                }
                else
                {
                    tax = (int)(subtTotal * 0.03);
                    TAXtextBox8.Text = tax.ToString();

                }
            }
        }


        private void TAXtextBox8_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(TAXtextBox8.Text) == true)
            {

            }
            else
            {
                int subtotal = Convert.ToInt32(SUBTOTALtextBox7.Text);
                int tax = Convert.ToInt32(TAXtextBox8.Text);
                int totalcost = subtotal + tax;
                TOTALCOSTtextBox9.Text = totalcost.ToString();
            }
        }
        void AddDataToGridView(string Sr_No,string item_name,string unit_price,string discount,string quanity,string sub_total,string tax,string total_cost)
            {
                string[] row = { Sr_No, item_name, unit_price, discount, quanity, sub_total, tax, total_cost };
                dataGridView1.Rows.Add(row);       
        }

        private void ADDbutton1_Click(object sender, EventArgs e)
        {
            if (ITEMcomboBox1.SelectedItem != null)
            {
                AddDataToGridView((++SrNo).ToString(), ITEMcomboBox1.SelectedItem.ToString(), PRICEtextBox3.Text, DISCOUNTtextBox4.Text, QUANTITYtextBox6.Text, SUBTOTALtextBox7.Text, TAXtextBox8.Text, TOTALCOSTtextBox9.Text);
                ResetControls();
                CalculateFinalcost();
            }
            else
            {
                MessageBox.Show("Please Select an Item !!");
            }
        }

        void ResetControls()
        {
            ITEMcomboBox1.SelectedItem = null;
            PRICEtextBox3.Clear();
            DISCOUNTtextBox4.Clear();
            QUANTITYtextBox6.Clear();
            SUBTOTALtextBox7.Clear();
            TAXtextBox8.Clear();
            TOTALCOSTtextBox9.Clear();
            FINALCOSTtextBox11.Clear();
            AMOUNTtextBox12.Clear();
            CHANGEtextBox13.Clear();
            QUANTITYtextBox6.Enabled = false;
        }

        void CalculateFinalcost()
        {
            finalCost = 0;
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                finalCost = finalCost + Convert.ToInt32(dataGridView1.Rows[i].Cells[7].Value);
            }
            FINALCOSTtextBox11.Text = finalCost.ToString();
        }

        private void AMOUNTtextBox12_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(AMOUNTtextBox12.Text) == true)
            {
                
            }
            else
            {
                int amountpaid=Convert.ToInt32(AMOUNTtextBox12.Text);
                int fcost = Convert.ToInt32(FINALCOSTtextBox11.Text);
                int change = amountpaid - fcost;
                CHANGEtextBox13.Text = change.ToString();

            }
        }

        private void RESETbutton2_Click(object sender, EventArgs e)
        {
            ResetControls();
        }

        private void CLEARbutton1_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            SrNo = 0;
        }
        void getinvoiceid()
        {
            SqlConnection con = new SqlConnection(cs);
            string query = "select invoice_id from order_master";
            SqlDataAdapter sda = new SqlDataAdapter(query, con);
            DataTable data = new DataTable();
            sda.Fill(data);
            if (data.Rows.Count < 1)
            {
                INVOICEtextBox1.Text = "1";

            }
            else
            {
            string query2 = "select max(invoice_id) from order_master";
                SqlCommand cmd = new SqlCommand(query2, con);
                con.Open();
                int a = Convert.ToInt32(cmd.ExecuteScalar());
                a = a + 1;
                INVOICEtextBox1.Text=a.ToString();
                con.Close();

            }
        }

        private void INSERTbutton1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(cs);
            string query = "insert into order_master values(@user,@datetime,@finalcost)";
            SqlCommand cmd=new SqlCommand(query, con);
            //cmd.Parameters.AddWithValue("@id", INVOICEtextBox1.Text);
            cmd.Parameters.AddWithValue("@user", USERtextBox2.Text);
            cmd.Parameters.AddWithValue("@datetime", DateTime.Now.ToString());
            cmd.Parameters.AddWithValue("@finalcost", FINALCOSTtextBox11.Text);
            con.Open();
            int a = cmd.ExecuteNonQuery();
            if (a>0)
            {
                MessageBox.Show("Inserted Successfully !!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                getinvoiceid();
                ResetControls();


            }
            else
            {
                MessageBox.Show("Insertion Failed", "Failure !!", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            con.Close();
            InsertIntoOrderDetails();
        }

        int getlastInsertedInvoiceId()
        {
            SqlConnection con = new SqlConnection(cs);
            string query = "select max(invoice_id) from order_master";
            SqlCommand cmd = new SqlCommand(query, con);
            con.Open();
            int MaxInvoiceId = Convert.ToInt32(cmd.ExecuteScalar());

            con.Close() ;
            return MaxInvoiceId;
        }

        void InsertIntoOrderDetails()
        {
            int a = 0;
            SqlConnection con = new SqlConnection(cs);
            try
            {


                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    string query = "insert into order_details values(@invoice_id,@name,@price,@discount,@quantity,@subtotal,@tax,@finalcost)";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@invoice_id", getlastInsertedInvoiceId());
                    cmd.Parameters.AddWithValue("@name", dataGridView1.Rows[i].Cells[1].Value.ToString());
                    cmd.Parameters.AddWithValue("@price", dataGridView1.Rows[i].Cells[2].Value);
                    cmd.Parameters.AddWithValue("@discount", dataGridView1.Rows[i].Cells[3].Value);
                    cmd.Parameters.AddWithValue("@quantity", dataGridView1.Rows[i].Cells[4].Value);
                    cmd.Parameters.AddWithValue("@subtotal", dataGridView1.Rows[i].Cells[5].Value);
                    cmd.Parameters.AddWithValue("@tax", dataGridView1.Rows[i].Cells[6].Value);
                    cmd.Parameters.AddWithValue("@finalcost", dataGridView1.Rows[i].Cells[7].Value);

                    con.Open();
                    a = a + cmd.ExecuteNonQuery();
                    con.Close();
                }
            }
            catch
            {

            }

            //if (a > 0) 
            //{
            //    MessageBox.Show("Data Added in Order Details !!");
            //}
            //else
            //{
            //    MessageBox.Show("Data Not Added in Order Details !!");

            //}

        }
        private void QUANTITYtextBox6_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (char.IsDigit(ch) == true)
            {
                e.Handled = false;
            }
            else if (ch == 8)
            {
                e.Handled = false;
            }
            else
            {
                e.Handled= true;
            }
        }

        private void AMOUNTtextBox12_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (char.IsDigit(ch) == true)
            {
                e.Handled = false;
            }
            else if (ch == 8)
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void PRINTPREVIEbutton1_Click(object sender, EventArgs e)
        {
            printPreviewDialog1.Document = printDocument1;
            printPreviewDialog1.ShowDialog();
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            Bitmap bmp = Properties.Resources.images;
            Image img = bmp;
            e.Graphics.DrawImage(img, 30, 5, 800, 250);
            e.Graphics.DrawString("Invoice Id: " + INVOICEtextBox1.Text, new Font("Arial", 15, FontStyle.Bold), Brushes.Black,new Point(30,300));
            e.Graphics.DrawString("User Name: " + USERtextBox2.Text, new Font("Arial", 15, FontStyle.Bold), Brushes.Black, new Point(30, 330));
            e.Graphics.DrawString("Date: " + DateTime.Now.ToShortDateString(), new Font("Arial", 15, FontStyle.Bold), Brushes.Black, new Point(30, 360));
            e.Graphics.DrawString("Time: " + DateTime.Now.ToLongTimeString(), new Font("Arial", 15, FontStyle.Bold), Brushes.Black, new Point(30, 390));
            e.Graphics.DrawString("-------------------------------------------------------------------------------------------------------------------------------------------------", new Font("Arial", 15, FontStyle.Bold), Brushes.Black, new Point(30, 420));
            e.Graphics.DrawString("ITEM" , new Font("Arial", 15, FontStyle.Bold), Brushes.Black, new Point(30, 450));
            e.Graphics.DrawString("PRICE" , new Font("Arial", 15, FontStyle.Bold), Brushes.Black, new Point(240,450));
            e.Graphics.DrawString("QUANTITY", new Font("Arial", 15, FontStyle.Bold), Brushes.Black, new Point(390, 450));
            e.Graphics.DrawString("DISCOUNT", new Font("Arial", 15, FontStyle.Bold), Brushes.Black, new Point(590, 450));
            e.Graphics.DrawString("--------------------------------------------------------------------------------------------------------------------------------------------------", new Font("Arial", 15, FontStyle.Bold), Brushes.Black, new Point(30, 480));

            //ITEM
            int gap = 510;  
            if (dataGridView1.Rows.Count > 0) 
            {
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    try
                    {
                        e.Graphics.DrawString(dataGridView1.Rows[i].Cells[1].Value.ToString(), new Font("Arial", 15, FontStyle.Bold), Brushes.Black, new Point(30, gap));
                        gap = gap + 30;
                    }
                    catch
                    { 

                    }
                }
            }

            //PRICE
            int gap1 = 510;
            if (dataGridView1.Rows.Count > 0)
            {
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    try
                    {
                        e.Graphics.DrawString(dataGridView1.Rows[i].Cells[2].Value.ToString(), new Font("Arial", 15, FontStyle.Bold), Brushes.Black, new Point(260, gap1));
                        gap1 = gap1 + 30;
                    }
                    catch
                    {

                    }
                }
            }

            //QUANTITY
            int gap2 = 510;
            if (dataGridView1.Rows.Count > 0)
            {
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    try
                    {
                        e.Graphics.DrawString(dataGridView1.Rows[i].Cells[4].Value.ToString(), new Font("Arial", 15, FontStyle.Bold), Brushes.Black, new Point(410, gap2));
                        gap2 = gap2 + 30;
                    }
                    catch
                    {

                    }
                }
            }

            //DISCOUNT
            int gap3 = 510;
            if (dataGridView1.Rows.Count > 0)
            {
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    try
                    {
                        e.Graphics.DrawString(dataGridView1.Rows[i].Cells[3].Value.ToString(), new Font("Arial", 15, FontStyle.Bold), Brushes.Black, new Point(610, gap3));
                        gap3 = gap3 + 30;
                    }
                    catch
                    {

                    }
                }
            }


            int SubtotalPrint = 0;
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                SubtotalPrint = SubtotalPrint + Convert.ToInt32(dataGridView1.Rows[i].Cells[5].Value);
            }
            e.Graphics.DrawString("--------------------------------------------------------------------------------------------------------------------------------------------------", new Font("Arial", 15, FontStyle.Bold), Brushes.Black, new Point(30, 850));
            e.Graphics.DrawString("Sub-Total : " + SubtotalPrint.ToString(), new Font("Arial", 15, FontStyle.Bold), Brushes.Black, new Point(30, 880));

            int taxPrint = 0;
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                taxPrint = taxPrint + Convert.ToInt32(dataGridView1.Rows[i].Cells[6].Value);
            }
            //e.Graphics.DrawString("--------------------------------------------------------------------------------------------------------------------------------------------------", new Font("Arial", 15, FontStyle.Bold), Brushes.Black, new Point(30, 850));
            e.Graphics.DrawString("Tax : " + taxPrint.ToString(), new Font("Arial", 15, FontStyle.Bold), Brushes.Black, new Point(30, 910));
            e.Graphics.DrawString("Final Amount : " + FINALCOSTtextBox11.Text, new Font("Arial", 15, FontStyle.Bold), Brushes.Black, new Point(30, 940));
            e.Graphics.DrawString("--------------------------------------------------------------------------------------------------------------------------------------------------", new Font("Arial", 15, FontStyle.Bold), Brushes.Black, new Point(30, 970));
            e.Graphics.DrawString("Amount Paid : " + AMOUNTtextBox12.Text, new Font("Arial", 15, FontStyle.Bold), Brushes.Black, new Point(30, 1000));
            e.Graphics.DrawString("Change : " + CHANGEtextBox13.Text, new Font("Arial", 15, FontStyle.Bold), Brushes.Black, new Point(30, 1030));



        }

        private void PRINTbutton2_Click(object sender, EventArgs e)
        {
            printDocument1.Print();
        }

        private void addItemToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddItemForm adf=new AddItemForm();
            adf.ShowDialog();
        }

        private void Form1_Activated(object sender, EventArgs e)
        {
            GetItems();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void editItemToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EditItemsform edf=new EditItemsform();
            edf.ShowDialog();
        }

        private void viewDataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ViewDataForm vdf = new ViewDataForm();
            vdf.ShowDialog();
        }

        private void detailAndSearchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DetailsandSearchForm das = new DetailsandSearchForm();
            das.ShowDialog();
        }
    }
}
