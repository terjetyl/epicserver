using System;
using System.ComponentModel.DataAnnotations;
using System.Web;
using System.Web.Mvc;
using MiniCms.Web.Code.Helpers;

namespace MiniCms.Web.Models.Entities
{
    public class BlogPostModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime DatePublished { get; set; }
        public string ImageUrl { get; set; }
        public string Author { get; set; }
        [AllowHtml]
        public string Body { get; set; }

        [Display(Name = "Bilde:")]
        [File(MaxContentLength = 1024 * 1024 * 4, ErrorMessage = "Ugyldig fil (maks størrelse er 4 mb.)")]
        public HttpPostedFileBase Image { get; set; }

        public string Tags { get; set; }

        public bool Published { get; set; }

        private string _friendlyUrl;
        public string FriendlyUrl
        {
            get { return _friendlyUrl ?? (_friendlyUrl = "/news/" + Id + "/" + Helper.Urlify(Title)); }
            set { _friendlyUrl = value; }
        }
    }
}