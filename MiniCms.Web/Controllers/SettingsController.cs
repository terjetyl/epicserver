using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MiniCms.Model.Repositories;
using MiniCms.Web.Code.Filters;
using MiniCms.Web.Models.Entities;

namespace MiniCms.Web.Controllers
{
    [Authorize]
    public class SettingsController : BaseController
    {
        IUserRepository _userRepository;

        public SettingsController(IUserRepository userRepository)
            : base(userRepository)
        {
            _userRepository = userRepository;
        }

        [FillViewBag]
        public ActionResult Index()
        {
            return View(Mapper.Map(LoggedInUser));
        }

        [FillViewBag]
        [HttpPost]
        public ActionResult Index(UserModel userModel)
        {
            var user = _userRepository.Get(userModel.Id);
            user.Name = userModel.Name;
            user.Email = userModel.Email;
            _userRepository.Save(user);
            return RedirectToAction("index");
        }
    }
}
