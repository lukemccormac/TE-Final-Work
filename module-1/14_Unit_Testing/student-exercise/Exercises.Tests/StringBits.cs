using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Exercises.Tests
{
    [TestClass]
    public class StringBitsTest
    {
        [TestMethod]
        public void GetBitsTest()
        {
            //GetBits("Hello") → "Hlo"
            //GetBits("Hi") → "H"
            //GetBits("Heeololeo") → "Hello"

            StringBits newTest = new StringBits();
            string result = newTest.GetBits("Hello");
            Assert.AreEqual("Hlo", result);

            result = newTest.GetBits("Hi");
            Assert.AreEqual("H", result);

            result = newTest.GetBits("");
            Assert.AreEqual("", result); 
        }
    }
}