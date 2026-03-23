using System;

namespace Lab4
{
    public class SavingsAccount : Account
    {
        public double InterestRate { get; }
        public double MinimumBalance { get; }

        public SavingsAccount(string ownerName, double initialBalance, double interestRate = 0.03, double minimumBalance = 100.0)
            : base(ownerName, initialBalance)
        {
            if (interestRate < 0) throw new ArgumentOutOfRangeException(nameof(interestRate));
            InterestRate = interestRate;
            MinimumBalance = Math.Max(0.0, minimumBalance);
        }

        public override double CalculateInterest()
        {
            if (Balance <= 0) return 0.0;
            return Balance * InterestRate;
        }

        public override bool Withdraw(double amount)
        {
            if (amount <= 0) throw new ArgumentOutOfRangeException(nameof(amount));

            double projected = Balance - amount;
            if (projected < MinimumBalance)
            {
                Console.WriteLine($"{AccountNumber}: Withdrawal denied — minimum balance of {MinimumBalance:C} must be maintained.");
                return false;
            }

            return base.Withdraw(amount);
        }

        public override void PrintDetails()
        {
            base.PrintDetails();
            Console.WriteLine($"Interest Rate  : {InterestRate:P}");
            Console.WriteLine($"Minimum Balance: {MinimumBalance:C}");
            Console.WriteLine();
        }
    }
}