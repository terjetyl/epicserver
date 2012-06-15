using MiniCms.Model.Entities;
using MiniCms.Model.Repositories;

namespace MiniCms.Services.RavenDb
{
    public class NewsletterRepository : RavenRepositoryBase<Newsletter>, INewsletterRepository
    {
        public NewsletterRepository() : base("newsletters-")
        {
        }
    }
}
