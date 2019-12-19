using System;
using System.Collections.Generic;
using System.Text;

namespace Lecture.Farming
{
    public class Pig : FarmAnimal
    {
        /// <summary>
        /// Creates a new horse.
        /// </summary>
        /// <param name="name">The name which the horse goes by.</param>
        public Pig() : base("PIG")
        {
        }

        /// <summary>
        /// The single noise the horse makes.
        /// </summary>
        /// <returns></returns>
        public override string MakeSoundOnce()
        {
            return "OINK";
        }

        /// <summary>
        /// The double noise the horse makes.
        /// </summary>
        /// <returns></returns>
        public override string MakeSoundTwice()
        {
            return "OINK OINK";
        }
    }
}
