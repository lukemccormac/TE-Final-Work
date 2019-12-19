using System;

namespace student_lecture
{
    class Program
    {
        static void Main(string[] args)
        {
            //
            // OLD MACDONALD
            //
            Console.WriteLine("Old MacDonald had a farm ee ay ee ay oh");

            // Let's try singing about a Farm Animal
            Horse animal = new Horse();

            // Can we swap out any animal in place here?

            Console.WriteLine("And on his farm there was a " + animal.Name + " ee ay ee ay oh");
            Console.WriteLine("With a " + animal.MakeSoundTwice() + " here and a " + animal.MakeSoundTwice() + " there");
            Console.WriteLine("Here a " + animal.MakeSoundOnce() + ", there a " + animal.MakeSoundOnce() + " everywhere a " + animal.MakeSoundTwice());
            Console.WriteLine("Old Macdonald had a farm, ee ay ee ay oh");
            Console.WriteLine();

            // Let's try singing about a Farm Animal
             Pig animal2 = new Pig();

            // Can we swap out any animal in place here?

            Console.WriteLine("And on his farm there was a " + animal2.Name + " ee ay ee ay oh");
            Console.WriteLine("With a " + animal2.MakeSoundTwice() + " here and a " + animal2.MakeSoundTwice() + " there");
            Console.WriteLine("Here a " + animal2.MakeSoundOnce() + ", there a " + animal2.MakeSoundOnce() + " everywhere a " + animal2.MakeSoundTwice());
            Console.WriteLine("Old Macdonald had a farm, ee ay ee ay oh");
            Console.WriteLine();




            // What if we wanted to sing about other things on the farm that were 
            // singable but not farm animals?
            // Can it be done? 

            Console.ReadLine();
        }
    }
}
