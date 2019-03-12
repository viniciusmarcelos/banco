using System;
using System.Collections.Generic;
using System.Text;

namespace Chess.Pieces
{
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
}
