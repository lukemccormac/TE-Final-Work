using System;

namespace MartianWeight
{
    /*
    In case you've ever pondered how much you weight on Mars, here's the calculation:
    Wm = We* 0.378
    where 'Wm' is the weight on Mars, and 'We' is the weight on Earth

    Write a command line program which accepts a series of Earth weights from the user  
    and displays each Earth weight as itself, and its Martian equivalent.


    C:\Users> MartianWeight  
    Enter a series of Earth weights (space-separated): 98 235 185

    98 lbs.on Earth, is 37 lbs.on Mars.
    235 lbs.on Earth, is 88 lbs.on Mars.
    185 lbs.on Earth, is 69 lbs.on Mars. 
    */
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter a series of Earth weights (space-separated): ");
            string strInput = Console.ReadLine();
            Console.WriteLine();

            string[] strWeights = strInput.Split(' ');
            double[] eWeights = new double[strWeights.Length];
            double[] mWeights = new double[strWeights.Length];
            for (int i = 0; i < strWeights.Length; i++)
            {
                eWeights[i] = double.Parse(strWeights[i]);
                mWeights[i] = eWeights[i] * 0.378;
                Console.WriteLine(eWeights[i] + " lbs.on Earth, is " + mWeights[i] + " lbs. on Mars.");
            }


            Console.ReadLine();
        }
    }
}
