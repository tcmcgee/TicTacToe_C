namespace TicTacToe
{
    internal class StartGame
    {
        private static void Main(string[] args)
        {
            Game game = new Game(9);
            game.StartGame();
        }
    }
}