using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    public class Game
    {
        public Board board;

        private bool turn = true;
        private ConsoleIO console;
        private bool gameOver = false;
        private bool tie = false;

        private int[][] horizontalWins = { new int[] { 1, 2 }, new int[] { 0, 2 }, new int[] { 0, 1 }, new int[] { 4, 5 }, new int[] { 3, 5 }, new int[] { 3, 4 }, new int[] { 7, 8 }, new int[] { 6, 8 }, new int[] { 6, 7 } };
        private int[][] verticalWins =   { new int[] { 3, 6 }, new int[] { 4, 7 }, new int[] { 5, 8 }, new int[] { 0, 6 }, new int[] { 1, 7 }, new int[] { 2, 8 }, new int[] { 0, 3 }, new int[] { 1, 4 }, new int[] { 2, 5 } };
        private int[][] rightDiagonalWins = { new int[] { 4, 8 }, new int[] { }, new int[] { 4, 6 }, new int[] { }, new int[] { 0, 8 }, new int[] { }, new int[]{ 2, 4 }, new int[] { }, new int[] { 0, 4 } };
        private int[][] leftDiagonalWins =  { new int[] { 4, 8 }, new int[] { }, new int[] { 4, 6 }, new int[] { }, new int[] { 2, 6 }, new int[] { }, new int[] { 2, 4 }, new int[] { }, new int[] { 0, 4 } };

        public Game()
        {
            this.board = new Board();
            this.console = new ConsoleIO(new ConsoleOutput());
        }

        public void StartGame()
        {
            bool playAgain;
            IUserInput input = new ConsoleInput();
            do
            {
                ResetGame();
                console.DisplayWelcomeMessage();
                console.DisplayHelp();
       
                while (gameOver == false)
                {
                    Turn(input);
                }

                console.DisplayBoard(board);
                console.DisplayGameOverMessage(!turn, tie);
                playAgain = console.GetPlayAgain(new ConsoleInput());
            } while (playAgain);
        }
        
        public void Move(int selection, bool turn)
        {
            string[] tempBoard = board.GetBoard();
            tempBoard[selection] = GetPiece(turn);
            board.SetBoard(tempBoard);
            if (IsGameOver(selection, turn))
            {
                this.gameOver = true;
            }
            else
            {
                this.gameOver = false;
            }

        }

        public void Turn(IUserInput input)
        {
            int selection = console.GetPlayerMove(board, input);
            selection = selection - 1;
            Move(selection, turn);
            turn = !turn;            
        }

        public bool IsGameOver(int selection, bool turn)
        {
            return IsHorizontalWin(selection, turn) || IsVerticalWin(selection, turn) 
                   || IsDiagonalWin(selection, turn) || IsTie();
        }

        public bool IsTie()
        {
            string[] boardArray = board.GetBoard();
            string[] flatArray = boardArray.Where(x => !string.IsNullOrEmpty(x)).ToArray();

            tie = (boardArray.Length == flatArray.Length);

            return tie;
        }

        public bool IsHorizontalWin(int selection,bool turn)
        {
            return IsWin(horizontalWins, selection, turn);
        }

        public bool IsVerticalWin(int selection, bool turn)
        {
            return IsWin(verticalWins, selection, turn);
        }

        public bool IsDiagonalWin(int selection, bool turn)
        {
            return (IsWin(rightDiagonalWins, selection, turn) ||
                    IsWin(leftDiagonalWins, selection, turn));
        }

        public bool IsWin(int[][] possibleWins,int selection, bool turn)
        {
            int[] possibleSelectionWins = possibleWins[selection];
            string piece = GetPiece(turn);
            string[] boardArray = board.GetBoard();

            if (possibleSelectionWins.Length != 0)
            {
                foreach (int pieceIndex in possibleSelectionWins)
                {
                    if (boardArray[pieceIndex] != piece)
                    {
                        return false;
                    }
                }
                return true;
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
            board = new Board();
            gameOver = false;
            turn = true;
        }
    }
}
