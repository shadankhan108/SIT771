using System;

public class WithdrawTransaction
{
    public Account _account;
    public decimal _amount;
    public bool _executed = false;
    public bool _success = false;
    public bool _reversed = false;

    public bool Executed
    {
        get{ return _executed; }
    }
    public bool Success
    {
        get { return _success; }
    }
    public bool Reversed
    {
        get { return _reversed; }
    }

    public WithdrawTransaction(Account account, decimal amount)
    {
        _account = account;
        _amount = amount;
    }
    public void Execute()
    {
        if (_executed)
        {
            throw new Exception("Cannot execute transaction already been executed.");
        }
        _executed = true;
        _success = _account.Withdraw(_amount);
    }
    public void Rollback()
    {
        if (!_executed)
        {
            throw new Exception("Cannot rollback transaction it has not been executed.");
        }
        if (_reversed)
        {
            throw new Exception("Cannot rollback transaction it has been reversed.");
        }
        _reversed = true;
        _account.Deposit(_amount);
    }
    public void Print()
    {
        Console.WriteLine("Withdraw Transaction:");
        Console.WriteLine("Amount: " + _amount);
        Console.WriteLine("Successful: " + _success);
        if (_reversed)
        {
            Console.WriteLine("Note: This transaction has been reveresd.");
        }
    }
}