using System.Collections.Generic;
using MiniCms.Web.Models.Entities;

namespace MiniCms.Web.Models
{
    public class AdminViewModel
    {
        public BlogModel BlogModel { get; set; }
        public IEnumerable<BlogPostModel> Posts { get; set; }
    }
}