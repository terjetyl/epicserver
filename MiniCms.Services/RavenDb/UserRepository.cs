using System;
using System.Linq;
using MiniCms.Model.Entities;
using MiniCms.Model.Repositories;

namespace MiniCms.Services.RavenDb
{
    public class UserRepository : RavenRepositoryBase<User>, IUserRepository
    {
        public UserRepository() : base("users-")
        {
        }

        public User GetByUsername(string username)
        {
            using (var session = DocumentStore.OpenSession())
            {
                return session.Query<User>().SingleOrDefault(o => o.Username == username);
            }
        }
    }
}
