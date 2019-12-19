using System;
using System.Collections.Generic;
using System.Text;

namespace TollBoothCalculator.Classes
{
    public interface IVehicle
    {
        string VehicleType();   
        double CalculateToll(int distance);
    }
}
