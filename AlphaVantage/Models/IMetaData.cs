using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlphaVantage.Models
{
    public class IMetaData
    {
        [JsonProperty(PropertyName = "1: Symbol")]
        public string Symbol { get; set; }
        [JsonProperty(PropertyName = "2: Indicator")]
        public string Indicator { get; set; }
        [JsonProperty(PropertyName = "3: Last Refreshed")]
        public string LastRefreshed { get; set; }
        [JsonProperty(PropertyName = "4: Interval")]
        public string Interval { get; set; }
        [JsonProperty(PropertyName = "5: Time Period")]
        public int TimePeriod { get; set; }
        [JsonProperty(PropertyName = "6: Series Type")]
        public string SeriesType { get; set; }
        [JsonProperty(PropertyName = "")]
        public string TimeZone { get; set; }
    }
}
