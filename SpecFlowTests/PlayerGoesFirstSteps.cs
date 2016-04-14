using System;
using System.Linq;
using Game.Core;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TechTalk.SpecFlow;

namespace SpecFlowTests
{
    [Binding]
    public class PlayerGoesFirstSteps
    {
        private GameManager _game;

        [Given(@"I am the first player in a (.*) columns and rows grid")]
        public void GivenIAmTheFirstPlayerInAColumnsAndRowsGrid(int columns)
        {
            _game = new GameManager();
            _game.AddPlayer("Maxi");
            _game.AddComputer("Hal");
            _game.PrepareBoard(columns);
            _game.PlayerStarts(true);
        }
        
        [When(@"I enter the position (.*) for my mark position")]
        public void WhenIEnterThePositionForMyMarkPosition(int position)
        {
            _game.ChoosePosition(position);
        }
        
        [Then(@"an X is positioned in the (.*) element")]
        public void ThenAnXIsPositionedInTheElement(int position)
        {
            var board = _game.GetBoardLayout();

            var value = board[position];

            Assert.AreEqual('X', value);
        }

        [Then(@"the computer makes it first move to (.*) element")]
        public void ThenTheComputerMakesItFirstMoveToElement(int position)
        {
            var board = _game.GetBoardLayout();

            var currentPosition = board.IndexOf('O');

            var numberOfX = board.Count(x => x == 'X');
            var numberOfO = board.Count(x => x == 'O');

            Assert.AreEqual(position, currentPosition);
            Assert.AreEqual(1, numberOfX);
            Assert.AreEqual(1, numberOfO);
        }
    }
}
