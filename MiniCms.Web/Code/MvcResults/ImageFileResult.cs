using System.Web;
using System.Web.Mvc;
using MiniCms.Web.Code.ExtensionMethods;

namespace MiniCms.Web.Code.MvcResults
{
    public class ImageFileResult : FilePathResult
    {
        public ImageFileResult(string fileName) :
            base(fileName, string.Format("image/{0}",
                fileName.FileExtensionForContentType()))
        {
        }
        protected override void WriteFile(HttpResponseBase response)
        {
            response.SetDefaultImageHeaders();
            base.WriteFile(response);
        }
    }
}