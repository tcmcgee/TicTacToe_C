using System;
using System.Linq;

namespace TicTacToe
{
    public class Game
    {
        public Board board;
        public IIO IO;
        private IPlayer player1;
        private IPlayer player2;
        public bool turn = true;

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

        public Game(int boardSize, IPlayer player1, IPlayer player2, IIO IO)
        {
            board = new Board(boardSize);
            this.IO = IO;
            InitialSetup(player1, player2);
        }

        private void InitialSetup(IPlayer player1, IPlayer player2)
        {
            this.player1 = player1;
            this.player2 = player2;
            this.horizontalWins = board.GetHorizontalWins();
            this.verticalWins = board.GetVerticalWins();
            this.diagonalWins = board.GetDiagonalWins();
        }

        public void StartGame()
        {
            bool playAgain;
            IO.DisplayWelcomeMessage();
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
            IO.DisplayBoard(board);
            IO.DisplayGameOverMessage(!turn, tie);
            return IO.GetPlayAgain();
        }

        private void GameSetup()
        {
            ResetGame();
            IO.DisplayHelp(board);
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