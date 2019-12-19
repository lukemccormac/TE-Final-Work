using System;
using System.Collections.Generic;
using System.Text;
using TollBoothCalculator.Classes;

namespace TollBoothCalculator
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Vehicle".PadRight(16) +"Distance travled"+ " Toll $".PadLeft(15));
            Console.WriteLine("--------------------------------------------------------");
            Random rnd = new Random();
            int distance = 0;
            int TotalDistance = 0; 
            double TollMoney = 0.00;

            List<IVehicle> vehicles = new List<IVehicle> { new Car(true), new Car(false), new Tank(),
                new Truck(4), new Truck(6), new Truck(8)}; 
            foreach (IVehicle vehicle in vehicles)
            {
                distance = rnd.Next(10, 240);
                Console.Write(vehicle.VehicleType().PadRight(25) + " " + distance + " " + vehicle.CalculateToll(distance).ToString().PadLeft(15));
                Console.WriteLine();

                TotalDistance = TotalDistance + distance;
                TollMoney = TollMoney + vehicle.CalculateToll(distance);
            }
            Console.WriteLine(); 
            Console.WriteLine("Total Miles Traveled: " + TotalDistance);
            Console.WriteLine("Total Tollbooth Revenue: $" + TollMoney); 

            Console.ReadLine(); 
        }
    }
}
