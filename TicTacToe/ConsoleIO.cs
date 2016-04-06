using System;
using System.Text;

namespace TicTacToe
{
    public class ConsoleIO : IIO
    {
        public IUserOutput output;
        public IUserInput input;

        public ConsoleIO(IUserInput input, IUserOutput output)
        {
            this.input = input;
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

        public string DisplayHelp(Board board)
        {
            int boardLength = board.GetBoardArray().Length;
            Board sampleBoard = new Board(boardLength);

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
            message = GetGameOverMessage(winnerTurn, tie);
            output.Display(message);
            return message;
        }

        private static string GetGameOverMessage(bool winnerTurn, bool tie)
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

            return message;
        }

        public int GetUserInput(string message, int low, int high)
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

        public int GetPlayerMove(Board board)
        {
            string[] boardArray = board.GetBoardArray();
            DisplayBoard(board);
            int selection = -1;
            bool done = false;
            while (done == false)
            {
                selection = GetUserInput("\nEnter the number corresponding with your move! (1-" + boardArray.Length + "): ", 1, boardArray.Length);
                done = (boardArray[selection - 1] == null);
                if (done == false)
                {
                    output.Display("Please Select an unoccupied space!");
                }
            }
            return selection;
        }

        public bool GetPlayAgain()
        {
            int selection = GetUserInput("Would you like to play again?\n1.Yes\n2.No", 1, 2);
            return selection == 1 ? true : false;
        }

        public int GetBoardSize()
        {
            int selection = GetUserInput("What size board would you like to play on?\n1.3x3\n2.4x4", 1, 2);
            return selection == 1 ? 9 : 16;
        }

        public bool GetPlayerType(int playerNumber)
        {
            int selection = GetUserInput("What type of player is Player" + playerNumber + "?\n1.Human\n2.Computer", 1, 2);
            return selection == 1;
        }
    }
}