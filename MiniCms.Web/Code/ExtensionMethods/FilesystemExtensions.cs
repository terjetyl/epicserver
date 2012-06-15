namespace MiniCms.Web.Code.ExtensionMethods
{
    public static class FilesystemExtensionMethods
    {
        public static string FileExtensionForContentType(this string fileName)
        {
            var pieces = fileName.Split('.');
            var extension = pieces.Length > 1 ? pieces[pieces.Length - 1]
                : string.Empty;
            return (extension.ToLower() == "jpg") ? "jpeg" : extension;
        }
    }
}