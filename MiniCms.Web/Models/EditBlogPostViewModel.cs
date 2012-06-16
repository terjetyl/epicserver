using MiniCms.Web.Models.Entities;

namespace MiniCms.Web.Models
{
    public class EditBlogPostViewModel
    {
        public Article BlogPost { get; set; }
        public bool EnableTags { get; set; }
    }
}