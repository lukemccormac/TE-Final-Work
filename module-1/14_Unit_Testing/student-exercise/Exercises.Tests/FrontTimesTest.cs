using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Exercises.Tests
{
    [TestClass]
    public class FrontTimesTest
    {
        [TestMethod]
        public void GenerateStringTest()
        {
            //frontTimes("Chocolate", 2) → "ChoCho"
            //frontTimes("Chocolate", 3) → "ChoChoCho"
            //frontTimes("Abc", 3) → "AbcAbcAbc"

            FrontTimes frontTest = new FrontTimes();
            string result = frontTest.GenerateString("Chocolate", 2);
            Assert.AreEqual("ChoCho", result);

            string result1 = frontTest.GenerateString("Abc", 3);
            Assert.AreEqual("AbcAbcAbc", result1);

            result = frontTest.GenerateString("", 3);
            Assert.AreEqual("", result); 
        }
    }
}
