using Simulator.Maps;

namespace Simulator
{
    public class Animals : IMappable
    {
        private string _description = "Unknown";
        public Map? Map { get; private set; }
        public Point Position { get; private set; }
        public required string Description
        {
            get => _description;
            init => _description = Validator.Shortener(value, 3, 15, '#');
        }
        public uint Size { get; set; } = 3;
        public virtual string Info => $"{Description} <{Size}>";

        public virtual char MapSymbol => 'A';

        public void Go(Direction direction)
        {
            if (Map == null) throw new InvalidOperationException("Map does not exist.");
            Point to = Map.Next(Position, direction);
            Map.Move(this, Position, to);
            Position = to;
        }

        public void InitMapAndPosition(Map map, Point position)
        {
            if (Map != null) throw new InvalidOperationException("Map already exists.");
            Map = map;
            Position = position;
            Map = map.Exist(position) ? map : throw new InvalidOperationException("Position not on the map.");
            Map.Add(this, position);
        }

        public override string ToString()
        {
            return $"{GetType().Name.ToUpper()}: {Info}";
        }
        protected virtual Point GetNewPosition(Direction direction)
        {
            return Map.Next(Position, direction);
        }

    }
}

