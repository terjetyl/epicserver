using System.Web.Mvc;

namespace MiniCms.Web.Controllers
{
    public class TagsController : Controller
    {
        public ActionResult Index(string tag = "")
        {
            return RedirectToAction("Search", "News", new { tag = tag });
        }

    }
}
