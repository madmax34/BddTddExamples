using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game.Core;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TddTests
{
    [TestClass]
    public class ControlPlayerPositioning
    {
        private GameManager _game;

        [TestInitialize]
        public void Setup()
        {
            _game = new GameManager();
            _game.AddPlayer("Maxi");
            _game.AddComputer("Hal");
            _game.PrepareBoard(3);
            _game.PlayerStarts(true);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException), "La posición ya ha sido tomada")]
        public void ControlPlayerPositioning_WithOccupiedPosition_ShouldThrowException()
        {
            const int position = 5;
            _game.ChoosePosition(position);

            _game.ChoosePosition(position);
        }
    }
}
