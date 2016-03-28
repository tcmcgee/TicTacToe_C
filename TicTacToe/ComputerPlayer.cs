using System;
using System.Collections.Generic;
using System.Linq;

namespace TicTacToe
{
    public class ComputerPlayer : IPlayer
    {
        private Game game;

        public ComputerPlayer()
        {
        }

        public int GetMove(Game activeGame)
        {
            this.game = new Game(activeGame.board.GetBoardArray().Length);
            this.game.board.SetBoard(activeGame.board.GetBoardArray());
            Dictionary<string, int> emptyDict = new Dictionary<string, int>();
            string[] boardArray = activeGame.board.GetBoardArray();
            this.game.board.SetBoard(boardArray);
            int move = negamax(boardArray, false, 0, new Dictionary<string, int>());
            return move;
        }

        public int negamax(string[] boardArray, bool turn, int depth, Dictionary<String, int> moveValues)
        {
            game.board.SetBoard(boardArray);

            if (game.HasWinner())
            {
                return ScoreWithDepthModifier(boardArray, depth);
            }
            else if (game.IsTie())
            {
                return 0;
            }
            else if (IsFourByFour(boardArray) && depth >= 5)
            {
                Random generator = new Random();
                return (int)(generator.NextDouble() * 5);
            }
            PlayOpenMoves(boardArray, turn, depth, moveValues);

            if (depth == 0)
            {
                return int.Parse(GetKeyOfHighestValue(moveValues));
            }
            else
            {
                return GetHighestValue(moveValues);
            }
        }

        private static bool IsFourByFour(string[] boardArray)
        {
            return boardArray.Length == 16;
        }

        private static int ScoreWithDepthModifier(string[] boardArray, int depth)
        {
            return -10 * (boardArray.Length - depth);
        }

        private static string GetKeyOfHighestValue(Dictionary<string, int> moveValues)
        {
            return moveValues.FirstOrDefault(x => x.Value == moveValues.Values.Max()).Key;
        }

        private static int GetHighestValue(Dictionary<string, int> moveValues)
        {
            return moveValues.FirstOrDefault(x => x.Value == moveValues.Values.Max()).Value;
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