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

    public void Deposit(decimal amountToDeposit)
    {
      _balance = _balance + amountToDeposit;
    }

    public void Withdraw(decimal amountToWithdraw)
    {
      _balance = _balance - amountToWithdraw;
    }


    public string name
    {
      get { return _name;}
    }

    public void Print()
    {
      Console.WriteLine($"Name: {_name}, Balance: {_balance}");
    }

    public bool DepositTransaction(decimal amountToDeposit)
    {
      if (amountToDeposit > 0)
      {
        _balance += amountToDeposit;
        return true;
      }
      return false;
    }

    public bool WithdrawTransaction(decimal amountToWithdraw)
    {
      if (amountToWithdraw <= _balance )
      {
        _balance -= amountToWithdraw;
        return true;
      }
      return false;
    }

}
