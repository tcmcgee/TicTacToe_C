namespace TicTacToe
{
    internal class StartGame
    {
        public static Game BuildGame(ConsoleIO IO)
        {
            int boardSize = IO.GetBoardSize();
            IPlayer player1 = IO.GetPlayerType(1);
            IPlayer player2 = IO.GetPlayerType(2);
            Game game = new Game(boardSize, player1, player2);
            return game;
        }

        public static void Main(string[] args)

        {
            ConsoleIO IO = new ConsoleIO(new ConsoleInput(), new ConsoleOutput());
            Game game = BuildGame(IO);
            game.StartGame();
        }
    }
}