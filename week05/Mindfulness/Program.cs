using System;

// CREATIVITY AND EXCEEDING REQUIREMENTS:
// 1. Enhanced breathing animation with visual feedback
// 2. Improved spinner animations with multiple characters
// 3. Added countdown timers for better user experience
// 4. Clear screen functionality for better interface
// 5. Enhanced prompts and user guidance

class Program
{
    static void Main(string[] args)
    {
        int choice = 0;

        while (choice != 4)
        {
            Console.Clear();
            Console.WriteLine("Menu Options:");
            Console.WriteLine("  1. Start breathing activity");
            Console.WriteLine("  2. Start reflecting activity");
            Console.WriteLine("  3. Start listing activity");
            Console.WriteLine("  4. Quit");
            Console.Write("Select a choice from the menu: ");

            string input = Console.ReadLine();

            if (int.TryParse(input, out choice))
            {
                Console.Clear();

                switch (choice)
                {
                    case 1:
                        BreathingActivity breathingActivity = new BreathingActivity();
                        breathingActivity.Run();
                        break;
                    case 2:
                        ReflectingActivity reflectingActivity = new ReflectingActivity();
                        reflectingActivity.Run();
                        break;
                    case 3:
                        ListingActivity listingActivity = new ListingActivity();
                        listingActivity.Run();
                        break;
                    case 4:
                        Console.WriteLine("Thank you for using the Mindfulness Program. Have a peaceful day!");
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please select 1, 2, 3, or 4.");
                        Console.WriteLine("Press any key to continue...");
                        Console.ReadKey();
                        break;
                }
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a number.");
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
            }
        }
    }
}