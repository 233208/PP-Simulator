namespace Simulator.Maps
{
    /// <summary>
    /// Small square map with a side size between 5 and 20 points.
    /// </summary>
    public class SmallSquareMap : SmallMap
    {
        public SmallSquareMap(int size) : base(size, size) { }
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
    }
}