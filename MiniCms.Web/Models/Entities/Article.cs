using System;
using System.ComponentModel.DataAnnotations;
using System.Web;
using System.Web.Mvc;
using MiniCms.Web.Code.Helpers;

namespace MiniCms.Web.Models.Entities
{
    public class Article
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

        public int CommentCount { get; set; }

        private string _slug;
        public string Slug
        {
            get { return _slug ?? (_slug = "/articles/" + Id + "/" + Helper.Urlify(Title)); }
            set { _slug = value; }
        }
    }
}