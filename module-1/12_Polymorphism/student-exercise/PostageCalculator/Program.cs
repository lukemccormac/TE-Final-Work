using System;
using System.Collections.Generic;
using System.Text;

using PostageCalculator.Classes; 

namespace PostageCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Pease enter the weight of the package?");
            string strWeight = Console.ReadLine();
            double weight = double.Parse(strWeight);

            Console.WriteLine("(P)ounds or (O)unces ?");
            string POrO = Console.ReadLine();
            if (POrO == "P")
            weight = weight * 16;

            Console.WriteLine("What distance will it be traveling?");
            string strDistance = Console.ReadLine();
            int distance = int.Parse(strDistance);

            Console.WriteLine("Delivery Method                 $ cost");
            Console.WriteLine("--------------------------------------");
            List<IDeliveryDriver> pricesForDeilvery = new List<IDeliveryDriver> { new FedEx(), new PostalService1st(),
            new PostalService2nd(), new PostalService3rd(), new SPU_2day_(), new SPU_4day_(), new SPU_NextDay_()};
            foreach (IDeliveryDriver drivers in pricesForDeilvery)
            {
                Console.WriteLine(drivers.Name().PadRight(35) + " " + drivers.CalculateRate(distance, weight).ToString().PadLeft(2) + "$");
            }
            Console.ReadLine(); 
        }
    }
}
