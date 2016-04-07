using TicTacToe;

namespace TicTacToeTests
{
    public class MockedInput : IUserInput
    {
        private string mockedInput;

        public MockedInput(string mockedInput)
        {
            this.mockedInput = mockedInput;
        }

        public string GetInput()
        {
            return mockedInput;
        }
    }
}