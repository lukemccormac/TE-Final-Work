using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Exercises.Tests
{
    [TestClass]
    public class Less20Test
    {
        [TestMethod]
        public void IsLessThanMultipleOf20Test()
        {
            //less20(18) → true
            //less20(19) → true
            //less20(20) → false
            Less20 newTest = new Less20();
            Assert.IsFalse(newTest.IsLessThanMultipleOf20(37)); 
            Assert.IsTrue(newTest.IsLessThanMultipleOf20(38));
            Assert.IsTrue(newTest.IsLessThanMultipleOf20(39)); 
        }
    }
}
