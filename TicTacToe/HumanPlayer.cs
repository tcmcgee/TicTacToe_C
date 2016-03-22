using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    public class HumanPlayer : IPlayer
    {
        public int GetMove(Game game, IUserInput input)
        {
            int selection = game.console.GetPlayerMove(game.board, input) - 1;
            return selection;
        }
    }
}