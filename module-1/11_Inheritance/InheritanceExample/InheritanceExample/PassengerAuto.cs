using System;
using System.Collections.Generic;
using System.Text;

namespace InheritanceExample
{
    public class PassengerAuto :Vehicle
    {
        public string VIN { get; set; }

        public PassengerAuto( string vin) : base(4)
        {
            VIN = vin;
        }
    }
}
