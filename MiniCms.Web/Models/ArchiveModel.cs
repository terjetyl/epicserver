using System.Collections.Generic;
using MiniCms.Web.Models.Entities;

namespace MiniCms.Web.Models
{
    public class ArchiveModel
    {
        public ArchiveModel()
        {
            Years = new List<Year>();
        }
        public List<Year> Years { get; set; }
    }

    public class Year
    {
        public Year()
        {
            Months = new List<Month>();
        }
        public int Name { get; set; }
        public List<Month> Months { get; set; }
        public int Count { get; set; }
    }

    public class Month
    {
        public Month()
        {
            Posts = new List<Article>();
        }
        public int Nr { get; set; }
        public string Name { get; set; }
        public List<Article> Posts { get; set; }
        public int Count { get; set; }
    }
}