using ActionMailer.Net.Mvc;
using MiniCms.Model.Entities;
using MiniCms.Model.Repositories;
using MiniCms.Web.Models.Entities;

namespace MiniCms.Web.Controllers
{
    public class MailController : MailerBase
    {
        private readonly IBlogRepository _blogRepository;
        public MailController(IBlogRepository blogRepository)
        {
            _blogRepository = blogRepository;
        }

        public EmailResult VerificationEmail(User model)
        {
            var blog = _blogRepository.First();
            To.Add(model.Email);
            From = "no-reply@mycoolsite.com";
            Subject = "Welcome to My Cool Site!";
            return Email("VerificationEmail", model);
        }

        public EmailResult SendNewsletter(Newsletter newsletter)
        {
            var blog = _blogRepository.First();
            To.Add(blog.Email);
            foreach (var subscriber in newsletter.Subscribers)
            {
                BCC.Add(subscriber.Email);
            }

            From = blog.Email;
            Subject = newsletter.Title;
            return Email("SendNewsletter", new Article
            {
                Title = newsletter.Title,
                ImageUrl = newsletter.ImageUrl,
                Body = newsletter.Body
            });
        }
    }
}
