using System.Web;
using System.Web.Mvc;
using MiniCms.Web.Code.ExtensionMethods;

namespace MiniCms.Web.Code.MvcResults
{
    public class DynamicImageResult : FileContentResult
    {
        public DynamicImageResult(string fileName, byte[] fileData) :
            base(fileData, string.Format("image/{0}",
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