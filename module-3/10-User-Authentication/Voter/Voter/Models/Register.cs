using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Voter.Models
{
    public class Register
    {
        [Required] 
        public string UserName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string PassWord { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Compare("PassWord")]
        public string PassWordRepeat { get; set; }
    }
}
