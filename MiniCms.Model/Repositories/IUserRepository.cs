namespace MiniCms.Model.Repositories
{
    public interface IUserRepository : IRepository<Entities.User>
    {
        Entities.User GetByUsername(string username);
    }
}
