using System.Text.RegularExpressions;

namespace MiniCms.Web.Code.Helpers
{
    public class Helper
    {
        public static string Urlify(string value)
        {
            return Regex.Replace(value, @"[^A-Za-z0-9_\.~]+", "-");
        }
    }
}