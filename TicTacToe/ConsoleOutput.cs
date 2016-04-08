using System;
using TicTacToe;

namespace TicTacToe
{
    public class ConsoleOutput : IUserOutput
    {
        public void Display(string str)
        {
            Console.WriteLine(str);
        }
    }
}