using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
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

        public HttpResponseMessage Post(Article article)
        {
            var item = Mapper.Map(article);
            if(!string.IsNullOrEmpty(article.ImageUrl))
            {
                using (var client = new WebClient())
                {
                    var imageHostClient = ImageHost.ServiceClient.ImageHostClient.GetFromConfig();
                    item.ImageUrl = imageHostClient.UploadImage(client.DownloadData(article.ImageUrl), Guid.NewGuid() + ".jpg");
                }
            }
            _blogPostRepository.Save(item);
            return new HttpResponseMessage(HttpStatusCode.Created);
        }
    }
}
