using System;
using TicTacToe;
using Xunit;

namespace TicTacToeTests
{
    public class GameTests
    {
        [Fact]
        public void GetPieceXTest()
        {
            Game game = new Game(9);

            Assert.Equal(game.GetPiece(true), "X");
        }

        [Fact]
        public void GetPieceOTest()
        {
            Game game = new Game(9);

            Assert.Equal(game.GetPiece(false), "O");
        }

        [Fact]
        public void MoveTest()
        {
            Game game = new Game(9);
            game.Move(0, true);
            string[] gameBoard = { "X", null, null, null, null, null, null, null, null };

            Assert.Equal(gameBoard, game.board.GetBoardArray());
        }

        [Fact]
        public void LargeBoardMoveTest()
        {
            Game game = new Game(16);
            game.Move(0, true);
            string[] gameBoard = { "X", null, null, null, null, null, null, null, null, null, null, null, null, null, null, null };

            Assert.Equal(gameBoard, game.board.GetBoardArray());
        }

        [Fact]
        public void LargeBoardMoveTestLargestInput()
        {
            Game game = new Game(16);
            game.Move(15, true);
            string[] gameBoard = { null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, "X" };

            Assert.Equal(gameBoard, game.board.GetBoardArray());
        }

        [Fact]
        public void TurnTest()
        {
            Game game = new Game(9);
            string[] gameBoard = { "X", null, null, null, null, null, null, null, null };
            game.IO = new ConsoleIO(new MockedInput("1"), new MockedOutput());
            game.Turn();

            Assert.Equal(gameBoard, game.board.GetBoardArray());
        }

        [Fact]
        public void LargeBoardTurnTest()
        {
            Game game = new Game(16);
            string[] gameBoard = { "X", null, null, null, null, null, null, null, null, null, null, null, null, null, null, null };
            game.IO = new ConsoleIO(new MockedInput("1"), new MockedOutput());
            game.Turn();

            Assert.Equal(gameBoard, game.board.GetBoardArray());
        }

        [Fact]
        public void LargeBoardTurnTestLargestInput()
        {
            Game game = new Game(16);
            string[] gameBoard = { null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, "X" };
            game.IO = new ConsoleIO(new MockedInput("16"), new MockedOutput());
            game.Turn();

            Assert.Equal(gameBoard, game.board.GetBoardArray());
        }

        [Fact]
        public void TwoTurnTest()
        {
            Game game = new Game(9);
            string[] gameBoard = { "X", null, null, null, "O", null, null, null, null };
            game.IO = new ConsoleIO(new MockedInput("1"), new MockedOutput());
            game.Turn();
            game.Turn(); //Second Turn Computer Goes

            Assert.Equal(gameBoard, game.board.GetBoardArray());
        }

        [Fact]
        public void CorrectPieceXTest()
        {
            Game game = new Game(9);
            game.IO = new ConsoleIO(new MockedInput("5"), new MockedOutput());
            game.Turn();

            Assert.Equal(game.board.GetBoardArray()[4], "X");
        }

        [Fact]
        public void NotCorrectPieceOTest()
        {
            Game game = new Game(9);
            game.IO = new ConsoleIO(new MockedInput("5"), new MockedOutput());
            game.Turn();

            Assert.False(game.board.GetBoardArray()[4] == "O");
        }

        [Fact]
        public void CorrectPieceOTest()
        {
            Game game = new Game(9);
            game.IO = new ConsoleIO(new MockedInput("1"), new MockedOutput());
            game.Turn();
            game.Turn();

            Assert.Equal(game.board.GetBoardArray()[4], "O");
        }

        [Fact]
        public void IsHorizontalWinXTest()
        {
            Game game = new Game(9);
            string[] gameBoard = { "X", "X", null, null, null, null, null, null, null };

            game.board.SetBoard(gameBoard);
            game.IO = new ConsoleIO(new MockedInput("3"), new MockedOutput());
            game.Turn();

            Assert.True(game.IsHorizontalWin(true));
        }

        [Fact]
        public void IsHorizontalWinOTest()
        {
            Game game = new Game(9);
            string[] gameBoard = { "X", "X", "O",
                                   "O", "O", "O",
                                   null, null, null };

            game.board.SetBoard(gameBoard);

            Assert.True(game.IsHorizontalWin(false));
        }

        [Fact]
        public void IsNotHorizontalWinTest()
        {
            Game game = new Game(9);
            string[] gameBoard = { "X", "X", "O", "O", null, "O", null, null, null };
            game.board.SetBoard(gameBoard);
            game.IO = new ConsoleIO(new MockedInput("9"), new MockedOutput());
            game.Turn();

            Assert.False(game.IsHorizontalWin(false));
        }

        [Fact]
        public void IsVerticalWinXTest()
        {
            Game game = new Game(9);
            string[] gameBoard = { "X", "X", "O", "X", "O", "O", "X", null, null };
            game.board.SetBoard(gameBoard);

            Assert.True(game.IsVerticalWin(true));
        }

        [Fact]
        public void IsVerticalWinOTest()
        {
            Game game = new Game(9);
            string[] gameBoard = { "X", "O", "X", "X", "O", "O", null, "O", null };
            game.board.SetBoard(gameBoard);

            Assert.True(game.IsVerticalWin(false));
        }

        [Fact]
        public void IsNotVerticalWinTest()
        {
            Game game = new Game(9);
            string[] gameBoard = { "X", "X", "O", "O", null, "O", null, null, null };
            game.board.SetBoard(gameBoard);

            Assert.False(game.IsVerticalWin(false));
        }

        [Fact]
        public void IsDiagonalWinXTest()
        {
            Game game = new Game(9);
            string[] gameBoard = { "X", "X", "O", "X", "X", "O", null, null, "X" };
            game.board.SetBoard(gameBoard);

            Assert.True(game.IsDiagonalWin(true));
        }

        [Fact]
        public void IsNotShortCircuitDiagnolTest()
        {
            Game game = new Game(9);
            game.IO = new ConsoleIO(new MockedInput("2"), new MockedOutput());
            game.Turn();

            Assert.False(game.IsDiagonalWin(true));
        }

        [Fact]
        public void IsDiagonalWinOTest()
        {
            Game game = new Game(9);
            string[] gameBoard = { "X", "O", "O",
                                    "X", "O", "O",
                                    "O", "O", null };
            game.board.SetBoard(gameBoard);

            Assert.True(game.IsDiagonalWin(false));
        }

        [Fact]
        public void IsNotDiagonalWinTest()
        {
            Game game = new Game(9);
            string[] gameBoard = { "X", "X", "O", "O", null, "O", null, null, null };
            game.board.SetBoard(gameBoard);

            Assert.False(game.IsDiagonalWin(false));
        }

        [Fact]
        public void IsTieTest()
        {
            Game game = new Game(9);
            string[] gameBoard = { "X", "X", "O", "O", "O", "X", "X", "O", "X" };
            game.board.SetBoard(gameBoard);

            Assert.True(game.IsTie());
        }

        [Fact]
        public void IsNotTieTest()
        {
            Game game = new Game(9);
            string[] gameBoard = { "X", null, "O", "O", "O", "X", "X", "O", "X" };
            game.board.SetBoard(gameBoard);

            Assert.False(game.IsTie());
        }

        [Fact]
        public void GameOverTieTest()
        {
            Game game = new Game(9);
            string[] gameBoard = { "X", "X", "O",
                                   "O", "O", "X",
                                   "X", "O", "X" };
            game.board.SetBoard(gameBoard);

            Assert.True(game.IsGameOver(false));
        }

        [Fact]
        public void GameOverWinTest()
        {
            Game game = new Game(9);
            string[] gameBoard = { "X", "X", "X",
                                   "O", null, "X",
                                   "X", "O", "X" };
            game.board.SetBoard(gameBoard);

            Assert.True(game.IsGameOver(true));
        }

        [Fact]
        public void NotGameOverTest()
        {
            Game game = new Game(9);
            string[] gameBoard = { "X", "X", null,
                                   "O", null, "X",
                                   "X", "O", "X" };
            game.board.SetBoard(gameBoard);

            Assert.False(game.IsGameOver(false));
        }

        [Fact]
        public void ResetGameTest()
        {
            Game game = new Game(9);
            string[] gameBoard = { "X", "X", null,
                                   "O", null, "X",
                                   "X", "O", "X" };
            string[] emptyBoard = { null, null, null, null, null, null, null, null, null };
            game.board.SetBoard(gameBoard);

            game.ResetGame();

            Assert.Equal(emptyBoard, game.board.GetBoardArray());
        }

        [Fact]
        public void LargeBoardIsNotHorizontalWinTest()
        {
            Game game = new Game(16);
            string[] gameBoard = {  "X", "X", "O", "O",
                                    "X", "X", null, "O",
                                    null, null, "O", "O",
                                    "X", "X", "O", null };
            game.board.SetBoard(gameBoard);
            game.IO = new ConsoleIO(new MockedInput("9"), new MockedOutput());
            game.Turn();

            Assert.False(game.IsHorizontalWin(false));
        }

        [Fact]
        public void LargeBoardIsVerticalWinXTest()
        {
            Game game = new Game(16);
            string[] gameBoard = {  "X", "O", "X", null,
                                    "X", null, "X", "X",
                                    "X", "X", "O", "O",
                                    "X", "X", "O", "X" };
            game.board.SetBoard(gameBoard);

            Assert.True(game.IsVerticalWin(true));
        }

        [Fact]
        public void LargeBoardIsVerticalWinOTest()
        {
            Game game = new Game(16);
            string[] gameBoard = {  "O", "O", "X", "O",
                                    "O", null, "X", "X",
                                    "O", "X", "O", "O",
                                    "O", "X", "O", null };
            game.board.SetBoard(gameBoard);

            Assert.True(game.IsVerticalWin(false));
        }

        [Fact]
        public void LargeBoardIsNotVerticalWinTest()
        {
            Game game = new Game(16);
            string[] gameBoard = {  "X", "O", "X", "O",
                                    "O", "O",null, "X",
                                    "X", null, "O", "O",
                                    "X", "X", "O", "X" };
            game.board.SetBoard(gameBoard);

            Assert.False(game.IsVerticalWin(false) || game.IsVerticalWin(true));
        }

        [Fact]
        public void LargeBoardIsDiagonalWinOTest()
        {
            Game game = new Game(16);
            string[] gameBoard = {  "O", "O", "X", "O",
                                    "X", "O", "X", "X",
                                    "X", null, "O", "O",
                                    "X", "X", "O", "O" };
            game.board.SetBoard(gameBoard);

            Assert.True(game.IsDiagonalWin(false));
        }
    }
}