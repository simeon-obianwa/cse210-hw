using System;

namespace SimpleFunctions
{
    class Program
    {
        static void Main(string[] args)
        {
            // Call DisplayWelcome function
            DisplayWelcome();

            // Call PromptUserName and save the return value
            string userName = PromptUserName();

            // Call PromptUserNumber and save the return value
            int favoriteNumber = PromptUserNumber();

            // Call SquareNumber and save the return value
            int squaredNumber = SquareNumber(favoriteNumber);

            // Call DisplayResult with the name and squared number
            DisplayResult(userName, squaredNumber);
        }

        // DisplayWelcome - Displays the welcome message
        static void DisplayWelcome()
        {
            Console.WriteLine("Welcome to the Program!");
        }

        // PromptUserName - Asks for and returns the user's name
        static string PromptUserName()
        {
            Console.Write("Please enter your name: ");
            string name = Console.ReadLine();
            return name;
        }

        // Asks for and returns the user's favorite number
        static int PromptUserNumber()
        {
            Console.Write("Please enter your favorite number: ");
            int number = int.Parse(Console.ReadLine());
            return number;
        }

        // SquareNumber - Accepts an integer and returns it squared
        static int SquareNumber(int number)
        {
            int squared = number * number;
            return squared;
        }

        // DisplayResult - Accepts name and squared number, displays them
        static void DisplayResult(string name, int squaredNumber)
        {
            Console.WriteLine($"{name}, the square of your number is {squaredNumber}");
        }
    }
}