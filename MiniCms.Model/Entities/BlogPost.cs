using System;
using System.Collections.Generic;

namespace MiniCms.Model.Entities
{
    public class BlogPost : EntityBase, IContent
    {
        public BlogPost()
        {
            Tags = new List<string>();
        }

        public Guid BlogId { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string Body { get; set; }
        public string ImageUrl { get; set; }
        public ICollection<string> Tags { get; set; }
        public bool Published { get; set; }
        public DateTime DatePublished { get; set; }
    }

    public interface IContent
    {
        DateTime DatePublished { get; set; }
        string Title { get; set; }
        string ImageUrl { get; set; }
        string Body { get; set; }
        ICollection<string> Tags { get; set; }

    }
}
