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
            Console.WriteLine("=== Einstellungen ===");
            Console.WriteLine("Hier kannst du den Zahlenbereich ändern.");
            Console.WriteLine();

            int newMin = ReadInt("Neues Minimum: ");
            int newMax = ReadInt("Neues Maximum: ");

            while (newMax <= newMin)
            {
                Console.WriteLine("Maximum muss größer als Minimum sein.");
                newMin = ReadInt("Neues Minimum: ");
                newMax = ReadInt("Neues Maximum: ");
            }

            Min = newMin;
            Max = newMax;

            Console.WriteLine($"Gespeichert! Neuer Bereich: {Min} - {Max}");
            Console.WriteLine("Drücke eine Taste, um ins Menü zurückzukehren...");
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

                Console.WriteLine("Bitte geben Sie eine gültige Zahl ein.");
            }
        }

    }
}
