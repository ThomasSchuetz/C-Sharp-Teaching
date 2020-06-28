using System;
using System.Text.RegularExpressions;

namespace RegularExpressions
{
    public struct MarketDay
    {
        public DateTime Date { get; }
        public decimal Open { get; }
        public decimal High { get; }
        public decimal Low { get; }
        public decimal Close { get; }
        public decimal AdjClose { get; }
        public long Volume { get; }

        private MarketDay(
            DateTime date,
            decimal open,
            decimal high,
            decimal low,
            decimal close,
            decimal adjClose,
            long volume)
        {
            Date = date;
            Open = open;
            High = high;
            Low = low;
            Close = close;
            AdjClose = adjClose;
            Volume = volume;
        }

        public override string ToString() =>
            $"{Date.ToShortDateString()} - open: {Open}, close: {Close}, volume: {Volume}";

        public static bool TryParse(string data, out MarketDay marketDay)
        {
            var pattern = @"\d{4}-\d{2}-\d{2}(,\d+.\d+){5},\d+"; // yyyy-mm-dd , (123.456) --> 5 times , 789
            var expression = new Regex(pattern);

            if (expression.IsMatch(data))
            {
                var splitData = data.Split(",");
                marketDay = new MarketDay(
                    date: DateTime.ParseExact(splitData[0], "yyyy-MM-dd", null),
                    open: splitData[1].ParseDotComma(),
                    high: splitData[2].ParseDotComma(),
                    low: splitData[3].ParseDotComma(),
                    close: splitData[4].ParseDotComma(),
                    adjClose: splitData[5].ParseDotComma(),
                    volume: long.Parse(splitData[6])
                    );
                return true;
            }
            else
            {
                marketDay = new MarketDay();
                return false;
            }
        }
    }
}
