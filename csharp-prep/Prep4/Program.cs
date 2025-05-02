using System;
using System.ComponentModel.DataAnnotations;

class Program
{
    static void Main(string[] args)
    {
        //Console.WriteLine("Hello Prep4 World!");
        List<int> numbers = new List<int>();

        Console.WriteLine("Enter a list of numbers, type 0 when finished.");
        int newNumber = -1;
        //Loop of entering numbers
        while (newNumber != 0)
        {
            Console.Write("Enter number: ");
            string textNewNumber = Console.ReadLine();
            newNumber = int.Parse(textNewNumber);

            if (newNumber != 0)
            {
                numbers.Add(newNumber);
            }
        }
        
        //Sum
        int sum = 0;
        foreach (int number in numbers)
        {
            sum += number;
        }
        Console.WriteLine($"The sum is: {sum}");

        //Average
        float numberAverage = ((float)sum) / numbers.Count;
        Console.WriteLine($"The average is: {numberAverage}");

        //Max
        int max = numbers[0];
    
        foreach (int number in numbers)
        {
            if (number > max)
            {
                max = number;
            }
        }
        Console.WriteLine($"The max is: {max}");


    }
}