namespace Simulator.Maps;

internal static class MoveRules
{
    public static Point WallNext(Map m, Point p, Direction d)
    {
        var nextPoint = p.Next(d);
        if (!m.Exist(nextPoint)) return p;
        return nextPoint;
    }
    public static Point WallNextDiagonal(Map m, Point p, Direction d)
    {
        var nextPoint = p.Next(d);
        if (!m.Exist(nextPoint)) return p;
        return nextPoint;
    }
}
