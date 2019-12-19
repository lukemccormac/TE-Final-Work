using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace FileSplitter
{
    public static class FileSplit
    {
        public static void SplittingAFile()
        {
            Console.WriteLine("Where is the input file(please include the path to the file) ?");
            string inputFullPath = Console.ReadLine();
            Console.WriteLine("How many lines of text(max) should there be in the split files ?");
            string numberOfLines = Console.ReadLine();


            string directory = @"c:\goodplace";
            string inputFile = "alice.txt";
            string outputFile = "alice.split";
            string inputFillPath = Path.Combine(directory, inputFile);
            string outputFilePath = Path.Combine(directory, outputFile);

            {

                using (StreamReader sr = new StreamReader(inputFile))
                {
                    using (StreamWriter sw = new StreamWriter(outputFile, true))
                    {
                        while (!sr.EndOfStream)
                        {
                            // Read an individual line
                            string line = sr.ReadLine();


                            // Write the new line to the output file
                            sw.WriteLine(numberOfLines);
                        }
                    }
                }
            }
        }
    }
}
