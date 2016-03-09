using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    public class ConsoleIO
    {
        IUserOutput output;

        public ConsoleIO(IUserOutput output)
        {
            this.output = output;
        }

        public string DisplayWelcomeMessage()
        {
            string message = "Welcome to Tic Tac Toe!";
            output.Display(message);
            return message;
        }

        public string GetStringBoard(Board b)
        {
            string[] boardArray = b.GetBoard();
            string[] stringTiles = new string[boardArray.Length];
            int index = 0;

            foreach (string tile in boardArray)
            {
                stringTiles[index] = string.IsNullOrEmpty(tile) ? " " : tile;
                index++;
            }
            StringBuilder builder = new StringBuilder();
            builder.AppendFormat( "_{0}_|_{1}_|_{2}_\n_{3}_|_{4}_|_{5}_\n {6} | {7} | {8} ",stringTiles);
            return builder.ToString();
        }

        public string DisplayBoard(Board board)
        {
            string stringBoard = GetStringBoard(board);
            output.Display(stringBoard);

            return stringBoard;
        }

        public string DisplayHelp()
        {
            Board sampleBoard = new Board();
            sampleBoard.SetBoard(new string[] { "1", "2", "3", "4", "5", "6", "7", "8", "9" });
            string message = "\nPlease reference the board as follows:";

            output.Display(message);
            message += DisplayBoard(sampleBoard);
            output.Display("");
            return message;    
        }

        public string DisplayGameOverMessage(bool winnerTurn, bool tie)
        {
            string message;
            if (tie)
            {
                message = "Game Over! It's a Tie!";
            }
            else if (winnerTurn)
            {
                message = "Game Over! X's Win!";
            }
            else if (!winnerTurn)
            {
                message = "Game Over! O's Win!";
            }
            else
            {
                message =  String.Empty;
            }
            output.Display(message);
            return message;
        }

        public int GetUserInput(IUserInput input, string message, int low, int high)
        {
            bool valid = false;
            int selection = -1;
            while (valid == false)
            {
                output.Display(message);

                bool success = Int32.TryParse(input.GetInput(), out selection);
                if (success)
                {
                    if (selection >= low && selection <= high)
                    {
                        valid = true;
                    }
                    else
                    {
                        output.Display("Please enter a valid number!");
                    }
                }
                else
                {
                    output.Display("You must enter a number!");
                }
            }
            return selection;
        }
  
        public int GetPlayerMove(Board board, IUserInput input)
        {
            string[] boardArray = board.GetBoard();
            DisplayBoard(board);
            int selection = -1;
            bool done = false;
            string message = "\nEnter the number corresponding with your move! (1-9): ";
            while (done == false)
            {
                selection = GetUserInput(input, message, 1, 9);
                done = (boardArray[selection - 1] == null);
                if (done == false)
                {
                    output.Display("Please Select an unoccupied space!");
                }
            }
            return selection;
        }

        public bool GetPlayAgain(IUserInput input)
        {
            int selection = GetUserInput(input,"Would you like to play again?\n1.Yes\n2.No",1,2);
            return selection == 1 ? true : false;

        }
    }
}
