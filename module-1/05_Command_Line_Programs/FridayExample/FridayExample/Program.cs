using System;

namespace FridayExample
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please enter you name:");
            string name = Console.ReadLine();

            Console.WriteLine("How many dollars are in your pocket( 0, 5, 7, etc.):");
            string dollars = Console.ReadLine();

            int count = int.Parse(dollars);

            Console.WriteLine("Please enter a sentence:");
            string sentence = Console.ReadLine();
            string[] result = sentence.Split(' ');


            Console.WriteLine("Your name is : " + name);
            Console.WriteLine("That is $" + (100 - count) + " less than $100");
            for (int i = 0; i < result.Length; i++)
            {
                Console.WriteLine(result[i]);
            }


            Console.ReadLine();
        }
    }
}
