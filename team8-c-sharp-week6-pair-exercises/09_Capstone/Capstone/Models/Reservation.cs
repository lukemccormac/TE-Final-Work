using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone.Models
{
    public class Reservation
    {
        public int SpaceID { get; set; }
        public string VenueName { get; set; } = "";
        public decimal DailyRate { get; set; }
    }
}
