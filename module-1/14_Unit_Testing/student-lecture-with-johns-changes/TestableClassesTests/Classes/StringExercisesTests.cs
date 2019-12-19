using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestableClasses.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace TestableClasses.Classes.Tests
{
    [TestClass()]
    public class StringExercisesTests
    {
        //Assert
        //.AreEqual() - compares expected and actual value for equality
        //.AreSame() - verifies two object variables refer to same object
        //.AreNotSame() - verifies two object variables refer to different objects
        //.Fail() - fails without checking conditions
        //.IsFalse()
        //.IsTrue()
        //.IsNotNull()
        //.IsNull()


        // makeAbba("Hi", "Bye") → "HiByeByeHi"	
        // makeAbba("Yo", "Alice") → "YoAliceAliceYo"	
        // makeAbba("What", "Up") → "WhatUpUpWhat"	
        [TestMethod]
        public void MakeAbbaTest()
        {
            StringExercises stringExercises = new StringExercises();

            string result = stringExercises.MakeAbba("Hi", "Bye");

            Assert.AreEqual("HiByeByeHi", result);


            result = stringExercises.MakeAbba("Yo", "Alice");

            Assert.AreEqual("YoAliceAliceYo", result);


            result = stringExercises.MakeAbba("What", "Up");

            Assert.AreEqual("WhatUpUpWhat", result);

        }

        //makeOutWord("<<>>", "Yay") → "<<Yay>>"	
        //makeOutWord("<<>>", "WooHoo") → "<<WooHoo>>"	
        //makeOutWord("[[]]", "word") → "[[word]]"	

        [TestMethod]
        public void MakeOutWordTest()
        {
            StringExercises testClass = new StringExercises();

            string result = testClass.MakeOutWord("<<>>", "Yay");

            Assert.AreEqual("<<Yay>>", result);
        }
        


        
    }
}