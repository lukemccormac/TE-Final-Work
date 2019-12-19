using System;
using System.Collections.Generic;
using System.Text;

namespace PostageCalculator.Classes
{
    class SPU_4day_ : IDeliveryDriver 
    {
        public double rate = 0;
        public double CalculateRate(int distance, double weight)
        {
            rate = ((weight/16) * 0.0050) * distance;
            return rate; 
        }
        public string Name()
        {
            return "SPU (4-Day Ground)"; 
        }
    }
}
