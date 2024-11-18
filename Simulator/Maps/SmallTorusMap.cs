namespace Simulator.Maps
{
    public class SmallTorusMap : Map
    {
        public int Size { get; }
        public SmallTorusMap(int size)
        {
            if (size < 5 || size > 20) throw new ArgumentOutOfRangeException(nameof(size), "Rozmiar mapy musi być z zakresu 5-20.");
            Size = size;
        }
        public override bool Exist(Point p) => p.X >= 0 && p.X < Size && p.Y >= 0 && p.Y < Size;

        public override Point Next(Point p, Direction d)
        {
            var nextPoint = p.Next(d);
            int x = (nextPoint.X + Size) % Size;
            int y = (nextPoint.Y + Size) % Size;
            return new Point(x, y);
        }

        public override Point NextDiagonal(Point p, Direction d)
        {
            var nextDiagonal = p.NextDiagonal(d);
            int x = (nextDiagonal.X + Size) % Size;
            int y = (nextDiagonal.Y + Size) % Size;
            return new Point(x, y);
        }
    }
}
