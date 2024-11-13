using Simulator.Maps;

namespace Simulator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Starting Simulator\n");

            // Lab5a();
            Lab5b();
        }
        public static void Lab5a()
        {
            try
            {
                Rectangle rect1 = new Rectangle(2, 3, 5, 8);
                Console.WriteLine("Utworzony prostokąt rect1: " + rect1);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine("Błąd przy tworzeniu prostokąta rect1: " + ex.Message);
            }

            // Test z współrzędnymi w złej kolejności
            try
            {
                Rectangle rect2 = new Rectangle(5, 8, 2, 3);
                Console.WriteLine("Utworzony prostokąt rect2 z przestawionymi współrzędnymi: " + rect2);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine("Błąd przy tworzeniu prostokąta rect2: " + ex.Message);
            }

            // Test tworzenia prostokąta za pomocą punktów
            try
            {
                Point p1 = new Point(1, 1);
                Point p2 = new Point(4, 6);
                Rectangle rect3 = new Rectangle(p1, p2);
                Console.WriteLine("Utworzony prostokąt rect3 z punktów: " + rect3);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine("Błąd przy tworzeniu prostokąta rect3: " + ex.Message);
            }

            // Test na współliniowe punkty
            try
            {
                Rectangle rect4 = new Rectangle(1, 1, 1, 5);
                Console.WriteLine("Utworzony prostokąt rect4: " + rect4);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine("Błąd przy tworzeniu prostokąta rect4: " + ex.Message);
            }

            // Test sprawdzania zawierania punktów
            Rectangle rect6 = new Rectangle(2, 3, 5, 8);
            Point insidePoint = new Point(3, 4);
            Point outsidePoint = new Point(6, 9);
            Console.WriteLine($"Punkt {insidePoint} jest w prostokącie rect6: {rect6.Contains(insidePoint)}");
            Console.WriteLine($"Punkt {outsidePoint} jest w prostokącie rect5: {rect6.Contains(outsidePoint)}");
        }
        public static void Lab5b()
        {
            // Test tworzenia mapy o rozmiarze w przedziale
            try
            {
                SmallSquareMap map = new SmallSquareMap(10);
                Console.WriteLine(map);
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Console.WriteLine("Błąd przy tworzeniu mapy: " + ex.Message);
            }
            Console.Write("\n");
            // Test tworzenia mapy z błednym rozmiarem
            try
            {
                SmallSquareMap invalidMap = new SmallSquareMap(3);
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Console.WriteLine("Błąd przy tworzeniu mapy: " + ex.Message);
            }
            Console.Write("\n");

            // Test metody Exist()
            SmallSquareMap map10 = new SmallSquareMap(10);
            Console.WriteLine(map10);
            Point pointInside = new Point(5, 5);
            Point pointInside2 = new Point(7, 3);
            Point pointOutside = new Point(10, 10);
            Point pointOutside2 = new Point(-4, -3);
            Console.WriteLine($"Punkt {pointInside} na mapie: {map10.Exist(pointInside)}");
            Console.WriteLine($"Punkt {pointOutside} na mapie: {map10.Exist(pointOutside)}");
            Console.WriteLine($"Punkt {pointInside2} na mapie: {map10.Exist(pointInside2)}");
            Console.WriteLine($"Punkt {pointOutside2} na mapie: {map10.Exist(pointOutside2)}");
            Console.Write("\n");

            // Test metody Next()
            Point startPoint = new Point(5, 5);
            Console.WriteLine($"Punkt startowy: {startPoint}");
            Console.WriteLine($"Następny punkt w górę od {startPoint}: {map10.Next(startPoint, Direction.Up)}");
            Console.WriteLine($"Następny punkt w prawo od {startPoint}: {map10.Next(startPoint, Direction.Right)}");
            Console.WriteLine($"Następny punkt w dół od {startPoint}: {map10.Next(startPoint, Direction.Down)}");
            Console.WriteLine($"Następny punkt w lewo od {startPoint}: {map10.Next(startPoint, Direction.Left)}");
            Console.Write("\n");

            // Próba wyjścia poza mapę
            Point edgePoint = new Point(0, 0);
            Console.WriteLine($"Próba wyjścia poza mapę w dół od {edgePoint}: ");
            Console.WriteLine($"Ruch w dół {map10.Next(edgePoint, Direction.Down)}");
            SmallSquareMap map20 = new SmallSquareMap(20);
            Console.WriteLine(map20);
            Point edgePoint2 = new Point(19, 19);
            Console.WriteLine($"Próba wyjścia poza mapę w prawo: ");
            Console.WriteLine($"Ruch w prawo {map20.Next(edgePoint2, Direction.Right)}");
            Console.Write("\n");

            // Test metody NextDiagonal()
            Console.WriteLine($"Następny punkt przekątny w prawo-górę od {startPoint}: {map10.NextDiagonal(startPoint, Direction.Up)}");
            Console.WriteLine($"Następny punkt przekątny w lewo-górę od {startPoint}: {map10.NextDiagonal(startPoint, Direction.Left)}");
            Console.WriteLine($"Następny punkt przekątny w lewo-dół od {startPoint}: {map10.NextDiagonal(startPoint, Direction.Down)}");
            Console.WriteLine($"Następny punkt przekątny w prawo-dół od {startPoint}: {map10.NextDiagonal(startPoint, Direction.Right)}");
        }


    }
}