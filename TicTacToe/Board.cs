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
    }
}
