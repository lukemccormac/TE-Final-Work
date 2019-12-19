using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercises
{
    public partial class StringExercises
    {
        /*
         Given a string, return true if the first instance of "x" in the string is immediately followed by another "x".
         DoubleX("axxbb") → true
         DoubleX("axaxax") → false
         DoubleX("xxxxx") → true
         */
        public bool DoubleX(string str)
        {
           if (str.Length < 2)
            {
                return false;
            }
            bool isFirstX = true;
                for (int i = 0; i < str.Length - 1; i++)
                {
                    if (str.Substring(i, 1).Equals("x") && isFirstX)
                    {
                        isFirstX = false;
                        if (str.Substring(i + 1, 1).Equals("x"))
                        {
                            return true; 
                        }
                    } 
                  
                }
                return false;
        }
    }
}
