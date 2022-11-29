using AlphaVantage.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlphaVantage.Controllers
{
    internal static class WeightedMovingAverageController
    {

        public static double Get(WMAResponse response) {
            double total = 0;

            var technicalAnalysis = response.TechnicalAnalysis.Values;

            foreach (WeightedMovingAverage date in technicalAnalysis)
            {
                double value = Convert.ToDouble(date.WMA);
                total += value;
            }

            return total / technicalAnalysis.Count;
        }
        
        public static double GetFiftyDay(WMAResponse response)
        {
            double total = 0;
            int days = 50;

            var technicalAnalysis = response.TechnicalAnalysis.Values;


            foreach (WeightedMovingAverage date in technicalAnalysis)
            {
                if (days > 0)
                {
                    double value = Convert.ToDouble(date.WMA);
                    total += value;
                    days--;
                } else
                {
                    break;
                }
            }

            return total / 50;
        }

        public static double GetTwoHundredDay(WMAResponse response)
        {
            double total = 0;
            int days = 200;

            var technicalAnalysis = response.TechnicalAnalysis.Values;


            foreach (WeightedMovingAverage date in technicalAnalysis)
            {
                if (days > 0)
                {
                    double value = Convert.ToDouble(date.WMA);
                    total += value;
                    days--;
                }
                else
                {
                    break;
                }
            }

            return total / 200;
        }
        
    }
}
