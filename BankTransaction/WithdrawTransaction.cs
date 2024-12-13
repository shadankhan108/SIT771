using System;

public class WithdrawTransaction
{
    private Account _stash;
    private decimal _amount;
    private bool _done = false;
    private bool _succeed = false;
    private bool _undone = false;

    public bool Done
    {
        get { return _done; }
    }

    public bool Success
    {
        get { return _succeed; }
    }

    public bool Reversed
    {
        get { return _undone; }
    }

    public WithdrawTransaction(Account stash, decimal amount)
    {
        _stash = stash;
        _amount = amount;
    }

    public void Execute()
    {
        if (_done)
        {
            throw new Exception("Cannot process this transaction as it has already been executed.");
        }

        _done = true;
        _succeed = _stash.Withdraw(_amount);
    }

    public void Reverse()
    {
        if (!_done)
        {
            throw new Exception("Cannot reverse this transaction as it has not been executed yet.");
        }

        if (_undone)
        {
            throw new Exception("Cannot reverse this transaction as it has already been undone.");
        }

        _undone = true;

        if (_succeed)
        {
            _stash.Deposit(_amount);
        }
    }

    public void Print()
    {
        Console.WriteLine($"Withdrawal of {_amount} from {_stash.HolderName}'s account.");
        Console.WriteLine($"Successful: {_succeed}, Reversed: {_undone}");
    }
}
