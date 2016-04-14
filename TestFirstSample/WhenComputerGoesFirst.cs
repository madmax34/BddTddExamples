using Game.Core;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestFirstSample
{
    [TestClass]
    public class WhenComputerGoesFirst
    {
        private GameManager _game;

        [TestInitialize]
        public void BeforeEachTest()
        {
            _game = new GameManager();
            _game.PrepareBoard(3);
            _game.AddPlayer("Player 1");
            _game.AddComputer("Hal 0.99");
            _game.PlayerStarts(false);
        }

        [TestMethod]
        public void ItShouldPutAnXInFirstAvailablePosition()
        {
            _game.MakeComputerMove();

            CollectionAssert.Contains(_game.GetBoardLayout(), 'X');
            CollectionAssert.DoesNotContain(_game.GetBoardLayout(), 'O');
        }
    }
}
