using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Exercises.Tests
{
    [TestClass]
    public class MaxEnd3test
    {
        [TestMethod]
        public void MakeArrayTest()
        {
            // MakeArray([1, 2, 3]) → [3, 3, 3]
            // MakeArray([11, 5, 9]) → [11, 11, 11]
            // MakeArray([2, 11, 3]) → [3, 3, 3]
            MaxEnd3 newTest = new MaxEnd3();
            int[] result = newTest.MakeArray(new int[]{ 1,2,3 }); 
            CollectionAssert.AreEqual(new int[] { 3, 3, 3 }, result);

            result = newTest.MakeArray(new int[] { 2, 9, 6 });
            CollectionAssert.AreEqual(new int[] { 6, 6, 6 }, result);




        }
    }
}
