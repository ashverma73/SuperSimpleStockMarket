namespace SuperSimpleStockMarket.DataModel
{
    public class Stock : IStock
    {
        public string Ticker { get; set ; }
        public StockType Type { get; set; }
        public double LastDividend { get; set; }
        public double FixedDividend { get; set; }
        public int ParValue { get; set; }
        public double LastPrice { get; set; }
    }
}
