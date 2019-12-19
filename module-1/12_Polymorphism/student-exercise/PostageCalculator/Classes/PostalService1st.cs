using System;
using System.Collections.Generic;
using System.Text;

namespace PostageCalculator.Classes
{
    class PostalService1st : IDeliveryDriver 
    {
        public double rate = 0;
        public double CalculateRate(int distance, double weight)
        {
            if (weight <= 2 && weight > 0)
            {
                rate = 0.035 * distance;
                return rate;
            }
            else if (weight >= 3 && weight <= 8)
            {
                rate = distance * 0.040;
                return rate;
            }
            else if (weight >= 9 && weight < 16)
            {
                rate = 0.047 * distance;
                return rate;
            }
            else if (weight >= 16 && weight <= 48)
            {
                rate = distance * 0.195;
                return rate; 
            }
            else if (weight >= 49 && weight <=128)
            {
                rate = distance * 0.450;
                return rate;
            }
            else
            {
                rate = distance * 0.500;
                return rate; 

            }
        }
        public string Name()
        {
            return "Postal Service (1st Class)";
        }
    }
}
