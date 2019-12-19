using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone.Models
{
    public class Venue
    {
        public int ID { get; set; }
        public string Name { get; set; } = "";
        public int CityID { get; set; }
        public string Description { get; set; } = "";

        public override string ToString()
        {
            return ID.ToString() + ") ".PadRight(20) + Name.PadRight(25);
        }


    }
}
