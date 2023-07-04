using System.Net.Mail;
using System.Net;
using Music.Web.Utilities.Contracts;

namespace Music.Web.Utilities.Implementation
{
    public class EmailSender : IEmailSender
    {
        public void send(string to, string subject, string body)
        {

            MailMessage mail = new MailMessage();

            SmtpClient smtpServer = new SmtpClient("smtp.gmail.com");

            mail.From = new MailAddress("***********8", "Music");
            mail.To.Add(to);
            mail.Subject = subject;
            mail.Body = body;
            mail.IsBodyHtml = true;


            smtpServer.Port = 587;
            smtpServer.Credentials = new NetworkCredential("************", "*************");
            smtpServer.EnableSsl = true;

            smtpServer.Send(mail);


        }
    }
}