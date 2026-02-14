using System;

/*
EXCEEDING REQUIREMENTS:
- Added a fourth activity called GratitudeActivity.
- Maintained proper inheritance structure.
- Implemented animations (spinner and countdown).
- Clean looping menu system.
*/

class Program
{
    static void Main()
    {
        string choice = "";

        while (choice != "5")
        {
            Console.Clear();
            Console.WriteLine("Mindfulness Program");
            Console.WriteLine("-------------------");
            Console.WriteLine("1. Breathing Activity");
            Console.WriteLine("2. Reflecting Activity");
            Console.WriteLine("3. Listing Activity");
            Console.WriteLine("4. Gratitude Activity");
            Console.WriteLine("5. Quit");

            Console.Write("\nSelect a choice from the menu: ");
            choice = Console.ReadLine();

            if (choice == "1")
            {
                new BreathingActivity().Run();
            }
            else if (choice == "2")
            {
                new ReflectingActivity().Run();
            }
            else if (choice == "3")
            {
                new ListingActivity().Run();
            }
            else if (choice == "4")
            {
                new GratitudeActivity().Run();
            }
        }
    }
}