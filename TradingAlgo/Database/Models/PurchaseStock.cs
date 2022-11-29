using System;
using System.Buffers.Text;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TradingAlgo.Models;

namespace TradingAlgo.Database.Models
{
    public class PurchaseStock
    {
        public Stock Stock;
        public string TransactionID;
        public DateTime PurchaseDateTime;
        public PurchaseStock(Stock stock, string transactionID)
        {
            this.TransactionID = transactionID;
            this.Stock = stock;
            this.PurchaseDateTime= DateTime.Now;
        }
    }
}
