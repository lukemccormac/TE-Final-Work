using System;
using System.Collections.Generic;
using System.Text;

namespace InheritanceExample
{
    class Truck : Vehicle
    {
        public int GrossVehicleWeight { get; set; }
        public int NumberOfAxles { get; set; }

        public Truck() :base(4)
        {

        }

    }
}
