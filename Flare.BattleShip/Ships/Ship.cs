using System.Collections.Generic;

namespace Flare.BattleShip.Ships
{

    /// <summary>
    /// The ship object
    /// </summary>
    public abstract class Ship
    {
        public readonly Direction Direction;
        private Dictionary<int, bool> structure;
        public readonly int X;
        public readonly int Y;
        public readonly int Size;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="size">the size of the ship</param>
        /// <param name="direction">the direction the ship is placed</param>
        /// <param name="x">the x coordinate of the ship on the map</param>
        /// <param name="y">the y coordinate of the ship on the map</param>
        public Ship(int size, Direction direction, int x, int y)
        {
            Direction = direction;
            X = x;
            Y = y;
            Size = size;
            structure = new Dictionary<int, bool>();

            for (int i = 0; i < size; i++)
            {
                structure.Add(i, true);
            }            
        }

        /// <summary>
        /// Attack the ship and mark the structure as damaged
        /// </summary>
        /// <param name="x">the x coordinate of the ship on the map</param>
        /// <param name="y">the y coordinate of the ship on the map</param>
        /// <returns>true if its a hit else false</returns>
        public bool Attack(int x, int y)
        {
            if (HitCheck(x, y))
            {
                if (Direction == Direction.Horizontal)
                {
                    structure[x - X] = false;
                }
                else
                {
                    structure[y - Y] = false;                    
                }

                return true;
            }

            return false;
        }

        /// <summary>
        /// Is this location a hit on the ship, this will not mark the ship as damaged
        /// </summary>
        /// <param name="x">the x coordinate of the ship on the map</param>
        /// <param name="y">the y coordinate of the ship on the map</param>
        /// <returns>true if its a collision else false</returns>
        public bool HitCheck(int x, int y)
        {
            if (Direction == Direction.Horizontal)
            {
                return ((y == Y) && ((x >= X) && (x < X + Size)));
            } else
            {
                return ((x == X) && ((y >= Y) && (y < Y + Size)));
            }
        }

        /// <summary>
        /// Checks to see if the ship is destroyed
        /// </summary>
        public bool IsDestroyed
        {
            get
            {
                return !structure.ContainsValue(true);
            }
        }
    }
}
