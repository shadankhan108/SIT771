using System;
using SplashKitSDK;

namespace BankTransactionProgram
{
    public class Program
    {
        
        public enum MenuOption
        {
            Withdraw, 
            Deposit,
            Print,
            Quit
        }

        public static MenuOption ReadUserOption()
        {
            int option;
            Console.WriteLine("Enter 1 to Withdraw");
            Console.WriteLine("Enter 2 to Deposit");
            Console.WriteLine("Enter 3 to Print");
            Console.WriteLine("Enter 4 to Quit");

            do
                {
                    Console.Write("Choose an opion [1-4]: ");
                    option = Convert.ToInt32(Console.ReadLine());
                }
            while(option<1 || option>4);
            
            return (MenuOption)(option-1);
        }


        public static void Main()
        {
            Account account = new Account("Shadan's Account", 8000);
            Account account2 = new Account("Shubham's Account", 12000);

            DoTransfer(account2, account);

            MenuOption userSelection;
            do
            {
                userSelection = ReadUserOption();
                switch(userSelection)
                {
                    case MenuOption.Withdraw:
                        Console.WriteLine("Withdraw");
                        DoWithdraw(account);
                        break;

                    case MenuOption.Deposit:
                        Console.WriteLine("Deposit");
                        DoDeposit(account);
                        break;

                    case MenuOption.Print:
                        Console.WriteLine("Print");
                        DoPrint(account);
                        break;

                    case MenuOption.Quit:
                        Console.WriteLine("Quit");
                        break;
                }
            }
            while(userSelection != MenuOption.Quit);
        }
    
     
        private static void DoDeposit(Account account)
        {
            Console.Write("Please enter the amount you wish to deposit: ");
            decimal amount = Convert.ToDecimal(Console.ReadLine());
            DepositTransaction deposit = new DepositTransaction(account, amount);
            deposit.Execute();
            deposit.Print();
            
        }
        private static void DoWithdraw(Account account)
        {
            
            Console.Write("What amount would you like to withdraw: ");
            decimal amount = Convert.ToDecimal(Console.ReadLine());
            WithdrawTransaction withdrawal = new WithdrawTransaction(account, amount);
            withdrawal.Execute();
            withdrawal.Print();
            
        }
        private static void DoTransfer(Account fromAccount, Account toAccount)
        {
            Console.Write("What amount do you wish to transfer: ");
            decimal amount = Convert.ToDecimal(Console.ReadLine());
            TransferTransaction transfer = new TransferTransaction(fromAccount, toAccount, amount);
            transfer.Execute();
            transfer.Print();
        }
        private static void DoPrint(Account account)
        {
            account.Print();
           
        }
    }
}
