using System;

class Program
{
    //In class
    
    static void Main(string[] args)
    {
        Console.WriteLine("Hello Prep5 World!");
        int number = PromptUserNumber();
        Console.WriteLine($"Your number is: {number}");
    }

    static int PromptUserNumber()
    {
        Console.Write("Please enter your favorite number: ");
        Console.ReadLine();
        int number = int.Parse(Console.ReadLine());
        return number;
    }
}