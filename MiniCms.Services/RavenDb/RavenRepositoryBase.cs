using System;
using System.Collections.Generic;
using System.Linq;
using MiniCms.Model;
using Raven.Client;

namespace MiniCms.Services.RavenDb
{
    public class RavenRepositoryBase<T> where T : class 
    {
        private static IDocumentStore _store;
        private readonly string _idPrefix;
        private readonly ICacheService _cache = new InProcessCache();

        public RavenRepositoryBase(string idPrefix)
        {
            _idPrefix = idPrefix;
        }

        public static IDocumentStore DocumentStore
        {
            get { return _store ?? (_store = RavenInitializer.Instance); }
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public T Find(int id)
        {
            throw new NotImplementedException();
        }

        public T Get(int id)
        {
            using (var session = DocumentStore.OpenSession())
            {
                return session.Load<T>(_idPrefix + id);
            }
        }

        public T Save(T item)
        {
            using (var session = DocumentStore.OpenSession())
            {
                session.Store(item);
                session.SaveChanges();
                _cache.Invalidate(_idPrefix);
                return item;
            }
        }
        
        public IQueryable<T> GetAll()
        {
            using (var session = DocumentStore.OpenSession())
            {
                return session.Query<T>();
            }
        }

        public ICollection<T> CachedCollection
        {
            get
            {
                var items = _cache.Get(_idPrefix, () => GetAll().ToList());
                return items;
            }
        }
    }
}
