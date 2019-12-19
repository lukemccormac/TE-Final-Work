using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone.Models
{
   public class Space
    {
        public int ID { get; set; }
        public int VenueID { get; set; }
        public string Name { get; set; } = "";
        public bool IsAccessible { get; set;}
        public string OpenFrom { get; set; }
        public string OpenTo { get; set; }
        public decimal DailyRate { get; set; }
        public int MaxOccupancy { get; set; }

        public override string ToString()
        {
            return "#"+ID.ToString().PadRight(20) + Name.PadRight(25) + OpenFrom + OpenTo + DailyRate.ToString("c") + MaxOccupancy;
        }
    }
}
