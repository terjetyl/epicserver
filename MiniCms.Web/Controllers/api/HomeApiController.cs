using System.Net.Mail;
using System.Web.Http;
using MiniCms.Model;
using MiniCms.Model.Repositories;
using MiniCms.Web.Models;

namespace MiniCms.Web.Controllers.api
{
    public class HomeController : ApiController
    {
        private readonly IMailService _mailService;
        private readonly IBlogRepository _blogRepository;
        public HomeController(IMailService mailService, IBlogRepository blogRepository)
        {
            _mailService = mailService;
            _blogRepository = blogRepository;
        }

        public void Post(RequestModel requestModel)
        {
            var blog = _blogRepository.First();
            var msg = new MailMessage {From = new MailAddress(requestModel.Email, requestModel.Name)};
            msg.To.Add(new MailAddress(blog.Email, blog.Name));
            msg.IsBodyHtml = true;
            msg.Body = requestModel.Message;
            _mailService.Send(msg);
        }
    }
}
