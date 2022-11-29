using System;
using System.Buffers.Text;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TradingAlgo.Models;

namespace TradingAlgo.Database.Models
{
    public class SellStock
    {
        public Stock Stock;
        public string TransactionID;
        public DateTime SaleDateTime;
        public SellStock(Stock stock, string transactionID)
        {
            this.TransactionID = transactionID;
            this.Stock = stock;
            this.SaleDateTime = DateTime.Now;
        }
    }
}
