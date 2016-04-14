using System;
using Game.Core;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TddTests
{
    [TestClass]
    public class GameManagerConfigurationTests
    {
        private static GameManager _game = new GameManager();
        [ClassInitialize]
        public static void TestSetup(TestContext context)
        {
            _game = new GameManager();
        }

        [TestMethod]
        public void ConfigureGame_WithNumberOfColumns_ShouldCreateCorrectMatrix()
        {
            const int columns = 3;
            _game.PrepareBoard(columns);

            var board = _game.GetBoardLayout();
            Assert.AreEqual(columns * columns, board.Count);
            foreach (var item in board)
            {
                Assert.AreEqual('\0', item);
            }
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void ConfigureGame_PlayerStarts_WithoutPlayer_ShouldThrowException()
        {
            _game.PlayerStarts(true);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void ConfigureGame_PlayerStarts_WithoutComputer_ShouldThrowException()
        {
            _game.AddPlayer("Player");
            _game.PlayerStarts(true);
        }

        [TestMethod]
        public void ConfigureGame_AddingPlayer_ShouldInitializePlayer()
        {
            const string player = "Maxi";
            _game.AddPlayer(player);

            Assert.AreEqual(player, _game.GetPlayerName());
        }

        [TestMethod]
        public void ConfigureGame_AddingComputer_ShouldInitializeComputer()
        {
            const string computer = "Hal";
            _game.AddComputer(computer);

            Assert.AreEqual(computer, _game.GetComputerName());
        }

        [TestMethod]
        public void ConfigureGame_SettingPlayerAsFirstPlayer_ShouldAssignXToPlayer()
        {
            _game.PlayerStarts(true);

            Assert.AreEqual('X', _game.GetPlayerMark());
            Assert.AreEqual('O', _game.GetComputerMark());
        }

        [TestMethod]
        public void ConfigureGame_SettingComputerAsFirstPlayer_ShouldAssignXToComputer()
        {
            _game.PlayerStarts(false);

            Assert.AreEqual('X', _game.GetComputerMark());
            Assert.AreEqual('O', _game.GetPlayerMark());
        }
    }
}
