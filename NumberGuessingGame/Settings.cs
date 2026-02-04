using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumberGuessingGame
{
    public class Settings
    {
        public int Min { get; private set; }
        public int Max { get; private set; }

        public Settings(int min = 1, int max = 100)
        {
            Min = min;
            Max = max;
        }

        public void ChangeSettings()
        {
            Console.Clear();
            Console.WriteLine("=== Settings ===");
            Console.WriteLine("Here you can change the number range.");
            Console.WriteLine();

            int newMin = ReadInt("New minimum: ");
            int newMax = ReadInt("New maximum: ");

            while (newMax <= newMin)
            {
                Console.WriteLine("Maximum must be greater then minimum.");
                newMin = ReadInt("New minimum: ");
                newMax = ReadInt("New maximum: ");
            }

            Min = newMin;
            Max = newMax;

            Console.WriteLine($"Saved! New range: {Min} - {Max}");
            Console.WriteLine("Press any key to return to the menu...");
            Console.ReadKey();
        }

        static int ReadInt(string prompt)
        {
            while (true)
            {
                Console.Write(prompt);
                string? input = Console.ReadLine();

                if (int.TryParse(input, out int value))
                    return value;

                Console.WriteLine("Please enter a valid number.");
            }
        }

    }
}
