using System;

namespace StringsDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            string name = "Ada Lovelace";

            // Strings are actually arrays of characters (char). 
            // Those characters can be accessed using [] notation.

            // 1. Write code that prints out the first and last characters
            //      of name.
            // Output: A
            // Output: e

            Console.WriteLine("First and Last Character. ");
            Console.WriteLine(name[0]);
            Console.WriteLine(name[name.Length - 1]);

            // 2. How do we write code that prints out the first three characters
            // Output: Ada

            Console.WriteLine("First 3 characters: ");
            Console.WriteLine(name.Substring(0, 3));

            // 3. Now print out the first three and the last three characters
            // Output: Adaace

            Console.WriteLine("First 3 and Last 3 characters: ");
            Console.WriteLine(name.Substring(0, 3) + name.Substring(name.Length - 3));

            // 4. What about the last word?
            // Output: Lovelace

            Console.WriteLine("Last Word: ");
            string[] words = name.Split(' ');
            Console.WriteLine(words[words.Length - 1]);

            // 5. Does the string contain inside of it "Love"?
            // Output: true

            if (name.Contains("Love"))
            {
                Console.WriteLine("Contains \"Love\"");
            }


            // 6. Where does the string "lace" show up in name?
            // Output: 8



             Console.WriteLine("Index of \"lace\": ");
            Console.WriteLine(name.IndexOf("lace"));

            // 7. How many 'a's OR 'A's are in name?
            // Output: 3

            Console.WriteLine("Number of \"a's\": ");

            int counter = 0;
            for (int i = 0; i < name.Length; i++)
            {
                if (name.ToLower().Substring(i,1) == "a")
                {
                    counter++;
                }
            }
            Console.WriteLine(counter);

            // 8. Replace "Ada" with "Ada, Countess of Lovelace"

            Console.WriteLine(name);

            name = name.Replace("Ada", "Ada, Countess of Lovelace");
            Console.WriteLine(name);

            // 9. Set name equal to null.
            name = null;

           

            // 10. If name is equal to null or "", print out "All Done".

            if (String.IsNullOrEmpty(name))
            {
                Console.WriteLine("All Done");
            }

            Console.ReadLine();
        }
    }
}