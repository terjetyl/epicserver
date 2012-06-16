using MiniCms.Web.Models.Entities;

namespace MiniCms.Web.Models
{
    public class NewsDetailsViewModel
    {
        public Article BlogPost { get; set; }
        public bool EnableCommentsOnContent { get; set; }
    }
}