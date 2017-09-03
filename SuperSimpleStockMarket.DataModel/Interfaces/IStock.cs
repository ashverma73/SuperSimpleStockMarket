namespace SuperSimpleStockMarket.DataModel
{
    public enum StockType
    {
        Common,
        Preferred
    }
    public interface IStock
    {
        string Ticker { get; set; }
        StockType Type { get; set; }
        double LastDividend { get; set; }
        double FixedDividend { get; set; }
        int ParValue { get; set; }
        double LastPrice { get; set; }
    }
}
