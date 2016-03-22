using System;
using System.Collections.Generic;
using System.Linq;

namespace TicTacToe
{
    public class ComputerPlayer
    {
        private Game game;

        public ComputerPlayer(Game game)
        {
            this.game = new Game();
        }

        public int negamax(string[] boardArray, bool turn, int depth, Dictionary<String, int> moveValues)
        {
            game.board.SetBoard(boardArray);
            if ((game.IsGameOver(turn) || game.IsGameOver(!turn)) && !game.IsTie())
            {
                return -10 * ((boardArray.Length) - depth);
            }
            else if (game.IsTie())
            {
                return 0;
            }

            for (int i = 0; i < boardArray.Length; i++)
            {
                if (boardArray[i] == null)
                {
                    string[] newBoardArray = (string[])boardArray.Clone();
                    newBoardArray[i] = game.GetPiece(turn);
                    moveValues[i.ToString()] = -1 * negamax(newBoardArray, !turn, depth + 1, new Dictionary<string, int>());
                }
            }

            if (depth == 0)
            {
                string keyOfMaxValue = moveValues.FirstOrDefault(x => x.Value == moveValues.Values.Max()).Key;
                return int.Parse(keyOfMaxValue);
            }
            else {
                string keyOfMaxValue2 = moveValues.FirstOrDefault(x => x.Value == moveValues.Values.Max()).Key;
                return moveValues[keyOfMaxValue2];
            }
        }
    }
}