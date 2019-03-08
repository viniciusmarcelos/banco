using System;

namespace Chess
{
    class Program
    {
        static void Main(string[] args)
        {
            Position pawn1StartingPosition = new Position(0, 1);
            Pawn pawn1 = new Pawn(pawn1StartingPosition);
            Position[] pawn1MovementOptions = pawn1.MovementOptions();
            Console.WriteLine("A posição inicial do Peão 1 é:");
            pawn1.Pos.Print();
            Console.WriteLine("A posição válida para movimento dele é:");
            pawn1MovementOptions[0].Print();
            Console.WriteLine();

            Position rook1StartingPosition = new Position(0, 0);
            Rook rook1 = new Rook(rook1StartingPosition);
            Position[] rook1MovementOptions = rook1.MovementOptions();
            Console.WriteLine("A posição inicial da Torre 1 é:");
            rook1.Pos.Print();
            Console.WriteLine("As posições válidas para movimento dele são:");
            for (int i = 0; i < rook1.MovementOptions().Length; i++)
            {
                rook1MovementOptions[i].Print();
            }

            Position bishop1StartingPosition = new Position(2, 0);
            Bishop bishop1 = new Bishop(bishop1StartingPosition);
            Position[] bishop1MovementOptions = bishop1.MovementOptions();
            Console.WriteLine("A posição inicial do Bispo 1 é:");
            bishop1.Pos.Print();
            Console.WriteLine("As posições válidas para movimento dele são:");
            for (int i = 0; i < bishop1.MovementOptions().Length; i++)
            {
                bishop1MovementOptions[i].Print();
            }

            Position knight1StartingPosition = new Position(1, 0);
            Knight knight1 = new Knight(knight1StartingPosition);
            Position[] knight1MovementOptions = knight1.MovementOptions();
            Console.WriteLine("A posição inicial do Cavaleiro 1 é:");
            knight1.Pos.Print();
            Console.WriteLine("As posições válidas para movimento dele são:");
            for (int i = 0; i < knight1.MovementOptions().Length; i++)
            {
                knight1MovementOptions[i].Print();
            }

            Position queen1StartingPosition = new Position(4, 0);
            Queen queen1 = new Queen(queen1StartingPosition);
            Position[] queen1MovementOptions = queen1.MovementOptions();
            Console.WriteLine("A posição inicial da Rainha 1 é:");
            queen1.Pos.Print();
            Console.WriteLine("As posições válidas para movimento dela são:");
            for (int i = 0; i < queen1.MovementOptions().Length; i++)
            {
                queen1MovementOptions[i].Print();
            }

            Position king1StartingPosition = new Position(3, 0);
            King king1 = new King(king1StartingPosition);
            Position[] king1MovementOptions = king1.MovementOptions();
            Console.WriteLine("A posição inicial do Rei 1 é:");
            king1.Pos.Print();
            Console.WriteLine("As posições válidas para movimento dele são:");
            for (int i = 0; i < king1.MovementOptions().Length; i++)
            {
                king1MovementOptions[i].Print();
            }
            Console.ReadKey();
        }
    }
}
