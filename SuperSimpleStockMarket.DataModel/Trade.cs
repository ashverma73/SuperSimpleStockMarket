using System;

namespace SuperSimpleStockMarket.DataModel
{
   public class Trade : ITrade
    {
        public Stock TradedStock { get; set; }
        public int Quantity { get; set; }
        public DateTime TradeTime { get; set; }
        public Signal TradeSignal { get; set; }
        public double TradePrice { get; set; }
     
    }
}
