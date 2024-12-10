namespace Simulator.Maps
{
    public interface IMappable
    {
        char MapSymbol { get; }

        void Go(Direction direction);
        void InitMapAndPosition(Map map, Point point);
    }
}
