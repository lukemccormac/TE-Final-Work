using System;
using Lecture.Aids;

namespace Lecture
{
    class Program
    {
        static void Main(string[] args)
        {
            // Here are a few examples of reading in a file and writing out values
            // to demonstrate their value.
            //ReadingInFiles.ReadACharacterFile();
            //ReadingInFiles.ReadInACSVFile();  
            //WritingTextFiles.WritingAFile();
            //LoopingCollectionToWriteFile.LoopingADictionaryToWriteAFile();
            //BinaryFileWriter.WritePrimitiveValues();
            BinaryFileWriter.ReadPrimitiveValues();
            //BinaryImageManipulator.ReadFileIn();
            //PerformanceDemo.SlowPerformance();
            //PerformanceDemo.FastPerformance();

            Console.Write("Press enter to finish");
            Console.ReadLine();
        }
    }
}
