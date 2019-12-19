using System;

namespace InheritanceExample
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            Vehicle myVehicle = new Vehicle(4);
            myVehicle.Manufacturer = "Ford";

            PassengerAuto myCar = new PassengerAuto("ABC123");
            myCar.NumberOFDoors = 3;

            Truck myTruck = new Truck();
            myTruck.GrossVehicleWeight = 10000;

            Console.ReadLine();


        }
    }
}
