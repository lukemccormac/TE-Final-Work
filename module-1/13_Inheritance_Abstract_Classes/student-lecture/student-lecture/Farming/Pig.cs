using System;
using System.Collections.Generic;
using System.Text;

namespace student_lecture
{
    public class Pig
    {
        /// <summary>
        /// Creates a new horse.
        /// </summary>
        /// <param name="name">The name which the pig goes by.</param>
        public Pig()
        {
            Name = "PIG";
        }

        public string Name { get; }

        /// <summary>
        /// The single noise the pig makes.
        /// </summary>
        /// <returns></returns>
        public string MakeSoundOnce()
        {
            return "OINK";
        }

        /// <summary>
        /// The double noise the pig makes.
        /// </summary>
        /// <returns></returns>
        public string MakeSoundTwice()
        {
            return "OINK OINK";
        }
    }
}
