namespace TicTacToe
{
    public class HumanPlayer : IPlayer
    {
        public int GetMove(Game activeGame)
        {
            return activeGame.IO.GetPlayerMove(activeGame.board) - 1;
        }
    }
}