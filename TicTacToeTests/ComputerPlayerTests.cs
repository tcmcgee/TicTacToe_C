using TicTacToe;
using Xunit;

namespace TicTacToeTests
{
    public class ComputerPlayerTests
    {
        [Fact]
        public void ChoosesToWin()
        {
            Game game = new Game(9);
            game.board.SetBoard(new string[] {"X","X",null,
                                              "O",null,null,
                                             null, null, "X"});
            ComputerPlayer computer = new ComputerPlayer();
            int move = computer.GetMove(game);

            Assert.Equal(2, move);
        }

        [Fact]
        public void BlocksAnImmediateWin()
        {
            Game game = new Game(9);
            game.board.SetBoard(new string[] {"X","X",null,
                                              "O",null,null,
                                             null, null, "O"});
            ComputerPlayer computer = new ComputerPlayer();
            int move = computer.GetMove(game);

            Assert.Equal(2, move);
        }

        [Fact]
        public void TakesCornerIfFirst()
        {
            Game game = new Game(9);
            game.board.SetBoard(new string[] {null,null,null,
                                              null,null,null,
                                             null, null, null});
            ComputerPlayer computer = new ComputerPlayer();
            int move = computer.GetMove(game);

            Assert.Equal(0, move);
        }

        [Fact]
        public void TakesCenterIfSecond()
        {
            Game game = new Game(9);
            game.board.SetBoard(new string[] {"X",null,null,
                                              null,null,null,
                                             null, null, null});
            ComputerPlayer computer = new ComputerPlayer();
            int move = computer.GetMove(game);

            Assert.Equal(4, move);
        }

        [Fact]
        public void NeverLosesAGameIfItGoesSecond()
        {
            Game game = new Game(9);

            Assert.True(PlayAllGames(game, game.board.GetBoardArray(), true));
        }

        [Fact]
        public void NeverLosesAGameIfItGoesFirst()
        {
            Game game = new Game(9);

            Assert.True(PlayAllGames(game, game.board.GetBoardArray(), false));
        }

        [Fact]
        public void BlocksAnImmediateLossLargeBoard()
        {
            Game game = new Game(16);
            game.board.SetBoard(new string[] {"X","X","X",null,
                                              "O",null,null,null,
                                              null,"O",null,null,
                                             null, null, null,null});
            ComputerPlayer computer = new ComputerPlayer();
            int move = computer.GetMove(game);

            Assert.Equal(move, 3);
        }

        [Fact]
        public void BlocksAnImmediateDiagonalLossLargeBoard()
        {
            Game game = new Game(16);
            game.board.SetBoard(new string[] {"X",null,null,null,
                                              "O","X",null,null,
                                              null,"O","X",null,
                                             null, null, null,null});
            ComputerPlayer computer = new ComputerPlayer();
            int move = computer.GetMove(game);

            Assert.Equal(move, 15);
        }

        [Fact]
        public void PrefersAnImmediateWinLargeBoard()
        {
            Game game = new Game(16);
            game.board.SetBoard(new string[] {"X","X","X",null,
                                              "O","O","O",null,
                                              null,null,null,null,
                                             null, null, null,"X"});
            ComputerPlayer computer = new ComputerPlayer();
            int move = computer.GetMove(game);

            Assert.Equal(move, 7);
        }

        public bool PlayAllGames(Game game, string[] boardArray, bool turn)
        {
            ComputerPlayer computer = new ComputerPlayer();
            game.board.SetBoard(boardArray);
            bool over = false;
            if (game.IsWinner(true))
            {
                game.IO.DisplayBoard(game.board);
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