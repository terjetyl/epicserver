using System.Collections.Generic;
using MiniCms.Web.Models.Entities;

namespace MiniCms.Web.Models
{
    public class SearchViewModel
    {
        public IEnumerable<Article> BlogPosts { get; set; }
    }
}