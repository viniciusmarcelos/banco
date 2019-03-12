using System;

namespace Chess
{
    public class Position
    {
        public int X { get; }
        public int Y { get; }

        public Position(int x, int y)
        {
            X = x;
            Y = y;
        }

        public Position Add(Position other)
        {
            return new Position(X + other.X, Y + other.Y);
        }

        public Position Multiply(int multiplier)
        {
            return new Position(X * multiplier, Y * multiplier);
        }

        public void Print()
        {
            Console.WriteLine("({0},{1})", X, Y);
        }
    }
}
