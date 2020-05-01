using System.Collections.Generic;
using System.IO;

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
            /*
             * 
             * Your code belongs here!
             * 
             */

            throw new System.NotImplementedException();
        }
    }
}
