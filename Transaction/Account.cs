using System;

public class Account
{
    private string _name;
    private decimal _balance;

    public Account(string name, decimal startingBalance)
    {
        _name = name;
        _balance = startingBalance;
    }


    public string name
    {
      get { return _name;}
    }

    public void Print()
    {
      Console.WriteLine($"Name: {_name}, Balance: {_balance}");
    }

    public bool Deposit(decimal amountToDeposit)
    {
      if (amountToDeposit > 0)
      {
        _balance += amountToDeposit;
        return true;
      }
      return false;
    }

    public bool Withdraw(decimal amountToWithdraw)
    {
      if (amountToWithdraw <= _balance )
      {
        _balance -= amountToWithdraw;
        return true;
      }
      return false;
    }

}
