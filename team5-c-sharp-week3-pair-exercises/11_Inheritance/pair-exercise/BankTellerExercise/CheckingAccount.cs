using System;
using System.Collections.Generic;
using System.Text;

namespace BankTellerExercise
{
    public class CheckingAccount : BankAccount
    {
        public override decimal Withdraw(decimal amountToWithdraw)
        {
            if (Balance - amountToWithdraw - 10 < -100)
            {
                return Balance;
            }
            else if (Balance-amountToWithdraw < 0)
            {
                amountToWithdraw = amountToWithdraw +10;

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
