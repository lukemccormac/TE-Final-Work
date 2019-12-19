using System;
using System.Collections.Generic;
using System.Text;

namespace PostageCalculator.Classes
{
    class FedEx : IDeliveryDriver
    {
        public double rate = 0; 
        public double CalculateRate(int distance, double weight)
        {
            rate = 20; 
            if (distance > 500)
            {
                rate = rate + 5;
                return rate; 
                    
            }
            else if (weight > 48 )
            {
                rate = rate + 3;
                return rate; 
            }
            else
            {
                return rate; 
            }
        }
        public string Name()
        {
            return "FexEd"; 
        }
    }
}
