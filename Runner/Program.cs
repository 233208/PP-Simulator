using SimConsole;
using Simulator.Maps;

namespace Simulator;

internal class Program
{
    static void Main(string[] args)
    {

        BigBounceMap map = new BigBounceMap(8, 6);
        List<IMappable> mappables = new List<IMappable>
        {
            new Orc("Gorbag"),
            new Elf("Elandor"),
            new Animals { Description = "Rabbits", Size = 7 },
            new Birds { Description = "Eagle", Size = 5, CanFly = true },
            new Birds { Description = "Ostriches", Size = 5, CanFly = false }
        };

        // Set starting positions
        List<Point> points = new List<Point>
        {
            new Point(2, 3),
            new Point(3, 1),
            new Point(2, 1),
            new Point(5, 5),
            new Point(1, 1)
        };

        // Define moves
        string moves = "ddddddu";

        // Create simulation and visualizer
        Simulation simulation = new Simulation(map, mappables, points, moves);
        MapVisualizer mapVisualizer = new MapVisualizer(map);

        Console.WriteLine("\nStarting positions:");
        mapVisualizer.Draw();

        int turnNumber = 0;

        
        //    while (!simulation.Finished)
        //{
        //    Console.WriteLine("Press any key to continue...");
        //    Console.ReadKey();
        
        //    Console.WriteLine($"\nTurn {turnNumber++}");
       //     Console.WriteLine($"{simulation.CurrentIMappable} goes {simulation.CurrentMoveName}:");

        //    simulation.Turn();
        //    mapVisualizer.Draw();
        //}

        Console.WriteLine("End of simulation!");

        var history = new SimulationHistory(simulation);
        var log = history.TurnLogs[5];
        Console.WriteLine(history._simulation.Moves);
        Console.WriteLine($"Turn: 5 - {log.Mappable} moved {log.Move}");
        foreach (var symbol in log.Symbols)
        {
            Console.WriteLine($"Position: {symbol.Key}, Symbol: {symbol.Value}");
        }

    }
}