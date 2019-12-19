using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone.Models
{
    public class Receipt
    {
            public int SpaceID { get; set; }
            public int groupSize { get; set; }           
            public DateTime FromDate { get; set; }
            public DateTime ToDate { get; set; }
            public string ReservedName { get; set; } = "";
    }
}
