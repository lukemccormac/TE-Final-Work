using System;
using System.Collections.Generic;
using System.Text;

namespace PostageCalculator.Classes
{
    class SPU_NextDay_ : IDeliveryDriver
    {
        public double rate = 0;
        public double CalculateRate(int distance, double weight)
        {
            rate = ((weight/16) * 0.075) * distance;
            return rate; 
        }
        public string Name()
        {
            return "SPU (Next Day)"; 
        }
    }
}
