﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercises
{
    public partial class Exercises
    {
        /*
         * Given an array of strings, return a Dictionary<string, Boolean> where each different string is a key and value
         * is true only if that string appears 2 or more times in the array.
         *
         * WordMultiple(["a", "b", "a", "c", "b"]) → {"b": true, "c": false, "a": true}
         * WordMultiple(["c", "b", "a"]) → {"b": false, "c": false, "a": false}
         * WordMultiple(["c", "c", "c", "c"]) → {"c": true}
         *
         */
        public Dictionary<string, bool> WordMultiple(string[] words)
        {
        Dictionary<string, bool> trueForMultiples = new Dictionary<string, bool>();
                foreach (string result in words)
                {
                    if (trueForMultiples.ContainsKey(result))
                    {
                        trueForMultiples[result] = true;
                    }
                    else
                    {
                        trueForMultiples[result] =  false;
                    }
                }
                return trueForMultiples;
        }
    }
}
