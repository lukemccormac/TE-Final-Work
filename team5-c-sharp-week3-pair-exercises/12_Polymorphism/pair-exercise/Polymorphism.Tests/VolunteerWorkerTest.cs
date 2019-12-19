using Microsoft.VisualStudio.TestTools.UnitTesting;
using EmployeePayroll.CLasses;

namespace Polymorphism.Tests
{
    [TestClass]
    public class VolunteerWorkerTest
    {
        [TestMethod]
        public void CollectWeeklyPayTest()
        {
            VolunteerWorker johnDoe = new VolunteerWorker("John", "Doe");
            double pay = johnDoe.CalculateWeeklyPay(50);

            Assert.AreEqual(0, pay);

            pay = johnDoe.CalculateWeeklyPay(0);

            Assert.AreEqual(0, pay);

        }
    }
}
