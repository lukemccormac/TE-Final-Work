using System;
using System.IO;

namespace Lecture.Aids
{
    public static class SummingUpNumbers
    {
        public static void ReadFile()
        {
            // Reading in a file of numbers
            //string folder = Environment.CurrentDirectory; //an ugly name
            string folder = "c:\\goodPlace"; //or you can create a nice place

            string filename = "number.txt";
            // get the full path
            string fullpath = Path.Combine(folder, filename);

            int sum = 0;

            try
            {
                using (StreamReader sr = new StreamReader(fullpath))
                {

                    // Read until we get to the end of the file
                    while (!sr.EndOfStream)
                    {
                        // TODO - Changes inside read loop
                        string result = sr.ReadLine();
                        int myValue = int.Parse(result);
                        sum += myValue;

                        // Read the line
                        // Convert to a number
                        // Add to Sum
                    }
                }
            }
            catch (System.FormatException ex)
            {
                Console.WriteLine("Unable to process. Please check data.");
            }
            catch (IOException ex)
            {
                Console.WriteLine("IO Exception");
                Console.WriteLine(ex.Message);
            }


            Console.WriteLine("The sum is " + sum);

            Console.ReadLine();
        }
    }
}
