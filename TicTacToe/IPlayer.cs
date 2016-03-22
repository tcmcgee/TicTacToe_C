using System;

namespace TicTacToe
{
    public interface IPlayer
    {
        int GetMove(Game game, IUserInput input);
    }
}