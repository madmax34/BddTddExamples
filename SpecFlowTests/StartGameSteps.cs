using Game.Core;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TechTalk.SpecFlow;

namespace SpecFlowTests
{
    [Binding]
    public class StartGameSteps
    {
        private GameManager _gameManager;
        [BeforeScenario()]
        public void Hook()
        {
            _gameManager = new GameManager();
        }

        [Given(@"I enter (.*) as the number of columns")]
        public void GivenIEnterAsTheNumberOfColumns(int columns)
        {
            _gameManager.PrepareBoard(columns);
        }
        
        [Given(@"also I enter ""(.*)"" as my name")]
        public void GivenAlsoIEnterAsMyName(string player)
        {
            _gameManager.AddPlayer(player);
        }
        
        [Given(@"also I enter ""(.*)"" as the computer name")]
        public void GivenAlsoIEnterAsTheComputerName(string computerName)
        {
            _gameManager.AddComputer(computerName);
        }
        
        [Given(@"also I select ""(.*)"" as I whant to start first")]
        public void GivenAlsoISelectAsIWhantToStartFirst(string comenzarPrimero)
        {
            var comenzar = comenzarPrimero == "Sí";
            _gameManager.PlayerStarts(comenzar);
        }
        
        [Given(@"also I select ""(.*)"" as I don't whant to start first")]
        public void GivenAlsoISelectAsIDonTWhantToStartFirst(string comenzarPrimero)
        {
            var comenzar = comenzarPrimero == "Sí";
            _gameManager.PlayerStarts(comenzar);
        }
        
        [Then(@"the board should be initialized to (.*) elements")]
        public void ThenTheBoardShouldBeInitializedToElements(int elements)
        {
            var boardLayout = _gameManager.GetBoardLayout();
            Assert.AreEqual(elements, boardLayout.Count);
        }
        
        [Then(@"my player name should show ""(.*)"" on screen")]
        public void ThenMyPlayerNameShouldShowOnScreen(string playerName)
        {
            var player = _gameManager.GetPlayerName();
            Assert.AreEqual(playerName, player);
        }
        
        [Then(@"the computer name should be ""(.*)""")]
        public void ThenTheComputerNameShouldBe(string computerName)
        {
            var computer = _gameManager.GetComputerName();
            Assert.AreEqual(computerName, computer);
        }
        
        [Then(@"my name should be decorated with an ""(.*)""")]
        public void ThenMyNameShouldBeDecoratedWithAn(string expectedMark)
        {
            var mark = _gameManager.GetPlayerMark().ToString();

            Assert.AreEqual(expectedMark, mark);
        }
    }
}
