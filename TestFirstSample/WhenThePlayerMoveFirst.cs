using System;
using Game.Core;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestFirstSample
{
    [TestClass]
    public class WhenThePlayerMovesFirst
    {
        private GameManager _game;

        [TestInitialize]
        public void BeforeEachTest()
        {
            _game = new GameManager();
            _game.PrepareBoard(3);
            _game.AddPlayer("Player 1");
            _game.AddComputer("Hal 0.99");
            _game.PlayerStarts(true);
        }

        [TestMethod]
        public void ItShouldPutTheirChoiceInTheSelectedPosition()
        {
            const int selectedPosition = 5;

            _game.ChoosePosition(selectedPosition);

            Assert.AreEqual('X', _game.GetMarkAtPosition(selectedPosition));
        }

        [TestMethod]
        public void ItShouldMakeTheNextMove()
        {
            _game.MakeComputerMove();

            CollectionAssert.Contains(_game.GetBoardLayout(), 'O');
        }
    }
}
