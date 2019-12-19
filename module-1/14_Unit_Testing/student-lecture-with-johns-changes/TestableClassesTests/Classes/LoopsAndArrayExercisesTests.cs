using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestableClasses.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestableClasses.Classes.Tests
{
    [TestClass]
    public class LoopsAndArrayExercisesTests
    {
        //CollectionAssert
        //.AllItemsAreNotNull() - Looks at each item in actual collection for not null
        //.AllItemsAreUnique() - Checks for uniqueness among actual collection
        //.AreEqual() - Checks to see if two collections are equal (same order and quantity)
        //.AreEquilavent() - Checks to see if two collections have same element in same quantity, any order
        //.AreNotEqual() - Opposite of AreEqual
        //.AreNotEquilavent() - Opposite or AreEqualivent
        //.Contains() - Checks to see if collection contains a value/object


        //middleWay([1, 2, 3], [4, 5, 6]) → [2, 5]
        //middleWay([7, 7, 7], [3, 8, 0]) → [7, 8]
        //middleWay([5, 2, 9], [1, 4, 5]) → [2, 4]

        [TestMethod]
        public void MiddleWayTest()
        {
            LoopsAndArrayExercises testClass = new LoopsAndArrayExercises();

            int[] result = testClass.MiddleWay(new int[] { 1, 2, 3 }, new int[] { 4, 5, 6 });

            CollectionAssert.AreEquivalent(new int[] { 2, 5 }, result);
        }
    }
}