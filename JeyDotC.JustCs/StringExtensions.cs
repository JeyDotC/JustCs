using System;
using System.Text.RegularExpressions;

namespace JeyDotC.JustCs
{
    public static class StringExtensions
    {
        public static string ToDashCase(this string camelCaseString) => Regex.Replace(camelCaseString ?? string.Empty, "(\\B[A-Z])", "-$1").TrimStart('-');
    }
}
