using System.Web.Mvc;

namespace MiniCms.Web.Areas.Admin.Controllers
{
    public class DashboardController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Stats()
        {
            return View();
        }
    }
}
