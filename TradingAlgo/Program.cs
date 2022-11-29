// See https://aka.ms/new-console-template for more information
using TradingAlgo.Models;

Console.WriteLine($"Bank Balance is: {Bank.GetBalance()}\n");

Broker broker = new();

Console.WriteLine($"Algorithm starting... \n\n\n");

broker.Buy(new Stock("Apple Inc. (AAPL)", 147.94, 3));
broker.Buy(new Stock("Rolls-Royce Holdings plc (RR-L)", 84.81, 2));
broker.Buy(new Stock("Alibaba Group Holding Limited (BABA)", 76.95, 4));
broker.Sell(new Stock("Rolls-Royce Holdings plc (RR-L)", 90.81, 1));
broker.Sell(new Stock("Alibaba Group Holding Limited (BABA)", 82.95, 4));


