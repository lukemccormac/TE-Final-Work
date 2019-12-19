using System;
using System.Collections.Generic;
using System.Text;

namespace InheritanceExample
{
    public class Vehicle
    {
        public Vehicle(int wheelCount)
        {
            WheelCount = wheelCount;
        }

        public int WheelCount { get; set; }
        public int NumberOFDoors { get; set; }
        public string Manufacturer { get; set; }
        public int NumberOfSeats { get; set; }
    }
}
