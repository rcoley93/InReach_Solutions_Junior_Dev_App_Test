using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace InReach_Solutions_Junior_Dev_App_Test.Services
{
    public class EmailService : IMailService
    {
        private readonly EmailSettings esConfig;

        public EmailService(EmailSettings Config)
        {
            this.esConfig = Config;
        }

        public async Task SendEmail(string ToEmail, string Subject, string HTMLBody)
        {
            MailMessage message = new MailMessage();
            SmtpClient smtp = new SmtpClient();
            message.From = new MailAddress(this.esConfig.strFromEmail);
            message.To.Add(new MailAddress(ToEmail));
            message.Subject = Subject;
            message.IsBodyHtml = true;
            message.Body = HTMLBody;
            smtp.Port = this.esConfig.iPort;
            smtp.Host = this.esConfig.strHost;
            smtp.EnableSsl = true;
            smtp.UseDefaultCredentials = false;
            smtp.Credentials = new NetworkCredential(this.esConfig.strUsername, this.esConfig.strPassword);
            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
            await smtp.SendMailAsync(message);
        }
    }
}
