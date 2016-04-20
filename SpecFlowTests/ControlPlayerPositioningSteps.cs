using System;
using Game.Core;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TechTalk.SpecFlow;

namespace SpecFlowTests
{
    [Binding]
    public class ControlPlayerPositioningSteps
    {
        private GameManager _game;

        [Given(@"I select position (.*)")]
        public void GivenISelectPosition(int position)
        {
            _game = new GameManager();
            _game.AddPlayer("Maxi");
            _game.AddComputer("Hal");
            _game.PrepareBoard(3);
            _game.PlayerStarts(true);
            _game.ChoosePosition(position);
        }
        
        [Given(@"position (.*) is allready taken")]
        public void GivenPositionIsAllreadyTaken(int position)
        {
            try
            {
                _game.ChoosePosition(position);
            }
            catch (Exception e)
            {
                Assert.AreEqual("La posición ya ha sido tomada", e.Message);
            }
            
        }
        
        [Then(@"the system should warn me")]
        public void ThenTheSystemShouldWarnMe()
        {
            var warning = _game.GetWarning();
            Assert.AreEqual("La posición ya ha sido tomada", warning);
        }
    }
}
