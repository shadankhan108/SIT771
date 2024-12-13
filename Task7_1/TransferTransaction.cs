using System;

public class TransferTransaction : Transaction
{
    
    private Account _destinationAccount;
    private Account _sourceAccount;
    private decimal _transferAmount;

    private WithdrawTransaction _withdrawTransaction;
    private DepositTransaction _depositTransaction;
    

    private bool _isReversed;
    private bool _isExecuted;
    

    public bool IsExecuted => _isExecuted;
    public bool IsReversed => _isReversed;

    public TransferTransaction(Account sourceAccount, Account destinationAccount, decimal amount, DateTime date) : base(amount, date)
    {
        _sourceAccount = sourceAccount;
        _destinationAccount = destinationAccount;
        _transferAmount = amount;

        _withdrawTransaction = new WithdrawTransaction(sourceAccount, amount, date);
        _depositTransaction = new DepositTransaction(destinationAccount, amount, date);
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

        _withdrawTransaction.RollbackTransaction();
        _depositTransaction.RollbackTransaction();
        _isReversed = true;
    }


    public override bool IsSuccess => _withdrawTransaction.IsSuccess && _depositTransaction.IsSuccess;

    public override void ExecuteTransaction()
    {
        if (_isExecuted)
        {
            throw new InvalidOperationException("Transaction has already been executed.");
        }

        _withdrawTransaction.ExecuteTransaction();
        if (_withdrawTransaction.IsSuccess)
        {
            _depositTransaction.ExecuteTransaction();
            if (_depositTransaction.IsSuccess)
            {
                _isExecuted = true;
                _sourceAccount.Bank.AddTransaction(this);
            }
            else
            {
                _withdrawTransaction.RollbackTransaction();
                throw new InvalidOperationException("Deposit transaction failed. Rollback initiated.");
            }
        }
    }


    public override void PrintTransaction()
    {
        Console.WriteLine($"Date: {TransactionDate}");
        
        Console.WriteLine("Transfer Transaction:");
        
        Console.WriteLine($"Transferred ${_transferAmount} from {_sourceAccount.AccountName} to {_destinationAccount.AccountName}.");
        
        Console.WriteLine(_isExecuted ? "Transfer Successful." : "Transfer Failed.");
        if (_isReversed)
        {
            Console.WriteLine("Note: This transaction has been reversed.");
        }
    }
}
