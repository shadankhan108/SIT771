using System;
using SplashKitSDK;
namespace Arrays
{
    
public class Program
{

public static void Main()
 {
 int numberOfValues;
 double sum = 0;

 Console.WriteLine("Enter how many value you want to store in the array:,! ");
 numberOfValues = ReadInteger(Console.ReadLine());

 double[] values = new double[numberOfValues];

 for (int i = 0; i < numberOfValues; i++)
 {
Console.WriteLine($"Enter the {i + 1}st value: ");
 values[i] = ReadDouble(Console.ReadLine());
sum = sum + values[i];
}

Console.WriteLine();
Console.WriteLine("Your array is: ");
for (int i = 0; i < numberOfValues; i++)
{
Console.WriteLine(values[i]);
}

Console.WriteLine();
Console.WriteLine("Total sum of all the numbers in the array is: " +sum);
}


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

 
}
}
