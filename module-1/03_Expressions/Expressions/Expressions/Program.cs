using System;

namespace Expressions
{
    class Program
    {
        static void Main(string[] args)
        {
            int AddOne(int inputValue)
            {
                inputValue++; 
                return inputValue; 
            }
            //Expressions

            int result = 7;

            result = result * 13 / 4;

            int value = (result + 7) * 6;

            double myValue = 6.7 / 8;

            bool isItDone = true;

            string name = "Luke McCormac";

            result = result + 1;
            result += 1; 
            result += 7;
            result++;
            ++result;

            //post increment
            int myValueA = 6;
            result = myValueA++;

            //pre increment
            int myValue2 = 6;
            result = ++myValue2;


            //blocks

            {
                int blockVariable = 7;
                Console.WriteLine(blockVariable);
            }
            Console.WriteLine(blockVariable);

            if (7>5)
            {
            
            }

            Console.ReadLine();
        }
    }
}
