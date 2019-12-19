using System;
using System.Collections.Generic;
using System.Text;

namespace BankTellerExercise
{
    public class BankAccount
    {
        public string AccountNumber { get; set; }
        public decimal Balance { get; private set; } = 0; 
        public decimal Deposit(decimal amountToDeposit)
        {
            Balance = Balance + amountToDeposit;
            return Balance;
        }
        public virtual decimal Withdraw(decimal amountToWithdraw)
        {
            Balance = Balance - amountToWithdraw;
            return Balance;
        }
        public void Transfer(BankAccount destinationAccount, decimal transferAmount)
        {
            Balance = Balance - transferAmount;
            destinationAccount.Balance = destinationAccount.Balance + transferAmount;
        }
    }
}
