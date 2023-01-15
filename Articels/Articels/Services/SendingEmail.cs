using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.CodeAnalysis.VisualBasic.Syntax;
using System.Net;
using System.Net.Mail;

namespace Articels.Services
{
    public class SendingEmail : IEmailSender
    {
        public async Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            var From = "myEmail";
            var pass = "mypassword";
            var message = new MailMessage();
            message.From = new MailAddress(From);
            message.Subject = subject;
            message.To.Add(email);
            message.Body = $"<html><body>{htmlMessage}</body></html>";
            message.IsBodyHtml = true;

            var smpt = new SmtpClient("smtp-mail.outlook.com")
            {
                Port=587,
                EnableSsl=true,
                Credentials=new NetworkCredential(From,pass)
            };
            smpt.Send(message);

        }
    }
}
