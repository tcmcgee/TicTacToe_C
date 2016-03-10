using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    public class Board
    {
        private string[] emptyBoard = { null, null, null, null, null, null, null, null, null };
        private string[] board;

        public Board()
        {
            this.board = emptyBoard;
        }

        public void SetBoard(string[] newBoard)
        {
            this.board = newBoard;
        }

        public string[] GetBoard()
        {
            return board;
        }

        public string[] GetStringBoardArray()
        {
            string[] stringBoard = (string[]) board.Clone();
            for (int i = 0; i < stringBoard.Length;i++)
            {
                stringBoard[i] = (stringBoard[i] == null) ? " " : stringBoard[i]; 
            }
            return stringBoard;
        }
    }
}
