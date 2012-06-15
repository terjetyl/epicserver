using System;
using System.Collections.Generic;
using System.Linq;
using MiniCms.Model.Entities;
using MiniCms.Model.Repositories;

namespace MiniCms.Services.RavenDb
{
    public class NewsletterSubscriberRepository : RavenRepositoryBase<NewsletterSubscriber>, INewsletterSubscriberRepository
    {
        public NewsletterSubscriberRepository() : base("newslettersubsscribers-")
        {
        }

        public NewsletterSubscriber FindByEmail(string email)
        {
            using (var session = DocumentStore.OpenSession())
            {
                return session.Query<NewsletterSubscriber>().FirstOrDefault(o => o.Email == email);
            }
        }

        public IEnumerable<NewsletterSubscriber> GetSubscribers(int page, int pageSize)
        {
            throw new NotImplementedException();
        }
    }
}
