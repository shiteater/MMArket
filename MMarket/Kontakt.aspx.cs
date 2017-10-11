
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MMarket
{
    public partial class Kontakt : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click1(object sender, EventArgs e)
        {
            // Specify the from and to email address
            MailMessage mailMessage = new MailMessage("info@habibi-orient.com", "info@habibi-orient.com");
            // Specify the email body
            if (!string.IsNullOrWhiteSpace(TbxPhone.Text))
            {
                mailMessage.Body = "Ime i Prezime: " + TbxName.Text + " " + TbxLastName.Text + "\n" + "email: " + TbxMail.Text + "\n" + "Phone: " + TbxPhone.Text + "\n" + textarea1.Text;
            }
            else
            {
                mailMessage.Body = "Ime i Prezime: " + TbxName.Text + " " + TbxLastName.Text + "\n" + "email: " + TbxMail.Text + "\n" + textarea1.Text;
            }
            
            // Specify the email Subject
            mailMessage.Subject = "Upit Od Korisnika";
            
            // Specify the SMTP server name and post number
            SmtpClient smtpClient = new SmtpClient("mail.habibi-orient.com", 8889);
            // Specify your gmail address and password
            smtpClient.Credentials = new System.Net.NetworkCredential()
            {
                UserName = "info@habibi-orient.com",
                Password = "Habibi123!"
            };
            // Gmail works on SSL, so set this property to true
            //smtpClient.EnableSsl = true;
            // Finall send the email message using Send() method
            smtpClient.Send(mailMessage);
            Response.Write("<script>alert('Uspješno ste poslali poruku');window.location='Kontakt.aspx'</script>");
           
        }
    }
}