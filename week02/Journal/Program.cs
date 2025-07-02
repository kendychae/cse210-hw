using System;

class Program
{
    static void Main(string[] args)
    {
        Journal journal = new Journal();
        PromptGenerator promptGenerator = new PromptGenerator();

        string choice = "";

        while (choice != "5")
        {
            Console.WriteLine("Please select one of the following choices:");
            Console.WriteLine("1. Write a new entry");
            Console.WriteLine("2. Display the journal");
            Console.WriteLine("3. Save the journal to a file");
            Console.WriteLine("4. Load the journal from a file");
            Console.WriteLine("5. Quit");

            Console.Write("What would you like to do? ");
            choice = Console.ReadLine();

            if (choice == "1")
            {
                string prompt = promptGenerator.GetRandomPrompt();
                Console.WriteLine(prompt);
                Console.Write("> ");
                string response = Console.ReadLine();

                Entry newEntry = new Entry
                {
                    _date = DateTime.Now.ToShortDateString(),
                    _promptText = prompt,
                    _entryText = response
                };

                journal.AddEntry(newEntry);
            }
            else if (choice == "2")
            {
                journal.DisplayAll();
            }
            else if (choice == "3")
            {
                Console.Write("Enter filename to save to: ");
                string fileName = Console.ReadLine();
                journal.SaveToFile(fileName);
                Console.WriteLine("Journal saved.");
            }
            else if (choice == "4")
            {
                Console.Write("Enter filename to load from: ");
                string fileName = Console.ReadLine();
                journal.LoadFromFile(fileName);
                Console.WriteLine("Journal loaded.");
            }
            else if (choice == "5")
            {
                Console.WriteLine("Goodbye!");
            }
            else
            {
                Console.WriteLine("Invalid choice. Please try again.");
            }

            Console.WriteLine();
        }
    }
}
