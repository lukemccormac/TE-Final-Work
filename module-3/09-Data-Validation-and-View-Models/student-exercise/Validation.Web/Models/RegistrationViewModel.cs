using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Validation.Web.Models
{
    public class RegistrationViewModel
    {
        [Required (ErrorMessage ="*")]
        [MaxLength (20)]
        public string FirstName { get; set; }

        [Required (ErrorMessage = "*")]
        [MaxLength(20)]
        public string LastName { get; set; }

        [Required]
        [EmailAddress(ErrorMessage ="Invalid Email")]
        public string Email { get; set; }

        [Required]
        [Compare("Email", ErrorMessage ="Email Address does not match")]
        public string ConfirmEmail { get; set; }

        [Required]
        [MinLength(8, ErrorMessage = "Password Minimum is 8 characters")]
        public string Password { get; set; }

        [Required]
        [Compare("Password", ErrorMessage ="Passwords do not match")]
        public string ConfirmPassword { get; set; }

        [Required(ErrorMessage ="The value entered is not a valid birthday")]              
        public DateTime? BirthDate { get; set; }

        [Required]
        [MinLength(1),MaxLength(10,ErrorMessage ="The # of tickets must be between 1 and 10")]
        public string NumberOfTickets { get; set;  }
    }
}