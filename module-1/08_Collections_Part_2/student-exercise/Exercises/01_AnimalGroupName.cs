﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercises
{
    public partial class Exercises
    {
        /*
         * Given the name of an animal, return the name of a group of that animal
         * (e.g. "Elephant" -> "Herd", "Rhino" - "Crash").
         *
         * The animal name should be case insensitive so "entlepha", "Elephant", and
         * "ELEPHANT" should all return "herd".
         *
         * If the name of the animal is not found, null, or empty, return "unknown".
         *
         * Rhino -> Crash
         * Giraffe -> Tower
         * Elephant -> Herd
         * Lion -> Pride
         * Crow -> Murder
         * Pigeon -> Kit
         * Flamingo -> Pat
         * Deer -> Herd
         * Dog -> Pack
         * Crocodile -> Float
         *
         * AnimalGroupName("giraffe") → "Tower"
         * AnimalGroupName("") -> "unknown"
         * AnimalGroupName("walrus") -> "unknown"
         * AnimalGroupName("Rhino") -> "Crash"
         * AnimalGroupName("rhino") -> "Crash"
         * AnimalGroupName("elephants") -> "unknown"
         *
         */
        public string AnimalGroupName(string animalName)
        {
       
            Dictionary<string, string> animalNames = new Dictionary<string, string>();
            animalNames["giraffe"] = "Tower";
            animalNames["rhino"] = "Crash";
            animalNames["elephant"] = "Herd";
            animalNames["lion"] = "Pride";
            animalNames["crow"] = "Murder";
            animalNames["pigeon"] = "Kit";
            animalNames["flamingo"] = "Pat";
            animalNames["deer"] = "Herd";
            animalNames["dog"] = "Pack";
            animalNames["crocodile"] = "Float";
            animalNames[""] = "unknown";

            if (animalNames.ContainsKey(animalName.ToLower()))
            {
                return animalNames[animalName.ToLower()];
            }
            else
            {
                return "unknown";
            }
        }
    }
}
