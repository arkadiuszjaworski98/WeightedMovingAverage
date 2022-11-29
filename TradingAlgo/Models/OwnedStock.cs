using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TradingAlgo.Models
{
    public class OwnedStock
    {
        public string Ticker;
        public int Amount;

        public OwnedStock(string ticker, int amount) {
            this.Ticker = ticker;
            this.Amount = amount;
        }
    }
}
