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
    public class Rook
    {
        public Position Pos { get; set; }
        public Rook(Position pos)
        {
            Pos = pos;
        }
        public Position[] MovementOptions()
        {
            Position[] options = new Position[28];
            int optionIndex = 0;
            //Creates all options to move up to 7 spaces up on the board.
            int max = 8;
            for (int i = 1; i < max; i++)
            {
                Position currentOption = new Position(Pos.X, Pos.Y + i);
                options[optionIndex] = currentOption;
                optionIndex++;
            }
            //Creates all options to move up to 7 spaces down on the board.
            for (int i = 1; i < max; i++)
            {
                Position currentOption = new Position(Pos.X, Pos.Y - i);
                options[optionIndex] = currentOption;
                optionIndex++;
            }
            //Creates all options to move up to 7 spaces to the right on the board.
            for (int i = 1; i < max; i++)
            {
                Position currentOption = new Position(Pos.X + i, Pos.Y);
                options[optionIndex] = currentOption;
                optionIndex++;
            }
            //Creates all options to move up to 7 spaces to the left on the board.
            for (int i = 1; i < max; i++)
            {
                Position currentOption = new Position(Pos.X - i, Pos.Y);
                options[optionIndex] = currentOption;
                optionIndex++;
            }
            return options;
        }
    }
    public class Bishop
    {
        public Position Pos { get; set; }
        public Bishop(Position pos)
        {
            Pos = pos;
        }
        public Position[] MovementOptions()
        {
            Position[] options = new Position[28];
            int optionIndex = 0;
            //Creates all options to move up to 7 spaces up and right on the board.
            int max = 8;
            for (int i = 1; i < max; i++)
            {
                Position currentOption = new Position(Pos.X + i, Pos.Y + i);
                options[optionIndex] = currentOption;
                optionIndex++;
            }
            //Creates all options to move up to 7 spaces down and right on the board.
            for (int i = 1; i < max; i++)
            {
                Position currentOption = new Position(Pos.X + i, Pos.Y - i);
                options[optionIndex] = currentOption;
                optionIndex++;
            }
            //Creates all options to move up to 7 spaces up and left on the board.
            for (int i = 1; i < max; i++)
            {
                Position currentOption = new Position(Pos.X - i, Pos.Y + i);
                options[optionIndex] = currentOption;
                optionIndex++;
            }
            //Creates all options to move up to 7 spaces down and left on the board.
            for (int i = 1; i < max; i++)
            {
                Position currentOption = new Position(Pos.X - i, Pos.Y - i);
                options[optionIndex] = currentOption;
                optionIndex++;
            }
            return options;
        }
    }
    public class Knight
    {
        public Position Pos { get; set; }
        public Knight(Position pos)
        {
            Pos = pos;
        }
        public Position[] MovementOptions()
        {
            int i = 0;
            int max = 8;
            Position[] options = new Position[max];
            Position option1 = new Position(Pos.X + 2, Pos.Y + 1); // >>^
            options[i++] = option1;
            Position option2 = new Position(Pos.X + 2, Pos.Y - 1); // >>v
            options[i++] = option2;
            Position option3 = new Position(Pos.X + 1, Pos.Y + 2); // >^^
            options[i++] = option3;
            Position option4 = new Position(Pos.X + 1, Pos.Y - 2); // >vv
            options[i++] = option4;
            Position option5 = new Position(Pos.X - 2, Pos.Y + 1); // <<^
            options[i++] = option5;
            Position option6 = new Position(Pos.X - 2, Pos.Y - 1); // <<v
            options[i++] = option6;
            Position option7 = new Position(Pos.X - 1, Pos.Y + 2); // <^^
            options[i++] = option7;
            Position option8 = new Position(Pos.X - 1, Pos.Y - 2); // <vv
            options[i] = option8;
            return options;
        }
    }
    public class Queen
    {
        public Position Pos { get; set; }
        public Queen(Position pos)
        {
            Pos = pos;
        }
        public Position[] MovementOptions()
        {
            Position[] options = new Position[56];
            int optionIndex = 0;
            //Creates all options to move up to 7 spaces up on the board.
            int max = 8;
            for (int i = 1; i < max; i++)
            {
                Position currentOption = new Position(Pos.X, Pos.Y + i);
                options[optionIndex] = currentOption;
                optionIndex++;
            }
            //Creates all options to move up to 7 spaces down on the board.
            for (int i = 1; i < max; i++)
            {
                Position currentOption = new Position(Pos.X, Pos.Y - i);
                options[optionIndex] = currentOption;
                optionIndex++;
            }
            //Creates all options to move up to 7 spaces to the right on the board.
            for (int i = 1; i < max; i++)
            {
                Position currentOption = new Position(Pos.X + i, Pos.Y);
                options[optionIndex] = currentOption;
                optionIndex++;
            }
            //Creates all options to move up to 7 spaces to the left on the board.
            for (int i = 1; i < max; i++)
            {
                Position currentOption = new Position(Pos.X - i, Pos.Y);
                options[optionIndex] = currentOption;
                optionIndex++;
            }
            //Creates all options to move up to 7 spaces up and right on the board.
            for (int i = 1; i < max; i++)
            {
                Position currentOption = new Position(Pos.X + i, Pos.Y + i);
                options[optionIndex] = currentOption;
                optionIndex++;
            }
            //Creates all options to move up to 7 spaces down and right on the board.
            for (int i = 1; i < max; i++)
            {
                Position currentOption = new Position(Pos.X + i, Pos.Y - i);
                options[optionIndex] = currentOption;
                optionIndex++;
            }
            //Creates all options to move up to 7 spaces up and left on the board.
            for (int i = 1; i < max; i++)
            {
                Position currentOption = new Position(Pos.X - i, Pos.Y + i);
                options[optionIndex] = currentOption;
                optionIndex++;
            }
            //Creates all options to move up to 7 spaces down and left on the board.
            for (int i = 1; i < max; i++)
            {
                Position currentOption = new Position(Pos.X - i, Pos.Y - i);
                options[optionIndex] = currentOption;
                optionIndex++;
            }
            return options;
        }
    }
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