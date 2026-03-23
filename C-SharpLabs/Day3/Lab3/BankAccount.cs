using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3
{
    public class BankAccount
    {
        int accountNumber;
        double balance;
        string ownerName;

        public BankAccount(int accountNumber, string ownerName, double initialBalance)
        {
            this.accountNumber = accountNumber;
            this.ownerName = ownerName;
            this.balance = initialBalance;
        }

        public void Deposit(double amount)
        {
            if (amount > 0)
                balance += amount;
        }

        public bool Withdraw(double amount)
        {
            if (amount > 0 && amount <= balance)
            {
                balance -= amount;
                return true;
            }
            return false;
        }

        public bool Transfer(BankAccount target, double amount)
        {
            if (Withdraw(amount))
            {
                target.Deposit(amount);
                return true;
            }
            return false;
        }

        public double GetBalance()
        {
            return balance;
        }

        public void DisplayInfo(BankAccount acc)
        {
            Console.WriteLine($"Account: {acc.accountNumber}, Owner: {acc.ownerName}, Balance: ${acc.balance:N2}");
        }
    }
}
