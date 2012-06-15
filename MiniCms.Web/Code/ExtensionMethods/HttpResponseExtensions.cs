using System.Web;
using System.Web.Caching;

namespace MiniCms.Web.Code.ExtensionMethods
{
    public static class HttpResponseExtensions
    {
        public static void SetDefaultImageHeaders(this HttpResponseBase response)
        {
            response.Cache.SetCacheability(HttpCacheability.Public);
            response.Cache.SetExpires(Cache.NoAbsoluteExpiration);
            response.Cache.SetLastModifiedFromFileDependencies();
        }
    }
}