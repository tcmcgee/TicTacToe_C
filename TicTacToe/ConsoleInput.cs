using System;
using TicTacToe;

namespace TicTacToeConsole
{
    public class ConsoleInput : IUserInput
    {
        public string GetInput()
        {
            return Console.ReadLine().Trim();
        }
    }
}