using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlphaVantage.Models
{
    public class WMAResponse
    {
        [JsonProperty(PropertyName = "Meta Data")]
        public IMetaData MetaData { get; set; }

        [JsonProperty(PropertyName = "Technical Analysis: WMA")]
        public Dictionary<string, WeightedMovingAverage> TechnicalAnalysis { get; set; }

    }
}
