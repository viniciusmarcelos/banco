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
            var straight = MovementCalculator.Straight(Pos, 7);
            var diagonal = MovementCalculator.Diagonal(Pos, 7);

            var positions = new Position[straight.Length + diagonal.Length];
            for (int i = 0; i < straight.Length; i++)
            {
                positions[i] = straight[i];
            }
            for (int i = 0; i < diagonal.Length; i++)
            {
                positions[i + straight.Length] = diagonal[i];
            }

            return positions;
        }
    }
}
