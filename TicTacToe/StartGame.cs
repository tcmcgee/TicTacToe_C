namespace TicTacToe
{
    internal class StartGame
    {
        public static Game ThreeByThreeVsComputer()
        {
            return new Game(9, new HumanPlayer(), new ComputerPlayer());
        }

        public static Game ThreeByThreeVsHuman()
        {
            return new Game(9, new HumanPlayer(), new HumanPlayer());
        }

        public static Game FourByFourVsComputer()
        {
            return new Game(16, new HumanPlayer(), new ComputerPlayer());
        }

        public static Game FourByFourVsHuman()
        {
            return new Game(16, new HumanPlayer(), new HumanPlayer());
        }

        public static void Main(string[] args)

        {
            Game game = StartGame.ThreeByThreeVsComputer();
            game.StartGame();
        }
    }
}