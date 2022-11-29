using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using TradingAlgo.Database.Models;

namespace TradingAlgo.Models
{
    public class Broker
    {
        public Random TransactionID;

        public List<Database.Models.Bank> BankDB = new();

        public List<PurchaseStock> PurchaseStockDB = new();

        public List<SellStock> SellStockDB = new();

        public List<OwnedStock> StockPortfolioDB = new();

        public Broker()
        {
            this.TransactionID = new Random();
        }

        private string GetTransactionID()
        {
            return TransactionID.Next().ToString();
        }

        private void UpdateBalanceReceived(Stock stock)
        {
            double amountReceived = stock.Price * stock.Amount;

            Bank.SetBalance(amountReceived);

        }

        private void UpdateBalancePaid(Stock stock)
        {
            double amountPaid = stock.Price * stock.Amount;

            Bank.SetBalance(-amountPaid);

        }

        private void UpdateBankDB(string transactionID)
        {
            Database.Models.Bank bank = new(transactionID, Bank.GetBalance());
            BankDB.Add(bank);
        }

        private void UpdateStockPortfolioDBPurchased(Stock stock) {

            StockPortfolioDB.Add(stock);
        }
        private void UpdateStockPortfolioDBSold(Stock stock) {

            int ownedStock = StockPortfolioDB.FindIndex((ownedStock) => ownedStock.Ticker.Equals(stock.Ticker));

            if (ownedStock != -1)
            {
                StockPortfolioDB[ownedStock].Amount -= stock.Amount;
            }
        }

        public int AmountOfOwnedStock(string ticker)
        {
            int ownedStock = StockPortfolioDB.FindIndex((ownedStock) => ownedStock.Ticker.Equals(ticker));

            return StockPortfolioDB[ownedStock].Amount;
        }
       

        private void UpdatePurchaseDB(Stock stock, string transactionID)
        {
            PurchaseStock purchasedStock = new(stock, transactionID);
            PurchaseStockDB.Add(purchasedStock);
        }

        private void UpdateSoldDB(Stock stock, string transactionID)
        {
            SellStock soldStock = new(stock, transactionID);
            SellStockDB.Add(soldStock);
        }

        private void ConsoleWriteTransaction (string transactionID, Stock stock, bool sold = true)
        {
            string type = "Sold";
            if (!sold)
            {
                type = "Bought";
            }
            Console.WriteLine($"Transaction: {transactionID} - {type} {stock.Amount} of {stock.Ticker} at {stock.Price}. \nThe balance is now {Bank.GetBalance()}\n\n");
        }

        public void Buy(Stock stock)
        {
            UpdateBalancePaid(stock);

            string transactionID = GetTransactionID();

            UpdateBankDB(transactionID);

            UpdatePurchaseDB(stock, transactionID);

            UpdateStockPortfolioDBPurchased(stock);

            ConsoleWriteTransaction(transactionID, stock, false);

        }

        public void Sell(Stock stock) {

            UpdateBalanceReceived(stock);

            string transactionID = GetTransactionID();

            UpdateBankDB(transactionID);

            UpdateSoldDB(stock, transactionID);

            UpdateStockPortfolioDBSold(stock);

            ConsoleWriteTransaction(transactionID, stock, true);

        }
    }
}
