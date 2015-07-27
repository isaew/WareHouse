using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Mail;

namespace WareHouseRelic
{
    public partial class FormSendMail : Form
    {
        public FormSendMail()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if(richTextBox1.Text != "")
                {
                    MailMessage mail = new MailMessage();
                    mail.From = new MailAddress("comandor.cry@gmail.com");
                    mail.To.Add(new MailAddress("comandor.cry@yandex.ru"));
                    mail.Subject = textBox1.Text;
                    mail.Body = richTextBox1.Text;
                    /*if (!string.IsNullOrEmpty(attachFile))
                        mail.Attachments.Add(new Attachment(attachFile));*/

                    SmtpClient client = new SmtpClient();
                    client.Host = "smtp.gmail.com";
                    client.Port = 587;
                    client.EnableSsl = true;
                    client.Credentials = new NetworkCredential("comandor.cry@gmail.com".Split('@')[0], "80688978775");
                    client.DeliveryMethod = SmtpDeliveryMethod.Network;
                    client.Send(mail);
                    mail.Dispose();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Mail.Send: " + ex.Message);
            }

            this.Close();
        }
    }
}
