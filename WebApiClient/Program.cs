using System;
using System.Collections.Generic;
using System.IO;
using System.Json;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Policy;
using System.Text;
using System.Xml.Linq;

namespace WebApiClient
{
    class Program
    {
        static void Main(string[] args)
        {
            var posts = GetPosts();
            foreach (var blogPost in posts)
            {
                Feed(blogPost.Title, blogPost.Body, blogPost.ImageUrl);
            }
        }

        public static IEnumerable<BlogPost> GetPosts()
        {
            var posts = new List<BlogPost>();

            var xdoc = XDocument.Load("http://feeds.allerinternett.no/articles/dinside/motor/rss.rss");

            var nodes = xdoc.Descendants("item");

            foreach (var node in nodes)
            {
                posts.Add(new BlogPost
                              {
                                  Title = node.Descendants("title").First().Value,
                                  Body = node.Descendants("description").First().Value,
                                  ImageUrl = node.Descendants("enclosure").First().Attribute("url").Value
                              });
            }

            return posts;
        }

        public static void Feed(string title, string body, string imageUrl)
        {
            var myObject = (dynamic)new JsonObject();
            myObject.Title = title;
            myObject.Body = body;
            myObject.ImageUrl = imageUrl;

            var c = new HttpClient();
            var json = new StringContent(myObject.ToString(), Encoding.UTF8, "application/json");
            var result = c.PostAsync("http://localhost:7003/webapi/newsapi", json).Result;
        }
    }

    public class BlogPost
    {
        public string Title { get; set; }
        public string Body { get; set; }
        public string ImageUrl { get; set; }
    }
}
