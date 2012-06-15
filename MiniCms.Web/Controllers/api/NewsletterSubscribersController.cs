using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MiniCms.Model.Repositories;
using MiniCms.Web.Models.Entities;

namespace MiniCms.Web.Controllers.api
{
    public class NewsletterSubscribersController : ApiController
    {
        private readonly INewsletterSubscriberRepository _newsletterSubscriberRepository;

        public NewsletterSubscribersController(INewsletterSubscriberRepository newsletterSubscriberRepository)
        {
            _newsletterSubscriberRepository = newsletterSubscriberRepository;
        }

        public IQueryable<NewsletterSubscriber> Get()
        {
            var subscribers = _newsletterSubscriberRepository.GetAll();
            return subscribers.Select(o => new NewsletterSubscriber
                                               {
                                                   Email = o.Email,
                                                   Name = o.Name
                                               });
        }

        public HttpResponseMessage Post(NewsletterSubscriber newsletterSubscriber)
        {
            var subscriber = _newsletterSubscriberRepository.FindByEmail(newsletterSubscriber.Email);
            if (subscriber != null)
                return new HttpResponseMessage(HttpStatusCode.Found);

            _newsletterSubscriberRepository.Save(new Model.Entities.NewsletterSubscriber
            {
                Email = newsletterSubscriber.Email,
                Name = newsletterSubscriber.Name
            });
            return new HttpResponseMessage(HttpStatusCode.Created);
        }
    }
}
