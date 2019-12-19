using System;
using System.Collections.Generic;
using System.Text;

namespace TollBoothCalculator.Classes
{
    class Car : IVehicle
    {
        double toll = 0.00;
        public bool HasTrailer { get; }
        public Car(bool hasTrailer)
        {
            HasTrailer = hasTrailer;
        }
        public string VehicleType()
        {
            {
                if (HasTrailer == true)
                {
                    return "Car has trailer";
                }
                else
                {
                    return "Car";
                }
            }
        }
        public override string ToString()
        {
            return base.ToString();
        }
        public double CalculateToll(int distance)
        {
            if (HasTrailer == false)
            {
                toll = distance * 0.020;
                toll = Math.Round(toll, 2); 
                return toll;
            }
            else
            {
                toll = distance * 0.020 + 1;
                toll = Math.Round(toll, 2);
                return toll;
            }
        }
    }
}
