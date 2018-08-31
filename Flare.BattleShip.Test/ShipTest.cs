using Microsoft.VisualStudio.TestTools.UnitTesting;
using Flare.BattleShip.Ships;

namespace Flare.BattleShip.Test
{
    [TestClass]
    public class ShipTest
    {
        /// <summary>
        /// Makes sure it creates a ship correctly
        /// </summary>
        [TestMethod]
        public void CreateShip()
        {
            var ship = new Destroyer(Direction.Horizontal, 1, 1);
            Assert.IsNotNull(ship);
        }

        /// <summary>
        /// Check to see if hit registers horizontally correctly
        /// </summary>
        [TestMethod]
        public void HitHorizontalShip()
        {
            var ship = new Destroyer(Direction.Horizontal, 1, 1);
            var result = ship.Attack(1, 1);
            Assert.AreEqual(true, result);
        }

        /// <summary>
        /// Check to see if miss registers horizontally correctly
        /// </summary>
        [TestMethod]
        public void MissHorizontalShip()
        {
            var ship = new Destroyer(Direction.Horizontal, 1, 1);
            var result = ship.Attack(3, 1);
            Assert.AreEqual(false, result);
        }

        /// <summary>
        /// Check to see if hit registers vertically correctly
        /// </summary>
        [TestMethod]
        public void HitVerticalShip()
        {
            var ship = new Destroyer(Direction.Vertical, 1, 1);
            var result = ship.Attack(1, 2);
            Assert.AreEqual(true, result);
        }

        /// <summary>
        /// Check to see if miss registers vertically correctly
        /// </summary>
        [TestMethod]
        public void MissVerticalShip()
        {
            var ship = new Destroyer(Direction.Vertical, 1, 1);
            var result = ship.Attack(2, 1);
            Assert.AreEqual(false, result);
        }

        /// <summary>
        /// Check to see if a ship is correctly destroyed if all parts are hit
        /// </summary>
        [TestMethod]
        public void DestroyShip()
        {
            var ship = new Submarine(Direction.Horizontal, 1, 1);
            ship.Attack(1, 1);
            ship.Attack(2, 1);
            ship.Attack(3, 1);

            var result = ship.IsDestroyed;

            Assert.AreEqual(true, result);
        }

        /// <summary>
        /// Check to see if partial destroyed ship is not classified as destroyed
        /// </summary>
        [TestMethod]
        public void NotDestroyShip()
        {
            var ship = new Destroyer(Direction.Horizontal, 1, 1);
            ship.Attack(1, 1);

            var result = ship.IsDestroyed;

            Assert.AreEqual(false, result);
        }
    }
}
