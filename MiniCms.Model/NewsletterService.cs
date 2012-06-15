using MiniCms.Model.Entities;
using MiniCms.Model.Repositories;

namespace MiniCms.Model
{
    public class NewsletterService
    {
        private INewsletterRepository _newsletterRepository;

        public NewsletterService(INewsletterRepository newsletterRepository)
        {
            _newsletterRepository = newsletterRepository;
        }

        public void Send(Newsletter newsletter)
        {
            // create mail

            // send to each recipient with a try catch
        }
    }
}
