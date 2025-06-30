using System;

class Program
{
    static void Main()
    {
        // Prompt user for first name
        Console.Write("What is your first name? ");
        string firstName = Console.ReadLine();

        // Prompt user for last name
        Console.Write("What is your last name? ");
        string lastName = Console.ReadLine();

        // Display the formatted output
        Console.WriteLine();
        Console.WriteLine($"Your name is {lastName}, {firstName} {lastName}.");
    }
}
