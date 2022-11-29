using AlphaVantage.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace AlphaVantage.Controllers
{
    public static class Query
    {
        public static string ApiKey = "OL8EX49JW7UXYPNJ";
        public static string Domain = "https://www.alphavantage.co/query";
        public static WMAResponse WMA(string symbol, string interval, string timePeriod, string seriesType)
        {
            // replace the "demo" apikey below with your own key from https://www.alphavantage.co/support/#api-key
            // https://www.alphavantage.co/query?function=SMA&symbol=IBM&interval=weekly&time_period=10&series_type=open&apikey=demo
            string QUERY_URL = $"{Domain}" +
                $"?" +
                $"function=WMA" +
                $"&" +
                $"symbol={symbol}" +
                $"&" +
                $"interval={interval}" +
                $"&" +
                $"time_period={timePeriod}" +
                $"&" +
                $"series_type={seriesType}" +
                $"&" +
                $"apikey={ApiKey}";

            Uri queryUri = new Uri(QUERY_URL);

            using (WebClient client = new())
            {
                var json = client.DownloadString(queryUri);
                return JsonConvert.DeserializeObject<WMAResponse>(json);
            }
        }
    }
}
