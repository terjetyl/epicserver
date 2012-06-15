using System.Linq;
using MiniCms.Model.Entities;
using MiniCms.Model.Repositories;

namespace MiniCms.Services.RavenDb
{
    public class FeatureRepository : RavenRepositoryBase<Feature>, IFeatureRepository
    {
        public FeatureRepository() : base("features-")
        {
        }

        public Feature GetByName(string name)
        {
            return CachedCollection.SingleOrDefault(o => o.Name == name) ?? new Feature();
        }
    }
}
