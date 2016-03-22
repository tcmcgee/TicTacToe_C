using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    public class HardComputer : IPlayer
    {
        public int GetMove(Game game, IUserInput input)
        {
            return 1;
        }
    }
}