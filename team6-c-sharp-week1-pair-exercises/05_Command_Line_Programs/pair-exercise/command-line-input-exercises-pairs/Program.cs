using System;

namespace command_line_input_exercises_pairs
{
    class Program
    {
        /*
        Write a command line program which prompts the user for the total bill, and the amount tendered. It should then display the change required.

        C:\Users> MakeChange

        Please enter the amount of the bill: 23.65
        Please enter the amount tendered: 100.00
        The change required is 76.35
        */
        static void Main(string[] args)
        {
            double amtBill = 0.0;
            double amtPaid = 0.0;
            
            Console.Write("Please enter the amount of the bill: ");
            string strBill = Console.ReadLine();
            amtBill = double.Parse(strBill);

            Console.Write("Please enter the amount tendered: ");
            string strPaid = Console.ReadLine();
            amtPaid = double.Parse(strPaid);

            if (amtPaid > amtBill)
            {   // change
                Console.WriteLine("Your change is: " + (amtPaid - amtBill));
            } else
            {   // still short
                Console.WriteLine("Dude, you are short by: " + (amtBill - amtPaid));
            }




            Console.ReadLine();
        }
    }
}
