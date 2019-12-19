using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TDD.Classes;

namespace TDD.Tests.Classes
{
    
    [TestClass]
    public class KataRomanNumeralTests
    {
        KataRomanNumeral testClass;

        [TestInitialize]
        public void Initialize()
        {
            testClass = new KataRomanNumeral(); 
        }

       [TestMethod]
       public void Test_M_for_thousand()
        {

            string result = testClass.ConvertToRomanNumeral(1000);
            Assert.AreEqual("M", result);

            result = testClass.ConvertToRomanNumeral(2000);
            Assert.AreEqual("MM", result);

            result = testClass.ConvertToRomanNumeral(3000);
            Assert.AreEqual("MMM", result);

            result = testClass.ConvertToRomanNumeral(4000);
            Assert.AreEqual("MMMM", result);
        }
        [TestMethod]
        public void Test_D_for_fivehundred()
        {
            string result = testClass.ConvertToRomanNumeral(500);
            Assert.AreEqual("D", result);

            result = testClass.ConvertToRomanNumeral(1500);
            Assert.AreEqual("MD", result);
        }

        [TestMethod]
        public void Test_C_for_hundred()
        {
            string result = testClass.ConvertToRomanNumeral(100);
            Assert.AreEqual("C", result);

            result = testClass.ConvertToRomanNumeral(200);
            Assert.AreEqual("CC", result);

            result = testClass.ConvertToRomanNumeral(1200);
            Assert.AreEqual("MCC", result);
        }

        [TestMethod]
        public void Test_L_for_fifty()
        {
            string result = testClass.ConvertToRomanNumeral(50);
            Assert.AreEqual("L", result);

            result = testClass.ConvertToRomanNumeral(150);
            Assert.AreEqual("CL", result);

            result = testClass.ConvertToRomanNumeral(1250);
            Assert.AreEqual("MCCL", result);
        }
        [TestMethod]
        public void Test_X_for_ten()
        {
            string result = testClass.ConvertToRomanNumeral(10);
            Assert.AreEqual("X", result);

            result = testClass.ConvertToRomanNumeral(60);
            Assert.AreEqual("LX", result);

            result = testClass.ConvertToRomanNumeral(1260);
            Assert.AreEqual("MCCLX", result);
        }

        [TestMethod]
        public void Test_V_for_five()
        {
            string result = testClass.ConvertToRomanNumeral(5);
            Assert.AreEqual("V", result);

            result = testClass.ConvertToRomanNumeral(15);
            Assert.AreEqual("XV", result);
        }

        [TestMethod]
        public void Test_I_for_one()
        {
            string result = testClass.ConvertToRomanNumeral(1);
            Assert.AreEqual("I", result);

            result = testClass.ConvertToRomanNumeral(2);
            Assert.AreEqual("II", result); 

            result = testClass.ConvertToRomanNumeral(6);
            Assert.AreEqual("VI", result); 
        }

        [TestMethod ]
        public void ContractedForms()
        {
            string result = testClass.ConvertToRomanNumeral(4);
            Assert.AreEqual("IV", result);

            result = testClass.ConvertToRomanNumeral(400);
            Assert.AreEqual("CD", result);
        }
            
    }
}
