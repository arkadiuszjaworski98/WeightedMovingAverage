using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TradingAlgo.Models
{
    public static class Bank
    {
        public static double Balance = 1000;

        public static double GetBalance()
        {
            return Math.Round(Balance, 2);
        }

        public static void SetBalance(double amount)
        {
            Balance += amount;
        }
    }
}
