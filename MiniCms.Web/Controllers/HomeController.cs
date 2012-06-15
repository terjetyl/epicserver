using System.Web.Mvc;
using System.Linq;
using MiniCms.Model.Repositories;
using MiniCms.Web.Models;
using MiniCms.Web.Code.Filters;

namespace MiniCms.Web.Controllers
{
    [FillViewBag]
    public class HomeController : Controller
    {
        private readonly IBlogPostRepository _blogPostRepository;

        public HomeController(IBlogPostRepository blogPostRepository)
        {
            _blogPostRepository = blogPostRepository;
        }

        public ActionResult Index()
        {
            var posts = _blogPostRepository.GetAll().Where(o => o.Published);
            var viewModel = new HomeIndexModel { Posts = posts.OrderByDescending(o => o.DateCreated).Select(Mapper.Map) };

            return View(viewModel);
        }

        public ActionResult About()
        {
            return View();
        }

        public ActionResult SignalR()
        {
            return View();
        }
    }
}
