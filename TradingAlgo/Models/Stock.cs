using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TradingAlgo.Models
{
    public class Stock : OwnedStock
    {
        public double Price;

        public Stock(string ticker, double price, int amount) : base (ticker, amount) {
            this.Price = price;
        }
    }
}
