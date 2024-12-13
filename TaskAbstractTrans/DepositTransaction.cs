using System;

public class DepositTransaction : Transaction
{
    private Account _targetAccount;
    private decimal _transactionAmount;
    private bool _isExecuted;
    private bool _isSuccessful;
    private bool _isReversed;

    public bool IsExecuted
    {
        get { return _isExecuted; }
    }
    public override bool IsSuccess
    {
        get { return _isSuccessful; }
    }
    public bool IsReversed
    {
        get { return _isReversed; }
    }

    public DepositTransaction(Account targetAccount, decimal amount, DateTime date) : base(amount, date)
    {
        _targetAccount = targetAccount;
        _transactionAmount = amount;
    }
    public override void ExecuteTransaction()
    {
        base.ExecuteTransaction();
        if (_isExecuted)
        {
            throw new Exception("Transaction has already been executed.");
        }
        _isExecuted = true;
        _isSuccessful = _targetAccount.Deposit(_transactionAmount);

        if (_isSuccessful)
        {
            _targetAccount.Bank.AddTransaction(this);
        }
    }
    public override void RollbackTransaction()
    {
        if (!_isExecuted)
        {
            throw new Exception("Transaction has not been executed.");
        }
        if (_isReversed)
        {
            throw new Exception("Transaction has already been reversed.");
        }
        _isReversed = true;
        _targetAccount.Deposit(_transactionAmount);
    }
    public override void PrintTransaction()
    {
        Console.WriteLine("Deposit Transaction:");
        Console.WriteLine($"Date: {TransactionDate}");
        Console.WriteLine("Amount: " + _transactionAmount);
        Console.WriteLine("Deposit Successful.");
        if (_isReversed)
        {
            Console.WriteLine("Note: This transaction has been reversed.");
        }
    }
}
