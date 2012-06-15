using System;

namespace MiniCms.Model
{
    public interface ICacheService
    {
        T Get<T>(string cacheId, Func<T> getItemCallback) where T : class;
        void Invalidate(string cacheId);
    }
}
