using System.Text.RegularExpressions;

namespace StreetNaming.Util.Extensions
{
    public static class StringExtensions
    {
        private static readonly Regex NumericRegex = new Regex("^[0-9]+$");

        public static bool IsNumeric(this string input)
        {
            return NumericRegex.IsMatch(input);
        }
    }
}