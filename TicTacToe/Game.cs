using System;
using System.Linq;

namespace TicTacToe
{
    public class Game
    {
        public Board board;
        public ConsoleIO console;
        private IPlayer player1;
        private IPlayer player2;
        private IPlayer HumanPlayer = new HumanPlayer();
        private IPlayer ComputerPlayer = new ComputerPlayer();
        private bool turn = true;

        private bool gameOver = false;
        private bool tie = false;

        private int[][] horizontalWins;
        private int[][] verticalWins;
        private int[][] diagonalWins;

        public Game(int boardSize)
        {
            board = new Board(boardSize);
            InitialSetup(new HumanPlayer(), new ComputerPlayer());
        }

        public Game(int boardSize, IPlayer player1, IPlayer player2)
        {
            board = new Board(boardSize);
            InitialSetup(player1, player2);
        }

        private void InitialSetup(IPlayer player1, IPlayer player2)
        {
            this.player1 = player1;
            this.player2 = player2;
            this.console = new ConsoleIO(new ConsoleInput(), new ConsoleOutput());
            this.horizontalWins = GetHorizontalWins(board);
            this.verticalWins = GetVerticalWins(board);
            this.diagonalWins = GetDiagonalWins(board);
        }

        public void StartGame()
        {
            bool playAgain;
            console.DisplayWelcomeMessage();
            do
            {
                GameSetup();
                while (gameOver == false)
                {
                    Turn();
                }
                playAgain = GameTearDown();
            } while (playAgain);
        }

        private bool GameTearDown()
        {
            console.DisplayBoard(board);
            console.DisplayGameOverMessage(!turn, tie);
            return console.GetPlayAgain();
        }

        private void GameSetup()
        {
            ResetGame();
            console.DisplayHelp(board);
        }

        public void Move(int selection, bool turn)
        {
            string[] tempBoard = board.GetBoardArray();
            tempBoard[selection] = GetPiece(turn);
            board.SetBoard(tempBoard);
            this.gameOver = IsGameOver(turn) ? true : false;
        }

        public void Turn()
        {
            int selection;
            if (turn)
            {
                selection = player1.GetMove(this);
            }
            else
            {
                selection = player2.GetMove(this);
            }
            Move(selection, turn);
            turn = !turn;
        }

        public int[][] GetHorizontalWins(Board board)
        {
            int rowLength = (int)Math.Sqrt(board.GetBoardArray().Length);
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

        public int[][] GetVerticalWins(Board board)
        {
            int rowLength = (int)Math.Sqrt(board.GetBoardArray().Length);
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

        public int[][] GetDiagonalWins(Board board)
        {
            int rowLength = (int)Math.Sqrt(board.GetBoardArray().Length);
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

        public bool HasWinner()
        {
            return IsHorizontalWin(true)
                || IsVerticalWin(true)
                || IsDiagonalWin(true)
                || IsHorizontalWin(false)
                || IsVerticalWin(false)
                || IsDiagonalWin(false);
        }

        public bool IsWinner(bool turn)
        {
            return IsHorizontalWin(turn)
                || IsVerticalWin(turn)
                || IsDiagonalWin(turn);
        }

        public bool IsGameOver(bool turn)
        {
            return IsHorizontalWin(turn)
                || IsVerticalWin(turn)
                || IsDiagonalWin(turn)
                || IsTie();
        }

        public bool IsTie()
        {
            string[] boardArray = board.GetBoardArray();
            string[] flatArray = boardArray.Where(x => !string.IsNullOrEmpty(x)).ToArray();

            tie = (boardArray.Length == flatArray.Length);

            return tie;
        }

        public bool IsHorizontalWin(bool turn)
        {
            return IsWin(horizontalWins, turn);
        }

        public bool IsVerticalWin(bool turn)
        {
            return IsWin(verticalWins, turn);
        }

        public bool IsDiagonalWin(bool turn)
        {
            return (IsWin(diagonalWins, turn));
        }

        public bool IsWin(int[][] possibleWins, bool turn)
        {
            string piece = GetPiece(turn);
            string[] boardArray = board.GetBoardArray();
            int rowLength = (int)Math.Sqrt(boardArray.Length);
            foreach (int[] win in possibleWins)
            {
                int count = 0;
                foreach (int index in win)
                {
                    if (boardArray[index] == piece)
                        count++;
                }
                if (count == rowLength)
                {
                    return true;
                }
            }
            return false;
        }

        public string GetPiece(bool turn)
        {
            return turn ? "X" : "O";
        }

        public void ResetGame()
        {
            tie = false;
            board = new Board(board.GetBoardArray().Length);
            gameOver = false;
            turn = true;
        }
    }
}