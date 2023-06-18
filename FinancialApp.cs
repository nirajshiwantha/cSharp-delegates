using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegateDemo
{
    public class Account
    {
        public decimal Balance { get; set; }
        public string AccountType { get; set; }

        // Single Delegate
        public delegate decimal CalculateFeesOrInterest(decimal balance);
        public CalculateFeesOrInterest Calculate;

        // Multicast Delegate
        public delegate void TransactionCompleteHandler(string accountType, decimal balanceChange);
        public TransactionCompleteHandler OnTransactionComplete;

        public void ProcessTransaction(decimal amount)
        {
            // Perform transaction logic here

            // Calculate fees or interest based on the account type
            decimal feesOrInterest = Calculate(Balance);

            // Update the balance with fees or interest
            Balance += feesOrInterest;

            // Invoke the transaction complete event
            OnTransactionComplete?.Invoke(AccountType, feesOrInterest);
        }
    }

    public class Program
    {
        public static decimal CalculateSavingsAccountInterest(decimal balance)
        {
            // Calculation logic for savings account interest
            decimal interest = balance * 0.05m;
            return interest;
        }

        public static decimal CalculateCheckingAccountFees(decimal balance)
        {
            // Calculation logic for checking account fees
            decimal fees = balance * 0.01m;
            return -fees; // Return negative value for fees
        }

        static void Main(string[] args)
        {
            Account savingsAccount = new Account
            {
                Balance = 1000,
                AccountType = "Savings",
                Calculate = CalculateSavingsAccountInterest
            };

            Account checkingAccount = new Account
            {
                Balance = 500,
                AccountType = "Checking",
                Calculate = CalculateCheckingAccountFees
            };

            // Anonymous Delegate
            savingsAccount.OnTransactionComplete += delegate (string accountType, decimal balanceChange)
            {
                Console.WriteLine($"Transaction completed for {accountType}. Balance changed by: {balanceChange}");
            };

            // Multicast Delegate
            checkingAccount.OnTransactionComplete += CheckingAccountTransactionComplete;
            checkingAccount.OnTransactionComplete += NotifyTransactionComplete;

            savingsAccount.ProcessTransaction(200);
            checkingAccount.ProcessTransaction(50);

            Console.WriteLine($"Savings Account Balance: {savingsAccount.Balance}");
            Console.WriteLine($"Checking Account Balance: {checkingAccount.Balance}");
        }

        static void CheckingAccountTransactionComplete(string accountType, decimal balanceChange)
        {
            Console.WriteLine($"Checking account transaction completed. Balance changed by: {balanceChange}");
        }

        static void NotifyTransactionComplete(string accountType, decimal balanceChange)
        {
            Console.WriteLine($"Transaction complete event received for {accountType}. Balance changed by: {balanceChange}");
        }
    }
}
