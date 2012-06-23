using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MiniCms.Model.Repositories;
using MiniCms.Web.Models.Entities;

namespace MiniCms.Web.Controllers.api
{
    public class CategoriesController : ApiController
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoriesController(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public HttpResponseMessage Post(Category category)
        {
            _categoryRepository.Save(new Model.Entities.Category{ Name = category.Name });
            return new HttpResponseMessage(HttpStatusCode.Created);
        }

        public IEnumerable<Category> Get()
        {
            var categories =_categoryRepository.GetAll();
            return new List<Category>(categories.Select(o => new Category{ Id = o.Id, Name = o.Name }));
        }
    }
}
