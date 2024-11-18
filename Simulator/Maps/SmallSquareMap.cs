namespace Simulator.Maps
{
    /// <summary>
    /// Small square map with a side size between 5 and 20 points.
    /// </summary>
    public class SmallSquareMap : Map
    {
        /// <summary>
        /// Size of the map.
        /// </summary>
        public int Size { get; }

        /// <summary>
        /// Constructor for SmallSquareMap.
        /// </summary>
        /// <param name="size">Size of the map side.</param>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when the size is not within the allowed range.</exception>
        public SmallSquareMap(int size)
        {
            if (size < 5 || size > 20)
            {
                throw new ArgumentOutOfRangeException(nameof(size), "Rozmiar mapy musi być z zakresu 5-20.");
            }

            Size = size;
        }

        public override bool Exist(Point p) => p.X >= 0 && p.X < Size && p.Y >= 0 && p.Y < Size;

        public override Point Next(Point p, Direction d)
        {
            var nextPoint = p.Next(d);
            if (!Exist(nextPoint)) return p;
            return nextPoint;
        }


        public override Point NextDiagonal(Point p, Direction d)
        {
            var nextDiagonal = p.NextDiagonal(d);
            if (!Exist(nextDiagonal)) return p;
            return nextDiagonal;
        }
        public override string ToString() => $"Utworzono mapę o rozmiarze: {Size}";
    }
}