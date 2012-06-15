using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MiniCms.Model.Entities;
using MiniCms.Model.Repositories;

namespace MiniCms.Services.RavenDb
{
    public class BlogPostRepository : RavenRepositoryBase<BlogPost>, IBlogPostRepository
    {
        public BlogPostRepository() : base("blogposts-")
        {
        }

        public IEnumerable<BlogPost> GetByTag(string tag)
        {
            throw new NotImplementedException();
        }

        public ICollection<BlogPost> Search(string q)
        {
            using (var session = DocumentStore.OpenSession())
            {
                var results = session.Advanced
                    .LuceneQuery<BlogPost, SearchIndex>()
                    .Search("Content", q);

                return results.ToArray();
            }
        }

        public void GetTagCloud()
        {
            using (var session = DocumentStore.OpenSession())
            {
                var result = session.Query<TagsCount.ReduceResult, TagsCount>().OrderByDescending(x => x.Count).ToArray();
            }
        }
    }
}
