using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TicTacToe.Tests
{
    internal class MockedInput : IUserInput
    {
        private string returnValue;

        public MockedInput(string returnValue)
        {
            this.returnValue = returnValue;
        }

        public string GetInput()
        {
            return this.returnValue;
        }
    }

    internal class MockedOutput : IUserOutput
    {
        public void Display(string str)
        {
        }
    }

    [TestClass()]
    public class ConsoleIOTests
    {
        [TestMethod()]
        public void DisplayWelcomeMessageTest()
        {
            ConsoleIO console = new ConsoleIO(new MockedOutput());

            Assert.AreEqual(console.DisplayWelcomeMessage(), "Welcome to Tic Tac Toe!");
        }

        [TestMethod()]
        public void DisplayEmptyBoardTest()
        {
            ConsoleIO console = new ConsoleIO(new MockedOutput());
            Board emptyBoard = new Board();
            string[] empty = { null, null, null, null, null, null, null, null, null };

            emptyBoard.SetBoard(empty);

            Assert.AreEqual(console.DisplayBoard(emptyBoard), "_ _|_ _|_ _\n_ _|_ _|_ _\n   |   |   \n");
        }

        [TestMethod()]
        public void DisplayOccupiedBoardTest()
        {
            ConsoleIO console = new ConsoleIO(new MockedOutput());
            Board b = new Board();
            string[] board = { "X", null, null,
                              null, null, null,
                              null, null, null };

            b.SetBoard(board);

            Assert.AreEqual(console.DisplayBoard(b), "_X_|_ _|_ _\n_ _|_ _|_ _\n   |   |   \n");
        }

        [TestMethod()]
        public void DisplayFullBoardTest()
        {
            ConsoleIO console = new ConsoleIO(new MockedOutput());
            Board b = new Board();
            string[] board = { "X", "O", "X",
                               "O", "X", "O",
                               "X", "O", "X" };

            b.SetBoard(board);

            Assert.AreEqual(console.DisplayBoard(b), "_X_|_O_|_X_\n_O_|_X_|_O_\n X | O | X \n");
        }

        [TestMethod()]
        public void DisplayHelpTest()
        {
            ConsoleIO console = new ConsoleIO(new MockedOutput());

            string message = console.DisplayHelp();

            Assert.AreEqual(message, "\nPlease reference the board as follows:_1_|_2_|_3_\n_4_|_5_|_6_\n 7 | 8 | 9 \n");
        }

        [TestMethod()]
        public void GetPlayerMoveEmptyBoardTest()
        {
            ConsoleIO console = new ConsoleIO(new MockedOutput());
            Board b = new Board();

            int selection = console.GetPlayerMove(b, new MockedInput("2"));

            Assert.AreEqual(selection, 2);
        }

        [TestMethod()]
        public void GetPlayerMoveOccupiedBoardTest()
        {
            ConsoleIO console = new ConsoleIO(new MockedOutput());
            Board b = new Board();
            string[] board = { "X", "O", "X",
                              null, null, null,
                              null, null, null };

            b.SetBoard(board);
            int selection = console.GetPlayerMove(b, new MockedInput("6"));

            Assert.AreEqual(selection, 6);
        }

        [TestMethod()]
        public void DisplayGameOverMessageXWinTest()
        {
            ConsoleIO console = new ConsoleIO(new MockedOutput());

            Assert.AreEqual(console.DisplayGameOverMessage(true, false), "Game Over! X's Win!");
        }

        [TestMethod()]
        public void DisplayGameOverMessageOWinTest()
        {
            ConsoleIO console = new ConsoleIO(new MockedOutput());

            Assert.AreEqual(console.DisplayGameOverMessage(false, false), "Game Over! O's Win!");
        }

        [TestMethod()]
        public void DisplayGameOverMessageTieTest()
        {
            ConsoleIO console = new ConsoleIO(new MockedOutput());

            Assert.AreEqual(console.DisplayGameOverMessage(false, true), "Game Over! It's a Tie!");
        }

        [TestMethod()]
        public void GetPlayAgainTest()
        {
            ConsoleIO console = new ConsoleIO(new MockedOutput());

            Assert.AreEqual(console.GetPlayAgain(new MockedInput("1")), true);
        }

        [TestMethod()]
        public void GetNoPlayAgainTest()
        {
            ConsoleIO console = new ConsoleIO(new MockedOutput());

            Assert.AreEqual(console.GetPlayAgain(new MockedInput("2")), false);
        }
    }
}