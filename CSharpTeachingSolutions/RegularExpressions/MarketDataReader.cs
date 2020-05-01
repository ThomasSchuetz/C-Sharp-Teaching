using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace RegularExpressions
{
    public static class MarketDataReader
    {
        public static List<MarketDay> Reader(string filename)
        {
            var content = File.ReadAllLines(filename);

            return Reader(content);
        }

        public static List<MarketDay> Reader(string[] content)
        {
            MarketDay marketDay = new MarketDay();
            return (from dailyContent in content
                    where MarketDay.TryParse(dailyContent, out marketDay)
                    select marketDay)
                   .ToList();
        }
    }
}
