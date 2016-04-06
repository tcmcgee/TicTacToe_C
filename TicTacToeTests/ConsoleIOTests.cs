using TicTacToe;
using Xunit;

namespace TicTacToeTests
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

    public class ConsoleIOTests
    {
        [Fact]
        public void DisplayWelcomeMessageTest()
        {
            ConsoleIO console = new ConsoleIO(new MockedInput(""), new MockedOutput());

            Assert.Equal(console.DisplayWelcomeMessage(), "Welcome to Tic Tac Toe!");
        }

        [Fact]
        public void DisplayEmptyBoardTest()
        {
            ConsoleIO console = new ConsoleIO(new MockedInput(""), new MockedOutput());
            Board emptyBoard = new Board(9);
            string[] empty = { null, null, null, null, null, null, null, null, null };

            emptyBoard.SetBoard(empty);

            Assert.Equal(console.DisplayBoard(emptyBoard), "_ _|_ _|_ _\n_ _|_ _|_ _\n   |   |   \n");
        }

        [Fact]
        public void DisplayOccupiedBoardTest()
        {
            ConsoleIO console = new ConsoleIO(new MockedInput(""), new MockedOutput());
            Board b = new Board(9);
            string[] board = { "X", null, null,
                              null, null, null,
                              null, null, null };

            b.SetBoard(board);

            Assert.Equal(console.DisplayBoard(b), "_X_|_ _|_ _\n_ _|_ _|_ _\n   |   |   \n");
        }

        [Fact]
        public void DisplayFullBoardTest()
        {
            ConsoleIO console = new ConsoleIO(new MockedInput(""), new MockedOutput());
            Board b = new Board(9);
            string[] board = { "X", "O", "X",
                               "O", "X", "O",
                               "X", "O", "X" };

            b.SetBoard(board);

            Assert.Equal(console.DisplayBoard(b), "_X_|_O_|_X_\n_O_|_X_|_O_\n X | O | X \n");
        }

        [Fact]
        public void DisplayHelpTest()
        {
            ConsoleIO console = new ConsoleIO(new MockedInput(""), new MockedOutput());

            string message = console.DisplayHelp(new Board(9));

            Assert.Equal(message, "\nPlease reference the board as follows:_1_|_2_|_3_\n_4_|_5_|_6_\n 7 | 8 | 9 \n");
        }

        [Fact]
        public void DisplayEmptyLargeBoardTest()
        {
            ConsoleIO console = new ConsoleIO(new MockedInput(""), new MockedOutput());
            Board board = new Board(9);
            board.SetBoard(new string[] { null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null });
            string message = console.DisplayBoard(board);

            Assert.Equal("_ _|_ _|_ _|_ _\n_ _|_ _|_ _|_ _\n_ _|_ _|_ _|_ _\n   |   |   |   \n", message);
        }

        [Fact]
        public void DisplayFullLargeBoardTest()
        {
            ConsoleIO console = new ConsoleIO(new MockedInput(""), new MockedOutput());
            Board board = new Board(16);
            board.SetBoard(new string[] { "X", "X", "X", "X", "X", "X", "X", "X", "X", "X", "X", "X", "X", "X", "X", "X" });
            string message = console.DisplayBoard(board);

            Assert.Equal("_X_|_X_|_X_|_X_\n_X_|_X_|_X_|_X_\n_X_|_X_|_X_|_X_\n X | X | X | X \n", message);
        }

        [Fact]
        public void DisplayLargeBoardHelpTest()
        {
            ConsoleIO console = new ConsoleIO(new MockedInput(""), new MockedOutput());
            Board board = new Board(16);
            board.SetBoard(new string[] { null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null });
            string message = console.DisplayHelp(board);

            Assert.Equal("\nPlease reference the board as follows:_1_|_2_|_3_|_4_\n_5_|_6_|_7_|_8_\n_9_|_10_|_11_|_12_\n 13 | 14 | 15 | 16 \n", message);
        }

        [Fact]
        public void GetPlayerMoveEmptyBoardTest()
        {
            ConsoleIO console = new ConsoleIO(new MockedInput("2"), new MockedOutput());
            Board b = new Board(9);

            int selection = console.GetPlayerMove(b);

            Assert.Equal(selection, 2);
        }

        [Fact]
        public void GetPlayerMoveOccupiedBoardTest()
        {
            ConsoleIO console = new ConsoleIO(new MockedInput("6"), new MockedOutput());
            Board b = new Board(9);
            string[] board = { "X", "O", "X",
                              null, null, null,
                              null, null, null };

            b.SetBoard(board);
            int selection = console.GetPlayerMove(b);

            Assert.Equal(selection, 6);
        }

        [Fact]
        public void DisplayGameOverMessageXWinTest()
        {
            ConsoleIO console = new ConsoleIO(new MockedInput(""), new MockedOutput());

            Assert.Equal(console.DisplayGameOverMessage(true, false), "Game Over! X's Win!");
        }

        [Fact]
        public void DisplayGameOverMessageOWinTest()
        {
            ConsoleIO console = new ConsoleIO(new MockedInput(""), new MockedOutput());

            Assert.Equal(console.DisplayGameOverMessage(false, false), "Game Over! O's Win!");
        }

        [Fact]
        public void DisplayGameOverMessageTieTest()
        {
            ConsoleIO console = new ConsoleIO(new MockedInput(""), new MockedOutput());

            Assert.Equal(console.DisplayGameOverMessage(false, true), "Game Over! It's a Tie!");
        }

        [Fact]
        public void GetPlayAgainTest()
        {
            ConsoleIO console = new ConsoleIO(new MockedInput("1"), new MockedOutput());

            Assert.Equal(console.GetPlayAgain(), true);
        }

        [Fact]
        public void GetNoPlayAgainTest()
        {
            ConsoleIO console = new ConsoleIO(new MockedInput("2"), new MockedOutput());

            Assert.Equal(console.GetPlayAgain(), false);
        }
    }
}