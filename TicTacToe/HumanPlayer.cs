namespace TicTacToe
{
    public class HumanPlayer : IPlayer
    {
        public int GetMove(Game activeGame)
        {
            return activeGame.console.GetPlayerMove(activeGame.board) - 1;
        }
    }
}