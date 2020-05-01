using System.Globalization;

namespace RegularExpressions
{
    public static class ParsingExtensions
    {
        public static decimal ParseDotComma(this string number) => 
            decimal.Parse(number, NumberStyles.Any, CultureInfo.InvariantCulture);
    }
}
