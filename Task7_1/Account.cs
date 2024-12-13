using System;

public class Account
{
    public string AccountName { get; private set; }
    public decimal Balance { get; private set; }
    public Bank Bank { get; set; }

    public Account(string name, decimal startingBalance, Bank bank)
    {
        AccountName = name;
        Balance = startingBalance;
        Bank = bank;
    }

    public void PrintAccountDetails()
    {
        Console.WriteLine($"Account Name: {AccountName}, Balance: {Balance}");
    }

    public bool Deposit(decimal amountToDeposit)
    {
        if (amountToDeposit > 0)
        {
            Balance += amountToDeposit;
            return true;
        }
        return false;
    }

    public bool Withdraw(decimal amountToWithdraw)
    {
        if (amountToWithdraw <= Balance)
        {
            Balance -= amountToWithdraw;
            return true;
        }
        return false;
    }
}
