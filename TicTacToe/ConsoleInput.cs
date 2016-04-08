using System;
using IUserInput = TicTacToe.IUserInput;

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