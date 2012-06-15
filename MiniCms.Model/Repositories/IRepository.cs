using System.Collections.Generic;
using System.Linq;

namespace MiniCms.Model.Repositories
{
    public interface IRepository<T> where T : class
    {
        void Delete(int id);
        T Find(int id);
        T Get(int id);
        T Save(T item);
        IQueryable<T> GetAll();
    }

    public interface IRepository<T, in TIdType> where T : class
    {
        void Delete(TIdType id);
        T Find(TIdType id);
        T Get(TIdType id);
        T Save(T item);
        IQueryable<T> GetAll();
    }
}
