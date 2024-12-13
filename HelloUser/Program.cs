using System;
using SplashKitSDK;

namespace HelloUser
{
    public class Program
    {
        public static void Main()
        {

      string name;
      string inputText;
      int heightInCM;
      double heightInMeters;
      double weightInKG;
      double bmi;

      Console.Write("Enter your name: ");
      name = Console.ReadLine();
      Console.WriteLine($"Hello {name}" );

      Console.Write("Enter height in cm ");
      inputText = Console.ReadLine();
      heightInCM = Convert.ToInt32(inputText);
      heightInMeters = heightInCM/100.0 ;
      
      Console.WriteLine($"Your Height in Meter is: {heightInMeters}");

      Console.Write("Enter weight in KG");
      inputText = Console.ReadLine();
      weightInKG = Convert.ToDouble(inputText);
      
      
       Console.WriteLine($"Your Weight in Kg is: {weightInKG}");

       bmi = weightInKG / (heightInMeters * heightInMeters);

       Console.WriteLine($"Your BMI is : {bmi} ");

      
        }
    }
}
