namespace NumberGuessingGame
{
    class Program
    {
        static void Main(string[] args)
        {
            var settings = new Settings();
            var stats = new Stats();
            var game = new Game(settings, stats);
            var menu = new Menu(settings, game, stats);

            menu.Run();
        }
    }
}
