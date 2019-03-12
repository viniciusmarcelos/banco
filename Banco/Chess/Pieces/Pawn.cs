using System;
using System.Collections.Generic;
using System.Text;

namespace Chess.Pieces
{
    public class Pawn
    {
        public Position Pos { get; set; }
        public Pawn(Position pos)
        {
            Pos = pos;
        }
        public Position[] MovementOptions()
        {
            Position option1 = new Position(Pos.X, Pos.Y + 1);
            Position[] options = new Position[] { option1 };
            return options;
        }
    }
}
