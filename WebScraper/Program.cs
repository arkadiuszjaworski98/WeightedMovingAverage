// See https://aka.ms/new-console-template for more information

using HtmlAgilityPack;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Net;
using System.Text;
using System.IO;
using Microsoft.VisualBasic;

string Symbol = "BABA";

async Task<string> GetPriceAsync(string symbol) {

    string price = "";

    string url = $"https://finance.yahoo.com/quote/{symbol}/";

    HttpClient client = new();
    var response = await client.GetStringAsync(url);

    var livePriceElement = "<fin-streamer class=\"Fw(b) Fz(36px) Mb(-4px) D(ib)\"";

    int indexOfLivePriceElement = response.IndexOf(livePriceElement);
    string livePriceElementString = response.Substring(indexOfLivePriceElement, 200);
    int indexOfPriceStart = livePriceElementString.IndexOf(">");
    string priceStringContainer = response.Substring(indexOfLivePriceElement + indexOfPriceStart + 1, 10);

    for (int i = 0; i < priceStringContainer.Length; i++)
    {
        if (priceStringContainer[i] == char.Parse("<"))
        {

            price = priceStringContainer.Substring(0,i);
        }
    }

    return price;
}

while (true)
{
    Console.WriteLine($"{DateAndTime.Now} - price of {Symbol} is {await GetPriceAsync(Symbol)}");
    Thread.Sleep(100);
}
// https://www.google.com/finance/quote/9988:HKG
