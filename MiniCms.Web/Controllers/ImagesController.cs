using System.IO;
using System.Web.Mvc;
using MiniCms.Web.Code.MvcResults;

namespace MiniCms.Web.Controllers
{
    public class ImagesController : Controller
    {
        [OutputCache(Duration = (60 * 60 * 24 * 30 * 12), VaryByParam = "*")] // 1 year
        public ActionResult Render(string file, int width, int height)
        {
            var fullFilePath = GetFullFilePath(file);
            if (!System.IO.File.Exists(fullFilePath))
                return Instantiate404ErrorResult(file);

            if (width > 0 || height > 0)
            {
                string fileExtension = Path.GetExtension(fullFilePath);
                string resizedFilePath = string.Format("{0}_{1}{2}", fullFilePath.Substring(0, fullFilePath.Length - fileExtension.Length), width + "x" + height, fileExtension);
                if (!System.IO.File.Exists(resizedFilePath))
                {
                    var imageResizer = new Simple.ImageResizer.ImageResizer(fullFilePath);
                    imageResizer.Resize(width, height, Simple.ImageResizer.ImageEncoding.Jpg90);
                    imageResizer.SaveToFile(resizedFilePath);
                }

                return new ImageFileResult(resizedFilePath);
            }

            return new ImageFileResult(fullFilePath);
        }

        private string GetFullFilePath(string file)
        {
            return Path.Combine(Server.MapPath("~/App_Data/Images"), file);
        }

        private HttpNotFoundResult Instantiate404ErrorResult(string file)
        {
            return new HttpNotFoundResult(
                string.Format("The file {0} does not exist.", file));
        }
    }
}
