using System.Linq;
using System.Web.Mvc;
using MiniCms.Model;
using MiniCms.Model.Entities;
using MiniCms.Model.Repositories;
using MiniCms.Web.Models;
using MiniCms.Web.Models.Entities;
using MiniCms.Web.Code.Filters;

namespace MiniCms.Web.Controllers
{
    public class NewslettersController : BaseController
    {
        private readonly INewsletterSubscriberRepository _newsletterSubscriberRepository;
        private readonly IBlogPostRepository _blogPostRepository;
        private readonly IBlogRepository _blogRepository;
        private readonly NewsletterService _newsletterService;
        public NewslettersController(IFeatureRepository featureRepository, INewsletterRepository newsletterRepository, INewsletterSubscriberRepository newsletterSubscriberRepository, IBlogPostRepository blogPostRepository, IBlogRepository blogRepository, IUserRepository userRepository) : 
            base(userRepository)
        {
            _blogPostRepository = blogPostRepository;
            _newsletterSubscriberRepository = newsletterSubscriberRepository;
            _newsletterService = new NewsletterService(newsletterRepository);
            _blogRepository = blogRepository;
        }

        [FillViewBag]
        public ActionResult Index()
        {
            return View();
        }

        [FillViewBag]
        public ActionResult Create(int blogpost = 0)
        {
            var viewModel = new EditBlogPostViewModel();
            if(blogpost > 0)
            {
                var blogPost = _blogPostRepository.Get(blogpost);
                viewModel.BlogPost = new BlogPostModel
                                         {
                                             Title = blogPost.Title,
                                             ImageUrl = blogPost.ImageUrl,
                                             Body = blogPost.Body
                                         };
            }
            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Create(EditBlogPostViewModel viewModel)
        {
            var subscribers = _newsletterSubscriberRepository.GetAll();
            var newsLetter = new Newsletter(subscribers)
                                 {
                                     Title = viewModel.BlogPost.Title,
                                     ImageUrl = viewModel.BlogPost.ImageUrl,
                                     Body = viewModel.BlogPost.Body
                                 };
            new MailController(_blogRepository).SendNewsletter(newsLetter).Deliver();
            return RedirectToAction("Index");
        }

        [FillViewBag]
        public ActionResult Subscribers()
        {
            var subscribers = _newsletterSubscriberRepository.GetAll();
            return View(subscribers);
        }

        public ActionResult Unsubscribe(int id)
        {
            _newsletterSubscriberRepository.Delete(id);
            return RedirectToAction("Index");
        }

    }
}
