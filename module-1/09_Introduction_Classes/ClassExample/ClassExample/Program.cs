using System;

namespace ClassExample
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Television myTelevision = new Television(34);
            Console.WriteLine(myTelevision.ToString());

            myTelevision.SerialNumber = "ABC123";
            Console.WriteLine(myTelevision.SerialNumber);

            myTelevision.Voltage = 220;
            Console.WriteLine(myTelevision.Voltage);

            Console.WriteLine(myTelevision.SetCaPbWarning(true));

            Console.WriteLine(myTelevision.Marketplace);

            Console.ReadLine();

        }
    }
}
