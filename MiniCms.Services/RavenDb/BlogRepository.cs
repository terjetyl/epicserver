using System;
using System.Linq;
using MiniCms.Model.Entities;
using MiniCms.Model.Repositories;

namespace MiniCms.Services.RavenDb
{
    public class BlogRepository : RavenRepositoryBase<Blog>, IBlogRepository
    {
        public BlogRepository() : base("blogs-")
        {
        }

        public Blog First()
        {
            return CachedCollection.FirstOrDefault();
        }

        public void Clear()
        {
            throw new NotImplementedException();
        }

    }
}
