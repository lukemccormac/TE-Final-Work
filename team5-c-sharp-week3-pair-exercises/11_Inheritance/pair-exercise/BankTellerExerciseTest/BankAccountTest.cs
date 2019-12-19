using Microsoft.VisualStudio.TestTools.UnitTesting;
using BankTellerExercise; 

namespace BankTellerExerciseTest
{
    [TestClass]
    public class BankAccountTest
    {
        [TestMethod]
        public void DepositTest()
        {
            BankAccount testAcccount = new BankAccount();
            decimal result = testAcccount.Deposit(50);
            Assert.AreEqual(50, result); 
        }

        [TestMethod]
        public void WithdrawTest()
        {
            BankAccount testAcccount = new BankAccount();
            decimal result = testAcccount.Withdraw(50);
            Assert.AreEqual(-50, result); 
        }

        [TestMethod]
        public void TransferTest()
        {
            BankAccount testAccount = new BankAccount();
            BankAccount testAccount2 = new BankAccount(); 
            testAccount.Deposit(50);
            testAccount.Transfer(testAccount2, 25);
            Assert.AreEqual(25, testAccount.Balance);
            Assert.AreEqual(25, testAccount2.Balance);
        }
    }
}