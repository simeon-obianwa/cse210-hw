using System;

class Program
{
    static void Main(string[] args)
    {
        // Core Requirement 1: Ask user for their grade percentage
        Console.Write("What is your grade percentage? ");

        int grade = int.Parse(Console.ReadLine());

        // Core Requirement 3: Create a variable called 'letter'
        string letter = "";

        // Core Requirement 1 & 3: Determine letter grade using if/else if/else
        if (grade >= 90)
        {
            letter = "A";
        }
        else if (grade >= 80)
        {
            letter = "B";
        }
        else if (grade >= 70)
        {
            letter = "C";
        }
        else if (grade >= 60)
        {
            letter = "D";
        }
        else
        {
            letter = "F";
        }

        // Core Requirement 3: Single print statement that prints the letter grade
        Console.WriteLine($"Your letter grade is {letter}");

        // Core Requirement 2: Separate if statement to determine if the user passed
        // The user must have at least a 70 to pass the class
        if (grade >= 70)
        {
            Console.WriteLine("Congratulations! You passed the course.");
        }
        else
        {
            Console.WriteLine("Keep trying! You didn't pass this time, but you can do it next time.");
        }
    }
}