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
        public void GetBoardTest()
        {
            Board b = new Board();

            string[] currentBoard = b.GetBoard();

            Assert.IsTrue(IsEqualBoard(currentBoard, emptyBoard));
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