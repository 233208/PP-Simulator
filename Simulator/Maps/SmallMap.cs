namespace Simulator.Maps
{
    public abstract class SmallMap : Map
    {
        public SmallMap(int sizeX, int sizeY) : base(sizeX, sizeY)
        {
            if (sizeX < 5) throw new ArgumentOutOfRangeException(nameof(sizeX), "Too wide");
            if (sizeY < 5) throw new ArgumentOutOfRangeException(nameof(sizeX), "Too high");
        }
    }
}
