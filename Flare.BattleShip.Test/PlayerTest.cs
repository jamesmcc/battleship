using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Flare.BattleShip.Ships;

namespace Flare.BattleShip.Test
{
    [TestClass]
    public class PlayerTest
    {
        [TestMethod]
        public void Create()
        {
            var player = new Player(10, 10);
            Assert.IsNotNull(player);
        }

        /// <summary>
        /// Add a ship to the board
        /// </summary>
        [TestMethod]
        public void AddShip()
        {
            var player = new Player(10, 10);
            player.AddShip(new Submarine(Direction.Horizontal, 7, 1));

            Assert.IsNotNull(player);
        }

        /// <summary>
        /// Place a ship outside the boundaries horizontally should error
        /// </summary>
        [TestMethod]
        public void ShipOutsideHorizontalBoundry()
        {
            var player = new Player(10, 10);
            var ex = Assert.ThrowsException<Exception>(
                () => player.AddShip(new Battleship(Direction.Horizontal, 7, 1)));

            Assert.AreEqual("Ship goes outside board", ex.Message);
        }

        /// <summary>
        /// An exception should occur if the ship goes out the vertical board boundaries
        /// </summary>
        [TestMethod]
        public void ShipOutsideVerticalBoundry()
        {
            var player = new Player(10, 10);
            var ex = Assert.ThrowsException<Exception>(
                () => player.AddShip(new Battleship(Direction.Horizontal, 7, 1)));

            Assert.AreEqual("Ship goes outside board", ex.Message);
        }

        /// <summary>
        /// Test that an exception occurs when the ships overlap
        /// </summary>
        [TestMethod]
        public void ShipsOverlap()
        {
            var player = new Player(10, 10);
            player.AddShip(new Destroyer(Direction.Horizontal, 1, 1));

            var ex = Assert.ThrowsException<Exception>(
                () => player.AddShip(new Battleship(Direction.Vertical, 1, 1)));

            Assert.AreEqual("Ship overlaps a previous placed ship", ex.Message);
        }

        /// <summary>
        /// Check that game isnt over if all but one is destroyed
        /// </summary>
        [TestMethod]
        public void OneShipStillAlive()
        {
            var player = new Player(10, 10);
            player.AddShip(new Destroyer(Direction.Horizontal, 1, 1));
            player.AddShip(new Destroyer(Direction.Horizontal, 3, 1));

            player.Attack(1, 1);
            player.Attack(2, 1);
            player.Attack(3, 1);

            Assert.AreEqual(false, player.GameOver);
        }

        [TestMethod]
        public void GameOver()
        {
            var player = new Player(10, 10);
            player.AddShip(new Destroyer(Direction.Horizontal, 1, 1));
            player.AddShip(new Destroyer(Direction.Horizontal, 3, 1));

            player.Attack(1, 1);
            player.Attack(2, 1);
            player.Attack(3, 1);
            player.Attack(4, 1);

            Assert.AreEqual(true, player.GameOver);
        }
    }
}
