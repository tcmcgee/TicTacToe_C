using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace TicTacToe.Tests
{
    [TestClass()]
    public class GameTests
    {
        [TestMethod()]
        public void GetPieceXTest()
        {
            Game game = new Game(9);

            Assert.AreEqual(game.GetPiece(true), "X");
        }

        [TestMethod()]
        public void GetPieceOTest()
        {
            Game game = new Game(9);

            Assert.AreEqual(game.GetPiece(false), "O");
        }

        [TestMethod()]
        public void MoveTest()
        {
            Game game = new Game(9);
            game.Move(0, true);
            string[] gameBoard = { "X", null, null, null, null, null, null, null, null };

            Assert.AreEqual(IsEqualBoard(game.board.GetBoardArray(), gameBoard), true);
        }

        [TestMethod()]
        public void TurnTest()
        {
            Game game = new Game(9);
            string[] gameBoard = { "X", null, null, null, null, null, null, null, null };
            game.console = new ConsoleIO(new MockedInput("1"), new MockedOutput());
            game.Turn();

            Assert.AreEqual(IsEqualBoard(gameBoard, game.board.GetBoardArray()), true);
        }

        [TestMethod()]
        public void TwoTurnTest()
        {
            Game game = new Game(9);
            string[] gameBoard = { "X", null, null, null, "O", null, null, null, null };
            game.console = new ConsoleIO(new MockedInput("1"), new MockedOutput());
            game.Turn();
            game.Turn();

            Assert.AreEqual(IsEqualBoard(gameBoard, game.board.GetBoardArray()), true);
        }

        [TestMethod()]
        public void CorrectPieceXTest()
        {
            Game game = new Game(9);
            game.console = new ConsoleIO(new MockedInput("5"), new MockedOutput());
            game.Turn();

            Assert.AreEqual(game.board.GetBoardArray()[4], "X");
        }

        [TestMethod()]
        public void NotCorrectPieceOTest()
        {
            Game game = new Game(9);
            game.console = new ConsoleIO(new MockedInput("5"), new MockedOutput());
            game.Turn();

            Assert.IsFalse(game.board.GetBoardArray()[4] == "O");
        }

        [TestMethod()]
        public void CorrectPieceOTest()
        {
            Game game = new Game(9);
            game.console = new ConsoleIO(new MockedInput("1"), new MockedOutput());
            game.Turn();
            game.Turn();

            Assert.AreEqual(game.board.GetBoardArray()[4], "O");
        }

        [TestMethod()]
        public void IsHorizontalWinXTest()
        {
            Game game = new Game(9);
            string[] gameBoard = { "X", "X", null, null, null, null, null, null, null };

            game.board.SetBoard(gameBoard);
            game.console = new ConsoleIO(new MockedInput("3"), new MockedOutput());
            game.Turn();

            Assert.IsTrue(game.IsHorizontalWin(true));
        }

        [TestMethod()]
        public void IsHorizontalWinOTest()
        {
            Game game = new Game(9);
            string[] gameBoard = { "X", "X", "O",
                                   "O", "O", "O",
                                   null, null, null };

            game.board.SetBoard(gameBoard);

            Assert.IsTrue(game.IsHorizontalWin(false));
        }

        [TestMethod()]
        public void IsNotHorizontalWinTest()
        {
            Game game = new Game(9);
            string[] gameBoard = { "X", "X", "O", "O", null, "O", null, null, null };
            game.board.SetBoard(gameBoard);
            game.console = new ConsoleIO(new MockedInput("9"), new MockedOutput());
            game.Turn();

            Assert.IsFalse(game.IsHorizontalWin(false));
        }

        [TestMethod()]
        public void IsVerticalWinXTest()
        {
            Game game = new Game(9);
            string[] gameBoard = { "X", "X", "O", "X", "O", "O", "X", null, null };
            game.board.SetBoard(gameBoard);

            Assert.IsTrue(game.IsVerticalWin(true));
        }

        [TestMethod()]
        public void IsVerticalWinOTest()
        {
            Game game = new Game(9);
            string[] gameBoard = { "X", "O", "X", "X", "O", "O", null, "O", null };
            game.board.SetBoard(gameBoard);

            Assert.IsTrue(game.IsVerticalWin(false));
        }

        [TestMethod()]
        public void IsNotVerticalWinTest()
        {
            Game game = new Game(9);
            string[] gameBoard = { "X", "X", "O", "O", null, "O", null, null, null };
            game.board.SetBoard(gameBoard);

            Assert.IsFalse(game.IsVerticalWin(false));
        }

        [TestMethod()]
        public void IsDiagonalWinXTest()
        {
            Game game = new Game(9);
            string[] gameBoard = { "X", "X", "O", "X", "X", "O", null, null, "X" };
            game.board.SetBoard(gameBoard);

            Assert.IsTrue(game.IsDiagonalWin(true));
        }

        [TestMethod()]
        public void IsNotShortCircuitDiagnolTest()
        {
            Game game = new Game(9);
            game.console = new ConsoleIO(new MockedInput("2"), new MockedOutput());
            game.Turn();

            Assert.IsFalse(game.IsDiagonalWin(true));
        }

        [TestMethod()]
        public void IsDiagonalWinOTest()
        {
            Game game = new Game(9);
            string[] gameBoard = { "X", "O", "O",
                                    "X", "O", "O",
                                    "O", "O", null };
            game.board.SetBoard(gameBoard);

            Assert.IsTrue(game.IsDiagonalWin(false));
        }

        [TestMethod()]
        public void IsNotDiagonalWinTest()
        {
            Game game = new Game(9);
            string[] gameBoard = { "X", "X", "O", "O", null, "O", null, null, null };
            game.board.SetBoard(gameBoard);

            Assert.IsFalse(game.IsDiagonalWin(false));
        }

        [TestMethod()]
        public void IsTieTest()
        {
            Game game = new Game(9);
            string[] gameBoard = { "X", "X", "O", "O", "O", "X", "X", "O", "X" };
            game.board.SetBoard(gameBoard);

            Assert.IsTrue(game.IsTie());
        }

        [TestMethod()]
        public void IsNotTieTest()
        {
            Game game = new Game(9);
            string[] gameBoard = { "X", null, "O", "O", "O", "X", "X", "O", "X" };
            game.board.SetBoard(gameBoard);

            Assert.IsFalse(game.IsTie());
        }

        [TestMethod()]
        public void GameOverTieTest()
        {
            Game game = new Game(9);
            string[] gameBoard = { "X", "X", "O",
                                   "O", "O", "X",
                                   "X", "O", "X" };
            game.board.SetBoard(gameBoard);

            Assert.IsTrue(game.IsGameOver(false));
        }

        [TestMethod()]
        public void GameOverWinTest()
        {
            Game game = new Game(9);
            string[] gameBoard = { "X", "X", "X",
                                   "O", null, "X",
                                   "X", "O", "X" };
            game.board.SetBoard(gameBoard);

            Assert.IsTrue(game.IsGameOver(true));
        }

        [TestMethod()]
        public void NotGameOverTest()
        {
            Game game = new Game(9);
            string[] gameBoard = { "X", "X", null,
                                   "O", null, "X",
                                   "X", "O", "X" };
            game.board.SetBoard(gameBoard);

            Assert.IsFalse(game.IsGameOver(false));
        }

        [TestMethod()]
        public void ResetGameTest()
        {
            Game game = new Game(9);
            string[] gameBoard = { "X", "X", null,
                                   "O", null, "X",
                                   "X", "O", "X" };
            string[] emptyBoard = { null, null, null, null, null, null, null, null, null };
            game.board.SetBoard(gameBoard);

            game.ResetGame();

            Assert.IsTrue(IsEqualBoard(game.board.GetBoardArray(), emptyBoard));
        }

        public bool IsEqualArrayOfInts(int[][] array1, int[][] array2)
        {
            if (array1.Length == array2.Length)
            {
                for (int i = 0; i < array1.Length; i++)
                {
                    if (array1[i].Length != array2[i].Length)
                    {
                        Console.WriteLine(array1[i].Length + " - LENGTH - " + array2[i].Length);
                        return false;
                    }
                    for (int j = 0; j < array1[i].Length; j++)
                    {
                        if (array1[i][j] != array2[i][j])
                        {
                            Console.WriteLine(array1[i][j] + " - != - " + array2[i][j]);
                            return false;
                        }
                    }
                }
            }
            else
            {
                return false;
            }
            return true;
        }

        public bool IsEqualBoard(string[] board1, string[] board2)
        {
            if (board1.Length == board2.Length)
            {
                for (int i = 0; i < board1.Length; i++)
                {
                    if (board1[i] != board2[i])
                    {
                        return false;
                    }
                }
            }
            else
            {
                return false;
            }
            return true;
        }
    }
}