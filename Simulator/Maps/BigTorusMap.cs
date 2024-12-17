using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulator.Maps
{
    public class BigTorusMap(int sizeX, int sizeY) : BigMap(sizeX, sizeY)
    {
        public override Point Next(Point p, Direction d)
        {
            var nextPoint = p.Next(d);
            int x = (nextPoint.X + SizeX) % SizeX;
            int y = (nextPoint.Y + SizeY) % SizeY;
            return new Point(x, y);
        }
        public override Point NextDiagonal(Point p, Direction d)
        {
            var nextDiagonal = p.NextDiagonal(d);
            int x = (nextDiagonal.X + SizeX) % SizeX;
            int y = (nextDiagonal.Y + SizeY) % SizeY;
            return new Point(x, y);
        }
    }
}
