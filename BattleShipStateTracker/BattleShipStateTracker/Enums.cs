using System;
using System.Collections.Generic;
using System.Text;

namespace BattleShipStateTracker
{
    public class Enums
    {
        /// <summary>
        /// Direction that a ship is oriented on the board.
        /// </summary>
        public enum ShipOrientation
        {
            Vertical,
            Horizontal
        }

        /// <summary>
        /// The result of an attack.
        /// </summary>
        public enum AttackResult
        {
            Hit,
            Miss,
            Sink,
            Win
        }
    }
}
