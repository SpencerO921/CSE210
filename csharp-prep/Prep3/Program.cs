using System;
using System.Security.Cryptography;

class Program
{
    static void Main(string[] args)
    {
        Random randomGenerator = new Random();
        int intMagicNumber = randomGenerator.Next(1,101);
       // Console.WriteLine("Hello Prep3 World!");
      //  Console.Write("What is the magic number?");
      //  string textMagicNumber = Console.ReadLine();
        //int intMagicNumber = int.Parse(textMagicNumber);
        //int intNumberGuess = null;
        int intNumberGuess = 0;

        while (intNumberGuess != intMagicNumber)
        {
            Console.Write("What is your guess? ");
            string textGuess = Console.ReadLine();
            intNumberGuess = int.Parse(textGuess);
            if (intNumberGuess > intMagicNumber)
            {
                Console.WriteLine("Magic Number is Lower.");
            }
            else if (intNumberGuess < intMagicNumber)
            {
                Console.WriteLine("Magic Number is Higher");
            }
            else if (intNumberGuess == intMagicNumber)
            {
                Console.WriteLine("You guessed it!");
            }
            else
            {
                Console.WriteLine("Invalid input.");
            }
        }
    }
}