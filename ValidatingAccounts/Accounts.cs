public class Account
{
    private string _name;
    private decimal _balance;

    public string Name { get { return _name; } }
    public decimal Balance { get { return _balance; } }

    public Account(string name, decimal startingBalance)
    {
        _name = name;
        _balance = startingBalance;
    }

    public bool Deposit(decimal amountToDeposit)
    {
        if (amountToDeposit > 0)
        {
            _balance += amountToDeposit;
            return true;
        }
        return false;
    }

    public bool Withdraw(decimal amountToWithdraw)
    {
        if (amountToWithdraw > 0 && amountToWithdraw <= _balance)
        {
            _balance -= amountToWithdraw;
            return true;
        }
        return false;
    }

    public void Print()
    {
        Console.WriteLine($"Account Name: {_name}");
        Console.WriteLine($"Balance: {_balance}");
    }
}