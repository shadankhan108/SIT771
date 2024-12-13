using System;
using SplashKitSDK;

namespace BankProgram;

    public class Program
{
    public static void Main()
    {
        Account account = new Account("Shadan Account", 200000);
        account.Print();

        
        account.Deposit(100);
        account.Print();

        
        account.Withdraw(50);
        account.Print();

        
        Account secondAccount = new Account("Simone Account", 10000);
        secondAccount.Print();

        
        secondAccount.Deposit(200);
        secondAccount.Withdraw(50);
        secondAccount.Print();
    }
}
