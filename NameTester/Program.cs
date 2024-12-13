using System;
using SplashKitSDK;

namespace NameTester
{
    using System;

public enum MenuOption
{
    TestName = 1,
    GuessThatNumber,
    Quit
}

public class Program
{
    public static void Main()
    {
        MenuOption userSelection;
        do
        {
            userSelection = ReadUserOption();
            switch (userSelection)
            {
                case MenuOption.TestName:
                    TestName();
                    break;
                case MenuOption.GuessThatNumber:
                    RunGuessThatNumber();
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
            Console.WriteLine("1. Test Name");
            Console.WriteLine("2. Guess That Number");
            Console.WriteLine("3. Quit");
            Console.Write("Choose an option [1-3]: ");
            if (!Enum.TryParse(Console.ReadLine(), out option))
            {
                Console.WriteLine("Invalid input, please enter a number.");
                option = (MenuOption)(-1);
            }
        } while (option < MenuOption.TestName || option > MenuOption.Quit);
        return option;
    }

    private static void TestName()
    {
        Console.Write("Enter your name: ");
        string name = Console.ReadLine();
        Console.WriteLine($"Hello {name}!");
        if (name.ToLower() == "shadan")
        {
            Console.WriteLine("Welcome my creator!");
        }
        else if (name.ToLower() == "jacob")
        {
            Console.WriteLine("Hello Jacob!");
        }
        else
        {
            Console.WriteLine("You have a nice name!");
        }
    }

    private static void RunGuessThatNumber()
    {
        Random random = new Random();
        int target = random.Next(1, 101);
        int guess;
        int lowestGuess = 1;
        int highestGuess = 100;
        Console.WriteLine("Guess a number between 1 and 100.");
        do
        {
            guess = ReadGuess(lowestGuess, highestGuess);
            if (guess < target)
            {
                Console.WriteLine("Too low! Try a higher number.");
                lowestGuess = guess + 1;
            }
            else if (guess > target)
            {
                Console.WriteLine("Too high! Try a lower number.");
                highestGuess = guess - 1;
            }
            else
            {
                Console.WriteLine("Congratulations! You guessed the number!");
            }
        } while (guess != target);
    }

    private static int ReadGuess(int min, int max)
    {
        int guess;
        bool isValidGuess;
        do
        {
            Console.Write($"Enter your guess between {min} and {max}: ");
            isValidGuess = int.TryParse(Console.ReadLine(), out guess);
            if (!isValidGuess || guess < min || guess > max)
            {
                Console.WriteLine("Invalid input. Please enter a valid number between {min} and {max}.");
            }
        } while (!isValidGuess || guess < min || guess > max);
        return guess;
    }
}


}
