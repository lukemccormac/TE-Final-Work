using System;
using System.Collections.Generic;
using System.Text;

namespace Lecture.Farming
{
    public class Dog : FarmAnimal
    {
        /// <summary>
        /// Creates a new dog.
        /// </summary>
        /// <param name="name">The name which the horse goes by.</param>
        public Dog() : base("DOG")
        {
        }

        /// <summary>
        /// The single noise the dog makes.
        /// </summary>
        /// <returns></returns>
        public override string MakeSoundOnce()
        {
            return "WOOF";
        }

        /// <summary>
        /// The double noise the dog makes.
        /// </summary>
        /// <returns></returns>
        public override string MakeSoundTwice()
        {
            return "WOOF WOOF";
        }
    }
}
