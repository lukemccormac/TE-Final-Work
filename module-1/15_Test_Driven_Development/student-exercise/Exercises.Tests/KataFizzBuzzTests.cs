using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercises.Tests
{
    [TestClass()]
    public class KataFizzBuzzTests
    {
        KataFizzBuzz testClass;

        [TestInitialize]
        public void Initialize()
        {
            testClass = new KataFizzBuzz();
        }

        [TestMethod]
        public void Result_should_be_FizzBuzz_when_number_is_divisible_by_3_and_5_or_contains_a_3_and_5()
        {
            string result = testClass.FizzBuzz(15);
            Assert.AreEqual("FizzBuzz", result);

            result = testClass.FizzBuzz(53);
            Assert.AreEqual("FizzBuzz", result); 
        }
        [TestMethod]
        public void Result_should_be_Fizz_when_number_is_divided_by_3_or_contains_3()
        {
            string result = testClass.FizzBuzz(9);
            Assert.AreEqual("Fizz", result);

            result = testClass.FizzBuzz(12);
            Assert.AreEqual("Fizz", result);

            result = testClass.FizzBuzz(13);
            Assert.AreEqual("Fizz", result); 

        }
        [TestMethod]
        public void Result_should_be_Buzz_when_number_is_divided_by_5_or_conatains_5()
        {
            string result = testClass.FizzBuzz(20);
            Assert.AreEqual("Buzz", result);
            result = testClass.FizzBuzz(10);
            Assert.AreEqual("Buzz", result);

            result = testClass.FizzBuzz(5);
            Assert.AreEqual("Buzz", result);

            result = testClass.FizzBuzz(56);
            Assert.AreEqual("Buzz", result);


        }
        [TestMethod]
        public void Result_should_be_int_when_number_is_neither()
        {
            string result = testClass.FizzBuzz(22);
            Assert.AreEqual("22", result);
            result = testClass.FizzBuzz(19);
            Assert.AreEqual("19", result); 
        }
    }
}
