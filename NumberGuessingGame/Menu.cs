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

        public Menu(Settings settings, Game game)
        {
            this.settings = settings;
            this.game = game;
        }

        public void Run()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("=== Number Guessing Game ===");
                Console.WriteLine("Current Range: " + settings.Min + " to " + settings.Max);
                Console.WriteLine();
                Console.WriteLine("1) Spiel starten");
                Console.WriteLine("2) Einstellungen (Bereich ändern)");
                Console.WriteLine("3) Beenden");
                Console.WriteLine();
                Console.Write("Wählen Sie eine Option: ");

                string? choice = Console.ReadLine();

                bool keepRunning = HandleChoice(choice);

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
                        Console.WriteLine("Danke fürs Spielen! Auf Wiedersehen!");
                        return false;
                default:
                    Console.WriteLine("Ungültige Auswahl. Bitte versuchen Sie es erneut.");
                    Console.ReadKey();
                    return true;
            }
        }
    }
}
