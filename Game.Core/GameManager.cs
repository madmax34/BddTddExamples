using System;
using System.Collections.Generic;
using System.Linq;

namespace Game.Core
{
    public class GameManager
    {
        private const char Empty = '\0';
        private List<char> _boardLayout;
        private Player _humanPlayer;
        private Player _computerPlayer;

        public GameManager()
        {
        }
        
        public void PrepareBoard(int numberOfColumns)
        {
            _boardLayout = new List<char>(numberOfColumns * numberOfColumns);

            for (int i = 0; i < _boardLayout.Capacity; i++)
            {
                _boardLayout.Add(Empty);
            }
        }

        public void PlayerStarts(bool playerStarts)
        {
            if (_humanPlayer == null)
            {
                throw new InvalidOperationException("No se ha agregado un jugador humano al juego");
            }

            if (_computerPlayer == null)
            {
                throw new InvalidOperationException("No se ha agregado el jugador de la computadora al juego");
            }

            _humanPlayer.PlayerStartsFirst(playerStarts);
            _computerPlayer.PlayerStartsFirst(!playerStarts);
        }

        public void AddPlayer(string player)
        {
            _humanPlayer = new Player(player);
        }

        public void AddComputer(string computer)
        {
            _computerPlayer = new Player(computer);
        }

        public string GetPlayerName()
        {
            return _humanPlayer.GetName();
        }

        public string GetComputerName()
        {
            return _computerPlayer.GetName();
        }

        public List<char> GetBoardLayout()
        {
            return _boardLayout;
        }

        public void ChoosePosition(int selectedPosition)
        {
            _humanPlayer.SetPosition(selectedPosition, _boardLayout);
            MakeComputerMove();
        }

        public char GetMarkAtPosition(int position)
        {
            return _boardLayout[position];
        }

        public void MakeComputerMove()
        {
            int firstUnoccupied = Enumerable.Range(0, _boardLayout.Count())
                                            .First(p => _boardLayout[p].Equals('\0'));

            _computerPlayer.SetPosition(firstUnoccupied, _boardLayout);
        }

        public char GetPlayerMark()
        {
            return _humanPlayer.GetMark();
        }

        public char GetComputerMark()
        {
            return _computerPlayer.GetMark();
        }
    }
}
