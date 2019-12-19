using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Exercises.Tests
{
    [TestClass]
    public class NonStartTest
    {
        [TestMethod]
        public void GetPartialStringTest()
        {
            //GetPartialString("Hello", "There") → "ellohere"
            //GetPartialString("java", "code") → "avaode"
            //GetPartialString("shotl", "java") → "hotlava"

            NonStart newTest = new NonStart();
            string result = newTest.GetPartialString("Hello", "There");
            Assert.AreEqual("ellohere", result);

            result = newTest.GetPartialString("java", "code");
            Assert.AreEqual("avaode", result);

            result = newTest.GetPartialString("", "code");
            Assert.AreEqual("ode", result);

            result = newTest.GetPartialString("hello", "");
            Assert.AreEqual("ello", result);


        }
    }
}
