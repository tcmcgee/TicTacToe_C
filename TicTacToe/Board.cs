using System;

namespace TicTacToe
{
    public class Board
    {
        private string[] emptySmallBoard = { null, null, null, null, null, null, null, null, null };
        private string[] emptyLargeBoard = { null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null };

        private string[] board;

        public Board(int size)
        {
            if (size == 9)
            {
                SetBoard(emptySmallBoard);
            }
            else
            {
                SetBoard(emptyLargeBoard);
            }
        }

        public void SetBoard(string[] newBoard)
        {
            this.board = newBoard;
        }

        public string[] GetBoardArray()
        {
            return board;
        }

        public int GetRowLength()
        {
            return (int)Math.Sqrt(GetBoardArray().Length);
        }

        public string[] GetStringBoardArray()
        {
            string[] stringBoard = (string[])board.Clone();
            for (int i = 0; i < stringBoard.Length; i++)
            {
                stringBoard[i] = (stringBoard[i] == null) ? " " : stringBoard[i];
            }
            return stringBoard;
        }

        public int[][] GetHorizontalWins()
        {
            int rowLength = GetRowLength();
            int[][] horizontalWins = new int[rowLength][];
            int count = 0;
            for (int row = 0; row < rowLength; row++)
            {
                int[] win = new int[rowLength];
                for (int col = 0; col < rowLength; col++)
                {
                    win[col] = count++;
                }
                horizontalWins[row] = win;
            }
            return horizontalWins;
        }

        public int[][] GetVerticalWins()
        {
            int rowLength = GetRowLength();
            int[][] verticalWins = new int[rowLength][];
            int count = 0;
            for (int row = 0; row < rowLength; row++)
            {
                int[] win = new int[rowLength];
                count = row;
                for (int col = 0; col < rowLength; col++)
                {
                    win[col] = count;
                    count += rowLength;
                }
                verticalWins[row] = win;
            }
            return verticalWins;
        }

        public int[][] GetDiagonalWins()
        {
            int rowLength = GetRowLength();
            int[] leftDiag = new int[rowLength];
            int[] rightDiag = new int[rowLength];
            int left = 0;
            int right = rowLength - 1;
            for (int i = 0; i < rowLength; i++)
            {
                leftDiag[i] = left;
                rightDiag[i] = right;
                left += rowLength + 1;
                right += rowLength - 1;
            }
            int[][] diagonalWins = new int[][] { leftDiag, rightDiag };
            return diagonalWins;
        }
    }
}