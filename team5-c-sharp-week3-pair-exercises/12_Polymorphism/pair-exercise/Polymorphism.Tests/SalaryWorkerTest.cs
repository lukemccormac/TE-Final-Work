using Microsoft.VisualStudio.TestTools.UnitTesting;
using EmployeePayroll.CLasses;

namespace Polymorphism.Tests
{
    [TestClass]
    public class SalaryWorkerTest
    {
        [TestMethod]
        public void CollectWeeklyPayTest()
        {
            SalaryWorker johnDoe = new SalaryWorker(52000, "John", "Doe");
            double pay = johnDoe.CalculateWeeklyPay(50);

            Assert.AreEqual(1000, pay);

            pay = johnDoe.CalculateWeeklyPay(0);

            Assert.AreEqual(1000, pay);

        }
    }
}
