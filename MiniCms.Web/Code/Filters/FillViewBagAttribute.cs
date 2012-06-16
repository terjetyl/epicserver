using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using MiniCms.Model;
using MiniCms.Model.Entities;
using MiniCms.Model.Repositories;
using Ninject;

namespace MiniCms.Web.Code.Filters
{
    public class FillViewBagAttribute : ActionFilterAttribute
    {
        [Inject]
        public IBlogRepository _blogRepository {get;set;}

        [Inject]
        public IFeatureRepository _featureRepository { get; set; }

        [Inject]
        public IUserRepository _userRepository { get; set; }

        private FeatureService _featureService;

        //[Inject]
        //private IBlogPostRepository _blogPostRepository;

        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            var viewResult = filterContext.Result as ViewResult;
            if (viewResult == null)
                return;

            var blog = _blogRepository.First();
            SetViewBag(blog, viewResult, filterContext.RequestContext.HttpContext.Request.IsAuthenticated ? LoggedInUser : null);
            base.OnActionExecuted(filterContext);
        }

        private User _loggedInUser;
        public User LoggedInUser
        {
            get
            {
                return _loggedInUser ??
                       (_loggedInUser = _userRepository.GetByUsername(HttpContext.Current.User.Identity.Name));
            }
        }

        private void SetViewBag(Blog blog, ViewResult viewResult, User user)
        {
            if (blog == null)
            {
                blog = SetupNewBlog();
            }

            _featureService = new FeatureService(_featureRepository);

            //var blogposts = _blogPostRepository.GetAll().Where(o => o.Published).ToList();
            //var archiveModel = new ArchiveModel();
            //var years = blogposts.Select(o => o.DateCreated.Year).Distinct().Select(i => new Year { Name = i });
            //foreach (var year in years)
            //{
            //    var months =
            //        blogposts.Where(o => o.DateCreated.Year == year.Name).Select(i => i.DateCreated.Month).Distinct().
            //            Select(y => new Month
            //            {
            //                Nr = y,
            //                Name = new DateTime(DateTime.Now.Year, y, 1).ToString("MMM")
            //            });
            //    foreach (var month in months)
            //    {
            //        var posts =
            //            blogposts.Where(o => o.DateCreated.Year == year.Name && o.DateCreated.Month == month.Nr);
            //        month.Posts.AddRange(posts.Select(o => new Article { Title = o.Title, Id = o.Id }));
            //        month.Count = posts.Count();
            //        year.Months.Add(month);
            //    }
            //    year.Count = months.Count();
            //    archiveModel.Years.Add(year);
            //}

            viewResult.ViewBag.Title = blog.Name;
            viewResult.ViewBag.Logo = blog.LogoUrl;
            viewResult.ViewBag.Name = blog.Name;
            viewResult.ViewBag.Description = blog.Description;
            viewResult.ViewBag.Phone = blog.Phone;
            viewResult.ViewBag.Fax = blog.Fax;
            viewResult.ViewBag.Address = blog.Address.AddressLine;
            viewResult.ViewBag.Post = blog.Address.Zip + " " + blog.Address.City;
            viewResult.ViewBag.FullAddress = blog.Address.AddressLine + ", " + blog.Address.Zip + " " + blog.Address.City;
            viewResult.ViewBag.Email = blog.Email;
            viewResult.ViewBag.Lat = blog.GeoPoint.Latitude;
            viewResult.ViewBag.Lon = blog.GeoPoint.Longitude;
            viewResult.ViewBag.Menu = blog.Menu;
            viewResult.ViewBag.StyleSheet = blog.StyleSheet;
            viewResult.ViewBag.GoogleAnalyticsId = blog.GoogleAnalyticsId;
            viewResult.ViewBag.EnableNewsletter = _featureService.EnableNewsletter.IsEnabledForUser(user);
            viewResult.ViewBag.EnableTaggableContent = _featureService.EnableTaggableContent.IsEnabledForUser(user);
            viewResult.ViewBag.EnableUserLogin = _featureService.EnableUserLogin.IsEnabledForUser(user);
            viewResult.ViewBag.EnableSearch = _featureService.EnableSearch.IsEnabledForUser(user);
            //ViewBag.ShowContactinfoInFooter = blog.ShowContactinfoInFooter;
            //ViewBag.Tags =
            //    blogposts.SelectMany(o => o.Tags).GroupBy(i => i).Select(
            //        y => new TagModel { Name = y.Key, Count = y.Count() });
            //ViewBag.Archive = archiveModel;
            //ViewBag.UserIsEditor = LoggedInUser != null && LoggedInUser.Groups.Any(o => o == "Admin");
            viewResult.ViewBag.AllowedHtmlElements = "<h1><h2><h3><h4><a><ul><li><strong><b><u><i><p><img>";
        }

        public Blog SetupNewBlog()
        {
            const string administratorRole = "Admin";
            const string adminUser = "admin";
            MembershipCreateStatus createStatus = MembershipCreateStatus.Success;
            if (Membership.GetUser(adminUser) == null)
                Membership.CreateUser(adminUser, adminUser, "admin@admin.com", null, null, true, null, out createStatus);

            if (createStatus == MembershipCreateStatus.Success)
            {
                if (!Roles.RoleExists(administratorRole))
                    Roles.CreateRole(administratorRole);
                if (!Roles.IsUserInRole(adminUser, administratorRole))
                    Roles.AddUserToRole(adminUser, administratorRole);

                _userRepository.Save(new User { DateCreated = DateTime.Now, Username = adminUser });
                return _blogRepository.Save(BlogService.InitialBlog);
            }
            throw new ApplicationException("Failed to create admin user: " + createStatus.ToString());
        }
    }
}