namespace Simulator
{
    internal class Creature
    {
        private string _name = "Unknown";
        private int _level = 1;
        public string Name {
            get => _name;
            init 
            {
                _name = value.Trim();
                if (_name.Length <= 3)
                    _name = _name.PadRight(3, '#');
                if (_name.Length >= 25)
                {
                    _name = _name.Substring(0, 25).Trim();
                    if (_name.Length <= 3)
                        _name = _name.PadRight(3, '#');
                }
                if (char.IsLower(_name[0]))
                    _name = char.ToUpper(_name[0]) + _name.Substring(1);
            }
        }
        public int Level 
        {
            get => _level;
            init
            {
                _level = value;
                if (_level < 1) { _level = 1; }
                if (_level > 10) { _level = 10; }
                    
            }
        }
        public Creature(string name, int level = 1)
        {
            Name = name;
            Level = level;
        }
        public Creature() { }
        public void SayHi()
        {
            Console.WriteLine($"Hi! I'm {Name}, my level is {Level}.");
        }

        public string Info => $"{Name} [{Level}]";

        public void Upgrade()
        {
            if (_level < 10)
                _level++;
        }

    }
}
