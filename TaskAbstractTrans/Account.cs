using System;

public class Account
{
    public string Name { get; private set; }
    public decimal Balance { get; private set; }
    public Bank Bank { get; set; }
    private string _accountName;
    private decimal _accountBalance;

    public Account(string name, decimal startingBalance, Bank bank)
    {
        _accountName = name;
        _accountBalance = Balance;
        Bank = bank;
    }

    public string AccountName
    {
        get { return _accountName; }
    }

    public void PrintAccountDetails()
    {
        Console.WriteLine($"Account Name: {_accountName}, Balance: {_accountBalance}");
    }

    public bool Deposit(decimal amountToDeposit)
    {
        if (amountToDeposit > 0)
        {
            _accountBalance += amountToDeposit;
            return true;
        }
        return false;
    }

    public bool Withdraw(decimal amountToWithdraw)
    {
        if (amountToWithdraw <= _accountBalance)
        {
            _accountBalance -= amountToWithdraw;
            return true;
        }
        return false;
    }
}
