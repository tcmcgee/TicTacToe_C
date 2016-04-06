using System;
using TicTacToe;
using Xunit;

namespace TicTacToeTests
{
    public class BoardTests
    {
        private string[] emptyBoard = { null, null, null, null, null, null, null, null, null };

        [Fact]
        public void SetBoardTest()
        {
            Board b = new Board(9);
            string[] newBoard = { "X", null, null, null, null, null, null, null, null };

            b.SetBoard(newBoard);

            Assert.True(IsEqualBoard(newBoard, b.GetBoardArray()));
        }

        [Fact]
        public void GetEmptyBoardTest()
        {
            Board b = new Board(9);

            string[] currentBoard = b.GetBoardArray();

            Assert.True(IsEqualBoard(currentBoard, emptyBoard));
        }

        [Fact]
        public void GetFullBoardTest()
        {
            Board b = new Board(9);
            string[] newBoard = { "X", "O", "X", "O", "X", "O", "X", "O", "X" };

            b.SetBoard(newBoard);
            string[] currentBoard = b.GetBoardArray();

            Assert.True(IsEqualBoard(currentBoard, newBoard));
        }

        [Fact]
        public void GetEmptyStringBoardArrayTest()
        {
            Board b = new Board(9);

            string[] stringBoard = b.GetStringBoardArray();

            Assert.True(IsEqualBoard(stringBoard, new string[] { " ", " ", " ", " ", " ", " ", " ", " ", " " }));
        }

        [Fact]
        public void GetOccupiedStringBoardArrayTest()
        {
            Board b = new Board(9);
            string[] newBoard = { "X", null, null, null, null, null, null, null, null };

            b.SetBoard(newBoard);
            string[] stringBoard = b.GetStringBoardArray();

            Assert.True(IsEqualBoard(stringBoard, new string[] { "X", " ", " ", " ", " ", " ", " ", " ", " " }));
        }

        [Fact]
        public void GetFullStringBoardArrayTest()
        {
            Board b = new Board(9);
            string[] newBoard = { "X", "O", "X", "O", "X", "O", "X", "O", "X" };

            b.SetBoard(newBoard);
            string[] stringBoard = b.GetStringBoardArray();

            Assert.True(IsEqualBoard(stringBoard, new string[] { "X", "O", "X", "O", "X", "O", "X", "O", "X" }));
        }

        [Fact]
        public void GetsHorizontalWins()
        {
            Board board = new Board(9);
            int[][] expectedWins = new int[][] { new int[] { 0, 1, 2 }, new int[] { 3, 4, 5 }, new int[] { 6, 7, 8 } };

            Assert.True(IsEqualArrayOfInts(expectedWins, board.GetHorizontalWins()));
        }

        [Fact]
        public void GetsVerticalWins()
        {
            Board board = new Board(9);
            int[][] expectedWins = new int[][] { new int[] { 0, 3, 6 }, new int[] { 1, 4, 7 }, new int[] { 2, 5, 8 } };

            Assert.True(IsEqualArrayOfInts(expectedWins, board.GetVerticalWins()));
        }

        [Fact]
        public void GetsDiagonalWins()
        {
            Board board = new Board(9);
            int[][] expectedWins = new int[][] { new int[] { 0, 4, 8 }, new int[] { 2, 4, 6 } };

            Assert.True(IsEqualArrayOfInts(expectedWins, board.GetDiagonalWins()));
        }

        [Fact]
        public void GetsLargeBoardHorizontalWins()
        {
            Board board = new Board(16);
            int[][] expectedWins = new int[][] { new int[] { 0, 1, 2, 3 }, new int[] { 4, 5, 6, 7 }, new int[] { 8, 9, 10, 11 }, new int[] { 12, 13, 14, 15 } };

            Assert.True(IsEqualArrayOfInts(expectedWins, board.GetHorizontalWins()));
        }

        [Fact]
        public void GetsLargeBoardVerticalWins()
        {
            Board board = new Board(16);
            int[][] expectedWins = new int[][] { new int[] { 0, 4, 8, 12 }, new int[] { 1, 5, 9, 13 }, new int[] { 2, 6, 10, 14 }, new int[] { 3, 7, 11, 15 } };

            Assert.True(IsEqualArrayOfInts(expectedWins, board.GetVerticalWins()));
        }

        [Fact]
        public void GetsLargeBoardDiagonalWins()
        {
            Board board = new Board(16);
            int[][] expectedWins = new int[][] { new int[] { 0, 5, 10, 15 }, new int[] { 3, 6, 9, 12 } };

            Assert.True(IsEqualArrayOfInts(expectedWins, board.GetDiagonalWins()));
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