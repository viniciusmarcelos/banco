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
            return MovementCalculator.FowardSimple(Pos, 1);
        }
    }
}
