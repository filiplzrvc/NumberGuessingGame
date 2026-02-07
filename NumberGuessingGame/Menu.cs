using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumberGuessingGame
{
    public class Menu
    {
        private Settings settings;
        private Game game;
        private Stats stats;

        public Menu(Settings settings, Game game, Stats stats)
        {
            this.settings = settings;
            this.game = game;
            this.stats = stats;
        }

        public void Run()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("=== Number Guessing Game ===");
                Console.WriteLine("Current Range: " + settings.Min + " to " + settings.Max);
                Console.WriteLine();
                Console.WriteLine("1) Start game");
                Console.WriteLine("2) Settings (change range)");
                Console.WriteLine("3) Show statistics");
                Console.WriteLine("4) Exit");
                Console.WriteLine();
                Console.Write("Choose an option: ");

                string? choice = Console.ReadLine();

               bool keepRunning = HandleChoice(choice ?? "");

                if (!keepRunning)
                    break;
            } 
        }

        public bool HandleChoice(string choice)
        {
            switch (choice)
                {
                    case "1":
                        game.Play();
                        Console.ReadKey();
                        return true;
                    case "2":
                        settings.ChangeSettings();
                        return true;
                    case "3":
                        ShowStatistics();
                        return true;
                    case "4":
                        Console.WriteLine("Thanks for playing! Goodbye!");
                        return false;
                default:
                        Console.WriteLine("Invalid selection. Please try again.");
                        Console.ReadKey();
                        return true;
            }
        }

        private void ShowStatistics()
        {
            Console.Clear();
            Console.WriteLine("=== Statistics ===");
            Console.WriteLine($"Games Played: {stats.GamesPlayed}");
            Console.WriteLine($"Best Attempts: {(stats.BestAttempts.HasValue ? stats.BestAttempts.Value.ToString() : "N/A")}");
            Console.WriteLine();
            Console.WriteLine("Press any key to return to the menu...");
            Console.ReadKey();
        }
    }
}
