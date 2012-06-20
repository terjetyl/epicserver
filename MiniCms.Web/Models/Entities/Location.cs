using System;

namespace MiniCms.Web.Models.Entities
{
    public class Location
    {
        public Guid MapId { get; set; }
        public string Name { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
    }
}