namespace MiniCms.Model.Entities
{
    public class Blog : EntityBase
    {
        public Blog()
        {
            Address = new Address();
            GeoPoint = new GeoPoint();
            Menu = new Menu();
        }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Fax { get; set; }
        public string Email { get; set; }
        public string Description { get; set; }
        public Address Address { get; set; }
        public GeoPoint GeoPoint { get; set; }
        public string LogoUrl { get; set; }
        public Menu Menu { get; set; }
        public string StyleSheet { get; set; }
        public bool EnableCommentsOnPosts { get; set; }
        public bool EnableTagsOnPosts { get; set; }
        public string Twitter { get; set; }
        public string FacebookPage { get; set; }
        public bool EnableNewsletter { get; set; }
        public bool ShowContactinfoInFooter { get; set; }
        public string GoogleAnalyticsId { get; set; }
    }
}
