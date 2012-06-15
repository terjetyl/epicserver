using System;
using System.Collections.Generic;
using System.Net;
using System.Web.Http;
using MiniCms.Model.Entities;
using MiniCms.Model.Repositories;
using MiniCms.Web.Models.Entities;

namespace MiniCms.Web.Controllers.api
{
    public class NewsController : ApiController
    {
        private readonly IBlogPostRepository _blogPostRepository;
    
        public NewsController(IBlogPostRepository blogPostRepository)
        {
            _blogPostRepository = blogPostRepository;
        }

        public IEnumerable<BlogPostModel> Get()
        {
            return Mapper.Map(_blogPostRepository.GetAll());
        }

        public BlogPost Get(int id)
        {
            return _blogPostRepository.Get(id);
        }

        public void Post(BlogPostModel blogPost)
        {
            var item = Mapper.Map(blogPost);
            if(!string.IsNullOrEmpty(blogPost.ImageUrl))
            {
                using (var client = new WebClient())
                {
                    var imageHostClient = ImageHost.ServiceClient.ImageHostClient.GetFromConfig();
                    item.ImageUrl = imageHostClient.UploadImage(client.DownloadData(blogPost.ImageUrl), Guid.NewGuid() + ".jpg");
                }
            }
            _blogPostRepository.Save(item);
        }
    }
}
