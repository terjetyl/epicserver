using System;

namespace MiniCms.Web.Code.ExtensionMethods
{
    public static class StringExtensions
    {
        public static int? ToInt(this string input)
        {
            if (input == null)
                return null;
            int val;
            if (int.TryParse(input, out val))
                return val;
            return null;
        }

        public static DateTime? ToDate(this string input)
        {
            if (input == null)
                return null;
            DateTime val;
            if (DateTime.TryParse(input, out val))
                return val;
            return null;
        }

        public static decimal? ToDecimal(this string input)
        {
            if (input == null)
                return null;
            decimal val;
            if (decimal.TryParse(input, out val))
                return val;
            return null;
        }
    }
}