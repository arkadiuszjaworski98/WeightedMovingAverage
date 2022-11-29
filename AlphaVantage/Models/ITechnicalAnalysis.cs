using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlphaVantage.Models
{
    internal interface ITechnicalAnalysis
    {
        public WeightedMovingAverage Date { get; set; }
    }
}
