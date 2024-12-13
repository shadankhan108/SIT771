using System;

public class Account
{
    private decimal _balance;
    private string _name;

    public Account(string name, decimal startingBalance)
    {
        _name = name;
        _balance = startingBalance;
    }

    public void Deposit(decimal amountToAdd)
    {
        _balance += amountToAdd;
    }

    public void Withdraw(decimal amountToWithdraw)
    {
        if (amountToWithdraw <= _balance)
        {
            _balance -= amountToWithdraw;
        }
        else
        {
            Console.WriteLine("Insufficient funds");
        }
    }

    public string Name
    {
        get { return _name; }
    }

    public void Print()
    {
        Console.WriteLine($"Account Name: {_name}");
        Console.WriteLine($"Balance: {_balance}");
    }
}


