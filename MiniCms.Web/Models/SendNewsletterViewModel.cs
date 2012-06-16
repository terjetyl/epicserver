using System.Collections.Generic;
using MiniCms.Web.Models.Entities;
using NewsletterSubscriber = MiniCms.Web.Models.Entities.NewsletterSubscriber;

namespace MiniCms.Web.Models
{
    public class SendNewsletterViewModel
    {
        public Article BlogPost { get; set; }
        public IEnumerable<NewsletterSubscriber> Subscribers { get; set; }
    }
}