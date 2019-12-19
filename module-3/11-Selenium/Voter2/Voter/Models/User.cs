using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Voter.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public int Role { get; set; } //0 is ordinary, 1 is Admin
    }
}