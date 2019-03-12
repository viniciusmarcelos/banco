namespace Chess.Pieces
{
    public class Rook
    {
        public Position Pos { get; set; }
        public Rook(Position pos)
        {
            Pos = pos;
        }

        public Position[] MovementOptions()
        {
            return MovementCalculator.Straight(Pos, 7);
        }
    }
}
