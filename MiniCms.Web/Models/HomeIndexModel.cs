using System.Collections.Generic;
using MiniCms.Web.Models.Entities;

namespace MiniCms.Web.Models
{
    public class HomeIndexModel
    {
        public IEnumerable<Article> Posts { get; set; }
    }
}