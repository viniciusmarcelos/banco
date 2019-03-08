using System;

namespace ObjectExercices
{
    class Program
    {
        static void Main(string[] args)
        {
            Point point1 = new Point(1, 3);
            Point point2 = new Point(4, 5);
            Console.WriteLine("A distância entre os pontos é {0:0.00}.", point1.DistanceTo(point2));

            Console.ReadKey();
        }
        public class Point
        {
            public int X { get; set; }
            public int Y { get; set; }
            public Point(int x, int y)
            {
                X = x;
                Y = y;
            }
            public double DistanceTo(Point other)
            {
                return Math.Sqrt(Math.Pow(X - other.X, 2) + Math.Pow(Y - other.Y, 2));
            }
        }
    }
}
