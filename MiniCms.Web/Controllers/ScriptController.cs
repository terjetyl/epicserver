using System.Collections.Generic;
using MiniCms.Model.Entities;
using MiniCms.Model.Repositories;
using MvcHaack.Ajax;

namespace MiniCms.Web.Controllers
{
    public class ScriptController : JsonController
    {
        private readonly INewsletterSubscriberRepository _newsletterSubscriberRepository;
        private readonly IContentRepository _contentRepository;
        private readonly IBlogRepository _blogRepository;

        public ScriptController(IBlogRepository blogRepository, IContentRepository contentRepository, INewsletterSubscriberRepository newsletterSubscriberRepository)
        {
            _newsletterSubscriberRepository = newsletterSubscriberRepository;
            _contentRepository = contentRepository;
            _blogRepository = blogRepository;
        }

        public string Subscribe(string email, string name)
        {
            var subscriber = _newsletterSubscriberRepository.FindByEmail(email);
            if (subscriber != null)
                return "alreadyexist";

            _newsletterSubscriberRepository.Save(new NewsletterSubscriber
                                                            {
                                                                Email = email,
                                                                Name = name
                                                            });
            return "success";
        }

        public bool Unsubscribe(string email)
        {
            var subscriber = _newsletterSubscriberRepository.FindByEmail(email);
            if (subscriber == null)
                return false;
            _newsletterSubscriberRepository.Delete(subscriber.Id);
            return true;
        }

        public IEnumerable<NewsletterSubscriber> GetSubscribers(int page, int pageSize)
        {
            return _newsletterSubscriberRepository.GetSubscribers(page, pageSize);
        }

        public EditableContent SaveEditableContent(EditableContent editableContent)
        {
            return _contentRepository.Save(editableContent);
        }

        public EditableContent GetEditableContent(int id)
        {
            return _contentRepository.Get(id);
        }

        public void SaveCoordinates(double lat, double lng)
        {
            var blog = _blogRepository.First();
            blog.GeoPoint.Latitude = lat;
            blog.GeoPoint.Longitude = lng;
            _blogRepository.Save(blog);
        }
    }
}
