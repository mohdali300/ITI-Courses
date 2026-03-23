using System;

namespace Lab4
{
    public abstract class Account : IPrintable, ITransactable
    {
        private double _balance;
        public string AccountNumber { get; }
        public string OwnerName { get; set; }

        public double Balance => _balance;

        protected Account(string ownerName, double initialBalance = 0)
        {
            AccountNumber = $"ACCT-{Guid.NewGuid():N}".ToUpperInvariant();
            OwnerName = ownerName ?? "Unknown";
            _balance = Math.Max(0.0, initialBalance);
        }

        protected void AdjustBalance(double delta)
        {
            _balance += delta;
        }

        public virtual void Deposit(double amount)
        {
            if (amount <= 0)
                throw new ArgumentOutOfRangeException(nameof(amount), "Deposit amount must be positive.");

            AdjustBalance(amount);
            Console.WriteLine($"{AccountNumber}: Deposited {amount:C}. New balance: {_balance:C}");
        }

        public virtual bool Withdraw(double amount)
        {
            if (amount <= 0)
                throw new ArgumentOutOfRangeException(nameof(amount), "Withdraw amount must be positive.");

            if (amount > _balance)
            {
                Console.WriteLine($"{AccountNumber}: Withdrawal of {amount:C} failed — insufficient funds.");
                return false;
            }

            AdjustBalance(-amount);
            Console.WriteLine($"{AccountNumber}: Withdrew {amount:C}. New balance: {_balance:C}");
            return true;
        }

        public abstract double CalculateInterest();

        public virtual void ApplyInterest()
        {
            double interest = CalculateInterest();
            if (interest <= 0)
            {
                Console.WriteLine($"{AccountNumber}: No interest applied.");
                return;
            }

            AdjustBalance(interest);
            Console.WriteLine($"{AccountNumber}: Applied interest {interest:C}. New balance: {_balance:C}");
        }

        public virtual void PrintDetails()
        {
            Console.WriteLine("\n");
            Console.WriteLine($"Account Number : {AccountNumber}");
            Console.WriteLine($"Owner          : {OwnerName}");
            Console.WriteLine($"Balance        : {Balance:C}");
            Console.WriteLine($"Account Type   : {GetType().Name}");
        }
    }
}