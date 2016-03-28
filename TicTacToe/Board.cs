namespace TicTacToe
{
    public class Board
    {
        private string[] emptyBoard = { null, null, null, null, null, null, null, null, null };
        private string[] emptyLargeBoard = { null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null };

        private string[] board;

        public Board()
        {
            this.board = emptyBoard;
        }

        public Board(int size)
        {
            if (size == 9)
            {
                this.board = emptyBoard;
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

        public string[] GetStringBoardArray()
        {
            string[] stringBoard = (string[])board.Clone();
            for (int i = 0; i < stringBoard.Length; i++)
            {
                stringBoard[i] = (stringBoard[i] == null) ? " " : stringBoard[i];
            }
            return stringBoard;
        }
    }
}