namespace Simulator 
{
    public readonly struct Point
    {
        public readonly int X, Y;
        public Point(int x, int y) => (X, Y) = (x, y);
        public override string ToString() => $"({X}, {Y})";
        public Point Next(Direction direction)
        {
            switch (direction)
            {
                default:
                    return default;
                case Direction.Up:
                    return new Point(X, Y + 1);
                case Direction.Right:
                    return new Point(X + 1, Y);
                case Direction.Down:
                    return new Point(X, Y - 1);
                case Direction.Left:
                    return new Point(X - 1, Y);

            }
        }
        public Point NextDiagonal(Direction direction)
        {
            switch (direction)
            {
                default:
                    return new Point(X, Y);
                case Direction.Up:
                    return new Point(X + 1, Y + 1);
                case Direction.Right:
                    return new Point(X + 1, Y - 1);
                case Direction.Down:
                    return new Point(X - 1, Y - 1);
                case Direction.Left:
                    return new Point(X - 1, Y + 1);

            }
        }
    }
    public class Rectangle
    {
        public readonly int X1;
        public readonly int Y1;
        public readonly int X2;
        public readonly int Y2;

        public Rectangle(int x1, int y1, int x2, int y2)
        {
            if (x1 == x2 || y1 == y2)
            {
                throw new ArgumentException("Punkty definiujące prostokąt nie mogą być współliniowe.");
            }

            X1 = Math.Min(x1, x2);
            Y1 = Math.Min(y1, y2);
            X2 = Math.Max(x1, x2);
            Y2 = Math.Max(y1, y2);
        }

        public Rectangle(Point p1, Point p2) : this(p1.X, p1.Y, p2.X, p2.Y) { }


        public bool Contains(Point point) => point.X >= X1 && point.X <= X2 && point.Y >= Y1 && point.Y <= Y2;


        public override string ToString() => $"({X1}, {Y1}):({X2}, {Y2})";

    }
}