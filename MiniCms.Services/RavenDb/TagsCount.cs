using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MiniCms.Model.Entities;
using Raven.Abstractions.Indexing;
using Raven.Client.Indexes;

namespace MiniCms.Services.RavenDb
{
    public class TagsCount : AbstractIndexCreationTask<BlogPost, TagsCount.ReduceResult>
    {
        public class ReduceResult
        {
            public string Name { get; set; }
            public int Count { get; set; }
        }

        public TagsCount()
        {
            Map = posts => from post in posts
                           from tag in post.Tags
                           select new { Name = tag.ToString().ToLower(), Count = 1 };
            Reduce = results => from tagCount in results
                                group tagCount by tagCount.Name
                                    into g
                                    select new { Name = g.Key, Count = g.Sum(x => x.Count) };

            Sort(result => result.Count, SortOptions.Int);
        }
    }
}
