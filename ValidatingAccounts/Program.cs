using System;
using SplashKitSDK;

namespace ValidatingAccounts

{

using System;

public enum MenuOption
{
    Deposit = 1,
    Withdraw,
    Print,
    Quit
}

public class Program
{
    public static void Main()
    {
        Account account = new Account("Shadan's Account", 1000);

        MenuOption userSelection;
        do
        {
            userSelection = ReadUserOption();
            switch (userSelection)
            {
                case MenuOption.Deposit:
                    DoDeposit(account);
                    break;
                case MenuOption.Withdraw:
                    DoWithdraw(account);
                    break;
                case MenuOption.Print:
                    account.Print();
                    break;
                case MenuOption.Quit:
                    Console.WriteLine("Goodbye!");
                    break;
                default:
                    Console.WriteLine("Invalid option, please try again.");
                    break;
            }
        } while (userSelection != MenuOption.Quit);
    }

    private static MenuOption ReadUserOption()
    {
        MenuOption option;
        do
        {
            Console.WriteLine("Menu:");
            Console.WriteLine("1. Deposit");
            Console.WriteLine("2. Withdraw");
            Console.WriteLine("3. Print");
            Console.WriteLine("4. Quit");
            Console.Write("Choose an option [1-4]: ");
            if (!Enum.TryParse(Console.ReadLine(), out option))
            {
                Console.WriteLine("Invalid input, please enter a number.");
                option = (MenuOption)(-1);
            }
        } while (option < MenuOption.Deposit || option > MenuOption.Quit);
        return option;
    }

    private static void DoDeposit(Account account)
    {
        Console.Write("Enter amount to deposit: ");
        decimal amountToDeposit;
        if (decimal.TryParse(Console.ReadLine(), out amountToDeposit))
        {
            if (account.Deposit(amountToDeposit))
            {
                Console.WriteLine($"Successfully deposited {amountToDeposit}. New balance: {account.Balance}");
            }
            else
            {
                Console.WriteLine("Invalid amount to deposit. Please enter a positive value.");
            }
        }
        else
        {
            Console.WriteLine("Invalid input. Please enter a valid number.");
        }
    }

    private static void DoWithdraw(Account account)
    {
        Console.Write("Enter amount to withdraw: ");
        decimal amountToWithdraw;
        if (decimal.TryParse(Console.ReadLine(), out amountToWithdraw))
        {
            if (account.Withdraw(amountToWithdraw))
            {
                Console.WriteLine($"Successfully withdrew {amountToWithdraw}. New balance: {account.Balance}");
            }
            else
            {
                Console.WriteLine("Invalid amount to withdraw. Please enter a positive value less than or equal to your balance.");
            }
        }
        else
        {
            Console.WriteLine("Invalid input. Please enter a valid number.");
        }
    }
}


}

