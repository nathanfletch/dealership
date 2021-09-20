using System;
using System.Collections.Generic;
using Dealership.Models;

namespace Dealership
{
  public class Program
  {
    private static string _password = "12345";

    public static bool passwordIsCorrect(string enteredPassword)
    {
      return enteredPassword == Program._password;
    }

    public static void Main()
    {
      Car volkswagen = new Car("1974 Volkswagen Thing", 1100, 368792);
      Car yugo = new Car("1980 Yugo Koral", 700, 56000);
      Car ford = new Car("1988 Ford Country Squire", 1400, 239001);
      Car amc = new Car("1976 AMC Pacer", 400, 198000);

      List<Car> Cars = new List<Car>() { volkswagen, yugo, ford, amc, };


      Console.WriteLine("Are you a customer? ");
      string isCustomer = Console.ReadLine();
      if (isCustomer.ToUpper() != "Y") 
      {
        Console.WriteLine($"Please enter your password: ");
        string password = Console.ReadLine();
        if (passwordIsCorrect(password))
        {
          Console.WriteLine($"Enter the new price for the yugo: ");
          int price = int.Parse(Console.ReadLine());
          yugo.SetPrice(price);
          Console.WriteLine($"The yugo now costs " + yugo.GetPrice());
          
        }
        else
        {
          Console.WriteLine($"Sorry, that password is incorrect. Goodbye!");
          
        }
      }

      Console.WriteLine("WELCOME TO THE DEALERSHIP");
      Console.WriteLine("Are you buying or selling today? [Enter B for buying or S for selling]");
      string buySell = Console.ReadLine();
      if (buySell == "B") 
      {
      Console.WriteLine($"Enter max price");
      string stringMaxPrice = Console.ReadLine();
      int maxPrice = int.Parse(stringMaxPrice);
      
      List<Car> CarsInBudget = new List<Car>(0);

      foreach(Car automobile in Cars) {
        if (automobile.IsInBudget(maxPrice)) 
        {
          CarsInBudget.Add(automobile);
        }
      }

      foreach(Car automobile in CarsInBudget)
      {
        Console.WriteLine($"-----------------");
        
        Console.WriteLine(automobile.GetMakeModel());
      
        Console.WriteLine("$" +automobile.GetPrice());
      
        Console.WriteLine(automobile.GetMiles() + " miles");
      }
      }
      if (buySell == "S") 
      {
        Console.WriteLine("Please enter your car's Make & Model");
        string newMakeModel = Console.ReadLine();
        Console.WriteLine("Please enter your car's mileage");
        int newMiles = int.Parse(Console.ReadLine());
        Console.WriteLine("How much do you want for your car?");
        int askingPrice = int.Parse(Console.ReadLine());
        Car brandNewCar = new Car(newMakeModel, (askingPrice * 2), newMiles);
        Cars.Add(brandNewCar);
        Console.WriteLine("We now own your car: " + brandNewCar.GetMakeModel() + " It now costs" + " " + brandNewCar.GetPrice());
      }
      
    }
  }
  }