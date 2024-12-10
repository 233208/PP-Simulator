using System.Collections.Generic;
using System.Drawing;

namespace Simulator.Maps
{
    public class BigMap : Map
    {
        private readonly Dictionary<Point, List<IMappable>> _fields;

        public BigMap(int sizeX, int sizeY) : base(sizeX, sizeY)
        {
            if (sizeX > 1000 || sizeY > 1000)
                throw new ArgumentOutOfRangeException("Map size cannot exceed 1000x1000.");
            _fields = new Dictionary<Point, List<IMappable>>();
        }

        public override void Add(IMappable mappable, Point p)
        {
            if (!_fields.ContainsKey(p))
            {
                _fields[p] = new List<IMappable>();
            }
            _fields[p].Add(mappable);
        }

        public override void Remove(IMappable mappable, Point p)
        {
            if (_fields.ContainsKey(p))
            {
                _fields[p].Remove(mappable);
                if (_fields[p].Count == 0)
                {
                    _fields.Remove(p);
                }
            }
        }

        public override List<IMappable>? At(Point p)
        {
            return _fields.ContainsKey(p) ? _fields[p] : null;
        }

        public override List<IMappable>? At(int x, int y)
        {
            return At(new Point(x, y));
        }

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
