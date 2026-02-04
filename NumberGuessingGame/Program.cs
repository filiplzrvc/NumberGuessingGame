namespace NumberGuessingGame
{
    class Program
    {
        static void Main(string[] args)
        {
            int min = 1;
            int max = 100;

            while (true)
            {
                Console.Clear();
                Console.WriteLine("=== Number Guessing Game ===");
                Console.WriteLine("Current Range: " + min + " to " + max);
                Console.WriteLine();
                Console.WriteLine("1) Spiel starten");
                Console.WriteLine("2) Einstellungen (Bereich ändern)");
                Console.WriteLine("3) Beenden");
                Console.WriteLine();
                Console.Write("Wählen Sie eine Option: ");

                string? choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        PlayGame(min, max);
                        Console.ReadKey();
                        break;
                    case "2":
                        ChangeSettings(ref min, ref max);
                        break;
                    case "3":
                        Console.WriteLine("Danke fürs Spielen! Auf Wiedersehen!");
                        return;
                }
            }
        }
        static void PlayGame(int min, int max)
        {
            while (true)
            {
                Console.Clear();
                Random random = new Random();
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

        static void ChangeSettings(ref int min, ref int max)
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

            min = newMin;
            max = newMax;

            Console.WriteLine($"Gespeichert! Neuer Bereich: {min} - {max}");
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
