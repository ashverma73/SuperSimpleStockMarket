using Newtonsoft.Json;
using SuperSimpleStockMarket.DataModel;
using System;
using System.Collections.Generic;
using System.IO;

namespace SuperSimpleStockMarket.MockData
{
    public static class MockData
    {
        static List<Stock> _StockData = null;

        public static List<Stock> GetStockData()
        {
            return _StockData ?? loadData();
          
        }
        private static List<Stock> loadData()
        {
            if (_StockData is null)
            {

                try
                {
                    var dirPath = CurrentAssemblyDirectory();
                    string json = File.ReadAllText(dirPath + "\\stockdata.json");
                    _StockData = JsonConvert.DeserializeObject<List<Stock>>(json);
                }
                catch (Exception)
                {

                    throw new Exception("Error loading test data json file");
                }
               
                
            }
            return _StockData;

        }
        static public string CurrentAssemblyDirectory()
        {
            string codeBase = System.Reflection.Assembly.GetExecutingAssembly().CodeBase;
            UriBuilder uri = new UriBuilder(codeBase);
            string path = Uri.UnescapeDataString(uri.Path);
            return Path.GetDirectoryName(path);
        }
    }
}
