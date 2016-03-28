using Microsoft.VisualStudio.TestTools.UnitTesting;

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
            ComputerPlayer computer = new ComputerPlayer();
            int move = computer.GetMove(game);

            Assert.AreEqual(2, move);
        }

        [TestMethod()]
        public void BlocksAnImmediateWin()
        {
            Game game = new Game();
            game.board.SetBoard(new string[] {"X","X",null,
                                              "O",null,null,
                                             null, null, "O"});
            ComputerPlayer computer = new ComputerPlayer();
            int move = computer.GetMove(game);

            Assert.AreEqual(2, move);
        }

        [TestMethod()]
        public void TakesCornerIfFirst()
        {
            Game game = new Game();
            game.board.SetBoard(new string[] {null,null,null,
                                              null,null,null,
                                             null, null, null});
            ComputerPlayer computer = new ComputerPlayer();
            int move = computer.GetMove(game);

            Assert.AreEqual(0, move);
        }

        [TestMethod()]
        public void TakesCenterIfSecond()
        {
            Game game = new Game();
            game.board.SetBoard(new string[] {"X",null,null,
                                              null,null,null,
                                             null, null, null});
            ComputerPlayer computer = new ComputerPlayer();
            int move = computer.GetMove(game);

            Assert.AreEqual(4, move);
        }

        [TestMethod()]
        public void NeverLosesAGameIfItGoesSecond()
        {
            Game game = new Game();

            Assert.IsTrue(PlayAllGames(game, game.board.GetBoardArray(), true));
        }

        [TestMethod()]
        public void NeverLosesAGameIfItGoesFirst()
        {
            Game game = new Game();

            Assert.IsTrue(PlayAllGames(game, game.board.GetBoardArray(), false));
        }

        public bool PlayAllGames(Game game, string[] boardArray, bool turn)
        {
            ComputerPlayer computer = new ComputerPlayer();
            game.board.SetBoard(boardArray);
            bool over = false;
            if (game.IsWinner(true))
            {
                game.console.DisplayBoard(game.board);
                over = true;
                return false;
            }
            if (game.IsWinner(false))
            {
                over = true;
            }
            if (game.IsTie())
            {
                over = true;
            }

            string[] boardArrayClone = (string[])boardArray.Clone();

            if (!over)
            {
                if (turn)
                {
                    for (int i = 0; i < boardArrayClone.Length; i++)
                    {
                        if (boardArrayClone[i] == null)
                        {
                            boardArrayClone[i] = "X";
                            if (!PlayAllGames(game, boardArrayClone, !turn))
                            {
                                return false;
                            }
                            boardArrayClone[i] = null;
                        }
                    }
                }
                else
                {
                    int move = computer.GetMove(game);
                    boardArrayClone[move] = "O";
                    if (!PlayAllGames(game, boardArrayClone, !turn))
                    {
                        return false;
                    }
                }
            }

            return true;
        }
    }
}