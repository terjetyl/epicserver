using System;
using System.Collections.Generic;

namespace MiniCms.Model.Entities
{
    public class Menu
    {
        public Menu()
        {
            MenuItems = new List<MenuItem>();
        }
        public List<MenuItem> MenuItems { get; set; }
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
        public int SortIndex { get; set; }
        public bool IsActive { get; set; }
        // TODO: remove from db
        public string Controller { get; set; }
        // TODO: remove from db
        public string Action { get; set; }
        public List<MenuItem> SubMenuItems { get; set; }
    }
}
