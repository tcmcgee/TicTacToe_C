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
    public class BoardTests
    {
        string[] emptyBoard = { null, null, null, null, null, null, null, null, null };

        [TestMethod()]
        public void SetBoardTest()
        {
            Board b = new Board();
            string[] newBoard = { "X", null, null, null, null, null, null, null, null };

            b.SetBoard(newBoard);

            Assert.IsTrue(IsEqualBoard(newBoard, b.GetBoard()));
        }

        [TestMethod()]
        public void GetEmptyBoardTest()
        {
            Board b = new Board();

            string[] currentBoard = b.GetBoard();

            Assert.IsTrue(IsEqualBoard(currentBoard, emptyBoard));
        }

        [TestMethod()]
        public void GetFullBoardTest()
        {
            Board b = new Board();
            string[] newBoard = { "X", "O", "X", "O", "X", "O", "X", "O", "X" };

            b.SetBoard(newBoard);
            string[] currentBoard = b.GetBoard();

            Assert.IsTrue(IsEqualBoard(currentBoard, newBoard));
        }

        [TestMethod()]
        public void GetEmptyStringBoardArrayTest()
        {
            Board b = new Board();

            string[] stringBoard = b.GetStringBoardArray();

            Assert.IsTrue(IsEqualBoard(stringBoard, new string[] { " ", " ", " ", " ", " ", " ", " ", " ", " "}));
        }

        [TestMethod()]
        public void GetOccupiedStringBoardArrayTest()
        {
            Board b = new Board();
            string[] newBoard = { "X", null, null, null, null, null, null, null, null };

            b.SetBoard(newBoard);
            string[] stringBoard = b.GetStringBoardArray();
            
            Assert.IsTrue(IsEqualBoard(stringBoard, new string[] { "X", " ", " ", " ", " ", " ", " ", " ", " " }));
        }

        [TestMethod()]
        public void GetFullStringBoardArrayTest()
        {
            Board b = new Board();
            string[] newBoard = { "X", "O", "X", "O", "X", "O", "X", "O", "X" };

            b.SetBoard(newBoard);
            string[] stringBoard = b.GetStringBoardArray();

            Assert.IsTrue(IsEqualBoard(stringBoard, new string[] { "X", "O", "X", "O", "X", "O", "X", "O", "X" }));
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