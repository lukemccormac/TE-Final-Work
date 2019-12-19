using System;
using System.Collections.Generic;
using System.Text;

namespace Lecture.Farming
{
    public class Dog : IFarmAnimal
    {
        /// <summary>
        /// Creates a new dog.
        /// </summary>
        /// <param name="name">The name which the horse goes by.</param>
        public Dog()
        {
            this.Name = "DOG";
        }

        public string Name { get; }

        /// <summary>
        /// The single noise the dog makes.
        /// </summary>
        /// <returns></returns>
        public string MakeSoundOnce()
        {
            return "WOOF";
        }

        /// <summary>
        /// The double noise the dog makes.
        /// </summary>
        /// <returns></returns>
        public string MakeSoundTwice()
        {
            return "WOOF WOOF";
        }
    }
}
