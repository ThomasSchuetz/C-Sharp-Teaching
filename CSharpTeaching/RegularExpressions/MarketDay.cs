using System;

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
            /*
             * 
             * Your code belongs here!
             * 
             */

            throw new NotImplementedException();
        }
    }
}
