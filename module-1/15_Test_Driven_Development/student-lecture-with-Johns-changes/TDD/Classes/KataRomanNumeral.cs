using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TDD.Classes
{
    /// <summary>
    /// 1 = I, 5 = V, 10 = X, 50 = L, 100 = C, 500 = D, 1000 = M
    /// </summary>
    public class KataRomanNumeral
    {
        public string GetRomanNumeral(int number)
        {
            string result = "";

            result += Convert(ref number, 1000, "M");
            result += Convert(ref number, 500, "D");
            result += Convert(ref number, 100, "C");
            result += Convert(ref number, 50, "L");
            result += Convert(ref number, 10, "X");
            result += Convert(ref number, 5, "V");
            result += Convert(ref number, 1, "I");

            result = result.Replace("XXXX", "XL");
            result = result.Replace("IIII", "IV");
            result = result.Replace("CCCC", "CD");
            result = result.Replace("LXXXX", "XC");
            result = result.Replace("LXL", "XC");
            result = result.Replace("VIV", "IX");

            return result;
        }

        private string Convert(ref int number, int latinValue,
            string romanValue)
        {
            string result = "";

            while (number >= latinValue)
            {
                result += romanValue;
                number -= latinValue;
            }

            return result;
        }
    }
}
