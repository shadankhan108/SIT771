using System;

public abstract class Transaction
{
    protected readonly decimal _transactionAmount;
    private bool _isExecuted;
    private bool _isReversed;
    private DateTime _transactionDate;

    public abstract bool IsSuccess { get; }
    public decimal TransactionAmount => _transactionAmount;
    public DateTime TransactionDate
    {
        get { return _transactionDate; }
        set { _transactionDate = value; }
    }
    public bool IsExecuted
    {
        get { return _isExecuted; }
        set { _isExecuted = value; }
    }
    public bool IsReversed
    {
        get { return _isReversed; }
        set { _isReversed = value; }
    }

    // Constructor
    public Transaction(decimal amount, DateTime date)
    {
        _transactionAmount = amount;
        _transactionDate = date;
        _isExecuted = false;
        _isReversed = false;
    }

    // Abstract Method
    public abstract void PrintTransaction();

    // Virtual Method
    public virtual void ExecuteTransaction()
    {
        if (_isExecuted)
        {
            throw new InvalidOperationException("Transaction has already been executed.");
        }

        _isExecuted = true;
        _transactionDate = DateTime.Now;
    }

    // Virtual Rollback Method
    public virtual void RollbackTransaction()
    {
        if (!_isExecuted)
        {
            throw new InvalidOperationException("Transaction has not been executed.");
        }

        _isExecuted = false;
        _isReversed = true;
        _transactionDate = DateTime.Now;
    }
}
