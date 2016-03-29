using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TicTacToe.Tests
{
    [TestClass()]
    public class HumanPlayerTests
    {
        [TestMethod()]
        public void GetMoveSmallBoardTest()
        {
            HumanPlayer human = new HumanPlayer();
            Game game = new Game(9);
            game.console = new ConsoleIO(new MockedInput("5"), new MockedOutput());

            int selection = human.GetMove(game);

            Assert.AreEqual(4, selection);
        }

        [TestMethod()]
        public void GetMoveLargeBoardTest()
        {
            HumanPlayer human = new HumanPlayer();
            Game game = new Game(16);
            game.console = new ConsoleIO(new MockedInput("16"), new MockedOutput());

            int selection = human.GetMove(game);

            Assert.AreEqual(15, selection);
        }
    }
}