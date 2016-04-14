using System.Linq;
using Game.Core;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TddTests
{
    [TestClass]
    public class GameManagerPlayerMovesFirst
    {
        private static GameManager _game;

        [ClassInitialize]
        public static void TestSetup(TestContext context)
        {
            _game = new GameManager();
            _game.AddPlayer("Maxi");
            _game.AddComputer("Hal");
            _game.PrepareBoard(3);
            _game.PlayerStarts(true);
        }

        [TestMethod]
        public void PlayerStarts_PlayerSelectsPosition_ShouldPositionPlayerAndComputerMoves()
        {
            const int position = 5;
            _game.ChoosePosition(position);

            var board = _game.GetBoardLayout();

            var valueAtPosition = board[position];

            Assert.AreEqual('X', valueAtPosition);

            var currentComputerPosition = board.IndexOf('O');

            var numberOfX = board.Count(x => x == 'X');
            var numberOfO = board.Count(x => x == 'O');

            Assert.AreEqual(0, currentComputerPosition);
            Assert.AreEqual(1, numberOfX);
            Assert.AreEqual(1, numberOfO);
        }
    }
}
