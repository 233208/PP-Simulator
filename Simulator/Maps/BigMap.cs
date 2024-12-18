using System.Collections.Generic;
using System.Drawing;

namespace Simulator.Maps
{
    public abstract class BigMap : Map
    {
        private readonly List<IMappable>?[,] _fields;
        public BigMap(int sizeX, int sizeY) : base(sizeX, sizeY)
        {
            if (sizeX > 1000) throw new ArgumentOutOfRangeException(nameof(sizeX), "Too wide");
            if (sizeY > 1000) throw new ArgumentOutOfRangeException(nameof(sizeY), "Too high");
            _fields = new List<IMappable>[sizeX, sizeY];
        }

    }
}
