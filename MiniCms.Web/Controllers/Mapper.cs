using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MiniCms.Model.Entities;
using MiniCms.Web.Models.Entities;
using Address = MiniCms.Web.Models.Entities.Address;
using GeoPoint = MiniCms.Web.Models.Entities.GeoPoint;

namespace MiniCms.Web.Controllers
{
    public class Mapper
    {
        public static BlogModel Map(Blog blog)
        {
            return new BlogModel
            {
                Address = new Address
                {
                    AddressLine = blog.Address.AddressLine,
                    City = blog.Address.City,
                    Country = blog.Address.Country,
                    Zip = blog.Address.Zip
                },
                Description = blog.Description,
                Email = blog.Email,
                Fax = blog.Fax,
                GeoPoint = new GeoPoint
                {
                    Latitude = blog.GeoPoint.Latitude,
                    Longitude = blog.GeoPoint.Longitude
                },
                LogoUrl = blog.LogoUrl,
                Name = blog.Name,
                Phone = blog.Phone,
                StyleSheet = blog.StyleSheet,
                EnableNewsletter = blog.EnableNewsletter,
                ShowContactinfoInFooter = blog.ShowContactinfoInFooter,
                GoogleAnalyticsId = blog.GoogleAnalyticsId
            };
        }

        public static BlogPost Map(BlogPostModel blogPostModel)
        {
            return new BlogPost
            {
                Author = blogPostModel.Author,
                Body = blogPostModel.Body,
                DateCreated = DateTime.Now,
                DatePublished = DateTime.Now,
                Title = blogPostModel.Title,
                Id = blogPostModel.Id,
                Tags = !string.IsNullOrWhiteSpace(blogPostModel.Tags)
                 ? blogPostModel.Tags.Split(',').Select(o => o.Trim()).ToList()
                 : new List<string>()
            };
        }

        public static IEnumerable<BlogPostModel> Map(IEnumerable<BlogPost> blogPosts)
        {
            return blogPosts.Select(Map);
        } 

        public static BlogPostModel Map(BlogPost blogPost)
        {
            return new BlogPostModel
            {
                Author = blogPost.Author,
                Body = blogPost.Body,
                DatePublished = blogPost.DatePublished,
                Title = blogPost.Title,
                Id = blogPost.Id,
                ImageUrl = blogPost.ImageUrl,
                Tags = blogPost.Tags != null ? string.Join(", ", blogPost.Tags) : string.Empty,
                Published = blogPost.Published
            };
        }

        public static UserModel Map(User user)
        {
            return new UserModel
            {
                Email = user.Email,
                Name = user.Name,
                Id = user.Id
            };
        }
    }
}