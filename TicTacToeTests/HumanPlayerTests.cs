using TicTacToe;
using Xunit;

namespace TicTacToeTests
{
    public class HumanPlayerTests
    {
        [Fact]
        public void GetMoveSmallBoardTest()
        {
            HumanPlayer human = new HumanPlayer();
            Game game = new Game(9);
            game.console = new ConsoleIO(new MockedInput("5"), new MockedOutput());

            int selection = human.GetMove(game);

            Assert.Equal(4, selection);
        }

        [Fact]
        public void GetMoveLargeBoardTest()
        {
            HumanPlayer human = new HumanPlayer();
            Game game = new Game(16);
            game.console = new ConsoleIO(new MockedInput("16"), new MockedOutput());

            int selection = human.GetMove(game);

            Assert.Equal(15, selection);
        }
    }
}