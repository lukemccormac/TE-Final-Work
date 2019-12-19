using System;

namespace LinearConvert
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Please enter the length: ");
            string strInput= Console.ReadLine(); 

            double finalLength = double.Parse(strInput);

            Console.WriteLine("Is the length in (M)eters or (F)eet: ");
            string fOrM = Console.ReadLine();

            switch (fOrM)
            {
                case "F":
                    Console.WriteLine(finalLength + " F is " + (finalLength * 0.3048) + " M.");
                    break;
                case "M":
                    Console.WriteLine(finalLength + " M is " + (finalLength * 3.2808399) + " F.");
                    break;
                default:
                    Console.WriteLine("Please submit a valid response");
                    break;
            }


            Console.ReadLine(); 


            }
    }
}
