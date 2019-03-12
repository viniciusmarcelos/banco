using System;
using System.Collections.Generic;
using System.Text;

namespace Chess.Pieces
{
    public class King
    {
        public Position Pos { get; set; }
        public King(Position pos)
        {
            Pos = pos;
        }
        public Position[] MovementOptions()
        {
            int i = 0;
            int max = 8;
            Position[] options = new Position[max];
            Position option1 = new Position(Pos.X, Pos.Y + 1); // ^
            options[i++] = option1;
            Position option2 = new Position(Pos.X, Pos.Y - 1); // v
            options[i++] = option2;
            Position option3 = new Position(Pos.X + 1, Pos.Y); // >
            options[i++] = option3;
            Position option4 = new Position(Pos.X - 1, Pos.Y); // <
            options[i++] = option4;
            Position option5 = new Position(Pos.X + 1, Pos.Y + 1); // >^
            options[i++] = option5;
            Position option6 = new Position(Pos.X - 1, Pos.Y - 1); // v<
            options[i++] = option6;
            Position option7 = new Position(Pos.X - 1, Pos.Y + 1); // <^
            options[i++] = option7;
            Position option8 = new Position(Pos.X + 1, Pos.Y - 1); // >v
            options[i] = option8;
            return options;
        }
    }
}
