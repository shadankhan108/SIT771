using System;

public class Bank
{
    private List<Account> _accounts = new List<Account>();

    public void AddAccount(Account account)
    {
            _accounts.Add(account);
    }
    public Account GetAccount(string name)
    {
        foreach (Account account in _accounts)
        {
            if (account.name == name)
            {
                return account;
            }
        }
        return null;
        Console.WriteLine("No account had a matching name");
    }
    public void ExecuteTransaction(WithdrawTransaction transaction)
    {
        Console.WriteLine("Executing WithdrawTransaction");
    }
    public void ExecuteTransaction(DepositTransaction transaction)
    {
        Console.WriteLine("Executing DepositTransaction");
    }
    public void ExecuteTransaction(TransferTransaction transfer)
    {  
        Console.WriteLine("Executing TransferTransaction");
    }

}