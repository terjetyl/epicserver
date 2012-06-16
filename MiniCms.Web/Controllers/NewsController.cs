using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using MarkdownSharp;
using MiniCms.Model;
using MiniCms.Model.Repositories;
using MiniCms.Web.Code.ExtensionMethods;
using MiniCms.Web.Code.Filters;
using MiniCms.Web.Models;
using MiniCms.Web.Models.Entities;

namespace MiniCms.Web.Controllers
{
    public class NewsController : BaseController
    {
        private readonly IBlogPostRepository _blogPostRepository;
        IFeatureRepository _featureRepository;
        FeatureService _featureService;

        public NewsController(IFeatureRepository featureRepository, IBlogPostRepository blogPostRepository, IUserRepository userRepository) : base(userRepository)
        {
            _blogPostRepository = blogPostRepository;
            _featureRepository = featureRepository;
            _featureService = new FeatureService(_featureRepository);
        }

        [FillViewBag]
        public ActionResult Index()
        {
            var posts = _blogPostRepository.GetAll().Where(o => o.Published);
            var viewModel = new HomeIndexModel { Posts = posts.OrderByDescending(o => o.DateCreated).Select(Mapper.Map) };

            return View(viewModel);
        }

        [FillViewBag]
        public ActionResult Create()
        {
            var viewModel = new EditBlogPostViewModel
                                {
                                    BlogPost = new Article(),
                                    EnableTags = _featureService.EnableTaggableContent.IsEnabledForUser(LoggedInUser)
                                };
            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Create(EditBlogPostViewModel blogPostModel)
        {
            var post = Mapper.Map(blogPostModel.BlogPost);

            if (blogPostModel.BlogPost.Image != null)
            {
                var imageHostClient = ImageHost.ServiceClient.ImageHostClient.GetFromConfig();
                post.ImageUrl = imageHostClient.UploadImage(blogPostModel.BlogPost.Image.ToByte(), blogPostModel.BlogPost.Image.FileName);
            }

            _blogPostRepository.Save(post);
            return RedirectToAction("Index", "Admin");
        }

        [FillViewBag]
        public ActionResult Edit(int id)
        {
            var post = _blogPostRepository.Get(id);
            var viewModel = new EditBlogPostViewModel
                                {
                                    BlogPost = Mapper.Map(post),
                                    EnableTags = _featureService.EnableTaggableContent.IsEnabledForUser(LoggedInUser)
                                };
            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Edit(EditBlogPostViewModel blogPostModel)
        {
            var post = _blogPostRepository.Get(blogPostModel.BlogPost.Id);
            post.Title = blogPostModel.BlogPost.Title;
            post.Body = blogPostModel.BlogPost.Body;
            post.Tags = !string.IsNullOrWhiteSpace(blogPostModel.BlogPost.Tags)
                            ? blogPostModel.BlogPost.Tags.Split(',').Select(o => o.Trim()).ToList()
                            : new List<string>();

            if (blogPostModel.BlogPost.Image != null)
            {
                var imageHostClient = ImageHost.ServiceClient.ImageHostClient.GetFromConfig();
                post.ImageUrl = imageHostClient.UploadImage(blogPostModel.BlogPost.Image.ToByte(), blogPostModel.BlogPost.Image.FileName);
            }

            _blogPostRepository.Save(post);
            return RedirectToAction("Index", "Admin");
        }

        public ActionResult Delete(int id)
        {
            _blogPostRepository.Delete(id);
            return RedirectToAction("Index", "Admin");
        }

        [FillViewBag]
        public ActionResult Search(string q = "")
        {
            var news = _blogPostRepository.Search(q);
            var viewModel = new SearchViewModel
                                {
                                    BlogPosts = news.Select(Mapper.Map)
                                };
            return View(viewModel);
        }

        [FillViewBag]
        public ActionResult Details(int id, string title)
        {
            var blogPost = _blogPostRepository.Get(id);
            var viewModel = new NewsDetailsViewModel
                                {
                                    EnableCommentsOnContent = _featureService.EnableCommentsOnContent.IsEnabledForUser(LoggedInUser),
                                    BlogPost = Mapper.Map(blogPost)
                                };
            return View(viewModel);
        }

        public ActionResult Publish(int id)
        {
            var blogPost = _blogPostRepository.Get(id);
            blogPost.Published = true;
            _blogPostRepository.Save(blogPost);
            return RedirectToAction("Index", "Admin");
        }

        public ActionResult UnPublish(int id)
        {
            var blogPost = _blogPostRepository.Get(id);
            blogPost.Published = false;
            _blogPostRepository.Save(blogPost);
            return RedirectToAction("Index", "Admin");
        }

    }
}
