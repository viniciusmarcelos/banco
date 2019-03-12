using System;
using System.Collections.Generic;
using System.Text;

namespace Chess
{
    public class Position
    {
        public int X { get; set; }
        public int Y { get; set; }
        public Position(int x, int y)
        {
            X = x;
            Y = y;
        }
        public void Print()
        {
            Console.WriteLine("({0},{1})", X, Y);
        }
    }
}
