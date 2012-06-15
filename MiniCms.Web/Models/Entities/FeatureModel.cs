using System.Web.Mvc;
using MiniCms.Model.Entities;

namespace MiniCms.Web.Models.Entities
{
    public class FeatureModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public FeatureSwitchStatus FeatureStatus { get; set; }
        public SelectList FeatureStatuses { get; set; }
    }
}