using Microsoft.VisualStudio.TestTools.UnitTesting;
using BankTellerExercise;

namespace BankTellerExerciseTest
{
    [TestClass]
    public class CheckingAccountTest
    {
        [TestMethod]
        public void CheckingAccountWithdaw()
        {
            CheckingAccount testAccount = new CheckingAccount();
            testAccount.Deposit(10); 
            decimal result = testAccount.Withdraw(50);
            Assert.AreEqual(-50, result);
            result = testAccount.Withdraw(100);
            Assert.AreEqual(-50, result);

            testAccount.Deposit(400);
            result = testAccount.Withdraw(50);
            Assert.AreEqual(300, result); 



        }
    }
}