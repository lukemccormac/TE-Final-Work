using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace FizzWriter
{
   public static class Fizzbuzz
    {
        public static void WritingAFizzBuzzFile()
        {
            // string directory = @"..\..\..\..";
            string filename = "FizzBuzz.txt";
            // string fullPath = Path.Combine(directory, filename);
            int a = 3;
            int b = 5;

            {
                using (StreamWriter sw = new StreamWriter(filename, false))
                    for (int n = 1; n <= 300; n++)
                    {
                        if (n % 3 == 0 && n % 5 == 0)                        
                        {
                            sw.WriteLine("FizzBuzz");
                        }
                        else if (n % 3 == 0 || n.ToString().Contains(a.ToString()))
                        {
                            sw.WriteLine("Fizz");
                        }
                        else if (n % 5 == 0 || n.ToString().Contains(b.ToString()))
                        {
                            sw.WriteLine("Buzz");
                        }
                        else
                        {
                            sw.WriteLine(n);
                        }                    
                    }                    
            }
        }
    }
}





