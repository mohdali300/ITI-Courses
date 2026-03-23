using System;

namespace Lab4
{
    public interface IPrintable
    {
        void PrintDetails();
    }

    public interface ITransactable
    {
        void Deposit(double amount);
        bool Withdraw(double amount);
    }
}