using System;
using System.Collections.Generic;
using System.Text;
using static BattleShipStateTracker.Enums;

namespace BattleShipStateTracker
{
    public class Ship
    {
        /// <summary>
        /// Name of the ship. Must be unique.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Length of the ship. Must be at least 1.
        /// </summary>
        public int Length { get; set; }

        /// <summary>
        /// Zero based start row.
        /// </summary>
        public int StartRow { get; set; }

        /// <summary>
        /// Zero based start column.
        /// </summary>
        public int StartCol { get; set; }

        /// <summary>
        /// Orientation of the ship, being down or to the right of the starting coordinates.
        /// </summary>
        public ShipOrientation Orientation { get; set; }
    }
}
