using System;
using System.Collections.Generic;
using System.Text;

namespace PostageCalculator.Classes
{
    class PostalService3rd :IDeliveryDriver
    {
        public double rate = 0;
        public double CalculateRate(int distance, double weight)
        {
            if (weight <= 2 && weight > 0)
            {
                rate = distance * 0.0020; 
                return rate;
            }
            else if (weight >= 3 && weight <= 8)
            {
                rate = distance * 0.0022;
                return rate;
            }
            else if (weight >= 9 && weight <= 15)
            {
                rate = distance * 0.0024;
                return rate;
            }
            else if (weight >= 16 && weight <= 48)
            {
                rate = distance * 0.0150;
                return rate;
            }
            else if (weight >= 49 && weight <= 128)
            {
                rate = distance * 0.0160;
                return rate;
            }
            else
            {
                rate = distance * 0.0170;
                return rate;
            }
        }
        public string Name()
        {
            return "Postal Service (3rd Class)"; 
        }
    }
}
