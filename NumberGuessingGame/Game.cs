using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumberGuessingGame
{
    public class Game
    {
        private Settings settings;
        private Random random = new Random();

        public Game(Settings settings)
        {
            this.settings = settings;
        }

        public void Play()
        {
            while (true)
            {
                Console.Clear();
                int min = settings.Min;
                int max = settings.Max;

                int target = random.Next(min, max + 1);

                int tries = 0;

                Console.WriteLine("Ich habe mir eine Zahl zwischen " + min + " und " + max + " ausgedacht.");
                Console.WriteLine("Versuchen Sie, sie zu erraten!");
                Console.WriteLine();

                while (true)
                {
                    Console.Write("Dein Tipp: ");
                    string? input = Console.ReadLine();

                    if (!int.TryParse(input, out int guess))
                    {
                        Console.WriteLine("Bitte geben Sie eine gültige Zahl ein.");
                        continue;
                    }

                    if (guess < min || guess > max)
                    {
                        Console.WriteLine("Bitte geben Sie eine Zahl innerhalb des Bereichs ein.");
                        continue;
                    }

                    tries++;

                    if (guess < target)
                    {
                        Console.WriteLine("Too low!");
                    }
                    else if (guess > target)
                    {
                        Console.WriteLine("Too high!");
                    }
                    else
                    {
                        Console.WriteLine($"Correct! Du hast {tries} Versuche gebraucht.");
                        break;
                    }
                }

                Console.WriteLine();
                Console.Write("Nochmal spielen? (j/n): ");
                string? again = Console.ReadLine();

                if (again == null || again.Trim().ToLower() != "j")
                    break; // zurück ins Hauptmenü
            }
        }
    }
}
