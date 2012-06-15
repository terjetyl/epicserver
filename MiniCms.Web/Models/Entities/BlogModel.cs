using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace MiniCms.Web.Models.Entities
{
    public class BlogModel
    {
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Fax { get; set; }
        public string Email { get; set; }
        [AllowHtml]
        [Display(Name = "Beskrivelse")]
        public string Description { get; set; }
        public Address Address { get; set; }
        public GeoPoint GeoPoint { get; set; }
        public string LogoUrl { get; set; }
        public string StyleSheet { get; set; }
        public bool EnableNewsletter { get; set; }
        public bool ShowContactinfoInFooter { get; set; }
        public string GoogleAnalyticsId { get; set; }
    }
}