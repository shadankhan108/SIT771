using System;
using SplashKitSDK;


namespace ListProgram
{
public class Program
{
private static List<double> _values = new List<double>();

public static int ReadInteger(string prompt)
{
while (true)
{
try
{
return Int32.Parse(prompt);
}
catch
{
Console.WriteLine("Please enter a valid number.");
}
}
}
public static Double ReadDouble(string prompt)
{
while (true)
{
try
{
return Double.Parse(prompt);
}
catch
{
Console.WriteLine("Please enter a valid number.");
}
}
}
public enum UserOptions
{
NewValue,
Sum,
Print,
Quit
}
public static void AddValueToList()
{
Console.WriteLine("Enter a new value: ");
double newValue = ReadDouble(Console.ReadLine());
_values.Add(newValue);
Console.WriteLine($"Value {newValue} added to the list.");
}
public static void Print()
{
if (_values.LongCount() == 0)
{
Console.WriteLine("List is empty!");
}
else
{
Console.WriteLine("Values in the list:");
foreach (var value in _values)
{
Console.WriteLine(value);
}
}
}
public static void Sum()
{
double sum = 0;
foreach (var value in _values)
{
sum += value;
}
Console.WriteLine($"Sum of values: {sum}");
}
public static UserOptions ReadUserOption()
{
Console.WriteLine("Enter 0 to add a value");
Console.WriteLine("Enter 1 to sum all values");
Console.WriteLine("Enter 2 to print all values");
Console.WriteLine("Enter 3 to quit");
int option = 3;
Int32.TryParse(Console.ReadLine(), out option);
return (UserOptions)option;
}
public static void Main()
{
UserOptions userOptions;
do
{
userOptions = ReadUserOption();
switch (userOptions)
{
case UserOptions.NewValue:
Console.WriteLine();
AddValueToList();
Console.WriteLine();
break;
case UserOptions.Sum:
Console.WriteLine();
Sum();
Console.WriteLine();
break;
case UserOptions.Print:
Console.WriteLine();
Print();
Console.WriteLine();
break;
case UserOptions.Quit:
Console.WriteLine();
break;
default:
Console.WriteLine();
break;
}
} while (userOptions == UserOptions.NewValue || userOptions == UserOptions.Sum || userOptions == UserOptions.Print);
}
}
}
