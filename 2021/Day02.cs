namespace aoc2021;

public class Day02
{
    public static async Task Part1()
    {
        Position position = new();
        IEnumerable<Movement> movements = await _getMovements();
        foreach (var move in movements) position.Move(move);
        position.ProductOfCoordinates(); 
    }


    private static async Task<IEnumerable<Movement>> _getMovements()
    {
        var input = await Files.ReadAsync("Input/day02.txt");
        var data = input.Split("\n")
            .Select(s => s.Split(" ", 2))
            .Select(s => new Movement {
                Length = int.Parse(s[1]),
                Direction = s[0] == "up" ? Direction.Up
                    : s[0] == "down" ? Direction.Down
                        : Direction.Forward
            });
        return data;
    }

    public enum Direction
    {
        Forward,
        Up,
        Down
    }

    public class Movement
    {
        public Direction Direction { get; set; }
        public int Length { get; set; }
    }

    public class Position
    {
        public int Horizontal { get; set; }
        public int Depth { get; set; }
        public void Move(Movement movement)
        {
            int length = movement.Length;
            switch (movement.Direction)
            {
                case Direction.Forward: Horizontal += length; break;
                case Direction.Up: Depth -= length; break;
                case Direction.Down: Depth += length; break;

                default: throw new ArgumentOutOfRangeException(nameof(movement.Direction));
            }
        }
        public void WhereAt() => WriteLine(Serialize(new { Horizontal, Depth }));
        public void ProductOfCoordinates() => WriteLine($"Horizontal x Vertical = {Horizontal} x {Depth} = {Horizontal * Depth}");
    }
}
