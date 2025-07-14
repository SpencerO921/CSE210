using System;

public class Program
{
    static void Main(string[] args)
    {
        //Console.WriteLine("Hello Learning03 World!");
        Console.WriteLine("Fractions Program");
        Fraction f1 = new Fraction();
        Fraction f3 = new Fraction(3, 4);
        Fraction f5 = new Fraction(5, 1);
        Console.WriteLine(f1.GetFractionString());
        Console.WriteLine(f1.GetDecimalValue());
        Console.WriteLine(f3.GetFractionString());
        Console.WriteLine(f3.GetDecimalValue());
        Console.WriteLine(f5.GetFractionString());
        Console.WriteLine(f5.GetDecimalValue());
        


    }
}