using System.Diagnostics.Metrics;

namespace Simulator
{
    public class Elf : Creature
    {
        private int _agility;
        public int Agility
        {
            get => _agility;
            init
            {
                _agility = value;
                if (_agility < 1) { _agility = 1; }
                if (_agility > 10) { _agility = 10; }

            }
        }
        private int _counter = 0;

        public void Sing()
        {
            _counter++;
            Console.WriteLine($"{Name} is singing.");
            if (_counter % 3 == 0 && _agility < 10)
            {
                _agility++;
                Console.WriteLine($"Agility up (now it equals {_agility})");
            }
        }
        public Elf(string name, int level = 1, int agility = 1) : base(name, level)
        {
            Agility = agility;
        }
        public Elf() { }
        public override void SayHi() => Console.WriteLine($"Hi, I'm {Name}, my level is {Level}, my agility is {Agility}.");
        public override int Power => (8* Level)+(2*Agility);
    }
}
