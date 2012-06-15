using MiniCms.Model.Entities;

namespace MiniCms.Model.Repositories
{
    public interface IFeatureRepository : IRepository<Feature>
    {
        Feature GetByName(string name);
    }
}
