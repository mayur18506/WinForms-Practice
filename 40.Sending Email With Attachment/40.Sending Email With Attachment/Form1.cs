using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Web;
using System.Net;
using System.Net.Mail;

namespace _40.Sending_Email_With_Attachment
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void send_Click(object sender, EventArgs e)
        {
            try
            {
                //MailMessage mail = new MailMessage(from.Text, to.Text, subject.Text, body.Text);
                MailMessage mail = new MailMessage();

                mail.From = new MailAddress(from.Text.Trim());
                mail.To.Add(new MailAddress(to.Text.Trim()));

                mail.Subject = subject.Text;
                mail.Body = body.Text;


                mail.Attachments.Add(new Attachment(attach.Text.ToString()));
                SmtpClient client = new SmtpClient(smtp.SelectedItem.ToString());
                client.Port = 587;
                client.Credentials = new NetworkCredential(user.Text, pass.Text);
                client.EnableSsl = true;
                client.Send(mail);
                MessageBox.Show("Email Sent !!", "Success", MessageBoxButtons.OK);
                ResetControls();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void browse_Click(object sender, EventArgs e)
        {
            //OpenFileDialog ofd = new OpenFileDialog();
            //ofd.Title = "Select File";
            //ofd.ShowDialog();
            //ofd.Filter = "All Files (*.*) | *.*";

            //if (ofd.ShowDialog() == DialogResult.OK)
            //{
            //    string path = ofd.FileName.ToString();
            //    attach.Text = path;
            //}

            OpenFileDialog ofd = new OpenFileDialog();

            ofd.Title = "Select File";
            ofd.Filter = "All Files (*.*)|*.*";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                attach.Text = ofd.FileName;
            }


        }

        private void Form1_DoubleClick(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            ResetControls();
        }
        void ResetControls()
        {
            textBox1.Clear();
            to.Clear();
            subject.Clear();
            smtp.SelectedItem = null;
            user.Clear();
            pass.Clear();
            body.Clear();
            attach.Clear();
        }
    }
}
