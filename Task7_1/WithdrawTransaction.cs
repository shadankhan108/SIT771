using System;

public class WithdrawTransaction : Transaction
{
    private Account _targetAccount;
    private decimal _withdrawAmount;
    private bool _isExecuted;
    private bool _isReversed;

    public bool IsReversed => _isReversed;

    public bool IsExecuted => _isExecuted;
    

    public WithdrawTransaction(Account targetAccount, decimal amount, DateTime date) : base(amount, date)
    {
        _targetAccount = targetAccount;
        _withdrawAmount = amount;
    }

    public override bool IsSuccess => _isExecuted && !_isReversed;

   

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

        _targetAccount.Deposit(_withdrawAmount);
        _isReversed = true;
    }


     public override void ExecuteTransaction()
    {
        if (_isExecuted)
        {
            throw new InvalidOperationException("Transaction has already been executed.");
        }

        if (_targetAccount.Withdraw(_withdrawAmount))
        {
            _isExecuted = true;
            _targetAccount.Bank.AddTransaction(this);
        }
        else
        {
            throw new InvalidOperationException("Withdrawal failed due to insufficient funds.");
        }
    }

    public override void PrintTransaction()
    {
        Console.WriteLine("Withdraw Transaction:");
        Console.WriteLine($"Amount: {_withdrawAmount}");
        Console.WriteLine($"Date: {TransactionDate}");
        
        Console.WriteLine(_isExecuted ? "Withdraw Successful." : "Withdraw Failed.");
        if (_isReversed)
        {
            Console.WriteLine("Note: This transaction has been reversed.");
        }
    }
}
