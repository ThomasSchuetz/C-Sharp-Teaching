using System;

namespace RegularExpressions
{
    internal static class Program
    {
        private static void Main()
        {
            const string Filename = "GoldPrice_USD.csv";

            var data = MarketDataReader.Reader(Filename);

            foreach (var item in data)
            {
                Console.WriteLine(item);
            }

            Console.ReadLine();
        }
    }
}
