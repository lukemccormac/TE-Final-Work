using Microsoft.VisualStudio.TestTools.UnitTesting;
using EmployeePayroll.CLasses;

namespace Polymorphism.Tests
{
    [TestClass]
    public class HourlyWorkerTest
    {
        [TestMethod]
        public void CollectWeeklyPayTest()
        {
            HourlyWorker johnDoe = new HourlyWorker(10, "John", "Doe");
            double pay = johnDoe.CalculateWeeklyPay(40);

            Assert.AreEqual(400, pay);

            pay = johnDoe.CalculateWeeklyPay(50);

            Assert.AreEqual(550, pay);

            pay = johnDoe.CalculateWeeklyPay(0);

            Assert.AreEqual(0, pay);

        }
    }
}
