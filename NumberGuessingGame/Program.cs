namespace NumberGuessingGame
{
    class Program
    {
        static void Main(string[] args)
        {
            var settings = new Settings();
            var game = new Game(settings);
            var menu = new Menu(settings, game);

            menu.Run();
        }
    }
}
