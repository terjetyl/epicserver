using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MiniCms.Web.Areas.Admin.Controllers
{
    public class CommentsController : Controller
    {
        //
        // GET: /Admin/Comments/

        public ActionResult Index()
        {
            return View();
        }

    }
}
