namespace Simulator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Starting Simulator\n");

            Lab5a();
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


    }
}