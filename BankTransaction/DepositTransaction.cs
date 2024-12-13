using System;

public class DepositTransaction
{
    private Account _account;
    private decimal _amount;
    private bool _executed = false;
    private bool _reversed = false;
    private bool _success = false;

    public bool Executed
    {
        get { return _executed; }
    }

    public bool Success
    {
        get { return _success; }
    }

    public bool Reversed
    {
        get { return _reversed; }
    }

    public DepositTransaction (Account account, decimal amount)
    {
        _account = account;
        _amount = amount;
    }

    public void Execute()
    {
        if (_executed)
        {
            throw new Exception("This transaction has already been executed.");
        }

        _executed = true;
        _success = _account.Deposit(_amount);
    }

    public void Reverse()
    {
        if (!_executed)
        {
            throw new Exception("Cannot reverse this transaction as it has not been executed.");
        }

        if (_reversed)
        {
            throw new Exception("Cannot reverse this transaction as it has already been reversed.");
        }

        _reversed = true;

        if (_success)
        {
            _account.Withdraw(_amount);
        }
    }

    public void Print()
    {
        Console.WriteLine($"Deposit of {_amount} into {_account.HolderName}'s account.");
        Console.WriteLine($"Successful: {_success}, Reversed: {_reversed}");
    }
}
