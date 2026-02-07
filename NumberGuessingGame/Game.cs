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
        private Stats stats;
        private Random random = new Random();

        public Game(Settings settings, Stats stats)
        {
            this.settings = settings;
            this.stats = stats;
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

                Console.WriteLine("I have chosen a number between " + min + " and " + max + ".");
                Console.WriteLine("Try to guess it!");
                Console.WriteLine();

                while (true)
                {
                    Console.Write("Your guess ");
                    string? input = Console.ReadLine();

                    if (!int.TryParse(input, out int guess))
                    {
                        Console.WriteLine("Please enter a valid number");
                        continue;
                    }

                    if (guess < min || guess > max)
                    {
                        Console.WriteLine("Please enter a number within the valid range.");
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
                        Console.WriteLine($"Correct! You needed {tries} attempts.");
                        stats.UpdateStats(tries);
                        break;
                    }
                }

                Console.WriteLine();
                Console.Write("Play again? (y/n): ");
                string? again = Console.ReadLine();

                if (again == null || again.Trim().ToLower() != "y")
                    break; // zurück ins Hauptmenü
            }
        }
    }
}
