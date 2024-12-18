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
            new Orc("Gorbag") {Level = 9, Rage = 5 },
            new Elf("Elandor") {Level = 9, Agility = 5 },
            new Orc("Alfred") {Level = 9, Rage = 5 },
            new Elf("Brung") {Level = 9, Agility = 5 },
            new Orc("Batista") {Level = 9, Rage = 5 },
            new Elf("Dexter") {Level = 9, Agility = 5 }


        };

        // Set starting positions
        List<Point> points = new List<Point>
        {
            new Point(2, 3),
            new Point(3, 1),
            new Point(2, 1),
            new Point(5, 5),
            new Point(1, 1),
            new Point(4, 1)
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
        var logVisualizer = new LogVisualizer(history);

        Console.WriteLine(logVisualizer.Draw(5));
        Console.WriteLine(logVisualizer.Draw(2));
    }
}