using System;

public class TransferTransaction : Transaction
{
    private Account _sourceAccount;
    private Account _destinationAccount;
    private decimal _transferAmount;
    private DepositTransaction _depositTransaction;
    private WithdrawTransaction _withdrawTransaction;
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

    public TransferTransaction(Account sourceAccount, Account destinationAccount, decimal amount, DateTime date) : base(amount, date)
    {
        _sourceAccount = sourceAccount;
        _destinationAccount = destinationAccount;
        _transferAmount = amount;

        _withdrawTransaction = new WithdrawTransaction(sourceAccount, amount, date);
        _depositTransaction = new DepositTransaction(destinationAccount, amount, date);
    }

    public override bool Success
    {
        get { return _withdrawTransaction.Success && _depositTransaction.Success; }
    }

    public override void ExecuteTransaction()
    {
        base.ExecuteTransaction();

        if (_isExecuted)
        {
            throw new InvalidOperationException("Transaction has already been executed.");
        }

        _withdrawTransaction.ExecuteTransaction();

        if (_withdrawTransaction.Success)
        {
            _depositTransaction.ExecuteTransaction();

            if (!_depositTransaction.Success)
            {
                _withdrawTransaction.RollbackTransaction();
                throw new InvalidOperationException("Deposit transaction failed. Rollback initiated.");
            }

            _isExecuted = true;
            _sourceAccount.Bank.AddTransaction(this);
        }
    }

    public void RollbackTransaction()
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

    public override void PrintTransaction()
    {
        Console.WriteLine("Transfer Transaction:");
        Console.WriteLine($"Date: {TransactionDate}");
        Console.WriteLine($"Transferred ${_transferAmount} from {_sourceAccount.Name}'s to {_destinationAccount.Name}'s account.");
        Console.WriteLine("Transfer Successful.");
    }
}
