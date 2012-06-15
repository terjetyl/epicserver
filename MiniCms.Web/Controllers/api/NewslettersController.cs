using System.Collections.Generic;
using System.Web.Http;
using MiniCms.Model.Entities;
using MiniCms.Model.Repositories;

namespace MiniCms.Web.Controllers.api
{
    public class NewslettersController : ApiController
    {
        private readonly INewsletterRepository _newsletterRepository;

        public NewslettersController(INewsletterRepository newsletterRepository)
        {
            _newsletterRepository = newsletterRepository;
        }

        public IEnumerable<Newsletter> Get()
        {
            return _newsletterRepository.GetAll();
        }

        public Newsletter Get(int id)
        {
            return _newsletterRepository.Get(id);
        }
    }
}
