using System;
using System.Collections.Generic;
using System.Text;

namespace PetInfo
{
    class ConsoleInterface
    {
        private string petType = "";
        private int arraySize = 0;
        private List<Pet> pets = new List<Pet>();
        private int numberOfPets;

        public void Run()
        {
            PrintMenu();
            string selection = Console.ReadLine();

            while (selection != "5")
            {

                switch (selection)
                {

                    case "1":
                        GetPetCount(); 
                        break;
                    case "2":
                        EnterPetInfo();
                        break; 
                    case "3":
                        DisplayPetInfo(); 
                        break;
                    case "4":
                        WriteToFile();
                        break;
                    case "5":
                        ReadFromFile();
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

        private void PrintMenu()
        {
            Console.WriteLine("Please enter a choice:");
            Console.WriteLine("1 - Number of pets");
            Console.WriteLine("2 - Enter pet info");
            Console.WriteLine("3 - Show pet info");
            Console.WriteLine("4 - Write Informaton to file");
            Console.WriteLine("5 - Read info from file");
            Console.WriteLine("6 - End program");
            return;
        }

        private void GetPetCount()
        {
            Console.WriteLine();
            Console.WriteLine("Please enter the number of pets");
            string petCount = Console.ReadLine();
            numberOfPets = int.Parse(petCount);

            Console.WriteLine();
        }

        private void EnterPetInfo()
        {
            Console.WriteLine(); 
            for (int i = 0; i < numberOfPets; i++)
            {
                Pet pet = new Pet(); 

                Console.WriteLine("Please enter a pet name:");
                pet.Name = Console.ReadLine();

                Console.WriteLine("Please eneter a type of pet (dog, cat, parrot, etc.)");
                pet.Type = Console.ReadLine(); 

                Console.WriteLine("Please enter the famly name");
                pet.FamilyName = Console.ReadLine(); 

                Console.WriteLine("Please enther the age in months");
                pet.AgeInMonths = int.Parse(Console.ReadLine());
                // todo add exception handling, try catch 

                pets.Add(pet);
            }
        }

        private void DisplayPetInfo()
        {
            Console.WriteLine();
            Console.WriteLine("Pet Count: " + arraySize);
            Console.WriteLine("Pet names:");
            for (int i = 0; i < pets.Count; i++)
            {
                Console.WriteLine(pets[i]);
            }
            Console.WriteLine();
        }

        private void WriteToFile()
        {
            DataAccess dataAccess = new DataAccess();
            bool result = dataAccess.WriteToFile(pets);
            if (result)
            {
                Console.WriteLine("Write to fule was successful;");
            }
            else
            {
                Console.WriteLine("Write to file failed");
            }
            Console.WriteLine();
            return; 
        }

        private void ReadFromFile()
        {
            DataAccess dataAccess = new DataAccess();
            List<Pet> result = dataAccess.ReadFromFile();

            if (result != null && result.Count > 0)
            {
                pets = result; 
                Console.WriteLine("Read from file was successful;");
            }
            else
            {
                Console.WriteLine("Read from file failed");
            }
            Console.WriteLine();
            return;
        }

    }
}


