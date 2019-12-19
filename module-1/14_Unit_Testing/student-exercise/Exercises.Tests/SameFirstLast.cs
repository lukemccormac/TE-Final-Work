using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Exercises.Tests
{
    [TestClass]
    public class SameFirstLastTest
    {
        [TestMethod]
        public void IsItTheSameTest()
        {
            
            //IsItTheSame([1, 2, 3]) → false
            //IsItTheSame([1, 2, 3, 1]) → true
            //IsItTheSame([1, 2, 1]) → true
            SameFirstLast newTest = new SameFirstLast();
            bool result = newTest.IsItTheSame(new int[] { 1, 2, 3, 5 });
            Assert.IsFalse(result);

            result = newTest.IsItTheSame(new int[] { 1, 2, 3, 1 });
            Assert.IsTrue(result);

            result = newTest.IsItTheSame(new int[] { });
            Assert.IsFalse(result);

            result = newTest.IsItTheSame(new int[] { 1 });
            Assert.IsTrue(result); 
        }
    }
}