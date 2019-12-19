using System;

namespace BankTellerExercise
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            BankAccount checkingAccount = new CheckingAccount();
            BankAccount savingsAccount = new SavingsAccount();

            decimal amountToDeposit = 20000.00M;
            decimal newBalance = checkingAccount.Deposit(amountToDeposit);

            decimal amountToTransfer = 500.00M;
            checkingAccount.Transfer(savingsAccount, amountToTransfer);

            Console.WriteLine(checkingAccount.Balance);
            Console.WriteLine(savingsAccount.Balance);

            checkingAccount.Withdraw(175);
            Console.WriteLine(checkingAccount.Balance);

            savingsAccount.Withdraw(100);
            Console.WriteLine(savingsAccount.Balance);

            BankCustomer jayGatsby = new BankCustomer();

            jayGatsby.AddAccount(checkingAccount);
            jayGatsby.AddAccount(savingsAccount);

            Console.WriteLine($"Jay Gatsby has {jayGatsby.AccountsArray.Length} accounts.");

            Console.WriteLine(jayGatsby.IsVIP);

            Console.ReadLine();
        }
    }
}
