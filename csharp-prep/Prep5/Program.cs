using System;
using System.Globalization;

class Program
{
    
    static void Main(string[] args)
    {
        //Console.WriteLine("Hello Prep5 World!");
        DisplayWelcome();

        string userName = PromptUserName();
        int number = PromptUserNumber();
        
        //Below is something written in class
        //Console.WriteLine($"Your number is: {number}");

        int SquaredNumber = SquareNumber(number);

        DisplayResult(userName, SquaredNumber);
    }

    static void DisplayWelcome()
    {
        Console.WriteLine("Welcome to the Program!");
    }

    static string PromptUserName()
    {
        Console.Write("What is your name? ");
        string name = Console.ReadLine();

        return name;
    }
    
    static int PromptUserNumber()
    {
        Console.Write("Please enter your favorite number: ");
        string textFavoriteNumber = Console.ReadLine();
        int number = int.Parse(textFavoriteNumber);
        return number;
    }
    
    static int SquareNumber(int number)
    {
        int square = number * number;
        return square;
    }
    
    static void DisplayResult(string name, int square)
    {
        Console.WriteLine($"{name}, your number squared is {square}");
    }
}