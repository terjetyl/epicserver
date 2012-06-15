using System;
using System.Web;
using MiniCms.Model;

namespace MiniCms.Services
{
    public class InProcessCache : ICacheService
    {
        public T Get<T>(string cacheId, Func<T> getItemCallback) where T : class
        {
            T item = HttpRuntime.Cache.Get(cacheId) as T;
            if (item == null)
            {
                item = getItemCallback();
                HttpContext.Current.Cache.Insert(cacheId, item);
            }
            return item;
        }

        public void Invalidate(string cacheId)
        {
            HttpRuntime.Cache.Remove(cacheId);
        }
    }
}
