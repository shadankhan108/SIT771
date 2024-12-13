using System;
using System.Collections.Generic;

public class Bank
{
    private List<Account> _accounts = new List<Account>();
    private List<Transaction> _transactions = new List<Transaction>();

    public void AddAccount(Account account)
    {
        account.Bank = this;
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
        Console.WriteLine("No account found with the given name.");
        return null;
    }
    
    public void ExecuteTransaction(Transaction transaction)
    {
        Console.WriteLine("Executing transaction...");
    }

    public void AddTransaction(Transaction transaction)
    {
        _transactions.Add(transaction);
    }

    public void PrintTransactionHistory()
    {
        if (_transactions.Count == 0)
        {
            Console.WriteLine("No transactions in history.");
            return;
        }
        
        Console.WriteLine("Transaction History: ");
        foreach (Transaction transaction in _transactions)
        {
            transaction.Print();
            Console.WriteLine("--------------------------");
        }
    }
}
