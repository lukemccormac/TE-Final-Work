using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Exercises.Tests
{
    [TestClass]
    public class Lucky13Test
    {
        [TestMethod]
        public void GetLuckyTest()
        {

            //GetLucky([0, 2, 4]) → true
            //GetLucky([1, 2, 3]) → false
            //GetLucky([1, 2, 4]) → false
            Lucky13 newTest = new Lucky13();
            bool result = newTest.GetLucky(new int[] { 1, 2, 3, 5 });
            Assert.IsFalse(result);

            result = newTest.GetLucky(new int[] { 8, 2, 7, 5 });
            Assert.IsTrue(result);

            result = newTest.GetLucky(new int[] { 7, 2, 3, 5 });
            Assert.IsFalse(result);

            result = newTest.GetLucky(new int[] { });
            Assert.IsTrue(result); 
        }
    }
}
