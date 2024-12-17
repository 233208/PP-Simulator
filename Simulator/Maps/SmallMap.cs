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

    }
}
