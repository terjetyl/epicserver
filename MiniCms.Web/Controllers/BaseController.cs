using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using System.Web.Security;
using MiniCms.Model;
using MiniCms.Model.Entities;
using MiniCms.Model.Repositories;
using MiniCms.Web.Code.ExtensionMethods;
using MiniCms.Web.Models;
using MiniCms.Web.Models.Entities;

namespace MiniCms.Web.Controllers
{
    public class BaseController : Controller
    {
        private readonly IUserRepository _userRepository;

        public BaseController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        private User _loggedInUser;
        public User LoggedInUser
        {
            get
            {
                if (Request == null)
                    return null;
                if (!Request.IsAuthenticated)
                    return null;
                if (_loggedInUser == null)
                {
                    _loggedInUser = _userRepository.GetByUsername(User.Identity.Name);
                    _loggedInUser.Groups.AddRange(Roles.GetRolesForUser(User.Identity.Name));
                }
                return _loggedInUser;
            }
        }

        public int PageIndex
        {
            get
            {
                int? page = Request["page"].ToInt();
                if (page == null)
                    return 0;
                return page.Value - 1;
            }
        }

        public int PageSize
        {
            get { return Request["pagesize"].ToInt() ?? 30; }
        }
    }
}
