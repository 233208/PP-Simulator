using Simulator;
using Simulator.Maps;

namespace SimWeb;

public static class App
{
    public static SimulationHistory SimulationHistory { get; set; }

    static App()
    {
        var map = new BigBounceMap(8, 6);
        var mappables = new List<IMappable>
        {
            new Orc("Gorbag"),
            new Elf("Ariel"),
            new Animals { Description = "Rabbits", Size = 7 },
            new Birds { Description = "Eagle", Size = 5, CanFly = true },
            new Birds { Description = "Ostriches", Size = 5, CanFly = false }
        };

        var points = new List<Point>
        {
            new Point(2, 3),
            new Point(3, 1),
            new Point(5, 1),
            new Point(0, 5),
            new Point(1, 1)
        };

        string moves = "ludrrlduurld";


        var simulation = new Simulation(map, mappables, points, moves);

        SimulationHistory = new SimulationHistory(simulation);
    }
}