﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.Web.Models
{
    public class Weather
    {
        public string ParkCode { get; set; }
        public int FiveDayForecastValue { get; set; }
        public int Low { get; set; }
        public int High { get; set; }
        public string Forecast { get; set; }


        public string Unit { get; set; }



        public int ConverToCelcius(int farenheit)
        {
            int finalCelcius;

            finalCelcius = (int)((farenheit - 32) * (5 / 9.0));

            return finalCelcius;
        }


    }
}
