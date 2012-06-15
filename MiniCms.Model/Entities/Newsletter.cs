using System;
using System.Collections.Generic;
using System.Linq;

namespace MiniCms.Model.Entities
{
    public class Newsletter : EntityBase, IContent
    {
        private readonly List<NewsletterSubscriber> _subscribers; 

        public Newsletter(IEnumerable<NewsletterSubscriber> subscribers)
        {
            _subscribers = subscribers.ToList();
        }

        public List<NewsletterSubscriber> Subscribers
        {
            get { return _subscribers; }
        }

        public string Title { get; set; }
        public DateTime DatePublished { get; set; }
        public string ImageUrl { get; set; }
        public string Body { get; set; }
        public ICollection<string> Tags { get; set; }
    }
}
