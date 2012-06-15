using System;
using System.Linq;
using System.Web.Mvc;
using MiniCms.Model;
using MiniCms.Model.Repositories;
using MiniCms.Web.Code.Filters;
using MiniCms.Web.Models;

namespace MiniCms.Web.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : BaseController
    {
        private readonly IBlogRepository _blogRepository;
        private readonly IBlogPostRepository _blogPostRepository;

        public AdminController(IBlogRepository blogRepository, IUserRepository userRepository, IBlogPostRepository blogPostRepository) : 
            base(userRepository)
        {
            _blogRepository = blogRepository;
            _blogPostRepository = blogPostRepository;
        }

        [FillViewBag]
        public ActionResult Index()
        {
            var lastPosts = _blogPostRepository.GetAll().OrderByDescending(o => o.DateCreated).Take(3);
            var viewModel = new AdminViewModel
                                {
                                    BlogModel = Mapper.Map(_blogRepository.First()),
                                    Posts = lastPosts.Select(Mapper.Map)
                                };
            return View(viewModel);
        }

        [FillViewBag]
        public ActionResult News()
        {
            return View();
        }

        [FillViewBag]
        public ActionResult Settings()
        {
            var viewModel = new AdminViewModel { BlogModel = Mapper.Map(_blogRepository.First()) };
            return View(viewModel);
        }

        [HttpPost]
        [FillViewBag]
        public ActionResult Settings(AdminViewModel adminViewModel)
        {
            var blog = _blogRepository.First();
            blog.Address.AddressLine = adminViewModel.BlogModel.Address.AddressLine;
            blog.Address.City = adminViewModel.BlogModel.Address.City;
            blog.Address.Zip = adminViewModel.BlogModel.Address.Zip;
            blog.Description = adminViewModel.BlogModel.Description;
            blog.Email = adminViewModel.BlogModel.Email;
            blog.Fax = adminViewModel.BlogModel.Fax;
            blog.Name = adminViewModel.BlogModel.Name;
            blog.Phone = adminViewModel.BlogModel.Phone;
            blog.StyleSheet = adminViewModel.BlogModel.StyleSheet;
            blog.EnableNewsletter = adminViewModel.BlogModel.EnableNewsletter;
            blog.ShowContactinfoInFooter = adminViewModel.BlogModel.ShowContactinfoInFooter;
            blog.GoogleAnalyticsId = adminViewModel.BlogModel.GoogleAnalyticsId;
            _blogRepository.Save(blog);
            return View();
        }

        [FillViewBag]
        public ActionResult Menu(Guid? menuitemId = null)
        {
            var blog = _blogRepository.First();
            var viewModel = new MenuModel
                                {
                                    MenuItems = blog.Menu.MenuItems.OrderBy(i => i.SortIndex).Select(o => new MenuItem
                                                                                    {
                                                                                        Id = o.Id,
                                                                                        Url = o.Url,
                                                                                        Title = o.Title,
                                                                                        SortIndex = o.SortIndex
                                                                                    })
                                };

            if(menuitemId.HasValue)
            {
                var item = blog.Menu.MenuItems.Single(o => o.Id == menuitemId);
                viewModel.CurrentMenuItem = new MenuItem
                                                {
                                                    Id = item.Id,
                                                    Url = item.Url,
                                                    SortIndex = item.SortIndex,
                                                    Title = item.Title
                                                };
            }

            return View(viewModel);
        }

        public ActionResult DeleteMenuItem(Guid menuitemId)
        {
            var blog = _blogRepository.First();
            blog.Menu.MenuItems.Remove(blog.Menu.MenuItems.First(o => o.Id == menuitemId));
            _blogRepository.Save(blog);
            return RedirectToAction("Menu");
        }

        public ActionResult SaveMenuItem(MenuModel menuModel)
        {
            var menuItem = menuModel.CurrentMenuItem;

            var blog = _blogRepository.First();

            var item = blog.Menu.MenuItems.SingleOrDefault(o => o.Id == menuItem.Id);

            if(item != null)
            {
                item.Title = menuItem.Title;
                item.Url = menuItem.Url;
                item.SortIndex = menuItem.SortIndex;
                _blogRepository.Save(blog);
            }
            else
            {
                blog.Menu.MenuItems.Add(new Model.Entities.MenuItem
                {
                    Id = Guid.NewGuid(),
                    Url = menuItem.Url,
                    Title = menuItem.Title,
                    SortIndex = menuItem.SortIndex
                });
                _blogRepository.Save(blog);
            }
            
            return RedirectToAction("Menu");
        }

        public void ResetBlog()
        {
            _blogRepository.Clear();
            _blogRepository.Save(BlogService.InitialBlog);
        }

        [FillViewBag]
        public ActionResult Logo()
        {
            return View();
        }
    }
}
