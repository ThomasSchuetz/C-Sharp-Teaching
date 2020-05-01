using System;

namespace RegularExpressions
{
    static class Program
    {
        static void Main()
        {
            var filename = "GoldPrice_USD.csv";

            var data = MarketDataReader.Reader(filename);

            foreach (var item in data)
            {
                Console.WriteLine(item);
            }

            Console.ReadLine();
        }
    }
}
