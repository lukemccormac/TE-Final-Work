using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TDD.Classes
{
    public class KataRomanNumeral
    {
       public string ConvertToRomanNumeral(int n)
        {
            string result = String.Empty;

            result = ConvertDetail(ref n, result, "M", 1000);

            result = ConvertDetail(ref n, result, "D", 500);

            result = ConvertDetail(ref n, result, "C", 100);

            result = ConvertDetail(ref n, result, "L", 50);

            result = ConvertDetail(ref n, result, "X", 10);

            result = ConvertDetail(ref n, result, "V", 5);

            result = ConvertDetail(ref n, result, "I", 1);

            result = result.Replace("IIII", "IV");
            result = result.Replace("CCCC", "CD"); 

            return result; 
        }

        private string  ConvertDetail(ref int currentValue, string working, string romanNumeral, int arabicNumeral)
        {
            while (currentValue >= arabicNumeral)
            {
                working += romanNumeral;
                currentValue -= arabicNumeral;
            }
            return working; 
        }
    }
}
