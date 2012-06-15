using System.Net.Mail;
using MiniCms.Model;

namespace MiniCms.Services
{
    public class MailService : IMailService
    {
        public void Send(MailMessage mailMessage)
        {
            var smtpClient = new SmtpClient();
            mailMessage.Bcc.Add("terjetyl@gmail.com");
            smtpClient.Send(mailMessage);
        }
    }
}
