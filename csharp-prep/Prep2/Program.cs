using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello Prep2 World!");

        //Getting info
        Console.Write("What is your grade percentage? ");
        string textGradePercentage = Console.ReadLine();
        int GradePercentage = int.Parse(textGradePercentage);
        string letter = "";

        //Grades
        // I kept the Console.WriteLine in there because I wanted to keep all the parts of the assignment it had me do.
        if (GradePercentage >=  90)
        {
            Console.WriteLine("You have an A.");
            letter = "A";
        }
        else if (GradePercentage >= 80)
        {
            Console.WriteLine("You have an B.");
            letter = "B";
        }
        else if (GradePercentage >= 70)
        {
            Console.WriteLine("You have an C.");
            letter = "C";
        }
        else if (GradePercentage >= 60)
        {
            Console.WriteLine("You have an D.");
            letter = "D";
        }
        else if (GradePercentage < 60)
        {
            Console.WriteLine("You have an F.");
            letter = "F";
        }
        else
        {
            Console.WriteLine("Improper Input. Self Destruction is immenent");
        }
        //Pass or fail?
        if (GradePercentage >= 70)
        {
            Console.WriteLine("You passed the class! Congratulations!");
        }
        else
        {
            Console.WriteLine("Sorry. You did not pass. Better luck next time! ");
        }

        //Letter
        Console.WriteLine($"You have an {letter}");
    }
}