using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    public class HumanPlayer : IPlayer
    {
        public int GetMove(Game activeGame)
        {
            return activeGame.console.GetPlayerMove(activeGame.board) - 1;
        }
    }
}