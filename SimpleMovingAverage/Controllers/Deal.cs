using AlphaVantage.Controllers;
using AlphaVantage.Models;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TradingAlgo.Models;

namespace SimpleMovingAverage.Controllers
{
    public static class Deal
    {

        public static bool Get(WMAResponse response)
        {
            return WeightedMovingAverageController.GetFiftyDay(response) > WeightedMovingAverageController.GetTwoHundredDay(response);
        }
    }

    /* 
     * 
     *             if (fiftyDay > twoHundredDay)
            {
                Bank.GetBalance();
                // check balance
                // if available buy
            } else
            {
                // check if stock owned
                // if owned sell
            }
     * 
     */
}
