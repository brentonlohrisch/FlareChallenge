using BattleShipStateTracker;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BattleShipStateTrackerTests
{
    [TestClass]
    public class StateTrackerTests
    {
        private StateTracker _stateTracker = new StateTracker();

        [TestMethod]
        public void AddShipToBoard_Pass()
        {
            _stateTracker.Setup();
            
            Ship newShip = new Ship() { Name = "s1", StartRow = 0, StartCol = 0, Length = 4, Orientation = Enums.ShipOrientation.Horizontal };
            
            var result = _stateTracker.AddShipToBoard(newShip);
            
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void AddShipToBoard_Fail_TooLong()
        {
            _stateTracker.Setup();
            
            Ship newShip = new Ship() { Name = "s1", StartRow = 0, StartCol = 0, Length = 11, Orientation = Enums.ShipOrientation.Horizontal };
            
            var result = _stateTracker.AddShipToBoard(newShip);
            
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void AddShipToBoard_Pass_MaxLength()
        {
            _stateTracker.Setup();
            
            Ship newShip = new Ship() { Name = "s1", StartRow = 0, StartCol = 0, Length = 10, Orientation = Enums.ShipOrientation.Horizontal };
            
            var result = _stateTracker.AddShipToBoard(newShip);
            
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void AddShipToBoard_Fail_IntersectsExistingShip()
        {
            _stateTracker.Setup();
            
            Ship newShip1 = new Ship() { Name = "s1", StartRow = 0, StartCol = 0, Length = 10, Orientation = Enums.ShipOrientation.Horizontal };
            _stateTracker.AddShipToBoard(newShip1);
            Ship newShip2 = new Ship() { Name = "s2", StartRow = 0, StartCol = 0, Length = 10, Orientation = Enums.ShipOrientation.Vertical };
            
            var result = _stateTracker.AddShipToBoard(newShip2);
            
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void Attack_Pass_IsMiss()
        {
            _stateTracker.Setup();
            
            Ship newShip1 = new Ship() { Name = "s1", StartRow = 0, StartCol = 0, Length = 10, Orientation = Enums.ShipOrientation.Horizontal };
            _stateTracker.AddShipToBoard(newShip1);
            
            var result = _stateTracker.ReceiveAttack(2, 2);

            Assert.AreEqual<Enums.AttackResult>(result, Enums.AttackResult.Miss);
        }

        [TestMethod]
        public void Attack_Pass_IsHit()
        {
            _stateTracker.Setup();
            
            Ship newShip1 = new Ship() { Name = "s1", StartRow = 0, StartCol = 0, Length = 10, Orientation = Enums.ShipOrientation.Horizontal };
            _stateTracker.AddShipToBoard(newShip1);
            
            var result = _stateTracker.ReceiveAttack(0, 2);

            Assert.AreEqual<Enums.AttackResult>(result, Enums.AttackResult.Hit);
        }

        [TestMethod]
        public void Attack_Pass_IsSink()
        {
            _stateTracker.Setup();
            
            Ship newShip1 = new Ship() { Name = "s1", StartRow = 0, StartCol = 0, Length = 2, Orientation = Enums.ShipOrientation.Horizontal };
            _stateTracker.AddShipToBoard(newShip1);
            Ship newShip2 = new Ship() { Name = "s2", StartRow = 0, StartCol = 5, Length = 2, Orientation = Enums.ShipOrientation.Horizontal };
            _stateTracker.AddShipToBoard(newShip2);

            _stateTracker.ReceiveAttack(0, 0);
            
            var result = _stateTracker.ReceiveAttack(0, 1);

            Assert.AreEqual<Enums.AttackResult>(result, Enums.AttackResult.Sink);
        }

        [TestMethod]
        public void Attack_Pass_IsWin()
        {
            _stateTracker.Setup();
            
            Ship newShip1 = new Ship() { Name = "s1", StartRow = 0, StartCol = 0, Length = 2, Orientation = Enums.ShipOrientation.Horizontal };
            _stateTracker.AddShipToBoard(newShip1);

            _stateTracker.ReceiveAttack(0, 0);
            
            var result = _stateTracker.ReceiveAttack(0, 1);

            Assert.AreEqual<Enums.AttackResult>(result, Enums.AttackResult.Win);
        }
    }
}
