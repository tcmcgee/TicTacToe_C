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
            this.game.board.SetBoard(game.board.GetBoardArray());
        }

        public int negamax(string[] boardArray, bool turn, int depth, Dictionary<String, int> moveValues)
        {
            game.board.SetBoard(boardArray);
            if (game.HasWinner())
            {
                return -10 * (boardArray.Length - depth);
            }
            else if (game.IsTie())
            {
                return 0;
            }
            PlayOpenMoves(boardArray, turn, depth, moveValues);
            string keyOfMaxValue = GetKeyOfHighestValue(moveValues);
            if (depth == 0)
            {
                return int.Parse(keyOfMaxValue);
            }
            else
            {
                return moveValues[keyOfMaxValue];
            }
        }

        private static string GetKeyOfHighestValue(Dictionary<string, int> moveValues)
        {
            return moveValues.FirstOrDefault(x => x.Value == moveValues.Values.Max()).Key;
        }

        private void PlayOpenMoves(string[] boardArray, bool turn, int depth, Dictionary<string, int> moveValues)
        {
            for (int i = 0; i < boardArray.Length; i++)
            {
                if (boardArray[i] == null)
                {
                    string[] newBoardArray = (string[])boardArray.Clone();
                    newBoardArray[i] = game.GetPiece(turn);
                    moveValues[i.ToString()] = -1 * negamax(newBoardArray, !turn, depth + 1, new Dictionary<string, int>());
                }
            }
        }
    }
}