using System;
using System.Text;

namespace TicTacToe
{
    public class ConsoleIO
    {
        private IUserOutput output;

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

        public string GetBoardString(Board b)
        {
            string[] boardArray = b.GetBoardArray();
            StringBuilder builder = new StringBuilder();

            string formatString = BoardStringFormat(boardArray);
            builder.AppendFormat(formatString, b.GetStringBoardArray());
            return builder.ToString();
        }

        private string BoardStringFormat(string[] boardArray)
        {
            int rowLength = (int)Math.Sqrt(boardArray.Length);
            string formatString = "";
            formatString = GenerateFormatString(rowLength, formatString);
            return formatString;
        }

        private static string GenerateFormatString(int rowLength, string formatString)
        {
            int count = 0;
            for (int row = 0; row < rowLength; row++)
            {
                for (int col = 0; col < rowLength; col++)
                {
                    formatString = AppendCharacterIndex(rowLength, formatString, count, row);
                    formatString = AppendNewLineOrDivider(rowLength, formatString, col);
                    count++;
                }
            }

            return formatString;
        }

        private static string AppendNewLineOrDivider(int rowLength, string formatString, int col)
        {
            if (col == rowLength - 1)
            {
                formatString += "\n";
            }
            else
            {
                formatString += "|";
            }

            return formatString;
        }

        private static string AppendCharacterIndex(int rowLength, string formatString, int count, int row)
        {
            if (row != rowLength - 1)
            {
                formatString += "_{" + count + "}_";
            }
            else
            {
                formatString += " {" + count + "} ";
            }

            return formatString;
        }

        public string DisplayBoard(Board board)
        {
            string stringBoard = GetBoardString(board);
            output.Display(stringBoard);

            return stringBoard;
        }

        public string DisplayHelp(Board b)
        {
            int boardLength = b.GetBoardArray().Length;
            Board sampleBoard = new Board();

            sampleBoard.SetBoard(GetIndexArray(boardLength));
            string message = "\nPlease reference the board as follows:";

            output.Display(message);
            message += DisplayBoard(sampleBoard);
            output.Display("");
            return message;
        }

        private string[] GetIndexArray(int boardLength)
        {
            string[] indexArray = new string[boardLength];
            for (int i = 0; i < boardLength; i++)
            {
                indexArray[i] = (i + 1).ToString();
            }
            return indexArray;
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
                message = String.Empty;
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
            string[] boardArray = board.GetBoardArray();
            DisplayBoard(board);
            int selection = -1;
            bool done = false;
            while (done == false)
            {
                selection = GetUserInput(input, "\nEnter the number corresponding with your move! (1-" + boardArray.Length + "): ", 1, boardArray.Length);
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
            int selection = GetUserInput(input, "Would you like to play again?\n1.Yes\n2.No", 1, 2);
            return selection == 1 ? true : false;
        }
    }
}