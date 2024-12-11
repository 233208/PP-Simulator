using SimConsole;
using Simulator.Maps;

namespace Simulator;

internal class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Starting simulator\n");

        // Initialize map and mappables
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
        string moves = "uuurrrrurlllrurrruuudlduuuuuu";

        // Create simulation and visualizer
        Simulation simulation = new Simulation(map, mappables, points, moves);
        MapVisualizer mapVisualizer = new MapVisualizer(map);

        Console.WriteLine("\nStarting positions:");
        mapVisualizer.Draw();

        int turnNumber = 1;
        while (!simulation.Finished)
        {
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();

            Console.WriteLine($"\nTurn {turnNumber++}");
            Console.WriteLine($"{simulation.CurrentMappable} goes {simulation.CurrentMoveName}:");

            simulation.ExecuteTurn();
            mapVisualizer.Draw();
        }

        Console.WriteLine("End of simulation!");

        // Display historical states
        simulation.History.DisplayState(5);
        Console.WriteLine();
        simulation.History.DisplayState(10);
        Console.WriteLine();
        simulation.History.DisplayState(15);
        Console.WriteLine();
        simulation.History.DisplayState(20);
        Console.WriteLine();
        simulation.History.DisplayState(30);
        Console.WriteLine();
        simulation.History.DisplayState(40);
    }
}