using System.Net.Mail;

namespace MiniCms.Model
{
    public interface IMailService
    {
        void Send(MailMessage mailMessage);
    }
}
