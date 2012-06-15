using MiniCms.Model.Entities;

namespace MiniCms.Model.Repositories
{
    public interface IBlogRepository : IRepository<Blog>
    {
        Blog First();
        void Clear();
    }
}
