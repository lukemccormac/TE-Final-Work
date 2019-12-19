using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Exercises.Tests
{
    [TestClass]
    public class DateFashionTest
    {
        [TestMethod]
        public void GetATableTest()
        {
            //dateFashion(5, 10) → 2
            //dateFashion(5, 2) → 0
            //dateFashion(5, 5) → 1

            DateFashion fashionTest = new DateFashion();
            int result = fashionTest.GetATable(5, 10);
            Assert.AreEqual(2, result);

            result = fashionTest.GetATable(5, 2);
            Assert.AreEqual(0, result);

            result = fashionTest.GetATable(5, 5);
            Assert.AreEqual(1, result);
        }
    }
}