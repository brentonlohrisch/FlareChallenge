using System;
using System.Collections.Generic;
using System.Text;

namespace BattleShipStateTracker
{
    public class Enums
    {
        public enum ShipOrientation
        {
            Vertical,
            Horizontal
        }

        public enum AttackResult
        {
            Hit,
            Miss,
            Sink,
            Win
        }
    }
}
