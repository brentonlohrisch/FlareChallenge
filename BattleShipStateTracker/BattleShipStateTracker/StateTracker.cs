using System;
using static BattleShipStateTracker.Enums;

namespace BattleShipStateTracker
{
    public class StateTracker
    {
        private int _maxBoardSize = 10;
        private string[,] _playerBoard;

        public StateTracker()
        {
            Setup();
        }

        /// <summary>
        /// Set the board up and optionally set a max size for it.
        /// </summary>
        /// <param name="maxBoardSize">Optionally specify a board size. Default is 10.</param>
        public void Setup(int maxBoardSize = 10)
        {
            _maxBoardSize = maxBoardSize;
            CreateBoard(maxBoardSize);
        }

        /// <summary>
        /// Add a new ship to the player board. Checks are performed to ensure it will fit, and it won't intersect another ship.
        /// </summary>
        /// <param name="newShip">Ship to add.</param>
        /// <returns>True if successfully added. False if it failed the fit or intersection checks.</returns>
        public bool AddShipToBoard(Ship newShip)
        {
            if (!WillShipFitOnBoard(newShip))
                return false;

            if (WillShipIntersectExisting(newShip))
                return false;

            if(newShip.Orientation == ShipOrientation.Vertical)
            {
                for (int row = newShip.StartRow; row < newShip.StartRow + newShip.Length; row++)
                {
                    _playerBoard[row, newShip.StartCol] = newShip.Name;
                }
            }
            else
            {
                for (int col = newShip.StartCol; col < newShip.StartCol + newShip.Length; col++)
                {
                    _playerBoard[newShip.StartRow, col] = newShip.Name;
                }
            }

            return true;
        }

        /// <summary>
        /// Process an attack.
        /// </summary>
        /// <param name="row">Zero based row of the attack coordinate to check.</param>
        /// <param name="col">Zero based column of the attack coordinate to check.</param>
        /// <returns>AttackResult enum, specifying if it's a miss, hit, sink or win.</returns>
        public AttackResult ReceiveAttack(int row, int col)
        {
            if (string.IsNullOrEmpty(_playerBoard[row, col]))
                return AttackResult.Miss;

            string hitShipName = _playerBoard[row, col];
            _playerBoard[row, col] = string.Empty;

            if (IsShipSunk(hitShipName))
            {
                if (IsBoardEmpty())
                    return AttackResult.Win;
                else
                    return AttackResult.Sink;
            }
            else
            {
                return AttackResult.Hit;
            }
        }

        private void CreateBoard(int maxBoardSize)
        {
            _playerBoard = new string[maxBoardSize, maxBoardSize];
        }

        private bool IsShipSunk(string shipName)
        {
            for(int col = 0; col < _maxBoardSize; col++)
            {
                for(int row = 0; row < _maxBoardSize; row++)
                {
                    if (_playerBoard[row, col] == shipName)
                        return false;
                }
            }

            return true;
        }

        private bool WillShipIntersectExisting(Ship newShip)
        {
            if (newShip.Orientation == ShipOrientation.Vertical)
            {
                for(int row = newShip.StartRow; row < newShip.StartRow + newShip.Length; row++)
                {
                    if (!string.IsNullOrEmpty(_playerBoard[row, newShip.StartCol]))
                        return true;
                }
            }
            else
            {
                for(int col = newShip.StartCol; col < newShip.StartCol + newShip.Length; col++)
                {
                    if (!string.IsNullOrEmpty(_playerBoard[newShip.StartRow, col]))
                        return true;
                }
            }

            return false;
        }

        private bool WillShipFitOnBoard(Ship newShip)
        {
            if (newShip.Orientation == ShipOrientation.Vertical)
            {
                if ((newShip.StartRow + newShip.Length) > _maxBoardSize)
                    return false;
            }
            else
            {
                if ((newShip.StartCol + newShip.Length) > _maxBoardSize)
                    return false;
            }

            return true;
        }

        private bool IsBoardEmpty()
        {
            for(int col = 0; col < _maxBoardSize; col++)
            {
                for(int row = 0; row < _maxBoardSize; row++)
                {
                    if(!string.IsNullOrEmpty(_playerBoard[row, col]))
                        return false;
                }
            }

            return true;
        }
               
    }

}
