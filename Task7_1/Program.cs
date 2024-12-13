using System;

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
            switch (userSelection)
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
                case MenuOption.Print:
                    Console.WriteLine("---Print---");
                    DoPrint(bank);
                    break;
                case MenuOption.Quit:
                    Console.WriteLine("---Quit---");
                    break;
            }
        }
        while (userSelection != MenuOption.Quit);
    }

    public enum MenuOption
    {
        NewAccount,
        Withdraw,
        Deposit,
        Transfer,
        Print,
        Quit
    }

    public static MenuOption ReadUserOption()
    {
        Console.WriteLine("----------------------------");
        int option;
        Console.WriteLine("Enter 1 to Add New Account");
        Console.WriteLine("Enter 2 to Withdraw");
        Console.WriteLine("Enter 3 to Deposit");
        Console.WriteLine("Enter 4 to Transfer");
        Console.WriteLine("Enter 5 to Print");
        Console.WriteLine("Enter 6 to Quit");
        Console.WriteLine("----------------------------");

        do
        {
            Console.Write("Choose an option [1-6]: ");
            option = Convert.ToInt32(Console.ReadLine());
        }
        while (option < 1 || option > 6);

        return (MenuOption)(option - 1);
    }

   

    private static void DoDeposit(Bank toBank)
    {
        Account toAccount = FindAccount(toBank);
        if (toAccount == null) return;

        Console.Write("How much do you want to deposit: ");
        decimal amount = Convert.ToDecimal(Console.ReadLine());
        DateTime now = DateTime.Now;
        DepositTransaction deposit = new DepositTransaction(toAccount, amount, now);
        toBank.ExecuteTransaction(deposit);
        deposit.PrintTransaction();
    }

      private static void NewAccount(Bank bank)
    {
        Console.Write("Enter name of the account: ");
        string name = Console.ReadLine();

        Console.Write("Enter starting balance: ");
        decimal balance = Convert.ToDecimal(Console.ReadLine());

        Account newAccount = new Account(name, balance, bank);
        bank.AddAccount(newAccount);
        Console.WriteLine("Account created successfully!");
    }
    private static void DoTransfer(Bank fromBank, Bank toBank)
    {
        Console.WriteLine("From what account?");
        Account fromAccount = FindAccount(toBank);
        if (fromAccount == null) return;

        Console.WriteLine("To what account?");
        Account toAccount = FindAccount(toBank);
        if (toAccount == null) return;

        Console.Write("How much do you want to transfer: ");
        decimal amount = Convert.ToDecimal(Console.ReadLine());
        DateTime now = DateTime.Now;
        TransferTransaction transfer = new TransferTransaction(fromAccount, toAccount, amount, now);
        fromBank.ExecuteTransaction(transfer);
        transfer.PrintTransaction();
    }

    private static void DoWithdraw(Bank toBank)
    {
        Account toAccount = FindAccount(toBank);
        if (toAccount == null) return;

        Console.Write("How much do you want to withdraw: ");
        decimal amount = Convert.ToDecimal(Console.ReadLine());
        DateTime now = DateTime.Now;
        WithdrawTransaction withdrawal = new WithdrawTransaction(toAccount, amount, now);
        toBank.ExecuteTransaction(withdrawal);
        withdrawal.PrintTransaction();
    }


    public static void DoPrint(Bank bank)
    {
        bank.PrintTransactionHistory();
    }
}
