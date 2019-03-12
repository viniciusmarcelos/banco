namespace Chess.Pieces
{
    public class Bishop
    {
        public Position Pos { get; set; }

        public Bishop(Position pos)
        {
            Pos = pos;
        }

        public Position[] MovementOptions()
        {
            return MovementCalculator.Diagonal(Pos, 7);
        }
    }
}
