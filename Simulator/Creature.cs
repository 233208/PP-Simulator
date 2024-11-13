namespace Simulator
{
    public abstract class Creature
    {
        private string _name = "Unknown";
        private int _level = 1;
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
        public string Go(Direction direction) => $"{direction.ToString().ToLower()}";
           

        public string[] Go(Direction[] directions)
        {
            string[] result = new string[directions.Length];
            for (int i = 0; i < result.Length; i++)
            {
                result[i] = Go(directions[i]);
            }
            return result ;
               
        }

        public string[] Go(string directions) => Go(DirectionParser.Parse(directions));
    }
}
