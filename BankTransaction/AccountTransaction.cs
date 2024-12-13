using System;

public class Account
{
    private decimal _balance;
    private string _accountholderName;

    public string HolderName
    {
        get { return _accountholderName; }
    }

    public decimal Balance
    {
        get { return _balance; }
    }

    public Account(string holderName, decimal initialBalance)
    {
        _accountholderName = holderName;
        _balance = initialBalance;
    }

    public bool Deposit(decimal amountToAdd)
    {
        if (amountToAdd > 0)
        {
            _balance += amountToAdd;
            return true;
        }
        return false;
    }

    public bool Withdraw(decimal amountToWithdraw)
    {
        if (amountToWithdraw < 0 || amountToWithdraw > _balance)
        {
            return false;
        }
        else
        {
            _balance -= amountToWithdraw;
            return true;
        }
    }

    public void DisplayAccountInfo()
    {
        Console.WriteLine("Account Holder: " + _accountholderName);
        Console.WriteLine("Account Balance: " + _balance);
    }
}
