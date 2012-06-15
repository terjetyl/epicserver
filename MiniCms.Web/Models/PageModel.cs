namespace MiniCms.Web.Models
{
    public class PageModel
    {
        //public List<Section> Sections { get; set; }
        public IslandModel IslandModel { get; set; }
    }

    public class Section
    {
        public int Width { get; set; }
        public string PartialView { get; set; }
    }

    public class IslandModel
    {
        public string Html { get; set; }
    }
}