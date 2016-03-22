using System;

namespace TicTacToe
{
    public class ConsoleInput : IUserInput
    {
        public string GetInput()
        {
            return Console.ReadLine().Trim();
        }
    }
}