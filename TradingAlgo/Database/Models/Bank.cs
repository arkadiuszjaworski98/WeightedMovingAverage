using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TradingAlgo.Database.Models
{
    public class Bank
    {
        public string? TransactionID { get; set; }
        public double Balance { get; set; }

        public Bank(string transactionID, double balance)
        {
            this.TransactionID = transactionID;
            this.Balance = balance; 
        }
    }
}
