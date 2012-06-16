using System;
using System.Collections.Generic;
using System.Net;
using System.Web.Http;
using MiniCms.Model.Entities;
using MiniCms.Model.Repositories;
using MiniCms.Web.Models.Entities;

namespace MiniCms.Web.Controllers.api
{
    public class ArticlesController : BaseApiController
    {
        private readonly IBlogPostRepository _blogPostRepository;

        public ArticlesController(IBlogPostRepository blogPostRepository)
        {
            _blogPostRepository = blogPostRepository;
        }

        public IEnumerable<Article> Get()
        {
            return Mapper.Map(_blogPostRepository.GetAll());
        }

        public BlogPost Get(int id)
        {
            return _blogPostRepository.Get(id);
        }

        public void Post(Article blogPost)
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
