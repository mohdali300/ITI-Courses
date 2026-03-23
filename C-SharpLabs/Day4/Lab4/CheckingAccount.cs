using System;

namespace Lab4
{
    public class CheckingAccount : Account
    {
        public double OverdraftLimit { get; }
        public int FreeTransactions { get; }
        private int _transactionCount;

        public CheckingAccount(string ownerName, double initialBalance, double overdraftLimit = 500.0, int freeTransactions = 3)
            : base(ownerName, initialBalance)
        {
            OverdraftLimit = Math.Max(0.0, overdraftLimit);
            FreeTransactions = Math.Max(0, freeTransactions);
            _transactionCount = 0;
        }

        public override double CalculateInterest() => 0.0;

        private void RegisterTransaction() => _transactionCount++;

        public override void Deposit(double amount)
        {
            base.Deposit(amount);
            RegisterTransaction();
        }

        public override bool Withdraw(double amount)
        {
            if (amount <= 0) throw new ArgumentOutOfRangeException(nameof(amount));

            double projected = Balance - amount;
            if (projected < -OverdraftLimit)
            {
                Console.WriteLine($"{AccountNumber}: Withdrawal denied — overdraft limit of {OverdraftLimit:C} exceeded.");
                return false;
            }

            if (amount <= Balance)
            {
                RegisterTransaction();
                return base.Withdraw(amount);
            }

            double remainder = amount - Balance;
            if (Balance > 0)
            {
                bool ok = base.Withdraw(Balance);
                if (!ok) return false;
            }

            throw new NotSupportedException("CheckingAccount requires Account to expose a protected AdjustBalance method. Update Account.cs accordingly.");
        }

        public override void PrintDetails()
        {
            base.PrintDetails();
            Console.WriteLine($"Overdraft Limit : {OverdraftLimit:C}");
            Console.WriteLine($"Free TXs        : {FreeTransactions}");
            Console.WriteLine($"Transactions    : {_transactionCount}");
            Console.WriteLine();
        }
    }
}