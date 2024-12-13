using System;

public abstract class Transaction
{
    protected readonly decimal _transactionAmount;
    private bool _isExecuted;
    private bool _isReversed;
    private DateTime _transactionDate;

    public decimal TransactionAmount => _transactionAmount;

    public abstract bool IsSuccess { get; }
    


    public DateTime TransactionDate
    {
        get { return _transactionDate; }
        set { _transactionDate = value; }
    }

     public bool IsReversed
    {
        get { return _isReversed; }
        set { _isReversed = value; }
    }


    public bool IsExecuted
    {
        get { return _isExecuted; }
        set { _isExecuted = value; }
    }
   

    // Constructor
    public Transaction(decimal amount, DateTime date)
    {
        _transactionDate = date;
        _transactionAmount = amount;
        
        _isExecuted = false;
        _isReversed = false;
    }

    // Abstract Method
    public abstract void PrintTransaction();

   

    // Virtual Rollback Method
    public virtual void RollbackTransaction()
    {
        if (!_isExecuted)
        {
            throw new InvalidOperationException("Transaction has not been executed.");
        }

        
        _isReversed = true;

        _isExecuted = false;

        _transactionDate = DateTime.Now;
    }


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
}
