using System;
using System.Collections.Generic;
using MiniCms.Model.Entities;

namespace MiniCms.Model
{
    public class BlogService
    {
        public static Blog InitialBlog
        {
            get
            {
                return new Blog
                {
                    DateCreated = DateTime.Now,
                    Name = "Blog name",
                    LogoUrl = "/content/img/logo.jpg",
                    Description = @"Here goes your company description",
                    Address = new Address
                    {
                        AddressLine = "AddressLine",
                        City = "City",
                        Zip = "0000"
                    },
                    Email = "email@email.com",
                    Fax = "555 09 99 99 99",
                    Phone = "555 09 99 99 99",
                    StyleSheet = "style.css",
                    GeoPoint = new GeoPoint
                    {
                        Latitude = 60.00706,
                        Longitude = 11.04355
                    },
                    Menu = new Menu
                    {
                        MenuItems = new List<MenuItem>
                                                              {
                                                                  new MenuItem
                                                                      {
                                                                          Id = Guid.NewGuid(),
                                                                          Title = "Start",
                                                                          Url = "/"
                                                                      },
                                                                  new MenuItem
                                                                      {
                                                                          Id = Guid.NewGuid(),
                                                                          Title = "Contact",
                                                                          Url = "/home/about"
                                                                      },
                                                              }
                    }
                };
            }
        }
    }
}
