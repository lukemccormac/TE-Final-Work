using System;
using System.Collections.Generic;
using System.Text;

namespace TollBoothCalculator.Classes
{
    class Tank : IVehicle
    {
        double toll = 0;
        public double CalculateToll(int distance)
        {
            toll = distance * 0;
            return toll; 
        }
        public string VehicleType()
            {
                return "Tank"; 
            }
    }
}
