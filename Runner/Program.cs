using SimConsole;
using Simulator.Maps;
using System.Text;

namespace Simulator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Starting Simulator\n");

            SmallSquareMap map = new SmallSquareMap(5);
            List<IMappable> mappables = new List<IMappable>
            {
                new Orc("Gorbag"),
                new Elf("Elandor")
            };
            List<Point> points = new List<Point>
            {
                new Point(2, 2),
                new Point(3, 1)
            };
            string moves = "dlrludludrrlrrruduuuuuuuu";

            Simulation simulation = new Simulation(map, mappables, points, moves);
            MapVisualizer mapVisualizer = new MapVisualizer(simulation.Map);

            Console.WriteLine("\nStarting positions:");
            mapVisualizer.Draw();

            int turnNumber = 1;
            while (!simulation.Finished)
            {
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();

                Console.WriteLine($"\nTurn {turnNumber++}");
                Console.WriteLine($"{simulation.CurrentIMappable} goes {simulation.CurrentMoveName}:");

                simulation.Turn();
                mapVisualizer.Draw();
            }

            Console.WriteLine("End of simulation!");
        }

    }



    }
