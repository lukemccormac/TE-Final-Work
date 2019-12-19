using System;

namespace Fibonacci
{
    class Program
    {
        static void Main(string[] args)

        {
            Console.Write("Please enter a number: ");
            string strNumber = Console.ReadLine();
            int finalNum = int.Parse(strNumber);

            Console.WriteLine();
            int firstNum = 0;
            int secondNum = 1;
            

            
            while (secondNum < finalNum - firstNum)
            {
                int result = firstNum;
                firstNum = secondNum;
                secondNum = result += firstNum; 

                
                  

                Console.WriteLine(result);
            }
             
                     
                       
            Console.ReadLine();
        }
    }
}
