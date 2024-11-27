namespace Simulator.Maps
{
    public abstract class SmallMap : Map
    {
        private readonly List<IMappable>?[,] _fields;
        public SmallMap(int sizeX, int sizeY) : base(sizeX, sizeY)
        {
            if (sizeX > 20) throw new ArgumentOutOfRangeException(nameof(sizeX), "Too wide");
            if (sizeY > 20) throw new ArgumentOutOfRangeException(nameof(sizeY), "Too high");
            _fields = new List<IMappable>[sizeX, sizeY];
        }
        public override void Add(IMappable mappable, Point p)
        {
            if (_fields[p.X, p.Y] == null)
            {
                _fields[p.X, p.Y] = new List<IMappable>();
            }
            _fields[p.X, p.Y]?.Add(mappable);
        }
        public override void Remove(IMappable mappable, Point p) => _fields[p.X, p.Y]?.Remove(mappable);
        public override List<IMappable>? At(Point p) => _fields[p.X, p.Y];
        public override List<IMappable>? At(int x, int y) => _fields[x, y];
    }
}
