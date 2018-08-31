using System;
using System.Collections.Generic;
using System.Linq;
using Flare.BattleShip.Ships;

namespace Flare.BattleShip
{
    public class Player
    {
        private readonly int BoardWidth;
        private readonly int BoardHeight;
        private List<Ship> Ships { get; set; }

        public Player(int width = 10, int height = 10)
        {
            BoardWidth = width;
            BoardHeight = height;
            Ships = new List<Ship>();
        }

        /// <summary>
        /// Will check to see if the ship is being placed over another ship
        /// </summary>
        /// <param name="size">How many units the size of the ship</param>
        /// <param name="x">the x coordinate where the ship is to be placed</param>
        /// <param name="y">the y coordinate where the ship is to be placed</param>
        /// <param name="direction">Is the ship placed Horizontal or Vertical</param>
        /// <returns>true if it does overlap else false</returns>
        private bool OverlapCheck(int size, int x, int y, Direction direction)
        {
            foreach (var ship in Ships)
            {
                for (int ii = 0; ii < size; ii++)
                {
                    if (direction == Direction.Horizontal)
                    {
                        if (ship.HitCheck(x + ii, y))
                            return true;
                    }
                    else
                    {
                        if (ship.HitCheck(x, y + ii))
                            return true;
                    }
                }
            }

            return false;
        }

        /// <summary>
        /// Add a ship to the players board
        /// </summary>
        /// <param name="ship">The ship to be added</param>
        public void AddShip(Ship ship)
        {
            //validate ship placement
            if ((ship.X == 0) || (ship.X > BoardWidth) || (ship.Y == 0) || (ship.Y > BoardHeight))
                throw new Exception("Position is out of bounds");

            if ((ship.Direction == Direction.Horizontal) && (ship.X + ship.Size > BoardWidth))
                throw new Exception("Ship goes outside board");

            if ((ship.Direction == Direction.Vertical) && (ship.Y + ship.Size > BoardHeight))
                throw new Exception("Ship goes outside board");

            if (OverlapCheck(ship.Size, ship.X, ship.Y, ship.Direction))
                throw new Exception("Ship overlaps a previous placed ship");

            Ships.Add(ship);
        }

        /// <summary>
        /// Attack the Player and the result of the attack
        /// </summary>
        /// <param name="x">The x coordinate of the attack</param>
        /// <param name="y">The y coordinate of the attack</param>
        /// <returns>the result of the attack: Miss, Hit or Ship Destroyed</returns>
        public AttackResult Attack(int x, int y)
        {
            var result = AttackResult.Miss;

            foreach (var ship in Ships)
            {
                if (ship.Attack(x, y))
                {
                    result = (ship.IsDestroyed) ? AttackResult.Hit : AttackResult.Destroyed;
                    break;
                }
            }

            return result;
        }

        /// <summary>
        /// Has all the ships sunk and the game is over
        /// </summary>
        public bool GameOver
        {
            get
            {
                return Ships.All(s => s.IsDestroyed);
            }
        }
    }
}
