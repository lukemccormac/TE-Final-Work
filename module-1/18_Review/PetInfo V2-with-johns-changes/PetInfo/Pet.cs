using System;
using System.Collections.Generic;
using System.Text;

namespace PetInfo
{
    public class Pet
    {
        public string Name { get; set; } = "";
        public string Type { get; set; } = "";
        public string FamilyName { get; set; } = "";
        public int AgeInMonths { get; set; }

        public Pet()
        {

        }

        public Pet(string name, string type, string familyName, int ageInMonths)
        {
            Name = name;
            Type = type;
            FamilyName = familyName;
            AgeInMonths = ageInMonths;
        }

        public override string ToString()
        {
            return Name.PadRight(20) + Type.PadRight(15) + FamilyName.PadRight(20) + (AgeInMonths / 12.0).ToString("F2");
        }
    }
}
