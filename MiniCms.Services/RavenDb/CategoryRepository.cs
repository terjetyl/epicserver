using MiniCms.Model.Entities;
using MiniCms.Model.Repositories;

namespace MiniCms.Services.RavenDb
{
    public class CategoryRepository : RavenRepositoryBase<Category>, ICategoryRepository
    {
        public CategoryRepository() : base("categories-")
        {
        }
    }
}
