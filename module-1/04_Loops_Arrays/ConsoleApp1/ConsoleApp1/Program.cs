using System;

namespace PetCount

{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            string result = CountMyPets(6, 6);
            Console.WriteLine(result); 

            Console.ReadLine();
        }
        static string CountMyPets(int catCount, int dogCount)
        {
            if (catCount > 3)
            {
                return "You have too many cats!";
            }
            else if(dogCount > 2)
            {
                return "You have too many dogs!";
            }
            else if((catCount + dogCount) > 4)
            {
                return ("You ave too many pets!");
            }
            else
            {
                return "";
            }
            
        }
    }
}
