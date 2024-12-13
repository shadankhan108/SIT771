using System;

public class DepositTransaction : Transaction
{
    private Account _targetAccount;

    private bool _isExecuted;
    
    private decimal _transactionAmount;
    
    private bool _isReversed;

    public bool IsExecuted => _isExecuted;

      public bool IsReversed => _isReversed;
    public override bool IsSuccess => _isExecuted && !_isReversed;
  

    public DepositTransaction(Account targetAccount, decimal amount, DateTime date) : base(amount, date)
    {
        _targetAccount = targetAccount;
        _transactionAmount = amount;
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

        _targetAccount.Withdraw(_transactionAmount);
        _isReversed = true;
    }


      public override void ExecuteTransaction()
    {
        if (_isExecuted)
        {
            throw new InvalidOperationException("Transaction has already been executed.");
        }

        if (_targetAccount.Deposit(_transactionAmount))
        {
            _isExecuted = true;
            _targetAccount.Bank.AddTransaction(this);
        }
    }


    public override void PrintTransaction()
    {
        Console.WriteLine("Deposit Transaction:");
        Console.WriteLine($"Date: {TransactionDate}");
        Console.WriteLine($"Amount: {_transactionAmount}");
        Console.WriteLine(_isExecuted ? "Deposit Successful." : "Deposit Failed.");
        if (_isReversed)
        {
            Console.WriteLine("Note: This transaction has been reversed.");
        }
    }
}
