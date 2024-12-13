using System;
using SplashKitSDK;

namespace bankTransaction
{
    public enum MenuOption
    {
        Withdraw,
        Deposit,
        Transfer,
        Print,
        Quit
    }

    public class Program
    {
        public static void Main()
        {
            MenuOption userSelection;
            Account stash1 = new Account("Kishor", 8000);
            Account stash2 = new Account("Suhas", 10000);

            do
            {
                userSelection = ReadUserOption();
                switch (userSelection)
                {
                    case MenuOption.Withdraw:
                        Console.WriteLine();
                        PerformCashOut(stash1);
                        Console.WriteLine();
                        stash1.DisplayAccountInfo();
                        break;
                    case MenuOption.Deposit:
                        Console.WriteLine();
                        PerformPayIn(stash1);
                        Console.WriteLine();
                        stash1.DisplayAccountInfo();
                        break;
                    case MenuOption.Transfer:
                        Console.WriteLine();
                        PerformMove(stash1, stash2);
                        break;
                    case MenuOption.Print:
                        Console.WriteLine();
                        stash1.DisplayAccountInfo();
                        stash2.DisplayAccountInfo();
                        break;
                    case MenuOption.Quit:
                        Console.WriteLine();
                        break;
                }
            } while (userSelection != MenuOption.Quit);
        }

        private static MenuOption ReadUserOption()
        {
            int choice;
            do
            {
                try
                {
                    Console.WriteLine();
                    Console.WriteLine("1 - Withdraw");
                    Console.WriteLine("2 - Deposit");
                    Console.WriteLine("3 - Transfer");
                    Console.WriteLine("4 - Current Balance");
                    Console.WriteLine("5 - Quit");

                    Console.Write("Please select an option [1-5]: ");
                    choice = Convert.ToInt32(Console.ReadLine());
                }
                catch
                {
                    Console.WriteLine("Invalid input. Please enter a number.");
                    choice = -1;
                }
            } while (choice < 1 || choice > 5);

            return (MenuOption)(choice - 1);
        }

        private static void PerformPayIn(Account stash)
        {
            decimal depositAmount;

            Console.WriteLine("Enter the amount you want to deposit: ");
            depositAmount = Convert.ToDecimal(Console.ReadLine());

            // Create a new DepositTransaction
            DepositTransaction depositTxn = new DepositTransaction (stash, depositAmount);

            try
            {
                // Execute the deposit transaction
                depositTxn.Execute();
                Console.WriteLine("Deposit successful!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Deposit failed: {ex.Message}");
            }

            Console.WriteLine();
            // Print details of the deposit transaction
            depositTxn.Print();
            Console.WriteLine();
        }

        private static void PerformCashOut(Account stash)
        {
            decimal withdrawAmount;

            Console.WriteLine("Enter the amount you want to withdraw: ");
            withdrawAmount = Convert.ToDecimal(Console.ReadLine());

            // Create a new WithdrawTransaction
            WithdrawTransaction withdrawTxn = new WithdrawTransaction (stash, withdrawAmount);

            try
            {
                // Execute the withdrawal transaction
                withdrawTxn.Execute();
                Console.WriteLine("Withdrawal successful!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Withdrawal failed: {ex.Message}");
            }

            Console.WriteLine();
            // Print details of the withdrawal transaction
            withdrawTxn.Print();
            Console.WriteLine();
        }

        private static void PerformMove(Account fromStash, Account toStash)
        {
            decimal transferAmount;
            Console.WriteLine("Enter the amount you want to transfer: ");
            transferAmount = Convert.ToDecimal(Console.ReadLine());

            if (transferAmount > fromStash.Balance)
            {
                throw new Exception("Cannot transfer amount as you do not have enough balance in your account.");
            }
            else
            {
                // Create a new TransferTransaction
                TransferTransaction transferTxn = new TransferTransaction (fromStash, toStash, transferAmount);
                try
                {
                    // Execute the transfer transaction
                    transferTxn.Execute();
                    Console.WriteLine("Transfer successful!");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Transfer failed: {ex.Message}");
                }

                Console.WriteLine();
                // Print details of the transfer transaction
                transferTxn.Print();
                Console.WriteLine();
            }
        }
    }
}
