using System;

namespace DecimalToBinary
{
    class Program
    {
        static void Main (string[] args)
        {
            {
                Console.Write("Please enter in a series of decimal values (separated by spaces): ");
                string strInput = Console.ReadLine();
                

                string[] strNumbers = strInput.Split(' ');
                int[] decNumbers = new int[strNumbers.Length];
                

                for (int i = 0; i < strNumbers.Length; i++)
                {
                    decNumbers[i] = int.Parse(strNumbers[i]);
                    string binary = Convert.ToString(decNumbers[i], 2);



                    Console.WriteLine(decNumbers[i] + " in binary is " + binary);
                }


                Console.ReadLine();
            }
        }
    }
}
