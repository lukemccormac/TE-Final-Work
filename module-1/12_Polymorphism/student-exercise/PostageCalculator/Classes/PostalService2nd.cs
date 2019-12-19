using System;
using System.Collections.Generic;
using System.Text;

namespace PostageCalculator.Classes
{
    class PostalService2nd : IDeliveryDriver 
    {
        public double rate = 0;
        public double CalculateRate(int distance, double weight)
        {
            if (weight <= 2 && weight > 0)
            {
                rate = distance * 0.0035;
                return rate;
            }
            else if (weight >= 3 && weight <= 8)
            {
                rate = distance * 0.0040;
                return rate;
            }
            else if (weight >= 9 && weight <= 15)
            {
                rate = distance * 0.0047;
                return rate;
            }
            else if (weight >= 16 && weight <= 48)
            {
                rate = distance * 0.0195;
                return rate;
            }
            else if (weight >= 49 && weight <= 128)
            {
                rate = distance * 0.0450;
                return rate;
            }
            else
            {
                rate = distance * 0.0500;
                return rate;

            }
        }
        public string Name()
        {
            return "Postal Service (2nd Class)"; 
        }
    }
}
