using Microsoft.VisualStudio.TestTools.UnitTesting;
using TicTacToe;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe.Tests
{
    [TestClass()]
    public class GameTests
    {
        [TestMethod()]
        public void GetPieceXTest()
        {
            Game game = new Game();

            Assert.AreEqual(game.GetPiece(true), "X");
        }

        [TestMethod()]
        public void GetPieceOTest()
        {
            Game game = new Game();

            Assert.AreEqual(game.GetPiece(false), "O");
        }

        [TestMethod()]
        public void MoveTest()
        {
            Game game = new Game();
            game.Move(0, true);
            string[] gameBoard = { "X", null, null, null, null, null, null, null, null };

            Assert.AreEqual(IsEqualBoard(game.board.GetBoard(), gameBoard), true);
        }

        [TestMethod()]
        public void TurnTest()
        {
            Game game = new Game();
            string[] gameBoard = { "X", null, null, null, null, null, null, null, null };

            game.Turn(new MockedInput("1"));

            Assert.AreEqual(IsEqualBoard(gameBoard, game.board.GetBoard()), true);
            
        }

        [TestMethod()]
        public void TwoTurnTest()
        {
            Game game = new Game();
            string[] gameBoard = { "X", "O", null, null, null, null, null, null, null };

            game.Turn(new MockedInput("1"));
            game.Turn(new MockedInput("2"));

            Assert.AreEqual(IsEqualBoard(gameBoard, game.board.GetBoard()), true);
        }
        [TestMethod()]
        public void CorrectPieceXTest()
        {
            Game game = new Game();
            game.Turn(new MockedInput("5"));

            Assert.AreEqual(game.board.GetBoard()[4], "X");
        }

        [TestMethod()]
        public void NotCorrectPieceOTest()
        {
            Game game = new Game();
            game.Turn(new MockedInput("5"));

            Assert.IsFalse(game.board.GetBoard()[4] == "O");
        }

        [TestMethod()]
        public void CorrectPieceOTest()
        {
            Game game = new Game();
            game.Turn(new MockedInput("5"));
            game.Turn(new MockedInput("7"));

            Assert.AreEqual(game.board.GetBoard()[6], "O");
        }



        [TestMethod()]
        public void IsHorizontalWinXTest()
        {
            Game game = new Game();
            string[] gameBoard = { "X", "X", null, null, null, null, null, null, null };
            game.board.SetBoard(gameBoard);

            game.Turn(new MockedInput("3"));
            Assert.IsTrue(game.IsHorizontalWin(true));
        }

        [TestMethod()]
        public void IsHorizontalWinOTest()
        {
            Game game = new Game();
            string[] gameBoard = { "X", "X", "O",
                                   "O", "O", "O",
                                   null, null, null };

            game.board.SetBoard(gameBoard);

            Assert.IsTrue(game.IsHorizontalWin(false));
        }

        [TestMethod()]
        public void IsNotHorizontalWinTest()
        {
            Game game = new Game();
            string[] gameBoard = { "X", "X", "O", "O", null, "O", null, null, null };
            game.board.SetBoard(gameBoard);

            game.Turn(new MockedInput("9"));

            Assert.IsFalse(game.IsHorizontalWin(false));
        }

        [TestMethod()]
        public void IsVerticalWinXTest()
        {
            Game game = new Game();
            string[] gameBoard = { "X", "X", "O", "X", "O", "O", "X", null, null };
            game.board.SetBoard(gameBoard);

            Assert.IsTrue(game.IsVerticalWin(true));
        }

        [TestMethod()]
        public void IsVerticalWinOTest()
        {
            Game game = new Game();
            string[] gameBoard = { "X", "O", "X", "X", "O", "O", null, "O", null };
            game.board.SetBoard(gameBoard);

            Assert.IsTrue(game.IsVerticalWin(false));
        }

        [TestMethod()]
        public void IsNotVerticalWinTest()
        {
            Game game = new Game();
            string[] gameBoard = { "X", "X", "O", "O", null, "O", null, null, null };
            game.board.SetBoard(gameBoard);

            Assert.IsFalse(game.IsVerticalWin(false));
        }


        [TestMethod()]
        public void IsDiagonalWinXTest()
        {
            Game game = new Game();
            string[] gameBoard = { "X", "X", "O", "X", "X", "O", null, null, "X" };
            game.board.SetBoard(gameBoard);

            Assert.IsTrue(game.IsDiagonalWin(true));
        }
        [TestMethod()]
        public void IsNotShortCircuitDiagnolTest()
        {
            Game game = new Game();
            game.Turn(new MockedInput("2"));

            Assert.IsFalse(game.IsDiagonalWin(true));
        }

        [TestMethod()]
        public void IsDiagonalWinOTest()
        {
            Game game = new Game();
            string[] gameBoard = { "X", "O", "O",
                                    "X", "O", "O",
                                    "O", "O", null };
            game.board.SetBoard(gameBoard);

            Assert.IsTrue(game.IsDiagonalWin(false));
        }

        [TestMethod()]
        public void IsNotDiagonalWinTest()
        {
            Game game = new Game();
            string[] gameBoard = { "X", "X", "O", "O", null, "O", null, null, null };
            game.board.SetBoard(gameBoard);

            Assert.IsFalse(game.IsDiagonalWin(false));
        }

        [TestMethod()]
        public void IsTieTest()
        {
            Game game = new Game();
            string[] gameBoard = { "X", "X", "O", "O", "O", "X", "X", "O", "X" };
            game.board.SetBoard(gameBoard);

            Assert.IsTrue(game.IsTie());
        }

        [TestMethod()]
        public void IsNotTieTest()
        {
            Game game = new Game();
            string[] gameBoard = { "X", null , "O", "O", "O", "X", "X", "O", "X" };
            game.board.SetBoard(gameBoard);

            Assert.IsFalse(game.IsTie());
        }

        [TestMethod()]
        public void GameOverTieTest()
        {
            Game game = new Game();
            string[] gameBoard = { "X", "X", "O",
                                   "O", "O", "X",
                                   "X", "O", "X" };
            game.board.SetBoard(gameBoard);

            Assert.IsTrue(game.IsGameOver(false));
        }

        [TestMethod()]
        public void GameOverWinTest()
        {
            Game game = new Game();
            string[] gameBoard = { "X", "X", "X",
                                   "O", null, "X",
                                   "X", "O", "X" };
            game.board.SetBoard(gameBoard);

            Assert.IsTrue(game.IsGameOver(true));
        }

        [TestMethod()]
        public void NotGameOverTest()
        {
            Game game = new Game();
            string[] gameBoard = { "X", "X", null,
                                   "O", null, "X",
                                   "X", "O", "X" };
            game.board.SetBoard(gameBoard);

            Assert.IsFalse(game.IsGameOver(false));
        }

        [TestMethod()]
        public void ResetGameTest()
        {
            Game game = new Game();
            string[] gameBoard = { "X", "X", null,
                                   "O", null, "X",
                                   "X", "O", "X" };
            string[] emptyBoard = { null, null, null, null, null, null, null, null, null };
            game.board.SetBoard(gameBoard);

            game.ResetGame();

            Assert.IsTrue(IsEqualBoard(game.board.GetBoard(),emptyBoard));
        }

        [TestMethod()]
        public void GetsHorizontalWins()
        {
            Game game = new Game();
            int[][] expectedWins = new int[][] { new int[] { 0, 1, 2 }, new int[] { 3, 4, 5 }, new int[] { 6, 7, 8 } };
            string[] gameBoard = { "X", "X", null,
                                   "O", null, "X",
                                   "X", "O", "X" };
            game.board.SetBoard(gameBoard);

            Assert.IsTrue(IsEqualArrayOfInts(expectedWins,game.GetHorizontalWins()));
        }

        [TestMethod()]
        public void GetsVerticalWins()
        {
            Game game = new Game();
            int[][] expectedWins = new int[][] { new int[] { 0, 3, 6 }, new int[] { 1, 4, 7 }, new int[] { 2, 5, 8 } };
            string[] gameBoard = { "X", "X", null,
                                   "O", null, "X",
                                   "X", "O", "X" };
            game.board.SetBoard(gameBoard);

            Assert.IsTrue(IsEqualArrayOfInts(expectedWins, game.GetVerticalWins()));
        }

        [TestMethod()]
        public void GetsDiagonalWins()
        {
            Game game = new Game();
            int[][] expectedWins = new int[][] { new int[] { 0, 4, 8 }, new int[] { 2, 4, 6 }};
            string[] gameBoard = { "X", "X", null,
                                   "O", null, "X",
                                   "X", "O", "X" };
            game.board.SetBoard(gameBoard);

            Assert.IsTrue(IsEqualArrayOfInts(expectedWins, game.GetDiagonalWins()));
        }






        public bool IsEqualArrayOfInts(int[][] array1, int[][] array2)
        {
            if (array1.Length == array2.Length)
            {
                for (int i = 0; i < array1.Length; i++)
                {
                    if (array1[i].Length != array2[i].Length)
                    {
                        return false;
                    }
                    for (int j = 0; j < array1[i].Length; j++)
                    {
                        if (array1[i][j] != array2[i][j])
                        {
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