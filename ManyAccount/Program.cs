using System;
using SplashKitSDK;

namespace Task5_3P
{
    public class Program
    {
        private static Account FindAccount(Bank fromBank)
        {
            Console.Write("Enter account name: ");
            string name = Console.ReadLine();
            Account result = fromBank.GetAccount(name);

            if (result == null)
            {
                Console.WriteLine($"No account found with name {name}");
            }
            return result;
        }
        public static void Main()
        {
            Bank bank = new Bank();
            

            MenuOption userSelection;
            do
            {
                userSelection = ReadUserOption();
                switch(userSelection)
                {
                    case MenuOption.NewAccount:
                        NewAccount(bank);
                        break;
                    case MenuOption.Withdraw:
                        Console.WriteLine("---Withdraw---");
                        DoWithdraw(bank);
                        break;

                    case MenuOption.Deposit:
                        Console.WriteLine("---Deposit---");
                        DoDeposit(bank);
                        break;
                    
                    case MenuOption.Transfer:
                        Console.WriteLine("---Transfer---");
                        DoTransfer(bank, bank);
                        break;

                    /*case MenuOption.Print:
                        Console.WriteLine("---Print---");
                        DoPrint(bank);
                        break;
                    */
                    case MenuOption.Quit:
                        Console.WriteLine("---Quit---");
                        break;
                }
            }
            while(userSelection != MenuOption.Quit);
        }
    
        public enum MenuOption
        {
            NewAccount,
            Withdraw, 
            Deposit,
            Transfer,
            //Print,
            Quit
        }
        public static MenuOption ReadUserOption()
        {
            Console.WriteLine("----------------------------");
            int option;
            Console.WriteLine("1 to Enter New Account");
            Console.WriteLine("2 to Enter Withdraw Amount");
            Console.WriteLine("3 to Enter Deposit Amount");
            //Console.WriteLine("Enter 4 to Print");
            Console.WriteLine("4 to Enter Transfer Amount");
            Console.WriteLine("5 to Exit");
            Console.WriteLine("----------------------------");

            do
                {
                    Console.Write("Choose an opion [1-5]: ");
                    option = Convert.ToInt32(Console.ReadLine());
                }
            while(option<1 || option>5);
            
            return (MenuOption)(option-1);
        }
        private static void NewAccount(Bank bank)
        {
            Console.WriteLine("Enter name of the account: ");
            string name = Console.ReadLine();

            Console.WriteLine("Enter starting balance: ");
            decimal balance = Convert.ToDecimal(Console.ReadLine());

            Account newAccount = new Account(name, balance);
            bank.AddAccount(newAccount);
            Console.WriteLine("Account created successfully!");
        }
        private static void DoDeposit(Bank toBank)
        {
            Account toAccount = FindAccount(toBank);
            if (toAccount == null) return;

            Console.Write("How much do you want to deposit: ");
            decimal amount = Convert.ToDecimal(Console.ReadLine());
            DepositTransaction deposit = new DepositTransaction(toAccount, amount);
            deposit.Execute();
            deposit.Print();
        }
        private static void DoWithdraw(Bank toBank)
        {
            Account toAccount = FindAccount(toBank);
            if (toAccount == null) return;

            Console.Write("How much do you want to withdraw: ");
            decimal amount = Convert.ToDecimal(Console.ReadLine());
            WithdrawTransaction withdrawal = new WithdrawTransaction(toAccount, amount);
            withdrawal.Execute();
            withdrawal.Print();
        }
        private static void DoTransfer(Bank fromBank, Bank toBank)
        {
            Console.WriteLine("From what account?");
            Account toAccount = FindAccount(toBank);
            if (toAccount == null) return;

            Console.WriteLine("To what account?");
            Account fromAccount = FindAccount(fromBank);
            if (toAccount == null) return;

            Console.Write("How much do you want to transfer: ");
            decimal amount = Convert.ToDecimal(Console.ReadLine());
            TransferTransaction transfer = new TransferTransaction(fromAccount, toAccount, amount);
            transfer.Execute();
            transfer.Print();
        }
        /*private static void DoPrint(Account account)
        {
            account.Print();
            Console.WriteLine("----------------------------------");
        }
        */
    }
}

