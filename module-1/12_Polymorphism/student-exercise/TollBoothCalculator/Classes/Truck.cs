using System;
using System.Collections.Generic;
using System.Text;

namespace TollBoothCalculator.Classes
{
    class Truck : IVehicle
    {
        double toll = 0.00;
        public int NumberOfAxles { get; }
        public Truck(int numberOfAxles)
        {
            NumberOfAxles = numberOfAxles; 
        }
        public string VehicleType()   
            {
                if (NumberOfAxles == 4)
                {
                    return "Truck (4 Axles)";
                }
                else if (NumberOfAxles == 6)
                {
                    return "Truck (6 Axles)";
                }
                else if (NumberOfAxles == 8)
                {
                    return "Truck (8 Axles)"; 
                }  
                else
            {
                return "Truck" + "(" + NumberOfAxles + " Axles)"; 
            }
            }
        
        public double CalculateToll(int distance)
        {
            if (NumberOfAxles == 4)
            {
                toll = distance * 0.04;
                toll = Math.Round(toll, 2); 
                return toll;
            }
            else if (NumberOfAxles == 6)
            {
                toll = distance * 0.045;
                toll = Math.Round(toll, 2);
                return toll;
            }
            else 
            {
                toll = distance * 0.048;
                toll = Math.Round(toll, 2); 
                return toll; 
            }
        }
    }
}
