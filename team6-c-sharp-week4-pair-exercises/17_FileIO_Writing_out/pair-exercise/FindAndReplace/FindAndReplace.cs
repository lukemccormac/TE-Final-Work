using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace FindAndReplace
{
    public static class FindAndReplace
    {
        public static void SearchAndReplace()          
        {
           
            Console.WriteLine("Please enter the word you would like to search");
            string searchWord = Console.ReadLine();

            Console.WriteLine("Please enter the word you would like to replace it with");
            string replaceWord = Console.ReadLine();

            Console.WriteLine("Please enter the source file path");
            string inputFullPath = Console.ReadLine();

            Console.WriteLine("Please enter the destination file path");
            string outputFullPath = Console.ReadLine();

            try
            {
                using (StreamReader sr = new StreamReader(inputFullPath))
                {
                    using (StreamWriter sw = new StreamWriter(outputFullPath, true))
                    {
                        while (!sr.EndOfStream)
                        {
                            string line = sr.ReadLine();

                            string fixedLine = line.Replace(searchWord, replaceWord);

                            sw.WriteLine(fixedLine);
                        }
                    }
                }
            }
            catch (IOException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
