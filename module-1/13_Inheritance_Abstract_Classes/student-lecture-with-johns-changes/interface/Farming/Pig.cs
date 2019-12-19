using System;
using System.Collections.Generic;
using System.Text;

namespace Lecture.Farming
{
    public class Pig : IFarmAnimal
    {
        /// <summary>
        /// Creates a new horse.
        /// </summary>
        /// <param name="name">The name which the horse goes by.</param>
        public Pig()
        {
            Name = "PIG";
        }

        public string Name { get; }

        /// <summary>
        /// The single noise the horse makes.
        /// </summary>
        /// <returns></returns>
        public string MakeSoundOnce()
        {
            return "OINK";
        }

        /// <summary>
        /// The double noise the horse makes.
        /// </summary>
        /// <returns></returns>
        public string MakeSoundTwice()
        {
            return "OINK OINK";
        }
    }
}
