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
         Suppose the string "yak" is unlucky. Given a string, return a version where all the "yak" are removed, but
         the "a" can be any char. The "yak" strings will not overlap.
         StringYak("yakpak") → "pak"
         StringYak("pakyak") → "pak"
         StringYak("yak123ya") → "123ya"
         */
        public string StringYak(string str)
        {
            string[] noYak = str.Split("yak");
            string newString = "";
// foreach string in my current array/collection were in "noYak", noYak is what was made when split into array at the "yak" mark            
            foreach(string myStr in noYak)
            {

                if (myStr != "yak")
                {
                    newString += myStr;
                }
               
            }
            return newString;

        }
     }
    }

