using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone.Models
{
    public class State
    {
        public int Id { get; set; }
        public string Name { get; set; } = "";
        public string StateAbbreviation { get; set; } = "";

        public override string ToString()
        {
            return Name.ToString() + ", ".PadRight(20) + StateAbbreviation;
        }

    }
}