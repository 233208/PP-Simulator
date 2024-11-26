using System;
using System.Diagnostics.Metrics;

namespace Simulator
{
    public class Elf : Creature
    {
        private int _agility;
        public int Agility
        {
            get => _agility;
            init => _agility = Validator.Limiter(value, 0, 10);
        }
        private int _singCounter = 0;

        public void Sing()
        {
            _singCounter++;
            if (_singCounter % 3 == 0 && _agility < 10)
            {
                _agility++;
            }
        }
        public Elf(string name, int level = 1, int agility = 1) : base(name, level)
        {
            Agility = agility;
        }
        public Elf() { }
        public override string Greeting() => $"Hi, I'm {Name}, my level is {Level}, my agility is {Agility}.";
        public override int Power => (8* Level)+(2*Agility);
        public override string Info => $"{Name} [{Level}][{Agility}]";
        public override char MapSymbol => 'E';
    }
}
