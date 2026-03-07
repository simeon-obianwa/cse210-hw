using System;

namespace GuessMyNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            // Variable to control the outer loop (Play Again)
            bool playAgain = true;

            // Loop back and play the whole game again
            while (playAgain)
            {
                // Generate a random number from 1 to 100
                // Ask the user for the magic number
                Random random = new Random();
                int magicNumber = random.Next(1, 101);

                // Initialize guess to a value that ensures the loop starts
                int guess = -1;

                // Keep track of how many guesses the user has made
                int guessCount = 0;

                // Loop that keeps looping as long as the guess does not match
                while (guess != magicNumber)
                {
                    // Ask the user for a guess
                    Console.Write("What is your guess? ");
                    string input = Console.ReadLine();
                    
                    // Convert input to integer
                    guess = int.Parse(input);
                    
                    // Increment the guess counter
                    guessCount++;

                    // If statement to determine higher, lower, or correct
                    if (guess < magicNumber)
                    {
                        Console.WriteLine("Higher");
                    }
                    else if (guess > magicNumber)
                    {
                        Console.WriteLine("Lower");
                    }
                    else
                    {
                        Console.WriteLine("You guessed it!");
                    }
                }

                // Inform them of the guess count at the end
                Console.WriteLine($"You took {guessCount} guesses.");
                Console.WriteLine();

                // Ask the user if they want to play again
                Console.Write("Do you want to play again? ");
                string response = Console.ReadLine();

                // When user type anything other than "yes", the game ends
                if (response.ToLower() != "yes")
                {
                    playAgain = false;
                }
                else
                {
                    Console.WriteLine();
                }
            }
        }
    }
}