using System;
using System.Linq;
using Game.Core;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TechTalk.SpecFlow;

namespace SpecFlowTests
{
    [Binding]
    public class ComputerGoesFirstSteps
    {
        private GameManager _game;

        [Given(@"I am the second player in a (.*) columns and rows grid")]
        public void GivenIAmTheSecondPlayerInAColumnsAndRowsGrid(int columns)
        {
            _game = new GameManager();
            _game.AddPlayer("Maxi");
            _game.AddComputer("Hal");
            _game.PrepareBoard(columns);
            _game.PlayerStarts(false);
        }
        
        [When(@"the game starts")]
        public void WhenTheGameStarts()
        {
            _game.MakeComputerMove();
        }

        [Then(@"the computer automatically makes it first move to (.*) element")]
        public void ThenTheComputerAutomaticallyMakesItFirstMoveToElement(int position)
        {
            var board = _game.GetBoardLayout();

            var currentPosition = board.IndexOf('X');

            var numberOfX = board.Count(x => x == 'X');

            Assert.AreEqual(position, currentPosition);
            Assert.AreEqual(1, numberOfX);
        }
    }
}
