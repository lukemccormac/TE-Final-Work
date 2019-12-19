using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercises
{
    public class KataFizzBuzz
    {
        //Your job will be to create a method called FizzBuzz, that will accept an int, and returns a string.
        // The string that is returned is based on the following requirements:

        //If the number is divisible by 3, convert the number to the string, "Fizz".
        //If the number is divisible by 5, convert the number to the string, "Buzz".
        //If the number is divisible by 3 AND 5, convert the number to the string, "FizzBuzz"
        //For all other numbers between 1 and 100 (inclusive), simply convert the number to a string.
        //Any number that is not between 1 and 100 (inclusive), convert the number to an empty string.
        public bool containsThree(int n)
        {
        int a = 3; 
        if (n.ToString().Contains(a.ToString()))
            {
                return true;
            }
        else
            {
                return false; 
            }
        }

        public bool containsFive(int n)
        {
            int b = 5;
            if (n.ToString().Contains(b.ToString()))
            {
                return true;
            }
            else
            {
                return false; 
            }
        }

        public string FizzBuzz(int n)
        {
            if (n % 3 == 0 && n % 5 == 0 || containsFive(n) == true && containsThree(n) == true && n >= 1 && n <= 100) 
            {
                return "FizzBuzz";
            }

            else if (n % 3 == 0 || containsThree(n) == true && n >= 1 && n <= 100)
            {
                return "Fizz";
            }

            else if (n % 5 == 0 || containsFive(n) == true && n >= 1 && n <= 100)
            {
                return "Buzz"; 
            }


            else if (n % 3 != 0 && n % 5 != 0 && n >= 1 && n <= 100)
            {
                return n.ToString(); 
            }
            
            return "";      
        }
    }
}
