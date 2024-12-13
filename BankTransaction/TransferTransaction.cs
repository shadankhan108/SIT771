using System;

public class TransferTransaction
{
    private WithdrawTransaction _withdrawal;
    private DepositTransaction _deposit;
    private Account _senderAccount;
    private Account _receiverAccount;
    private decimal _amount;
    private bool _executed = false;
    private bool _reversed = false;
    private bool _success = false;

    public bool Executed
    {
        get { return _executed; }
    }

    public bool Success
    {
        get { return _withdrawal.Success; }
    }

    public bool Reversed
    {
        get { return _withdrawal.Reversed; }
    }

    public TransferTransaction (Account senderAccount, Account receiverAccount, decimal amount)
    {
        _senderAccount = senderAccount;
        _receiverAccount = receiverAccount;
        _amount = amount;

        _withdrawal = new WithdrawTransaction(senderAccount, amount);
        _deposit = new DepositTransaction (receiverAccount, amount);
    }

    public void Execute()
    {
        if (_withdrawal.Done)
        {
            throw new Exception("This transaction has already been executed.");
        }

        _withdrawal.Execute();

        if (_withdrawal.Success)
        {
            _deposit.Execute();
        }
        else
        {
            _withdrawal.Reverse();
        }
    }

    public void Reverse()
    {
        if (_withdrawal.Done)
        {
            throw new Exception("Cannot reverse this transaction as it has not been executed.");
        }

        if (_withdrawal.Reversed)
        {
            throw new Exception("Cannot reverse this transaction as it has already been reversed.");
        }

        if (_withdrawal.Success)
        {
            _withdrawal.Reverse();
        }

        if (_deposit.Success)
        {
            _deposit.Reverse();
        }
    }

    public void Print()
    {
        Console.WriteLine($"Transferred {_amount} from {_senderAccount.HolderName}'s account to {_receiverAccount.HolderName}'s account.");
        Console.WriteLine();
        _withdrawal.Print();
        Console.WriteLine();
        _senderAccount.DisplayAccountInfo();
        Console.WriteLine();
        Console.WriteLine();
        _deposit.Print();
        Console.WriteLine();
        _receiverAccount.DisplayAccountInfo();
    }
}
