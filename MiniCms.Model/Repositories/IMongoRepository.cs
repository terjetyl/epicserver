using System;
using System.Collections.Generic;

namespace MiniCms.Model.Repositories
{
    public interface IMongoRepository<T> where T : class
    {
        void Delete(Guid id);
        T Find(Guid id);
        T Get(Guid id);
        T Save(T item);
        IEnumerable<T> GetAll();
    }
}
