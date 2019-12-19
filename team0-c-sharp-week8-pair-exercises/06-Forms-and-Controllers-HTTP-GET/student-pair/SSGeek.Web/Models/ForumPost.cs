using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SSGeek.Web.Models
{
    public class ForumPost
    {      
        [Required]
        [MinLength(2)]
        public string Subject { get; set; }

        [Required]
        [MaxLength(20)]
        public string UserName { get; set; }

        [Required]
        public string Message { get; set; }

        public DateTime TimeOfPost { get; set; }
    }
}