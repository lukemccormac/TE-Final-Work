using Microsoft.VisualStudio.TestTools.UnitTesting;
using BankTellerExercise;

namespace BankTellerExerciseTest
{
    [TestClass]
    public class BankCustomerTest
    {
        [TestMethod]
        public void VipTest()
        {
            BankCustomer testCustomer = new BankCustomer();
            BankAccount testAccount = new BankAccount();
            testCustomer.AddAccount(testAccount);
            testAccount.Deposit(30000);
            Assert.IsTrue(testCustomer.IsVIP);


           testAccount.Withdraw(10000);
           Assert.IsFalse(testCustomer.IsVIP); 
            
        }

        [TestMethod]
        public void ArrayTest()
        {
            BankCustomer testCustomer = new BankCustomer();
            BankAccount testAccount = new BankAccount();
            BankAccount testAccount2 = new CheckingAccount();

            testCustomer.AddAccount(testAccount);

            CollectionAssert.AreEqual(new BankAccount[] { testAccount }, testCustomer.AccountsArray);

            testCustomer.AddAccount(testAccount2);
            CollectionAssert.AreEqual(new BankAccount[] { testAccount, testAccount2 }, testCustomer.AccountsArray);
        }
    }
}
