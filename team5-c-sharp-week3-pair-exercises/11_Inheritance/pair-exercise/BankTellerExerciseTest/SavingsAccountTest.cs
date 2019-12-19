using Microsoft.VisualStudio.TestTools.UnitTesting;
using BankTellerExercise;

namespace BankTellerExerciseTest
{
    [TestClass]
    public class SavingsAccountTest
    {
        [TestMethod]
        public void SavingsAccountWithdraw()
        {
            SavingsAccount testAccount = new SavingsAccount();
            testAccount.Deposit(200);
            decimal result = testAccount.Withdraw(100);
            Assert.AreEqual(100, result);

            result = testAccount.Withdraw(50);
            Assert.AreEqual(48, result);

            result = testAccount.Withdraw(100);
            Assert.AreEqual(48, result); 
        }
    }
}