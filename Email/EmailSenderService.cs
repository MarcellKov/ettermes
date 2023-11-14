using System.Net;
using System.Net.Mail;

namespace webapp.Email
{
    public interface IEmailSenderService 
    {
        Task SendEmailAsync(string receipent, string subject, string message);
    }

    public class EmailSenderService : IEmailSenderService
    {
        public Task SendEmailAsync(string receipent,string subject, string message)
        {
            var client = new SmtpClient
            (
             "smtp.gmail.com", 587
            )
            {EnableSsl=true, Credentials=new NetworkCredential("kmarcell379@gmail.com", "tqpf gbwd ehsn timj") };
            var mm = new MailMessage("kmarcell379@gmail.com", receipent, subject, message);
            mm.IsBodyHtml = true;
            return client.SendMailAsync(mm);
            
        }
    }
}
