namespace TicTacToe
{
    internal class StartGame
    {
        public static Game BuildGame(ConsoleIO IO)
        {
            int boardSize = IO.GetBoardSize();
            IPlayer player1 = GetPlayer(IO.GetPlayerType(1));
            IPlayer player2 = GetPlayer(IO.GetPlayerType(2));
            Game game = new Game(boardSize, player1, player2, IO);
            return game;
        }

        public static IPlayer GetPlayer(bool IsHumanPlayer)
        {
            if (IsHumanPlayer)
            {
                return new HumanPlayer();
            }
            else
            {
                return new ComputerPlayer();
            }
        }

        public static void Main(string[] args)

        {
            ConsoleIO IO = new ConsoleIO(new ConsoleInput(), new ConsoleOutput());
            Game game = BuildGame(IO);
            game.StartGame();
        }
    }
}