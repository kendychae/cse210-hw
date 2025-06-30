using System;

class Program
{
    static void Main()
    {
        string playAgain;

        do
        {
            // Generate random number between 1 and 100
            Random randomGenerator = new Random();
            int magicNumber = randomGenerator.Next(1, 101); // upper bound is exclusive

            int guess = -1;
            int guessCount = 0;

            Console.WriteLine("Welcome to the Guess My Number game!");

            // Loop until the guess is correct
            while (guess != magicNumber)
            {
                Console.Write("What is your guess? ");
                string input = Console.ReadLine();
                guess = int.Parse(input);
                guessCount++;

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
                    Console.WriteLine($"It took you {guessCount} guesses.");
                }
            }

            // Ask if they want to play again
            Console.Write("Do you want to play again? (yes/no): ");
            playAgain = Console.ReadLine().ToLower();
            Console.WriteLine();

        } while (playAgain == "yes");

        Console.WriteLine("Thanks for playing!");
    }
}
