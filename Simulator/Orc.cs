namespace Simulator
{
    public class Orc : Creature
    {
        private int _rage;
        public int Rage
        {
            get => _rage;
            init => _rage = Validator.Limiter(value, 0, 10);
        }
        private int _huntCounter = 0;
        public void Hunt()
        {
            _huntCounter++;
            Console.WriteLine($"{Name} is hunting.");
            if (_huntCounter % 2 == 0 && _rage < 10)
            {
                _rage++;
                Console.WriteLine($"Rage up (now it equals {_rage})");
            }
        }
        public Orc(string name, int level = 1, int rage = 1) : base(name, level)
        {
            Rage = rage;
        }
        public Orc() { }
        public override void SayHi() => Console.WriteLine($"Hi, I'm {Name}, my level is {Level}, my rage is {Rage}.");
        public override int Power => (7 * Level) + (3 * Rage);
        public override string Info => $"{Name} [{Level}][{Rage}]";
    }
}
