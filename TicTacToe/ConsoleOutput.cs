using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
