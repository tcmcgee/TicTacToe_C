using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicTacToe;

namespace TicTacToe.Tests
{
    [TestClass()]
    public class HardComputerTests
    {
        private Game game;
        private HardComputer computer;

        private string[] emptyBoard = new string[] { null, null, null, null, null, null, null, null, null };

        [TestInitialize()]
        public void TestInitialize()

        {
            computer = new HardComputer();
            game = new Game(new HumanPlayer(), computer);
        }

        [TestMethod()]
        public void Moves()
        {
            Assert.Fail();
        }
    }
}