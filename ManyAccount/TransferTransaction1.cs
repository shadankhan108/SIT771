using System;

public class TransferTransaction
{
    public Account _toAccount;
    public Account _fromAccount;
    public decimal _amount;
    public DepositTransaction _theDeposit;
    public WithdrawTransaction _theWithdraw;
    public bool _executed = false;
    public bool _reversed = false;

    public bool Success
    {
        get { return _theDeposit.Success && _theWithdraw.Success; }
    }

    public bool Executed
    {
        get{ return _executed; }
    }
    
    public bool Reversed
    {
        get { return _reversed; }
    }

    public TransferTransaction(Account fromAccount, Account toAccount, decimal amount)
    {
        _fromAccount = fromAccount;
        _toAccount = toAccount;
        _amount = amount;

        _theWithdraw = new WithdrawTransaction(fromAccount, amount);
        _theDeposit = new DepositTransaction(toAccount, _amount);
    }
    public void Execute()
    {
        if (_executed)
        {
            throw new Exception("Cannot execute this transaction as it has already been executed.");
        }
        _theWithdraw.Execute();
        if (_theWithdraw.Success)
        {
            _theDeposit.Execute();
            if (!_theDeposit.Success)
            {
                _theWithdraw.Rollback();
                throw new Exception("Deposit transaction failed. Rollback initiated.");
            }
        }
        _executed = true;
    }

      public void Print()
    {
        Console.WriteLine($"Transferred ${_amount} from {_fromAccount.name}'s to {_toAccount.name}'s account.");
        Console.WriteLine("Transfer Successful.");
       
    
    }
    public void Rollback()
    {
        if (!_executed)
        {
            throw new Exception("Cannot rollback a transaction that has not been executed.");
        }
        if (_reversed)
        {
            throw new Exception("Cannot rollback a transaction that has been reversed.");
        }
        if (_theWithdraw.Success)
        {
            _theWithdraw.Rollback();
        }
        if (_theDeposit.Success)
        {
            _theDeposit.Rollback();
        }
        _reversed = true;
    }
  
}