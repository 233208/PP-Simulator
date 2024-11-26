using Simulator.Maps;

namespace Simulator
{
    public abstract class Creature
    {
        private string _name = "Unknown";
        private int _level = 1;

        public Map? Map { get; private set; }
        public Point Position { get; private set; }

        public string Name
        {
            get => _name;
            init => _name = Validator.Shortener(value, 3, 15, '#');

        }
        public int Level
        {
            get => _level;
            init => _level = Validator.Limiter(value, 1, 10);
        }
        public abstract int Power { get; }
        public Creature(string name, int level = 1)
        {
            Name = name;
            Level = level;
        }
        public Creature() { }
        public abstract string Greeting();

        public abstract string Info { get; }
        public override string ToString()
        {
            return $"{GetType().Name.ToUpper()}: {Info}";
        }

        public void Upgrade()
        {
            if (_level < 10)
                _level++;
        }
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
        public abstract char MapSymbol { get; }

    }
}
