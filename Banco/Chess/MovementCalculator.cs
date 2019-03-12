namespace Chess
{
    public class MovementCalculator
    {
        public static Position[] Straight(Position baseLocation, int range)
        {
            var modifiers = new Position[]
            {
                new Position(0, 1),
                new Position(1, 0),
                new Position(0, -1),
                new Position(-1, 0),
            };

            var totalOptions = range * modifiers.Length;
            Position[] options = new Position[totalOptions];
            int count = 0;
            for (int i = 1; i <= range; i++)
            {
                for (int j = 0; j < modifiers.Length; j++)
                {
                    var move = modifiers[j].Multiply(i);
                    options[count] = baseLocation.Add(move);
                    count++;
                }
            }

            return options;
        }

        public static Position[] Diagonal(Position baseLocation, int range)
        {
            var modifiers = new Position[]
            {
                new Position(1, 1),
                new Position(1, -1),
                new Position(-1, 1),
                new Position(-1, -1),
            };

            var totalOptions = range * modifiers.Length;
            Position[] options = new Position[totalOptions];
            int count = 0;
            for (int i = 1; i <= range; i++)
            {
                for (int j = 0; j < modifiers.Length; j++)
                {
                    var move = modifiers[j].Multiply(i);
                    options[count] = baseLocation.Add(move);
                    count++;
                }
            }

            return options;
        }

        // Simplificado em relacao aos anteriores
        public static Position[] FowardSimple(Position baseLocation, int range)
        {
            var modifier = new Position(0, 1);

            Position[] options = new Position[range];
            for (int i = 0; i < range; i++)
            {
                var move = modifier.Multiply(i + 1);
                options[i] = baseLocation.Add(move);

            }

            return options;
        }

        // Igual aos anteriores, mas com codigo desnecessario
        public static Position[] FowardCopyPaste(Position baseLocation, int range)
        {
            var modifiers = new Position[]
            {
                new Position(0, 1)
            };

            var totalOptions = range * modifiers.Length;
            Position[] options = new Position[totalOptions];
            int count = 0;
            for (int i = 1; i <= range; i++)
            {
                for (int j = 0; j < modifiers.Length; j++)
                {
                    var move = modifiers[j].Multiply(i);
                    options[count] = baseLocation.Add(move);
                    count++;
                }
            }

            return options;
        }
    }
}
