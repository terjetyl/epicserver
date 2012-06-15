using System.Collections.Generic;
using MiniCms.Model.Entities;

namespace MiniCms.Model.Repositories
{
    public interface INewsletterSubscriberRepository : IRepository<NewsletterSubscriber>
    {
        NewsletterSubscriber FindByEmail(string email);
        IEnumerable<NewsletterSubscriber> GetSubscribers(int page, int pageSize);
    }
}
