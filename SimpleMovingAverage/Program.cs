using AlphaVantage.Controllers;
using AlphaVantage.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Runtime.Intrinsics.X86;
using System.Text.Json;
using System.Web.Helpers;
using System.Web.WebPages;
using System.Threading;
using SimpleMovingAverage.Controllers;
using TradingAlgo.Models;
using System.Timers;
using Microsoft.VisualBasic;

internal class Program
{
    private static void Main(string[] args)
    {
        Broker broker = new();
        string ticker = "IBM";

        Thread thread = new(Update(broker, ticker));
        thread.Start();
    }

    public static void Run(Broker broker, string ticker, WMAResponse response)
    {

        bool isDeal = Deal.Get(response);

        double stockPrice = 173.32;

        if (isDeal)
        {
            double balance = Bank.GetBalance();

            if (balance > stockPrice)
            {
                int amountOfStockToPurchase = (int)(balance / stockPrice);
                var buyOrder = new Stock(ticker, stockPrice, amountOfStockToPurchase);
                broker.Buy(buyOrder);
                Console.WriteLine($"{DateAndTime.Now} - {amountOfStockToPurchase} units of {ticker} were purchased at {stockPrice}.\n");
            }

            Console.WriteLine($"{DateAndTime.Now} - {ticker} is a good investment at {stockPrice}. Unfortunately our bank balance is only {balance}.\n");

        }
        else
        {
            int quantityOfStockOwned = broker.AmountOfOwnedStock(ticker);
            if (quantityOfStockOwned > 0)
            {
                var sellOrder = new Stock(ticker, stockPrice, quantityOfStockOwned);
                broker.Sell(sellOrder);
                Console.WriteLine($"{DateAndTime.Now} - {quantityOfStockOwned} units of {ticker} were sold at {stockPrice}.\n");
            } else
            {
                Console.WriteLine($"{DateAndTime.Now} - {ticker} is a bad investment at {stockPrice}. Fortunately we currently don't own any {ticker}.\n");
            }
        }

    }

    private static ParameterizedThreadStart Update(Broker broker, string ticker)
    {
        Console.WriteLine($"{DateAndTime.Now} - Staring WMA Trading algoirthm to monitor {ticker} stock...\n");
        while (true)
        {
            Console.WriteLine($"{DateAndTime.Now} - Getting Weighted Moving Average for {ticker}\n");
            WMAResponse? response = Query.WMA(ticker, "daily", "10", "open");
            Run(broker, ticker, response);
            Thread.Sleep(20000);
        }
    }

}