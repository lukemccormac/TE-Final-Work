using System;
using System.Collections.Generic;
using System.Text;

namespace student_lecture
{
    public class Horse
    {
        /// <summary>
        /// Creates a new horse.
        /// </summary>
        /// <param name="name">The name which the horse goes by.</param>
        public Horse() 
        {
            Name = "HORSE";
        }

        public string Name { get; }

        /// <summary>
        /// The single noise the horse makes.
        /// </summary>
        /// <returns></returns>
        public  string MakeSoundOnce()
        {
            return "NEIGH";
        }

        /// <summary>
        /// The double noise the horse makes.
        /// </summary>
        /// <returns></returns>
        public  string MakeSoundTwice()
        {
            return "NEIGH NEIGH";
        }
    }
}
