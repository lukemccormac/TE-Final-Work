using System;

namespace TempConvert
{
    class Program
    {
        static void Main(string[] args)
            
        {
            Console.Write("Please enter the temperature: ");
            string strInput = Console.ReadLine();

            double finalTemp = double.Parse(strInput); 

            Console.WriteLine("Is the temperature in (C)elcius, or(F)arenheit ? ");
            string cOrF = Console.ReadLine();
       
            switch(cOrF)
            {
                case "F":
                    Console.Write(finalTemp + " F is " + ((finalTemp - 32) / 1.8 ) + " C.");
                    break;
                case "C":
                    Console.WriteLine(finalTemp + (" C is " + (finalTemp * 1.8 + 32) + " F."));
                    break;
                default:
                    Console.WriteLine ("Please submit a valid response");
                    break;

                    //  Tf = Tc * 1.8 + 32
            }

            Console.ReadLine();
        }
    }
}
