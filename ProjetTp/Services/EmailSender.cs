using System.Net.Mail;
using System.Net;

namespace ProjetTp.Services
{
    public class EmailSender : IEmailSender
    {
         public async Task<bool> SendEmailAsync(string email, string subject, string confirmLink)
        {
            string mail = "jihenmkhinini4070@gmail.com";
            string pwd = "bgyd qdxq exvy ruis";
            MailMessage message = new MailMessage();
            message.From = new MailAddress(mail);
            message.To.Add(new MailAddress(email));
            message.Subject = subject;
            message.Body = confirmLink;
            message.IsBodyHtml = true;
            var client = new SmtpClient("smtp.gmail.com", 587)

            {
                EnableSsl = true,
                Credentials = new NetworkCredential(mail, pwd),
            };
            await client.SendMailAsync(message);
            return true;

        }
    }
}
