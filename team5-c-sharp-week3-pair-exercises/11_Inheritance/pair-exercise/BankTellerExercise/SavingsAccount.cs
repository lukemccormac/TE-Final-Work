using System;
using System.Collections.Generic;
using System.Text;

namespace BankTellerExercise
{
    public class SavingsAccount : BankAccount
    {
        public override decimal Withdraw(decimal amountToWithdraw)
        {
            if (Balance - amountToWithdraw < 0)
            {
                return Balance;
            }
            else if (Balance < 150)
            {
                amountToWithdraw = amountToWithdraw + 2;
                base.Withdraw(amountToWithdraw);
                return Balance;
            }
            else
            {
                base.Withdraw(amountToWithdraw);
                return Balance;
            }
        }
    }
}
