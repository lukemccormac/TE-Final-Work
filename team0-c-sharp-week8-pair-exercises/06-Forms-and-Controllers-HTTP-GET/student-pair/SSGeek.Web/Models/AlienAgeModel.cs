using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SSGeek.Web.Models
{
    public class AlienAgeModel
    {
        public string Planet { get; set; }
        public int EarthAge { get; set; }
    }
}
