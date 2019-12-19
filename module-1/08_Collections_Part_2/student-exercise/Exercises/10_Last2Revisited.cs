using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercises
{
    public partial class Exercises
    {
        /*
         * Just when you thought it was safe to get back in the water --- Last2Revisited!!!!
         *
         * Given an array of strings, for each string, the count of the number of times that a substring length 2 appears
         * in the string and also as the last 2 chars of the string, so "hixxxhi" yields 1.
         *
         * We don't count the end substring, but the substring may overlap a prior position by one.  For instance, "xxxx"
         * has a count of 2, one pair at position 0, and the second at position 1. The third pair at position 2 is the
         * end substring, which we don't count.
         *
         * Return Dictionary<string, int>, where the key is string from the array, and its last2 count.
         *
         * Last2Revisited(["hixxhi", "xaxxaxaxx", "axxxaaxx"]) → {"hixxhi": 1, "xaxxaxaxx": 1, "axxxaaxx": 2}
         *
         */
        public Dictionary<string, int> Last2Revisited(string[] words)
        {
            Dictionary<string, int> lastTwoDictionary = new Dictionary<string, int>();
            int counter = 0;
            foreach (string result in words)
            {
                if (result.Length < 4)
                {
                    lastTwoDictionary.Add(result, 0);
                }
                else if (result.Length == 4)
                {
                    for (int i = 0; i < result.Length-1; i++)
                    {
                        if (result.Substring(i, 2).Equals(result.Substring(result.Length - 2, 2)))
                        {
                            counter++;
                        }
                        lastTwoDictionary.Add(result, counter-1);
                    }
                }
                else 
                {
                    for (int i = 0; i < result.Length-3; i++)
                    {
                        if (result.Substring(i, 2).Equals(result.Substring(result.Length - 2, 2)))
                        {
                            counter++;
                           
                        }
                       
                    }
                    lastTwoDictionary.Add(result, counter);
                }
            }
            return lastTwoDictionary;
        }
    }    
}
        