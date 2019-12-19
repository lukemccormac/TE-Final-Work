using System;

namespace PetInfo
{
    class Program
    {
        static void Main(string[] args)
        {
            PrintMenu();
            string selection = Console.ReadLine();

            string petType = "";
            int arraySize = 0;
            string[] pets = { "" };

            while (selection != "5")
            {

                switch (selection)
                {
                    case "1":
                        Console.WriteLine();
                        Console.WriteLine("Please enter a type of pet (dog, cat, parrot, etc.)");
                        petType = Console.ReadLine();
                        Console.WriteLine();
                        break;
                    case "2":
                        Console.WriteLine();
                        Console.WriteLine("Please enter the number of pets");
                        string petCount = Console.ReadLine();
                        arraySize = int.Parse(petCount);

                         pets = new string[arraySize];
                        Console.WriteLine();
                        break;
                    case "3":
                        Console.WriteLine();
                        for (int i = 0; i <pets.Length; i++)
                        {
                            Console.WriteLine("Please enter a pet name:");
                            pets[i] = Console.ReadLine();
                        }
                        Console.WriteLine();
                        break;
                    case "4":
                        Console.WriteLine();
                        Console.WriteLine("Pet Type: " + petType);
                        Console.WriteLine("Pet Count: " + arraySize);
                        Console.WriteLine("Please enter a pet name:");
                        for (int i = 0; i < pets.Length; i++)
                        {
                            Console.WriteLine(pets[i]);
                        }
                        Console.WriteLine();
                        break;

                    default:
                        Console.WriteLine();
                        Console.WriteLine("Please make a valid selection.");
                        Console.WriteLine();
                        break;

                }


                PrintMenu();
                selection = Console.ReadLine();
            }
        }

        static void PrintMenu()
        {
            Console.WriteLine("Please enter a choice:");
            Console.WriteLine("1 - Type of pet");
            Console.WriteLine("2 - Number of pets");
            Console.WriteLine("3 - Enter pet info");
            Console.WriteLine("4 - Show pet info");
            Console.WriteLine("5 - End program");
            return;
        }
    }
}

