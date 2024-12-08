﻿namespace Simulator.Maps
{
    /// <summary>
    /// Map of points.
    /// </summary>
    public abstract class Map
    {
        public int SizeX { get; }
        public int SizeY { get; }
        public Map(int sizeX, int sizeY) 
        {
            if (sizeX < 5) throw new ArgumentOutOfRangeException(nameof(sizeX), "Too narrow");
            if (sizeY < 5) throw new ArgumentOutOfRangeException(nameof(sizeY), "Too short");
            SizeX = sizeX;
            SizeY = sizeY;
        }
        /// <summary>
        /// Check if give point belongs to the map.
        /// </summary>
        /// <param name="p">Point to check.</param>
        /// <returns></returns>
        public virtual bool Exist(Point p) => p.X >= 0 && p.X < SizeX && p.Y >= 0 && p.Y < SizeY;
        /// <summary>
        /// Next position to the point in a given direction.
        /// </summary>
        /// <param name="p">Starting point.</param>
        /// <param name="d">Direction.</param>
        /// <returns>Next point.</returns>
        public abstract Point Next(Point p, Direction d);

        /// <summary>
        /// Next diagonal position to the point in a given direction 
        /// rotated 45 degrees clockwise.
        /// </summary>
        /// <param name="p">Starting point.</param>
        /// <param name="d">Direction.</param>
        /// <returns>Next point.</returns>
        public abstract void Add(IMappable mappable, Point p);

        public abstract void Remove(IMappable mappable, Point p);

        public void Move(IMappable mappable, Point from, Point to)
        {
            Remove(mappable, from);
            Add(mappable, to);
        }
        public abstract List<IMappable>? At(Point p);
        public abstract List<IMappable>? At(int x, int y);
        public abstract Point NextDiagonal(Point p, Direction d);
        public override string ToString() => $"{GetType().Name}: {Exist}, {Next}, {NextDiagonal}";
    }
}
