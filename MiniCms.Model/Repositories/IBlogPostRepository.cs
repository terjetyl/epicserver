using System.Collections.Generic;
using MiniCms.Model.Entities;

namespace MiniCms.Model.Repositories
{
    public interface IBlogPostRepository : IRepository<BlogPost>
    {
        IEnumerable<BlogPost> GetByTag(string tag);
        ICollection<BlogPost> CachedCollection { get; }
        ICollection<BlogPost> Search(string q);
    }
}
