﻿namespace Simulator
{
    internal class Creature
    {
        public string Name { get; set; }
        public int Level { get; set; }
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

        public string Info()
        { 
            return $"{Name} [{Level}]";
        }

    }
}
