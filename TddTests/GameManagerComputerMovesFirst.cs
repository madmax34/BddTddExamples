using System.Linq;
using Game.Core;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TddTests
{
    [TestClass]
    public class GameManagerComputerMovesFirst
    {
        private static GameManager _game;

        [ClassInitialize]
        public static void TestSetup(TestContext context)
        {
            _game = new GameManager();
            _game.AddPlayer("Maxi");
            _game.AddComputer("Hal");
            _game.PrepareBoard(3);
            _game.PlayerStarts(false);
        }

        [TestMethod]
        public void ComputerStarts_ComputerSelectsPosition_ShouldPositionComputer()
        {
            _game.MakeComputerMove();
            var board = _game.GetBoardLayout();

            var valueAtPosition = board[0];

            Assert.AreEqual('X', valueAtPosition);

            var numberOfX = board.Count(x => x == 'X');
            var numberOfO = board.Count(x => x == 'O');

            Assert.AreEqual(1, numberOfX);
            Assert.AreEqual(0, numberOfO);
        }
    }
}
