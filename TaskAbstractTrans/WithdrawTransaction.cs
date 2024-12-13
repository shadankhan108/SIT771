using System;

public class WithdrawTransaction : Transaction
{
    private Account _targetAccount;
    private decimal _withdrawAmount;
    private bool _isExecuted;
    private bool _isReversed;

    public bool IsExecuted
    {
        get { return _isExecuted; }
    }

    public bool IsReversed
    {
        get { return _isReversed; }
    }

    public WithdrawTransaction(Account targetAccount, decimal amount, DateTime date) : base(amount, date)
    {
        _targetAccount = targetAccount;
        _withdrawAmount = amount;
    }

    public override bool Success
    {
        get { return _isExecuted && _targetAccount.Balance >= _withdrawAmount; }
    }

    public override void ExecuteTransaction()
    {
        base.ExecuteTransaction();

        if (_isExecuted)
        {
            throw new InvalidOperationException("Transaction has already been executed.");
        }

        _isExecuted = true;
        _isReversed = false;

        if (_targetAccount.Withdraw(_withdrawAmount))
        {
            _targetAccount.Bank.AddTransaction(this);
        }
        else
        {
            throw new InvalidOperationException("Withdrawal failed due to insufficient funds.");
        }
    }

    public override void RollbackTransaction()
    {
        if (!_isExecuted)
        {
            throw new InvalidOperationException("Transaction has not been executed.");
        }

        if (_isReversed)
        {
            throw new InvalidOperationException("Transaction has already been reversed.");
        }

        _isReversed = true;
        _targetAccount.Deposit(_withdrawAmount);
    }

    public override void PrintTransaction()
    {
        Console.WriteLine("Withdraw Transaction:");
        Console.WriteLine($"Date: {TransactionDate}");
        Console.WriteLine("Amount: " + _withdrawAmount);
        Console.WriteLine("Withdraw Successful.");
        if (_isReversed)
        {
            Console.WriteLine("Note: This transaction has been reversed.");
        }
    }
}
