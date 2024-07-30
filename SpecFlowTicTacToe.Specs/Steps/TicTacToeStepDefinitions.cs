using System;
using TechTalk.SpecFlow;
using Xunit;

namespace SpecFlowTicTacToe.Specs.Steps
{
    [Binding]
    public sealed class TicTacToeStepDefinitions
    {
        private readonly TicTacToe _ticTacToe;
        private bool _moveResult;
        private bool _isDraw;
        private bool _isWin;

        public TicTacToeStepDefinitions()
        {
            _ticTacToe = new TicTacToe();
        }

        [Given("a new TicTacToe game")]
        public void GivenANewTicTacToeGame()
        {
            // Nothing to do here, the TicTacToe constructor initializes the game
        }

        [When("player (.*) makes a move at row (.*) and column (.*)")]
        public void WhenPlayerMakesAMove(char player, int row, int col)
        {
            if (_ticTacToe.GetCurrentPlayer() != player)
            {
                _ticTacToe.ChangePlayer();
            }

            _moveResult = _ticTacToe.MakeMove(row, col);
        }

        [Then("the cell at row (.*) and column (.*) should be \"(.*)\"")]
        public void ThenTheCellAtRowAndColumnShouldBe(int row, int col, char expectedValue)
        {
            Assert.Equal(expectedValue, _ticTacToe.GetBoardValue(row, col));
        }

        [Then("the move should be invalid")]
        public void ThenTheMoveShouldBeInvalid()
        {
            Assert.False(_moveResult);
        }

        [When("the game is checked for a win")]
        public void WhenTheGameIsCheckedForAWin()
        {
            _isWin = _ticTacToe.CheckForWin();
        }

        [Then("player (.*) should be the winner")]
        public void ThenPlayerShouldBeTheWinner(char player)
        {
            Assert.True(_isWin);
            Assert.Equal(player, _ticTacToe.GetCurrentPlayer());
        }

        [When("the game is checked for a draw")]
        public void WhenTheGameIsCheckedForADraw()
        {
            _isDraw = _ticTacToe.IsDraw();
        }

        [Then("the game should be a draw")]
        public void ThenTheGameShouldBeADraw()
        {
            Assert.False(_isDraw);
        }
    }
}
