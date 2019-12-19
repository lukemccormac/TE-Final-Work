using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Forms.Web.Models
{
    public class City
    {
        public int CityId { get;  set; }
        
        [Required]
        [MinLength(3,ErrorMessage = "Name must be at least 3 characters")]
        public string Name { get;  set; }

        [Required]
        public string CountryCode { get;  set; }

        [Required]
        public string District { get;  set; }

        [Range(100,100000000)]
        public int Population { get;  set; }
    }
}
