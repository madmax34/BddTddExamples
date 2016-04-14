using Game.Core;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestFirstSample
{
    [TestClass]
    public class BeforeGameStarts
    {
        [TestMethod]
        public void ItShouldAskForTheNumberOfColumns()
        {
            const int numberOfColumns = 3;

            var gameManager = new GameManager();
            gameManager.PrepareBoard(numberOfColumns);

            Assert.AreEqual(numberOfColumns * numberOfColumns, gameManager.GetBoardLayout().Count);
            CollectionAssert.DoesNotContain(gameManager.GetBoardLayout(), 'X');
            CollectionAssert.DoesNotContain(gameManager.GetBoardLayout(), 'O');
        }

        [TestMethod]
        public void ItShouldAskForThePlayersName()
        {
            const string player = "Player 1";
            var gameManager = new GameManager();
            gameManager.AddPlayer(player);

            Assert.AreEqual(player, gameManager.GetPlayerName());
        }

        [TestMethod]
        public void ItShouldAskForTheComputerName()
        {
            const string computer = "Hal";
            var gameManager = new GameManager();
            gameManager.AddComputer(computer);

            Assert.AreEqual(computer, gameManager.GetComputerName());
        }

        [TestMethod]
        public void ItShouldAskIfThePlayerMovesFirst()
        {
            var gameManager = new GameManager();
            gameManager.AddPlayer("Me");
            gameManager.AddComputer("Hal");
            gameManager.PlayerStarts(true);

            Assert.AreEqual('X', gameManager.GetPlayerMark());
            Assert.AreEqual('O', gameManager.GetComputerMark());

            gameManager.PlayerStarts(false);

            Assert.AreEqual('O', gameManager.GetPlayerMark());
            Assert.AreEqual('X', gameManager.GetComputerMark());
        }
    }
}