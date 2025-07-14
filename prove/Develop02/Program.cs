// using System;
// using System.Threading.Tasks.Dataflow;

// class Program
// {
//         static void Main(string[] args)
//     {
//         //Console.WriteLine("Hello Develop02 World!");
//         //Journal activity
//         Journal journal = new();

//         def static DisplayMenu()
//         {
//             Console.WriteLine("Choose an integer option.");
//             Console.WriteLine("1) Write a new entry");
//             Console.WriteLine("2) Display a journal");
//             Console.WriteLine("3) Save Journal to a file");
//             Console.WriteLine("4) Load Journal from a file");
//             Console.WriteLine("5) Exit");
//         }

//         GetChoice();
//         def static ShowPrompt();
//         {
//             List<string> prompts =
//             [
//             "Who was the most interesting person I interacted with today?",
//             "What was the best part of my day?",
//             "How did I see the hand of the Lord in my life today?",
//             "What was the strongest emotion I felt today?",
//             "If I had one thing I could do over today, what would it be?"
//             ]
//         }
//         AddEntry();
//         {
//             // Who was the most interesting person I interacted with today?
//             // What was the best part of my day?
//             // How did I see the hand of the Lord in my life today?
//             // What was the strongest emotion I felt today?
//             // If I had one thing I could do over today, what would it be?
//         }


//     }
// }


// class Journal
// {
//     string 

// }

// class Entry
// {
//     DateTime


// }


// DateTime theCurrentTime = DateTime.now;
// string dateText = theCurrentTime.ToShortDateString();


// 3 classes. Program, Journal, and Entry class




class Program
{
    static void Main(string[] args)
    {
        Job job1 = new Job();
        job1._jobTitle = "Software Engineer";
        job1._company = "Microsoft";
        job1._startYear = 2019;
        job1._endYear = 2022;

        Job job2 = new Job();
        job2._jobTitle = "Manager";
        job2._company = "Apple";
        job2._startYear = 2022;
        job2._endYear = 2023;

        Resume myResume = new Resume();
        myResume._name = "Allison Rose";

        myResume._jobs.Add(job1);
        myResume._jobs.Add(job2);

        myResume.Display();
    }
}