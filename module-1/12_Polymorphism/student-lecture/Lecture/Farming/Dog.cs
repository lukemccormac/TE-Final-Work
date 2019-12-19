using System;
using System.Collections.Generic;
using System.Text;

namespace Lecture.Farming
{
    public class Dog : FarmAnimal
    {
        /// <summary>
        /// Creates a new Dog.
        /// </summary>
        /// <param name="name">The name which the horse goes by.</param>
        public Dog() : base("HORSE")
        {
        }

        /// <summary>
        /// The single noise the Dog makes.
        /// </summary>
        /// <returns></returns>
        public override string MakeSoundOnce()
        {
            return "WOOF";
        }

        /// <summary>
        /// The double noise the Dog makes.
        /// </summary>
        /// <returns></returns>
        public override string MakeSoundTwice()
        {
            return "WOOF WOOF";
        }
    }
}
