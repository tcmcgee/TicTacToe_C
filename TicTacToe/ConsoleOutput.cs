using System;
using IUserOutput = TicTacToe.IUserOutput;

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