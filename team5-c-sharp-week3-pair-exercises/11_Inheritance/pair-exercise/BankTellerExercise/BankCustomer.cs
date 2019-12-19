using System;
using System.Collections.Generic;
using System.Text;

namespace BankTellerExercise
{
    public class BankCustomer
    {
        private List<BankAccount> AccountsList = new List<BankAccount>();
        public string Name { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public bool IsVIP
        {
            get
            {
                decimal accountBalance = 0;
                for (int i = 0; i < AccountsList.Count; i++)
                {
                    
                   accountBalance = accountBalance +  AccountsList[i].Balance;
                }

                if (accountBalance >= 25000)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public BankAccount[] AccountsArray
        {
            get
            {
                return AccountsList.ToArray();
            }
        }

        public void AddAccount(BankAccount newAccount)
        {
            AccountsList.Add(newAccount);
        }
    }
}
