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
    public class ComputerPlayerTests
    {
        [TestMethod()]
        public void ChoosesToWin()
        {
            Game game = new Game();
            game.board.SetBoard(new string[] {"X","X",null,
                                              "O",null,null,
                                             null, null, "X"});
            ComputerPlayer computer = new ComputerPlayer(game);
            int move = computer.negamax(game.board.GetBoardArray(), true, 0, new Dictionary<string, int>());

            Assert.AreEqual(2, move);
        }

        [TestMethod()]
        public void BlocksAnImmediateWin()
        {
            Game game = new Game();
            game.board.SetBoard(new string[] {"X","X",null,
                                              "O",null,null,
                                             null, null, "O"});
            ComputerPlayer computer = new ComputerPlayer(game);
            int move = computer.negamax(game.board.GetBoardArray(), false, 0, new Dictionary<string, int>());

            Assert.AreEqual(2, move);
        }

        [TestMethod()]
        public void TakesCornerIfFirst()
        {
            Game game = new Game();
            game.board.SetBoard(new string[] {null,null,null,
                                              null,null,null,
                                             null, null, null});
            ComputerPlayer computer = new ComputerPlayer(game);
            int move = computer.negamax(game.board.GetBoardArray(), false, 0, new Dictionary<string, int>());

            Assert.AreEqual(0, move);
        }

        [TestMethod()]
        public void TakesCenterIfSecond()
        {
            Game game = new Game();
            game.board.SetBoard(new string[] {"X",null,null,
                                              null,null,null,
                                             null, null, null});
            ComputerPlayer computer = new ComputerPlayer(game);
            int move = computer.negamax(game.board.GetBoardArray(), false, 0, new Dictionary<string, int>());

            Assert.AreEqual(4, move);
        }
    }
}