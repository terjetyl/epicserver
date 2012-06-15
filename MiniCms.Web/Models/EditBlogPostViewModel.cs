using MiniCms.Web.Models.Entities;

namespace MiniCms.Web.Models
{
    public class EditBlogPostViewModel
    {
        public BlogPostModel BlogPost { get; set; }
        public bool EnableTags { get; set; }
    }
}