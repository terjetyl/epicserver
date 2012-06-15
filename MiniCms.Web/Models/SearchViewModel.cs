using System.Collections.Generic;
using MiniCms.Web.Models.Entities;

namespace MiniCms.Web.Models
{
    public class SearchViewModel
    {
        public IEnumerable<BlogPostModel> BlogPosts { get; set; }
    }
}