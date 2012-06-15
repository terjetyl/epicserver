using System;
using System.Collections.Generic;

namespace MiniCms.Web.Models
{
    public class MenuModel
    {
        public MenuModel()
        {
            MenuItems = new List<MenuItem>();
        }

        public MenuItem CurrentMenuItem { get; set; }
        public IEnumerable<MenuItem> MenuItems { get; set; }
    }

    public class MenuItem
    {
        public MenuItem()
        {
            SubMenuItems = new List<MenuItem>();
        }

        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Url { get; set; }
        public IEnumerable<MenuItem> SubMenuItems { get; set; }
        public int SortIndex { get; set; }
    }
}