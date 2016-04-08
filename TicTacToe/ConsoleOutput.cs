using System;
using TicTacToe;

namespace TicTacToeConsole
{
    public class ConsoleOutput : IUserOutput
    {
        public void Display(string str)
        {
            Console.WriteLine(str);
        }
    }
}