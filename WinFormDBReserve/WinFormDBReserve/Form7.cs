using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Mail;

namespace WinFormDBReserve
{
    public partial class Form7 : Form
    {
        public Form7()
        {
            InitializeComponent();
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            try
            {
                MailMessage mail = new MailMessage();
                SmtpClient smtp = new SmtpClient("smtp.gmail.com");
                mail.From = new MailAddress(txtFrom.Text);
                mail.To.Add(txtTo.Text);
                mail.Subject = txtTittle.Text;
                mail.Body = txtBody.Text;

                System.Net.Mail.Attachment attachment;
                attachment = new System.Net.Mail.Attachment(lblLocation.Text);
                mail.Attachments.Add(attachment);

                smtp.Port = 587;
                smtp.Credentials = new System.Net.NetworkCredential(txtFrom.Text, txtPassword.Text);
                smtp.EnableSsl = true;
                smtp.Send(mail);
                MessageBox.Show("Mail has been successfully sent", "Email sent", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message); 
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            openFileDialog1.ShowDialog();
            lblLocation.Text = openFileDialog1.FileName;
        }

        private void Form7_Load(object sender, EventArgs e)
        {

        }
    }
}
