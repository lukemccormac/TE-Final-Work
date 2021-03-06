﻿using Lecture.Farming;
using System;
using System.Collections.Generic;

namespace Lecture
{
    class Program
    {
        static void Main(string[] args)
        {
           //
            // OLD MACDONALD
            //
            Console.WriteLine("Old MacDonald had a farm ee ay ee ay oh");
            Console.WriteLine();

            List<IFarmAnimal> animals = new List<IFarmAnimal>  {  new Pig(), new Horse(), new Dog()}; 

            foreach (IFarmAnimal animal in animals)
            {
                // Let's try singing about a Farm Animal


                // Can we swap out any animal in place here?

                Console.WriteLine("And on his farm there was a " + animal.Name + " ee ay ee ay oh");
                Console.WriteLine("With a " + animal.MakeSoundTwice() + " here and a " + animal.MakeSoundTwice() + " there");
                Console.WriteLine("Here a " + animal.MakeSoundOnce() + ", there a " + animal.MakeSoundOnce() + " everywhere a " + animal.MakeSoundTwice());
                Console.WriteLine("Old Macdonald had a farm, ee ay ee ay oh");
                Console.WriteLine();

                // Let's try singing about a Farm Animal

                // What if we wanted to sing about other things on the farm that were 
                // singable but not farm animals?
                // Can it be done? 
            }
            Console.ReadLine();
        }
    }
}