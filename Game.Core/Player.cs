using System.Collections.Generic;

namespace Game.Core
{
    public class Player
    {
        private const char FirstPlayerMark = 'X';
        private const char SecondPlayerMark = 'O';
        private readonly string _name;
        private bool _isFirstPlayer;

        public Player(string name)
        {
            _name = name;
        }

        public void PlayerStartsFirst(bool startsFirst)
        {
            _isFirstPlayer = startsFirst;
        }

        public char GetMark()
        {
            return _isFirstPlayer ? FirstPlayerMark : SecondPlayerMark;
        }

        public string GetName()
        {
            return _name;
        }

        public void SetPosition(int selectedPosition, List<char> boardLayout)
        {
            boardLayout[selectedPosition] = GetMark();
        }
    }
}