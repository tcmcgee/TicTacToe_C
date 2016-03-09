using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
